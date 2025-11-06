# -*- coding:utf8 -*-

#-----------------------------------------------------------------------
#                           XBMC Skin Manager                           
#-----------------------------------------------------------------------
# network.py : generic classes for FTP, HTTP and SVN handling           
#-----------------------------------------------------------------------
# Last edit : 06/15/2008                                                
# Branch    : 0.6                                                       
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

import os
import StringIO
import shutil
import threading
import re

import globals
import misc


# ****************************************  FTP Class  *********************************************
import ftplib

# Custom exceptions
class MoveError(Exception):
    def __init__(self, src, dest):
        """ Raised when a folder is moved through partitions which is impossible on Xbox
        """
        self.src  = src
        self.dest = dest
    
    def __str__(self):
        return "Unable to move %s to %s. Move folder through physical patitions is impossible"%(self.src, self.dest)

# Errors responses when rename fails
RENAME_ERRORS = ("550 file exists",                                #XBMC error
                 "553 Internal error. Rename was not successful.", #UnleashX error
                 "553 Could not rename file.")                     #Avalaunch error

class FtpTools(ftplib.FTP):
    """ FTP handling class.
        Allow to close and resume connections without repeat IDs. 
        Also add some usefull methods
    """
    def __init__(self, host='', user='', passwd='', acct=''):
        # upload status variables
        self.totalUpload, self.uploaded = -1, -1
        
        self.user, self.passwd, self.acct = '', '', ''  # intialize IDs (tested on login)
        ftplib.FTP.__init__(self, host, user, passwd, acct)
    
    def login(self, user = '', passwd = '', acct = ''):
        """ login user with specified IDs, or with previous IDs or as anonymous (in this order) """
        if not self.user: self.user = 'anonymous' if not user else user
        if not self.passwd: self.passwd = passwd
        if not self.acct: self.acct = acct
        ftplib.FTP.login(self, self.user, self.passwd, self.acct)
    
    def dummy(self, *args):
        """ For developpement only !! Used to test private methods """
        return self.join(*args)
    
    def mkd(self, dirname):
        """ Replacements mkd methdod to handle UnleahX which is not RFC-959 compilant :
            normal response is 257 but it respond 250. Not retrun anything.
            In addition it handle another Xbox limitation : creating directories from root
            is forbidden.
            For finish, if dirnme already exists, nothing is done and no exceptions are generated
        """
        if self.isDir(dirname) : return
        dirbak = self.pwd()
        path = self.__splitPath(dirname)
        self.cwd(path[0])
        resp = self.sendcmd('MKD ' + path[1])
        if resp[0] != "2":  # if resp is not success (doesn’t matter exact reponse)
            raise error_reply, resp
        self.cwd(dirbak)
    
    def cwd(self, dirname):
        """ Replacements mkd methdod to handle UnleahX (him again!) :
            command "CWD ." returns error
        """
        if dirname not in (".", ""):
            ftplib.FTP.cwd(self, dirname)
    
    def uploadDir(self, source=".", dest=".", recurse=False):
        """ Recursively uploads a directory 
              source (string) : local directory to upload. Default : current directory
              dest   (string) : distant destination. Default : current directory
              recurse (bool)  : private parameter (say if this is a recurse call)
            Attribute uploaded gives the total and current uploaded bytes, 
            it can also be called by getUploaded method.
        """
        # status variables init
        if not recurse : 
            self.uploaded = 0
        # Save context and load working directories
        localbak = os.getcwd()
        distbak = self.pwd()
        os.chdir(source)
        # create desination dir if needed
        if dest != "." : self.makedirs(dest)
        self.cwd(dest)
        
        # Uploads all directory content
        for item in os.listdir("."):
            if os.path.isfile(item):
                self.__uploadFile(item, item)
                self.uploaded += os.path.getsize(item)
            elif os.path.isdir(item):
                self.mkd(item)
                self.uploadDir(item, item, True)
        
        #restore dirs
        self.cwd(distbak)
        os.chdir(localbak)
        # restore status variables
        if not recurse:
            self.uploaded = -1
    
    def getUploaded(self):
        """ Returns the currentl uploaded size in bytes while uploadDir is running.
        """
        return self.uploaded

    def uploadFile(self, dest, source=None, content=None):
        """ Uploads source file or a string to dest
              dest   (string) : destination path (including filename).
              source (string) : path to source file
              contant(string) : content to upload
            Specify either of source or content parameters but not both !
        """
        dirbak = self.pwd()
        dest = self.__splitPath(dest)
        self.cwd(dest[0])
        if source : self.__uploadFile(source, dest[1])
        else      : self.__uploadString(content, dest[1])
        self.cwd(dirbak)
    
    def downloadFile(self, dist, local=None):
        """ Download a distant file onto a local folder or returned into a string
              dist  (string) : path to the distant file
              local (string) : path to local file or returned at string if None
                               Default : None
        """
        # IO init
        if local==None : out = StringIO.StringIO()
        else           : out = open(local, 'wb')
        
        # downloading the file
        self.retrbinary('RETR '+dist, out.write)
        
        # data return
        if local==None : return out.getvalue()
        else           : out.close()
    
    def listdir(self, dir='', namesOnly = False):
        """ Return a tuple containing (name(str), isdir(bool)) or just name according
            to namesOnly status for each item on given folder. Based on DIR command
            because NLST is not implemented on all servers.
              dir (string) : path to list. Default : current directory
              namesOnly (bool) : lists only names without isDir bool
        """
        # I don't know why but dir commands always return current WD listing...
        origDir = self.pwd() 
        self.cwd(dir)
        
        ret = []
        # retrieving the directory listing
        l = []
        self.dir(l.append)
        
        for item in l:
            cont = True
            x=len(item)-1
            while cont:
                x-=1
                # string formating : "drw-r--r--   1 XBOX      XBOX        0 May 17 17:49 Vision"
                # locates the ":" for establish the beginning of filename
                cont = item[x-3] != ':'
            if item[x+1:] != '..': #eliminate the parent directory
                ret.append(item[x+1:] if namesOnly else (item[x+1:], item[0] == 'd'))
        
        self.cwd(origDir)
        return tuple(ret)
    
    def moveFolder(self, source, dest, overWrite=False, recurseCall=False):
        """ Move the source folder's content onto dest folder
            exemple for moveFolder("/E/a/b/foo","/E/c") all files located in "/E/a/b/foo" will be in "/E/c"
            Paths can be absolute or relative. Destination folder mut exist.
            overWrite boolean says if existing files in dest folder must be overwritten (True) or not (False)
            if files are identically named. If files are not overwritten, they are still in source path
            after function execution.
            Function returns True if files still exist in source at exit, False otherwise.
            !!WARNING!! : since folders loatad at root directory are physical xbox partitions you can't
                          move files through partitions (you can't move files from E to F for example)
            The recurseCall argument is private (used for recurse)
        """
        filesExists = False  # return value
        path = self.__getRelative(source, dest)
        if not path : raise MoveError(source, dest)  # stops here if both paths are not located on same partition
        if not recurseCall:       #not necessary for recurse calls
            baseWD = self.pwd() #saves working directory
            self.cwd(path[0]) 
            
        for item in self.listdir(path[1][0]):
            if item[1]:
                # the item is a directory : it must be created on destination before move it
                if not self.isDir(self.join(dest, item[0])) : self.mkd(self.join(dest, item[0]))
                filesExists = self.moveFolder(self.join(source, item[0]), self.join(dest, item[0]), overWrite, True)
                # now we can delete source directory (if it's empty)
                if not filesExists : self.rmd(self.join(source, item[0]))
            else:
                try:
                    self.rename(self.join(path[1][0], item[0]), self.join(path[1][1], item[0]))
                except ftplib.error_perm, e:
                    if e.message in RENAME_ERRORS:
                        # apparently rename fails because file already exists in dest folder
                        if overWrite:
                            # delete existing file and then put new one
                            self.delete(self.join(path[1][1], item[0]))
                            self.rename(self.join(path[1][0], item[0]), self.join(path[1][1], item[0]))
                        else : filesExists = True
                    else: raise #error is unhandled
                except : raise  #idem
        
        if not recurseCall : self.cwd(baseWD)
        return filesExists
    
    def isDir(self, path):
        """ Like os.path function but for FTP : returns True if given path is an existing directory.
        """
        bak = self.pwd()
        try:
            self.cwd(path)  # fails if path doesn't exist
            self.cwd(bak)
            return True
        except:
            return False
    
    def isFile(self, path):
        """ Like os.path function but for FTP : returns True if given path is an existing file.
        """
        path = self.__splitPath(path)
        try:
            return (path[1], False) in self.listdir(path[0])   # Fails if dir doesn't exist
        except:
            return False
    
    def delDir(self, dir):
        """ Delete a directory and all its content recursively
            Path can be absolute or relative but be sure that you're not trying to delete current dir !
        """
        dirbak = self.pwd()
        self.cwd(dir)
        # First : delete directory's content
        for item in self.listdir("."):
            if item[1]:
                self.delDir(item[0])
            else:
                self.delete(item[0])
        # Then delete directory itself
        self.cwd("..")
        self.rmd(dir)
        # restore prevois cwd
        self.cwd(dirbak)
    
    def clearDir(self, dir):
        """ Clears a directory, i.e. delete all content without delete directory itself
        """
        dirbak = self.pwd()
        self.cwd(dir)
        for item in self.listdir("."):
            if item[1] : self.delDir(item[0])
            else : self.delete(item[0])
        self.cwd(dirbak)
    
    def makedirs(self, path):
        """ Like os function : create an entire path. If path is already exists, do nothing.
            Path can be absolute or relative
        """
        dirbak = self.pwd()
        # we need to place to root for absolute paths
        if path[0] == "/" : self.cwd("/")
        for dir in path.split("/"):
            if not self.isDir(dir):
                # create directory
                self.mkd(dir)
            self.cwd(dir)
        self.cwd(dirbak)
    
    def join(self, *args):
        """ Like os.path.join function for FTP paths
              *args : pieces to join
        """
        ret = "/".join(args).replace("//","/")
        if args[0] == "" : ret = ret[1:]       # delete falses absloute paths when args[0] is ""
        return ret
    
    def __uploadFile(self, source, dest):
        """ Uploads source file to dest
              source (string) : path to source file
              dest   (string) : destination path (including filename).
            This mustn't be called directly because it's unsafe : 
            "550 Permission denied - Storing in XBOX Root not allowed." can be raised
            if working dir is root.
        """
        f = open(source, "rb")
        self.storbinary("STOR " + dest, f)
        f.close()
    
    def __uploadString(self, content, dest):
        """ Uploads a string into specified destination file
              same limitation than previous method
        """
        self.storbinary("STOR " + dest, StringIO.StringIO(content))
    
    def __splitPath(self, path):
        """ Splits absolute path in two pieces to avoid root directory error with absolute paths on Xbox
            example "/F/foo1/foo2" => ("/F/foo1,"foo2")
        """
        path = path.split("/")
        return ("/".join(path[:-1]), path[-1])
    
    def __getRelative(self, path1, path2):
        """ Returs a tuple of paths :
              (common, (relative1,relative2))
            Example __getRelative("/E/a/b","/E/a/c/d") => ("/E/a", ("b","c/d"))
            Returns False if both paths doesn't have anything in common.
        """
        path1 = path1.split("/")
        path2 = path2.split("/")
        
        i = 0
        while path1[i] == path2[i]:
            i += 1
        if i == 0 : return False # both paths have nothing in common or 
        
        return ("/".join(path1[:i]),("/".join(path1[i:]), "/".join(path2[i:])))



