using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using XForm.Data;

namespace XForm
{
	/// <summary>
	/// Summary description for FrmXRss.
	/// </summary>
	public class FrmXRss : System.Windows.Forms.Form
	{
		private Boolean FirstTime = true;

		private CC_xRss cc_xRss;
		private FrmDesign f;
		private XRss xb;
		private XRss backupxb;
		private Boolean edit;

		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.TextBox txtRss;
		private System.Windows.Forms.Label Label7000;
		private System.Windows.Forms.Button btnRssText;
		private System.Windows.Forms.TextBox txtRssText;
		private System.Windows.Forms.TextBox txtRssWidth;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.TextBox txtRssYPos;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.TextBox txtRssXPos;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.TextBox txtRssID;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.ComboBox CboxRssFonts;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Button btnRssTitleColor;
		private System.Windows.Forms.TextBox txtRssTitle;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Button btnRssHeadline;
		private System.Windows.Forms.TextBox txtRssHeadline;
		private System.Windows.Forms.Button btnIgnore;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.ToolTip toolTips;
		private System.ComponentModel.IContainer components;

		public FrmXRss()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.btnIgnore = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.txtRss = new System.Windows.Forms.TextBox();
			this.Label7000 = new System.Windows.Forms.Label();
			this.btnRssText = new System.Windows.Forms.Button();
			this.txtRssText = new System.Windows.Forms.TextBox();
			this.txtRssWidth = new System.Windows.Forms.TextBox();
			this.label64 = new System.Windows.Forms.Label();
			this.txtRssYPos = new System.Windows.Forms.TextBox();
			this.label66 = new System.Windows.Forms.Label();
			this.txtRssXPos = new System.Windows.Forms.TextBox();
			this.label67 = new System.Windows.Forms.Label();
			this.txtRssID = new System.Windows.Forms.TextBox();
			this.label68 = new System.Windows.Forms.Label();
			this.label69 = new System.Windows.Forms.Label();
			this.label70 = new System.Windows.Forms.Label();
			this.CboxRssFonts = new System.Windows.Forms.ComboBox();
			this.label71 = new System.Windows.Forms.Label();
			this.btnRssTitleColor = new System.Windows.Forms.Button();
			this.txtRssTitle = new System.Windows.Forms.TextBox();
			this.label72 = new System.Windows.Forms.Label();
			this.btnRssHeadline = new System.Windows.Forms.Button();
			this.txtRssHeadline = new System.Windows.Forms.TextBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.btnIgnore);
			this.groupBox6.Controls.Add(this.btnSave);
			this.groupBox6.Controls.Add(this.btnUpdate);
			this.groupBox6.Controls.Add(this.txtRss);
			this.groupBox6.Controls.Add(this.Label7000);
			this.groupBox6.Controls.Add(this.btnRssText);
			this.groupBox6.Controls.Add(this.txtRssText);
			this.groupBox6.Controls.Add(this.txtRssWidth);
			this.groupBox6.Controls.Add(this.label64);
			this.groupBox6.Controls.Add(this.txtRssYPos);
			this.groupBox6.Controls.Add(this.label66);
			this.groupBox6.Controls.Add(this.txtRssXPos);
			this.groupBox6.Controls.Add(this.label67);
			this.groupBox6.Controls.Add(this.txtRssID);
			this.groupBox6.Controls.Add(this.label68);
			this.groupBox6.Controls.Add(this.label69);
			this.groupBox6.Controls.Add(this.label70);
			this.groupBox6.Controls.Add(this.CboxRssFonts);
			this.groupBox6.Controls.Add(this.label71);
			this.groupBox6.Controls.Add(this.btnRssTitleColor);
			this.groupBox6.Controls.Add(this.txtRssTitle);
			this.groupBox6.Controls.Add(this.label72);
			this.groupBox6.Controls.Add(this.btnRssHeadline);
			this.groupBox6.Controls.Add(this.txtRssHeadline);
			this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox6.Location = new System.Drawing.Point(8, 8);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(240, 256);
			this.groupBox6.TabIndex = 67;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Rss Properties";
			this.groupBox6.Enter += new System.EventHandler(this.groupBox6_Enter);
			// 
			// btnIgnore
			// 
			this.btnIgnore.Enabled = false;
			this.btnIgnore.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnIgnore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnIgnore.Location = new System.Drawing.Point(80, 224);
			this.btnIgnore.Name = "btnIgnore";
			this.btnIgnore.Size = new System.Drawing.Size(64, 24);
			this.btnIgnore.TabIndex = 86;
			this.btnIgnore.Text = "Delete";
			this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
			// 
			// btnSave
			// 
			this.btnSave.Enabled = false;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(160, 224);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(72, 24);
			this.btnSave.TabIndex = 85;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnUpdate.Location = new System.Drawing.Point(8, 224);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(64, 24);
			this.btnUpdate.TabIndex = 84;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// txtRss
			// 
			this.txtRss.Location = new System.Drawing.Point(16, 80);
			this.txtRss.Multiline = true;
			this.txtRss.Name = "txtRss";
			this.txtRss.Size = new System.Drawing.Size(208, 24);
			this.txtRss.TabIndex = 83;
			this.txtRss.Text = "";
			// 
			// Label7000
			// 
			this.Label7000.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label7000.Location = new System.Drawing.Point(16, 192);
			this.Label7000.Name = "Label7000";
			this.Label7000.Size = new System.Drawing.Size(56, 16);
			this.Label7000.TabIndex = 82;
			this.Label7000.Text = "Text Color";
			// 
			// btnRssText
			// 
			this.btnRssText.BackColor = System.Drawing.SystemColors.Control;
			this.btnRssText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRssText.Location = new System.Drawing.Point(112, 192);
			this.btnRssText.Name = "btnRssText";
			this.btnRssText.Size = new System.Drawing.Size(32, 20);
			this.btnRssText.TabIndex = 80;
			this.btnRssText.Click += new System.EventHandler(this.btnRssText_Click);
			// 
			// txtRssText
			// 
			this.txtRssText.Location = new System.Drawing.Point(152, 192);
			this.txtRssText.Name = "txtRssText";
			this.txtRssText.Size = new System.Drawing.Size(72, 20);
			this.txtRssText.TabIndex = 81;
			this.txtRssText.Text = "ff000000";
			// 
			// txtRssWidth
			// 
			this.txtRssWidth.Location = new System.Drawing.Point(152, 32);
			this.txtRssWidth.Name = "txtRssWidth";
			this.txtRssWidth.Size = new System.Drawing.Size(40, 20);
			this.txtRssWidth.TabIndex = 77;
			this.txtRssWidth.Text = "";
			this.txtRssWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label64
			// 
			this.label64.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label64.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label64.Location = new System.Drawing.Point(152, 16);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(32, 16);
			this.label64.TabIndex = 76;
			this.label64.Text = "Width";
			this.label64.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtRssYPos
			// 
			this.txtRssYPos.Location = new System.Drawing.Point(104, 32);
			this.txtRssYPos.Name = "txtRssYPos";
			this.txtRssYPos.Size = new System.Drawing.Size(40, 20);
			this.txtRssYPos.TabIndex = 58;
			this.txtRssYPos.Text = "";
			this.txtRssYPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label66
			// 
			this.label66.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label66.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label66.Location = new System.Drawing.Point(112, 16);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(40, 16);
			this.label66.TabIndex = 57;
			this.label66.Text = "Y Pos";
			// 
			// txtRssXPos
			// 
			this.txtRssXPos.Location = new System.Drawing.Point(56, 32);
			this.txtRssXPos.Name = "txtRssXPos";
			this.txtRssXPos.Size = new System.Drawing.Size(40, 20);
			this.txtRssXPos.TabIndex = 56;
			this.txtRssXPos.Text = "";
			this.txtRssXPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label67
			// 
			this.label67.Cursor = System.Windows.Forms.Cursors.Default;
			this.label67.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label67.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label67.Location = new System.Drawing.Point(64, 16);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(40, 16);
			this.label67.TabIndex = 55;
			this.label67.Text = "X Pos";
			// 
			// txtRssID
			// 
			this.txtRssID.Location = new System.Drawing.Point(8, 32);
			this.txtRssID.MaxLength = 4;
			this.txtRssID.Name = "txtRssID";
			this.txtRssID.Size = new System.Drawing.Size(40, 20);
			this.txtRssID.TabIndex = 54;
			this.txtRssID.Text = "";
			this.txtRssID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label68
			// 
			this.label68.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label68.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label68.Location = new System.Drawing.Point(16, 16);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(24, 16);
			this.label68.TabIndex = 53;
			this.label68.Text = "ID";
			this.label68.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label69
			// 
			this.label69.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label69.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label69.Location = new System.Drawing.Point(72, 56);
			this.label69.Name = "label69";
			this.label69.Size = new System.Drawing.Size(96, 16);
			this.label69.TabIndex = 59;
			this.label69.Text = "RssFeed Location";
			this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label70
			// 
			this.label70.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label70.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label70.Location = new System.Drawing.Point(16, 120);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(40, 16);
			this.label70.TabIndex = 69;
			this.label70.Text = "Font";
			this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CboxRssFonts
			// 
			this.CboxRssFonts.Location = new System.Drawing.Point(80, 112);
			this.CboxRssFonts.Name = "CboxRssFonts";
			this.CboxRssFonts.Size = new System.Drawing.Size(152, 21);
			this.CboxRssFonts.TabIndex = 70;
			this.CboxRssFonts.Text = "10";
			// 
			// label71
			// 
			this.label71.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label71.Location = new System.Drawing.Point(16, 144);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(48, 16);
			this.label71.TabIndex = 73;
			this.label71.Text = "Title Key";
			// 
			// btnRssTitleColor
			// 
			this.btnRssTitleColor.BackColor = System.Drawing.SystemColors.Control;
			this.btnRssTitleColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRssTitleColor.Location = new System.Drawing.Point(112, 144);
			this.btnRssTitleColor.Name = "btnRssTitleColor";
			this.btnRssTitleColor.Size = new System.Drawing.Size(32, 20);
			this.btnRssTitleColor.TabIndex = 67;
			this.btnRssTitleColor.Click += new System.EventHandler(this.btnRssTitleColor_Click);
			// 
			// txtRssTitle
			// 
			this.txtRssTitle.Location = new System.Drawing.Point(152, 144);
			this.txtRssTitle.Name = "txtRssTitle";
			this.txtRssTitle.Size = new System.Drawing.Size(72, 20);
			this.txtRssTitle.TabIndex = 68;
			this.txtRssTitle.Text = "ff000000";
			// 
			// label72
			// 
			this.label72.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label72.Location = new System.Drawing.Point(16, 168);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(88, 16);
			this.label72.TabIndex = 74;
			this.label72.Text = "HeadLine Color";
			// 
			// btnRssHeadline
			// 
			this.btnRssHeadline.BackColor = System.Drawing.SystemColors.Control;
			this.btnRssHeadline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRssHeadline.Location = new System.Drawing.Point(112, 168);
			this.btnRssHeadline.Name = "btnRssHeadline";
			this.btnRssHeadline.Size = new System.Drawing.Size(32, 20);
			this.btnRssHeadline.TabIndex = 71;
			this.btnRssHeadline.Click += new System.EventHandler(this.btnRssHeadline_Click);
			// 
			// txtRssHeadline
			// 
			this.txtRssHeadline.Location = new System.Drawing.Point(152, 168);
			this.txtRssHeadline.Name = "txtRssHeadline";
			this.txtRssHeadline.Size = new System.Drawing.Size(72, 20);
			this.txtRssHeadline.TabIndex = 72;
			this.txtRssHeadline.Text = "ff000000";
			// 
			// toolTips
			// 
			this.toolTips.AutomaticDelay = 50;
			this.toolTips.AutoPopDelay = 10000;
			this.toolTips.InitialDelay = 50;
			this.toolTips.ReshowDelay = 10;
			this.toolTips.ShowAlways = true;
			// 
			// FrmXRss
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(256, 270);
			this.Controls.Add(this.groupBox6);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FrmXRss";
			this.Text = "FrmXRss";
			this.Load += new System.EventHandler(this.FrmXRss_Load);
			this.groupBox6.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public CC_xRss cc_XRss
		{
			get {return this.cc_xRss;}
			set {this.cc_xRss = value;}
		}

