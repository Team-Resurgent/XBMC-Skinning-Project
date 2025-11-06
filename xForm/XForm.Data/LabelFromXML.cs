using System;
using System.Data;

namespace XForm.Data
{
	/// <summary>
	/// Summary description for LabelFromXML.
	/// </summary>
	public class LabelFromXML
	{
		public LabelFromXML()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public String[] labelFromXML(String path)
		{
			DataSet ds = new DataSet("string");

			ds.ReadXml(path);
		
			Int32 j = ds.Tables[0].Rows.Count;

			String[] LabelArray = new String[j];
	
			for (Int32 i = 0; i < j; i++)
			{

				DataRow	drLabels = ds.Tables[0].Rows[i];

				if(drLabels["value"].ToString()!="0")
				{
					LabelArray[i] = (drLabels["value"].ToString());
				}
			}

			ds.Dispose();

			return (LabelArray);
		}
	}
}
