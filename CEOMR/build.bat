@ECHO OFF
CLS
COLOR 71
ECHO Preparing the build...
ECHO .
ECHO ..
ECHO ...
ECHO ....
ECHO .....
Echo .svn>exclude.txt
Echo Thumbs.db>>exclude.txt
Echo Desktop.ini>>exclude.txt
Echo dsstdfx.bin>>exclude.txt
Echo help.xpr>>exclude.txt
Echo hilfe.xpr>>exclude.txt
Echo textures.xpr>>exclude.txt
Echo exclude.txt>>exclude.txt

SET TEX=skin\CEOMR Media Center\media\XBMCTex.exe

SET SKINBUILD=BUILD

ECHO Copying files...

XCOPY "addons" "%SKINBUILD%\addons" /E /Q /I /Y /EXCLUDE:exclude.txt
XCOPY "media" "%SKINBUILD%\media" /E /Q /I /Y /EXCLUDE:exclude.txt
XCOPY "scripts" "%SKINBUILD%\scripts" /E /Q /I /Y /EXCLUDE:exclude.txt
XCOPY "skin" "%SKINBUILD%\skin" /E /Q /I /Y /EXCLUDE:exclude.txt
XCOPY "web" "%SKINBUILD%\web" /E /Q /I /Y /EXCLUDE:exclude.txt

ECHO Compressing textures...

"%TEX%" -input "skin\CEOMR Media Center\media\hilfe.xpr" -quality high -output "%SKINBUILD%\skin\CEOMR Media Center\media"
ren "%SKINBUILD%\skin\CEOMR Media Center\media\Textures.xpr" "Hilfe.xpr"

"%TEX%" -input "skin\CEOMR Media Center\media\help.xpr" -quality high -output "%SKINBUILD%\skin\CEOMR Media Center\media"
ren "%SKINBUILD%\skin\CEOMR Media Center\media\Textures.xpr" "Help.xpr"

"%TEX%" -input "skin\CEOMR Media Center\media\Textures.xpr" -quality high -output "%SKINBUILD%\skin\CEOMR Media Center\media"

del exclude.txt

ECHO Finished!