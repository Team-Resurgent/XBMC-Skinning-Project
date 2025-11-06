# -*- coding:utf8 -*-

#-----------------------------------------------------------------------
#                           XBMC Skin Manager                           
#-----------------------------------------------------------------------
# gui.py : main GUI handling                                            
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


import wx
import wx.lib.delayedresult as delayedresult
import wx.lib.scrolledpanel as scrolled
import sys
import time
import platform
import threading
import StringIO
import re
from base64 import b64decode

import globals

# ***  Debugging section  ***
if __name__ == "__main__":
    globals.STATUS = { "debug" : False, "net" : False, "svn" : False, "log":False, "verb":0 }
    globals.RESOURCE_PATH  = ".."
    globals.SVN_SKIN_PATH  = "..\\..\\skins\\SVN"
    globals.HTTP_SKIN_PATH = "..\\..\\skins\\HTTP"
# *** End ***
from misc import *
from widgets import *
import config
import core
from init import Init

# don't need to import this in normal mode
if globals.STATUS["debug"] : import traceback


# Colour constants
DARK_RED   = wx.Colour(127,0  ,0  )
DARK_BLUE  = wx.Colour(0  ,19 ,127)
DARK_GREEN = wx.Colour(38 ,97 ,0  )

# program icon (Base 64)
ICON =  '''iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAALGPC/xhBQAAABh0RVh0U29mdHdhcmUAUG
FpbnQuTkVUIHYzLjA4ZXKc4QAAAdtJREFUOE9jYKAGWL5qmdzPXz+ZiDXr58+fTEeOHxWGq3/28hln27ySqRU9RX7Lli9jxGeQR6q
tW/30gtbvP74zo6i78+yEUONGu9OBVZrHjZ21A8LDw1hhClKzs5kt/E3C/Cu0jlYsMt66YGUfD1ZLrj7aJzzzjMXpwk3K/72qNO/p
uKpV6nrq1Fvlat6Pm6v0f/IB812fvj/nwOvVx69PC8w/Y3yy6bji//htOv8tO2T/p65U+N+70/joy3c3eYkKp1WbZpgvOif6v+W4/
P/MlTL/e3dJ/J88uwm7s9FNfP/xPWtUjf3xHTe5/i+9IPB/zlG+/+sucv43DVVd9eHDB7wBDDarcnJyZ8o8mf9H7/L9OXYzKP/Y7Z
Cyrdf5/4TOUPwfV+RXjNcL3fPL/atWa/6ZfEj9w7m72T4wxfuuxwQ37df5krdA5Wd8XpgdVkPW7Vii3LnJ9O3CM3oX95xt0kBXtPt
qu8aMU0a3SmZovDGzM9RHkb9w/bRg+1rHK2vPe8x49+kxzmh69eEO94ZLNgvrZhucefj0HhfYkHuP73F3LclbuPZUti8xUfTv3z+G
3ecyQ9rmp037/PULC8Oq7Ssdz109KUSMZmQ1Jy4dEV6zc601qfqorx4A4sPTK+XN2+MAAAAASUVORK5CYII='''

class Skins(scrolled.ScrolledPanel):
    # Skin types IDs
    SVN    = 0
    HTTP   = 1
    
    def __init__(self, *args, **kwds):
        self.inst = kwds["instances"]
        del kwds["instances"]  # make a crash on wx.Panel.__init__ if exists
        
        # Create skins data dictionaries
        self.svnSkins  = {}
        self.httpSkins = {}
        
        # begin wxGlade: Skins.__init__
        kwds["style"] = wx.TAB_TRAVERSAL
        scrolled.ScrolledPanel.__init__(self, *args, **kwds)
        self.skinsHTTPsizer_staticbox = wx.StaticBox(self, -1, self.inst["loc"](2009))
        self.skinsSVNsizer_staticbox = wx.StaticBox(self, -1, self.inst["loc"](2008))

        self.__do_layout()
        # end wxGlade
    
    def updateVersions(self):
        """ Updates version numbers and colors for both HTTP and SVN skins
        """
        self.__updateHTTPSkins(self.inst["xmlcfg"].getHttpSkins())
        self.__updateSVNSkins(self.inst["svn"].getSkins())
        self.Refresh()
    
    def __createGrid(self, type):
        """ Creates the SVN skin grid for given skin type
            Build self.svnSkins dict with wx instances :
              {"skinname":(wx.CheckBox, wx.StaticText(versions), wx.Button), ...}
            Return a wx.GridSizer ready to map
        """
        # mode dependant variables :
        #  (destination dict, version str, button str, button tip, getInfo method, update method)
        vars = {Skins.SVN  : (self.svnSkins,  2011, 2013, 2014, self.inst["svn"].getSkins,        self.__updateSVNSkins),
                Skins.HTTP : (self.httpSkins, 2012, 2015, 2016, self.inst["xmlcfg"].getHttpSkins, self.__updateHTTPSkins) }

        # prepares the styled labels
        skin_label = wx.StaticText(self, -1, self.inst["loc"](2010))
        skin_label.SetFont(wx.Font(8, wx.DEFAULT, wx.NORMAL, wx.BOLD, 0, ""))
        rev_label = wx.StaticText(self, -1, self.inst["loc"](vars[type][1]))
        rev_label.SetFont(wx.Font(8, wx.DEFAULT, wx.NORMAL, wx.BOLD, 0, ""))
        # grid pattern : CheckBox|Versions|Button
        grid = wx.FlexGridSizer(0, 3, 5, 5)
        grid.Add(skin_label, 0, wx.ALIGN_CENTER_HORIZONTAL|wx.ALIGN_CENTER_VERTICAL, 0)
        grid.Add(rev_label , 0, wx.ALIGN_CENTER_HORIZONTAL|wx.ALIGN_CENTER_VERTICAL, 0)
        grid.Add((0, 0), 0, 0, 0)  #dummy rect for button column
        
        vars[type][0].clear()
        # Fill grid with skins
        skinsDict = vars[type][4]()
        for skin in skinsDict.sorted_keys():
            # create wx instances
            vars[type][0][skin] = \
              (wx.CheckBox(self, -1, skin),
               wx.StaticText(self, -1, (str(skinsDict[skin][0]) if skinsDict[skin][0] >= 0 and  \
                   skinsDict[skin][0] != "-1" else "-")+"/"+(str(skinsDict[skin][1]) if skinsDict[skin][1] >= 0 else "-")),
               wx.Button(self, -1, self.inst["loc"](vars[type][2]))
              )
            # set proprieties
            vars[type][0][skin][2].SetToolTipString(self.inst["loc"](vars[type][3]))
            
            # Binds button action
            if type == Skins.SVN:
                # Changelog dialog
