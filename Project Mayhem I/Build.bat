@echo off
ECHO ------------------------------
echo Creating Project Mayhem I Build Folder
rmdir BUILD /S /Q
md BUILD

ECHO ------------------------------
ECHO Creating XPR Files...
CALL media\XBMCTex.bat

ECHO ------------------------------
ECHO Copying XPR Files...
xcopy *.xpr "BUILD\Project Mayhem I\media\" /Q /I /Y

ECHO ------------------------------
ECHO Cleaning Up...
del *.xpr

ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "1080i" "BUILD\Project Mayhem I\1080i" /E /Q /I /Y
xcopy "720p" "BUILD\Project Mayhem I\720p" /E /Q /I /Y
xcopy "NTSC" "BUILD\Project Mayhem I\NTSC" /E /Q /I /Y
xcopy "NTSC16x9" "BUILD\Project Mayhem I\NTSC16x9" /E /Q /I /Y
xcopy "PAL" "BUILD\Project Mayhem I\PAL" /E /Q /I /Y
xcopy "PAL16x9" "BUILD\Project Mayhem I\PAL16x9" /E /Q /I /Y
xcopy "fonts" "BUILD\Project Mayhem I\fonts" /E /Q /I /Y
xcopy "*.xml" "BUILD\Project Mayhem I\" /Q /I /Y

copy *.xml "BUILD\Project Mayhem I\"
copy *.txt "BUILD\Project Mayhem I\"

ECHO ------------------------------
ECHO Removing SVN directories from build
FOR /R BUILD %%d IN (.SVN) DO @RD /S /Q "%%d" 2>NUL

echo Build Complete - Scroll Up to check for errors.
echo Final build is located in the BUILD directory
echo ftp the Project Mayhem I folder in the build dir to your xbox
pause
