# -*- coding:utf8 -*-

#-----------------------------------------------------------------------
#                           XBMC Skin Manager                           
#-----------------------------------------------------------------------
# init.py : initialization procedures                                   
#-----------------------------------------------------------------------
# Last edit : 06/15/2008                                                
# Branch    : 0.6                                                       
#-----------------------------------------------------------------------
# Copyright (C) 2008 Julien Desgats                                     
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

from config    import *
from language  import *
from configxml import *
from network   import *
import globals
#import ping
import urllib2
import sys
import thread

import xml.dom


# ***  Debugging section  ***
if __name__ == "__main__":
    globals.STATUS = { "debug" : True, "net" : True, "svn" : True }
    globals.RESOURCE_PATH = ".."
    globals.SVN_SKIN_PATH = "D:\\Skins XBMC\\Branche0.6\\skins\\SVN"
# *** End ***


class Init:
    PING_HOSTS = ("goolge.com", "yahoo.com", "microsoft.com")  # hosts to ping for test internet
    # Status
    WAITING  = 0
    INTERNET = 1 # check for internet connection
    CONFIG   = 2 # update config.xml file
    SVN      = 3 # SVN synchronizing
    FINISHED = 4
    
    UPDATEURL = globals.WEBSITE+"xmlupdate.php?xmlver=%s&softver="+globals.VERSION
    XMLFILE   = os.path.join(globals.RESOURCE_PATH,"config.xml")
    
    def __init__(self):
        """ Initialization class. This initiate config and language instances, the rest is done on
            initThread method. To get these instances, use getInit method
            status attribute is initalized too : it indicate the init state
        """
        self.config = get_settings()
        self.lang   = Language(self.config["lang"])
        self.status = Init.WAITING
        # Exceptions dictionnary : the key gives where exception has been raised (eg svn, xml...)
        # and contain the exc_info()of the exception (not yex exploited)
        self.exc    = {}
    
    def getInit(self):
        """ Return config and lang instances in this order
        """
        return self.config, self.lang
    
    def start(self):
        """ Starts the init Thread. Implemented insances are given by getThread.
            If exceptions are raised, they are logged in exc dictionary (indexed by "net","svn","xml")
        """
        self.status = Init.INTERNET # Sets an alive value immedently to avoid problems with isAlive
        thread.start_new_thread(self.initThread, ())

    def getThread(self):
        """Returns (in this order) :
              xmlcfg : ConfigXML instance
              svn    : SvnTools instance
            MUSTN'T be called before start !!
        """
        return self.xmlcfg, self.svn
    
    def isAlive(self):
        """ Says if the thread is alive or not (bool) """
        return not self.status in (Init.WAITING, Init.FINISHED)
    
    def initThread(self):
        """ Initialization procedure.
            The attribute status is updated at each step
        """
        self.status = Init.INTERNET
        globals.STATUS["net"] = self._ping() if globals.STATUS["net"] else False
        self.status = Init.CONFIG
        # updating & parsing XML files
        if globals.STATUS["net"]:
            self._updateConfig()
        self.xmlcfg = ConfigXML()
        # SVN synchro (only if Internet is OK)
        self.status = Init.SVN
        self.svn = self._svnSynchro()
        self.status = Init.FINISHED
    
    def _ping(self):
        """ Tests internet connection. Exceptions are logged as "net"
            Return a boolean
            Test is done by send  dummy HTTP request to google.com
            (ping requst has been depreciated since it's requre root privileges)
        """
        try:
            urllib2.urlopen("http://google.com")
##            for host in Init.PING_HOSTS:
##                if ping.ping(host, bool=True) : return True
        except Exception, exc:
            self.exc["net"] = sys.exc_info()
        else:
            return True
        # if exc is raised
        return False 
    
    def _updateConfig(self):
        """ Open and update config.xml file. Exceptions are logged as "xml"
        """
        try:
            update = urlopen(Init.UPDATEURL % ( xmlVersion(Init.XMLFILE) )).read()
            if len(update) > 5 and update[:5] == '<?xml':
                f = open(Init.XMLFILE,"w")
                f.write(update)
                f.close()
        except Exception, exc:
            self.exc["xml"] = sys.exc_info()
    
    def _svnSynchro(self):
        """ Reads the HEAD revisons of each skin.
            Returns SvnTools instance
        """
        try:
            svn = SvnTools(self.xmlcfg.getSvnServer())
            svn.listrep(self.xmlcfg.getBlackList())
        except Exception, exc:
            self.exc["svn"] = sys.exc_info()
        finally:
            # svn instance is unconditionnaly returned to avoid nonetype problems
            # when it will be used
            return svn
    

# ***  Debugging section  ***
if __name__ == "__main__":
    import time
    i = Init()
    i.start()
    s = 0
    while i.isAlive():
        time.sleep(0.05)
        if s != i.status:
            s = i.status
            print s
    print i.getThread()
    
