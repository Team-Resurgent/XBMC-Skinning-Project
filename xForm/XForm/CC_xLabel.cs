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
	/// Summary description for CC_xLabel.
	/// </summary>
	public class CC_xLabel : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label lblLabel;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private XLabel xb;
		private FrmDesign frmdesign;

		public FrmDesign frmDesign
		{
			get {return(this.frmdesign);}
			set	{this.frmdesign = value;}
		}

		public XLabel XB
		{
			get {return(this.xb);}
			set	
			{
				this.xb = value;
				this.UpdateControl();
			}
		}

		public CC_xLabel()
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
			this.lblLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblLabel
			// 
			this.lblLabel.Location = new System.Drawing.Point(0, 0);
			this.lblLabel.Name = "lblLabel";
			this.lblLabel.Size = new System.Drawing.Size(44, 44);
			this.lblLabel.TabIndex = 0;
			this.lblLabel.Text = "label1";
			this.lblLabel.Click += new System.EventHandler(this.lblLabel_Click);
			// 
			// CC_xLabel
			// 
			this.Controls.Add(this.lblLabel);
			this.Name = "CC_xLabel";
			this.Size = new System.Drawing.Size(44, 44);
			this.Click += new System.EventHandler(this.CC_xLabel_Click);
			this.Load += new System.EventHandler(this.CC_xLabel_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void CC_xLabel_Load(object sender, System.EventArgs e)
		{
			this.BackColor = Color.Transparent;
		}

		public void UpdateControl()
		{
			String labeltext;

			this.ForeColor = Color.FromArgb(xb.XColor[0].A,xb.XColor[0].R, xb.XColor[0].G, xb.XColor[0].B);
			this.Location = new Point(Convert.ToInt32(xb.Xpos), Convert.ToInt32(xb.Ypos));
			labeltext = xb.Labeltext;

			if (labeltext != "Please Select a Label")
			{
				this.lblLabel.Text = labeltext;
				this.lblLabel.Font = new Font("Ariel",Convert.ToInt32(xb.Font));
				this.lblLabel.Width = this.lblLabel.PreferredWidth;
				this.lblLabel.Height = this.lblLabel.PreferredHeight;
				this.lblLabel.ForeColor = this.ForeColor;
				this.lblLabel.BackColor = Color.Transparent;
				this.lblLabel.Location = new Point(Convert.ToInt32(xb.XOffset),Convert.ToInt32(xb.YOffset));
				this.Size = this.lblLabel.Size;
			}
			frmDesign.Update();
		}

		private void lblLabel_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void CC_xLabel_Click(object sender, System.EventArgs e)
		{
			this.OpenEditDialog();
		}

		private void OpenEditDialog()
		{
			FrmXLabel frmXLabel = new FrmXLabel();

			frmXLabel.EDIT = true;
			frmXLabel.cc_XLabel = this;
			frmXLabel.F = frmdesign;

			frmXLabel.XB = this.xb;
			frmXLabel.Show();
		}
	}
}