##                log = Callback(self.inst["svn"].changelog, skin)          # log callback
##                dlg = Callback(ChangelogDlg, skin, log, self.inst["loc"]) # dialog callback
                dlg = Callback(self.displayChangelog, skin)
                self.Bind(wx.EVT_BUTTON, dlg, self.svnSkins[skin][2])
            else:
                # info dialog
                dlg = Callback(InfoDialog, skin, self.inst["xmlcfg"].getHttpData(skin), self.inst["loc"]) # dialog callback
                self.Bind(wx.EVT_BUTTON, dlg, self.httpSkins[skin][2])
            
            # fill grid
            grid.Add(vars[type][0][skin][0], 0, wx.ALIGN_CENTER_VERTICAL, 0)
            grid.Add(vars[type][0][skin][1], 0, wx.ALIGN_CENTER_HORIZONTAL|wx.ALIGN_CENTER_VERTICAL, 0)
            grid.Add(vars[type][0][skin][2], 0, wx.ALIGN_CENTER_HORIZONTAL|wx.ALIGN_CENTER_VERTICAL, 0)
        vars[type][5](skinsDict)
        return grid
    
    def __updateSVNSkins(self, skins):
        """ Updates SVN skins' colors """
        for skin in skins:
            # Gets color and button status according to revision numbers
            if skins[skin][0] < 0                : status=(DARK_RED , False)   # skin is not present
            elif skins[skin][0] < skins[skin][1] : status=(DARK_BLUE, True)   # skin has updates
            else : status=(wx.SystemSettings_GetColour(wx.SYS_COLOUR_WINDOWTEXT), False)  # skin is up to date
            # apply modifications and refresh versions numbers
            self.svnSkins[skin][0].SetForegroundColour(status[0])
            self.svnSkins[skin][1].SetForegroundColour(status[0])
            self.svnSkins[skin][1].SetLabel("%s/%s"%("-" if skins[skin][0] < 0 else str(skins[skin][0]),
                                                     "-" if skins[skin][1] < 0 else str(skins[skin][1])))
            self.svnSkins[skin][2].Enable(status[1])
    
    def __updateHTTPSkins(self, skins):
        """ Updates HTTP skins' colors """
        for skin in skins:
            # Gets color and button status according to version numbers
            if skins[skin][0]   == "-1"           : status=DARK_RED             # skin is not present
            elif skins[skin][0] != skins[skin][1] : status=DARK_BLUE            # skin has updates
            else : status=wx.SystemSettings_GetColour(wx.SYS_COLOUR_WINDOWTEXT) # skin is up to date
            # apply modifications and refresh versions numbers
            self.httpSkins[skin][0].SetForegroundColour(status)
            self.httpSkins[skin][1].SetForegroundColour(status)
            self.httpSkins[skin][1].SetLabel("%s/%s"%("-" if skins[skin][0] == "-1" else str(skins[skin][0]),
                                                      "-" if skins[skin][1] == "-1" else str(skins[skin][1])))


    def __do_layout(self):
        # begin wxGlade: Skins.__do_layout
        skinsSizer = wx.BoxSizer(wx.HORIZONTAL)
        skinsSVNsizer = wx.StaticBoxSizer(self.skinsSVNsizer_staticbox, wx.HORIZONTAL)
        skinsSVNsizer.Add(self.__createGrid(Skins.SVN), 1, 0, 0)
        skinsSizer.Add(skinsSVNsizer, 1, wx.ALL|wx.EXPAND, 5)
        skinsHTTPsizer = wx.StaticBoxSizer(self.skinsHTTPsizer_staticbox, wx.HORIZONTAL)
        skinsHTTPsizer.Add(self.__createGrid(Skins.HTTP), 1, 0, 0)
        skinsSizer.Add(skinsHTTPsizer, 1, wx.ALL|wx.EXPAND, 5)
        self.SetSizer(skinsSizer)
        skinsSizer.Fit(self)
        self.SetAutoLayout(True)
        self.SetupScrolling(scroll_x=False)
        # end wxGlade
    
    def displayChangelog(self, skin, *args):
        """ Retrieve and displays skin's changelog
            Dispalys also a progress dialog while changelog is retieved
        """
        th = threading.Thread(target = self.inst["svn"].changelog, args=(skin,))
        dlg = wx.ProgressDialog(self.inst["loc"](4036),self.inst["loc"](4037), 
                                parent=self, style = wx.PD_APP_MODAL)
        th.start()
        while th.isAlive():
            dlg.UpdatePulse()[0]
            wx.MilliSleep(100)
        dlg.Destroy()
        ChangelogDlg(skin, self.inst["svn"].getLastLog(), self.inst["loc"])

