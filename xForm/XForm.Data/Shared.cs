using System;

namespace XForm.Data
{
	/// <summary>
	/// Summary description for Shared.
	/// </summary>
	public class Shared
	{
		private Int32 tag;

		private String id;
		private String xpos;
		private String ypos;
		private String xwidth;
		private String yhieght;
		private String up;
		private String down;
		private String left;
		private String right;
        private String xoffset;
		private String yoffset;
		private String suffix;

		private XColorCollection xColorCollection;
		private PictureCollection pictureCollection;
		private String hyperlink;
		private String labeltext;
		private String font;
		private String feed;
		private String align;
		private String description;
		private String subtype;

		private String reverse;
		private String visible;
		private String shadow;

		private Boolean save;

		protected Shared()
		{
			
		}

		public Boolean Save
		{
			get {return(this.save);}
			set	{this.save = value;}
		}

		public Int32 Tag
		{
			get {return(this.tag);}
			set	{this.tag = value;}
		}

		public String ID
		{
			get {return(this.id);}
			set	{this.id = value;}
		}

		public String Suffix
		{
			get {return(this.suffix);}
			set	{this.suffix = value;}
		}

		public String Xpos
		{
			get {return(this.xpos);}
			set	{this.xpos = value;}
		}

		public String Ypos
		{
			get {return(this.ypos);}
			set	{this.ypos = value;}
		}

		public String YHieght
		{
			get {return(this.yhieght);}
			set	{this.yhieght = value;}
		}

		public String XWidth
		{
			get {return(this.xwidth);}
			set	{this.xwidth = value;}
		}

		public String Up
		{
			get {return(this.up);}
			set	{this.up = value;}
		}

		public String Down
		{
			get {return(this.down);}
			set	{this.down = value;}
		}

		public String Left
		{
			get {return(this.left);}
			set	{this.left = value;}
		}

		public String Right
		{
			get {return(this.right);}
			set	{this.right = value;}
		}

		public String XOffset
		{
			get {return(this.xoffset);}
			set	{this.xoffset = value;}
		}

		public String YOffset
		{
			get {return(this.yoffset);}
			set	{this.yoffset = value;}
		}

		public String Font
		{
			get {return(this.font);}
			set	{this.font = value;}
		}

		public String Feed
		{
			get {return(this.feed);}
			set	{this.feed = value;}
		}

		public String Align
		{
			get {return(this.align);}
			set	{this.align = value;}
		}

		public String Hyperlink
		{
			get {return(this.hyperlink);}
			set	{this.hyperlink = value;}
		}

		public String Labeltext
		{
			get {return(this.labeltext);}
			set	{this.labeltext = value;}
		}

		public String Description
		{
			get {return(this.description);}
			set	{this.description = value;}
		}

		public String Subtype
		{
			get {return(this.subtype);}
			set	{this.subtype = value;}
		}

		public String Reverse
		{
			get {return(this.reverse);}
			set	{this.reverse = value;}
		}

		public String Visible
		{
			get {return(this.visible);}
			set	{this.visible = value;}
		}

		public String Shadow
		{
			get {return(this.shadow);}
			set	{this.shadow = value;}
		}

		public XColorCollection XColor
		{
			get 
			{
				if (this.xColorCollection == null)
				{
					this.xColorCollection = new XColorCollection();
				}

				return (this.xColorCollection);
			}
			set
			{
				this.xColorCollection = value;
			}
		}

		public PictureCollection Picture
		{
			get 
			{
				if (this.pictureCollection == null)
				{
					this.pictureCollection = new PictureCollection();
				}

				return (this.pictureCollection);
			}
			set
			{
				this.pictureCollection = value;
			}
		}

	}
}
