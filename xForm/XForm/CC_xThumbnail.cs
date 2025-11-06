using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using XForm.Data;

namespace XForm
{
	/// <summary>
	/// Summary description for CC_xThumbnail.
	/// </summary>
	public class CC_xThumbnail : System.Windows.Forms.UserControl
	{
		private Xthumbnail xb;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolTip toolTips;

		private FrmDesign frmdesign;

		public FrmDesign frmDesign
		{
			get {return(this.frmdesign);}
			set	{this.frmdesign = value;}
		}

		public Xthumbnail XB
		{
			get {return(this.xb);}
			set	
			{
				this.xb = value;
				this.UpdateControl();
			}
		}

		public CC_xThumbnail()
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
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			// 
			// toolTips
			// 
			this.toolTips.AutomaticDelay = 50;
			this.toolTips.AutoPopDelay = 10000;
			this.toolTips.InitialDelay = 50;
			this.toolTips.ReshowDelay = 10;
			this.toolTips.ShowAlways = true;
			// 
			// CC_xThumbnail
			// 
			this.Name = "CC_xThumbnail";
			this.Size = new System.Drawing.Size(432, 568);
			this.Click += new System.EventHandler(this.CC_xThumbnail_Click);
			this.Load += new System.EventHandler(this.CC_xThumbnail_Load);

		}
		#endregion

		private void CC_xThumbnail_Load(object sender, System.EventArgs e)
		{
			this.BackColor = Color.Transparent;
		}

		public void UpdateControl()
		{
			this.Location = new Point(Convert.ToInt32(xb.Xpos),Convert.ToInt32(xb.Ypos));
			this.Size = new Size(Convert.ToInt32(xb.XWidth),Convert.ToInt32(xb.YHieght));

			while (this.Controls.Count > 0)
			{
				this.Controls.RemoveAt(0);
			}

			Size item = new Size(Convert.ToInt32(xb.ItemWidth),Convert.ToInt32(xb.ItemHeight));
			Size texture = new Size(Image.FromFile(xb.Picture["imageFolder"].Path).Width,Image.FromFile(xb.Picture["imageFolder"].Path).Height);

			this.Size = new Size(Convert.ToInt32(xb.XWidth),Convert.ToInt32(xb.YHieght));
			this.ForeColor = Color.FromArgb(xb.XColor["textcolor"].A,xb.XColor["textcolor"].R,xb.XColor["textcolor"].G,xb.XColor["textcolor"].B);

			String picx = Convert.ToString(this.Width / Convert.ToInt32(xb.ItemWidth));
			String picy = Convert.ToString(this.Height / Convert.ToInt32(xb.ItemHeight));

			String[] tempx = (picx.Split(new char [] {'.'}));
			String[] tempy = (picy.Split(new char [] {'.'}));

			Size pics = new Size(Convert.ToInt32(tempx[0]),Convert.ToInt32(tempy[0]));

			if (item.Width < texture.Width)
			{
				item.Width = texture.Width;
				xb.ItemWidth = xb.TextureWidth;
			}
			
			if (item.Height < texture.Height)
			{
				item.Height = texture.Height;
				xb.ItemHeight = xb.TextureHeight;
			}

			Size space = new Size(item.Width - texture.Width / 2, item.Height - texture.Height / 2);

			for (Int32 x = 0; x < pics.Width; x++)
			{
				for (Int32 y = 0; y < pics.Height; y++)
				{
					if ((x * item.Width) + space.Width + texture.Width < this.Width)
					{
						if ((y * item.Height) + space.Height + texture.Height < this.Height)
						{
							PictureBox pbox = new PictureBox();

							pbox.Location = new Point((x * item.Width) + space.Width, (y * item.Height) + space.Height);
							pbox.Image = Image.FromFile(xb.Picture["imageFolder"].Path);
							pbox.Size = texture;
							pbox.BackColor = Color.Transparent;
							pbox.Click +=new EventHandler(pbox_Click);

							this.Controls.Add(pbox);

							Label label = new Label();

							label.Location = new Point((x * item.Width) + space.Width, (y * item.Height) + space.Height + texture.Height);
							label.ForeColor = this.ForeColor;
							label.BackColor = this.BackColor;
							label.Text = "xThumbnail";
							label.Width = label.PreferredWidth;
							label.Font = new Font("Ariel",Convert.ToInt32(xb.Font));

							label.Click +=new EventHandler(label_Click);

							this.Controls.Add(label);
						}
					}
				}
				frmdesign.Update();
			}


			CC_xSpinControl cc_xSpinControl = new CC_xSpinControl();

			XSpinControl xSpinControl = new XSpinControl();

			XColor xc = new XColor();

			xc.A = 255;
			xc.B = 255;
			xc.G = 255;
			xc.R = 255;

			xc.Color = "ffffffff";

			xSpinControl.XColor.Add("0",xc);

			xSpinControl.Reverse = "false";

			xSpinControl.Xpos = xb.Picture["textureUp"].Picxpos;
			xSpinControl.Ypos = xb.Picture["textureUp"].Picypos;
			
			Picture p = new Picture();

			p.Path = xb.Picture["textureUp"].Path;

			xSpinControl.Picture.Add("textureUp",p);

			Picture p2 = new Picture();

			p2.Path = xb.Picture["textureDown"].Path;
				
			xSpinControl.Picture.Add("textureDown",p2);

			xSpinControl.Reverse = xb.Reverse;

			cc_xSpinControl.XB = xSpinControl;
			cc_xSpinControl.frmDesign = frmdesign;

			this.Controls.Add(cc_xSpinControl);

		}

		private void CC_xSpinControl_Load(object sender, System.EventArgs e)
		{

		}

		private void CC_xSpinControl_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void OpenEditDialog()
		{
			FrmXThumbnail frmXThumbnail = new FrmXThumbnail();

			frmXThumbnail.EDIT = true;
			frmXThumbnail.cc_XThumbnail = this;
			frmXThumbnail.F = frmdesign;

			frmXThumbnail.XB = this.xb;
			frmXThumbnail.Show();
		}

		private void pbox_Click(object sender, EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void label_Click(object sender, EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void CC_xThumbnail_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}
	}
}
