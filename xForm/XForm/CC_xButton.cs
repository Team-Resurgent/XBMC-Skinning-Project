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
	/// Summary description for Button.
	/// </summary>
	public class CC_xButton : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private XButton xb;
		private FrmDesign frmdesign;

		public FrmDesign frmDesign
		{
			get {return(this.frmdesign);}
			set	{this.frmdesign = value;}
		}

		public XButton XB
		{
			get {return(this.xb);}
			set	
			{
				this.xb = value;
				this.UpdateControl();
			}
		}

		public CC_xButton()
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
			// CC_xButton
			// 
			this.Name = "CC_xButton";
			this.Size = new System.Drawing.Size(232, 176);
			this.Click += new System.EventHandler(this.CC_xButton_Click);
			this.Load += new System.EventHandler(this.Button_Load);

		}
		#endregion

		private void lblLabel_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void Button_Load(object sender, System.EventArgs e)
		{
			this.BackColor = Color.Transparent;
			
		}

		public void UpdateControl()
		{
			this.Location = new Point(Convert.ToInt32(xb.Xpos), Convert.ToInt32(xb.Ypos));
			this.Size = new Size(Convert.ToInt32(xb.XWidth),Convert.ToInt32(xb.YHieght));
			this.BackColor = Color.Transparent;
			this.Refresh();
		}

		private void pBoxImage_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void CC_xButton_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void OpenEditDialog()
		{
			FrmXButton frmXButton = new FrmXButton();

			frmXButton.EDIT = true;
			frmXButton.cc_XButton = this;
			frmXButton.F = frmdesign;

			frmXButton.XB = this.xb;
			frmXButton.Show();
		}

		private void pBoxImage_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{

		}

		protected override void OnPaint(PaintEventArgs e)
		{
			// If there is an image and it has a location, 
			// paint it when the Form is repainted.
			base.OnPaint(e);

			String imagePath;

			
			imagePath = xb.Picture[0].Path;

			if (Path.GetFileNameWithoutExtension(imagePath) != "-")
			{
				e.Graphics.DrawImage(Image.FromFile(imagePath),0,0);
			}

			Int32 xdis = 0;

			String labeltext;

			labeltext = xb.Labeltext;

			if (xb.Align == "left")
			{xdis = 0;}
			
			if (xb.Align == "center")
			{xdis = this.Width / 2;}

			if (xb.Align == "right")
			{xdis = this.Width;}

			System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(	ClientRectangle,
				Color.FromArgb(xb.XColor["textcolor"].A,xb.XColor["textcolor"].R,xb.XColor["textcolor"].G,xb.XColor["textcolor"].B),
				Color.FromArgb(xb.XColor["textcolor"].A,xb.XColor["textcolor"].R,xb.XColor["textcolor"].G,xb.XColor["textcolor"].B),
				System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
			Font font = new Font("Arial",Convert.ToInt32(xb.Font));

			if (labeltext != "No Label") 
			{
				if (labeltext != "-")
				{
					e.Graphics.DrawString(labeltext,font,brush,xdis + Convert.ToInt32(xb.XOffset),1 + Convert.ToInt32(xb.YOffset));
				}
			}	

			brush.Dispose();
			font.Dispose();
		}

	}
}
