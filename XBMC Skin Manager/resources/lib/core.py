# -*- coding:utf8 -*-

#-----------------------------------------------------------------------
#                           XBMC Skin Manager                           
#-----------------------------------------------------------------------
# core.py : core classes & functions (upload scripts, etc)              
#-----------------------------------------------------------------------
# Branch    : 0.7                                                       
#-----------------------------------------------------------------------
# Copyright (C) 2007-2008 Julien Desgats                                
#                                                                       
# This program is free software: you can redistribute it and/or modify  
# it under the terms of the GNU General Public License as published by  
# the Free Software Foundation, either version 3 of the License, or     
# (at your option) any later version.                                   
#                                                                       
# This program is distributed in the hope that it will be useful,       
# but WITHOUT ANY WARRANTY; without even the implied warranty of        
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         
# GNU General Public License for more details.                          
#                                                                       
# You should have received a copy of the GNU General Public License     
# along with this program.  If not, see <http://www.gnu.org/licenses/>. 
#-----------------------------------------------------------------------

#TODO: handle progress bar for local installations

import threading
import time
import urllib2
import os
import re
import shutil
import platform
import stat
import subprocess
import copy
import xml.dom.minidom as xml
import wx

import globals
import network
import fs as filesystem
import widgets
import archive
from misc import *

# downloads statistics URL
STATSURL = globals.WEBSITE + "stats.php?skin=%s&type=%s"

# elements for detect XBMC installation
XBMCINSTALL = (("default.xbe",False), ("skin",True), ("scripts",True), ("UserData",True), ("system",True))

# defaults paths and files
DEFAULT_BUILD = "BUILD"
DEFAULT_BAT = "Build"
MODDED_BAT = batchExt("Build_")

#PATH variable used for build scripts (XMBCTex is located on "tools" directory)
SCRIPT_PATH = os.pathsep.join((os.defpath, os.path.join(globals.PROGRAM_PATH, "tools")))

# raised when build directory is not found
class BuildDirNotFound(Exception):pass

# raised when temp path (to keep XPR files) exists and is not a directory
class TempDirExists(Exception):
    def __init__(self, path):
        self.path=path
    def __str__(self, path):
        print "%s is not a directory. Please delete or rename it."%path

