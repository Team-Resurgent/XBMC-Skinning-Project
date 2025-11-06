@echo off

python -OO Py2Exe.py

:: build cleanup
rmdir "build" /S /Q

:: copy dependancies
mkdir "dist\resources"
xcopy "resources\language" "dist\resources\language" /E /Q /I /Y
copy  "resources\config.xml" "dist\resources"
copy  "tools\msvcp71.dll" "dist"
copy  "resources\lib\UnRAR\unrar.dll" "dist"
copy  "resources\lib\UnRAR\unrar.dll.license.txt" "dist"
copy  "doc\readme.txt" "dist"
copy  "doc\changelog.txt" "dist"

:: binary compression (assuming that 7zip is installed)
echo Do you want compress executables ? (7-zip required ; take long time)
set /P compress=(y/n): 
if %compress% NEQ y (
GOTO end
)

cd dist
"C:\Program Files\7-Zip\7z.exe" -aoa x library.zip -olibrary\ 
del library.zip 
cd library
"C:\Program Files\7-Zip\7z.exe" a -tzip -mx9 ..\library.zip -r 
cd.. 
rd library /s /q 
cd..

"tools\upx.exe" --best dist\*.* 

:end
pause