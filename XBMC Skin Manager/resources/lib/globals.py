# -*- coding:utf8 -*-

#-----------------------------------------------------------------------
#                           XBMC Skin Manager                           
#-----------------------------------------------------------------------
# global.py : global variables.                                         
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

# This file MUST be imported by 'import globals' and not by 'from globals import *'
# because environement constants are not affected here !

import platform

VERSION = "0.71"
WEBSITE = "http://xbmcsm.dyndns.org/"
##WEBSITE = "http://127.0.0.1/content/xbmcsmCurrent/"

# The following vars will be initialized by main file but declared here to
# be shared between modules
STATUS = {}
PROGRAM_PATH   = ""
RESOURCE_PATH  = ""
SVN_SKIN_PATH  = ""
HTTP_SKIN_PATH = ""
# Default path for local installation
DEFAULT_PATH = "C:\\Program Files\\XBMC" if platform.system() in ("Windows", "Microsoft") else "~/.xbmc"

LOGFILE = "xbmcsm.log"
OPTFILE = "options"