class processSkins:
    def __init__(self,svnSkins, httpSkins, instances, frame):
        """ Process all given skins. Prints info messages on stdout.
              svnSkins  : list of processed svn skins
              httpSkins : dictionnary of processed http skins (indexed by their name)
              instances : collection of instances must contain at least SvnTools, ConfigXML, loc, config
              frame     : operations frame instance (for gauges handling)
        """
        # creating local variables
        self.svn  = svnSkins
        self.http = httpSkins
        self.inst = instances.copy()  # the dict will be modified
        self.inst["frame"] = frame
        # some useful shortcuts
        self.cfg = self.inst["config"]
        self.loc = self.inst["loc"]
        # safe GUI procedures
        self.setCurTask = Callback(wx.CallAfter, self.inst["frame"].setCurTask)
        self.setTaskRange = Callback(wx.CallAfter, self.inst["frame"].opTkProgress.SetRange)
        self.setTaskValue = Callback(wx.CallAfter, self.inst["frame"].opTkProgress.SetValue)
        self.setTaskPulse = Callback(wx.CallAfter, self.inst["frame"].opTkProgress.Pulse)
        self.incOvProgress = Callback(wx.CallAfter, self.inst["frame"].incOvProgress)
        # Errors handling : if error happend on a skin, it's name is written here
        # and it isn't processed any more
        self.errors = {"svn":[], "http":[]}
        self.statsAvailable = globals.STATUS["net"]  # is stats page is available ?
        
        # counting tasks
        self.skinCount = len(self.svn) + len(self.http) # will be reused
        tasksCount = self.skinCount * \
                     sum((self.cfg["update"],
                          self.cfg["build"], 
                          self.cfg["upload"], 
                          self.cfg["deltemp"], 
##                          self.cfg["del"]
                        ))
        wx.CallAfter(self.inst["frame"].opOvProgress.SetRange,tasksCount)
        
        # Stops here if there's noting to do
        if tasksCount < 1:
            widgets.safeMsgBox(self.loc(4000),self.loc(4001))
            return
        
        # This is switched to false if a serious error occurs and process is stopped
        cont = True 
        
        # Initialise destination FileSystem (fs.* methods are used onlt for destination
        # operations, all local ones remain with os/shutil functions)
        if self.cfg["upload"] and not self.cfg["local"]:
            self.setCurTask(self.loc(2032),"")
            print self.loc(5005)
            self.fs = connectFTP(self.cfg["IP"], self.cfg["user"], self.cfg["passwd"], self.cfg["xbmcdir"], self.loc)
            cont = bool(self.fs)  # If FTP fails, False is returned
        else:
            # parse HOME directory shortcuts & test install
            self.cfg["xbmcdir"] = os.path.expanduser(self.cfg["xbmcdir"])
            # test local XBMC install if required
            cont = not self.cfg["upload"] or \
                   testLocalXBMC(self.cfg["xbmcdir"]) or \
                   widgets.safeYesNoBox(self.loc(4030), self.loc(4031)%self.cfg["xbmcdir"])
            self.fs = filesystem.FileSystem("local")
            
        
        # for correct counting, SVN skins must be processed before HTTP ones !
        # updating skins
        if self.cfg["update"] and cont:
            print self.loc(5010)
            self.__svnUpdate()
            self.__httpUpdate()
        
        # building skins
        if self.cfg["build"] and cont:
            print self.loc(5015)
            self.__buildSVNskins()
            self.__buildHTTPskins()
        
        # uploading skins
        if self.cfg["upload"] and cont:
            print self.loc(5019)
            cont = self.__uploadSkins("svn")
            if cont : cont = self.__uploadSkins("http")
            
            self.fs.close() # definitly close FTP connection
        
        # deleting temp folders
        if self.cfg["deltemp"] and cont:
            print self.loc(5026)
            cont = self.__delSkins("svn",0)
            if cont : cont = self.__delSkins("http",0)
        
        # deleting complete skin (Buggy : removed)
