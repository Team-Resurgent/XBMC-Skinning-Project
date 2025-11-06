@echo off
ECHO ------------------------------
ECHO Creating "xTV" Build Folder
rmdir BUILD /S /Q
md BUILD

ECHO ------------------------------
ECHO Creating XPR Files...
CALL media\XBMCTex.bat

ECHO ------------------------------
ECHO Copying XPR Files...
xcopy "media\*.xpr" "BUILD\xTV\media\" /Q /I /Y

ECHO ------------------------------
ECHO Cleaning Up...
del "media\*.xpr"

ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "1080i" "BUILD\xTV\1080i" /E /Q /I /Y
xcopy "720p" "BUILD\xTV\720p" /E /Q /I /Y
xcopy "extras" "BUILD\xTV\extras" /E /Q /I /Y
xcopy "NTSC" "BUILD\xTV\NTSC" /E /Q /I /Y
xcopy "NTSC16x9" "BUILD\xTV\NTSC16x9" /E /Q /I /Y
xcopy "PAL" "BUILD\xTV\PAL" /E /Q /I /Y
xcopy "PAL16x9" "BUILD\xTV\PAL16x9" /E /Q /I /Y
xcopy "fonts" "BUILD\xTV\fonts" /E /Q /I /Y
xcopy "sounds" "BUILD\xTV\sounds" /E /Q /I /Y
xcopy "colors" "BUILD\xTV\colors" /E /Q /I /Y
xcopy "language" "BUILD\xTV\language" /E /Q /I /Y
xcopy "*.xml" "BUILD\xTV\" /Q /I /Y

ECHO ------------------------------
ECHO Removing SVN directories from build...
FOR /R BUILD %%d IN (.SVN) DO @RD /S /Q "%%d" 2>NUL

ECHO Build Complete - Scroll Up to check for errors.
ECHO Final build is located in the BUILD directory
ECHO Have Fun


pause
