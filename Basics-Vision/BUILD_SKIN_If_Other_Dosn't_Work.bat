@echo off
ECHO ------------------------------
echo Creating Basics-Vision Build Folder
rmdir BUILD /S /Q
md BUILD

ECHO ------------------------------
ECHO Creating XPR Files...
CALL XBMCTex -input media\ -output textures.xpr -quality max -noprotect

ECHO ------------------------------
ECHO Copying XPR Files...
xcopy "*.xpr" "BUILD\Basics-Vision\media\" /Q /I /Y

ECHO ------------------------------
ECHO Cleaning Up...
del "*.xpr"

ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "1080i" "BUILD\Basics-Vision\1080i" /E /Q /I /Y
xcopy "720p" "BUILD\Basics-Vision\720p" /E /Q /I /Y
xcopy "PAL16x9" "BUILD\Basics-Vision\PAL16x9" /E /Q /I /Y
xcopy "PAL" "BUILD\Basics-Vision\PAL" /E /Q /I /Y
xcopy "colors" "BUILD\Basics-Vision\colors" /E /Q /I /Y
xcopy "fonts" "BUILD\Basics-Vision\fonts" /E /Q /I /Y
xcopy "sounds" "BUILD\Basics-Vision\sounds" /E /Q /I /Y
xcopy "language" "BUILD\Basics-Vision\language" /E /Q /I /Y
xcopy "*.xml" "BUILD\Basics-Vision\" /Q /I /Y

copy *.txt "BUILD\Basics-Vision\"

ECHO ------------------------------
ECHO Removing SVN directories from build
FOR /R BUILD %%d IN (.SVN) DO @RD /S /Q "%%d" 2>NUL

echo Build Complete - Scroll Up to check for errors.
echo Final build is located in the BUILD directory
echo ftp the Basics-Vision folder in the build dir to your xbox
pause
