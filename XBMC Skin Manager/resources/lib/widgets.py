# -*- coding:utf8 -*-

#-----------------------------------------------------------------------
#                           XBMC Skin Manager                           
#-----------------------------------------------------------------------
# widgets.py : misc custom WxPython widgets                             
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
import wx.lib.hyperlink as hl
import wx.lib.scrolledpanel as scrolled
import time
import os
import threading
import platform

import globals
import misc
import network

class Choice(wx.Choice):
    """ Custom wx.Choice class which add a standard GetValue method """
    def GetValue(self):
        return self.GetStringSelection()


class Update(wx.Dialog):
    def __init__(self, updateInfo, loc):
        # begin wxGlade: Update.__init__
        #TODO:close window when hl is clicked
        wx.Dialog.__init__(self, None, -1, loc(4004))
        self.text = wx.StaticText(self, -1, loc(4005)%updateInfo[0], style=wx.ALIGN_CENTRE)
        self.notes = wx.TextCtrl(self, -1, updateInfo[1])
        self.website = hl.HyperLinkCtrl(self, -1, loc(4006), URL=globals.WEBSITE)
        self.button = wx.Button(self, -1, loc(4014))
        self.Bind(wx.EVT_BUTTON, self.Destroy, self.button)

        self.__set_properties()
        self.__do_layout()
        self.ShowModal()
        #FIXME:crash with win32 py2exe executable
        try:self.Destroy()
        except:pass
        # end wxGlade

    def __set_properties(self):
        # begin wxGlade: Update.__set_properties
        self.notes.SetMinSize((350, 100))
        # end wxGlade

    def __do_layout(self):
        # begin wxGlade: Update.__do_layout
        sizer_1 = wx.BoxSizer(wx.VERTICAL)
        sizer_1.Add(self.text, 0, wx.BOTTOM|wx.EXPAND, 5)
        sizer_1.Add(self.notes, 0, wx.LEFT|wx.RIGHT|wx.ALIGN_CENTER_HORIZONTAL|wx.ALIGN_CENTER_VERTICAL, 20)
        sizer_1.Add(self.website, 0, wx.ALL|wx.ALIGN_CENTER_HORIZONTAL|wx.ALIGN_CENTER_VERTICAL, 20)
        sizer_1.Add(self.button, 0, wx.BOTTOM|wx.ALIGN_CENTER_HORIZONTAL|wx.ALIGN_CENTER_VERTICAL, 10)
        self.SetSizer(sizer_1)
        sizer_1.Fit(self)
        self.Layout()
        # end wxGlade
    
    def Destroy(self, *args):
        """ Only for handle dummy auto-inserted arguments
        """
        wx.Dialog.Destroy(self)

