@ECHO OFF
CLS
color 05
ECHO ----------------------------------------
echo Creating Build Folder
rmdir BUILD /S /Q
md BUILD\skin.Connected\media\

Echo .svn>exclude.txt
Echo Thumbs.db>>exclude.txt
Echo Desktop.ini>>exclude.txt
Echo dsstdfx.bin>>exclude.txt
Echo exclude.txt>>exclude.txt

ECHO ----------------------------------------
ECHO Creating XPR File...
START /B /WAIT XBMCTex -input media\ -output BUILD\skin.Connected\media\textures.xpr -quality max

ECHO ----------------------------------------
ECHO XPR Texture Files Created...
ECHO Building Skin Directory...
xcopy "720p" "BUILD\skin.Connected\720p" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "1080i" "BUILD\skin.Connected\1080i" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "colors" "BUILD\skin.Connected\colors" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "fonts" "BUILD\skin.Connected\fonts" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "language" "BUILD\skin.Connected\language" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "NTSC" "BUILD\skin.Connected\NTSC" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "NTSC16x9" "BUILD\skin.Connected\NTSC16x9" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "PAL" "BUILD\skin.Connected\PAL" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "PAL16x9" "BUILD\skin.Connected\PAL16x9" /E /Q /I /Y /EXCLUDE:exclude.txt
xcopy "sounds" "BUILD\skin.Connected\sounds" /Q /I /Y /EXCLUDE:exclude.txt

del exclude.txt

copy *.xml "BUILD\skin.Connected\"
copy icon.png "BUILD\skin.Connected\"
pause