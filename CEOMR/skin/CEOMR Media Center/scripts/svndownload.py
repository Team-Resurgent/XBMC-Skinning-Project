import os
import xbmcgui
import urllib
from sgmllib import SGMLParser
import socket

socket.setdefaulttimeout( 5 )

class Parser( SGMLParser ):
    def reset( self ):
        self.tags = []
        self.url = None
        self.tag_found = None
        self.url_found = True
        SGMLParser.reset( self )

    def start_a( self, attrs ):
        for key, value in attrs:
            if ( key == 'href' ): self.tag_found = value
    
    def handle_data( self, text ):
        if ( self.tag_found == text.replace( ' ', '%20' ) ):
            self.tags.append( self.tag_found )
            self.tag_found = False
        if ( self.url_found ):
            self.url = text.replace( ' ', '%20' )
            self.url_found = False
            
    def unknown_starttag( self, tag, attrs ):
        if ( tag == 'h2' ):
            self.url_found = True

class Download:
    def __init__( self, script = 'XBMC Lyrics', version = '0' ):
        self.script = script
        self.version = version
        self.base_url = 'http://xbmc-scripting.googlecode.com/svn'
        self.dialog = xbmcgui.DialogProgress()
        self._download_script()
        
    def _download_script( self ):
        try:
            self.dialog.create( self.script )
            tag = self._get_tagged_versions()
            if ( tag ):
                self.dialog.update( -1, 'Fetching file list...', 'Please wait...' )
                script_files = []
                folders = ['%s/%s' % ( self.url, self.versions[-1], )]
                while folders:
                    try:
                        htmlsource = self._get_html_source( '%s%s' % ( self.base_url, folders[0] ) )
                        if ( htmlsource ):
                            items, url = self._parse_html_source( htmlsource )
                            files, dirs = self._parse_items( items )
                            url = url[url.find( ':%20' ) + 4:]
                            for file in files:
                                script_files.append( '%s/%s' % ( url, file, ) )
                            for folder in dirs:
                                folders.append( '%s/%s' % ( folders[0], folder, ) )
                        else: 
                            raise
                        folders = folders[1:]
                    except:
                        folders = None
                self._get_files( script_files, self.versions[-1][:-1] )
            else: 
                self.dialog.close()
                xbmcgui.Dialog().ok( self.script, 'There was an error downloading script.' )
        except:
            self.dialog.close()
            xbmcgui.Dialog().ok( self.script, 'There was an error downloading script.' )
        
    def _get_tagged_versions( self ):
        try:
            self.dialog.update( -1, 'Fetching current tagged versions...' )
            # get version tags
            tag = False
            htmlsource = self._get_html_source( '%s/tags/%s' % ( self.base_url, self.script.replace( ' ', '%20' ), ) )
            if ( htmlsource ):
                self.versions, url = self._parse_html_source( htmlsource )
                self.url = url[url.find( ':%20' ) + 4:]
                if ( self.versions ):
                    tag = True
        except: 
            traceback.print_exc()
            tag = None
        return tag
                
    def _get_files( self, script_files, version ):
        try:
            for cnt, url in enumerate( script_files ):
                items = os.path.split( url )
                path = items[0].replace( '/tags/%s/%s' % ( self.script.replace( ' ', '%20' ), self.versions[-1][:-1].replace( ' ', '%20' ), ), 'Q:\\scripts\\%s' % ( self.script, ) ).replace( '/', '\\' ).replace( '%20', ' ' )
                file = items[1].replace( '%20', ' ' )
                pct = int( ( float( cnt ) / len( script_files ) ) * 100 )
                self.dialog.update( pct, 'Fetching: %s' % ( url, ), 'Path: %s' % ( path, ), 'File: %s' % ( file, ) )
                if ( self.dialog.iscanceled() ): raise
                if ( not os.path.isdir( path ) ): os.makedirs( path )
                urllib.urlretrieve( '%s%s' % ( self.base_url, url, ), '%s\\%s' % ( path, file, ) )
        except:
            raise
        else:
            self.dialog.close()
            
    def _get_html_source( self, url ):
        try:
            sock = urllib.urlopen( url )
            htmlsource = sock.read()
            sock.close()
            return htmlsource
        except: return None

    def _parse_html_source( self, htmlsource ):
        try:
            parser = Parser()
            parser.feed( htmlsource )
            parser.close()
            return parser.tags, parser.url
        except: return None, None
            
    def _parse_items( self, items ):
        folders = []
        files = []
        for item in items:
            if ( item[-1] == '/' ):
                folders.append( item )
            else:
                files.append( item )
        return files, folders
