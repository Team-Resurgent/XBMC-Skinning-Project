using System;
using System.IO;

namespace XForm.Data
{
	/// <summary>
	/// Summary description for GetFontList.
	/// </summary>
	public class GetFontList
	{
		public GetFontList()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public String[] getFontList() //String path
		{
			String [] FontArray = new String [8];

			FontArray[0] = "10";
			FontArray[1] = "12";
			FontArray[2] = "13";
			FontArray[3] = "14";
			FontArray[4] = "15";
			FontArray[5] = "18";
			FontArray[6] = "64";

//			if (Directory.GetFiles(path + @"\fonts\",@"*.xpr").Length >0)
//			{
//				Int32 j =Directory.GetFiles(path + @"\fonts\",@"*.xpr").Length;
//
//				String [] FontArray = new String [j];
//
//				for (Int32 i = 0; i < j; i++)
//				{
//					FontArray[i] = Path.GetFileName(Directory.GetFiles(path + @"\fonts\",@"*.xpr")[i]);
//				}
//
				return (FontArray);
//			}
//			else
//			{
//				return (null);
//			}
		}
	}
}