# ****************************************  SVN class  *********************************************
import pysvn

class SvnTools:
    # actions kind for verbose mode (only common updates actions are recognized)
    AC_KIND = {pysvn.wc_notify_action.update_add : "A",
               pysvn.wc_notify_action.update_update : "U",
               pysvn.wc_notify_action.update_delete : "D"}
    def __init__(self, baseURL):
        """ SVN handling class
              baseURL (string)  : repository URL
              checkout (string) : local checkout
        """
        self.baseURL  = baseURL
        self.s = pysvn.Client()
        # For HTTPS connection
        self.s.callback_ssl_server_trust_prompt = self.ssl_server_trust_prompt
        # verbose log
        if globals.STATUS["verb"]:
            self.s.callback_notify = self.verboseInfo
        
        self.skins = misc.CustomDict()   # skins dictionary
        self.lastLog = None  # last retrieved changelog
    
    def ssl_server_trust_prompt(self, trust_dict):
        """ Initialising HTTPS connection """
        retcode = True
        accepted_failures = ~0
        save = False
        return retcode, accepted_failures, save
    
    def verboseInfo(self, eventDict):
        """ Displays SVN infos in verbose mode
        """
        if eventDict["action"] in SvnTools.AC_KIND.keys():
            print SvnTools.AC_KIND[eventDict["action"]] + " " + eventDict["path"][len(globals.SVN_SKIN_PATH)+1:]
        elif eventDict["action"] == pysvn.wc_notify_action.update_completed:
            print eventDict["path"][len(globals.SVN_SKIN_PATH)+1:] + " at revision " + str(eventDict["revision"].number)
    
    def getSkins(self):
        """ Returns the skins dictionary which have the following pattern
              {"SkinName":(localRev, HEADrev), ... }
        """
        return self.skins
    
    def getSkinVersions(self, skin):
        """ Returns (localRev, HEADrev) for given skin.
            Return (0,0) if skin doesn't exist or if called before listrep
        """
        return self.skins[skin] if self.skins.has_key(skin) else (0,0)
    
    def listrep(self, blacklist):
        """ Lists SVN skins with or without HEAD revisions depending on globals.STATUS["net"] state
              blacklist (list) : excluded directories
            Skin list is stored internally, it can be retrieved with getSkins or getSkinVersions methods
        """

        # if SVN synchro is not jumped, we try to list the repository
        if globals.STATUS["net"] and globals.STATUS["svn"]:
            try    : svnlist = self.s.list(self.baseURL)
            except : # SVN is unreachable : only local checkout will be parsed
                globals.STATUS["svn"] = False 
        else:
            # Lists local checkout if SVN is down
            # the dummy string is inserted cos with SVN list function, the first indice represents root URL
            svnlist = [""] + os.listdir(globals.SVN_SKIN_PATH)
            globals.STATUS["svn"] = False
        
        urllen = len(self.baseURL)               # for calculating skin names with svn URLs
        for i in range(1, len(svnlist)):         # eliminate the repository root
            name = svnlist[i][0].path[urllen:] if globals.STATUS["svn"] else svnlist[i]
            if name not in blacklist:
                # revisions tuples : (local rev, HEAD rev)
                self.skins[name] = (self.localrev(name), 
                    svnlist[i][0]["created_rev"].number if globals.STATUS["svn"] else -1)
    
    def localrev(self, name):
        """ Give the local revision of given checkout or -1 if not exists
              name (string) : skin name
        """
        path = os.path.join(globals.SVN_SKIN_PATH, name)
        # Tests if the given directory exists and is a SVN checkout
        if os.path.isdir(os.path.join(path, ".svn")):
            return self.s.info(path).commit_revision.number
        else:
            return -1
    
    def update(self, name):
        """ Update (and relocate if needed) given checkout
            If checkout doesn't exists. Skin will be downloaded
              name (string) : skin name
        """
        if self.localrev(name) > 0:
            # Local checkout extists : update it
            path = os.path.join(globals.SVN_SKIN_PATH, name) # absolute local checkout path
            # Relocates checkout URL (for checkouts which not have the up to date URL)
            if self.s.info(path).url != self.join(name):
                self.s.relocate(self.s.info(path).url, self.join(name), path)
            self.s.update(path)
        else:
            # no local checkout : download skin
            self.download(name)
        # updates skin's local revision
        self.skins[name] = (self.localrev(name), self.skins[name][1])
    
    def download(self,name):
        """ Create a local checkout. Automatically called by update method if local
            checkout doesn't exist.
              name (string) : skin name
        """
        self.s.checkout(self.join(name),os.path.join(globals.SVN_SKIN_PATH, name))
        
    
    def export(self, rep=".", dest="BUILD", clear=True):
        """ Exports recursively SVN repository rep to dest as an unversionned copy
              rep (string) : repository, can be path or URL
              dest(string) : target folder
              clear (bool) : delete dest folder if exists
            Warning : existing data can be overwritten if dest is not cleared
        """
        # clear existing data
        if clear and os.path.isdir(dest):
            shutil.rmtree(dest)
        
        self.s.export(rep, dest, force=True)
    
    def changelog(self,name):
        """ Returns changelog for given skin. It's a tuple of changes, each change contains
            {"rev":int, "date":int(timestamp), "author":str, "message":str}
            When executed in a thread, the changelog can also be retrieved by getLastLog method
        """
        log = self.s.log(self.join(name),
                         pysvn.Revision(pysvn.opt_revision_kind.head),
                         pysvn.Revision(pysvn.opt_revision_kind.number,
                         self.localrev(name)+1))
        log.reverse()
        revlist = []
        for item in log:
            revlist.append({ "rev"     : item["revision"].number,
                             "date"    : item["date"],
                             "author"  : item["author"],
                             "message" : item["message"]} ) 
        self.lastLog =  tuple(revlist)
        return self.lastLog
    
    def getLastLog(self):
        """ Returns instantly last changelog
        """
        return self.lastLog
    
    
    def join(self, *args):
        """ Like os.path function for URLs
              *args : pieces to chain with baseURL
        """
        ret = "/".join((self.baseURL,)+args).replace("//","/").replace(":/","://").replace(' ','%20')
        return ret
    

