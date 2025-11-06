@echo off
ECHO ------------------------------
echo Creating Xbox-Classic Build Folder
rmdir BUILD /S /Q
md BUILD

ECHO ------------------------------
ECHO Creating XPR Files...
CALL media\XBMCTex.bat

ECHO ------------------------------
ECHO Copying XPR Files...
xcopy "media\*.xpr" "BUILD\Xbox-Classic\media\" /Q /I /Y

ECHO ------------------------------
ECHO Cleaning Up...
del "media\*.xpr"

ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "1080i" "BUILD\Xbox-Classic\1080i" /E /Q /I /Y
xcopy "720p" "BUILD\Xbox-Classic\720p" /E /Q /I /Y
xcopy "NTSC" "BUILD\Xbox-Classic\NTSC" /E /Q /I /Y
xcopy "NTSC16x9" "BUILD\Xbox-Classic\NTSC16x9" /E /Q /I /Y
xcopy "PAL" "BUILD\Xbox-Classic\PAL" /E /Q /I /Y
xcopy "PAL16x9" "BUILD\Xbox-Classic\PAL16x9" /E /Q /I /Y
xcopy "colors" "BUILD\Xbox-Classic\colors" /E /Q /I /Y
xcopy "fonts" "BUILD\Xbox-Classic\fonts" /E /Q /I /Y
xcopy "sounds" "BUILD\Xbox-Classic\sounds" /E /Q /I /Y
xcopy "language" "BUILD\Xbox-Classic\language" /E /Q /I /Y
xcopy "*.xml" "BUILD\Xbox-Classic\" /Q /I /Y

copy *.txt "BUILD"

ECHO ------------------------------
ECHO Removing SVN directories from build
FOR /R BUILD %%d IN (.SVN) DO @RD /S /Q "%%d" 2>NUL

echo Build Complete - Scroll Up to check for errors.
echo Final build is located in the BUILD directory
echo ftp the Xbox-Classic folder in the build dir to your xbox
pause
