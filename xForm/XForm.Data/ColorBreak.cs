using System;

namespace XForm.Data
{
	/// <summary>
	/// Summary description for ColorBreak.
	/// </summary>
	public class ColorBreak
	{
		public ColorBreak()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public XColor BreakColor(XColor xc, String Color)
		{
			Int32 A,R,G,B;
			String a,r,g,b;

			a = Color.Substring(0,2);
			r = Color.Substring(2,2);
			g = Color.Substring(4,2);
			b = Color.Substring(6,2);

			A = Convert.ToInt32 (a,16);
			R = Convert.ToInt32 (r,16);
			G = Convert.ToInt32 (g,16);
			B = Convert.ToInt32 (b,16);

			xc.A = A;
			xc.R = R;
			xc.G = G;
			xc.B = B;

			xc.Color = Color;

			return (xc);
		}
	}
}
