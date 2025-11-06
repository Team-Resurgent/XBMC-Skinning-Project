import os, xbmc, xbmcgui, xWidgets
from os.path import join, getsize
try: Emulating = xbmcgui.Emulating
except: Emulating = False

ACTION_UNKNOWN = 0			#'Y', black
ACTION_MOVE_LEFT = 1		#Dpad Left
ACTION_MOVE_RIGHT = 2		#Dpad Right
ACTION_MOVE_UP = 3			#Dpad Up
ACTION_MOVE_DOWN = 4		#Dpad Down
ACTION_SKIP_NEXT = 5 		#Left trigger
ACTION_SKIP_PREVIOUS = 6 	#Right trigger
ACTION_SELECT = 7			#'A'
ACTION_BACK = 9				#'B'
ACTION_MENU = 10			#'Back'
ACTION_STOP = 13			#'Start'
ACTION_DISPLAY = 18			#'X'

Close	= [630, 30, 30, 30]		# Close Button
Help	= [630, 75, 30, 30]		# Help Button
New	= [273, 70, 55, 37]		# New Button
Open	= [333, 70, 55, 37]		# Open Button
Save	= [393, 70, 55, 37]		# Save Button
#Edit	= []
#Read	= []

FirstRow = 130				# Y coordinate of first label
FirstColumn = 75			# X coordinate of first label
ScrollDist = 15				# Number of pixels that text shifts on left/right scroll
DistBetween12 = 20			# Screen height (in pixels) of a line at font12
DistBetween14 = 25			# Screen height (in pixels) of a line at font14
DistBetween18 = 35			# Screen height (in pixels) of a line at font18
UndoSteps = 10				# Maximum distance back you can Undo. Higher numbers increase memory usage.

RootDir = "Q:\\scripts\\notepad\\"	# Add the folder name of your script to the end of RootDir (i.e. "Q:\\scripts\\XMovieGuide\\")

READ_MODE = 1
EDIT_MODE = 2

class MyClass(xbmcgui.Window):
	def __init__(self):
		if Emulating: xbmcgui.Window.__init__(self)

        	self.setCoordinateResolution(6)


		# Begin setting up the GUI
		# Add a white backdrop.
		self.addControl(xbmcgui.ControlImage(0,0,0,0, "background.png"))
		self.pic = xbmcgui.ControlImage(0,0,0,0, RootDir + "white.png")
		self.addControl(self.pic)
		# THEN add ALL necessary Editbox Labels
		self.addLines()
		# THEN add the "background" image as an overlay.
		self.pic = xbmcgui.ControlImage(0,0,0,0, RootDir + "background.png")
		self.addControl(self.pic)
                self.addControl(xbmcgui.ControlImage(63, 46, 133, 60,'logo_notepad.png'))
                self.addControl(xbmcgui.ControlImage(585, 33, 90, 90,'DefaultScriptBig.png'))
		# THEN add any user-interactable buttons.
		self.newButton = xbmcgui.ControlButton(New[0], New[1], New[2], New[3], "New")
		self.addControl(self.newButton)
		self.openButton = xbmcgui.ControlButton(Open[0], Open[1], Open[2], Open[3], "Open")
		self.addControl(self.openButton)
		self.saveButton = xbmcgui.ControlButton(Save[0], Save[1], Save[2], Save[3], "Save")
		self.addControl(self.saveButton)
