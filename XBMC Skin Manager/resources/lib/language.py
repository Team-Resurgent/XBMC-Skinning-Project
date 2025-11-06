# -*- coding:utf8 -*-

#----------------------------------------------------------------------------
#--                           XBMC Skin Manager                           ---
#----------------------------------------------------------------------------
#-- language.py : XML language files handling                             ---
#--               Based on Nuka1195's class for XBMC Python scripts       ---
#----------------------------------------------------------------------------
#-- Last edit : 03/09/2008                                                ---
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

import globals
import os, xml.dom.minidom
import misc

DEFAULT = "english" # default language

class Language:
    """ Language Class: creates a dictionary of localized strings { int: string } """
    def __init__(self, language=DEFAULT):
        """ initializer """
        # language folder
        self.base_path = os.path.join( globals.RESOURCE_PATH, "language")
        # verify if given language file exists otherwise it takes english
        if not os.path.isfile(os.path.join(self.base_path, language + ".xml")):
            language = DEFAULT
        # create strings dictionary
        self._create_localized_dict( language )

    def _create_localized_dict( self, language ):
        """ initializes self.strings and calls _parse_strings_file """
        # localized strings dictionary
        self.strings = {}
        # add localized strings
        self._parse_strings_file( os.path.join( self.base_path, language + ".xml" ) )
        # fill-in missing strings with english strings
        if ( language != DEFAULT ):
            self._parse_strings_file( os.path.join( self.base_path, DEFAULT+".xml" ) )
        
    def _parse_strings_file( self, language_path ):
        """ adds localized strings to self.strings dictionary """
        try:
            # load and parse strings.xml file
            doc = xml.dom.minidom.parse( language_path )
            # make sure this is a valid <strings> xml file
            root = doc.documentElement
            if ( not root or root.tagName != "strings" ): raise
            # parse and resolve each <string id="#"> tag
            strings = root.getElementsByTagName( "string" )
            for string in strings:
                # convert id attribute to an integer
                string_id = int( string.getAttribute( "id" ) )
                # if a valid id add it to self.strings dictionary
                if ( string_id not in self.strings and string.hasChildNodes() ):
                    self.strings[ string_id ] = string.firstChild.nodeValue
        except:
            # print the error message to the log and debug window
            print "ERROR: Language file %s can't be parsed!" % ( language_path, )
            misc.debug()
        # clean-up document object
        try: doc.unlink()
        except: pass

    def localized( self, code ):
        """ returns the localized string if it exists """
        ret = self.strings.get( code, "Invalid Id %d" % ( code, ) )
        return ret
    
    def getLanguages( self ):
        """ returns a list containing all available languages """
        ret = []
        for item in os.listdir(self.base_path):
            f = os.path.splitext(item)
            if f[1] == ".xml" : ret.append(f[0])
        return ret


# ***  Debugging section  ***
if __name__ == "__main__":
    globals.RESOURCE_PATH = ".."
    l = Language()
    for i in l.strings:
        print l.localized(i)
    print l.getLanguages()