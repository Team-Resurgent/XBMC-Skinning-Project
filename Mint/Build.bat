@ECHO OFF

ECHO ------------------------------
ECHO Creating "Mint" Build Folder
rmdir BUILD /S /Q
md BUILD

ECHO ------------------------------
ECHO Creating XPR Files...
START /B /WAIT XBMCTex -input media -output media -quality high -noprotect >> BUILD\XBMCTexLog.log

ECHO ------------------------------
ECHO Copying XPR Files...
xcopy "media\*.xpr" "BUILD\Mint\media\" /Q /I /Y

ECHO ------------------------------
ECHO Cleaning Up...
del "media\*.xpr"

ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "720p" "BUILD\Mint\720p" /E /Q /I /Y
xcopy "colors" "BUILD\Mint\colors" /E /Q /I /Y
xcopy "fonts" "BUILD\Mint\fonts" /E /Q /I /Y
xcopy "sounds" "BUILD\Mint\sounds" /E /Q /I /Y
xcopy "*.xml" "BUILD\Mint\" /Q /I /Y
xcopy "*.txt" "BUILD" /Q /I /Y

ECHO ------------------------------
ECHO Removing SVN directories from build...
FOR /R BUILD %%d IN (.SVN) DO @RD /S /Q "%%d" 2>NUL

ECHO Build Complete - Scroll Up to check for errors.
ECHO Final build is located in the BUILD directory
ECHO Enjoy!!!

pause
