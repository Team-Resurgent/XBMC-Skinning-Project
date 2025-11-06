@echo off
ECHO ------------------------------
echo Creating eX Build Folder
rmdir BUILD /S /Q
md BUILD

ECHO ------------------------------
ECHO Creating XPR Files...
XBMCTex -input media\ -output textures.xpr -quality max

ECHO ------------------------------
ECHO Copying XPR Files...
xcopy "*.xpr" "BUILD\Vision2\media\" /Q /I /Y

ECHO ------------------------------
ECHO Cleaning Up...
del "*.xpr"

ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "720p" "BUILD\Vision2\720p" /E /Q /I /Y
xcopy "colors" "BUILD\Vision2\colors" /E /Q /I /Y
xcopy "language" "BUILD\Vision2\language" /E /Q /I /Y
xcopy "fonts" "BUILD\Vision2\fonts" /E /Q /I /Y
xcopy "sounds" "BUILD\Vision2\sounds" /E /Q /I /Y
xcopy "*.xml" "BUILD\Vision2\" /Q /I /Y

copy *.txt "BUILD"

ECHO ------------------------------
ECHO Removing SVN directories from build
FOR /R BUILD %%d IN (.SVN) DO @RD /S /Q "%%d" 2>NUL

echo Build Complete - Scroll Up to check for errors.
echo Final build is located in the BUILD directory
echo ftp the Vision2 folder in the build dir to your xbox
pause