class ChangelogDlg(wx.Dialog):
    """ Displays the changelog dialog
          skinName : name of concerned skin
          log      : log tuple
          loc      : language.get method
          evt      : dummy (wx.Event automatically inserted)
    """
    def __init__(self, skinName, log, loc, evt=None):
        self.skinName = skinName
        self.log      = log
        self.loc      = loc
        # begin wxGlade: MyDialog.__init__
        wx.Dialog.__init__(self, None, -1, "")
        self.title = wx.StaticText(self, -1, self.loc(4015)%self.skinName, style=wx.ALIGN_CENTRE)
        self.revIndex = wx.StaticText(self, -1, self.loc(4016)%(int(self.log[0]["rev"]), int(self.log[len(self.log)-1]["rev"])))
        self.logTab = self.drawTab()
        self.button = wx.Button(self, -1, self.loc(4014))
        self.Bind(wx.EVT_BUTTON, self.Destroy, self.button)
        self.__set_properties()
        self.__do_layout()
        self.ShowModal()
        self.Destroy()
        # end wxGlade
    
    def drawTab(self):
        """ Draws the log grid. Returns a wx.FlexGridSizer """
        panel = scrolled.ScrolledPanel(self)
        sizer = wx.FlexGridSizer(0,4,15,15)
        
        revision = wx.StaticText(panel, -1, self.loc(2011), style = wx.ALIGN_CENTER_HORIZONTAL)
        date     = wx.StaticText(panel, -1, self.loc(4017), style = wx.ALIGN_CENTER_HORIZONTAL)
        author   = wx.StaticText(panel, -1, self.loc(4018), style = wx.ALIGN_CENTER_HORIZONTAL)
        notes    = wx.StaticText(panel, -1, self.loc(4019), style = wx.ALIGN_CENTER_HORIZONTAL)
        revision.SetFont(wx.Font(8, wx.DEFAULT, wx.NORMAL, wx.BOLD, 0, ""))
        date.    SetFont(wx.Font(8, wx.DEFAULT, wx.NORMAL, wx.BOLD, 0, ""))
        author.  SetFont(wx.Font(8, wx.DEFAULT, wx.NORMAL, wx.BOLD, 0, ""))
        notes.   SetFont(wx.Font(8, wx.DEFAULT, wx.NORMAL, wx.BOLD, 0, ""))
        
        # adds titles
        sizer.Add(revision)
        sizer.Add(date)
        sizer.Add(author)
        sizer.Add(notes)
        
        for change in self.log:
            # formatting date
            change["date"] = time.strftime(self.loc(3), time.gmtime(change["date"]))
            # maps the grid
            for item in ("rev","date","author","message"): # the keys must be listed in a defined order
                text = wx.StaticText(panel, -1, str(change[item]))
                text.Wrap(450)
                sizer.Add(text, flag = wx.TOP|wx.ALIGN_CENTER_VERTICAL, border=10)
        panel.SetSizer(sizer)
        sizer.Fit(panel)
        panel.SetupScrolling(scroll_x=False)
        return panel

    def __set_properties(self):
        # begin wxGlade: MyDialog.__set_properties
        self.SetTitle(self.loc(4015)%self.skinName)
        self.title.SetFont(wx.Font(20, wx.DEFAULT, wx.NORMAL, wx.BOLD, 0, ""))
        # end wxGlade

    def __do_layout(self):
        # begin wxGlade: MyDialog.__do_layout
        sizer = wx.BoxSizer(wx.VERTICAL)
        sizer.Add(self.title, 0, wx.ALL|wx.ALIGN_CENTER_HORIZONTAL, 5)
        sizer.Add(self.revIndex, 0, wx.BOTTOM|wx.ALIGN_CENTER_HORIZONTAL, 5)
        sizer.Add(self.logTab, 1, wx.EXPAND|wx.ALL, 15)
        sizer.Add(self.button, 0, wx.ALL|wx.ALIGN_RIGHT, 5)
        sizer.Fit(self)
        self.SetSizer(sizer)
        logsize = self.logTab.GetSizer().GetSizeTuple()
        # calculates window size (max log height : 500 px)
        self.SetSize((logsize[0]+30, self.GetSizeTuple()[1]+min(logsize[1], 500)))
        self.Layout()
        self.Centre()
        # end wxGlade
        
    def Destroy(self, *args):
        """ Only for handle dummy auto-inserted arguments
        """
        wx.Dialog.Destroy(self)


