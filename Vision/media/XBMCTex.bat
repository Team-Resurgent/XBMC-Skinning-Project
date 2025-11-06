@echo off

START /B /WAIT media/XBMCTex -input media\default\ -output media\textures.xpr -quality max -noprotect
START /B /WAIT media/XBMCTex -input media\PM3\ -output media\PM3.xpr -quality max -noprotect
