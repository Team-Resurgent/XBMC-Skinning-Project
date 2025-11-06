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
	public class CC_xSpinControl : System.Windows.Forms.UserControl
	{
		private XSpinControl xb;

		private System.Windows.Forms.PictureBox PboxImage;
		private System.Windows.Forms.PictureBox PboxImage2;

		private FrmDesign frmdesign;

		public FrmDesign frmDesign
		{
			get {return(this.frmdesign);}
			set	{this.frmdesign = value;}
		}

		public XSpinControl XB
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

		public CC_xSpinControl()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CC_xSpinControl));
			this.PboxImage = new System.Windows.Forms.PictureBox();
			this.PboxImage2 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// PboxImage
			// 
			this.PboxImage.Image = ((System.Drawing.Image)(resources.GetObject("PboxImage.Image")));
			this.PboxImage.Location = new System.Drawing.Point(0, 0);
			this.PboxImage.Name = "PboxImage";
			this.PboxImage.Size = new System.Drawing.Size(44, 44);
			this.PboxImage.TabIndex = 0;
			this.PboxImage.TabStop = false;
			this.PboxImage.Click += new System.EventHandler(this.PboxImage_Click);
			// 
			// PboxImage2
			// 
			this.PboxImage2.Image = ((System.Drawing.Image)(resources.GetObject("PboxImage2.Image")));
			this.PboxImage2.Location = new System.Drawing.Point(46, 0);
			this.PboxImage2.Name = "PboxImage2";
			this.PboxImage2.Size = new System.Drawing.Size(44, 44);
			this.PboxImage2.TabIndex = 1;
			this.PboxImage2.TabStop = false;
			this.PboxImage2.Click += new System.EventHandler(this.PboxImage2_Click);
			// 
			// CC_xSpinControl
			// 
			this.Controls.Add(this.PboxImage2);
			this.Controls.Add(this.PboxImage);
			this.Name = "CC_xSpinControl";
			this.Size = new System.Drawing.Size(90, 44);
			this.Click += new System.EventHandler(this.CC_xSpinControl_Click);
			this.Load += new System.EventHandler(this.CC_xSelectButton_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void CC_xSelectButton_Load(object sender, System.EventArgs e)
		{
		
		}

		public void UpdateControl()
		{
			String imagePath;
			String imagePath2;

			Boolean reverse;

			this.Location = new Point(Convert.ToInt32(xb.Xpos), Convert.ToInt32(xb.Ypos));
			this.ForeColor = Color.FromArgb(xb.XColor[0].A,xb.XColor[0].R, xb.XColor[0].G, xb.XColor[0].B);
			imagePath = xb.Picture[0].Path;
			imagePath2 = xb.Picture[1].Path;
			reverse = Convert.ToBoolean(xb.Reverse);

			if (Path.GetFileNameWithoutExtension(imagePath) != "-")
			{
				this.PboxImage.Image = Image.FromFile(imagePath);
				this.PboxImage.Size = new Size(Image.FromFile(imagePath).Width, Image.FromFile(imagePath).Height);
				this.Size = new Size(this.PboxImage.Size.Width + this.PboxImage2.Size.Width + 1, this.PboxImage.Size.Height + this.PboxImage2.Size.Height);
			}

			if (Path.GetFileNameWithoutExtension(imagePath2) != "-")
			{
				this.PboxImage2.Image = Image.FromFile(imagePath2);
				this.PboxImage2.Size = new Size(Image.FromFile(imagePath2).Width, Image.FromFile(imagePath2).Height);
				this.Size = new Size(this.PboxImage.Size.Width + this.PboxImage2.Size.Width + 1, this.PboxImage.Size.Height + this.PboxImage2.Size.Height);
			}
		
			if (reverse)
			{
				this.PboxImage.Location = new Point(0 , 0);
				this.PboxImage2.Location = new Point(this.PboxImage.Size.Width + 1,0);

			}
			else
			{
				this.PboxImage2.Location = new Point(0,0);
				this.PboxImage.Location = new Point(this.PboxImage2.Size.Width + 1,0);
			}

			if (frmDesign != null)
			{
				frmDesign.Update();
			}
		}

		private void PboxImage_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void PboxImage2_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void CC_xSpinControl_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void OpenEditDialog()
		{
			FrmXSpinControl frmXSpinControl = new FrmXSpinControl();

			frmXSpinControl.EDIT = true;
			frmXSpinControl.cc_XSpinControl = this;
			frmXSpinControl.F = frmdesign;

			frmXSpinControl.XB = this.xb;
			frmXSpinControl.Show();
		}
	}
}
