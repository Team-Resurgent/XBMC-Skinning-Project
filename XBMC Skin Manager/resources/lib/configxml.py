# -*- coding:utf8 -*-

#-----------------------------------------------------------------------
#                           XBMC Skin Manager                           
#-----------------------------------------------------------------------
# configxml.py : XML files handling                                     
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

# A special kind of user defined downloads is WIP. Some elements are implemnted here but it's not finished

import xml.dom.minidom as xml
import os
import re

import globals
from misc import *

def xmlVersion(path):
    """ Just return version number for given xml file path (for updating config.xml)
    """
    try:
        # Try to read the xml file version
        x = xml.parse(path)
        v = int(x.getElementsByTagName("version")[0].childNodes[0].data)
        x.unlink()
    except:
        # if file, the file doesn't exists or is corripted, we update it
        v = 0
    finally:
        return v

class ConfigXML:
    """ Handling configuration and customization XML files .
        Alse handle HTTP skins versions control.
    """
    
    XML_FILES = ("config.xml", "usercustom.xml")      # parsed XML files (config.xml MUST be in 0 pos)
    ERROR = "Error (XML) : node %s named %s for %s is not well fromatted : skipped."  # i18n is not accessible here
    
    def __init__(self):
        # XML files are directly parsed and unlinked : data is stored into a dict after init
        
        # parses xml files
        self.xml = []
        for xmlfile in ConfigXML.XML_FILES:
            path = os.path.join(globals.RESOURCE_PATH, xmlfile)
            if os.path.isfile(path):
                self.xml.append(xml.parse(path))
        
        # create data dictionaries
        self.customData = CustomDict()      # customizations
        self.httpData   = CustomDict()      # HTTP skins data
        self.udlData    = CustomDict()      # TODO:UserDownloads data
        # extract data
        self.__parseCustoms()
        self.__parseHTTP()
        self.version    = int(self.__getSimpleNode("version"))   # config.xml version number
        self.svnServer  = self.__getSimpleNode("svnserver")
        self.blackList  = self.__parseBlackList()
        self.lastUpdate = self.__parseLastUpdate()
        
        # release XML files
        for xmlfile in self.xml : xmlfile.unlink()
    
    def getCustom(self, skinName = None):
        """ Returns customization dictionary for given skin name r for all skins if skinName is not provided
            or None if skin has no customizations
        """
        if skinName is None:
            return self.customData
        else:
            return self.customData[skinName] if self.customData.has_key(skinName) else None
    
    def getHttpSkins(self):
        """ Returns the partial data of HTTP skins :
              {"SkinName":("localVer", "lastVer"), ... }
        """
        ret = CustomDict()
        for skin in self.httpData:
            ret[skin] = (self.httpData[skin]["localversion"], self.httpData[skin]["lastversion"])
        return ret
    
    def getHttpData(self, skinName = None):
        """ Returns full data dictionary for given HTTP skin name or for all skins if skinName is not provided
            or none if skin doesn't extists
        """
        if skinName is None:
            return self.httpData
        else:
            return self.httpData[skinName] if self.httpData.has_key(skinName) else None
    
    def updateHTTPversion(self, skinName):
        """ Sets skinName's version to newer available
        """
        # writes version file
        f = open(os.path.join(globals.HTTP_SKIN_PATH, skinName, "version"), "w")
        f.write(self.httpData[skinName]["lastversion"])
        f.close()
        # updates dictionnary data
        self.httpData[skinName]["localversion"] = self.httpData[skinName]["lastversion"]
    
    def getVersion(self):
        """ Returns the config.xml file's version number
        """
        return self.version
    
    def getLastUpdate(self):
        """ Return last update version and release notes in a tuple (version, notes)
        """
        return self.lastUpdate
    
    def getSvnServer(self):
        """ Returns the svn server's URL
        """
        return self.svnServer
    
    def getBlackList(self):
        """ Returns blacklist as tuple.
        """
        return self.blackList
    
    
    #--- Private functions ---
    
    def __getSimpleNode(self, node, index=0):
        """ return the content of an unique root node on a given xml file
              node : node name
              index : file index on self.xml (default = 0 (config.xml))
        """
        return self.xml[index].getElementsByTagName(node)[0].childNodes[0].data
    
    # Tags used for HTTP downloads
    HTTPDL_NODES  = ("dllink","lastversion","author","skinsize","info","screenshot","web")
    # HTTPskins : screenshot, info and web are optional. web is parsed besides.
    # UserDownloads : only dllink is necessary 
    
    def __parseBlackList(self):
        """ returns the blacklist located on blacklist tag in config.xml file.
        """
        ret = []
        for item in self.xml[0].getElementsByTagName("blacklist")[0].childNodes:
            if item.nodeName == "item":
                ret.append(item.childNodes[0].data)
        return tuple(ret)
    
    def __parseLastUpdate(self):
        """ parse lastupdate node in config.xml file. Returns a tuple with
              (version, notes)
        """
        ret = [None,None]
        for item in self.xml[0].getElementsByTagName("lastupdate")[0].childNodes:
            if item.nodeName == "version" : ret[0] = item.childNodes[0].data
            if item.nodeName == "notes"   : ret[1] = item.childNodes[0].data
        return tuple(ret)
    
    def __parseHTTP(self, mode=0):
        """ Parses xml files for getting HTTP data for HTTPskins and UserDownloads nodes
              mode : 0 for HTTPskins nodes, 1 for UserDownloads nodes
        """
        # define variables according to mode. tuple had the following vars :
        #  (self.xml index, tag name, number of obligatory fields, destination dictionary)
        vars = (0,"HTTPskins",5,self.httpData) if mode == 0 else (1,"UserDownloads",1,self.udlData)
        # parse only config.xml for HTTP skins
        for skin in self.xml[vars[0]].getElementsByTagName(vars[1])[0].childNodes:
            data = CustomDict()
            data['weblinks'] = CustomDict()
            for node in skin.childNodes:
                if node.nodeName in ConfigXML.HTTPDL_NODES[:6]:
                    # if the node is <foo />, node.childNodes will be empty and an error will be raised
                    if len(node.childNodes) > 0 : data[node.nodeName] = node.childNodes[0].data
                elif node.nodeName == 'web':
                    data['weblinks'][node.getAttribute('desc')] = node.childNodes[0].data
                # now getting local version
                localfile = os.path.join(globals.HTTP_SKIN_PATH, skin.getAttribute('name'), "version")
                data["localversion"] = open(localfile,"r").read() if os.path.isfile(localfile) else "-1"
            # correct empty info case
            if not data.has_key("info") : data["info"] = ""
            if data.has_keys(ConfigXML.HTTPDL_NODES[:vars[2]]):
                # define file type
                data["filetype"] = data["dllink"].split(".")[-1]
                vars[3][skin.getAttribute('name')] = data

    def __parseCustoms(self):
        """ Parses xml files for getting customization data (stored on self.customData)
        """
        # Indexes each customisation function (documented on concerned function)
        customIndex = {
            "optfolder"    : self.__cOptFolder,
            "optfiles"     : self.__cOptFiles,
            "batfile"      : self.__cBatFile,
            "buildfolder"  : self.__cBuildFolder,
            "choicefolder" : self.__cChoiceFolder }
        # parses all XML files
        for xmlfile in self.xml:
            for skin in xmlfile.getElementsByTagName('customisations')[0].childNodes:
                if skin.nodeName == 'skin':
                    # create a new entry in self.customData if needed
                    skinName = skin.getAttribute('name')
                    if not self.customData.has_key(skinName):
                        self.customData[skinName] = CustomDict()
                    # execute appropriate function for each subnode
                    for node in skin.childNodes:
                        if customIndex.has_key(node.nodeName):
                            customIndex[node.nodeName](skinName, node)
        
        # misc processings
        self.__string2IDs(self.customData)
    
    
    
    #--- Customisations nodes functions
    # Each node has a defined method with two arguments :
    #  skinname : name of skin
    #  node     : XML instance for concerned node
    # The functions modifies direcly self.customData
    # Existing data can be overwritten or not depending on each node politic :
    # several OptFolder nodes can exists at the same time but not several BuildFolder.
    # This way, last read node is conserved : usercustom.xml is prioritary on config.xml.

    # The following list is used on several function, so it's declared globally
    CHOICEFOLDER_NODES = ("source","destination","string","default")   # "simple" nodes for choicefolder
    def __cChoiceFolder(self, skinname, node):
        " Function for handling choicefolder node "
        if node.getAttribute("type") == "1":
            self.__cChoiceFolder1(skinname, node)
        elif node.getAttribute("type") == "2":
            self.__cChoiceFolder2(skinname, node)
        else:
            print "Error (XML) : unknown choicefolder type %s (for %s)"%(node.getAttribute("type"), skinname)
    
    def __cChoiceFolder1(self, skinname, node):
        """ Function for handling type 1 choicefolder node.
            Created dictionary layout:
              {"source"      : source path,
               "destination" : destination path,
               "string"      : string(str) or stringID(int),
               "choices"     : [list of possible choices]
               ["default"    : default choice] }
        """
        # builds an independant dictionary
        data = CustomDict()
        data["choices"] = []
        for subnode in node.childNodes:
            if subnode.nodeName in ConfigXML.CHOICEFOLDER_NODES:
                data[subnode.nodeName] = subnode.childNodes[0].data
            elif subnode.nodeName == "choice":
                data["choices"].append(subnode.childNodes[0].data)
        
        # Exceptions handling : if the dictionary is not valid, self.customData is not modified
        #  all fields must be present (except 'default' which is facultative)
        #  there must be choices
        #  if a default key is present, its value must be in choices
        if data.has_keys(ConfigXML.CHOICEFOLDER_NODES[:3]) and len(data["choices"]) > 0 and \
           ((data.has_key("default") and data["default"] in data["choices"]) or not data.has_key("default")):
            if not self.customData[skinname].has_key("choicefolder1"):
                self.customData[skinname]["choicefolder1"] = CustomDict()
            self.customData[skinname]["choicefolder1"][node.getAttribute("name")] = data
        else:
            print ConfigXML.ERROR%(node.nodeName, node.getAttribute("name"), skinname)

    def __cChoiceFolder2(self, skinname, node):
        """ Function for handling type 1 choicefolder node.
            Created dictionary layout:
              {"sources"     : {"source name":path,...},
               "destination" : destination path,
               "string"      : string(str) or stringID(int),
               ["default"    : default source name] }
        """
        # builds an independant dictionary
        data = CustomDict()
        data["sources"] = CustomDict()
        for subnode in node.childNodes:
            if subnode.nodeName in ConfigXML.CHOICEFOLDER_NODES[1:]: # the source mark is not simple here
                data[subnode.nodeName] = subnode.childNodes[0].data
            elif subnode.nodeName == "source":
                data["sources"][subnode.getAttribute('name')] = subnode.childNodes[0].data
        
        # Exceptions handling : if the dictionary is not valid, self.customData is not modified
        #  fields destinatiopn and string must be present
        #  there must be sources
        #  if a default key is present, its value must be a source name
        if data.has_keys(ConfigXML.CHOICEFOLDER_NODES[1:2]) and len(data["sources"]) > 0 and \
           ((data.has_key("default") and data["default"] in data["sources"].keys()) or not data.has_key("default")):
            if not self.customData[skinname].has_key("choicefolder2"):
                self.customData[skinname]["choicefolder2"] = CustomDict()
            self.customData[skinname]["choicefolder2"][node.getAttribute('name')] = data
        else:
            print ConfigXML.ERROR%(node.nodeName, node.getAttribute("name"), skinname)

    def __cOptFolder(self, skinname, node):
        """ Function for handling type 1 choicefolder node.
            Created dictionary layout:
              {"source"      : source path,
               "destination" : destination path,
               "string"      : string(str) or stringID(int),
               ["default"    : boolean] }
        """
        OPTFOLDER_NODES = ('source','destination','string','default')   # "simple" nodes for optfolder
        
        # builds an independant dictionary
        data = CustomDict()
        for subnode in node.childNodes:
            if subnode.nodeName in OPTFOLDER_NODES:
                data[subnode.nodeName] = subnode.childNodes[0].data
        
        # if default not exists, False is provided
        data["default"] = bool(int(data["default"])) if data.has_key("default") else False
        
        # Exceptions handling : if the dictionary is not valid, self.customData is not modified
        if data.has_keys(OPTFOLDER_NODES):
            if not self.customData[skinname].has_key("optfolder"):
                self.customData[skinname]["optfolder"] = CustomDict()
            self.customData[skinname]["optfolder"][node.getAttribute('name')] = data
        else:
            print ConfigXML.ERROR%(node.nodeName, node.getAttribute("name"), skinname)

    def __cOptFiles(self, skinname, node):
        """ Function for handling type 1 choicefolder node.
            Created dictionary layout:
              {"sources"     : [ list of sources ],
               "destination" : destination path,
               "string"      : string(str) or stringID(int),
               ["default"    : default source name] }
        """
        OPTFILES_NODES = ('destination','string','default')   # "simple" nodes for choicefolder
        
        # builds an independant dictionary
        data = CustomDict()
        data["sources"] = []
        for subnode in node.childNodes:
            if subnode.nodeName in OPTFILES_NODES:
                data[subnode.nodeName] = subnode.childNodes[0].data
            elif subnode.nodeName == "source":
                data["sources"].append(subnode.childNodes[0].data)
        
        # if default not exists, False is provided
        data["default"] = bool(int(data["default"])) if data.has_key("default") else False
        
        # Exceptions handling : if the dictionary is not valid, self.customData is not modified
        #  fields destination and string must be present
        #  there must be sources
        if data.has_keys(OPTFILES_NODES[:2]) and len(data["sources"]) > 0 :
            if not self.customData[skinname].has_key("optfiles"):
                self.customData[skinname]["optfiles"] = CustomDict()
            self.customData[skinname]["optfiles"][node.getAttribute('name')] = data
        else:
            print ConfigXML.ERROR%(node.nodeName, node.getAttribute("name"), skinname)


    def __cBatFile(self, skinname, node):
        """ Function for handling batfile node.
            It create a list which contain
        """
        BATFILE_NODES = ("file","string","default")
        
        # builds an independant dictionary
        data = CustomDict()
        data["files"] = CustomDict()
        for subnode in node.childNodes:
            if subnode.nodeName in BATFILE_NODES[1:]: # the file mark is not simple here
                data[subnode.nodeName] = subnode.childNodes[0].data
            elif subnode.nodeName == "file":
                fileData = subnode.childNodes[0].data.split(":")
                # for compatibility reasons, file extension is in XML but it's useless now
                fileData[0] = stripBatchExt(fileData[0])
                if subnode.hasAttribute("name"):
                    data["files"][subnode.getAttribute("name")] = fileData
                else:
                    # If no attribute name is found, the data is written as string
                    self.customData[skinname]["batfile"] = fileData
                    # and the alogorithm stops here
                    return

        # Exceptions handling : if the dictionary is not valid, self.customData is not modified
        #  One file : only fileData is stored
        #  Several files : field string must be present. Default is optionnal
        #  if default is present it must point an existing file
        if len(data["files"]) == 1:
            self.customData[skinname]["batfile"] = data["files"].values()[0]
        elif len(data["files"]) > 1 and data.has_key("string") and \
          ((data.has_key("default") and data["default"] in data["files"].keys()) or not data.has_key("default")):
            self.customData[skinname]["batfile"] = data
        else:
            print ConfigXML.ERROR%(node.nodeName, "N/A", skinname)
        

    def __cBuildFolder(self, skinname, node):
        """ Function for handling buildfolder node.
            If only one unnamed <source> mark is provided, the content is just written in self.customData as string
            Else, the following dictionary is written :
              {"sources"  : {sourceName:path, ...}
               "string"   : string(str) or stringID(int),
               ["default" : default source name] }
        """
        BUILDFOLDER_NODES = ("source","string","default")
        
        # builds an independant dictionary
        data = CustomDict()
        data["sources"] = CustomDict()
        for subnode in node.childNodes:
            if subnode.nodeName in BUILDFOLDER_NODES[1:]: # the source mark is not simple here
                data[subnode.nodeName] = subnode.childNodes[0].data
            elif subnode.nodeName == "source":
                if subnode.hasAttribute("name"):
                    data["sources"][subnode.getAttribute("name")] = subnode.childNodes[0].data
                else:
                    # If no attribute name is found, the data is written as string
                    self.customData[skinname]["buildfolder"] = subnode.childNodes[0].data
                    # and the alogorithm stops here
                    return

        # Exceptions handling : if the dictionary is not valid, self.customData is not modified
        #  One source : only source path is stored
        #  Several source : field string must be present. Default is optionnal
        #  if default is present it must point an existing file
        if len(data["sources"]) == 1:
            self.customData[skinname]["buildfolder"] = data["files"].values()[0]
        elif len(data["sources"]) > 1 and data.has_key("string") and \
          ((data.has_key("default") and data["default"] in data["sources"].keys()) or not data.has_key("default")):
            self.customData[skinname]["buildfolder"] = data
        else:
            print ConfigXML.ERROR%(node.nodeName, "N/A", skinname)

    def __string2IDs(self, d):
        """ Recurse ransforms strings IDs into integers for given dictionary
        """
        for k in d:
            if type(d[k]) is CustomDict : self.__string2IDs(d[k])
            elif k == "string" :
                try    : d[k] = int(d[k]) # try to convert into integer, fails for hard-coded strings
                except : pass


# ***  Debugging section  ***
if __name__ == "__main__":
    globals.RESOURCE_PATH = ".."
    globals.HTTP_SKIN_PATH = os.path.join(globals.RESOURCE_PATH, "skins", "HTTP")
    print xmlVersion(os.path.join(globals.RESOURCE_PATH,"config.xml"))
    x = ConfigXML()
    print x.getHttpSkins()
    dict = x.getCustom()
    for skin in dict:
        for custom in dict[skin]:
            print skin, custom, dict[skin][custom]
    print x.getBlackList()
    print x.getLastUpdate()
    