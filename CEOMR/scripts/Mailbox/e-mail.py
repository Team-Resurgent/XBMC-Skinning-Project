###################################################################
#
#   xbmcmail v0.3
#   by burriko
#   A pop3 email client for xbmc
#
#   Edit the following variables to reflect your settings
#
###################################################################

SERVER = 'Posteingangserver'
USER = 'Benutzername'
PASS = 'Kennwort'
TEMPFOLDER = 'X:\\'  #note: needs to end with \\

###################################################################

import poplib, sys, email, xbmcgui, xbmc, string, time, mimetypes, re, os

from os.path import join, getsize

class xbmcmail(xbmcgui.Window):
    def __init__(self):

        self.setCoordinateResolution(6)
       
        self.fullscreen = False
        self.showingimage = False

        self.addControl(xbmcgui.ControlImage(0,0,720,576, 'background.png'))
        self.addControl(xbmcgui.ControlImage(585, 33, 90, 90,'DefaultScriptBig.png'))
        self.fsoverlay = xbmcgui.ControlImage(0,0,720,576, 'background.png')
        self.repanel = xbmcgui.ControlImage(63,46,133,60, 'panel-email.png')
        self.cmButton = xbmcgui.ControlButton(60, 120, 145, 32, "Abrufen..")
        self.fsButton = xbmcgui.ControlButton(60, 157, 145, 32, "Vollbild")
        self.vaButton = xbmcgui.ControlButton(60, 194, 145, 32, "Anhaenge")
        self.listControl = xbmcgui.ControlList(211, 121, 404, 200, 'font04')
        self.attachlist = xbmcgui.ControlList(211, 340, 404, 200, 'font04')
        self.msgbody = xbmcgui.ControlTextBox(221, 340, 414, 210, 'font10')
        self.fsmsgbody = xbmcgui.ControlTextBox(80, 50, 550, 500, 'font10')

        self.addControl(self.repanel)
        
        self.cmButton.setLabel("Abrufen..", "font04")
        self.fsButton.setLabel("Vollbild", "font04", "60ffffff")
        self.vaButton.setLabel("Anhaenge", "font04", "60ffffff")
        
        self.addControl(self.cmButton)
        self.addControl(self.fsButton)
        self.addControl(self.vaButton)
        
        self.addControl(self.listControl)
        self.addControl(self.attachlist)
        self.attachlist.setVisible(False)
        self.addControl(self.msgbody)

        #define control navigation
        self.attachlist.controlLeft(self.vaButton)
        self.listControl.controlLeft(self.cmButton)
        self.listControl.controlRight(self.cmButton)
        self.msgbody.controlUp(self.listControl)
        self.msgbody.controlLeft(self.fsButton)
        self.cmButton.controlRight(self.listControl)
        self.fsButton.controlUp(self.cmButton)
        self.fsButton.controlRight(self.msgbody)
        self.vaButton.controlUp(self.fsButton)
        self.setFocus(self.listControl)
        self.show()

    def checkEmail(self):
        dialog = xbmcgui.DialogProgress()
        dialog.create("Posteingang","Verbindungsaufbau...")
        try:
            mail = poplib.POP3(SERVER)
            mail.user(USER)
            mail.pass_(PASS)
            numEmails = mail.stat()[0]

            print "Es wurden ", numEmails, " neue Nachrichten empfangen"
            dialog.close()
            dialog.create("Posteingang","Es wurden " + str(numEmails) + " neue Nachrichten empfangen")
            if numEmails==0:
                mail.quit()
                time.sleep(2)
                dialog.close()
                self.setFocus(self.cmButton)
                self.listControl.reset()
            else:
                self.emails = []
                for i in range(1, numEmails+1):
                    dialog.update((i*100)/numEmails)
                    mailMsg = mail.retr(i)[1]
                    tempStr = ''
                    for line in mailMsg:
                        if line == '':
                            line = ' '
                        tempStr = tempStr + line + '\n'
                    self.emails.append(email.message_from_string(tempStr))
                mail.quit()
                dialog.close()

                self.listControl.reset()
                for i in range(numEmails):
                    self.listControl.addItem(self.emails[i].get('subject') + " von " + self.emails[i].get('from'))
        except:
            dialog.close()
            dialog.create("Posteingang","Es konnte keine Verbindung hergestellt werden.")
            time.sleep(2)
            dialog.close()
            self.setFocus(self.cmButton)

    def processEmail(self, selected):
        self.fsButton.controlRight(self.msgbody)
        self.vaButton.controlRight(self.msgbody)
        self.msgbody.setVisible(True)
        self.attachlist.setVisible(False)
        self.attachments = []
        if self.emails[selected].is_multipart():
            for part in self.emails[selected].walk():
                if part.get_content_type() != "text/plain" and part.get_content_type() != "text/html" and part.get_content_type() != "multipart/mixed" and part.get_content_type() != "multipart/alternative":
                    filename = part.get_filename()
                    if not filename:
                        ext = mimetypes.guess_extension(part.get_type())
                        if not ext:
                            # Use a generic extension
                            ext = '.bin'
                        filename = 'temp' + ext
                    try:
                        f=open(TEMPFOLDER + filename, "wb")
                        f.write(part.get_payload(decode=1))
                        f.close()
                    except:
                        print "Probleme mit Anhang " + filename
                    self.attachments.append(filename)
        
        if len(self.attachments)==0:
            # disable the attachments button
            self.vaButton.setLabel("Anhaenge", "font04", "60ffffff")
            self.fsButton.controlDown(self.fsButton)
        else:
            # enable the attachments button
            self.vaButton.setLabel("Anhaenge", "font04", "ffffffff")
            self.fsButton.controlDown(self.vaButton)
        self.printEmail(selected)

    def printEmail(self, selected):
        self.msgText = ""
        if self.emails[selected].is_multipart():
            for part in self.emails[selected].walk():
                if part.get_content_type() == "text/plain":
                    print part.get_payload()
                    self.msgText = part.get_payload()
                    break
        else:
            if self.emails[selected].get_content_type() == "text/html":
                # email in html only, so strip html tags
                text = re.sub('<STYLE.*?>', '<!--', self.emails[selected].get_payload())
                text = re.sub('<SCRIPT.*?>', '<!--', text)
                text = re.sub('<style.*?>', '<!--', text)
                text = re.sub('<script.*?>', '<!--', text)
                text = re.sub('</STYLE>', '-->', text)
                text = re.sub('</SCRIPT>', '-->', text)
                text = re.sub('</style>', '-->', text)
                text = re.sub('</script>', '-->', text)
                text = re.sub('(?s)<!--.*?-->', '', text)
                text = re.sub('(?s)<.*?>', ' ', text)
                text = re.sub('&nbsp;', ' ', text)
                self.msgText = text
            else:
                self.msgText = self.emails[selected].get_payload()
                print self.msgText
        self.msgbody.setText(self.msgText)
        self.setFocus(self.msgbody)

    def showAttachments(self):
        self.fsButton.controlRight(self.attachlist)
        self.vaButton.controlRight(self.attachlist)
        self.msgbody.setVisible(False)
        self.attachlist.setVisible(True)
        self.attachlist.reset()
        for attachment in self.attachments:
            self.attachlist.addItem(attachment)

    def ShowImage(self, filename):
        self.img = xbmcgui.ControlImage(50,40,0,0, TEMPFOLDER + filename)
        self.addControl(self.img)
        self.showingimage = True

    def PlayMedia(self, filename):
        print "Wiedergabe von " + filename
        xbmc.Player().play(TEMPFOLDER + filename)

    def goFullscreen(self):       
        self.addControl(self.fsoverlay)
        self.addControl(self.fsmsgbody)
        self.fsmsgbody.setText(self.msgText)
        self.setFocus(self.fsmsgbody)
        self.fullscreen = True

    def undoFullscreen(self):
        self.fullscreen = False
        self.removeControl(self.fsmsgbody)
        self.removeControl(self.fsoverlay)
        self.setFocus(self.listControl)

    def onAction(self, action):
        if action == 10:
            if self.fullscreen:
                self.undoFullscreen()
            elif self.showingimage:
                self.removeControl(self.img)
                self.showingimage = False
            else:
                self.close()
            
    def onControl(self, control):
        if control == self.cmButton:
            self.checkEmail()
        elif control == self.listControl:
            self.fsButton.setLabel("Vollbild", "font04", "ffffffff")
            self.cmButton.controlDown(self.fsButton)
            self.processEmail(self.listControl.getSelectedPosition())
        elif control == self.fsButton:
            self.goFullscreen()
        elif control == self.vaButton:
            self.showAttachments()
        elif control == self.attachlist:
            selected = self.attachlist.getSelectedPosition()
            filetype = string.split(self.attachments[selected], '.').pop()
            print filetype
            if filetype=="jpg" or filetype=="jpeg" or filetype=="gif" or filetype=="png" or filetype=="bmp":
                self.ShowImage(self.attachments[selected])
            else:
                self.PlayMedia(self.attachments[selected])

if os.access(TEMPFOLDER, os.F_OK)==0: #if folder doesn't exist
    print "Temporerer Ordner wird erstellt."
    try:
        os.mkdir(TEMPFOLDER)
    except:
        print "Fehler beim Ordnererstellen, XBMC Root Ordner wird verwendet"
        TEMPFOLDER = "Z:\\"

m = xbmcmail()
m.checkEmail()
m.doModal()
del m
