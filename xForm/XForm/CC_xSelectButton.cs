using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;

using XForm.Data;

namespace XForm
{
	/// <summary>
	/// Summary description for CC_xSelectButton.
	/// </summary>
	public class CC_xSelectButton : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.PictureBox pBoxLeftImage;
		private System.Windows.Forms.Button BtnImage;
		private System.Windows.Forms.PictureBox pBoxRightImage;

		private XSelectButton xb;
		private FrmDesign frmdesign;

		public FrmDesign frmDesign
		{
			get {return(this.frmdesign);}
			set	{this.frmdesign = value;}
		}

		public XSelectButton XB
		{
			get {return(this.xb);}
			set	
			{
				this.xb = value;
				this.UpdateControl();
			}
		}

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CC_xSelectButton()
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
			this.pBoxLeftImage = new System.Windows.Forms.PictureBox();
			this.BtnImage = new System.Windows.Forms.Button();
			this.pBoxRightImage = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// pBoxLeftImage
			// 
			this.pBoxLeftImage.Location = new System.Drawing.Point(8, 0);
			this.pBoxLeftImage.Name = "pBoxLeftImage";
			this.pBoxLeftImage.Size = new System.Drawing.Size(44, 44);
			this.pBoxLeftImage.TabIndex = 0;
			this.pBoxLeftImage.TabStop = false;
			this.pBoxLeftImage.Click += new System.EventHandler(this.pBoxLeftImage_Click);
			// 
			// BtnImage
			// 
			this.BtnImage.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BtnImage.Location = new System.Drawing.Point(88, 40);
			this.BtnImage.Name = "BtnImage";
			this.BtnImage.TabIndex = 1;
			this.BtnImage.Text = "button1";
			this.BtnImage.Click += new System.EventHandler(this.BtnImage_Click);
			// 
			// pBoxRightImage
			// 
			this.pBoxRightImage.Location = new System.Drawing.Point(53, 53);
			this.pBoxRightImage.Name = "pBoxRightImage";
			this.pBoxRightImage.Size = new System.Drawing.Size(44, 44);
			this.pBoxRightImage.TabIndex = 2;
			this.pBoxRightImage.TabStop = false;
			this.pBoxRightImage.Click += new System.EventHandler(this.pBoxRightImage_Click);
			// 
			// CC_xSelectButton
			// 
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.pBoxRightImage);
			this.Controls.Add(this.BtnImage);
			this.Controls.Add(this.pBoxLeftImage);
			this.Name = "CC_xSelectButton";
			this.Click += new System.EventHandler(this.CC_xSelectButton_Click);
			this.Load += new System.EventHandler(this.CC_xSelectButton_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void CC_xSelectButton_Load(object sender, System.EventArgs e)
		{
			this.BackColor = Color.Transparent;
		}

		

		public void UpdateControl()
		{
			String imageLeftPath;
			String imageButtonPath;
			String imageRightPath;
			String labeltext;

			this.Location = new Point(Convert.ToInt32(xb.Xpos), Convert.ToInt32(xb.Ypos));
			this.ForeColor = Color.FromArgb(xb.XColor[0].A,xb.XColor[0].R, xb.XColor[0].G, xb.XColor[0].B);
			imageLeftPath = xb.Picture["textureLeft"].Path;
			imageRightPath = xb.Picture["textureRight"].Path;
			imageButtonPath = xb.Picture["textureFocus"].Path;

			if (xb.Labeltext != "No Label")
			{
				labeltext = xb.Labeltext;
			}
			else
			{
				labeltext = "";
			}

			this.BtnImage.Text = labeltext;

			if (Path.GetFileNameWithoutExtension(imageLeftPath) != "-")
			{
				this.pBoxLeftImage.Image = Image.FromFile(imageLeftPath);
				this.pBoxLeftImage.Size = new Size(Image.FromFile(imageLeftPath).Width, Image.FromFile(imageLeftPath).Height);
			}

			if (Path.GetFileNameWithoutExtension(imageRightPath) != "-")
			{
				this.BtnImage.Image = Image.FromFile(imageButtonPath);
				this.BtnImage.Size = new Size(Image.FromFile(imageButtonPath).Width, Image.FromFile(imageButtonPath).Height);
			}

			if (Path.GetFileNameWithoutExtension(imageRightPath) != "-")
			{
				this.pBoxRightImage.Image = Image.FromFile(imageRightPath);
				this.pBoxRightImage.Size = new Size(Image.FromFile(imageRightPath).Width, Image.FromFile(imageRightPath).Height);
			}

			this.BtnImage.Text = labeltext;
			this.BtnImage.Font = new Font("Ariel",Convert.ToInt32(xb.Font));
			
			this.pBoxLeftImage.Location = new Point(0, 0);
			this.BtnImage.Location = new Point(this.pBoxLeftImage.Width + 1, 0);
			this.pBoxRightImage.Location = new Point(this.pBoxLeftImage.Width + 1 + this.BtnImage.Width, 0);

			Int32 Width = this.pBoxLeftImage.Width + 2 + this.BtnImage.Width + this.pBoxRightImage.Width;
			Int32 Hieght = this.pBoxLeftImage.Height;

			if (this.BtnImage.Height > Hieght)
			{
				Hieght = this.BtnImage.Height;
			}

			if (this.pBoxRightImage.Height > Hieght)
			{
				Hieght = this.pBoxRightImage.Height;
			}

			this.Size = new Size(Width, Hieght);

			frmDesign.Update();
		}

		private void pBoxLeftImage_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void pBoxRightImage_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void BtnImage_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void CC_xSelectButton_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void OpenEditDialog()
		{
			FrmXSelectButton frmXSelectButton = new FrmXSelectButton();

			frmXSelectButton.EDIT = true;
			frmXSelectButton.cc_XSelectButton = this;
			frmXSelectButton.F = frmdesign;

			frmXSelectButton.XB = this.xb;
			frmXSelectButton.Show();
		}
	}
}
