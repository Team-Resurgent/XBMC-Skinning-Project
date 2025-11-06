################################################################################
##                                                                            ##
##	SCRIPT:			TV PROGRAMM // TV TODAY                       ##
##	AUTHOR:			tAGEdiEB // lazee@gmx.net                     ##
##	VERSION:		1.3                                           ##
##  LAST UPDATE:	2005-12-01                                            ##
##                                                                            ##
##  This Script contains portions of "tvtoday TV Guide" by MyXperience        ##
##                                                                            ##
################################################################################

# -*- coding: Latin-1 -*-

################################################################################
## IMPORT & DEFINE ACTION KEYS
################################################################################

from string import *
from posixpath import exists
import urllib, urllib2, re, random, string, os.path, datetime, formatter, time, math
import Image, ImageFile
import xbmc, xbmcgui

from os.path import join, getsize

ACTION_MOVE_LEFT		=  1
ACTION_MOVE_RIGHT		=  2
ACTION_MOVE_UP			=  3
ACTION_MOVE_DOWN		=  4
ACTION_PAGE_UP			=  5
ACTION_PAGE_DOWN		=  6
ACTION_SELECT_ITEM		=  7
ACTION_HIGHLIGHT_ITEM	=  8
ACTION_PARENT_DIR		=  9
ACTION_PREVIOUS_MENU	= 10
ACTION_SHOW_INFO		= 11
ACTION_PAUSE			= 12
ACTION_STOP				= 13
ACTION_NEXT_ITEM		= 14
ACTION_PREV_ITEM		= 15
ACTION_XBUTTON			= 18

################################################################################
## Preferences
################################################################################

mainmenu_icons		= True
hauptsender_icons	= True
senderlist_icons	= True
genre_icons		= False
sender_icons		= False
soon_minutes		= 0

################################################################################
## GLOBAL VARIABLES
################################################################################

dirHome			= os.getcwd()
dirHome			= dirHome[:-1]+'\\'

RootDir			= dirHome
imageDir		= RootDir + '\\images\\'
extraimageDir	= RootDir + '\\images\\'
senderDir		= RootDir + '\\sender\\'
cacheDir		= RootDir + '\\cache\\'
senderlogos		= 'http://programm.tvtoday.de/tv/programm/bilder/senderlogos/'
constructURL	= 'http://programm.tvtoday.de/tv/programm/'
MainURL			= 'http://programm.tvtoday.de'

urldata         = None
urlheaders      = {'Accept-Language': 'en-us',}

################################################################################
## FUNCTIONS
################################################################################

def CleanName(name):
	name = replace(name, '&auml;', 'ä')
	name = replace(name, '&ouml;', 'ö')
	name = replace(name, '&uuml;', 'ü')
	name = replace(name, '&Auml;', 'Ä')
	name = replace(name, 'Oouml;', 'Ö')
	name = replace(name, '&Uuml;', 'Ü')
	name = replace(name, '&szlig;', 'ß')
	name = replace(name, '&amp;', '&')
	name = replace(name, '&hearts;', '<3')
	name = replace(name, '&#146;', '\'')
	return name
	
def RemoveTags(name):
	name = replace(name, '<br>', '')
	return name	
	
def GetKey(name):
	data=name
	rg = re.compile('href="(.*?)"', re.IGNORECASE)
	result = rg.findall(data)
	n = len(result)
	if n>0: 
		namename=result[0]  
	else:
		namename=""
	return namename

def ConvertFilename(name):
	name = replace(name, '.', '')
	name = replace(name, '-', '')
	name = replace(name, ' ', '')
	return name	

def GetDauer(name): #make titles look nicer in menu
	data=name
	rg = re.compile("<i>(.*?) Min. bis (.*?)</i>", re.IGNORECASE)
	result = rg.findall(data)
	n = len(result)
	if n>0: namename=result[0]  
	return namename
  
