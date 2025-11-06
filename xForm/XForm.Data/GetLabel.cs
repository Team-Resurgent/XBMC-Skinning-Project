using System;
using System.Data;

namespace XForm.Data
{
	/// <summary>
	/// Summary description for GetLabel.
	/// </summary>
	public class GetLabel
	{
		private String path;

		public String Path
		{
			get {return(this.path);}
			set	{this.path = value;}
		}

		public GetLabel()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public String GetLabelFromValue(Int32 label, String path)
		{
			if (label != 9999)
			{
				DataSet dsStrings = new DataSet("string");

				dsStrings.ReadXml(this.path + @"\strings.xml");

				Int32 j = dsStrings.Tables[0].Rows.Count;

				for (Int32 i = 0; i < j; i++)
				{

					DataRow	drLabels = dsStrings.Tables[0].Rows[i];

					if(drLabels["ID"].ToString() == label.ToString())
					{
						return (drLabels["value"].ToString());
					}
				}

				dsStrings.Dispose();

				return ("hello");
			}
			else
			{
				return ("-");
			}
		}

		public String GetValueFromLabel(String label)
		{
			DataSet dsStrings = new DataSet("string");

			dsStrings.ReadXml(this.path + @"\strings.xml");

			Int32 j = dsStrings.Tables[0].Rows.Count;

			for (Int32 i = 0; i < j; i++)
			{

				DataRow	drLabels = dsStrings.Tables[0].Rows[i];

				if(drLabels["value"].ToString() == label)
				{
					return (Convert.ToString(drLabels["ID"]));
				}
			}

			dsStrings.Dispose();

			return ("-");
		}
	}
}