#		self.addLines() #-

		self.newButton.controlLeft(self.saveButton)
		self.newButton.controlRight(self.openButton)
		self.openButton.controlLeft(self.newButton)
		self.openButton.controlRight(self.saveButton)
		self.saveButton.controlLeft(self.openButton)
		self.saveButton.controlRight(self.newButton)

		# Set up class variables:
		self.filename = ""				# Added in self.openFile()
		self.inMenu = True				# Changed when onAction == ACTION_DOWN
		self.cursorpositions = []		# Added in self.changeFont()
		self.cursorPic = None			# Will be one of three images, added in self.drawCursor()
		self.undos = [[]]				# Added in self.newFile()
		self.redos = [[]]				# Added in self.newFile()
		self.activeList = []			# One of the lists of Font labels, set in self.changeFont()
		self.changeFont(self.linesat14)	# This creates the Initial (default) font
		self.newFile()					# Clears the screen at bottom, and initializes display
		self.setFocus(self.openButton)	# Prepare user to open a new file.
		
	## onAction works differently depending whether you're moving among the 
	## menu buttons at the top of the screen (self.inMenu == True) or moving 
	## around in an open document below (self.inMenu == False)
	def onAction(self, action):
		if action == ACTION_STOP:
			self.changeSettings()
		elif self.inMenu:
			if action == ACTION_MENU:
				# Quit the script
				self.shutdown()
			elif action == ACTION_MOVE_DOWN:
				# Begin editing the document below.
				self.inMenu = False
				self.drawCursor()
				self.setFocus(self.activeList[0])
		else:
			# If you're already editing the document...
			if action == ACTION_MENU:
				# Quit editing the document and return to menu.
				self.inMenu = True
				if self.cursorPic:
					self.removeControl(self.cursorPic)
				self.setFocus(self.openButton)
			# These four scroll the document view
			elif action == ACTION_MOVE_LEFT:	self.moveLeft()
			elif action == ACTION_MOVE_RIGHT:	self.moveRight()
			elif action == ACTION_MOVE_UP:		self.moveUp()
			elif action == ACTION_MOVE_DOWN:	self.moveDown()
			# changeList modifies the selected line depending on your cursor type
			elif action == ACTION_SELECT:		self.changeList()
			elif action == ACTION_BACK:			self.undo()			# undo one step of line changes
			elif action == ACTION_DISPLAY:		self.redo()			# redo one step of line changes
			# Left and right trigger cycle among the three cursor types
			elif action == ACTION_SKIP_NEXT:
				if self.cursorType == "Edit": 		self.cursorType = "Delete"
				elif self.cursorType == "Delete": 	self.cursorType = "Insert"
				elif self.cursorType == "Insert": 	self.cursorType = "Edit"
				self.drawCursor()
			elif action == ACTION_SKIP_PREVIOUS:
				if self.cursorType == "Edit": 		self.cursorType = "Insert"
				elif self.cursorType == "Insert": 	self.cursorType = "Delete"
				elif self.cursorType == "Delete": 	self.cursorType = "Edit"
				self.drawCursor()

	def onControl(self, control):
		# One function per button, fairly self-explanatory
		if control == self.newButton:	self.newFile()
		if control == self.openButton:	self.openFile()
		if control == self.saveButton:	self.saveFile()

	##############################################################################
	##	The following functions are all onAction Functions (and subfunctions	##
	##	of onAction functions).													##
	##############################################################################
	
	def changeSettings(self):
		Choices = {	"Switch to Read Mode": self.noChange,	# Currently unused 
					"Add Text to Calendar": self.noChange, 	# Currently unused
					"(No Change)": self.noChange}
		choiceList = ["Switch to Read Mode", "Add Text to Calendar", "(No Change)"]
		if not self.activeList == self.linesat18:
			Choices["Change Font: Larger"] = self.fontUp
			choiceList.insert(0, "Change Font: Larger")
		if not self.activeList == self.linesat12:
			Choices["Change Font: Smaller"] = self.fontDown
			choiceList.insert(0, "Change Font: Smaller")
		dlg = xbmcgui.Dialog()
		ndex = dlg.select("Modify Settings", choiceList)
		choice = Choices[choiceList[ndex]]
		choice()

	def fontUp(self):
		if self.activeList == self.linesat12:
			self.changeFont(self.linesat14)
		elif self.activeList == self.linesat14:
			self.changeFont(self.linesat18)
		self.writeLines()

	def fontDown(self):
		if self.activeList == self.linesat18:
			self.changeFont(self.linesat14)
		elif self.activeList == self.linesat14:
			self.changeFont(self.linesat12)
		self.writeLines()
	
	def noChange(self): pass

	## To scroll left/right, I hide part of the labels behind a partly-transparent
	## "background" image. Left and right slides the labels along, the display box 
	## automatically clips them for me.
	def moveLeft(self):
		if self.fileLines:
			## I can only scroll left as far as the 0 x-coordinate on the display (offsetX == 
			## -75), so this checks to see if scrolling will still be on-screen and, if so,
			## scrolls left.
			if self.offsetX + ScrollDist < 75:
				self.offsetX += ScrollDist
			for i in range(len(self.activeList)):
				self.activeList[i].setPosition(FirstColumn - self.offsetX, FirstRow + (i * self.spacer))
		
	def moveRight(self):
		if self.fileLines:
			## This scrolls right until all lines are flush with the left edges of the 
			## display box (offsetX == 0).
			if self.offsetX - ScrollDist >= 0:
				self.offsetX -= ScrollDist
			else:
				self.offsetX = 0
			for i in range(len(self.activeList)):
				self.activeList[i].setPosition(FirstColumn - self.offsetX, FirstRow + (i * self.spacer))
		
	## To scroll up/down, I have a single set of labels that fills the display box from 
	## top to bottom, and fill each of them with a line out of the fileLines list. onUp 
	## or onDown, I use offsetY to choose which lines out of the list get displayed.
	def moveUp(self):
		if self.fileLines:
			if self.position > 0:
				self.position -= 1
				self.drawCursor()
			else:
				if self.offsetY > 0:
					self.offsetY -= 1
				else:
					self.offsetY = 0
			self.writeLines()

	def moveDown(self):
		if self.fileLines:
			if self.position < len(self.activeList) - 1 and self.position < len(self.fileLines) - 1:
				self.position += 1
				self.drawCursor()
			elif self.cursorType == "Insert" and (self.position < len(self.activeList) and 
													self.position < len(self.fileLines)):
				self.position += 1
				self.drawCursor()
			elif self.offsetY < len(self.fileLines) - len(self.activeList):
				self.offsetY += 1
			self.writeLines()
		
	def changeList(self):
		if self.cursorType == "Delete":
			newLines = [item for item in self.fileLines]
			if newLines:
				newLines.remove(newLines[self.position + self.offsetY])
				if newLines and self.position >= len(newLines): 
					self.position -= 1
				if self.offsetY: self.offsetY -= 1
				self.do(newLines)
		elif self.cursorType == "Insert": 
			newLines = [item for item in self.fileLines]
			keyboard = xbmc.Keyboard()
			keyboard.doModal()
			if keyboard.isConfirmed():
				newLine = keyboard.getText()
				newLines.insert(self.position + self.offsetY, newLine)
				if self.position < len(self.activeList): self.position += 1
				elif self.offsetY <= len(self.fileLines) - len(self.activeList): self.offsetY += 1
				self.do(newLines)
		else: # self.cursorType == "Edit": 
			newLines = [item for item in self.fileLines]
			keyboard = xbmc.Keyboard(newLines[self.position + self.offsetY])
			keyboard.doModal()
			if keyboard.isConfirmed():
				newLine = keyboard.getText()
				newLines[self.position + self.offsetY] = newLine
				self.do(newLines)

	def do(self, newLines):
		for i in range(UndoSteps):
			i = (UndoSteps - 1) - i
			if i > 0:
				self.undos[i] = self.undos[i-1]
			else:
				self.undos[i] = self.fileLines
		self.fileLines = newLines
		for i in range(UndoSteps - 1):
			self.redos[i] = []
		self.writeLines()
		self.drawCursor()
	
	def undo(self):
		if self.undos[0]:
			for i in range(UndoSteps - 1):
				i = (UndoSteps - 2) - i
				if i > 0:
					self.redos[i] = self.redos[i-1]
				else:
					self.redos[i] = self.fileLines
			self.fileLines = self.undos[0]
			for i in range(UndoSteps):
				if i < (UndoSteps - 1):
					self.undos[i] = self.undos[i + 1]
				else:
					self.undos[i] = []
			self.writeLines()
	
	def redo(self):
		if self.redos[0]:
			for i in range(UndoSteps):
				i = (UndoSteps - 1) - i
				if i > 0:
					self.undos[i] = self.undos[i-1]
				else:
					self.undos[i] = self.fileLines
			self.fileLines = self.redos[0]
			for i in range(UndoSteps - 1):
				if i < (UndoSteps - 2):
					self.redos[i] = self.redos[i + 1]
				else:
					self.redos[i] = []
			self.writeLines()

	##############################################################################
	##	The following functions are all onControl Functions (and subfunctions	##
	##	of onControl functions).												##
	##############################################################################
	def newFile(self):
		if self.undos[0]:
			dlg = xbmcgui.Dialog()
			if dlg.yesno("Warning!", "Save changes to current document?"):
				self.saveFile()

		self.fileLines = [""]
		for i in range(UndoSteps):
			try: self.undos[i] = []
			except: self.undos.append([])
		for i in range(UndoSteps - 1):
			try: self.redos[i] = []
			except: self.redos.append([])
