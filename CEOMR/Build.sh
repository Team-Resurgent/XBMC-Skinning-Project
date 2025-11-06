#!/bin/bash

cd ${0%/*}
which XBMCTex &>/dev/null || { echo Can\'t find XBMCTex; exit 1 ;}

SKINNAME="CEOMR Media Center"

echo ------------------------------
echo Creating $SKINNAME Build Folder
rm -Rf BUILD
mkdir -p "BUILD/skin/$SKINNAME/media"

echo ------------------------------
echo Creating XPR Files...
XBMCTex -input "\"skin/$SKINNAME/media/hilfe.xpr\"" -output Hilfe.xpr -quality max -noprotect
XBMCTex -input "\"skin/$SKINNAME/media/help.xpr\"" -output Help.xpr -quality max -noprotect
XBMCTex -input "\"skin/$SKINNAME/media/textures.xpr\"" -output textures.xpr -quality max -noprotect

echo ------------------------------
echo Copying XPR Files...
mv -f *.xpr "BUILD/skin/$SKINNAME/media/"

echo ------------------------------
echo Building Skin Directory...

for i in addons scripts web
do
  cp -R $i BUILD/
done

for i in 1080i 720p PAL PAL16x9 NTSC NTSC16x9 fonts colors sounds scripts
do
  cp -R "skin/$SKINNAME/$i" "BUILD/skin/$SKINNAME/"
done

cp skin/"$SKINNAME"/*.xml "BUILD/skin/$SKINNAME/"
cp *.txt BUILD
   
echo ------------------------------
echo Removing SVN directories from build
for inode in $(ls -Ria BUILD|grep ".svn$"|cut -d' ' -f1)
do
	find -inum $inode -exec rm -Rf '{}' \; &>/dev/null
done

echo Build Complete - Scroll Up to check for errors.
echo Final build is located in the BUILD directory
echo ftp the $SKINNAME folder in the build dir to your xbox
