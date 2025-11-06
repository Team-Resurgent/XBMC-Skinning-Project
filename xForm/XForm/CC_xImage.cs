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
	/// Summary description for CC_xImage.
	/// </summary>
	public class CC_xImage : System.Windows.Forms.UserControl
	{
		private XImage xb;
		private System.Windows.Forms.PictureBox pBoxImage;

		private FrmDesign frmdesign;

		public FrmDesign frmDesign
		{
			get {return(this.frmdesign);}
			set	{this.frmdesign = value;}
		}

		public XImage XB
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

		public CC_xImage()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CC_xImage));
			this.pBoxImage = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// pBoxImage
			// 
			this.pBoxImage.Image = ((System.Drawing.Image)(resources.GetObject("pBoxImage.Image")));
			this.pBoxImage.Location = new System.Drawing.Point(0, 0);
			this.pBoxImage.Name = "pBoxImage";
			this.pBoxImage.Size = new System.Drawing.Size(44, 44);
			this.pBoxImage.TabIndex = 0;
			this.pBoxImage.TabStop = false;
			this.pBoxImage.Click += new System.EventHandler(this.pBoxImage_Click);
			// 
			// CC_xImage
			// 
			this.Controls.Add(this.pBoxImage);
			this.Name = "CC_xImage";
			this.Size = new System.Drawing.Size(44, 44);
			this.Click += new System.EventHandler(this.CC_xImage_Click);
			this.Load += new System.EventHandler(this.CC_xImage_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void CC_xImage_Load(object sender, System.EventArgs e)
		{
			this.BackColor = Color.Transparent;
		}

		public void UpdateControl()
		{
			String imagePath;

			this.Location = new Point(Convert.ToInt32(xb.Xpos), Convert.ToInt32(xb.Ypos));
			imagePath = xb.Picture[0].Path;

			if (Path.GetFileNameWithoutExtension(imagePath) != "-")
			{
				this.pBoxImage.Image = Image.FromFile(imagePath);
				this.pBoxImage.Size = new Size(Image.FromFile(imagePath).Width, Image.FromFile(imagePath).Height);
			}

			this.Size = this.pBoxImage.Size;
			frmDesign.Update();
		}

		private void pBoxImage_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void CC_xImage_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void OpenEditDialog()
		{
			FrmXImage frmXImage = new FrmXImage();

			frmXImage.EDIT = true;
			frmXImage.CC_XImage = this;
			frmXImage.F = frmdesign;

			frmXImage.XB = this.xb;
			frmXImage.Show();
		}
	}
}
