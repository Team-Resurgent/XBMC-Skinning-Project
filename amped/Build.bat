@echo off
ECHO ------------------------------
echo Creating Amped Build Folder
rmdir BUILD /S /Q
md BUILD

ECHO ------------------------------
ECHO Creating Theme XPR Files...

CALL Kenwood\XBMCTex.bat
move *.xpr kenwood.xpr


CALL media\XBMCTex.bat




ECHO ------------------------------
ECHO XPR Texture Files Created...
ECHO Building Skin Directory...
xcopy "extras" "BUILD\skin\Amped\extras" /E /Q /I /Y

xcopy "colors" "BUILD\skin\Amped\colors" /E /Q /I /Y

xcopy "720p" "BUILD\skin\Amped\720p" /E /Q /I /Y
xcopy "1080i" "BUILD\skin\Amped\1080i" /E /Q /I /Y
xcopy "NTSC" "BUILD\skin\Amped\NTSC" /E /Q /I /Y
xcopy "NTSC16x9" "BUILD\skin\Amped\NTSC16x9" /E /Q /I /Y
xcopy "PAL" "BUILD\skin\Amped\PAL" /E /Q /I /Y
xcopy "PAL16x9" "BUILD\skin\Amped\PAL16x9" /E /Q /I /Y
xcopy "fonts" "BUILD\skin\Amped\fonts" /E /Q /I /Y
xcopy "*.xml" "BUILD\skin\Amped\" /Q /I /Y
xcopy "sounds\*.*" "BUILD\skin\Amped\sounds\" /Q /I /Y 

ECHO ------------------------------
ECHO Copying Theme XPR Files...
xcopy *.xpr BUILD\skin\Amped\media /Q /I /Y
copy *.xml BUILD\skin\Amped\
copy *.txt BUILD\skin\

ECHO ------------------------------
ECHO Cleaning Up...
del *.xpr


ECHO ------------------------------
ECHO Removing SVN directories from build
FOR /R BUILD %%d IN (.SVN) DO @RD /S /Q "%%d" 2>NUL

echo Build Complete - Scroll Up to check for errors.
echo ---
echo Yippie Kia Ayye!
pause
cls
Echo NOTE
Echo ----
echo.
echo Wallpapers have been removed, if you want to add wallpapers to the home page please insert into the folders created for
echo you within the build/skin/amped/media folders.
echo .
echo Thank you

md build\skin\amped\media\Movies
md build\skin\amped\media\Music
md build\skin\amped\media\Pictures

md build\skin\amped\media\Programs
md build\skin\amped\media\Games
md build\skin\amped\media\Emulators

md build\skin\amped\media\Files
md build\skin\amped\media\Settings
md build\skin\amped\media\Weather
md build\skin\amped\media\Scripts




pause