		public FrmDesign F
		{
			get {return this.f;}
			set {this.f = value;}
		}

		public XRss XB
		{
			get {return this.xb;}
			set {this.xb = value;}
		}

		public XRss BackupXB
		{
			get {return this.backupxb;}
			set {this.backupxb = value;}
		}

		public Boolean EDIT
		{
			get {return this.edit;}
			set {this.edit = value;}
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			this.UpdateControl();
		}

		public void UpdateControl()
		{
			this.btnSave.Enabled = true;	
			this.btnIgnore.Enabled = true;

			xb.Picture.Clear();
			xb.XColor.Clear();
			
			xb.Xpos = (this.txtRssXPos.Text == "" ? "0" : this.txtRssXPos.Text);
			xb.Ypos = (this.txtRssYPos.Text == "" ? "0" : this.txtRssYPos.Text);
			xb.ID = (this.txtRssID.Text == "" ? "0" : this.txtRssID.Text);
			xb.XWidth = (this.txtRssWidth.Text == "" ? "0" : this.txtRssWidth.Text);
			xb.Feed = this.txtRss.Text;
			xb.Font = this.CboxRssFonts.Text;
			xb.Description = "Rss Feed";

			if (txtRssHeadline.Text.Length <= 7)
			{
				txtRssHeadline.Text = "ff000000";
			}

			if (txtRssText.Text.Length <= 7)
			{
				txtRssText.Text = "ff000000";
			}

			if (txtRssTitle.Text.Length <= 7)
			{
				txtRssTitle.Text = "ff000000";
			}

			ColorBreak cb = new ColorBreak();
			XColor xc1 = new XColor();

			xb.XColor.Add("headlinecolor", cb.BreakColor(xc1, this.txtRssHeadline.Text));

			XColor xc2 = new XColor();
			xb.XColor.Add("textcolor", cb.BreakColor(xc2, this.txtRssText.Text));

			XColor xc3 = new XColor();
			xb.XColor.Add("titlecolor", cb.BreakColor(xc3, this.txtRssTitle.Text));

			this.Render();
		}

