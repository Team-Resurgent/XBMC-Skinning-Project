#!/bin/bash

cd ${0%/*}
which XBMCTex &>/dev/null || { echo Can\'t find XBMCTex; exit 1 ;}

SKINNAME=PDM

echo ------------------------------
echo Creating $SKINNAME Build Folder
rm -Rf BUILD
mkdir -p BUILD/$SKINNAME/media

echo ------------------------------
echo Creating XPR Files...
XBMCTex -input media/Default -output textures.xpr -quality max -noprotect
XBMCTex -input media/X -output textures.xpr -quality max -noprotect


echo ------------------------------
echo Copying XPR Files...
mv -f *.xpr BUILD/$SKINNAME/media/ 

echo ------------------------------
echo creating Media Directory structure...
for i in "PIC Filemanager" "PIC Games" "PIC Movies" "PIC Music" "PIC Pictures" "PIC Scripts" "PIC Settings" "PIC Shutdown" "PIC Weather" "PIC Xlink"
do 
  mkdir "BUILD/$SKINNAME/media/$i"
done

echo ------------------------------
echo Building Skin Directory...

for i in 1080i 720p NTSC NTSC16x9 PAL PAL16x9 fonts sounds extras *.xml
do
  cp -R $i BUILD/$SKINNAME/
done

cp -R extras/backgrounds BUILD/$SKINNAME/media/Default

cp *.txt BUILD
   
echo ------------------------------
echo Removing SVN directories from build
rm -Rf BUILD/$SKINNAME/*/.svn

echo Build Complete - Scroll Up to check for errors.
echo Final build is located in the BUILD directory
echo ftp the $SKINNAME folder in the build dir to your xbox
