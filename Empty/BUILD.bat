@echo off
ECHO ------------------------------
echo Creating Empty Build Folder
rmdir BUILD /S /Q
md BUILD

ECHO ------------------------------
ECHO Creating XPR Files...
CALL XBMCTex -input media\ -output textures.xpr -quality max -noprotect

ECHO ------------------------------
ECHO Copying XPR Files...
xcopy "*.xpr" "BUILD\Empty\media\" /Q /I /Y

ECHO ------------------------------
ECHO Cleaning Up...
del "*.xpr"

ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "1080i" "BUILD\Empty\1080i" /E /Q /I /Y
xcopy "720p" "BUILD\Empty\720p" /E /Q /I /Y
xcopy "NTSC" "BUILD\Empty\NTSC" /E /Q /I /Y
xcopy "NTSC16x9" "BUILD\Empty\NTSC16x9" /E /Q /I /Y
xcopy "PAL16x9" "BUILD\Empty\PAL16x9" /E /Q /I /Y
xcopy "PAL" "BUILD\Empty\PAL" /E /Q /I /Y
xcopy "colors" "BUILD\Empty\colors" /E /Q /I /Y
xcopy "fonts" "BUILD\Empty\fonts" /E /Q /I /Y
xcopy "sounds" "BUILD\Empty\sounds" /E /Q /I /Y
xcopy "language" "BUILD\Empty\language" /E /Q /I /Y
xcopy "*.xml" "BUILD\Empty\" /Q /I /Y

copy *.txt "BUILD\Empty\"

ECHO ------------------------------
ECHO Removing SVN directories from build
FOR /R BUILD %%d IN (.SVN) DO @RD /S /Q "%%d" 2>NUL

echo Build Complete - Scroll Up to check for errors.
echo Final build is located in the BUILD directory
echo ftp the Empty folder in the build dir to your xbox
pause
