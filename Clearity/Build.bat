@ECHO OFF

ECHO ------------------------------
ECHO Creating "Clearity" Build Folder
rmdir BUILD /S /Q
md BUILD

ECHO ------------------------------
ECHO Creating XPR Files...
CALL media\XBMCTex.bat

ECHO ------------------------------
ECHO Copying XPR Files...
xcopy "media\*.xpr" "BUILD\Clearity\media\" /Q /I /Y

ECHO ------------------------------
ECHO Cleaning Up...
del "media\*.xpr"

ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "1080i" "BUILD\Clearity\1080i" /E /Q /I /Y
xcopy "720p" "BUILD\Clearity\720p" /E /Q /I /Y
xcopy "PAL" "BUILD\Clearity\PAL" /E /Q /I /Y
xcopy "PAL16x9" "BUILD\Clearity\PAL16x9" /E /Q /I /Y
xcopy "colors" "BUILD\Clearity\colors" /E /Q /I /Y
xcopy "fonts" "BUILD\Clearity\fonts" /E /Q /I /Y
xcopy "language" "BUILD\Clearity\language" /E /Q /I /Y
xcopy "sounds" "BUILD\Clearity\sounds" /E /Q /I /Y
xcopy "*.xml" "BUILD\Clearity\" /Q /I /Y
xcopy "*.txt" "BUILD\Clearity\" /Q /I /Y

ECHO ------------------------------
ECHO Removing SVN directories from build...
FOR /R BUILD %%d IN (.SVN) DO @RD /S /Q "%%d" 2>NUL

ECHO Building of Clearity Completed 
ECHO ------------------------------
ECHO you may wanna scroll up to check for errors.
ECHO Final build is located in the BUILD directory
ECHO Enjoy!!!

pause