def GetTitel(name): #make titles look nicer in menu
	data=name
	rg = re.compile("<u>(.*?)</u>", re.IGNORECASE)
	result = rg.findall(data)
	n = len(result)
	if n>0: 
		namename=result[0]  
	else:
		data=name
		rg = re.compile('<span class="headline".*?>(.*?)</span>', re.IGNORECASE) 
		result = rg.findall(data)
		n = len(result)
		if n>0: 
			namename=result[0]
			namename = replace(namename, '<span class="headline">', '')
			namename = replace(namename, '</span>', '')
		else:    
			namename="?"
	return namename
	
################################################################################
## CLASSES
################################################################################

class senderItem:
	def __init__(self, name, senderx,senderid):
		self.name = name
		self.sender = senderx
		self.senderid = senderid

class programmaItem:
	def __init__(self, senderlogo, uhrzeit, info, key):
		self.senderlogo = strip(senderlogo)
		self.uhrzeit = strip(uhrzeit)	
		self.info = strip(info)	
		self.key = strip(key)
		
class senderListItem:
	def __init__(self, senderlogo, sendername):
		self.senderlogo = strip(senderlogo)
		self.sendername = strip(sendername)
		
################################################################################
## MAIN
################################################################################

class MainWindow(xbmcgui.Window):
	def __init__(self):

		progress = xbmcgui.DialogProgress()
		progress.create("TV Today Guide", "TV Programm wird geladen...")
		
		self.scaleX = ( float(self.getWidth())  / float(720) )
		self.scaleY = ( float(self.getHeight()) / float(480) )
		
		########################################################################
		## CREATE GUI
		########################################################################

	        self.setCoordinateResolution(6)

		self.addControl(xbmcgui.ControlImage(0,0,720,576, "background.png"))

                self.addControl(xbmcgui.ControlImage(63, 46, 133, 60,'logo_tv.png'))
                self.addControl(xbmcgui.ControlImage(585, 33, 90, 90,'DefaultScriptBig.png'))

		#self.text = xbmcgui.ControlLabel(254,50,400,30, ": Übersicht")
		#self.addControl(self.headline)
		
		self.detailSendung = xbmcgui.ControlLabel(210,120,400,30, "?")
		self.addControl(self.detailSendung)
		self.detailSendung.setVisible(0) 

		self.detailUhrzeit = xbmcgui.ControlLabel(210,150,400,30, "?")
		self.addControl(self.detailUhrzeit)
		self.detailUhrzeit.setVisible(0) 

		self.detailSender = xbmcgui.ControlLabel(480,150,400,30, "Sender:")
		self.addControl(self.detailSender)
		self.detailSender.setVisible(0)

		self.detailInfo = xbmcgui.ControlTextBox(300, 180, 350, 270)
		self.addControl(self.detailInfo)
		self.detailInfo.setVisible(0)

		self.listText = xbmcgui.ControlList(211, 120, 450, 350, "font13",'0xFFDDDDDD')
		self.addControl(self.listText)
		self.listText.setVisible(0)
		
		self.listThumb = xbmcgui.ControlList(211, 120, 450, 350, "font13",'0xFFDDDDDD')
		self.addControl(self.listThumb)
		self.listThumb.setVisible(0)

		self.buttonNext = xbmcgui.ControlButton(60, 120, 140, 30, "Später")
		self.addControl(self.buttonNext)
		self.buttonNext.setVisible(0)
		
		self.buttonPrevious = xbmcgui.ControlButton(60, 152, 140, 30, "Früher")
		self.addControl(self.buttonPrevious)
		self.buttonPrevious.setVisible(0)
		
		self.buttonMain = xbmcgui.ControlButton(60, 120, 140, 30, "Allgemein")
		self.addControl(self.buttonMain)
		self.buttonMain.setVisible(0)
		
		self.buttonSender = xbmcgui.ControlButton(60, 152, 140, 30, "Sender")
		self.addControl(self.buttonSender)
		self.buttonSender.setVisible(0)
		
		self.buttonGenre = xbmcgui.ControlButton(60, 184, 140, 30, "Genre")
		self.addControl(self.buttonGenre)
		self.buttonGenre.setVisible(0)
		
		self.listThumb.setItemHeight(39)
		self.listThumb.setImageDimensions(46,30)
		
		self.listText.controlLeft(self.buttonNext)
		self.listThumb.controlLeft(self.buttonNext)
		self.buttonNext.controlDown(self.buttonPrevious)
		self.buttonPrevious.controlUp(self.buttonNext)

		self.suchtext = ''
		self.nextExists = 0
		self.PageCount = 0
		self.state = 0
		self.mainState = "main"

		progress.close()
		self.mainMenu(mainmenu_icons)

	def onAction(self, action):
		if action == ACTION_PREVIOUS_MENU and self.state == 0:
			self.close()
		elif action == ACTION_PREVIOUS_MENU and self.state == 1:
			self.state = 0
			self.mainMenu(mainmenu_icons)
		elif action == ACTION_PREVIOUS_MENU and self.state == 2:
			self.state = 1
			self.BackFromDetail()
		elif action == ACTION_PARENT_DIR and self.state == 1:
			self.state = 0
			self.mainMenu(mainmenu_icons)
		elif action == ACTION_PARENT_DIR and self.state == 2:
			self.state = 1
			self.BackFromDetail()

	def onControl(self, control):
		if control == self.listText:
			if self.state == 0:
				self.state = 1
				self.SenderID = self.senderItems[self.listText.getSelectedPosition()].senderid
				self.SenderName = self.senderItems[self.listText.getSelectedPosition()].name
				self.ParseProgramme(hauptsender_icons, self.SenderID)

		elif control == self.listThumb:
			if self.state == 0:
				self.state = 1
				self.SenderID = self.senderItems[self.listThumb.getSelectedPosition()].senderid
				self.SenderName = self.senderItems[self.listThumb.getSelectedPosition()].name
				if self.SenderName == 'Suchen':
					self.suchtext = ''
					self.search_window()
					if self.suchtext != '':
						self.SenderID = self.SenderID + self.suchtext
						self.ParseProgramme(hauptsender_icons, self.SenderID)
					else:
						self.state = 0
				else:
					self.ParseProgramme(hauptsender_icons, self.SenderID)
			elif self.state == 1:
				self.state = 2
				self.GetDetails(self.listThumb.getSelectedPosition())

		elif control == self.buttonNext and self.state == 1:
			if self.nextExists == 0:
				self.PageCount = self.PageCount
			else:
				self.PageCount = self.PageCount + 12
			self.ParseProgramme(hauptsender_icons, self.SenderID + '&von=' + str(self.PageCount))

		elif control == self.buttonPrevious and self.state == 1:
			self.PageCount = self.PageCount - 12
			if self.PageCount < 0:
				self.PageCount = 0
			self.ParseProgramme(hauptsender_icons, self.SenderID + '&von=' + str(self.PageCount))
			
		elif control == self.buttonMain and self.state == 0:
			self.state = 0
			self.mainState = "main"
			self.mainMenu(mainmenu_icons)
			
		elif control == self.buttonSender and self.state == 0:
			self.state = 0
			self.mainState = "sender"
			self.mainMenu(senderlist_icons)
			
		elif control == self.buttonGenre and self.state == 0:
			self.state = 0
			self.mainState = "genre"
			self.mainMenu(genre_icons)

	def message(self, messageText):
		dialog = xbmcgui.Dialog()
		dialog.ok("TV Today", messageText)  

	def downloadImg(self, source, destination):        
		try:
			loc = urllib.URLopener()
			loc.retrieve(source, destination)
		except:
			print 'Error'
			#xbmcgui.Dialog().ok('Download Failed',destination)

	def search_window(self):

		keyboard = xbmc.Keyboard()
		keyboard.doModal()
		if (keyboard.isConfirmed()):
			search_txt = keyboard.getText()
			search_txt = replace(search_txt,'   ',' ');#just in case
			search_txt = replace(search_txt,'  ',' ');#just in case
			search_txt = replace(search_txt,' ','+');
			if search_txt != '':
				self.suchtext = search_txt

	def mainMenu(self, useThumbs):
		self.PageCount = 0
		self.senderItems = []

		if self.mainState == "main":
			useThumbs = mainmenu_icons
			self.senderItems.append(senderItem('Was lauft jetzt im Fernsehen?', 'JETZT' ,'programm.php?sender=HS&uhrzeit=jetzt&sparte=alle'))
			self.senderItems.append(senderItem('Was lauft gleich im Fernsehen?', 'GLEICH' , 'programm.php?ztag=&uhrzeit=' + time.strftime("%H:%M", time.localtime(time.time()+(soon_minutes*60))) + ':00&sparte=alle&sender=HS'))
			self.senderItems.append(senderItem('Was lauft ab 20:15 Uhr im Fernsehen?', '2015' ,'programm.php?sender=HS&uhrzeit=Ax20&sparte=alle'))
			self.senderItems.append(senderItem('Was lauft ab 22:00 Uhr im Fernsehen?', '2200' ,'programm.php?sender=HS&uhrzeit=Ax22&sparte=alle'))
			self.senderItems.append(senderItem('Hauptsender', 'Hauptsender' ,'programm.php?ztag=0&uhrzeit=jetzt&sparte=alle&sender=HS'))
			self.senderItems.append(senderItem('Alle Sender', 'Hauptsender' ,'programm.php?ztag=0&uhrzeit=jetzt&sparte=alle&sender=alle'))
			self.senderItems.append(senderItem('Suchen', 'Suchen' ,'programm.php?ztag=0&uhrzeit=jetzt&sparte=alle&sender=HS&suchbegriff='))
		elif self.mainState == "sender":
			useThumbs = senderlist_icons
			self.senderItems.append(senderItem('ARD', 'ard' ,'programm.php?ztag=0&sparte=alle&uhrzeit=jetzt&sender=ARD'))
			self.senderItems.append(senderItem('ZDF', 'zdf' ,'programm.php?ztag=0&sparte=alle&uhrzeit=jetzt&sender=ZDF'))
			self.senderItems.append(senderItem('RTL', 'rtl' ,'programm.php?ztag=0&sparte=alle&uhrzeit=jetzt&sender=RTL'))
			self.senderItems.append(senderItem('SAT.1', 'sat1' ,'programm.php?ztag=0&sparte=alle&uhrzeit=jetzt&sender=SAT.1'))
			self.senderItems.append(senderItem('PRO 7', 'pro7' ,'programm.php?ztag=0&sparte=alle&uhrzeit=jetzt&sender=PRO+7'))
			self.senderItems.append(senderItem('KABEL 1', 'kabel1' ,'programm.php?ztag=0&sparte=alle&uhrzeit=jetzt&sender=KABEL+1'))
			self.senderItems.append(senderItem('RTL 2', 'rtl2' ,'programm.php?ztag=0&sparte=alle&uhrzeit=jetzt&sender=RTL+2'))
			self.senderItems.append(senderItem('Super RTL', 'superrtl' ,'programm.php?ztag=0&sparte=alle&uhrzeit=jetzt&sender=SUPER+RTL'))
			self.senderItems.append(senderItem('VOX', 'vox' ,'programm.php?ztag=0&sparte=alle&uhrzeit=jetzt&sender=VOX'))
			self.senderItems.append(senderItem('3SAT', '3sat' ,'programm.php?ztag=0&sparte=alle&uhrzeit=jetzt&sender=3SAT'))
			self.senderItems.append(senderItem('ARTE', 'arte' ,'programm.php?ztag=0&sparte=alle&uhrzeit=jetzt&sender=ARTE'))
			self.senderItems.append(senderItem('ORF 1', 'orf1' ,'programm.php?ztag=0&sparte=alle&uhrzeit=jetzt&sender=ORF+1'))
			self.senderItems.append(senderItem('ORF 2', 'orf2' ,'programm.php?ztag=0&sparte=alle&uhrzeit=jetzt&sender=ORF+2'))
			self.senderItems.append(senderItem('SF1', 'sf1' ,'programm.php?ztag=0&sparte=alle&uhrzeit=jetzt&sender=SF1'))
			self.senderItems.append(senderItem('SF2', 'sf2' ,'programm.php?ztag=0&sparte=alle&uhrzeit=jetzt&sender=SF2'))
		elif self.mainState == "genre":
			useThumbs = genre_icons
			self.senderItems.append(senderItem('Spielfilme', 'GENRE' ,'programm.php?ztag=0&uhrzeit=jetzt&sparte=fil&sender=HR'))
			self.senderItems.append(senderItem('Serien', 'GENRE' ,'programm.php?ztag=0&uhrzeit=jetzt&sparte=ser&sender=HR'))
			self.senderItems.append(senderItem('Show & Fun', 'GENRE' ,'programm.php?ztag=0&uhrzeit=jetzt&sparte=unt&sender=HR'))
			self.senderItems.append(senderItem('Kinder', 'GENRE' ,'programm.php?ztag=0&uhrzeit=jetzt&sparte=kin&sender=HR'))
			self.senderItems.append(senderItem('Sport', 'GENRE' ,'programm.php?ztag=0&uhrzeit=jetzt&sparte=spo&sender=HR'))
			self.senderItems.append(senderItem('Nachrichten', 'GENRE' ,'programm.php?ztag=0&uhrzeit=jetzt&sparte=nac&sender=HR'))
			self.senderItems.append(senderItem('Politik', 'GENRE' ,'programm.php?ztag=0&uhrzeit=jetzt&sparte=pol&sender=HR'))
			self.senderItems.append(senderItem('Reportagen', 'GENRE' ,'programm.php?ztag=0&uhrzeit=jetzt&sparte=inf&sender=HR'))
			self.senderItems.append(senderItem('Kultur', 'GENRE' ,'programm.php?ztag=0&uhrzeit=jetzt&sparte=kun&sender=HR'))

		self.buttonNext.setVisible(0)
		self.buttonPrevious.setVisible(0)
		self.buttonMain.setVisible(1)
		self.buttonGenre.setVisible(1)
		self.buttonSender.setVisible(1)

		self.buttonMain.controlUp(self.buttonGenre)
		self.buttonMain.controlDown(self.buttonSender)
		self.buttonSender.controlUp(self.buttonMain)
		self.buttonSender.controlDown(self.buttonGenre)
		self.buttonGenre.controlUp(self.buttonSender)
		self.buttonGenre.controlDown(self.buttonMain)

		if useThumbs == True:
			self.listThumb.reset()
			self.buttonMain.controlRight(self.listThumb)
			self.buttonSender.controlRight(self.listThumb)
			self.buttonGenre.controlRight(self.listThumb)
			self.listThumb.controlLeft(self.buttonMain)
			self.listText.setVisible(0)
			self.listThumb.setVisible(1)
			self.setFocus(self.listThumb)
		else:
			self.listText.reset()
			self.buttonMain.controlRight(self.listText)
			self.buttonSender.controlRight(self.listText)
			self.buttonGenre.controlRight(self.listText)
			self.listText.controlLeft(self.buttonMain)
			self.listThumb.setVisible(0)
			self.listText.setVisible(1)
			self.setFocus(self.listText)

		for m in self.senderItems:
			if useThumbs == True:
				thumb = extraimageDir + str(m.sender) + ".png"
				if not os.path.exists(thumb):
					thumb = senderDir + str(m.sender) + ".gif"
				Sendungseintrag = xbmcgui.ListItem("    " + m.name,"" ,"", thumb)
				self.listThumb.addItem(Sendungseintrag)
			else:
				Sendungseintrag = xbmcgui.ListItem("    " + m.name,"" ,"")
				self.listText.addItem(Sendungseintrag)
	
	def ParseProgramme(self, useThumbs, sender):
		self.buttonMain.setVisible(0)
		self.buttonGenre.setVisible(0)
		self.buttonSender.setVisible(0)
		self.buttonNext.setVisible(1)
		self.buttonPrevious.setVisible(1)
		if useThumbs == True:
			self.listThumb.reset()
			self.buttonNext.controlRight(self.listThumb)
			self.buttonPrevious.controlRight(self.listThumb)
			self.listThumb.controlLeft(self.buttonNext)
			self.listText.setVisible(0)
			self.listThumb.setVisible(1)
			self.setFocus(self.listThumb)
		else:
			self.listText.reset()
			self.buttonNext.controlRight(self.listText)
			self.buttonPrevious.controlRight(self.listText)
			self.listText.controlLeft(self.buttonNext)
			self.listThumb.setVisible(0)
			self.listText.setVisible(1)
			self.setFocus(self.listText)
		
		self.programmaItems = []
		Counter = 0
		
		senderurl = constructURL + sender
		
		progress = xbmcgui.DialogProgress()
		progress.create("TV Today Guide", "Daten werden geladen...")
		
		f = urllib.urlopen(senderurl,urldata, urlheaders)
		data = f.read()
		f.close()
		
		result = re.compile('/tv/programm/bilder/senderlogos/(.*?)".*?>.*?<td.*?bgcolor="#a8a8a8.*?><span.*?>(.*?)</span></td>.*?<td.*?>(.*?)</td>', re.DOTALL or re.DOTALL or re.MULTILINE)
		programmadata = result.findall(data)
		progress.close()
		
		FoundCount = str(len(programmadata))
		
		if len(programmadata) < 12:
			self.nextExists = 0
		else:
			self.nextExists = 1
		
		for item in programmadata:
			tmp = programmaItem(item[0],item[1],item[2],GetKey(item[2]))
			self.programmaItems.append(tmp)

		for m in self.programmaItems:
			titel = CleanName(m.info)
			titel = GetTitel(m.info)
			m.uhrzeit = replace(m.uhrzeit, '<br>', '/') 
			
			if useThumbs == True:
				file_sender = str(m.senderlogo)
				if not os.path.exists(dirHome + 'sender\\' + file_sender):
					self.downloadImg('http://programm.tvtoday.de/tv/programm/bilder/senderlogos/' + str(file_sender), dirHome + 'sender\\' + str(file_sender))
				thumb = senderDir + file_sender
				Sendungseintrag = xbmcgui.ListItem(" " + m.uhrzeit + ' - ' + titel, "", "", thumb)
				self.listThumb.addItem(Sendungseintrag)
			else:
				Sendungseintrag = xbmcgui.ListItem(" " + m.uhrzeit + ' - ' + titel, "", "")
				self.listText.addItem(Sendungseintrag)

	def GetDetails(self, position):
		titel = self.programmaItems[position].info
		titel = CleanName(titel)
		titel = GetTitel(titel)
		dauer = GetDauer(self.programmaItems[position].info)
		laufzeit = dauer[0]
		zeitbis = dauer[1]
		self.buttonNext.setVisible(0)
		self.buttonPrevious.setVisible(0)
		self.listThumb.setVisible(0)

		self.detailSendung.setLabel(str(titel))
		#self.detailUhrzeit.setLabel(self.programmaItems[position].uhrzeit + ' Uhr')
		self.detailUhrzeit.setLabel(self.programmaItems[position].uhrzeit + " - " + zeitbis + ' Uhr')
		self.detailInfo.setText(self.programmaItems[position].key)

		KeyURL = self.programmaItems[position].key
		if KeyURL == '':
			self.detailInfo.setText('keine weiteren Informationen verfügbar')
			#self.detailsenderimage = xbmcgui.ControlImage(550,150,38,24, senderDir + self.programmaItems[position].senderlogo)
			#self.addControl(self.detailsenderimage)
 		else:
 			DetailURL = MainURL + KeyURL
 
 			progress = xbmcgui.DialogProgress()
 			progress.create("TV Movie Guide", "Lade Details...")
 
 			f = urllib.urlopen(DetailURL,urldata, urlheaders)
 			data = f.read()
 			f.close()
 			self.detailInfo.setText(self.GetProgramDetails(data, self.programmaItems[position].senderlogo, dauer))
 			progress.close()

		self.detailSendung.setVisible(1)
		self.detailUhrzeit.setVisible(1)
		self.detailInfo.setVisible(1)
		self.setFocus(self.detailInfo)
			
	def GetProgramDetails(self, data, sndimg, dauer):
		laufzeit = dauer[0]
		zeitbis = dauer[1]
		
		#Detailtabelle ausschließen
		result = re.compile('<table border="0" cellpadding="0" cellspacing="0" width="170">(.*?)</table>', re.DOTALL or re.MULTILINE)
		DetailTableArr = result.findall(data)
		DetailTable = DetailTableArr[0]

		#Dateiltexte ermitteln
		result = re.compile('<span class="text">(.*?)</span>', re.DOTALL or re.MULTILINE)
		SDetailData = result.findall(DetailTable)

		#Detailüberschriften ermitteln
		result = re.compile('<span class="headline">(.*?)</span>', re.DOTALL or re.MULTILINE)
		SDetailHeader = result.findall(DetailTable)	

		#Detailtabelle2 ausschließen
		result = re.compile('<td width="270">(.*?)<form', re.DOTALL or re.MULTILINE)
		DetailTable2Arr = result.findall(data)
		nT2 = len(DetailTable2Arr)
		if nT2 > 0:
			DetailTable2 = DetailTable2Arr[0]
		else:
			DetailTable2 = ''

		#Sendungstitel, Uhrzeit und Bild ermitteln
		result = re.compile('<span class="headline">(.*?)</span>', re.DOTALL or re.MULTILINE)
		SDetailHeader2 = result.findall(DetailTable2)	
		nTH2 = len(SDetailHeader2)
		if nTH2 > 0:
			self.detailSendung.setLabel(RemoveTags(SDetailHeader2[0]))
			result = re.compile('<span class="text-farbe">(.*?)</span>', re.DOTALL or re.MULTILINE)
		DetailUhrzeit = result.findall(DetailTable2)
		nTH2 = len(DetailUhrzeit)
		if nTH2 > 0:
			tmp = RemoveTags(DetailUhrzeit[0])
			tmp = tmp[tmp.find(" Uhr | ")+7:len(tmp)] + " | " + tmp[0:tmp.find(" Uhr | ")] + " - " + zeitbis + " Uhr"
			self.detailUhrzeit.setLabel(tmp)
			result = re.compile('<img src="(.*?)"', re.DOTALL or re.MULTILINE)
		DetailBilder2 = result.findall(DetailTable2)
		nTH2 = len(DetailBilder2)
		if nTH2 > 2:
			SendungsImage = DetailBilder2[1]
		else:
			SendungsImage = ''

		#Dateiltexte2 ermitteln
		result = re.compile('<span class="text">(.*?)</span>', re.DOTALL or re.MULTILINE)
		SDetailData2 = result.findall(DetailTable2)
		nTD2 = len(SDetailData2) 

		#Programmbild ermitteln (2. Spalte in Tabelle)
		result = re.compile('<img src="(.*?)"', re.DOTALL or re.MULTILINE)
		ImageArr = result.findall(DetailTable)
		nImg = len(SDetailData)
		if nImg > 1:
			ImageDetail = ImageArr[1]
		else:
			ImageDetail = ''

		#Programmbild laden und anzeigen
		if ImageDetail != '':
			ImgURL = MainURL + ImageDetail
			Target = cacheDir + 'Sendung.jpg'
			self.downloadImg(ImgURL,Target)
 			if exists(Target):
				# Proportionen des Programmbilds berechnen 
 				try:
 					im = Image.open(Target)
 					imSize=[im.size[0],im.size[1]]
 					f = float(200)/float(imSize[0])
 					w = int(math.ceil(imSize[0]*f))
 					h = int(math.ceil(imSize[1]*f))
					if h > 260:
						f = float(260)/float(imSize[1])
						w = int(math.ceil(imSize[0]*f))
						h = int(math.ceil(imSize[1]*f))
 				except:
 					#print "could not get image size"
 					w = 200
 					h = 140
			self.detailprogrammimage = xbmcgui.ControlImage(80,196,120,120, cacheDir + 'Sendung.jpg')
			self.addControl(self.detailprogrammimage)
			if exists(Target):
				os.remove(Target)

		#Senderbild laden und anzeigen
		#if SendungsImage != '':
		#   ImgURL = MainURL + SendungsImage
		#   Target = cacheDir + 'sender.gif'
		#   self.downloadImg(ImgURL,Target)
		#   self.detailsenderimage = xbmcgui.ControlImage(550,150,40,40, cacheDir + 'sender.gif')
		#   self.addControl(self.detailsenderimage)
		#   if exists(Target):
		#      os.remove(Target)
		#self.detailsenderimage = xbmcgui.ControlImage(550,150,38,24, senderDir + sndimg)
		#self.addControl(self.detailsenderimage)

		#Besonderheiten laden ----------------------------------------------------------------------------
		result = re.compile('<span class="text-mini">(.*?)</span>', re.DOTALL or re.MULTILINE)
		SpecialData = result.findall(data)		  
		nSD = len(SpecialData)

		n = len(SDetailData)
		nH = len(SDetailHeader)

		namename = ''

		if n == 0 and nTD2 == 0: 
			namename="keine weiteren Informationen verfügbar"
		else:
			for i in range(0, n):
				if i <= nH:
					sTemp = replace(SDetailHeader[i], '\n', '')
					namename = namename + str(strip(sTemp)) + ' '
					sTemp = replace(SDetailData[i], '\n', '')
					namename = namename + str(strip(sTemp)) + '\n'
				else:
					sTemp = replace(SDetailData[i], '\n', '')
					namename = namename + '\n' + str(strip(sTemp))
			for i in range(0, nSD):
				sTemp = replace(SpecialData[i], '\n', '')
				sTemp = CleanName(sTemp)
				sTemp = RemoveTags(sTemp)
				namename = namename + ' > ' + str(strip(sTemp)) + '\n'   

			if namename != '':
				namename = namename + '\n'

			for i in range(0, nTD2):
				sTemp = replace(SDetailData2[i], '\n', '')
				sTemp = CleanName(sTemp)
				sTemp = RemoveTags(sTemp)
				namename = namename + str(strip(sTemp)) + '\n'
		return namename
		
	def BackFromDetail(self):
		self.state = 1
		self.buttonNext.setVisible(1)
		self.buttonPrevious.setVisible(1)
		#self.cmdfirst.setVisible(1)
		self.detailSendung.setVisible(0)
		self.detailUhrzeit.setVisible(0)
		self.detailInfo.setVisible(0)
		self.listThumb.setVisible(1)
		self.setFocus(self.listThumb)
		try:
			self.removeControl(self.detailprogrammimage)
		except:
			print 'No Images to Remove'

win = MainWindow()
win.doModal()
del win