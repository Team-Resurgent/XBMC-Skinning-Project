import os, xbmcgui

def fileOpen():
	path = ""
	driveList = ["C:", "D:", "E:", "F:", "G:", "Q:", "X:", "Y:", "Z:"]
	driveDlg = xbmcgui.Dialog()
	ndex = driveDlg.select("Find file on which drive?", driveList)
	choice = driveList[ndex]
	path = choice + "\\"

	while True:
		lList = os.listdir(path)
		contents = ["(D) .."]
		for item in lList:
			if os.path.isdir(path + item):
				item = "(D) " + item
				contents.append(item)
			else:
				item = "f   " + item
				contents.append(item)
		contents.sort()
		fileDlg = xbmcgui.Dialog()
		ndex = fileDlg.select("Select a File to Open", contents)
		fileChoice = contents[ndex]
		if fileChoice[:4] == "f   ":
			return path + fileChoice[4:]
		elif fileChoice[:4] == "(D) ":
			path += fileChoice[4:] + "\\"
		else:
			print "FileOpen widget failed. Please report any errors to Alexpoet at script_requests@cox.net"
		lList = []
		contents = []