class Options(scrolled.ScrolledPanel):
    def __init__(self, *args, **kwds):
        self.inst = kwds["instances"]
        self.mframe = kwds["mainframe"]
        del kwds["instances"], kwds["mainframe"]  # make a crash on wx.Panel.__init__ if exists
        # begin wxGlade: Options.__init__
        kwds["style"] = wx.TAB_TRAVERSAL
        scrolled.ScrolledPanel.__init__(self, *args, **kwds)
        self.taskBox_staticbox = wx.StaticBox(self, -1, self.inst["loc"](2022))
        self.miscBox_staticbox = wx.StaticBox(self, -1, self.inst["loc"](2039))
        self.optionXbBox_staticbox = wx.StaticBox(self, -1, self.inst["loc"](2017))
        self.xbMode = wx.CheckBox(self, -1, self.inst["loc"](2046))
        self.xbIPlb = wx.StaticText(self, -1, self.inst["loc"](2018))
        self.xbIP = wx.TextCtrl(self, -1, self.inst["config"]["IP"])
        self.xbUserlb = wx.StaticText(self, -1, self.inst["loc"](2019))
        self.xbUser = wx.TextCtrl(self, -1, self.inst["config"]["user"])
        self.xbPwdlb = wx.StaticText(self, -1, self.inst["loc"](2020))
        self.xbPwd = wx.TextCtrl(self, -1, self.inst["config"]["passwd"])
        self.xbDirlb = wx.StaticText(self, -1, self.inst["loc"](2021))
        self.xbDir = wx.TextCtrl(self, -1, self.inst["config"]["xbmcdir"])
        self.browse = wx.Button(self, -1, "...",style=wx.BU_EXACTFIT) 
        self.default = wx.Button(self, -1, "def",style=wx.BU_EXACTFIT) 
        self.tkDl = wx.CheckBox(self, -1, self.inst["loc"](2023))
        self.tkBuild = wx.CheckBox(self, -1, self.inst["loc"](2024))
        self.tkUp = wx.CheckBox(self, -1, self.inst["loc"](2025))
        self.tkKeepXPR = wx.CheckBox(self, -1, self.inst["loc"](2042))
        self.tkClean = wx.CheckBox(self, -1, self.inst["loc"](2026))
##        self.tkDel = wx.CheckBox(self, -1, self.inst["loc"](2043))
        self.lang_lab = wx.StaticText(self, -1, self.inst["loc"](2027))
        self.lang = wx.Choice(self, -1, choices=self.inst["lang"].getLanguages())
        #self.miscDefault = wx.Button(self, -1, self.inst["loc"](2041)) #TODO : reset defaults

        self.__set_properties()
        self.__do_layout()
        # end wxGlade

    def __set_properties(self):
        # begin wxGlade: Options.__set_properties
        self.lang.SetStringSelection(self.inst["config"]["lang"])
        self.Bind(wx.EVT_CHOICE,self.__changeLanguage,self.lang)
        self.Bind(wx.EVT_CHECKBOX,self.__switchLocalMode,self.xbMode)
        self.Bind(wx.EVT_BUTTON, self.__browse, self.browse)
        self.Bind(wx.EVT_BUTTON, self.__setDefault, self.default)
        # Set checkbox values
        self.xbMode.SetValue(self.inst["config"]["local"])
        self.tkDl.SetValue(self.inst["config"]["update"])
        self.tkBuild.SetValue(self.inst["config"]["build"])
        self.tkUp.SetValue(self.inst["config"]["upload"])
        self.tkKeepXPR.SetValue(self.inst["config"]["keepxpr"])
        self.tkClean.SetValue(self.inst["config"]["deltemp"])
