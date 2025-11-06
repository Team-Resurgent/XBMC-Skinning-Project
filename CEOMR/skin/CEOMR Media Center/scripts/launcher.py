"""
Launcher script
"""
import sys, os
import xbmc, xbmcgui
#dummy = xbmc.getCondVisibility( "System.InternetState" ) # per GeminiServers instructions

if ( __name__ == "__main__" ):
    if ( len( sys.argv ) > 1 ):
        SCRIPT = sys.argv[ 1 ].strip()
        if ( os.path.isfile( "q:\\scripts\\%s\\default.py" % ( SCRIPT, ) ) ):
            xbmc.executebuiltin( 'XBMC.RunScript(q:\\scripts\\%s\\default.py)' % ( SCRIPT, ) )
        else:
            #if ( not dummy ): xbmc.sleep( 500 ) # per GeminiServers instructions
            if ( xbmc.getCondVisibility( "System.InternetState" ) ):
                ok = xbmcgui.Dialog().yesno( "Warning! %s" % ( SCRIPT, ), "%s is not installed on your Xbox." % ( SCRIPT, ), "Would you like to download and install it?", "", 'skip', 'download' )
                if ( ok ):
                    import svndownload
                    download = svndownload.Download( script=SCRIPT )
                    del download
                    if ( os.path.isfile( "q:\\scripts\\%s\\default.py" % ( SCRIPT, ) ) ):
                        xbmc.executebuiltin( "XBMC.RunScript(q:\\scripts\\%s\\default.py)" % ( SCRIPT, ) )
            else:
                ok = xbmcgui.Dialog().ok( "Warning! %s" % ( SCRIPT, ), "%s is not installed on your Xbox." % ( SCRIPT, ), "You may download from SVN at:", "http://xbmc-scripting.googlecode.com/svn/trunk/%s" % ( SCRIPT.replace( " ", "%20" ), ) )
    else: ok = xbmcgui.Dialog().ok( "Invalid call to this script!", "You must supply a script name." )