##        if self.cfg["del"] and cont:
##            print self.loc(5026)
##            cont = self.__delSkins("svn",1)
##            if cont : cont = self.__delSkins("http",1)
        
        
        #finished!
        print self.loc(5030)
        wx.CallAfter(self.inst["frame"].opOvProgress.SetValue,0)
    
    #---Download/Update
    def __svnUpdate(self):
        """ updates SVN skins. Do nothing when SVN is unreacheable """
        if globals.STATUS["svn"]:
            nb = 0   # number of current skin
            for skin in self.svn:
                self.setCurTask(self.loc(2033),skin)
                nb += 1
                try:
                    skinVer = self.inst["svn"].getSkinVersions(skin)
                    if skinVer[0] < skinVer[1]:
                        # skin must be downloaded or updated
                        self.__pulse(threading.Thread(target=self.__updateSVNskin, args=(skin,)))
                        print self.loc(5011)%(skin, nb, self.skinCount)
                    else:
                        # skin is up to date
                        print self.loc(5012)%(skin, nb, self.skinCount)
                except:
                    # an error is occured : the skin will not be processed any more
                    #BUG:apparently not work...
                    debug()
                    self.errors["svn"].append(skin)
                self.incOvProgress()
        elif len(self.svn) > 0:
            # SVN is unreacheable : increments gauge and print info
            self.incOvProgress(self.skinCount)
            print self.loc(5013)
    
    def __updateSVNskin(self, name):
        """ Updates given SVN skin and send statistics """
        self.__sendStats(name, "up" if self.inst["svn"].getSkinVersions(name)[0] > 1 else "dl")
        self.inst["svn"].update(name)
    
    def __httpUpdate(self):
        """ updates HTTP skins. Do nothing when Internet is unreacheable """
        if globals.STATUS["net"]:
            nb = len(self.svn) # SVN skins are processed before HTTP ones
            for skin in self.http:
                self.setCurTask(self.loc(2033),skin)
                nb += 1
                try:
                    if self.http[skin]["lastversion"] != self.http[skin]["localversion"]:
                        # update is available
                        # Create skin directory if not exists
                        if not os.path.isdir(os.path.join(globals.HTTP_SKIN_PATH, skin)):
                            os.makedirs(os.path.join(globals.HTTP_SKIN_PATH, skin))
                        inst = network.urlopen(self.http[skin]["dllink"]) #opened out of thread because we need total size
                        self.__progress(threading.Thread(target=Callback(self.__updateHTTPskin, skin, inst)),
                                        inst.info()["content-length"], inst.getDownloaded)
                        print self.loc(5011)%(skin, nb, self.skinCount)
                    else:
                        # skin is up to date
                        print self.loc(5012)%(skin, nb, self.skinCount)
                except:
                    # an error is occured : the skin will not be processed any more
                    debug()
                    print self.loc(5014)%skin
                    self.errors["http"].append(skin)
                finally:
                    self.incOvProgress()
        elif len(self.http) > 0:
            # Internet is unreacheable : increments gauge and print info
            self.incOvProgress(len(self.http))
            print self.loc(5033)
    
    def __updateHTTPskin(self, name, urlInst):
        """ Download given HTTP with the urlInst skin and send statistics 
              name : name of skin
              ulrInst : instance of network.urlopen 
        """
        self.__sendStats(name, "up" if self.http[name]["localversion"] != "-1" else "dl")
        urlInst.download(os.path.join(globals.HTTP_SKIN_PATH, name, "skin."+self.http[name]["filetype"]))
        self.inst["xmlcfg"].updateHTTPversion(name)
    
    def __sendStats(self, name, type):
        """ Send stats if server is available.
              name : name of skin
              type : type of operation (can be 'dl' or 'up')
        """
        if self.statsAvailable and globals.STATUS["stats"]:
            # no need to send stats if server is unreacheable
            try:
                urllib2.urlopen(STATSURL%(name, type))
            except:
                debug()
                self.statsAvailable = False
    
    #--- Build skins
    def __buildSVNskins(self):
        """ Customizes (strips all pauses) and excecutes BAT files
        """
        # compiles regexp only once for all skins
        pause = re.compile("\s*pause.*", re.IGNORECASE)
        set   = re.compile("\s*set /p.*\n", re.IGNORECASE)
        
        currentDirBak = os.getcwd() # current dir will be changed later
        nb = 0
        for skin in self.svn:
            self.setCurTask(self.loc(2035),skin)
            nb += 1
            
            if skin in self.errors["svn"] :
                # if skin is not processed
                print self.loc(5032)%(skin, nb, self.skinCount)
                continue
            
            # in order to run bat file correctly, current dir must be changed
            os.chdir(os.path.join(globals.SVN_SKIN_PATH, skin))            
            
            if platform.system() in BATCH_EXT.keys(): # the skin can be built
                # retrieve the filename
                if self.cfg["custom"].has_key(skin) and self.cfg["custom"][skin].has_key("batfile"):
                    # first : check if it's user defined
                    batfile = copy.copy(self.inst["xmlcfg"].getCustom(skin)["batfile"]["files"][self.cfg["custom"][skin]["batfile"]])
                elif self.inst["xmlcfg"].getCustom().has_key(skin) and self.inst["xmlcfg"].getCustom(skin).has_key("batfile"):
                    # second : check if bat file is specified in xml config
                    batfile = copy.copy(self.inst["xmlcfg"].getCustom(skin)["batfile"])
                elif os.path.isfile(batchExt(DEFAULT_BAT)):
                    # finally take default bat file if exists
                    batfile = [DEFAULT_BAT]
                else:
                    # if none of possibilities worked : skin can be exported
                    # export is buggy (especialy on windows)!
