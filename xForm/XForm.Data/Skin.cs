using System;

namespace XForm.Data
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Skin
	{
		private XButtonCollection xButtonCollection;
		private XImageCollection xImageCollection;
		private XLabelCollection xLabelCollection;
		private XColorCollection xColorCollection;
		private PictureCollection pictureCollection;
		private XButtonMCollection xButtonMCollection;
		private XButtonTCollection xButtonTCollection;
		private XFadeLabelCollection xFadeLabelCollection;
		private XListControlCollection xListControlCollection;
		private XmarkCollection xmarkCollection;
		private XProgressCollection xProgressCollection;
		private XRadioCollection xRadioCollection;
		private XRamCollection xRamCollection;
		private XRssCollection xRssCollection;
		private XSelectButtonCollection xSelectButtonCollection;
		private XSliderCollection xSliderCollection;
		private XSpinButtonCollection xSpinButtonCollection;
		private XSpinControlCollection xSpinControlCollection;
		private XtextAreaCollection xtextAreaCollection;
		private XthumbnailCollection xthumbnailCollection;
		private Boolean res;
		private Boolean ratio;
		//private Skin skin;

		private Int32 control;
		private Int32 id;
		private String name;
		private String path;
		private String projectpath;
		private String apppath;

		public Skin()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public Boolean Save()
		{
			XMLSave xmlsave = new XMLSave();
			if(xmlsave.SaveSkin(	name,
				path,
				projectpath,
				apppath,
				control,
				id,
				xButtonCollection,
				xImageCollection,
				xLabelCollection,
				xColorCollection,
				pictureCollection,
				xButtonMCollection,
				xButtonTCollection,
				xFadeLabelCollection,
				xListControlCollection,
				xmarkCollection,
				xProgressCollection,
				xRadioCollection,
				xRamCollection,
				xRssCollection,
				xSelectButtonCollection,
				xSliderCollection,
				xSpinButtonCollection,
				xSpinControlCollection,
				xtextAreaCollection,
				xthumbnailCollection))
			{
				return true;}
			else
			{
				return(false);
			}
		}

		public Skin Load()
		{
			XMLLoad xmlload = new XMLLoad();
			xmlload.LoadSkin(this , path, apppath, projectpath + @"media\");

			return (this);
		}

		public Int32 Control
		{
			get {return(this.control);}
			set	{this.control = value;}
		}

		public Int32 ID
		{
			get {return(this.id);}
			set	{this.id = value;}
		}

		public String Name
		{
			get {return(this.name);}
			set	{this.name = value;}
		}

		public String Path
		{
			get {return(this.path);}
			set	{this.path = value;}
		}

		public String Projectpath
		{
			get {return(this.projectpath);}
			set	{this.projectpath = value;}
		}

		public String AppPath
		{
			get {return(this.apppath);}
			set	{this.apppath = value;}
		}

		public Boolean Res
		{
			get {return(this.res);}
			set	{this.res = value;}
		}

		public Boolean Ratio
		{
			get {return(this.ratio);}
			set	{this.ratio = value;}
		}

		public XButtonCollection XButtons
		{
			get 
			{
				if (this.xButtonCollection == null)
				{
					this.xButtonCollection = new XButtonCollection();
				}

				return (this.xButtonCollection);
			}
			set
			{
				this.xButtonCollection = value;
			}
		}

		public XImageCollection XImage
		{
			get 
			{
				if (this.xImageCollection == null)
				{
					this.xImageCollection = new XImageCollection();
				}

				return (this.xImageCollection);
			}
			set
			{
				this.xImageCollection = value;
			}
		}

		public XLabelCollection XLabel
		{
			get 
			{
				if (this.xLabelCollection == null)
				{
					this.xLabelCollection = new XLabelCollection();
				}

				return (this.xLabelCollection);
			}
			set
			{
				this.xLabelCollection = value;
			}
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

		public XButtonMCollection XButtonM
		{
			get 
			{
				if (this.xButtonMCollection == null)
				{
					this.xButtonMCollection = new XButtonMCollection();
				}

				return (this.xButtonMCollection);
			}
			set
			{
				this.xButtonMCollection = value;
			}
		}

		public XButtonTCollection XButtonT
		{
			get 
			{
				if (this.xButtonTCollection == null)
				{
					this.xButtonTCollection = new XButtonTCollection();
				}

				return (this.xButtonTCollection);
			}
			set
			{
				this.xButtonTCollection = value;
			}
		}

		public XFadeLabelCollection XFadeLabel
		{
			get 
			{
				if (this.xFadeLabelCollection == null)
				{
					this.xFadeLabelCollection = new XFadeLabelCollection();
				}

				return (this.xFadeLabelCollection);
			}
			set
			{
				this.xFadeLabelCollection = value;
			}
		}

		public XListControlCollection XListControl
		{
			get 
			{
				if (this.xListControlCollection == null)
				{
					this.xListControlCollection = new XListControlCollection();
				}

				return (this.xListControlCollection);
			}
			set
			{
				this.xListControlCollection = value;
			}
		}

		public XmarkCollection Xmark
		{
			get 
			{
				if (this.xmarkCollection == null)
				{
					this.xmarkCollection = new XmarkCollection();
				}

				return (this.xmarkCollection);
			}
			set
			{
				this.xmarkCollection = value;
			}
		}

		public XProgressCollection XProgress
		{
			get 
			{
				if (this.xProgressCollection == null)
				{
					this.xProgressCollection = new XProgressCollection();
				}

				return (this.xProgressCollection);
			}
			set
			{
				this.xProgressCollection = value;
			}
		}

		public XRadioCollection XRadio
		{
			get 
			{
				if (this.xRadioCollection == null)
				{
					this.xRadioCollection = new XRadioCollection();
				}

				return (this.xRadioCollection);
			}
			set
			{
				this.xRadioCollection = value;
			}
		}

		public XRamCollection XRam
		{
			get 
			{
				if (this.xRamCollection == null)
				{
					this.xRamCollection = new XRamCollection();
				}

				return (this.xRamCollection);
			}
			set
			{
				this.xRamCollection = value;
			}
		}

		public XRssCollection XRss
		{
			get 
			{
				if (this.xRssCollection == null)
				{
					this.xRssCollection = new XRssCollection();
				}

				return (this.xRssCollection);
			}
			set
			{
				this.xRssCollection = value;
			}
		}

		public XSelectButtonCollection XSelectButton
		{
			get 
			{
				if (this.xSelectButtonCollection == null)
				{
					this.xSelectButtonCollection = new XSelectButtonCollection();
				}

				return (this.xSelectButtonCollection);
			}
			set
			{
				this.xSelectButtonCollection = value;
			}
		}

		public XSliderCollection XSlider
		{
			get 
			{
				if (this.xSliderCollection == null)
				{
					this.xSliderCollection = new XSliderCollection();
				}

				return (this.xSliderCollection);
			}
			set
			{
				this.xSliderCollection = value;
			}
		}

		public XSpinButtonCollection XSpinButton
		{
			get 
			{
				if (this.xSpinButtonCollection == null)
				{
					this.xSpinButtonCollection = new XSpinButtonCollection();
				}

				return (this.xSpinButtonCollection);
			}
			set
			{
				this.xSpinButtonCollection = value;
			}
		}

		public XtextAreaCollection XtextArea
		{
			get 
			{
				if (this.xtextAreaCollection == null)
				{
					this.xtextAreaCollection = new XtextAreaCollection();
				}

				return (this.xtextAreaCollection);
			}
			set
			{
				this.xtextAreaCollection = value;
			}
		}

		public XthumbnailCollection XThumbnail
		{
			get 
			{
				if (this.xthumbnailCollection == null)
				{
					this.xthumbnailCollection = new XthumbnailCollection();
				}

				return (this.xthumbnailCollection);
			}
			set
			{
				this.xthumbnailCollection = value;
			}
		}

		public XSpinControlCollection XSpinControl
		{
			get 
			{
				if (this.xSpinControlCollection == null)
				{
					this.xSpinControlCollection = new XSpinControlCollection();
				}

				return (this.xSpinControlCollection);
			}
			set
			{
				this.xSpinControlCollection = value;
			}
		}
	}
}