#		self.mode = READ_MODE

		self.cursorType = "Edit"
		self.position = 0
		if not self.inMenu: self.drawCursor()

		self.offsetX = 0
		self.offsetY = 0

		self.writeLines()

	def openFile(self):
		self.newFile()
		self.filename = xWidgets.fileOpen()
		textFile = file(self.filename, "r")
		self.fileLines = textFile.readlines()
		textFile.close()
		textFile = None
		newlist = []
		for item in self.fileLines:
			if item[-1] == "\n": item = item[:-1]
#			item.replace("\t", "    ")
			newlist.append(item)
		self.fileLines = newlist
		self.writeLines()

	def saveFile(self):
		dir = RootDir
		if self.filename:
			dir = os.path.split(self.filename)[0] + "\\"
			choices = ["Save to Current File", "Save with New Name"]
			dlg = xbmcgui.Dialog()
			ndex = dlg.select("Save Changes:", choices)
			if ndex == 0:
				SaveChanges(self.filename, self.fileLines)
				for i in range(UndoSteps):
					try: self.undos[i] = []
					except: self.undos.append([])
				for i in range(UndoSteps - 1):
					try: self.redos[i] = []
					except: self.redos.append([])
				return
			else:
				pass
		keyboard = xbmc.Keyboard(os.path.split(self.filename)[1])
		keyboard.doModal()
		if keyboard.isConfirmed():
			name = keyboard.getText()
			SaveChanges(dir + name, self.fileLines)
			for i in range(UndoSteps):
				try: self.undos[i] = []
				except: self.undos.append([])
			for i in range(UndoSteps - 1):
				try: self.redos[i] = []
				except: self.redos.append([])

	##############################################################################
	##	The following functions are all used for GUI setup. Once written,		##
	##	these functions shouldn't need much changing.							##
	##############################################################################
	def addLines(self):
		# 14 lines at 12 point font
		self.linesat12 = []
		for i in range(14):
			line = xbmcgui.ControlLabel(FirstColumn, FirstRow + (i * DistBetween12), 720, DistBetween12, "", "font12", "0xFF000000")
			self.linesat12.append(line)
			self.addControl(line)
			line.setVisible(False)
		self.cursorsat12 = []
		for i in range(15):
			cursor = (60, FirstRow + 5 + (i * DistBetween12), 10, 10)
			self.cursorsat12.append(cursor)

		# 12 lines at 14 point font
		self.linesat14 = []
		for i in range(12):
			line = xbmcgui.ControlLabel(FirstColumn, FirstRow + (i * DistBetween14), 720, DistBetween14, "", "font14", "0xFF000000")
			self.linesat14.append(line)
			self.addControl(line)
			line.setVisible(False)
		self.cursorsat14 = []
		for i in range(13):
			cursor = (60, FirstRow + 7 + (i * DistBetween14), 10, 10)
			self.cursorsat14.append(cursor)

		# 9 lines at 18 point font
		self.linesat18 = []
		for i in range(9):
			line = xbmcgui.ControlLabel(FirstColumn, FirstRow + (i * DistBetween18), 720, DistBetween18, "", "font18", "0xFF000000")
			self.linesat18.append(line)
			self.addControl(line)
			line.setVisible(False)
		self.cursorsat18 = []
		for i in range(10):
			cursor = (60, FirstRow + 10 + (i * DistBetween18), 10, 10)
			self.cursorsat18.append(cursor)

	##############################################################################
	##	The following functions are all used to change the GUI's appearance.	##
	##############################################################################
	def writeLines(self):
		available = len(self.activeList)
		total = len(self.fileLines)
		for item in self.activeList:
			item.setLabel("")
		if total and total <= available:
			for i in range(total):
				self.activeList[i].setLabel(self.fileLines[self.offsetY + i])
		elif total:
			for i in range(available):
				self.activeList[i].setLabel(self.fileLines[self.offsetY + i])
				
	def changeFont(self, newFontList):
		if self.activeList:
			for item in self.activeList:
				item.setVisible(False)
			self.cursorpositions = []
		self.activeList = newFontList
		for item in self.activeList:
			item.setVisible(True)
		if self.activeList == self.linesat12:
			self.spacer = DistBetween12
			self.cursors = [item for item in self.cursorsat12]
		elif self.activeList == self.linesat14:
			self.spacer = DistBetween14
			self.cursorpositions = [item for item in self.cursorsat14]
		elif self.activeList == self.linesat18:
			self.spacer = DistBetween18
			self.cursorpositions = [item for item in self.cursorsat18]
			
	def drawCursor(self):
		c = self.cursorpositions[self.position]
		if self.cursorPic:
			self.removeControl(self.cursorPic)
		if self.cursorType == "Delete":
			self.cursorPic = xbmcgui.ControlImage(c[0], c[1], c[2], c[3], RootDir + "delete.png")
		elif self.cursorType == "Insert": 
			self.cursorPic = xbmcgui.ControlImage(c[0], c[1] - int(self.spacer / 2), c[2], c[3], RootDir + "insert.png")
		else: # self.cursorType == "Edit": 
			self.cursorPic = xbmcgui.ControlImage(c[0], c[1], c[2], c[3], RootDir + "edit.png")
		self.addControl(self.cursorPic)
		
	def shutdown(self):
		# The program terminator: Saves changes to the open text file, then exits.
		if self.undos[0]:
			dlg = xbmcgui.Dialog()
			if dlg.yesno("Warning!", "Save changes to current document?"):
				self.saveFile()
		self.close()
		
def SaveChanges(filename, lines):
	target = file(filename, "w")
	newlist = []
	for item in lines:
		item += "\n"
#		item.replace("    ", "\t")
		newlist.append(item)
	target.writelines(newlist)
	target.close()
	target = None

win = MyClass()
win.doModal()
del win