##        self.tkDel.SetValue(self.inst["config"]["del"])
        self.__switchLocalMode()
        # end wxGlade
    
    def __changeLanguage(self, *args):
        """ Change saves settrings and display a msgbox at language changing
        """
        self.mframe.saveSettings()
        msgBox(self.inst["loc"](4032),self.inst["loc"](4033))
    
    def __switchLocalMode(self, *args):
        """ Grey unused parameters when local mode is checked
        """
        state = not self.xbMode.IsChecked()
        self.xbIP.Enable(state)
        self.xbUser.Enable(state)
        self.xbPwd.Enable(state)
        self.browse.Enable(not state)
        self.default.Enable(not state)
    
    def __browse(self, *args):
        """ Displays browse dialog and set XBMC dir with selected path
        """
        #TODO:check XBMC dir instantly
        dlg = wx.DirDialog(self, "Choose a directory:", self.xbDir.GetValue(),
                           style=wx.DD_DEFAULT_STYLE|wx.DD_DIR_MUST_EXIST)
        
        # checks provided directory and ask user confirmation if XBMC is not located
        if dlg.ShowModal() == wx.ID_OK and (core.testLocalXBMC(dlg.GetPath()) or \
           yesNoBox(self.inst["loc"](4030), self.inst["loc"](4031)%dlg.GetPath())):
            self.xbDir.SetValue(dlg.GetPath())
        dlg.Destroy()
    
    def __setDefault(self, *args):
        """ Set XBMC dir to default path
        """
        self.xbDir.SetValue(globals.DEFAULT_PATH)

    def __do_layout(self):
        # begin wxGlade: Options.__do_layout
        optionsSizer = wx.BoxSizer(wx.VERTICAL)
        optionsSubSizer = wx.FlexGridSizer(4, 1, 0, 0)
        miscBox = wx.StaticBoxSizer(self.miscBox_staticbox, wx.VERTICAL)
        langSizer = wx.BoxSizer(wx.HORIZONTAL)
        taskBox = wx.StaticBoxSizer(self.taskBox_staticbox, wx.HORIZONTAL)
        taskSizer = wx.BoxSizer(wx.VERTICAL)
        optionXbBox = wx.StaticBoxSizer(self.optionXbBox_staticbox, wx.VERTICAL)
        optionXbSizer = wx.FlexGridSizer(4, 2, 0, 10)
        optionXbSizer.Add(self.xbIPlb, 0, wx.ALIGN_CENTER_VERTICAL, 0)
        optionXbSizer.Add(self.xbIP, 0, wx.TOP|wx.ALIGN_CENTER_VERTICAL, 5)
        optionXbSizer.Add(self.xbUserlb, 0, wx.ALIGN_CENTER_VERTICAL, 0)
        optionXbSizer.Add(self.xbUser, 0, wx.TOP|wx.BOTTOM|wx.ALIGN_CENTER_VERTICAL, 2)
        optionXbSizer.Add(self.xbPwdlb, 0, wx.ALIGN_CENTER_VERTICAL, 0)
        optionXbSizer.Add(self.xbPwd, 0, wx.TOP|wx.BOTTOM|wx.ALIGN_CENTER_VERTICAL, 2)
        optionXbSizer.Add(self.xbDirlb, 0, wx.ALIGN_CENTER_VERTICAL, 0)
        dirSizer = wx.FlexGridSizer()
        dirSizer.Add(self.xbDir)
        dirSizer.Add(self.browse)
        dirSizer.Add(self.default)
        optionXbSizer.Add(dirSizer, 0, wx.BOTTOM|wx.ALIGN_CENTER_VERTICAL, 5)
        optionXbBox.Add(self.xbMode, 0, wx.ALIGN_CENTER, 0)
        optionXbBox.Add(optionXbSizer, 1, wx.ALL|wx.EXPAND, 5)
        optionsSubSizer.Add(optionXbBox, 1, wx.ALL|wx.EXPAND, 10)
        taskBox.Add((10, 0), 0, 0, 0)
        taskSizer.Add(self.tkDl, 0, wx.TOP, 5)
        taskSizer.Add(self.tkBuild, 0, wx.TOP|wx.BOTTOM, 4)
        taskSizer.Add(self.tkUp, 0, wx.BOTTOM, 2)
        taskSizer.Add(self.tkKeepXPR, 0, wx.LEFT, 15)
        taskSizer.Add(self.tkClean, 0, wx.TOP|wx.BOTTOM, 4)
##        taskSizer.Add(self.tkDel, 0, wx.BOTTOM, 4)
        taskBox.Add(taskSizer, 1, wx.EXPAND, 0)
        optionsSubSizer.Add(taskBox, 1, wx.ALL|wx.EXPAND, 10)
        langSizer.Add(self.lang_lab, 0, wx.ALL|wx.ALIGN_CENTER_VERTICAL, 7)
        langSizer.Add(self.lang, 0, wx.ALL|wx.EXPAND, 7)
        miscBox.Add(langSizer, 1, wx.ALIGN_CENTER_HORIZONTAL, 0)
        #miscBox.Add(self.miscDefault, 0, wx.ALL|wx.ALIGN_CENTER_VERTICAL|wx.ALIGN_CENTER_HORIZONTAL, 7)
        optionsSubSizer.Add(miscBox, 1, wx.ALL|wx.EXPAND, 10)
        optionsSizer.Add(optionsSubSizer, 1, wx.ALIGN_CENTER_HORIZONTAL|wx.ALIGN_CENTER_VERTICAL, 0)
        self.SetSizer(optionsSizer)
        optionsSizer.Fit(self)
        self.SetAutoLayout(True)
        self.SetupScrolling(scroll_x=False)
        # end wxGlade


