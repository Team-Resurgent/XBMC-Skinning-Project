# -*- coding:utf8 -*-

#----------------------------------------------------------------------------
#--                           XBMC Skin Manager                           ---
#----------------------------------------------------------------------------
#-- archive.py : class for handling ZIP, RAR and LZMA/7ZIP archives       ---
#----------------------------------------------------------------------------
#-- Last edit : 03/08/2008                                                ---
#-- Branch    : 0.6                                                       ---
#----------------------------------------------------------------------------
#-- Copyright (C) 2008 Julien Desgats                                     ---
#--                                                                       ---
#-- This program is free software: you can redistribute it and/or modify  ---
#-- it under the terms of the GNU General Public License as published by  ---
#-- the Free Software Foundation, either version 3 of the License, or     ---
#-- (at your option) any later version.                                   ---
#--                                                                       ---
#-- This program is distributed in the hope that it will be useful,       ---
#-- but WITHOUT ANY WARRANTY; without even the implied warranty of        ---
#-- MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         ---
#-- GNU General Public License for more details.                          ---
#--                                                                       ---
#-- You should have received a copy of the GNU General Public License     ---
#-- along with this program.  If not, see <http://www.gnu.org/licenses/>. ---
#----------------------------------------------------------------------------

import os
import shutil
import zipfile
import platform
# RAR library is platform dependant
if platform.system() == "Linux":
    import rarfile
else:
    import UnRAR

import misc

#TODO:7z support
#TODO:linux support

class Archive:
    # The index is the 3 firsts bytes of the file and the content is the filetype
    filetypes = {"Rar":"rar", "PK\x03":"zip", "7z\xbc":"7z"}

    def __init__(self, path):
        """ ZIP, RAR and LZMA/7ZIP archives handling.
              path : path to archive
            Attribues:
              filetype : filetype (not based on exentsion)
              extsize  : EXTracted SIZE (in Bytes)
        """
        self.path = path
        self.extracted = 0  # created here to avoid problem with threads
        # Identifying filetype
        try:
            self.filetype = Archive.filetypes[ open(path, "rb").read(3) ]
        except:
            # The type can't be identified or file is not openable
            raise Exception("Archive %s can't be processed"%os.path.abspath(path))
        
        # Open archive
        archTypes    = { "zip":misc.Callback(zipfile.ZipFile, path, "r"),
                         "rar":misc.Callback(rarfile.RarFile, path) if platform.system() == "Linux"
                               else misc.Callback(UnRAR.Archive,path) }
        self.archive = archTypes[self.filetype]()
        
        # Extracted size
        extsizeMethods = {"zip":self.__extsize, "rar":self.__rarextsize}
        self.extsize   = extsizeMethods[self.filetype]()
        
        # misc constants
        self.separator = "/" if self.filetype == "zip" else "\\"
        
    def extract(self, dest="BUILD"):
        """ Extracts the archive on dest directory
            .  dest : destination path. Default : "BUILD"
            If destination path exists, it will be deleted before extract new files
            Attributes:
              extracted : currently extraced size (can be called by using getExtracted metod)
        """
        self.extracted = 0
        if os.path.isdir(dest):
            # delete old files
            shutil.rmtree(dest, True)
        os.mkdir(dest)
        
        extractMethods = {"zip":self.__unzip, "rar":self.__unrar}
        extractMethods[self.filetype](dest)
    
    def getExtracted(self):
        """ Returns the curently extracted size while extract is running.
        """
        return self.extracted
    
    def __extsize(self):
        """ Private method for calculate the extracted size of a ZIP/Linux RAR archive 
            Not directly called for RARs
        """
        size = 0
        for item in self.archive.infolist():
            size += item.file_size
        return size
    
    def __rarextsize(self):
        """ Private method for calculate the extracted size of a RAR archive.
        """
        if platform.system() == "Linux":
            return self.__extsize()
        size = 0
        for item in self.archive.iterfiles():
            size += item.size
        self.__refreshRAR()
        return size

    def __unzip(self, dest):
        """ Private method for zip extracting
        """
        #BUG:Some archives not references a directory. This doesn't work with them.
        test = self.archive.testzip()
        if test is None:             # if ziptest succeed
            for item in self.archive.infolist():
                if item.filename[-1] == "/": # create new subdirs
                    os.mkdir(os.path.join(dest, item.filename.replace("/", os.sep)))
                else:                # or just extract the file
                    file = open(os.path.join(dest, item.filename.replace("/", os.sep)), "wb")
                    file.write(self.archive.read(item.filename))
                    file.close()
                    self.extracted += item.file_size
        else:
            # at least one file is corrupted
            raise Exception("Bad file %s found in %s"%(test, os.path.abspath(self.path)))
    
    def __unrar(self, dest):
        """ Private method for rar extracting
        """
        if platform.system() == "Linux":
            # rarfile extracting algorithm
            l = self.archive.namelist()
            l.sort() # for put folders before contained files
            for item in l:
                item = self.archive.getinfo(item)
                path = os.path.join(dest, item.filename.replace("\\", os.sep))
                if item.isdir():
                    os.makedirs(path)
                else:
                    file = open(path, "wb")
                    file.write(self.archive.read(item.filename))
                    file.close()
                    self.extracted += item.file_size
        else:
            # PyUnRar extracting algorithm
            for item in self.archive.iterfiles():
                if not item.isdir:
                    item.extract(dest=dest)
                    self.extracted += item.size
            self.__refreshRAR()

    def __refreshRAR(self):
        """ Private method for dealing with a pyUnRAR bug/limitation :
            the iterfile method can be called only one time per instance so
            self.archive is "refreshed"
        """
        self.archive = UnRAR.Archive(self.path)

# ***  Debugging section  ***
if __name__ == "__main__":
    os.chdir("/home/julien")
    a = Archive("skin.rar")
    print a.filetype, a.extsize
    for item in a.archive.infolist():
        print item.filename
    a.extract("aaa")