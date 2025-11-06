@echo off
ECHO ------------------------------
ECHO Creating "The Orbs" Build Folder
rmdir BUILD /S /Q
md BUILD
ECHO ------------------------------
ECHO Creating XPR Files...
CALL media\XBMCTex.bat

ECHO ------------------------------
ECHO Copying XPR Files...
xcopy *.xpr "BUILD\The Orbs\media\" /Q /I /Y

ECHO ------------------------------
ECHO Cleaning Up...
del *.xpr

ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "1080i" "BUILD\The Orbs\1080i" /E /Q /I /Y
xcopy "720p" "BUILD\The Orbs\720p" /E /Q /I /Y
xcopy "NTSC" "BUILD\The Orbs\NTSC" /E /Q /I /Y
xcopy "NTSC16x9" "BUILD\The Orbs\NTSC16x9" /E /Q /I /Y
xcopy "PAL" "BUILD\The Orbs\PAL" /E /Q /I /Y
xcopy "PAL16x9" "BUILD\The Orbs\PAL16x9" /E /Q /I /Y
xcopy "fonts" "BUILD\The Orbs\fonts" /E /Q /I /Y
xcopy "sounds" "BUILD\The Orbs\sounds" /E /Q /I /Y
xcopy "colors" "BUILD\The Orbs\colors" /E /Q /I /Y
xcopy "language" "BUILD\The Orbs\language" /E /Q /I /Y
xcopy "*.xml" "BUILD\The Orbs\" /Q /I /Y

ECHO ------------------------------
ECHO Removing SVN directories from build...
FOR /R BUILD %%d IN (.SVN) DO @RD /S /Q "%%d" 2>NUL

ECHO Build Complete - Scroll Up to check for errors.
ECHO Final build is located in the BUILD directory
ECHO All credit for this skin goes to Kotix


pause
