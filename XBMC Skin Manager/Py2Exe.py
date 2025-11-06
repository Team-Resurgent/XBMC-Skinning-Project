# -*- coding: cp1252 -*-
#-----------------------------------------------------------------------
#                           XBMC Skin Manager                           
#                           by Julien DESGATS                           
#-----------------------------------------------------------------------
# setup.py : création des fichier binaires via py2exe                   
# Dernière révision : 10-04-2007                                        
#-----------------------------------------------------------------------
#-----------------------------------------------------------------------
# Copyright (C) 2007 Julien Desgats                                     
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

from distutils.core import setup
import py2exe
import sys
import os
import shutil

# import software version
sys.path.append(os.path.join(os.getcwd(), "resources", "lib"))
from globals import VERSION

sys.argv.append("py2exe") #Avoids having to use the command line
sys.argv = sys.argv 

# Mainfest for XP/Vista look'n'feel
manifest = """
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<assembly xmlns="urn:schemas-microsoft-com:asm.v1"
manifestVersion="1.0">
<assemblyIdentity
    version="0.64.1.0"
    processorArchitecture="x86"
    name="Controls"
    type="win32"
/>
<description>Your Application</description>
<dependency>
    <dependentAssembly>
        <assemblyIdentity
            type="win32"
            name="Microsoft.Windows.Common-Controls"
            version="6.0.0.0"
            processorArchitecture="X86"
            publicKeyToken="6595b64144ccf1df"
            language="*"
        />
    </dependentAssembly>
</dependency>
</assembly>
"""


setup(
  name='XBMC Skin Manager',
  version=VERSION,
  description='Manage your XBMC skins',
  windows=[
    {
      "script":"xbmcsm.pyw", 
      "icon_resources":[(1,"resources\\icon.ico")], 
      "other_resources":[(24,1,manifest)]
    }
  ],
  options={"py2exe":{"optimize":2}},
)
