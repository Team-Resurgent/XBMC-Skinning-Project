# -*- coding:utf8 -*-

#-----------------------------------------------------------------------
#                           XBMC Skin Manager                           
#-----------------------------------------------------------------------
# config.py : configuration file handling                               
#             based on Nuka1195's module for Apple Movie Trailers       
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
import globals
import os

# A config dictionary has the is coposed by base options and a sub-dictionary per customized skin :
# The field "version" contains the program's version number to test comptatibility with
# further updates.

# Default settings are declared here
DEFAULTS = { 
    "IP"      : "192.168.0.0",
    "user"    : "xbox",
    "passwd"  : "xbox",
    "xbmcdir" : "/E/XBMC",
    "local"   : False,
    "update"  : True,
    "build"   : True,
    "upload"  : True,
    "keepxpr" : True,
    "deltemp" : True,
##    "del"     : False,
    "lang"    : "english",
    "lastup"  : globals.VERSION,   # to avoid to display update info at each start
    "version" : globals.VERSION }

SETTINGS_VERSIONS = ("0.6", "0.61", "0.7", globals.VERSION)  # compatible versions with current settings pattern

def get_settings():
    """ read settings
        return a config dictionary
    """
    try:
        settings_file = open( os.path.join(globals.RESOURCE_PATH, globals.OPTFILE), "r" )
        settings = eval( settings_file.read() )
        settings_file.close()
        if ( settings[ "version" ] not in SETTINGS_VERSIONS ):
            raise
    except:
        # if no file is found or the file version is not compatible
        print "r|Unable to load settings. Defaults will be used."
        settings = DEFAULTS
        save_settings(DEFAULTS)
    return settings

def save_settings(settings):
    """ save a settings dictionary """
    settings["version"] = globals.VERSION  # eventually refresh version string
    try:
        settings_file = open( os.path.join(globals.RESOURCE_PATH, globals.OPTFILE), "w" )
        settings_file.write( repr( settings ) )
        settings_file.close()
        return True
    except:
        print "r|Unable to save settings."
        return False


# ***  Debugging section  ***
if __name__ == "__main__":
    globals.RESOURCE_PATH = ".."
    import os
    print os.getcwd()
    CONFIG = get_settings()
    print CONFIG
    print save_settings(CONFIG)
