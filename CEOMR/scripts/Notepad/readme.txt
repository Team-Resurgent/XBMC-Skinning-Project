The script contained in this file is designed to allow you to edit simple text files 
on your XBox, without the hassle of an FTP transfer. I have made no improvements to 
the in-game keyboard, nor have I built in any support for USB keyboards (for all I 
know, they might work automatically--I don't have one, so I can't test). The XBox is 
NOT a particularly pleasant environment for editing text, so I don't recommend this 
script for writing the Great American Novel.

However, it will be an excellent resource for changing config file settings, or making 
small adjustments to Python scripts during development (tweaking the exact location of 
that ControlButton, or changing the timeDelay from 10 to 20, for instance).

In order for the script to run properly, "Notepad.py" should be copied to your 
XBMC installation's "/scripts/Notepad/" subfolder, along with the various image files 
that comes packaged with it ("background.png", "white.png", "edit.png", "delete.png", 
and "insert.png"). I've also included GIF versions of all included image files to help 
this script run with the PC Emulator, in case you want to help me with debug issues.

In addition to the Notepad files, you'll need to copy the attached "xWidgets.py" to 
either the "/scripts/Notepad/" folder, or to your XBMC's "/python/Lib/" subfolder. I 
recommend the latter, as I'll be using xWidgets in several future scripts, and 
extending it as well.

In order to use Notepad, simply launch it from the script launcher. Press "A" on your 
controller (or "Select" on the IR Remote) to "Open" a document on your XBox hard drive, 
create a "New" text document there, or "Save" the one you're currently editing (using 
the appropriate button).

In order to edit a new or opened document, press Down from any of the control buttons, 
and an edit cursor will appear to the left of one of the lines. Use the right and left 
triggers to cycle among your editing choices (a red "X" for Delete Line, a black ">" for 
Insert New Line, or a tiny pencil for Edit Line). If you choose to edit an existing line,
the keyboard will pop up, showing you the full contents of the line (including any that 
wouldn't show up on the regular display). Press "Y" to close the keyboard and keep any 
changes.

Notepad is capable of saving multiple steps of Undo (and Redo) to help protect you from 
unwanted changes to your text. The default setting is 10 steps back, but you can easily 
increase this value. (Note that the higher this value, the more likely it becomes that 
Notepad will begin using excessive memory and slowing down your system.) Simply open 
"Notepad.py" and change the value for "UndoSteps" near the top. To Undo one step, press 
"B" on your controller (or "Back" on the IR Remote) while in editing mode. To Redo one 
step, use "Y" on your controller (or "Display" on the IR Remote).

The available scrolling distance is severely limited by XBMC. I'm currently waiting on 
an answer to a feature request which MAY make it possible, in future versions, to scroll 
far enough left that you can view long lines. Currently, you can only shift to the left 
enough to see an additional 10-20 characters, so it's not a huge bonus.

Also...font size should be adjustable. It's very close, but I haven't actually written it 
into the script yet. Expect adjustable font size in the next version. I'd also like to 
write a script more friendly to multiple resolutions (one of my best friends uses my 
scripts on a 1080i HDTV), but I haven't got that working yet. Again, look for it in a 
future version.

In the meantime, consider this script in development, and please give me all your complaints 
and comments! The more feedback I get, the better I can make the script run. There'll be 
a thread devoted to this topic on the XBMC Python scripting forums, and you can also 
email me at the address listed on my website.

Please check back at my website frequently for updates! I'm constantly trying to make these 
things better.

Visit my website: http://members.cox.net/alexpoet/downloads/