		private void Render()
		{
			if (this.edit == false)
			{

				if (FirstTime)
				{
					F.AddXRss(xb, this);
					FirstTime = false;
				}
				else
				{
					cc_xRss.XB = this.xb;
				}
			}
			else
			{
				cc_xRss.XB = this.xb;
			}
		}

		private void btnIgnore_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you wish to Delete this Control? It cannot beundone","Warning",MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				xb.Save = false;
				cc_xRss.Visible = false;

				this.Close();
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			xb.Save = true;

			if (EDIT)
			{
				this.Close();
			}
			else
			{
				F.SaveXRss(xb);
				this.Close();
			}
		}

		private void btnRssTitleColor_Click(object sender, System.EventArgs e)
		{
			if (this.colorDialog1.ShowDialog() == DialogResult.OK)
			{
				String Alpha =  (colorDialog1.Color.A.ToString("x") == "0" ? "00":colorDialog1.Color.A.ToString("x"));
				String Red	 =  (colorDialog1.Color.R.ToString("x") == "0" ? "00":colorDialog1.Color.R.ToString("x"));
				String Green =	(colorDialog1.Color.G.ToString("x") == "0" ? "00":colorDialog1.Color.G.ToString("x"));
				String Blue  =  (colorDialog1.Color.B.ToString("x") == "0" ? "00":colorDialog1.Color.B.ToString("x"));
				this.txtRssTitle.Text = Alpha += Red += Green += Blue;
				
				this.btnRssTitleColor.BackColor = colorDialog1.Color;
			}
		}

		private void btnRssHeadline_Click(object sender, System.EventArgs e)
		{
			if (this.colorDialog1.ShowDialog() == DialogResult.OK)
			{
				String Alpha =  (colorDialog1.Color.A.ToString("x") == "0" ? "00":colorDialog1.Color.A.ToString("x"));
				String Red	 =  (colorDialog1.Color.R.ToString("x") == "0" ? "00":colorDialog1.Color.R.ToString("x"));
				String Green =	(colorDialog1.Color.G.ToString("x") == "0" ? "00":colorDialog1.Color.G.ToString("x"));
				String Blue  =  (colorDialog1.Color.B.ToString("x") == "0" ? "00":colorDialog1.Color.B.ToString("x"));
				this.txtRssHeadline.Text = Alpha += Red += Green += Blue;
				
				this.btnRssHeadline.BackColor = colorDialog1.Color;
			}
		}

		private void btnRssText_Click(object sender, System.EventArgs e)
		{
			if (this.colorDialog1.ShowDialog() == DialogResult.OK)
			{
				String Alpha =  (colorDialog1.Color.A.ToString("x") == "0" ? "00":colorDialog1.Color.A.ToString("x"));
				String Red	 =  (colorDialog1.Color.R.ToString("x") == "0" ? "00":colorDialog1.Color.R.ToString("x"));
				String Green =	(colorDialog1.Color.G.ToString("x") == "0" ? "00":colorDialog1.Color.G.ToString("x"));
				String Blue  =  (colorDialog1.Color.B.ToString("x") == "0" ? "00":colorDialog1.Color.B.ToString("x"));
				this.txtRssText.Text = Alpha += Red += Green += Blue;
				
				this.btnRssText.BackColor = colorDialog1.Color;
			}
		}

		private void FrmXRss_Load(object sender, System.EventArgs e)
		{
			GetFontList getFontList = new GetFontList();
			String [] Fonts = getFontList.getFontList(); //Application.StartupPath);

			for (Int32 i = 0; i < Fonts.Length - 1; i++)
			{
				this.CboxRssFonts.Items.Add(Fonts[i]);
			}

			if (xb == null)
			{
				xb = new XRss();
			}
			else
			{
				if (backupxb == null)
				{
					backupxb = new XRss();
					backupxb = xb;
				}

				this.btnIgnore.Enabled = true;

				this.txtRssXPos.Text = xb.Xpos;
				this.txtRssYPos.Text = xb.Ypos;
				this.txtRssID.Text = xb.ID;
				
				this.txtRss.Text = xb.Feed;
				
				this.txtRssWidth.Text = xb.XWidth;

				this.CboxRssFonts.Text = xb.Font;

				this.txtRssHeadline.Text = xb.XColor["headlinecolor"].Color.ToString();
				this.txtRssText.Text = xb.XColor["textcolor"].Color.ToString();
				this.txtRssTitle.Text = xb.XColor["titlecolor"].Color.ToString();

				this.btnRssHeadline.BackColor = Color.FromArgb(xb.XColor["headlinecolor"].R,xb.XColor["headlinecolor"].G,xb.XColor["headlinecolor"].B);
				this.btnRssText.BackColor = Color.FromArgb(xb.XColor["textcolor"].R,xb.XColor["textcolor"].G,xb.XColor["textcolor"].B);
				this.btnRssTitleColor.BackColor = Color.FromArgb(xb.XColor["titlecolor"].R,xb.XColor["titlecolor"].G,xb.XColor["titlecolor"].B);
			}
		}

		private void groupBox6_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void FieldKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			Int32 keycode;

			keycode = e.KeyChar;

			if (((keycode > 47) && (keycode < 58) || (keycode == 8)))
			{
				e.Handled = false;
			}
			else
			{
				e.Handled = true;
			}
		}
	}
}