class InfoDialog(wx.Dialog):
    """ Displays info dialog for HTTP Skins
          skinName : name of concerned skin
          skinDict : info dictionary for skin
          loc      : language.get method
          evt      : dummy (wx.Event automatically inserted)
    """
    def __init__(self, skinName, skinDict, loc, evt):
        # begin wxGlade: InfoDialog.__init__
        self.skinDict = skinDict
        self.name     = skinName
        self.loc      = loc
        self.weblinks = []
        wx.Dialog.__init__(self, None, -1, "", style=wx.DEFAULT_DIALOG_STYLE)
        self.skinName = wx.StaticText(self, -1, self.name, style=wx.ALIGN_CENTRE)
        self.author = wx.StaticText(self, -1, loc(4007)%self.skinDict['author'])
        self.lastVersion = wx.StaticText(self, -1, loc(4008)%self.skinDict['lastversion'])
        self.localVersion = wx.StaticText(self, -1, loc(4009)%self.skinDict['localversion'])
        # xml size file is based on a test request which can be fail. In this case -1 is
        # set for size.
        self.filesize = wx.StaticText(self, -1, loc(4010)%\
          misc.parseSize(int(self.skinDict['skinsize']), loc(2)) if int(self.skinDict['skinsize']) > 0 else loc(2048))
        self.readmeTitle = wx.StaticText(self, -1, loc(4011))
        self.readme = wx.TextCtrl(self, -1, self.skinDict['info'], style=wx.TE_MULTILINE|wx.TE_READONLY|wx.TE_RICH2)
        self.screenshotButton = wx.Button(self, -1, loc(4012))
        self.closeButton = wx.Button(self, -1, loc(4014))
        
        for link in self.skinDict['weblinks']:
            self.weblinks.append(hl.HyperLinkCtrl(self, wx.ID_ANY, link, URL=self.skinDict['weblinks'][link]))

        self.__set_properties()
        self.__do_layout()
        self.ShowModal()
        self.Destroy()
        # end wxGlade

    def __set_properties(self):
        # begin wxGlade: InfoDialog.__set_properties
        self.SetTitle(self.name)
        self.skinName.SetFont(wx.Font(20, wx.DEFAULT, wx.NORMAL, wx.BOLD, 0, ""))
        self.author.SetFont(wx.Font(10, wx.DEFAULT, wx.ITALIC, wx.NORMAL, 0, ""))
        self.readme.SetMinSize((350, 180))
        
        if self.skinDict.has_key("screenshot"):
            callback = misc.Callback(ScreenshotDlg, 
                                     self, self.name, 
                                     self.skinDict['screenshot'], 
                                     globals.STATUS["net"], 
                                     self.loc)
            self.Bind(wx.EVT_BUTTON, callback, self.screenshotButton)
        else:
            self.screenshotButton.Disable()
        
        self.Bind(wx.EVT_BUTTON, self.Destroy, self.closeButton)
        # end wxGlade

    def __do_layout(self):
        # begin wxGlade: InfoDialog.__do_layout
        mainSizer = wx.BoxSizer(wx.VERTICAL)
        mainSizer.Add(self.skinName, 0, wx.ALL|wx.ALIGN_CENTER_HORIZONTAL|wx.ALIGN_CENTER_VERTICAL, 0)
        mainSizer.Add(self.author, 0, wx.BOTTOM|wx.ALIGN_CENTER_HORIZONTAL|wx.ALIGN_CENTER_VERTICAL, 12)
        mainSizer.Add(self.lastVersion, 0, wx.LEFT, 15)
        mainSizer.Add(self.localVersion, 0, wx.LEFT, 15)
        mainSizer.Add(self.filesize, 0, wx.LEFT, 15)
        mainSizer.Add(self.readmeTitle, 0, wx.TOP|wx.ALIGN_CENTER_HORIZONTAL|wx.ALIGN_CENTER_VERTICAL, 10)
        mainSizer.Add(self.readme, 0, wx.LEFT|wx.RIGHT|wx.BOTTOM|wx.EXPAND, 10)
        mainSizer.Add(self.screenshotButton, 0, wx.ALL|wx.ALIGN_CENTER_HORIZONTAL|wx.ALIGN_CENTER_VERTICAL, 5)
        # Weblinks (l'affichage est désactivé s'il y en a pas)
        if len(self.weblinks) > 0:
            linksSizer = wx.BoxSizer(wx.VERTICAL)
            linksSizer.Add(wx.StaticText(self, -1, self.loc(4013)), 0, wx.LEFT, 15)
            for link in self.weblinks:
                linksSizer.Add(link, 0, wx.LEFT, 40)
            mainSizer.Add(linksSizer, 1, wx.EXPAND, 0)
        mainSizer.Add(self.closeButton, 0, wx.ALL|wx.ALIGN_CENTER_HORIZONTAL|wx.ALIGN_CENTER_VERTICAL, 10)
        self.SetSizer(mainSizer)
        mainSizer.Fit(self)
        self.Layout()
        # end wxGlade

    def Destroy(self, *args):
        """ Only for handle dummy auto-inserted arguments
        """
        wx.Dialog.Destroy(self)

