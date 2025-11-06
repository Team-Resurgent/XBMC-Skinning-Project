"""
XBMCScripts Installer v1.8
Last updated: February 26th 2007
"""

version = 1.8

"""
Credits:
Main script and graphics: EnderW (enderw@xbmscripts.com)
Additional coding: blittan (blittan@xbmcscripts.com)
Modules: CachedHTTP: Aslak Grinsted / Phunck (ag@phunck.com)

Visit http://www.xbmcscripts.com for help and updates on this script.

Changelog:
 - added: progress of startup
 - added: online update
 - added: check if we are online before starting
 - added: MC360 gui

"""

import xbmc

UPDATING = 0
dummy = xbmc.getCondVisibility("System.InternetState")

if (not dummy): xbmc.sleep(500)
if (xbmc.getCondVisibility("System.InternetState")):
  import urllib2, xbmcgui
  URL = "http://www.xbmcscripts.com/scriptservice/?version=true"
  print "Fetching version from XBMCScripts.com"
  try:
    data = urllib2.urlopen(URL).read()
    onlineversion = float(data.split('|')[0])
    manditory = data.split('|')[1]
    line1 = data.split('|')[2]
    if len(data.split('|')) > 3: line2=data.split('|')[3]
    else: line2 = ''
    if len(data.split('|')) > 4: line3=data.split('|')[4]
    else: line3 = ''
    if onlineversion != None or onlineversion > 3:
      print "("+str(onlineversion)+") versionstring downloaded successfully!"
    else:
      print "Couldn't fetch versionstring, returned empty object"
  except:
    print "ERROR while fetching versionstring:"
    xbmcgui.Dialog().ok('XBMCScripts installer', 'Can\'t reach www.xbmcscripts.com.','Check your connection and try again!')
    raise
  if version < onlineversion:
    if not manditory:
      if xbmcgui.Dialog().yesno('XBMCScripts installer update', line1, line2, line3):
        UPDATING = 1
    else:
      UPDATING = 1
  print "www.xbmcscripts.com is reachable!"
else:
  import xbmcgui
  xbmcgui.Dialog().ok('XBMCScripts installer', 'Can\'t reach www.xbmcscripts.com.','Check your connection and try again!')
  raise

if UPDATING:
  xbmcgui.Dialog().ok('XBMCScripts installer update', line1, line2, line3)
  try:
    f = open('Z:\\xsupdater.py', 'w')
    f.write(urllib2.urlopen('http://www.xbmcscripts.com/scriptservice/updater-src.txt').read())
    f.close()
    print "doing update"
    xbmc.executebuiltin( 'XBMC.RunScript(%s)' % 'Z:\\xsupdater.py' )
  except:
    print "ERROR during update"
    xbmcgui.Dialog().ok('XBMCScripts installer update', 'Couldn\'t update, aborting!', 'Try again...')
    raise
else:
  import sys

  try:
    del sys.modules['xbmcscripts_main']
    del sys.modules['xbmcscripts_core']
    del sys.modules['core']
    del sys.modules['main']
    del sys.modules['cachedhttp']
  except:
    pass

  sys.path.append(sys.path[0] + '\\lib')

  import xbmcscripts_main as main

  gui = main.GUI()
  gui.doModal()
  del gui