class Customizations(scrolled.ScrolledPanel):
    def __init__(self, *args, **kwds):
        self.inst = kwds["instances"]
        del kwds["instances"]  # make a crash on wx.Panel.__init__ if exists
        
        self.skins = {}   # all customizations instances will be placed here
        
        # begin wxGlade: Customizations.__init__
        kwds["style"] = wx.TAB_TRAVERSAL
        scrolled.ScrolledPanel.__init__(self, *args, **kwds)
        self.cusVersion = wx.StaticText(self, -1, "config.xml v"+str(self.inst["xmlcfg"].getVersion()))
        
        # Sizer for custom boxes. A separate sizer is created to have all boxes centerd with same dimension
        self.customSizer = wx.FlexGridSizer(2, 1, 5, 10) 
        self.__setCustomBoxes()
        
        self.__do_layout()
        # end wxGlade
    
    def GetOptionsValues(self, iter=None):
        """ Returns a dictionary with following pattern :
              {SkinName:{CustomType:{CustomName:Value, ...}|Value, ...}, ...}
            Must be called instead of retrieve self.skins dirrectly for getting values not wx instances.
              iter : private argument for recurse calls (dictionary).
        """
        values = {}
        if iter is None: iter = self.skins
        for i in iter:
            if type(iter[i]) is dict:
                # parse sub dictionary
                values[i] = self.GetOptionsValues(iter[i])
            else:
                # standard node : just put value
                values[i] = iter[i].GetValue()
        return values

    def __do_layout(self):
        # begin wxGlade: Customizations.__do_layout
        customMainSizer = wx.BoxSizer(wx.VERTICAL)
        customMainSizer.Add(self.cusVersion, 0, wx.ALL|wx.ALIGN_RIGHT, 5)
        customMainSizer.Add(self.customSizer, 1, wx.ALIGN_CENTER_HORIZONTAL|wx.ALIGN_CENTER_VERTICAL, 0)
        self.SetSizer(customMainSizer)
        customMainSizer.Fit(self)
        self.SetAutoLayout(True)
        self.SetupScrolling(scroll_x=False)
        # end wxGlade
    
    def __setCustomBoxes(self):
        """ Creates and map all customizations boxes
        """
        # Customization functions
        CUSTOM_FCT = {
            "choicefolder1":self._choiceFolder1,
            "choicefolder2":self._choiceFolder2,
            "optfolder"    :self._optFolder,
            "optfiles"     :self._optFiles,
            "batfile"      :self._batFile,
            "buildfolder"  :self._buildFolder }
        
        data = self.inst["xmlcfg"].getCustom()
        # each skin is parsed : the useful instances will be placed in self.skins dictionary
        # indexed by their type and then their name for multiple nodes.
        # Each custom type has its own creation function
        for skin in data:
            self.skins[skin] = {}
            skin_staticbox = wx.StaticBox(self, -1, skin)
            skin_sizer     = wx.StaticBoxSizer(skin_staticbox, wx.VERTICAL)
            for custom in data[skin]:
                # call custom function with custom data and skin name
                CUSTOM_FCT[custom](skin_sizer, skin, data[skin][custom])
            
            # maps the box only if there is something to display
            if len(self.skins[skin]) > 0:
                self.customSizer.Add(skin_sizer, 1, wx.EXPAND, 0)
            else: # clean that mess
                skin_sizer.Destroy()
                del self.skins[skin]
    
    #---  Customizations functions  ---
    #----------------------------------
    def _choiceFolder1(self, sizer, skinName, data):
        """ Creates a wx.choice """
        self.skins[skinName]["choicefolder1"] = {}
        for item in data:
            self.skins[skinName]["choicefolder1"][item] = self._choicelist(sizer, data[item]["string"],
              data[item]["choices"], self._defineDefault(skinName,data,"choicefolder1",item))
    
    def _choiceFolder2(self, sizer, skinName, data):
        self.skins[skinName]["choicefolder2"] = {}
        for item in data:
            self.skins[skinName]["choicefolder2"][item] = self._choicelist(sizer, data[item]["string"],
              data[item]["sources"].keys(), self._defineDefault(skinName,data,"choicefolder2",item))
    
    def _optFolder(self, sizer, skinName, data):
        self.skins[skinName]["optfolder"] = {}
        for item in data:
            self.skins[skinName]["optfolder"][item] = self._checkBox(sizer, data[item]["string"],
              self._defineDefault(skinName,data,"optfolder",item))
    
    def _optFiles(self, sizer, skinName, data):
        self.skins[skinName]["optfiles"] = {}
        for item in data:
            self.skins[skinName]["optfiles"][item] = self._checkBox(sizer, data[item]["string"],
              self._defineDefault(skinName,data,"optfiles",item))
    
    def _batFile(self, sizer, skinName, data):
        if type(data) is CustomDict:  # this is a list if there is only one choice
            self.skins[skinName]["batfile"] = self._choicelist(sizer, data["string"],
              data["files"].keys(), self._defineDefault(skinName,data,"batfile"))
    
    def _buildFolder(self, sizer, skinName, data):
        if type(data) is CustomDict:  # this is a string if there is only one choice
            self.skins[skinName]["buildfolder"] = self._choicelist(sizer, data["string"],
              data["sources"].keys(), self._defineDefault(skinName,data,"buildfolder"))
    
    def _defineDefault(self, skinName, data, customName, itemName=None):
        """ define default choice for a skin customization based on config choice
            and then on specified default (if provided)
              skinName : skin's name
              data : customization dictionary
              customName : customization's name
              itemName : custostomization item's name (None if N/A)
        """
        # search in config
        if self.inst["config"].has_key("custom") and \
           self.inst["config"]["custom"].has_key(skinName) and \
           self.inst["config"]["custom"][skinName].has_key(customName):
            if not itemName:
                return self.inst["config"]["custom"][skinName][customName]
            elif self.inst["config"]["custom"][skinName][customName].has_key(itemName):
                return self.inst["config"]["custom"][skinName][customName][itemName]
        # then search for a specifed default
        if data.has_key("default"):
            return data["default"]
        # finally takes program default
        return False
    
    def _choicelist(self, sizer, string, choices, default):
        """ generic function for draw a dropdown choice with multiple nodes
              sizer   : wx.Sizer or derivates where maps the list
              string  : description string (string or integer id)
              choices : list or tuple of choices
              default : set default choice (first if not provided)
            returns a wx.Choice instance
        """
        # a dropdown list requires an HORIZONTAL subsizer
        subsizer = wx.BoxSizer(wx.HORIZONTAL)
        # adds description string (localizd if necessary)
        subsizer.Add(wx.StaticText(self, -1,
          self.inst["loc"](string) if type(string) is int else string), 0,
          wx.ALIGN_LEFT|wx.ALIGN_CENTER_VERTICAL|wx.RIGHT, 10)
        # create and configure wx.choice instance
        instance = Choice(self, -1, choices=choices)
        # sets default string if specified
        if type(default) in (str, unicode):
            instance.SetStringSelection(default)
        else: # first choice is selected
            instance.SetSelection(0)
        # maps the wx.choice
        subsizer.Add(instance, 0, wx.EXPAND|wx.ALIGN_RIGHT)
        sizer.Add(subsizer, 0, wx.ALIGN_CENTER_HORIZONTAL|wx.ALL, 5)
        return instance
    
    def _checkBox(self, sizer, string, default=False):
        """ generic function for draw a checkbox with multiple nodes
              sizer   : wx.Sizer or derivates where maps the list
              string  : description string (string or integer id)
              default : set default choice (unchecked if not provided)
            returns a wx.CheckBox instance
        """
        instance = wx.CheckBox(self, -1, self.inst["loc"](string) if type(string) is int else string)
        instance.SetValue(default)
        sizer.Add(instance, 0, wx.ALIGN_CENTER_HORIZONTAL|wx.ALL, 5)
        return instance


