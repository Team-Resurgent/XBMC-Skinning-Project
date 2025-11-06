@echo off
ECHO ------------------------------
ECHO Creating PDM Build Folder
rmdir BUILD /S /Q
md BUILD

ECHO ------------------------------
ECHO Creating XPR Files...
CALL media\XBMCTex.bat

ECHO ------------------------------
ECHO Copying XPR Files...
xcopy "media\*.xpr" "BUILD\PDM\media\" /Q /I /Y

ECHO ------------------------------
ECHO Cleaning Up...
del "media\*.xpr"

ECHO ------------------------------
ECHO creating Media Directory structure...
md "BUILD\PDM\media\PIC Filemanager"
md "BUILD\PDM\media\PIC Games"
md "BUILD\PDM\media\PIC Movies"
md "BUILD\PDM\media\PIC Music"
md "BUILD\PDM\media\PIC Pictures"
md "BUILD\PDM\media\PIC Scripts"
md "BUILD\PDM\media\PIC Settings"
md "BUILD\PDM\media\PIC Shutdown"
md "BUILD\PDM\media\PIC Weather"
md "BUILD\PDM\media\PIC Xlink"

ECHO ------------------------------
ECHO Choose language :
ECHO   1-English
ECHO   2-Dutch
ECHO   3-Norwegian
ECHO   4-French
SET /p lang=Language:

ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "1080i" "BUILD\PDM\1080i" /E /Q /I /Y
xcopy "720p" "BUILD\PDM\720p" /E /Q /I /Y
xcopy "NTSC" "BUILD\PDM\NTSC" /E /Q /I /Y
xcopy "NTSC16x9" "BUILD\PDM\NTSC16x9" /E /Q /I /Y
xcopy "PAL" "BUILD\PDM\PAL" /E /Q /I /Y
xcopy "PAL16x9" "BUILD\PDM\PAL16x9" /E /Q /I /Y
xcopy "fonts" "BUILD\PDM\fonts" /E /Q /I /Y
xcopy "sounds" "BUILD\PDM\sounds" /E /Q /I /Y
xcopy "*.xml" "BUILD\PDM\" /Q /I /Y
xcopy "*.txt" "BUILD\PDM\extras\changelog" /Q /I /Y
xcopy "extras\language" "BUILD\PDM\extras\language" /E /Q /I /Y
xcopy "extras\backgrounds" "BUILD\PDM\media\Default" /E /Q /I /Y
xcopy "extras\changelog" "BUILD\PDM\extras\changelog" /E /Q /I /Y

IF %lang%==2 xcopy "extras\language\Dutch\*.xml" "BUILD\PDM\PAL" /E /Q /I /Y
IF %lang%==3 xcopy "extras\language\Norwegian\*.xml" "BUILD\PDM\PAL" /E /Q /I /Y
IF %lang%==4 xcopy "extras\language\French\*.xml" "BUILD\PDM\PAL" /E /Q /I /Y

ECHO ------------------------------
ECHO Removing SVN directories from build
FOR /R BUILD %%d IN (.SVN) DO @RD /S /Q "%%d" 2>NUL

ECHO Build Complete - Scroll Up to check for errors.
ECHO Final build is located in the BUILD directory
ECHO ftp the PDM folder in the build dir to your xbox
pause