##                    if widgets.safeYesNoBox(self.loc(4034), self.loc(4035)%skin):
##                        # export skin
##                        self.__exportSkin(skin)
##                        print self.loc(5016)%(skin, nb, self.skinCount)
##                    else: # log error if user won't export skin
##                        self.errors["svn"].append(skin)
##                        print self.loc(5017)%skin
                    self.errors["svn"].append(skin)
                    print self.loc(5017)%skin
                    self.incOvProgress()
                    continue
                
                # strips pauses in bat file (does nothing on shell scripts)
                source = open(batchExt(batfile[0]), "r")
                dest = open(MODDED_BAT, "w")
                for line in source:
                    if not (pause.match(line) or set.match(line)):
                        dest.write(line)
                source.close()
                dest.close()
                
                # execute BAT file
                batfile[0] = MODDED_BAT
                os.chmod(batfile[0], 0755)
                debug("Starting Build",
                      "command : "+" ".join(batfile), 
                      "PATH (for linux) : "+SCRIPT_PATH, 
                      "current dir : "+os.getcwd())
                # environement mustn't be modified on Windows
                env = None if platform.system() in ("Windows", "Microsoft") \
                      else {"env":{"PATH":SCRIPT_PATH}, "shell":True}
                self.__pulse(threading.Thread(target=subprocess.call, args=(batfile,), kwargs=env))
            
            else: # the skin cannot be built, the process is stopped
                print self.loc(5042)%platform.system()
                return false
                
            print self.loc(5016)%(skin, nb, self.skinCount)
            self.incOvProgress()
        
        os.chdir(currentDirBak)  # restore previous current dir
    
    def __exportSkin(self, skin):
        """ Exports curent SVN checkout (ie in current woking dir) into DEFAULT_BUILD directory
            Not currently used !
        """
        # Delete previous BUILD folder
        if os.path.isdir(DEFAULT_BUILD):
            shutil.rmtree(DEFAULT_BUILD)
        os.mkdir(DEFAULT_BUILD)
        # exports current verison
        self.inst["svn"].export(self.__findSkinDir("."), os.path.join(DEFAULT_BUILD, skin))
    
    def __buildHTTPskins(self):
        """ Extract HTTP skins onto BUILD directory.
        """
        nb = len(self.svn) # SVN skins are processed before HTTP ones
        for skin in self.http:
            self.setCurTask(self.loc(2036),skin)
            nb += 1
            
            if skin in self.errors["http"] :
                # if skin is not processed
                print self.loc(5032)%(skin, nb, self.skinCount)
                continue
            try:
                #extract the archive
                arc = archive.Archive(os.path.join(globals.HTTP_SKIN_PATH, skin, "skin."+self.http[skin]["filetype"]))
                self.__progress(threading.Thread(target=arc.extract, args=(os.path.join(globals.HTTP_SKIN_PATH, skin, DEFAULT_BUILD),)),
                                arc.extsize, arc.getExtracted)
            except:
                # an error is occured : the skin will not be processed any more
                debug()
                print self.loc(5018)%skin
                self.errors["http"].append(skin)
            finally:
                print self.loc(5016)%(skin, nb, self.skinCount)
                self.incOvProgress()
    
    #--- Upload Skins
    def __uploadSkins(self, type):
        """ Upload a group of skins.
              type "http" or "svn"
        """
        nb = 0 if type == "svn" else len(self.svn) # SVN skins are processed before HTTP ones
        skinList = self.svn if type == "svn" else self.http
        # functions which handle each customization node
        self.CUSTOMFCT = {"choicefolder1" : self.__cChoiceFolder1,
                          "choicefolder2" : self.__cChoiceFolder2,
                          "optfolder"     : self.__cOptFolder,
                          "optfiles"      : self.__cOptFiles}
        
        #restore FTP if needed
        try:
            self.fs.connect()
            self.fs.login()
        except:
            # failed to restore FTP connection : stop process
            debug()
            print self.loc(5007)
            return False
        
        # create skin directory if not exsist
        if not self.fs.isdir(self.fs.join(self.cfg["xbmcdir"], "skin")):
            self.fs.makedirs(self.fs.join(self.cfg["xbmcdir"], "skin"))
        
        # Saves existing themes
        if self.cfg["keepxpr"]:
            try:
                self.tempDir = self.__createTempDir()
            except TempDirExists, exc:
                # temp path already exists and it's not a directory
                print self.loc(5040)%exc.path
                return False
            except:
                # unhandled exception
                debug()
                return False
        
        for skin in skinList:
            self.setCurTask(self.loc(2037),skin)
            nb += 1
            
            if skin in self.errors[type] :
                # if skin is not processed
                print self.loc(5032)%(skin, nb, self.skinCount)
                continue
            
            try:
                self.__upSkin(skin, type)
            except BuildDirNotFound:
                # build dir is not found
                print self.loc(5021)%skin
                self.errors[type].append(skin)
            except:
                # an unhandled error is occured : the skin will not be processed any more
                debug()
                print self.loc(5024)%skin
                self.errors[type].append(skin)
            else:
                print self.loc(5020)%(skin, nb, self.skinCount)
            finally:
                self.incOvProgress()
        
        # cleanup
        if self.cfg["keepxpr"]:
            self.fs.rmtree(self.tempDir)
        
        self.fs.quit()
        
        return True
    
    def __createTempDir(self):
        """ Creates or clear temp directory on both local or FTP modes.
            Returns directory path.
            Raises TempDirExists if temp path already exists and is not a directory
        """
        tempDir = self.fs.join(self.cfg["xbmcdir"], "xbmcsm_temp")
        # create or clear temp dir if already exists
        if self.fs.isdir(tempDir):
            # It's a directory : it's deleted
            self.fs.rmtree(tempDir)
        elif self.fs.isfile(tempDir):
            # It's not a directory : error is raised
            raise TempDirExists(tempDir)
        self.fs.makedirs(tempDir)
        return tempDir
    
    def __upSkin(self, name, type):
        """ Uploads a skin on Xbox by using previously opened connection
              name : skin name
              type : "http" or "svn"
        """
        
        # determines all working paths (mainly used by macros)
        self.localSkinDir = os.path.join(globals.SVN_SKIN_PATH if type == "svn" else globals.HTTP_SKIN_PATH, name)
        # determine build directory
        self.buildDir = self.__findBuildDir(name)
        if not self.buildDir:
            # if no BUILD directroy is found : stop skin processing
            raise BuildDirNotFound
        #now the skin root dir i.e. where is skin.xml file and media directory
        self.localRootDir = self.__findSkinDir(self.buildDir)
        
        if not self.localRootDir:
            # if no skin directory is found
            raise BuildDirNotFound
        
        # destination path
        self.destSkinDir = self.fs.join(self.cfg["xbmcdir"], "skin", self.localRootDir.split(os.sep)[-1])
        
        # prints computed paths (debug only)
        debug("BUILD dir : %s\nSource dir : %s\nDest dir : %s"%
              (self.buildDir, self.localRootDir, self.destSkinDir))
        
        # delete old skin directory (if exists)
        if self.fs.isdir(self.destSkinDir):
            if self.cfg["keepxpr"] and self.fs.isdir(self.fs.join(self.destSkinDir, "media")):
                # backup media directory 
                self.fs.move(self.fs.join(self.destSkinDir, "media"), self.tempDir, True)
            self.fs.rmtree(self.destSkinDir)
        
        # send main skin directory
        self.__uploadDir(self.localRootDir, self.destSkinDir)
        
        # restore xpr files
        if self.cfg["keepxpr"] and self.fs.isdir(self.fs.join(self.destSkinDir, "media")):
            # put custom themes back except for default themes (existing files are not overwritten)
            self.fs.move(self.tempDir, self.fs.join(self.destSkinDir, "media"), False)
            self.fs.clear(self.tempDir)
        
        # customisations handling
        custom = self.inst["xmlcfg"].getCustom(name)
        if not custom : return # if skin has no customisations, process is finished
        for item in custom:
            # Call defined method for each node
            self.CUSTOMFCT.get(item, dummy)(name, type, custom[item])
    
    #--- Customizations methods
    # Each customization method take 3 arguments : name & type of skin and
    # custom dictionnary generated by xml parsing
    def __cChoiceFolder1(self, name, type, options):
        for item in options:
            if options[item].has_key("default") and \
               self.cfg["custom"][name]["choicefolder1"][item] == options[item]["default"]:
                continue  # don't do anything if default is selected
            src  = os.path.join(self.__parseLocalMacros(options[item]["source"]),self.cfg["custom"][name]["choicefolder1"][item])
            dest = self.__parseDistantMacros(options[item]["destination"])
            print "di|Install choicefolder type 1 from %s to %s"%(src, dest)
            
            self.__uploadDir(src, dest)
    
    def __cChoiceFolder2(self, name, type, options):
        for item in options:
            src  = self.__parseLocalMacros(options[item]["sources"][self.cfg["custom"][name]["choicefolder2"][item]])
            dest = self.__parseDistantMacros(options[item]["destination"])
            print "di|Install choicefolder type 2 from %s to %s"%(src, dest)
            
            self.__uploadDir(src, dest)
    
    def __cOptFolder(self, name, type, options):
        for item in options:
            if not self.cfg["custom"][name]["optfolder"][item] : continue
            src  = self.__parseLocalMacros(options[item]["source"])
            dest = self.__parseDistantMacros(options[item]["destination"])
            print "di|Install optfolder from %s to %s"%(src, dest)
            
            self.__uploadDir(src, dest)
    
    def __cOptFiles(self, name, type, options):
        for item in options:
            if not self.cfg["custom"][name]["optfiles"][item] : continue
            src  = []
            for f in options[item]["sources"]:
                src.append(self.__parseLocalMacros(f))
            dest = self.__parseDistantMacros(options[item]["destination"])
            print "di|Install optfiles %s to %s"%(", ".join(src), dest)
            
            # crate path & copy/upload files
            self.fs.makedirs(dest)
            for f in src:
                self.fs.copy(f, self.fs.join(dest, os.path.basename(f)))
    
    #--- Cleanup
    def __delSkins(self, type, mode):
        """ Clean skin's directories
            type is "http" or "svn"
            mode : 0 for delete only build folder, 1 for delete WHOLE skin
        """
        # specific output messages depending of mode
        vars = ((5027,5028,5029),(5034,5035,5036))
        nb = 0 if type == "svn" else len(self.svn) # SVN skins are processed before HTTP ones
        skinList = self.svn if type == "svn" else self.http
        for skin in skinList:
            self.setCurTask(self.loc(2038),skin)
            nb += 1
            
            # self.__findBuildDir needs it for parse macros
            self.localSkinDir = os.path.join(globals.SVN_SKIN_PATH if type == "svn" else globals.HTTP_SKIN_PATH, skin)
            if not mode:  # delete only build folder
                dir = self.__findBuildDir(skin)
            else : dir = self.localSkinDir
            
            if dir:
                #TODO:BUG:sometimes crash on unclean SVN checkouts!!!
                self.__pulse(threading.Thread(target=self.__delOneSkin,args=(skin, dir, type)))
                # check if deleting went smooth
                if not skin in self.errors[type]:   # successfully deleted
                    print self.loc(vars[mode][0])%(skin, nb, self.skinCount)
                else:                               # unhandled error
                    print self.loc(vars[mode][2])%(skin)
            else:                                   # build dir not found
                print self.loc(vars[mode][1])%skin  # not considered as error
            
            self.incOvProgress()
        return True
    
    def __delOneSkin(self, skinName, dir, type):
        """ Delete one skin with exceptions handling
              skinName : skin to delete
              dir      : directory of skin
              type     : skin's type (svn or http)
        """
        try:
            shutil.rmtree(dir)
        except:
            debug()
            self.errors[type].append(skinName)
    
    #--- Misc methods
    def __uploadDir(self, src, dest):
        """ Uplaods a directory on xbox with path creation and gauge handling
        """
        #TODO:remplacer ça !!!!!!!!!!!!!!!!!!
        self.__progress(threading.Thread(target=self.fs.copytree, args=(src, dest)),
                        dirsize(src), self.fs.getUploaded)
    
    
    def __parseLocalMacros(self, path, parseBuild=True):
        """ Replace macros by real absolute paths for a local path
            Set parseBuild to False to not replace [BUILDdir] macro (need self.buildDir defined)
        """
        path = path.replace("[PGRMdir]", globals.PROGRAM_PATH)
        path = path.replace("[DATAdir]", self.localSkinDir)
        if parseBuild : path = path.replace("[BUILDdir]", self.buildDir)
        path = path.replace("/",os.sep).replace("\\",os.sep)  # separator handling for windows & linux
        return path
    
    def __parseDistantMacros(self, path):
        """ Replace macros by real absolute paths for a distant path
        """
        path = path.replace("[XBMCdir]", self.cfg["xbmcdir"])
        path = path.replace("[SKINdir]", self.destSkinDir)
        path = path.replace("\\","/")
        return path
    
    def __findBuildDir(self, name):
        """ Find skins' build directorys
            Returns the name of directory WITH MACROS!! or nothing if not found
        """
        # determine build directory
        if self.cfg["custom"].has_key(name) and self.cfg["custom"][name].has_key("buildfolder"):
            # first : check if it's user defined
            ret = self.inst["xmlcfg"].getCustom(name)["buildfolder"]["sources"][self.cfg["custom"][name]["buildfolder"]]
        elif self.inst["xmlcfg"].getCustom().has_key(name) and self.inst["xmlcfg"].getCustom(name).has_key("buildfolder"):
            # second : check if build folder is specified in xml config
            ret = self.inst["xmlcfg"].getCustom(name)["buildfolder"]
        elif os.path.isdir(os.path.join(self.localSkinDir, DEFAULT_BUILD)):
            # finally take default build folder if exists
            ret =  "[DATAdir]\\"+DEFAULT_BUILD
        else : return # if nothing works : return nothing.
        # return absolute path
        return self.__parseLocalMacros(ret, False)
        
    
    def __findSkinDir(self,path):
        """ Recurse analysis of build directory to find skin directory
            Returns absolute or relative path depending on initial path nature
            Returns None if no skin directory is found
        """
        dirList = os.listdir(path)
        if ("media" in dirList or "Media" in dirList) and "skin.xml" in dirList:
            # if current path is skin directory
            return path
        # else : parses each subdirectory
        for item in dirList:
            itemPath = os.path.join(path, item)
            if os.path.isdir(itemPath):
                skinPath = self.__findSkinDir(itemPath)
                if skinPath : return skinPath
    
    def __pulse(self, thread):
        """ Starts given thread and pluses the current task gauge while thread is alive
        """
        thread.start()
        while thread.isAlive():
            time.sleep(0.05)
            self.setTaskPulse() 
        
        self.setTaskValue(0)
    
    def __progress(self, thread, range, current):
        """ Starts given thread and make progress current task gauge while thread is alive.
            Resets the gauge at exit.
              thread  : thread to start
              range   : gauge's maximum value
              current : function to call for get current progress 
        """
        self.setTaskRange(range)
        thread.start()
        while thread.isAlive():
            time.sleep(0.05)
            self.setTaskValue(current())
        # reset gauge position
        self.setTaskRange(1)
        self.setTaskValue(0)