# **************************************  HTTP classes  *******************************************
import urllib2, time

class urlopen:
    def __init__(self, url, data=None):
        """ Replacement class for urllib2.urlopen function which include some extra functions
            Open the URL url, which can be either a string or a Request object. 
            data may be a string specifying additional data to send to the server, or None if no such data is needed.
        """
        self.downloaded = 0
        self.s = urllib2.urlopen(url, data)
    
    def info(self):
        """ return the meta-information of the page, as a dictionary object
            There is some modifications compared with normal info medthod :
              last-modified field : numeric timestamp is calculated. If no last-modified field is found, None will be recorded
              content-length is now an integer
        """
        infos = self.s.info()
        d = dict(infos)    # strandard dictionary is returned to avoid problem with RFC822 objects
        d["last-modified"] = time.mktime(infos.getdate("last-modified")) if infos.has_key("last-modified") \
                             else None   # time.mktime chshes if None is passed as argument
        d["content-length"] = int(infos["content-length"])
        return d
    
    def geturl(self):
        """ return the URL of the resource retrieved 
        """
        return self.s.geturl()
        
    def download(self, dest):
        """ downloads the file on given dest file. If path doesn't exist it will be created
            If file exists it will be overwritten !
            while downloading the attribute "downloaded" give the current dowloaded size (in bytes).
            To access at downloaded size in a call, use getDownloadedmethod.
        """
        self.downloaded = 0
        
        if not os.path.isdir(os.path.dirname(dest)):
            os.createdirs(os.path.dirname(dest))
        
        fdest = open(os.path.join(dest) ,'wb')
        while True:
            data = self.s.read(1024)
            if data == '':
                break
            else:
                fdest.write(data)
                self.downloaded += 1024
        fdest.close()
    
    def getDownloaded(self):
        """ Return the currently downloaded size in bytes.
        """
        return self.downloaded
    
    def read(self):
        return self.s.read()


# ***  Debugging section  ***
if __name__ == "__main__":
##    globals.SVN_SKIN_PATH = "D:\\Skins XBMC\\Branche0.6\\skins\\SVN"
##    globals.STATUS["net"] = True
##    globals.STATUS["svn"] = True
##    u = urlopen("http://s205077464.onlinehome.fr/files/xbmcsm0.51.source.zip")
##    info = u.info()
##    for key in info:
##        print key, ":", info[key]
        
##    s = FtpTools("new-host.home.","xbox","xbox")
##    s.set_debuglevel(1)
##    s.moveFolder("/F/XBMC/media","/F/XBMC/foo",False)
##    print s.pwd()
##    s.uploadFile("/F/test.txt",content="vjqeiorejqireqjiovrjeqio")
##    s.close()

    dist  = "https://xboxmediacenter.svn.sourceforge.net/svnroot/xboxmediacenter/"
    globals.SVN_SKIN_PATH = "/home/julien/Code/xbmcsm/skins/SVN"
    globals.STATUS["verb"] = True
    s = SvnTools(dist)
    s.update("Containment")
##    s.listrep(())
##    print s.getSkins()
##    s.update("Back-Row")
##    print s.getSkins()
