using System;

namespace XForm.Data
{
	/// <summary>
	/// Summary description for Color.
	/// </summary>
	public class XColor
	{
		private Int32 r;
		private Int32 g;
		private Int32 b;
		private Int32 a;

		private String color;

		public XColor()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public Int32 R
		{
			get {return(this.r);}
			set	{this.r = value;}
		}

		public Int32 G
		{
			get {return(this.g);}
			set	{this.g = value;}
		}

		public Int32 B
		{
			get {return(this.b);}
			set	{this.b = value;}
		}

		public Int32 A
		{
			get {return(this.a);}
			set	{this.a = value;}
		}

		public String Color
		{
			get {return(this.color);}
			set	{this.color = value;}
		}
	}
}
