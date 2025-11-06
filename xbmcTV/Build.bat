@echo off
ECHO ------------------------------
ECHO Creating "xbmcTV" Build Folder
rmdir BUILD /S /Q
md BUILD
ECHO ------------------------------
ECHO Creating XPR Files...
CALL media\XBMCTex.bat

ECHO ------------------------------
ECHO Copying XPR Files...
xcopy *.xpr "BUILD\xbmcTV\media\" /Q /I /Y

ECHO ------------------------------
ECHO Cleaning Up...
del *.xpr

ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "1080i" "BUILD\xbmcTV\1080i" /E /Q /I /Y
xcopy "720p" "BUILD\xbmcTV\720p" /E /Q /I /Y
xcopy "NTSC" "BUILD\xbmcTV\NTSC" /E /Q /I /Y
xcopy "NTSC16x9" "BUILD\xbmcTV\NTSC16x9" /E /Q /I /Y
xcopy "PAL" "BUILD\xbmcTV\PAL" /E /Q /I /Y
xcopy "PAL16x9" "BUILD\xbmcTV\PAL16x9" /E /Q /I /Y
xcopy "fonts" "BUILD\xbmcTV\fonts" /E /Q /I /Y
xcopy "sounds" "BUILD\xbmcTV\sounds" /E /Q /I /Y
xcopy "colors" "BUILD\xbmcTV\colors" /E /Q /I /Y
xcopy "language" "BUILD\xbmcTV\language" /E /Q /I /Y
xcopy "*.xml" "BUILD\xbmcTV\" /Q /I /Y

ECHO ------------------------------
ECHO Removing SVN directories from build...
FOR /R BUILD %%d IN (SVN) DO @RD /S /Q "%%d" 2>NUL

ECHO Build Complete - Scroll Up to check for errors.
ECHO Final build is located in the BUILD directory
ECHO Have Fun


pause