class ScreenshotDlg(wx.Dialog):
    def __init__(self, parent, skinName, url, online, loc, evt):
        """ Downloads and display as screenshot
            parent (wxWindow) : parent
            skinName (str)
            url (str) : screenshot URL
            online (bool) : in Internet is reacheable
            loc (Language.localized)
            evt (wxEvent) : dummy
        """
        self.downloaded = 0
        self.filesize   = -1
        error      = False
        self.skinName   = skinName
        self.path       = os.path.join(globals.HTTP_SKIN_PATH, skinName, 'screenshot.jpg')
        # begin wxGlade: MyDialog.__init__
        wx.Dialog.__init__(self, parent, -1, "", style=wx.DEFAULT_DIALOG_STYLE)
        
        if online:
            try    : session = network.urlopen(url)
            except :
                misc.debug()
                error = True
            # we download only if file dosent exist or if their sizes are different
            if not error and (not os.path.isfile(self.path) or \
               os.path.getsize(self.path) != session.info()['content-length']):
                # the total size will not change : we generate string one for all
                sizeStr = misc.parseSize(session.info()['content-length'])
                progressDlg = wx.ProgressDialog(loc(4020),
                                                loc(4022)%("",sizeStr),
                                                session.info()['content-length'],
                                                self,
                                                wx.PD_APP_MODAL)
                dlThread = threading.Thread(None, session.download, None,(self.path,))
                dlThread.start()
                while dlThread.isAlive():
                    progressDlg.Update(session.downloaded, loc(4022)%(misc.parseSize(session.downloaded),sizeStr))
                    wx.MilliSleep(40)
                progressDlg.Destroy()
        else:
            # we can display local image if exists
            error = not os.path.isfile(self.path)
        
        if not error:
            self.bitmap = wx.StaticBitmap(self, -1, wx.Bitmap(self.path, wx.BITMAP_TYPE_ANY))
            self.__do_layout()
            self.ShowModal()
        else:
            msgBox(loc(4024), loc(4023))
        self.Destroy()
        # end wxGlade

    def __do_layout(self):
        # begin wxGlade: MyDialog.__do_layout
        sizer = wx.BoxSizer(wx.HORIZONTAL)
        sizer.Add(self.bitmap, 0, 0, 4)
        self.SetSizer(sizer)
        sizer.Fit(self)
        self.Layout()
        self.Centre()
        # end wxGlade

def yesNoBox(title, message, *args):
    """ Display a wx.MessageDialog in YES_NO mode with provided text
        return True if yes is clicked, False otherwise
        args are useless but this way it handle for auto inserted parameters
        /!\ Don't call it from a thread, use safeYesNoBox instead
    """
    return wx.MessageBox(message, title, wx.YES_NO) == wx.YES

def safeBoxThread(title, message, result):
    result.value = yesNoBox(title, message)

def safeYesNoBox(title, message, *args):
    """ Safe way to call a Yes/No bos in a thread
    """
    result = misc.threadresult()
    wx.CallAfter(safeBoxThread, title, message, result)
    return result.value

def msgBox(title, message, *args):
    """ Display a wx.MessageDialog in OK mode with provided text
        args are useless but this way it handle for auto inserted parameters
        /!\ Don't call it from a thread, use safeMsgBox instead
    """
    wx.MessageBox(message, title)

safeMsgBox = misc.Callback(wx.CallAfter, msgBox)

# ***  Debugging section  ***
if __name__ == "__main__":
    import language
    globals.RESOURCE_PATH = ".."
    app = wx.PySimpleApp()
    l = language.Language()
    log = [{'date': 1204416606.311651, 'message': u'Renamed remotely', 'rev': 1209, 'author': u'sharpe2'}, 
           {'date': 1204424138.944212, 'message': u'Updated busy animation', 'rev': 1210, 'author': u'sharpe2'},
           {'date': 1204451848.4513841, 'message': u'tweaked busy animation', 'rev': 1211, 'author': u'sharpe2'}, 
           {'date': 1204588391.7513609, 'message': u'Altered sun-menu buttons', 'rev': 1212, 'author': u'sharpe2'}]
    ChangelogDlg("Back-Row", log, l.localized)
    app.MainLoop()
    app.Destroy()
    
