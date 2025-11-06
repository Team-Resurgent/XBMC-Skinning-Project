#!/bin/bash

#TODO:handle Xbox build
#TODO:Create revision include file

cd ${0%/*}
which XBMCTex &>/dev/null || { echo Can\'t find XBMCTex; exit 1 ;}

SKINNAME=Basics-101
#REVISION=$(sed -n 4p .svn/entries)



echo ------------------------------
echo Creating $SKINNAME Build Folder
rm -Rf BUILD
mkdir -p BUILD/$SKINNAME/media

echo ------------------------------
echo Creating XPR Files...
XBMCTex -input media -output textures.xpr -quality max -noprotect


echo ------------------------------
echo Copying XPR Files...
mv -f *.xpr BUILD/$SKINNAME/media/ 

echo ------------------------------
echo creating Media Directory structure...
for i in "Default Wallpaper" Movies TV Music Photos Apps Settings "Sub Button Wallpaper" Files Scripts Weather
do 
  mkdir "BUILD/$SKINNAME/media/$i"
done

echo ------------------------------
echo Building Skin Directory...

for i in 1080i 720p PAL16x9 Fonts colors sounds language extras *.xml
do
  cp -R $i BUILD/$SKINNAME/
done

cp *.txt BUILD
   
echo ------------------------------
echo Removing SVN directories from build
for inode in $(ls -Ria BUILD/$SKINNAME|grep ".svn$"|cut -d' ' -f1)
do
	find -inum $inode -exec rm -Rf '{}' \; &>/dev/null
done

echo Build Complete - Scroll Up to check for errors.
echo Final build is located in the BUILD directory
echo ftp the $SKINNAME folder in the build dir to your xbox
