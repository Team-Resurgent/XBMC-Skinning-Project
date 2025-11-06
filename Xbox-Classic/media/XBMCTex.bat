@echo off

START /B /WAIT media/XBMCTex -input media\Default\ -output media\textures.xpr -quality max -noprotect
START /B /WAIT media/XBMCTex -input media\Moonlight\ -output media\Moonlight.xpr -quality max -noprotect
START /B /WAIT media/XBMCTex -input media\Farenheit\ -output media\Farenheit.xpr -quality max -noprotect
