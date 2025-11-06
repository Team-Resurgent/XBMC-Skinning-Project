@echo off
ECHO ------------------------------
echo Creating MARK-III Build Folder
rmdir BUILD /S /Q
md BUILD

ECHO ------------------------------
ECHO Creating XPR Files...
CALL XBMCTex -input media\ -output textures.xpr -quality max -noprotect

ECHO ------------------------------
ECHO Copying XPR Files...
xcopy "*.xpr" "BUILD\MARK-III\media\" /Q /I /Y

ECHO ------------------------------
ECHO Cleaning Up...
del "*.xpr"

ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "backgrounds" "BUILD\MARK-III\backgrounds" /E /Q /I /Y
xcopy "720p" "BUILD\MARK-III\720p" /E /Q /I /Y
xcopy "colors" "BUILD\MARK-III\colors" /E /Q /I /Y
xcopy "fonts" "BUILD\MARK-III\fonts" /E /Q /I /Y
xcopy "sounds" "BUILD\MARK-III\sounds" /E /Q /I /Y
xcopy "language" "BUILD\MARK-III\language" /E /Q /I /Y
xcopy "*.xml" "BUILD\MARK-III\" /Q /I /Y
xcopy "*.txt" "BUILD\MARK-III\" /Q /I /Y

ECHO ------------------------------
ECHO Removing SVN directories from build
FOR /R BUILD %%d IN (.SVN) DO @RD /S /Q "%%d" 2>NUL

echo Build Complete - Scroll Up to check for errors.
echo Final build is located in the BUILD directory
echo ftp the MARK-III folder in the build dir to your xbox
pause
