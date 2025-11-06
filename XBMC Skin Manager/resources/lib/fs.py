# -*- coding:utf8 -*-

#-----------------------------------------------------------------------
#                           XBMC Skin Manager                           
#-----------------------------------------------------------------------
# fs.py : File System abstraction class. Handles local or FTP fs        
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

import os
import misc
import globals


#-------------- Misc functions --------------

def move(src, dst, overwrite=False):
    """ Recursively move a directory src to another location dst.
        Unlike shutil's function, this one can merge directorys with overwrite flag. 
        If overwrite flag is set to True, existing files will be overwritten.
        
        If files are still in src directory when overwrite is set to false,
        it will be kept.
        
        Returns True if src still exists after porcess
    """
    filesExists = False  # return value (is files are still in src after porcess?)
    
    if not os.path.isdir(dst):
        #create destination directory
        os.makedirs(dst)
    
    for file in os.listdir(src):
        spath = os.path.join(src, file)
        dpath = os.path.join(dst, file)
        
        if os.path.isdir(spath):
            # recurse call (if filesExists is True before call, it must be still True after)
            filesExists = move(spath, dpath, overwrite) or filesExists
        else:
            if os.path.exists(dpath):
                # if target path already exists
                if overwrite:
                    # remove existing file (fails with directorys)
                    os.remove(dpath)
                else:
                    filesExists = True
                    continue # the file is not processed
            
            try:
                os.rename(spath, dpath)
            except OSError:
                copy2(spath, dpath)
                os.remove(spath)
    
    if not filesExists:
        os.rmdir(src)
    
    return filesExists

def clearDir(path):
    """ Removes all contant in path without delete path itself.
        path is a directory.
    """
    for item in os.listdir(path):
        ipath = os.path.join(path, item)
        if os.path.isdir(ipath):shutil.rmtree(ipath)
        else:os.remove(ipath)
        


#-------------- Custom Exceptions --------------
class UnknownFS(Exception):
    def __init__(self, fs):
        """ Raised when unknown FS is required
        """
        self.fs=fs
    def __str__(self):
        return "Unknown File System : "+self.fs

class MissingFTPdata(Exception): pass



#-------------- Main class --------------
class FileSystem:
    def __init__(self, mode, ftp=None):
        """ Filesystem abstraction class. Allows FS operations to be independant.
            Works with local FS or FTP (using FTPTools).
            Following methods are initialized :
             join, isdir, isfile, rmtree, copytree, move, clear, makedirs, copy, listdir
            Others FTP functions can be acceded with ftp attribute
            
            mode  string  Define FS. Can be "ftp" or "local".
            ftp   dict    FTP connection data. Required only for FTP mode.
                          Must contain at least 'host' key and optionally 'user', 
                          'passwd', 'acct' keys.
        """
        self.mode = mode
        if mode == "local":
            # local FS mode
            import os
            import shutil
            
            self.join = os.path.join
            self.isdir = os.path.isdir
            self.isfile = os.path.isfile
            self.rmtree = shutil.rmtree
            self.copytree = shutil.copytree
            self.move = move
            self.clear = clearDir
            self.makedirs = os.makedirs
            self.copy = shutil.copy2
            self.listdir = os.listdir
        elif mode == "ftp":
            # ftp mode
            if type(ftp) is not dict: raise MissingFTPdata
            import network
            
            self.ftp = network.FtpTools(ftp["host"],
                                        ftp["user"]   if ftp.has_key("user")   else "",
                                        ftp["passwd"] if ftp.has_key("passwd") else "",
                                        ftp["acct"]   if ftp.has_key("acct")   else "")
            # will print all FTP cmds in verbose mode
            self.ftp.set_debuglevel(int(globals.STATUS["verb"]))
            
            self.join = self.ftp.join
            self.isdir = self.ftp.isDir
            self.isfile = self.ftp.isFile
            self.rmtree = self.ftp.delDir
            self.copytree = self.ftp.uploadDir
            self.move = self.ftp.moveFolder
            self.clear = self.ftp.clearDir
            self.makedirs = self.ftp.makedirs
            self.copy = self.ftp.uploadFile
            self.listdir = self.ftp.listdir
        else: raise UnknownFS(mode)

    def ftpCallback(self, callback, *args):
        """ Calls callback function with FTPTools instancs at first argument and
            args at following. Returns callback result.
            Does nothing if mode is not ftp
            
            callback  function  function to call
            args      sequence  arguments
        """
        if self.mode == "ftp" : return callback(*((self.ftp, )+args))
    
    def connect(self, *args):
        """ Call connect method in ftp mode, does nothing in local mode
        """
        if self.mode == "ftp" : return self.ftp.connect(*args)
    
    def login(self, *args):
        """ Call login method in ftp mode, does nothing in local mode
        """
        if self.mode == "ftp" : return self.ftp.login(*args)
    
    def quit(self):
        """ Call quit method in ftp mode, does nothing in local mode
        """
        if self.mode == "ftp" : return self.ftp.quit()
    
    def close(self):
        """ Call close method in ftp mode, does nothing in local mode
        """
        if self.mode == "ftp" : return self.ftp.close()
        
    def getUploaded(self):
        """ Returns amount of uploaded data in FTP mode. Returns 0 in local mode.
        """
        return self.ftp.getUploaded() if self.mode == "ftp" else 0
    
    def readfile(self, path):
        """ Returns the content of file as string
        """
        if self.mode == "ftp":
            return self.ftp.downloadFile(path)
        else:
            return open(path, "rb").read()
    
    def writefile(self, path, content):
        """ Writes content on given path
        """
        if self.mode == "ftp":
            self.ftp.uploadFile(path, content=content)
        else:
            open(path, "wb").write(content)

# ***  Debugging section  ***
if __name__ == "__main__":
    globals.STATUS["verb"] = True
    local = FileSystem("local")
    ftp = FileSystem("ftp", {"host":"juju.box", "user":"xbox", "passwd":"xbox"})
    print ftp.ftp.getwelcome()
    ftp.rmtree("/F/test/2")
    ftp.makedirs("/F/test/1/2")
    ftp.copytree("/home/julien/Documents","/F/test/2")