#--- FTP Test
def connectFTP(host, user, passwd, dir, loc):
    """ Opens FTP connection for test it. Also tests for XBMC 
        installation on provided dir
        Returns FtpTools instance if suceed, false otherwise
          host, user, passwd : FTP data
          dir : path to XBMC installation
          loc : Language.localized shortcut
    """
    # first test if XBMC path is abolute : relative paths works here but make an incredible mess
    # at skin uploading
    if dir[0] != "/":
        print loc(5039)
        return False
    
    try:
        #Test FTP connection
        fs = filesystem.FileSystem("ftp", {"host":host, "user":user, "passwd":passwd})
        print loc(5006)
        
        return fs if fs.ftpCallback(testXBMC, dir, loc) else False
    except: #TODO:handle FTP error codes (wrong id, pass, etc)
        debug()
        print loc(5007)

def testXBMC(ftp, dir, loc):
    """ Tests if XBMC is current dashboard (based on FTP welcome message)
        and try to locate XBMC on provided folder
        Ask at user to continue if problems are detected
    """
    cont = True
    if "XBMC" in ftp.getwelcome():
        # current dash is probably XBMC : ask for continue
        cont = widgets.safeYesNoBox(loc(4002), loc(4003))
    
    if cont and not set(XBMCINSTALL).issubset(ftp.listdir(dir)):
        # all items are not laocated : XBMC directory is probably wrong
        cont = widgets.safeYesNoBox(loc(4030), loc(4031)%dir)
    
    print loc(5008 if cont else 5031)
    return cont

