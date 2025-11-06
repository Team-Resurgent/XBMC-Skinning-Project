
import xbmc, xbmcgui
import urllib,re
import os

base_url = "http://blackbolt.x-scene.com/skins/xbmc/Basics-101/download/themes/themes.xml"
def ping(host):
    import socket,time
    s = socket.socket( socket.AF_INET, socket.SOCK_STREAM )
    t1=float(0)
    t2=float(0)
    t1 = float(time.time()*1000)
    try:
        s.connect(( host, 80 ))
        t2 = float(time.time()*1000)
        s.close()
        del s
        return int((t2 - t1))
    except socket.error, (errcode, errmsg):
        t2 = time.time()
        if errcode == 111:
            return int((t2 - t1))
        else:
            return None


def DownloaderClass(url,dest,name):
    if (os.path.exists(dest)):
        ret = xbmcgui.Dialog().yesno(xbmc.getLocalizedString(31900),xbmc.getLocalizedString(31906),xbmc.getLocalizedString(31907),xbmc.getLocalizedString(31908))
        if (ret == True):
            os.remove(dest)
        else:
            return 0

    dp = xbmcgui.DialogProgress()
    dp.create(xbmc.getLocalizedString(31900),xbmc.getLocalizedString(31902),name)
    try:
        urllib.urlretrieve(url,dest,lambda nb, bs, fs, url=url: _pbhook(nb,bs,fs,url,dp))
        dp.close()
        xbmcgui.Dialog().ok(xbmc.getLocalizedString(31900),xbmc.getLocalizedString(31903),"  ",xbmc.getLocalizedString(31904))
        return 1
    except:
        urllib.urlcleanup()
        remove_tries = 3
        while remove_tries and os.path.isfile(dest):
            try:
                os.remove(dest)
            except:
                remove_tries -= 1
                xbmc.sleep( 1000 )
        dp.close()
        return 0

def _pbhook(numblocks, blocksize, filesize, url=None,dp=None):
    try:
        percent = min((numblocks*blocksize*100)/float(filesize), 100)
        dp.update(int(percent))
    except:
        percent = 100
        dp.update(percent)
    if dp.iscanceled():
        xbmc.executebuiltin('XBMC.Notification($LOCALIZE[31900],$LOCALIZE[31905],2000,defaultAlbumCover.png)')
        raise IOError

def getList():
    WebSock = urllib.urlopen(base_url)  # Opens a 'Socket' to URL
    WebHTML = WebSock.read()            # Reads Contents of URL and saves to Variable
    WebSock.close()
    try:
        ItemList = re.compile('<themename>(.*)</themename><path>(.*)</path><filename>(.*)</filename>', re.IGNORECASE).findall(WebHTML) # Using find all mentions of
    except:
        return [],[],[]
    filename_list = []
    path_list = []
    themename_list = []
    for x in ItemList:
        filename_list.append(x[2])
        path_list.append(x[1])
        themename_list.append(x[0])
    return themename_list,filename_list,path_list

def main():
    themename_list,filename_list,path_list = getList()
    if not themename_list == []:
        retval = xbmcgui.Dialog().select(xbmc.getLocalizedString(31901),themename_list)
        if retval == -1:
            return
        else:
            DownloaderClass(path_list[retval],"Q:\\skin\\Basics-101\\media\\" + filename_list[retval],themename_list[retval])


if __name__ == "__main__":
    main()

