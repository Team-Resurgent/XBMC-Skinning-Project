# -*- coding:utf8 -*-

#-----------------------------------------------------------------------
#                           XBMC Skin Manager                           
#-----------------------------------------------------------------------
# misc.py : Customized stdlib elements. And others misc tools           
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
import globals
import traceback
import platform
import threading

class CustomDict(dict):
    """ Include some useful methods to standard dict """
    
    def has_keys(self, keys):
        """
        Multiple key search. Return true if keys passed are subset of keys. 
        
        @type  keys:sequence
        @param keys:set of seached keys
        
        @rtype: bool
        @return:is passed keys are subset of keys set
        """
        return set(keys).issubset(self.keys())
    
    def sorted_keys(self):
        """
        Returns dict keys in alphanumerical order (case insensitive).
        
        @attention:all keys must be same type for being correcly sorted !
        """
        l = self.keys()
        try:
            if type(l[0]) is str : l.sort(key=str.lower)
            elif type(l[0]) is unicode : l.sort(key=unicode.lower)
            else : l.sort()
        except : pass # if sorting fails, the keys are returned in arbitary order
        return l
        
    
class Callback:
    """
    Create a callback shim. Based on code by Scott David Daniels
    (which also handles keyword arguments).
    """
    def __init__(self, callback, *firstArgs):
        """
        Initialize callback with a callable function and its first arguments.
        Other arguments can be added at call.
        
        @param callback:function which will be called
        @type  callback:callable
        @param *firstargs:first callback arguments. Can be empty.
        @type  *firstargs:sequence
        """
        self.__callback = callback
        self.__firstArgs = firstArgs

    def __call__(self, *args):
        """
        Call function with its first arguments and eventually others arguments
        
        @param *args:arguments to chain with first arguments. Can be empty
        @type  *args:sequence
        
        @return: the normal return of function
        """
        return self.__callback (*(self.__firstArgs + args))

class threadresult(object):
    def __init__(self):
        self.__event=threading.Event()
        self.__result=None
 
    def reset(self):
        self.__event.clear()
        self.__result=None
 
    def setresult(self,value):
        self.__result=value
        self.__event.set()
 
    def getresult(self):
        self.__event.wait()
        return self.__result
 
    value=property(getresult,setresult)


def parseSize(size, symbol='B', decimals=2, binarPrefix=True):
    """ 
    Create a pretty printed string for given size (in bytes)

    @type  size:int, long, float
    @param size:size in bytes
    @type  symbol:string
    @param symbol:byte symbol (default : "B")
    @type  decimals:int
    @param decimals:number of decimals (default : 2)
    @type  binarPrefix:bool
    @param binarPrefix:use IEC normalized 2^10 prefixes instead of SI 10^3 ones (def : True)
    
    @rtype: string
    @return:pretty printed stirng
    """
    prefix = ['', 'k', 'M', 'G', 'T', 'P', 'E', 'Z']
    div = 0
    while size >= 1024.0:
        size /= 1024.0
        div +=1
        if div >= (len(prefix)-1):
            break
    
    # Rounds the result to given decimals or integer if there's no decimals
    if size-int(size) < 1.0/(10.0**decimals):
        size = int(size)
    else:
        size = round(size, decimals)
    
    if binarPrefix:
        prefix[1] = 'K'     # the kibibyte is KiB and not kiB
        return str(size) + ' ' + prefix[div] + 'i' + symbol
    else:
        return str(size) + ' ' + prefix[div] + symbol

def dirsize(path):
    """ Returns total dir size.
        If dir is a file : returns its size
        If dir doesn't exist : returns -1
    """
    if os.path.isdir(path) or path == '':
        size = 0
        for item in os.listdir(path):
            if os.path.isdir(os.path.join(path,item)):
                size += dirsize(os.path.join(path,item))
            elif os.path.isfile(os.path.join(path,item)):
                size += os.path.getsize(os.path.join(path,item))
        return size 
    elif os.path.isfile(path):
        return os.path.getsize(path)
    else:
        return -1

def debug(*args):
    """ Prints debug informations. Nothing is displayed in non debug mode.
        With no arguments, prints last exception's traceback.
        Otherwise, prints all arguments.
    """
    try:
        if globals.STATUS["debug"]:
            if len(args)==0:
                # prints formatted traceback
                print "rc|----   EXCEPTION TRACEBACK   ----"
                print traceback.format_exc()
                print "rc|----      END TRACEBACK      ----"
            else:
                for arg in args:
                    print str(arg)
    except : pass


def dummy(*args):
    """ This function does nothing !
        It'used by dict.get methods when nothing happend with an unknown key.
    """
    pass

# Windows Vista can sometimes return "Microsoft" for platform.system()
BATCH_EXT = {"Windows":"bat", "Microsoft":"bat", "Linux":"sh"}
def batchExt(filename):
    """ Returns file name with correct extension depending on current OS
        Retrurs filename without modification if OS is not supported
    """
    return ".".join((filename, BATCH_EXT.get(platform.system(), "")))

def stripBatchExt(filename):
    """ Returns filename witout any batch extension.
        Does nothing if filename does not have a batch extension
    """
    split = os.path.splitext(filename)
    return split[0] if split[1][1:].lower() in BATCH_EXT.values() else filename

# ***  Debugging section  ***
if __name__ == "__main__":
    pass