class Operations(scrolled.ScrolledPanel):
    def __init__(self, *args, **kwds):
        """ This class needs MainFrame (given as mainframe) instance too for global GUI operations 
        """
        self.inst   = kwds["instances"]
        self.mframe = kwds["mainframe"]
        del kwds["instances"], kwds["mainframe"]  # make a crash on wx.Panel.__init__ if exists
        # begin wxGlade: Operations.__init__
        kwds["style"] = wx.TAB_TRAVERSAL
        scrolled.ScrolledPanel.__init__(self, *args, **kwds)
        self.opReset_staticbox = wx.StaticBox(self, -1, self.inst["loc"](2029))
        self.opStartBtn = wx.Button(self, -1, self.inst["loc"](2028))
        self.opOvProgress = wx.Gauge(self, -1, 10)
        self.opCurTask = wx.StaticText(self, -1, self.inst["loc"](2030)%(self.inst["loc"](2031),""))
        self.opTkProgress = wx.Gauge(self, -1, 10)
        self.opLog = wx.TextCtrl(self, -1, "", style=wx.TE_MULTILINE|wx.TE_READONLY|wx.TE_AUTO_URL|wx.TE_NOHIDESEL)
        self.resetTxt = wx.StaticText(self, -1, self.inst["loc"](2044),style=wx.ALIGN_CENTRE)
        self.resetBtn = wx.Button(self, -1, self.inst["loc"](2045))

        self.__set_properties()
        self.__do_layout()
        # end wxGlade
    
    def incOvProgress(self, n=1):
        """ Add n to overall progress gauge. If n is omitted, 1 will be added.
            For set gauge to a determinated position, use opOvProgress.SetValue directly
        """
        self.opOvProgress.SetValue(self.opOvProgress.GetValue() + n)
    
    def setCurTask(self, *args):
        """ Updates the current task text with provided strings (2 required).
        """
        try:
            self.opCurTask.SetLabel(self.inst["loc"](2030)%args)
        except:
            debug()
        finally:
            self.opSizer.Layout()

    def __set_properties(self):
        # begin wxGlade: Operations.__set_properties
        self.opTkProgress.SetMinSize((-1, 15))
        self.opLog.SetMinSize((-1, 200))
        self.Bind(wx.EVT_BUTTON, self.__start, self.opStartBtn)
        self.Bind(wx.EVT_BUTTON, self.__reset, self.resetBtn)
        # end wxGlade

    def __do_layout(self):
        # begin wxGlade: Operations.__do_layout
        self.opSizer = wx.BoxSizer(wx.VERTICAL)
        opReset = wx.StaticBoxSizer(self.opReset_staticbox, wx.VERTICAL)
        self.opSizer.Add(self.opStartBtn, 0, wx.ALL|wx.ALIGN_CENTER_HORIZONTAL, 15)
        self.opSizer.Add(self.opOvProgress, 0, wx.LEFT|wx.RIGHT|wx.EXPAND, 15)
        self.opSizer.Add(self.opCurTask, 0, wx.TOP|wx.ALIGN_CENTER_HORIZONTAL|wx.ALIGN_CENTER_VERTICAL, 10)
        self.opSizer.Add(self.opTkProgress, 0, wx.LEFT|wx.RIGHT|wx.BOTTOM|wx.EXPAND, 15)
        self.opSizer.Add(self.opLog, 0, wx.ALL|wx.EXPAND, 15)
        opReset.Add(self.resetTxt, 0, wx.LEFT|wx.RIGHT|wx.TOP|wx.EXPAND|wx.ALIGN_CENTER_VERTICAL, 10)
        opReset.Add(self.resetBtn, 0, wx.ALL|wx.ALIGN_CENTER_HORIZONTAL|wx.ALIGN_CENTER_VERTICAL, 10)
        self.opSizer.Add(opReset, 1, wx.ALL|wx.EXPAND, 25)
        self.SetSizer(self.opSizer)
        self.opSizer.Fit(self)
        self.SetAutoLayout(True)
        self.SetupScrolling(scroll_x=False)
        # end wxGlade
    
    def __start(self, *args):
        """ Start skins processing and saves config
        """
        self.mframe.saveSettings()
        svn, http = self.mframe.getCheckedSkins() # getting skins lists
        self.mframe.Disable()
        delayedresult.startWorker(self.__processConsumer, core.processSkins, wargs=(svn, http, self.inst, self))
    
    def __processConsumer(self, delayed):
        """starts delayed thread
        """
        try:
            delayed.get()
        except:
            debug()
        # the following instructions are executed only after the end of operations
        self.setCurTask(self.inst["loc"](2031), "")
        self.mframe.skinsPanel.updateVersions()
        self.mframe.Enable()
    
    def __reset(self, *args):
        """ resets skins settings
        """
        self.mframe.saveSettings()
        callback = Callback(core.resetSkinSettings, 
                            self.inst["config"]["IP"],
                            self.inst["config"]["user"], 
                            self.inst["config"]["passwd"], 
                            self.inst["config"]["xbmcdir"],
                            self.inst["loc"],
                            self.inst["config"]["local"] )
        self.mframe.Disable()
        delayedresult.startWorker(self.__processConsumer, callback)


