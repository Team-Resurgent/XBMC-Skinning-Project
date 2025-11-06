@echo off
ECHO ------------------------------
ECHO Creating "Containment" Build Folder
rmdir BUILD /S /Q
md BUILD
ECHO ------------------------------
ECHO Creating XPR Files...
CALL media\XBMCTex.bat

ECHO ------------------------------
ECHO Copying XPR Files...
xcopy *.xpr "BUILD\Containment\media\" /Q /I /Y

ECHO ------------------------------
ECHO Cleaning Up...
del *.xpr

ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "1080i" "BUILD\Containment\1080i" /E /Q /I /Y
xcopy "720p" "BUILD\Containment\720p" /E /Q /I /Y
xcopy "extras" "BUILD\Containment\extras" /E /Q /I /Y
xcopy "NTSC" "BUILD\Containment\NTSC" /E /Q /I /Y
xcopy "NTSC16x9" "BUILD\Containment\NTSC16x9" /E /Q /I /Y
xcopy "PAL" "BUILD\Containment\PAL" /E /Q /I /Y
xcopy "PAL16x9" "BUILD\Containment\PAL16x9" /E /Q /I /Y
xcopy "fonts" "BUILD\Containment\fonts" /E /Q /I /Y
xcopy "sounds" "BUILD\Containment\sounds" /E /Q /I /Y
xcopy "colors" "BUILD\Containment\colors" /E /Q /I /Y
xcopy "language" "BUILD\Containment\language" /E /Q /I /Y
xcopy "*.xml" "BUILD\Containment\" /Q /I /Y

ECHO ------------------------------
ECHO Removing SVN directories from build...
FOR /R BUILD %%d IN (.SVN) DO @RD /S /Q "%%d" 2>NUL

ECHO Build Complete - Scroll Up to check for errors.
ECHO Final build is located in the BUILD directory
ECHO Have Fun


pause
