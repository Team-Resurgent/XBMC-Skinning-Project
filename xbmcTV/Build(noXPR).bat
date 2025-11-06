@ECHO off
CLS
COLOR 17
TITLE xbmcTV Build Script
  ECHO ------------------------------------------------------------ 
  ECHO    ВВВВВВВББББББББААААААА
  ECHO  ВлллллллллллллллллллллллВВВВВВБББББАААААА     пппВмм
  ECHO олллллллллллллллллллллллллллллллллллллллллВВВВБББАА  ппм
  ECHO ВлллллллллллллллллллллллллллллллллллллллллллллллллллВА  н
  ECHO ВлллллллллллллллллллплллллллллллллллллллллллллллллллллА В
  ECHO БллллллллллллллллллнАлллллллллллллллллллллллллллллллллл о
  ECHO АллллллВБА  плп           плллп    пВп    плллп   АВллл о
  ECHO  ллллллллллн   млллн Влллм олн мВлм   мллм ол  мллллллл о
  ECHO  Влллллллллл  лллллн лллллн л оллллн оллллн н олллллллл В
  ECHO  Блллллллллн олллллн лллллн л лллллн лллллн   ВлллллллВ н
  ECHO  АВлллллллп   пллллн плллп он лллллн лллллн А плллллллн н
  ECHO   БлллВБА мллм АБВллм     млВмллллллмлллллВ лм   АВлллно
  ECHO   АВлллллллллллллллллллллллллллллллллллллллллллллллллл В
  ECHO    Блллллпппплпплппллпллпллллпплпплппплпплпплппллллллл н
  ECHO    АВлллл но л пл л л лнмоллл лл пл л лнол пл пмлллллБ н
  ECHO     Блллл но л пл пмл л м ллл пл пл л лнол пл л лллллАо
  ECHO     АВллллллллллллллллллллллллллллллллллллллллллллллВ
  ECHO      БАммммммммммммммммммммммммммммммммммммм  АБВВВВ
  ECHO      АВллллллллллллллллллллллллллллллллллллллВААБВп
  ECHO       БВлллллллллллллллллллллллллллллВлВВпппп
  ECHO        ВВллллллллллллллллллВлВВпппп
  ECHO         пВллллВлВВВпппппп
  ECHO ------------------------------------------------------------ 
ECHO Creating "xbmcTV" Build Folder
rmdir BUILD /S /Q
md BUILD

ECHO ------------------------------
ECHO Building Skin Directory...
xcopy "media" "BUILD\xbmcTV\media" /E /Q /I /Y
xcopy "1080i" "BUILD\xbmcTV\1080i" /E /Q /I /Y
xcopy "720p" "BUILD\xbmcTV\720p" /E /Q /I /Y
xcopy "NTSC" "BUILD\xbmcTV\NTSC" /E /Q /I /Y
xcopy "NTSC16x9" "BUILD\xbmcTV\NTSC16x9" /E /Q /I /Y
xcopy "PAL" "BUILD\xbmcTV\PAL" /E /Q /I /Y
xcopy "PAL16x9" "BUILD\xbmcTV\PAL16x9" /E /Q /I /Y
xcopy "fonts" "BUILD\xbmcTV\fonts" /E /Q /I /Y
xcopy "sounds" "BUILD\xbmcTV\sounds" /E /Q /I /Y
xcopy "colors" "BUILD\xbmcTV\colors" /E /Q /I /Y
xcopy "language" "BUILD\xbmcTV\language" /E /Q /I /Y
xcopy "*.xml" "BUILD\xbmcTV\" /Q /I /Y

ECHO ------------------------------
ECHO Removing SVN directories from build...
FOR /R BUILD %%d IN (SVN) DO @RD /S /Q "%%d" 2>NUL

ECHO Build Complete - Scroll Up to check for errors.
ECHO Final build is located in the BUILD directory
ECHO Have Fun


pause