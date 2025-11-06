import xbmc,xbmcgui
import urllib,re,os,shutil

base_url = "http://skin-downloads.googlecode.com/svn/trunk/Skin%20Themes/Containment_themes.xml"
currentskin = xbmc.getSkinDir()
temp = "Z:\\themes_"+currentskin+"\\"

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


def DownloaderClass(url,file,name):
	dp = xbmcgui.DialogProgress()
	dp.create(xbmc.getLocalizedString(31047),xbmc.getLocalizedString(31051)," ",name)
	ext = os.path.splitext(file)[1]
	url = url.replace(" ","%20")
	dest = temp + file
	try: os.makedirs(temp)
	except: pass
	try:
		urllib.urlretrieve(url,dest,lambda nb, bs, fs, url=url: _pbhook(nb,bs,fs,url,dp))
		if ext == ".xpr":
			shutil.move(dest,"Q:\\skin\\"+currentskin+"\\media\\"+file)
		if (ext == ".rar") or (ext == ".zip"):
			xbmc.executebuiltin('XBMC.Extract('+dest+','+"Q:\\skin\\"+currentskin+"\\media\\"+')')
		dp.close()
		xbmcgui.Dialog().ok(xbmc.getLocalizedString(31047),xbmc.getLocalizedString(31052),xbmc.getLocalizedString(31055))
		xbmc.executebuiltin('XBMC.Notification('+name+','+xbmc.getLocalizedString(31048)+')')
		return 1
	except:
		dp.close()
		xbmcgui.Dialog().ok(xbmc.getLocalizedString(31047),xbmc.getLocalizedString(31054),xbmc.getLocalizedString(31056))
		xbmc.executebuiltin('XBMC.Notification('+xbmc.getLocalizedString(31047)+','+xbmc.getLocalizedString(31053)+')')
		return 0


def _pbhook(numblocks, blocksize, filesize, url=None,dp=None):
	try:
		percent = min((numblocks*blocksize*100)/float(filesize), 100)
		dp.update(int(percent))
	except:
		percent = 100
		dp.update(percent)
	if dp.iscanceled():
		raise IOError


def getList():
	themedata = urllib.urlopen(base_url)
	themelist = themedata.read()
	themedata.close()
	try:
		ItemList = re.compile('<themename>(.*)</themename><path>(.*)</path><filename>(.*)</filename>', re.IGNORECASE).findall(themelist)
	except:
		return [],[],[]
	path_list = []
	themename_list = []
	filename_list = []
	for x in ItemList:
		path_list.append(x[1])
		themename_list.append(x[0])
		filename_list.append(x[2])
	return themename_list,filename_list,path_list


def main():
	try:
		themename_list,filename_list,path_list = getList()
		if not themename_list == []:
			themeid = xbmcgui.Dialog().select(xbmc.getLocalizedString(31047),themename_list)
			filesplit = os.path.splitext(filename_list[themeid])
			if themeid == -1:
				return
			elif os.path.exists("Q:\\skin\\"+currentskin+"\\media\\"+filesplit[0]+".xpr"):
				xbmcgui.Dialog().ok(xbmc.getLocalizedString(31047),xbmc.getLocalizedString(31049),xbmc.getLocalizedString(31055))
				return
			else:
				DownloaderClass(path_list[themeid],filename_list[themeid],themename_list[themeid])
		else:
			xbmcgui.Dialog().ok(xbmc.getLocalizedString(31047),xbmc.getLocalizedString(31050))
	except:
		xbmcgui.Dialog().ok(xbmc.getLocalizedString(31047),xbmc.getLocalizedString(31057),xbmc.getLocalizedString(31058))


if __name__ == "__main__":
	try:
		main()
	finally:
		shutil.rmtree(temp,True)
