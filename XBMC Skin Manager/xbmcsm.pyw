#!/usr/bin/python
# -*- coding:utf8 -*-

#-----------------------------------------------------------------------
#                           XBMC Skin Manager                           
#-----------------------------------------------------------------------
# xmbcsm.pyw : main program file                                        
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

#TODO:comment for epydoc (WIP)
#TODO:xbox skin delete
#TODO:handle when xml file is missing and user is offline
#BUG :definitely delete has been removed because of an acess denied error with svn files
#     related lines in gui and core has been commented
if __name__ == "__main__":
    import os, sys, platform
    
    # program absolute path (OS & freeze insensitive)
    path = os.path.abspath(os.path.join(os.path.dirname(sys.argv[0]))) 
    
    if len(sys.argv) <= 1 : sys.argv.append("") # to avoid oversize problems
    sys.path.append(os.path.join(path, "resources", "lib"))
    
    # Check third party modules
    if not hasattr(sys, "frozen"):  # mustnt be run during py2exe 'compiles'
        try:
            import wxversion
            wxversion.select("2.8")
        except ImportError:
            sys.exit("WxPython not detected! Please install WxPython 2.8")
        except wxversion.VersionError:
            sys.exit("Please install WxPython v2.8")
    
    try:
        import pysvn
    except ImportError:
        sys.exit("pysvn module not detected! Please install pysvn (a.k.a python-svn)")
    
    if platform.system() == "Linux":
        import rarfile
        if not rarfile.checkInstall():
            sys.exit("Unrar porgram not detected in PATH. Please install unrar nonfree.")


    import globals
    #   Initialize system dependant constants
    globals.PROGRAM_PATH   = path
    globals.RESOURCE_PATH  = os.path.join(globals.PROGRAM_PATH, "resources")
    globals.SVN_SKIN_PATH  = os.path.join(globals.PROGRAM_PATH, "skins", "SVN")
    globals.HTTP_SKIN_PATH = os.path.join(globals.PROGRAM_PATH, "skins", "HTTP")
    
    # Misc status. HTTP and SVN connection are initialized at True if they are not skipped
    # Debug mode : more log messages (tracebacks and some status messages)
    # Verbose mode : the log is VERY verbose : all files operations, FTP commands, etc are logged
    # log mode : log is also written on "xbmcsm.log" file
    globals.STATUS["debug"] = "d" in sys.argv[1]       # debug mode
    globals.STATUS["verb"]  = "v" in sys.argv[1]       # verbose mode
    globals.STATUS["log"]   = "l" in sys.argv[1]       # logging mode
    globals.STATUS["stats"] = not "a" in sys.argv[1]   # anonymous mode (stats not sent)
    globals.STATUS["net"]   = not "n" in sys.argv[1]   # Internet status
    globals.STATUS["svn"]   = not "s" in sys.argv[1]   # SVN status
    
    import gui
    # the log MUSTN'T be intialized before because it uses globals.STATUS globals
    log = gui.Log()
    sys.stdout = log
    if globals.STATUS["debug"]: # tracebacks are redirected too on debug mode
        sys.stderr = log
    
    # Create missing directories
    if not os.path.isdir(globals.SVN_SKIN_PATH):
        os.makedirs(globals.SVN_SKIN_PATH)
    if not os.path.isdir(globals.HTTP_SKIN_PATH):
        os.makedirs(globals.HTTP_SKIN_PATH)

    # run GUI
    app = gui.mainGUI(redirect = False)
    app.MainLoop()