class MainFrame(wx.Frame):
    def draw(self, instances):
        self.inst = instances
        # begin wxGlade: MainFrame.__init__
        self.notebook = wx.Notebook(self, -1, style=0)
        self.skinsPanel   = Skins         (self.notebook, -1, instances=self.inst)
        self.optionsPanel = Options       (self.notebook, -1, instances=self.inst, mainframe=self)
        self.customPanel  = Customizations(self.notebook, -1, instances=self.inst)
        self.opPanel      = Operations    (self.notebook, -1, instances=self.inst, mainframe=self)

        self.__set_properties()
        self.__do_layout()
        # end wxGlade
    
    def getCheckedSkins(self):
        """ Returns (in this order) :
              - list of checked SVN skins
              - dictionary of checked HTTP skins with skin data indexed bk skinName
        """
        svn  = []
        http = CustomDict()
        
        # getting SVN skins
        for skin in self.skinsPanel.svnSkins:
            if self.skinsPanel.svnSkins[skin][0].IsChecked():
                svn.append(skin)
        
        # getting HTTP skins
        for skin in self.skinsPanel.httpSkins:
            if self.skinsPanel.httpSkins[skin][0].IsChecked():
                http[skin] = self.inst["xmlcfg"].getHttpData(skin)
        
        return svn, http
    
    def saveSettings(self):
        """ Updates and saves config file """
        self.inst["config"]["custom"] = self.customPanel.GetOptionsValues()
        self.inst["config"]["local"]  = self.optionsPanel.xbMode.IsChecked()
        self.inst["config"]["IP"]     = self.optionsPanel.xbIP.GetValue()
        self.inst["config"]["user"]   = self.optionsPanel.xbUser.GetValue()
        self.inst["config"]["passwd"] = self.optionsPanel.xbPwd.GetValue()
        self.inst["config"]["xbmcdir"]= self.optionsPanel.xbDir.GetValue()
        self.inst["config"]["update"] = self.optionsPanel.tkDl.IsChecked()
        self.inst["config"]["build"]  = self.optionsPanel.tkBuild.IsChecked()
        self.inst["config"]["upload"] = self.optionsPanel.tkUp.IsChecked()
        self.inst["config"]["keepxpr"]= self.optionsPanel.tkKeepXPR.IsChecked()
        self.inst["config"]["deltemp"]= self.optionsPanel.tkClean.IsChecked()
##        self.inst["config"]["del"]    = self.optionsPanel.tkDel.IsChecked()
        self.inst["config"]["lang"]   = self.optionsPanel.lang.GetStringSelection()
        self.inst["config"]["lastup"]  = self.inst["xmlcfg"].getLastUpdate()[0]
        self.inst["config"]["version"]= globals.VERSION
        config.save_settings(self.inst["config"])
        
    def Disable(self):
        """ Disables all tabs, same as Enable(false).
        """
        return self.notebook.Disable()
    
    def Enable(self, mode=True):
        """ Enable or disable the tabs and all children for user input.
        """
        return self.notebook.Enable(mode)

    def __set_properties(self):
        # begin wxGlade: MainFrame.__set_properties
        _icon = wx.EmptyIcon()
        _icon.CopyFromBitmap(wx.BitmapFromImage(wx.ImageFromStream(StringIO.StringIO(b64decode(ICON)))))
        self.SetIcon(_icon)
        self.SetTitle(self.inst["loc"](1)%globals.VERSION)
        self.skinsPanel.SetToolTipString(self.inst["loc"](2001))
        self.optionsPanel.SetToolTipString(self.inst["loc"](2003))
        self.customPanel.SetToolTipString(self.inst["loc"](2005))
        self.opPanel.SetToolTipString(self.inst["loc"](2007))
        self.SetBackgroundColour(wx.SystemSettings_GetColour(wx.SYS_COLOUR_3DFACE))
        # end wxGlade

    def __do_layout(self):
        # begin wxGlade: MainFrame.__do_layout
        mainSizer = wx.BoxSizer(wx.HORIZONTAL)
        self.notebook.AddPage(self.skinsPanel  , self.inst["loc"](2000))
        self.notebook.AddPage(self.optionsPanel, self.inst["loc"](2002))
        self.notebook.AddPage(self.customPanel , self.inst["loc"](2004))
        self.notebook.AddPage(self.opPanel     , self.inst["loc"](2006))
        mainSizer.Add(self.notebook, 1, wx.ALL|wx.EXPAND, 10)
        self.SetSizer(mainSizer)
        mainSizer.Fit(self)
        # Sets the size of most higher panel plus current window size (tab bar & margins)
        # This is limited to screen height and scrolled if bigger
        self.SetSize((-1,max(self.skinsPanel.GetSizer().GetSizeTuple()[1],
                             self.optionsPanel.GetSizer().GetSizeTuple()[1],
                             self.customPanel.GetSizer().GetSizeTuple()[1],
                             self.opPanel.GetSizer().GetSizeTuple()[1])+
                             self.GetSizeTuple()[1]-20)) #20px is original tabs height
        self.Layout()
        # end wxGlade

