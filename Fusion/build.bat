@echo off
ECHO ----------------------------------------
echo Creating Fusion Build Folders
rmdir BUILD /S /Q
md BUILD
rmdir BUILD_720 /S /Q
md BUILD_720

Echo .svn>exclude.txt
Echo Thumbs.db>>exclude.txt
Echo Desktop.ini>>exclude.txt
Echo dsstdfx.bin>>exclude.txt
Echo exclude.txt>>exclude.txt

ECHO ----------------------------------------
ECHO Creating SD XPR File...
START /B /WAIT XBMCTex -input media\media_sd -quality high -output media\media_sd -noprotect >> pack.log
ECHO Creating 720p XPR File...
START /B /WAIT XBMCTex -input media\media_720 -quality high -output media\media_720 -noprotect >> pack.log

ECHO ----------------------------------------
ECHO Copying XPR Files...
xcopy "media\media_sd\Textures.xpr" "BUILD\Fusion\media\" /Q /I /Y
xcopy "media\media_720\Textures.xpr" "BUILD_720\Fusion\media\" /Q /I /Y

ECHO ----------------------------------------
ECHO Cleaning Up...
del "media\media_sd\Textures.xpr"
del "media\media_720\Textures.xpr"

ECHO ----------------------------------------
ECHO XPR Texture Files Created...
ECHO Building SD Skin Directory...
xcopy "720p" "BUILD\Fusion\720p" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "1080i" "BUILD\Fusion\1080i" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "fonts" "BUILD\Fusion\fonts" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "NTSC" "BUILD\Fusion\NTSC" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "NTSC16x9" "BUILD\Fusion\NTSC16x9" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "PAL" "BUILD\Fusion\PAL" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "PAL16x9" "BUILD\Fusion\PAL16x9" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "sounds\*.*" "BUILD\Fusion\sounds\" /Q /I /Y /EXCLUDE:exclude.txt
xcopy "colors\*.*" "BUILD\Fusion\colors\" /Q /I /Y /EXCLUDE:exclude.txt
ECHO Building HD Skin Directory...
xcopy "720p" "BUILD_720\Fusion\720p" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "1080i" "BUILD_720\Fusion\1080i" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "fonts" "BUILD_720\Fusion\fonts" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "NTSC" "BUILD_720\Fusion\NTSC" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "NTSC16x9" "BUILD_720\Fusion\NTSC16x9" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "PAL" "BUILD_720\Fusion\PAL" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "PAL16x9" "BUILD_720\Fusion\PAL16x9" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "sounds\*.*" "BUILD_720\Fusion\sounds\" /Q /I /Y /EXCLUDE:exclude.txt
xcopy "colors\*.*" "BUILD_720\Fusion\colors\" /Q /I /Y /EXCLUDE:exclude.txt

del exclude.txt

copy *.xml "BUILD\Fusion\"
copy *.txt "BUILD\Fusion\"
copy *.xml "BUILD_720\Fusion\"
copy *.txt "BUILD_720\Fusion\"

ECHO Press any key to exit...
pause > NUL