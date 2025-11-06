#!/bin/bash

cd ${0%/*}
which XBMCTex &>/dev/null || { echo Can\'t find XBMCTex; exit 1 ;}

SKINNAME=Fusion

echo ------------------------------
echo Creating $SKINNAME Build Folder
rm -Rf BUILD
mkdir -p BUILD/$SKINNAME/media
rm -Rf BUILD_720
mkdir -p BUILD_720/$SKINNAME/media

echo ------------------------------
echo Creating SD XPR File...
XBMCTex -input media/media_sd -output media/media_sd -quality max -noprotect
XBMCTex -input media/media_720 -output media/media_720 -quality max -noprotect


echo ------------------------------
echo Copying XPR Files...
mv -f media/media_sd/*.xpr BUILD/$SKINNAME/media/ 
mv -f media/media_720/*.xpr BUILD_720/$SKINNAME/media/ 


echo ------------------------------
echo Building Skin Directory...

for i in 1080i 720p NTSC NTSC16x9 PAL PAL16x9 fonts colors sounds *.xml
do
  cp -R $i BUILD/$SKINNAME/
  cp -R $i BUILD_720/$SKINNAME/
done

cp *.txt BUILD
cp *.txt BUILD_720
   
echo ------------------------------
echo Removing SVN directories from build
for inode in $(ls -Ria BUILD/$SKINNAME|grep ".svn$"|cut -d' ' -f1)
do
	find -inum $inode -exec rm -Rf '{}' \; &>/dev/null
done

echo Build Complete - Scroll Up to check for errors.
echo Final build is located in the BUILD directory
echo ftp the $SKINNAME folder in the build dir to your xbox
