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
	/// Summary description for CC_xRss.
	/// </summary>
	public class CC_xRss : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label LblLabel;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private XRss xb;
		private FrmDesign frmdesign;

		public FrmDesign frmDesign
		{
			get {return(this.frmdesign);}
			set	{this.frmdesign = value;}
		}

		public XRss XB
		{
			get {return(this.xb);}
			set	
			{
				this.xb = value;
				this.UpdateControl();
			}
		}

		public CC_xRss()
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
			this.LblLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// LblLabel
			// 
			this.LblLabel.Location = new System.Drawing.Point(2, 5);
			this.LblLabel.Name = "LblLabel";
			this.LblLabel.Size = new System.Drawing.Size(64, 16);
			this.LblLabel.TabIndex = 0;
			this.LblLabel.Text = "LblRssFeed";
			this.LblLabel.Click += new System.EventHandler(this.LblLabel_Click);
			// 
			// CC_xRss
			// 
			this.Controls.Add(this.LblLabel);
			this.Name = "CC_xRss";
			this.Size = new System.Drawing.Size(96, 24);
			this.Click += new System.EventHandler(this.CC_xRss_Click);
			this.Load += new System.EventHandler(this.CC_xRss_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void CC_xRss_Load(object sender, System.EventArgs e)
		{
			this.BackColor = Color.Transparent;
		}

		public void UpdateControl()
		{
			String labeltext;

			this.Location = new Point(Convert.ToInt32(xb.Xpos), Convert.ToInt32(xb.Ypos));
			this.ForeColor = Color.FromArgb(xb.XColor[0].A,xb.XColor[0].R, xb.XColor[0].G, xb.XColor[0].B);

			labeltext = xb.Feed;

			this.LblLabel.Text = labeltext;
			this.LblLabel.Font = new Font("Ariel",Convert.ToInt32(xb.Font));
			this.LblLabel.Width = this.LblLabel.PreferredWidth;
			this.LblLabel.Height = this.LblLabel.PreferredHeight;
			this.LblLabel.ForeColor = this.ForeColor;
			this.LblLabel.BackColor = Color.Transparent;

			frmDesign.Update();
		}

		private void LblLabel_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void CC_xRss_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void OpenEditDialog()
		{
			FrmXRss frmXRss = new FrmXRss();

			frmXRss.EDIT = true;
			frmXRss.cc_XRss = this;
			frmXRss.F = frmdesign;

			frmXRss.XB = this.xb;
			frmXRss.Show();
		}
	}
}
