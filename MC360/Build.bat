@echo off
ECHO ------------------------------
ECHO Creating "MC360" Build Folder
rmdir BUILD /S /Q
md BUILD

ECHO ------------------------------
ECHO Creating XPR Files...
CALL media\XBMCTex.bat

ECHO ------------------------------
ECHO Copying XPR Files...
xcopy "media\*.xpr" "BUILD\MC360\media\" /Q /I /Y

ECHO ------------------------------
ECHO Cleaning Up...
del "media\*.xpr"

ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "1080i" "BUILD\MC360\1080i" /E /Q /I /Y
xcopy "720p" "BUILD\MC360\720p" /E /Q /I /Y
xcopy "colors" "BUILD\MC360\colors" /E /Q /I /Y
xcopy "extras" "BUILD\MC360\extras" /E /Q /I /Y
xcopy "NTSC" "BUILD\MC360\NTSC" /E /Q /I /Y
xcopy "NTSC16x9" "BUILD\MC360\NTSC16x9" /E /Q /I /Y
xcopy "PAL" "BUILD\MC360\PAL" /E /Q /I /Y
xcopy "PAL16x9" "BUILD\MC360\PAL16x9" /E /Q /I /Y
xcopy "fonts" "BUILD\MC360\fonts" /E /Q /I /Y
xcopy "sounds" "BUILD\MC360\sounds" /E /Q /I /Y
xcopy "language" "BUILD\MC360\language" /E /Q /I /Y
xcopy "*.xml" "BUILD\MC360\" /Q /I /Y
xcopy "*.txt" "BUILD\" /Q /I /Y

ECHO ------------------------------
ECHO Removing SVN directories from build...
FOR /R BUILD %%d IN (.SVN) DO @RD /S /Q "%%d" 2>NUL

echo Build Complete - Scroll Up to check for errors.
echo ---
echo Thank You for shopping with Team Blackbolt!

pause
