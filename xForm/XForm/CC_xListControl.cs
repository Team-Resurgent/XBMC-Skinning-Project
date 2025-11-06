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
	/// Summary description for CC_xListControl.
	/// </summary>
	public class CC_xListControl : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		private XListControl xb;
		private FrmDesign frmdesign;

		public FrmDesign frmDesign
		{
			get {return(this.frmdesign);}
			set	{this.frmdesign = value;}
		}

		public XListControl XB
		{
			get {return(this.xb);}
			set	
			{
				this.xb = value;
				this.UpdateControl();
			}
		}

		public CC_xListControl()
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
			// 
			// CC_xListControl
			// 
			this.Name = "CC_xListControl";
			this.Size = new System.Drawing.Size(360, 528);
			this.Click += new System.EventHandler(this.CC_xListControl_Click);
			this.Load += new System.EventHandler(this.CC_xListControl_Load);

		}
		#endregion

		private void CC_xListControl_Load(object sender, System.EventArgs e)
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

			this.Location = new Point(Convert.ToInt32(xb.Xpos),Convert.ToInt32(xb.Ypos));
			this.Size = new Size(Convert.ToInt32(xb.XWidth),Convert.ToInt32(xb.YHieght));
			this.ForeColor = Color.FromArgb(xb.XColor["textcolor"].A,xb.XColor["textcolor"].R,xb.XColor["textcolor"].G,xb.XColor["textcolor"].B);

			Int32 amount = this.Height / Image.FromFile(xb.Picture["textureFocus"].Path).Height;

			String[] convert = Convert.ToString(amount).Split(new char[] {'.'});

			Int32 total = Convert.ToInt32(convert[0]);

			for (Int32 y = 0; y < total; y++)
			{
				PictureBox picbox = new PictureBox();

				picbox.Location = new Point(5, (y * Image.FromFile(xb.Picture["textureFocus"].Path).Height) + 20);
				picbox.Size = new Size(Image.FromFile(xb.Picture["textureFocus"].Path).Width, Image.FromFile(xb.Picture["textureFocus"].Path).Height);
				picbox.Image = Image.FromFile(xb.Picture["textureFocus"].Path);
				picbox.BackColor = Color.Transparent;
				picbox.Click += new EventHandler(picbox_Click);
				picbox.SendToBack();

				this.Controls.Add(picbox);

				PictureBox picbox1 = new PictureBox();

				picbox1.Location = new Point(10, (y * Image.FromFile(xb.Picture["textureFocus"].Path).Height) + 22);
				picbox1.Size = new Size(Image.FromFile(xb.Picture["image"].Path).Width, Image.FromFile(xb.Picture["image"].Path).Height);
				picbox1.Image = Image.FromFile(xb.Picture["image"].Path);
				picbox1.BackColor = Color.Transparent;
				picbox1.Click += new EventHandler(picbox_Click);

				this.Controls.Add(picbox1);

				Label label = new Label();

				label.Location = new Point(15 + Image.FromFile(xb.Picture["image"].Path).Width, (y * Image.FromFile(xb.Picture["textureFocus"].Path).Height) + 22);
				label.ForeColor = this.ForeColor;
				label.BackColor = this.BackColor;
				label.Text = "xListControl";
				label.Width = label.PreferredWidth;
				label.Font = new Font("Ariel",Convert.ToInt32(xb.Font));

				label.Click +=new EventHandler(picbox_Click);

				this.Controls.Add(label);

				frmDesign.Update();

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

		private void CC_xListControl_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
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
			FrmXListControl frmXListControl = new FrmXListControl();

			frmXListControl.EDIT = true;
			frmXListControl.cc_XListControl = this;
			frmXListControl.F = frmdesign;

			frmXListControl.XB = this.xb;
			frmXListControl.Show();
		}

		private void picbox_Click(object sender, EventArgs e)
		{
			this.OpenEditDialog();
		}
	}
}