def testLocalXBMC(path):
    """ Retruns true if XBMC is detected on local path.
        Teste only 'skin' dir existance
    """
    return os.path.isdir(os.path.join(path, "skin"))

def findGuiSettings(path):
    """ Try to find guisettings.xml file in la local XBMC installation
        path : XBMC installation path. It will search here before then in HOME folder.
        Return found path or None.
    """
    # test given path first
    file = os.path.join(path, "userdata", "guisettings.xml")
    if os.path.isfile(file):
        return file
    
    path = os.path.join("XBMC", "userdata", "guisettings.xml")
    # test for XP path
    file = os.path.expanduser(os.path.join("~", "Application Data",path))
    if os.path.isfile(file):
        return file
    
    # test for Vista path
    file = os.path.expanduser(os.path.join("~", "AppData","Roaming",path))
    if os.path.isfile(file):
        return file
    
    #test for Linux path
    file = os.path.expanduser(os.path.join(globals.DEFAULT_PATH, "userdata", "guisettings.xml"))
    if os.path.isfile(file):
        return file

def resetSkinSettings(host, user, passwd, dir, loc, localmode):
    """ Resets XBMC skin parameters by modifying UserData/guisettings.xml
          host, user, passwd : FTP data
          dir : path to XBMC installation
          loc : Language.localized shortcut
          localmode : bool. True if current mode is local
    """
    # ask confirmation to user
    if not widgets.safeYesNoBox(loc(4026),loc(4027)): return
    print loc(5037)
    
    # init filesystem
    if not localmode:
        print loc(5005)
        fs = connectFTP(host, user, passwd, dir, loc)
        path = fs.join(dir, "userdata", "guisettings.xml")
        cont = bool(fs)  # If FTP fails, False is returned
    else:
        # parse HOME directory shortcuts & find userdata
        fs = filesystem.FileSystem("local")
        path = findGuiSettings(os.path.expanduser(dir))
        cont = bool(path)
    
    # stop if something fails
    if not cont:
        print loc(5041)
        return
    
    try:
        # download XML file into a string
        xmlInst= xml.parseString(fs.readfile(path))
        # modify XML tags
        node = xmlInst.getElementsByTagName('lookandfeel')[0]
        node.getElementsByTagName('skin')      [0].childNodes[0].data = 'Project Mayhem III'
        node.getElementsByTagName('font')      [0].childNodes[0].data = 'Default'
        node.getElementsByTagName('skincolors')[0].childNodes[0].data = 'SKINDEFAULT'
        node.getElementsByTagName('skintheme') [0].childNodes[0].data = 'SKINDEFAULT'
        node.getElementsByTagName('soundskin') [0].childNodes[0].data = 'SKINDEFAULT'
        # retour du string
        fs.writefile(path, content=xmlInst.toxml("utf-8"))
    except:
        debug()
        print loc(5038)
    else:
        widgets.safeMsgBox(loc(4028), loc(4029))
    finally:
        print loc(5030)
        fs.close()
    
