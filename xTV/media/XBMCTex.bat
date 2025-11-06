@echo off

START /B /WAIT media/XBMCTex -input media\Default\ -output media\textures.xpr -quality max -noprotect
START /B /WAIT media/XBMCTex -input media\White\ -output media\White.xpr -quality max -noprotect
