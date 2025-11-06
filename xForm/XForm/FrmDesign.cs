using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using XForm.Data;

namespace XForm
{
	/// <summary>
	/// Summary description for FrmDesign.
	/// </summary>
	public class FrmDesign : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList ImgList;
		private FrmDesign f;
		private FrmMain m;
		private System.Windows.Forms.ToolTip toolTips;

		public Skin skin;

		public FrmMain M
		{
			get {return(this.m);}
			set	{this.m = value;
				 m.SKIN = skin;
				}
		}


		public FrmDesign()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmDesign));
			this.ImgList = new System.Windows.Forms.ImageList(this.components);
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			// 
			// ImgList
			// 
			this.ImgList.ImageSize = new System.Drawing.Size(64, 64);
			this.ImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgList.ImageStream")));
			this.ImgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// toolTips
			// 
			this.toolTips.AutomaticDelay = 50;
			this.toolTips.AutoPopDelay = 10000;
			this.toolTips.InitialDelay = 50;
			this.toolTips.ReshowDelay = 10;
			this.toolTips.ShowAlways = true;
			// 
			// FrmDesign
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(732, 542);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(50, 50);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmDesign";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "xForm Design Window";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmDesign_Closing);
			this.Load += new System.EventHandler(this.FrmDesign_Load);

		}
		#endregion

		private void btnButton_Click(object sender, System.EventArgs e)
		{

		}

		public void RemoveLast()
		{
			this.Controls.RemoveAt(this.Controls.Count -1);
		}

		public void RemoveObject(Int32 ControlNo)
		{
			this.Controls.RemoveAt(ControlNo);
		}

		public void SaveXButton(XButton xb)
		{
			skin.XButtons.Add(xb.Description,xb);
		}

		public void SaveXImage(XImage xb)
		{
			skin.XImage.Add(xb.ID.ToString(),xb);
		}

		public void SaveXLabel(XLabel xb)
		{
			skin.XLabel.Add(xb.ID.ToString(),xb);
		}

		public void SaveXFadeLabel(XFadeLabel xb)
		{
			skin.XFadeLabel.Add(xb.ID.ToString(),xb);
		}

		public void SaveXMark(Xmark xb)
		{
			skin.Xmark.Add(xb.ID.ToString(),xb);
		}

		public void SaveXRadio(XRadio xb)
		{
			skin.XRadio.Add(xb.ID.ToString(),xb);
		}

		public void SaveXRss(XRss xb)
		{
			skin.XRss.Add(xb.ID.ToString(),xb);
		}

		public void SaveXSelectButton(XSelectButton xb)
		{
			skin.XSelectButton.Add(xb.ID.ToString(),xb);
		}

		public void SaveXButtonT(XButtonT xb)
		{
			skin.XButtonT.Add(xb.ID.ToString(),xb);
		}

		public void SaveXSpinControl(XSpinControl xb)
		{
			skin.XSpinControl.Add(xb.ID.ToString(),xb);
		}

		public void SaveXSpinButton(XSpinButton xb)
		{
			skin.XSpinButton.Add(xb.ID.ToString(),xb);
		}

		public void SaveXListControl(XListControl xb)
		{
			skin.XListControl.Add(xb.ID.ToString(),xb);
		}

		public void SaveXthumbnail(Xthumbnail xb)
		{
			skin.XThumbnail.Add(xb.ID.ToString(),xb);
		}

		public void RemoveXButton(XButton xb)
		{
			skin.XButtons.Remove(xb.Description);
		}

		public void RemoveXImage(XImage xb)
		{
			skin.XImage.Remove(xb.ID.ToString());
		}

		public void RemoveXLabel(XLabel xb)
		{
			skin.XLabel.Remove(xb.ID.ToString());
		}

		public void RemoveXFadeLabel(XFadeLabel xb)
		{
			skin.XFadeLabel.Remove(xb.ID.ToString());
		}

		public void RemoveXMark(Xmark xb)
		{
			skin.Xmark.Remove(xb.ID.ToString());
		}

		public void RemoveXRss(XRss xb)
		{
			skin.XRss.Remove(xb.ID.ToString());
		}

		public void RemoveXSelectButton(XSelectButton xb)
		{
			skin.XSelectButton.Remove(xb.ID.ToString());
		}

		public void RemoveXButtonT(XButtonT xb)
		{
			skin.XButtonT.Remove(xb.ID.ToString());
		}

		public void RemoveXSpinControl(XSpinControl xb)
		{
			skin.XSpinControl.Remove(xb.ID.ToString());
		}

		public void RemoveXSpinButton(XSpinButton xb)
		{
			skin.XSpinButton.Remove(xb.ID.ToString());
		}

		public void RemoveXListControl(XListControl xb)
		{
			skin.XListControl.Remove(xb.ID.ToString());
		}

		public void RemoveXthumbnail(Xthumbnail xb)
		{
			skin.XThumbnail.Remove(xb.ID.ToString());
		}


		public void AddXButton(XButton xb, FrmXButton form)
		{
			CC_xButton b = new CC_xButton();
			b.frmDesign = this;
			b.XB = xb;
			

			b.Tag = Convert.ToString(this.Controls.Count + 1);
			xb.Tag = (this.Controls.Count);

			this.Controls.Add(b);

			if (form != null)
			{
				form.cc_XButton = b;
			}
		}

		public void AddXthumbnail(Xthumbnail xb, FrmXThumbnail form)
		{
			CC_xThumbnail b = new CC_xThumbnail();
			b.frmDesign = this;
			b.XB = xb;


			b.Tag = Convert.ToString(this.Controls.Count + 1);
			xb.Tag = (this.Controls.Count);

			this.Controls.Add(b);

			if (form != null)
			{
				form.cc_XThumbnail = b;
			}
		}

		public void AddXListControl(XListControl xb, FrmXListControl form)
		{
			CC_xListControl b = new CC_xListControl();
			b.frmDesign = this;
			b.XB = xb;


			b.Tag = Convert.ToString(this.Controls.Count + 1);
			xb.Tag = (this.Controls.Count);

			this.Controls.Add(b);

			if (form != null)
			{
				form.cc_XListControl = b;
			}
		}

		public void AddXSpinButton(XSpinButton xb, FrmXSpinButton form)
		{
//			CC_xSpinButton b = new CC_xSpinButton();
//	//			b.frmDesign = this;		
//			b.XB = xb;

//
//			b.Tag = Convert.ToString(this.Controls.Count + 1);
//			xb.Tag = (this.Controls.Count);
//
//			this.Controls.Add(b);

			if (form != null)
			{
				//			form.cc_XSpinButton = b;
			}
		}

		public void AddXSpinControl(XSpinControl xb, FrmXSpinControl form)
		{
			CC_xSpinControl b = new CC_xSpinControl();
			b.frmDesign = this;
			b.XB = xb;


			b.Tag = Convert.ToString(this.Controls.Count + 1);
			xb.Tag = (this.Controls.Count);

			this.Controls.Add(b);

			if (form != null)
			{
				form.cc_XSpinControl = b;
			}
		}

		public void AddXButtonT(XButtonT xb, FrmXButtonT form)
		{
//			Button b = new Button();
//
//			b.Size = new Size(Convert.ToInt32(xb.XWidth), Convert.ToInt32(xb.YHieght));
//			b.Location = new Point(Convert.ToInt32(xb.Xpos), Convert.ToInt32(xb.Ypos));
//			b.Name = xb.Description;
//			b.frmDesign = this;
//
//
//			b.Tag = Convert.ToString(this.Controls.Count + 1);
//			b.Click +=new EventHandler(ButtonT_Click);
//
			if (form != null)
			{
				//			form.cc_XButton = b;
			}
		}

		public void AddXSelectButton(XSelectButton xb, FrmXSelectButton form)
		{
			CC_xSelectButton b = new CC_xSelectButton();
			b.frmDesign = this;
			b.XB = xb;
			

			b.Tag = Convert.ToString(this.Controls.Count + 1);
			xb.Tag = (this.Controls.Count);

			this.Controls.Add(b);

			if (form != null)
			{
				form.cc_XSelectButton = b;
			}
		}

		public void AddXLabel(XLabel xb, FrmXLabel form)
		{
			CC_xLabel b = new CC_xLabel();
			b.frmDesign = this;
			b.XB = xb;
			

			b.Tag = Convert.ToString(this.Controls.Count + 1);
			xb.Tag = (this.Controls.Count);

			this.Controls.Add(b);

			if (form != null)
			{
				form.cc_XLabel = b;
			}
		}

		public void AddXFadeLabel(XFadeLabel xb, FrmXFadeLabel form)
		{
			CC_xFadeLabel b = new CC_xFadeLabel();
			b.frmDesign = this;
			b.XB = xb;
			

			b.Tag = Convert.ToString(this.Controls.Count + 1);
			xb.Tag = (this.Controls.Count);

			this.Controls.Add(b);

			if (form != null)
			{
				form.cc_XFadeLabel = b;
			}
		}

		public void AddXRss(XRss xb, FrmXRss form)
		{
			CC_xRss b = new CC_xRss();
			b.frmDesign = this;
			b.XB = xb;
			

			b.Tag = Convert.ToString(this.Controls.Count + 1);
			xb.Tag = (this.Controls.Count);

			this.Controls.Add(b);

			if (form != null)
			{
				form.cc_XRss = b;
			}
		}

		public void AddXImage(XImage xb, FrmXImage form)
		{
			CC_xImage b = new CC_xImage();
			b.frmDesign = this;
			b.XB = xb;
			

			b.Tag = Convert.ToString(this.Controls.Count + 1);
			xb.Tag = (this.Controls.Count);

			this.Controls.Add(b);

			if (form != null)
			{
				form.CC_XImage = b;
			}

		}

		public void AddXMark(Xmark xb, FrmXMark form)
		{
			CC_xMark b = new CC_xMark();
			b.frmDesign = this;
			b.XB = xb;
			

			b.Tag = Convert.ToString(this.Controls.Count + 1);
			xb.Tag = (this.Controls.Count);

			this.Controls.Add(b);

			if (form != null)
			{
				form.cc_XMark = b;
			}
		}

		public void AddXRadio(XRadio xb, FrmxRadio form)
		{
			CC_xRadio b = new CC_xRadio();
			b.frmDesign = this;
			b.XB = xb;
			

			b.Tag = Convert.ToString(this.Controls.Count + 1);
			xb.Tag = (this.Controls.Count);

			this.Controls.Add(b);

			if (form != null)
			{
				form.cc_XRadio = b;
			}
		}

		public FrmDesign F
		{
			get {return this.f;}
			set {this.f = value;}
		}

		private void FrmDesign_Load(object sender, System.EventArgs e)
		{
			skin = new Skin();
			skin.AppPath = Application.StartupPath;
			skin.Projectpath = m.ProjectPath;
		}

		public void UpDateBG()
		{
			this.BackgroundImage = Image.FromFile(skin.Picture[0].Path);
			this.toolTips.SetToolTip(this,"ID " + skin.ID + "\r\n Default Control " + skin.Control);
		}

		public void SkinSave()
		{
			if(skin.Save())
			{
				MessageBox.Show("Save Successful");
			}
			else
			{
				MessageBox.Show("Save Failed");
			}
		}

		public void SkinLoad(String path, String projectpath)
		{
			skin.Path = path;
			skin.Projectpath = projectpath;
			skin = skin.Load();
		}

		private void FrmDesign_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			m.SKIN = null;
		}

		public void Rebuildskin()
		{
			if (skin.XButtons != null )
			{
				for (Int32 i = 0;i < skin.XButtons.Count; i ++)
				{
					this.AddXButton(skin.XButtons[i], null);
				}
			}
			
			if (skin.XButtonT != null )
			{
				for (Int32 i = 0;i < skin.XButtonT.Count; i ++)
				{
					this.AddXButtonT(skin.XButtonT[i], null);
				}
			}

			if (skin.XFadeLabel != null )
			{
				for (Int32 i = 0;i < skin.XFadeLabel.Count; i ++)
				{
					this.AddXFadeLabel(skin.XFadeLabel[i], null);
				}
			}

			if (skin.XImage != null )
			{
				for (Int32 i = 0;i < skin.XImage.Count; i ++)
				{
					this.AddXImage(skin.XImage[i], null);
				}
			}

			if (skin.XLabel != null )
			{
				for (Int32 i = 0;i < skin.XLabel.Count; i ++)
				{
					this.AddXLabel(skin.XLabel[i], null);
				}
			}

			if (skin.XListControl != null )
			{
				for (Int32 i = 0;i < skin.XListControl.Count; i ++)
				{
					this.AddXListControl(skin.XListControl[i], null);
				}
			}

			if (skin.Xmark != null )
			{
				for (Int32 i = 0;i < skin.Xmark.Count; i ++)
				{
					this.AddXMark(skin.Xmark[i], null);
				}
			}

			if (skin.XRss != null )
			{
				for (Int32 i = 0;i < skin.XRss.Count; i ++)
				{
					this.AddXRss(skin.XRss[i], null);
				}
			}

			if (skin.XSelectButton != null )
			{
				for (Int32 i = 0;i < skin.XSelectButton.Count; i ++)
				{
					this.AddXSelectButton(skin.XSelectButton[i], null);
				}
			}

			if (skin.XSpinControl != null )
			{
				for (Int32 i = 0;i < skin.XSpinControl.Count; i ++)
				{
					this.AddXSpinControl(skin.XSpinControl[i], null);
				}
			}

			if (skin.XThumbnail != null )
			{
				for (Int32 i = 0;i < skin.XThumbnail.Count; i ++)
				{
					this.AddXthumbnail(skin.XThumbnail[i], null);
				}
			}

			if (skin.XRadio != null )
			{
				for (Int32 i = 0;i < skin.XRadio.Count; i ++)
				{
					this.AddXRadio(skin.XRadio[i], null);
				}
			}
		}
	}
}