class mainGUI(wx.App):
    def OnInit(self):
        wx.InitAllImageHandlers()
        self.frame = MainFrame(None, -1, "")
        instances = self.__doInitialization()
        
        # check for updates
        lastUpdate = instances["xmlcfg"].getLastUpdate()
        # arithmetic test is impossible here because verson are not necessarily numbers
        if lastUpdate[0] != globals.VERSION and lastUpdate[0] != instances["config"]["lastup"]:
            Update(lastUpdate, instances["loc"])
        
        self.frame.draw(instances)
        self.SetTopWindow(self.frame)
        self.frame.Show()

        # now we can set the log's destination widget
        sys.stdout.setDestination(self.frame.opPanel.opLog)
        
        # put log's tab if errors are displayed
        if instances.has_key("exc"):
            self.frame.notebook.ChangeSelection(3)
            del instances["exc"]
        return 1
    
    def OnExit(self):
        # put stdout back
        sys.stdout.close()
        sys.stdout = sys.__stdout__
    
    def __doInitialization(self):
        """ Initializes all variables
            Returns a dictionary with all intialized instnces :
              "lang"   : language instance
              "loc"    : shortcut for get in localized string
              "config" : config dictionary
              "xmlcfg" : CongifXML instance
              "svn"    : SvnTools instance
        """
        inst = CustomDict()
        init = Init()
        inst["config"], inst["lang"] = init.getInit()
        inst["loc"] = inst["lang"].localized          # shortcut for localized strings
        init.start()
        dlg = wx.ProgressDialog(inst["loc"](1000), inst["loc"](1001), parent=self.frame, style = wx.PD_APP_MODAL )
        while init.isAlive():
            wx.MilliSleep(100)
            dlg.Pulse(inst["loc"](1001+init.status)) #The init strings numbers are 1001-1005
        inst["xmlcfg"], inst["svn"] = init.getThread()
        dlg.Destroy()
        
        # write log messages (and traceback in debug mode)
        if len(init.exc) > 0:
            print inst["loc"](5000)
            if init.exc.has_key("net") :
                print inst["loc"](5001)
                if globals.STATUS["debug"] :
                    traceback.print_exception(init.exc["net"][0],init.exc["net"][1],init.exc["net"][2])
            if init.exc.has_key("xml") :
                print inst["loc"](5003)
                if globals.STATUS["debug"] :
                    traceback.print_exception(init.exc["xml"][0],init.exc["xml"][1],init.exc["xml"][2])
            if init.exc.has_key("svn") :
                print inst["loc"](5002)
                if globals.STATUS["debug"] :
                    traceback.print_exception(init.exc["svn"][0],init.exc["svn"][1],init.exc["svn"][2])
            inst["exc"] = None  # signals that exception has occured
        return inst
        



class Log:
    # Header which delimitate each session on log file
    FILE_HEADER = """\n\n\n
    ------- XBMC Skin Manager v%s-------
    -------------------------------------
    Date : %s
    -------------------------------------\n"""

    def __init__(self, ctrl=None):
        """ Basic file like class for log I/O
              ctrl    : WxTextCtrl instance. Messages are buffered if it's not a WxTextCtrl
        """
        self.out = ctrl
        if ctrl is None : self.stack = []
        
        if globals.STATUS["log"]:
            self.logfile = open(globals.LOGFILE, "a+")
            self.logfile.write(Log.FILE_HEADER%(globals.VERSION, wx.Now()))
        else : self.logfile = None
        self.blank = re.compile("\s+")  # blank string pattern
    
    def setDestination(self, ctrl):
        """ Sets/change the destination widget.
              ctrl    : WxTextCtrl instance. Messages are stacked if it's not a WxTextCtrl
            Writes eventual stack onto it in LILO mode
        """
        if type(ctrl) is wx.TextCtrl: # to prevent infinite loop at stack writing
            self.out = ctrl
            # Writes stack 
            while len(self.stack) > 0:
                self.write(self.stack.pop(0))
    
    def close(self):
        """ Only closes log file properly if needed """
        if globals.STATUS["log"] : self.logfile.close()
    
    def write(self, string):
        """ Writes the string in log.
            In order to be correctly formated string can be tagged (optional) : 
            a tagged sting has the following structure : "tags|message"
            Available tages are:
              d : only displayed in debug mode
              v : only displayed in verbose mode
              i : adds an indentation before string
              c : text is centered
              r,g : red and green text colors
            A non tagged string will be displayed in wx.SYS_COLOUR_WINDOWTEXT at left border
        """
        # skips blank strings
        if self.blank.match(string) : return
        
        # Stacks the message if destination is not set
        if type(self.out) is not wx.TextCtrl:
            self.stack.append(string)
            return
        
        string = string.split("|")  # separate tags and content
        # insert an empty string for simplify further tests
        if len(string) < 2:
            string.insert(0,"")
        
        # no need to parse string if it's not written
        if ("d" in string[0] and not globals.STATUS["debug"]) or ("v" in string[0] and not globals.STATUS["verb"]):
            return
        
        # adds the line return if not provided
        if string[1][-1] != "\n":
            string[1] += "\n"
        
        # set the color
        if   "g" in string[0] : style = wx.TextAttr(DARK_GREEN)
        elif "r" in string[0] : style = wx.TextAttr(DARK_RED)
        else : style = wx.TextAttr(wx.SystemSettings_GetColour(wx.SYS_COLOUR_WINDOWTEXT))
        
        # text alignment
        if "i" in string[0] : string[1] = "    "+string[1]
        if "c" in string[0] : style.SetAlignment(wx.TEXT_ALIGNMENT_CENTRE)
        else                : style.SetAlignment(wx.TEXT_ALIGNMENT_LEFT)

        wx.CallAfter(self.out.SetDefaultStyle,style)
        wx.CallAfter(self.out.SetInsertionPointEnd)
        wx.CallAfter(self.out.WriteText,string[1])
        
        # log file entry
        if self.logfile is not None:
            self.logfile.write("[%s] %s"%(string[0], string[1]))


# ***  Debugging section  ***
if __name__ == "__main__":
    sys.stdout = Log()
    app = mainGUI(False)
    print "&éèèààà"
    app.MainLoop()
