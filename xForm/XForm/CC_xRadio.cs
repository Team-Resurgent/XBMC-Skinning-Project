using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

using XForm.Data;

namespace XForm
{
	/// <summary>
	/// Summary description for XRadio.
	/// </summary>
	public class CC_xRadio : System.Windows.Forms.UserControl
	{
		private System.ComponentModel.IContainer components;

		private System.Windows.Forms.Label LblLabel;
		private System.Windows.Forms.PictureBox PboxImage;
		
		private XRadio xb;
		private System.Windows.Forms.ToolTip toolTips;
		private System.Windows.Forms.PictureBox pBoxBackimage;
		private FrmDesign frmdesign;

		public FrmDesign frmDesign
		{
			get {return(this.frmdesign);}
			set	{this.frmdesign = value;}
		}

		public XRadio XB
		{
			get {return(this.xb);}
			set	
			{
				this.xb = value;
				this.UpdateControl();
			}
		}

		public CC_xRadio()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			SetStyle (ControlStyles.SupportsTransparentBackColor,true);
			SetStyle (ControlStyles.Opaque, true);
			SetStyle (ControlStyles.StandardClick, true);
			SetStyle (ControlStyles.UserMouse, true);
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x20;
				return cp;
			}
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CC_xRadio));
			this.LblLabel = new System.Windows.Forms.Label();
			this.PboxImage = new System.Windows.Forms.PictureBox();
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			this.pBoxBackimage = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// LblLabel
			// 
			this.LblLabel.BackColor = System.Drawing.Color.Transparent;
			this.LblLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LblLabel.Location = new System.Drawing.Point(20, 11);
			this.LblLabel.Name = "LblLabel";
			this.LblLabel.TabIndex = 0;
			this.LblLabel.Text = "XFormRadio";
			this.LblLabel.Click += new System.EventHandler(this.LblLabel_Click);
			// 
			// PboxImage
			// 
			this.PboxImage.Image = ((System.Drawing.Image)(resources.GetObject("PboxImage.Image")));
			this.PboxImage.Location = new System.Drawing.Point(100, 0);
			this.PboxImage.Name = "PboxImage";
			this.PboxImage.Size = new System.Drawing.Size(44, 44);
			this.PboxImage.TabIndex = 1;
			this.PboxImage.TabStop = false;
			this.PboxImage.Click += new System.EventHandler(this.PboxImage_Click);
			this.PboxImage.BackgroundImageChanged += new System.EventHandler(this.PboxImage_BackgroundImageChanged);
			// 
			// toolTips
			// 
			this.toolTips.AutomaticDelay = 50;
			this.toolTips.AutoPopDelay = 10000;
			this.toolTips.InitialDelay = 50;
			this.toolTips.ReshowDelay = 10;
			this.toolTips.ShowAlways = true;
			// 
			// pBoxBackimage
			// 
			this.pBoxBackimage.Image = ((System.Drawing.Image)(resources.GetObject("pBoxBackimage.Image")));
			this.pBoxBackimage.Location = new System.Drawing.Point(61, 1);
			this.pBoxBackimage.Name = "pBoxBackimage";
			this.pBoxBackimage.Size = new System.Drawing.Size(38, 44);
			this.pBoxBackimage.TabIndex = 2;
			this.pBoxBackimage.TabStop = false;
			this.pBoxBackimage.Click += new System.EventHandler(this.PboxImage_Click);
			// 
			// CC_xRadio
			// 
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.PboxImage);
			this.Controls.Add(this.LblLabel);
			this.Controls.Add(this.pBoxBackimage);
			this.Name = "CC_xRadio";
			this.Size = new System.Drawing.Size(145, 46);
			this.Click += new System.EventHandler(this.CC_xMark_Click);
			this.Load += new System.EventHandler(this.XCheckMark_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void XCheckMark_Load(object sender, System.EventArgs e)
		{
			this.BackColor = Color.Transparent;
		}

		private void PboxImage_BackgroundImageChanged(object sender, System.EventArgs e)
		{
		
		}

		private void CC_xMark_Click(object sender, System.EventArgs e)
		{
		
		}

		public void UpdateControl()
		{
			String imagePath;
			String imageBackdrop;
			String labeltext;
			Boolean reverse;

			this.Location = new Point(Convert.ToInt32(xb.Xpos), Convert.ToInt32(xb.Ypos));
			this.ForeColor = Color.FromArgb(xb.XColor[0].A,xb.XColor[0].R, xb.XColor[0].G, xb.XColor[0].B);
			imagePath = xb.Picture["textureRadioFocus"].Path;
			imageBackdrop = xb.Picture["textureFocus"].Path;
			reverse = Convert.ToBoolean(xb.Reverse);

			if (xb.Labeltext != "No Label")
			{
				labeltext = xb.Labeltext;
			}
			else
			{
				labeltext = "";
			}

			if (Path.GetFileNameWithoutExtension(imageBackdrop) != "-")
			{
				this.pBoxBackimage.Image = Image.FromFile(imageBackdrop);
				this.pBoxBackimage.Size = new Size(Image.FromFile(imageBackdrop).Width, Image.FromFile(imageBackdrop).Height);
				this.pBoxBackimage.Location = new Point(0,0);
				this.Size = this.pBoxBackimage.Size;
			}

			if (Path.GetFileNameWithoutExtension(imagePath) != "-")
			{
				this.PboxImage.Image = Image.FromFile(imagePath);
				this.PboxImage.Size = new Size(Image.FromFile(imagePath).Width, Image.FromFile(imagePath).Height);
			}

			this.LblLabel.Text = labeltext;
			this.LblLabel.Font = new Font("Ariel",Convert.ToInt32(xb.Font));
			this.LblLabel.Width = this.LblLabel.PreferredWidth;
			this.LblLabel.Height = this.LblLabel.PreferredHeight;
			this.LblLabel.ForeColor = this.ForeColor;
			this.LblLabel.BackColor = Color.Transparent;

			if (reverse)
			{
				this.PboxImage.Location = new Point(this.Width - this.PboxImage.Width - 5 , (this.Height /2) - (this.PboxImage.Height /2));
				this.LblLabel.Location = new Point(3,(this.Height /2) - (this.LblLabel.Height /2));
			}
			else
			{
				this.PboxImage.Location = new Point(5,(this.Height /2) - (this.PboxImage.Height /2));		
				this.LblLabel.Location = new Point(this.PboxImage.Size.Width + 7,(this.Height /2) - (this.LblLabel.Height /2));
			}

			String Popup;

			Popup = xb.Description + @" ~ ID " + xb.Tag;

			this.toolTips.SetToolTip (this.LblLabel, Popup);
			this.toolTips.SetToolTip (this.PboxImage, Popup);
			this.toolTips.SetToolTip (this.pBoxBackimage, Popup);
			this.toolTips.SetToolTip (this, Popup);

			frmDesign.Update();

			

		}

		private void LblLabel_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void PboxImage_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void OpenEditDialog()
		{
			FrmxRadio frmXRadio = new FrmxRadio();

			frmXRadio.EDIT = true;
			frmXRadio.cc_XRadio = this;
			frmXRadio.F = frmdesign;

			frmXRadio.XB = this.xb;
			frmXRadio.Show();
		}
	}
}