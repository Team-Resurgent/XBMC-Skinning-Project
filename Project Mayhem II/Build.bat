@echo off
ECHO ------------------------------
ECHO Creating Project Mayhem II Build Folder
rmdir BUILD /S /Q
md BUILD

ECHO ------------------------------
ECHO Creating XPR Files...
CALL media\XBMCTex.bat

ECHO ------------------------------
ECHO Copying XPR Files...
xcopy *.xpr "BUILD\Project Mayhem II\media\" /Q /I /Y

ECHO ------------------------------
ECHO Cleaning Up...
del *.xpr
 
ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "1080i" "BUILD\Project Mayhem II\1080i" /E /Q /I /Y
xcopy "720p" "BUILD\Project Mayhem II\720p" /E /Q /I /Y
xcopy "PAL" "BUILD\Project Mayhem II\PAL" /E /Q /I /Y
xcopy "PAL16x9" "BUILD\Project Mayhem II\PAL16x9" /E /Q /I /Y
xcopy "language" "BUILD\Project Mayhem II\language" /E /Q /I /Y
xcopy "fonts" "BUILD\Project Mayhem II\fonts" /E /Q /I /Y
xcopy "sounds" "BUILD\Project Mayhem II\sounds" /E /Q /I /Y
xcopy "*.xml" "BUILD\Project Mayhem II\" /Q /I /Y

ECHO ------------------------------
ECHO Removing SVN directories from build
FOR /R BUILD %%d IN (.SVN) DO @RD /S /Q "%%d" 2>NUL

ECHO Build Complete - Scroll Up to check for errors.
ECHO Final build is located in the BUILD directory
ECHO ftp the Project Mayhem II folder in the build dir to your xbox
pause
