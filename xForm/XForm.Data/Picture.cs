using System;

namespace XForm.Data
{
	/// <summary>
	/// Summary description for Picture.
	/// </summary>
	public class Picture
	{
		private String path;
		private String picxpos;
		private String picypos;
		private String spacex;
		private String spacey;

		private String pichieght;
		private String picwidth;

		public Picture()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public String Pichieght
		{
			get {return(this.pichieght);}
			set	{this.pichieght = value;}
		}

		public String Picwidth
		{
			get {return(this.picwidth);}
			set	{this.picwidth = value;}
		}

		public String Path
		{
			get {return(this.path);}
			set	{this.path = value;}
		}

		public String Picxpos
		{
			get {return(this.picxpos);}
			set	{this.picxpos = value;}
		}
		
		public String Picypos
		{
			get {return(this.picypos);}
			set	{this.picypos = value;}
		}

		public String Spacex
		{
			get {return(this.spacex);}
			set	{this.spacex = value;}
		}
		
		public String Spacey
		{
			get {return(this.spacey);}
			set	{this.spacey = value;}
		}

	}
}
