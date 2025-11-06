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
xcopy "media\*.xpr" "BUILD\Vision\media\" /Q /I /Y

ECHO ------------------------------
ECHO Cleaning Up...
del media\*.xpr

ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "1080i" "BUILD\Vision\1080i" /E /Q /I /Y
xcopy "720p" "BUILD\Vision\720p" /E /Q /I /Y
xcopy "NTSC" "BUILD\Vision\NTSC" /E /Q /I /Y
xcopy "NTSC16x9" "BUILD\Vision\NTSC16x9" /E /Q /I /Y
xcopy "PAL" "BUILD\Vision\PAL" /E /Q /I /Y
xcopy "PAL16x9" "BUILD\Vision\PAL16x9" /E /Q /I /Y
xcopy "fonts" "BUILD\Vision\fonts" /E /Q /I /Y
xcopy "sounds" "BUILD\Vision\sounds" /E /Q /I /Y
xcopy "colors" "BUILD\Vision\colors" /E /Q /I /Y
xcopy "language" "BUILD\Vision\language" /E /Q /I /Y
xcopy "*.xml" "BUILD\Vision\" /Q /I /Y

copy *.xml "BUILD\Vision\"
copy *.txt "BUILD\Vision\"

ECHO ------------------------------
ECHO Removing SVN directories from build
FOR /R BUILD %%d IN (.SVN) DO @RD /S /Q "%%d" 2>NUL

echo Build Complete - Scroll Up to check for errors.
echo Final build is located in the BUILD directory
echo ftp the Vision folder in the build dir to your xbox
pause
