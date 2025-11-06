@echo off
ECHO ------------------------------
ECHO Creating "Xii" Build Folder
rmdir BUILD /S /Q
md BUILD

ECHO ------------------------------
ECHO Creating XPR Files...
CALL XBMCTex.bat

ECHO ------------------------------
ECHO Copying XPR Files...
xcopy "media\*.xpr" "BUILD\Xii-build\media\" /Q /I /Y

ECHO ------------------------------
ECHO Cleaning Up...
del "media\*.xpr"

ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "1080i" "BUILD\Xii-build\1080i" /E /Q /I /Y
xcopy "720p" "BUILD\Xii-build\720p" /E /Q /I /Y
xcopy "extras" "BUILD\Xii-build\extras" /E /Q /I /Y
xcopy "NTSC" "BUILD\Xii-build\NTSC" /E /Q /I /Y
xcopy "NTSC16x9" "BUILD\Xii-build\NTSC16x9" /E /Q /I /Y
xcopy "PAL" "BUILD\Xii-build\PAL" /E /Q /I /Y
xcopy "PAL16x9" "BUILD\Xii-build\PAL16x9" /E /Q /I /Y
xcopy "fonts" "BUILD\Xii-build\fonts" /E /Q /I /Y
xcopy "sounds" "BUILD\Xii-build\sounds" /E /Q /I /Y
xcopy "*.xml" "BUILD\Xii-build\" /Q /I /Y
xcopy "*.txt" "BUILD\Xii-build\" /Q /I /Y
xcopy "Extra Stuff" "BUILD\Extra Stuff" /E /Q /I /Y

ECHO ------------------------------
ECHO Removing SVN directories from build...
FOR /R BUILD %%d IN (.SVN) DO @RD /S /Q "%%d" 2>NUL

ECHO Build Complete - Scroll Up to check for errors.
ECHO Final build is located in the BUILD directory
ECHO Have Fun


pause
