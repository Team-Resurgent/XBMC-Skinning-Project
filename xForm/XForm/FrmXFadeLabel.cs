using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

using XForm.Data;

namespace XForm
{
	/// <summary>
	/// Summary description for FrmXFadeLabel.
	/// </summary>
	public class FrmXFadeLabel : System.Windows.Forms.Form
	{
		private Boolean FirstTime = true;

		private CC_xFadeLabel cc_xFadeLabel;
		private FrmDesign f;
		private XFadeLabel xb;
		private XFadeLabel backupxb;
		private Boolean edit;

		private System.Windows.Forms.GroupBox gBoxProperties;
		private System.Windows.Forms.Label lblColor1;
		private System.Windows.Forms.ComboBox CboxLabel;
		private System.Windows.Forms.ComboBox CboxFonts;
		private System.Windows.Forms.Label lblFonts;
		private System.Windows.Forms.Button btnIgnore;
		private System.Windows.Forms.Label lblLabel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.TextBox txtYPos;
		private System.Windows.Forms.Label lblYPos;
		private System.Windows.Forms.TextBox txtXPos;
		private System.Windows.Forms.Label lblXPos;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.Label lblID;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.TextBox txtOffSet;
		private System.Windows.Forms.Label lblOffset;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.TextBox txtYoffset;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboxalign;
		private System.Windows.Forms.TextBox txtColorkey;
		private System.Windows.Forms.Button btnColorkey;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtdisabledcolor;
		private System.Windows.Forms.Button btndisabledcolor;
		private System.Windows.Forms.TextBox txtWidth;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ToolTip toolTips;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.ComponentModel.IContainer components;

		public FrmXFadeLabel()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public CC_xFadeLabel cc_XFadeLabel
		{
			get {return this.cc_xFadeLabel;}
			set {this.cc_xFadeLabel = value;}
		}

		public FrmDesign F
		{
			get {return this.f;}
			set {this.f = value;}
		}

		public XFadeLabel XB
		{
			get {return this.xb;}
			set {this.xb = value;}
		}

		public XFadeLabel BackupXB
		{
			get {return this.backupxb;}
			set {this.backupxb = value;}
		}

		public Boolean EDIT
		{
			get {return this.edit;}
			set {this.edit = value;}
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
			this.gBoxProperties = new System.Windows.Forms.GroupBox();
			this.txtWidth = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtdisabledcolor = new System.Windows.Forms.TextBox();
			this.btndisabledcolor = new System.Windows.Forms.Button();
			this.cboxalign = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtYoffset = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblColor1 = new System.Windows.Forms.Label();
			this.CboxLabel = new System.Windows.Forms.ComboBox();
			this.CboxFonts = new System.Windows.Forms.ComboBox();
			this.lblFonts = new System.Windows.Forms.Label();
			this.txtColorkey = new System.Windows.Forms.TextBox();
			this.btnColorkey = new System.Windows.Forms.Button();
			this.btnIgnore = new System.Windows.Forms.Button();
			this.lblLabel = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.txtYPos = new System.Windows.Forms.TextBox();
			this.lblYPos = new System.Windows.Forms.Label();
			this.txtXPos = new System.Windows.Forms.TextBox();
			this.lblXPos = new System.Windows.Forms.Label();
			this.txtID = new System.Windows.Forms.TextBox();
			this.lblID = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.lblDescription = new System.Windows.Forms.Label();
			this.txtOffSet = new System.Windows.Forms.TextBox();
			this.lblOffset = new System.Windows.Forms.Label();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.gBoxProperties.SuspendLayout();
			this.SuspendLayout();
			// 
			// gBoxProperties
			// 
			this.gBoxProperties.Controls.Add(this.txtWidth);
			this.gBoxProperties.Controls.Add(this.label5);
			this.gBoxProperties.Controls.Add(this.label3);
			this.gBoxProperties.Controls.Add(this.txtdisabledcolor);
			this.gBoxProperties.Controls.Add(this.btndisabledcolor);
			this.gBoxProperties.Controls.Add(this.cboxalign);
			this.gBoxProperties.Controls.Add(this.label2);
			this.gBoxProperties.Controls.Add(this.txtYoffset);
			this.gBoxProperties.Controls.Add(this.label1);
			this.gBoxProperties.Controls.Add(this.lblColor1);
			this.gBoxProperties.Controls.Add(this.CboxLabel);
			this.gBoxProperties.Controls.Add(this.CboxFonts);
			this.gBoxProperties.Controls.Add(this.lblFonts);
			this.gBoxProperties.Controls.Add(this.txtColorkey);
			this.gBoxProperties.Controls.Add(this.btnColorkey);
			this.gBoxProperties.Controls.Add(this.btnIgnore);
			this.gBoxProperties.Controls.Add(this.lblLabel);
			this.gBoxProperties.Controls.Add(this.btnSave);
			this.gBoxProperties.Controls.Add(this.btnUpdate);
			this.gBoxProperties.Controls.Add(this.txtYPos);
			this.gBoxProperties.Controls.Add(this.lblYPos);
			this.gBoxProperties.Controls.Add(this.txtXPos);
			this.gBoxProperties.Controls.Add(this.lblXPos);
			this.gBoxProperties.Controls.Add(this.txtID);
			this.gBoxProperties.Controls.Add(this.lblID);
			this.gBoxProperties.Controls.Add(this.txtDescription);
			this.gBoxProperties.Controls.Add(this.lblDescription);
			this.gBoxProperties.Controls.Add(this.txtOffSet);
			this.gBoxProperties.Controls.Add(this.lblOffset);
			this.gBoxProperties.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gBoxProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gBoxProperties.Location = new System.Drawing.Point(0, 0);
			this.gBoxProperties.Name = "gBoxProperties";
			this.gBoxProperties.Size = new System.Drawing.Size(248, 320);
			this.gBoxProperties.TabIndex = 2;
			this.gBoxProperties.TabStop = false;
			this.gBoxProperties.Text = "Button Properties";
			this.gBoxProperties.Enter += new System.EventHandler(this.gBoxProperties_Enter);
			// 
			// txtWidth
			// 
			this.txtWidth.Location = new System.Drawing.Point(152, 72);
			this.txtWidth.Name = "txtWidth";
			this.txtWidth.Size = new System.Drawing.Size(40, 20);
			this.txtWidth.TabIndex = 59;
			this.txtWidth.Text = "";
			this.txtWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label5
			// 
			this.label5.Cursor = System.Windows.Forms.Cursors.Default;
			this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label5.Location = new System.Drawing.Point(152, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 58;
			this.label5.Text = "Width";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 216);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 16);
			this.label3.TabIndex = 57;
			this.label3.Text = "Disabled Color";
			// 
			// txtdisabledcolor
			// 
			this.txtdisabledcolor.Location = new System.Drawing.Point(144, 216);
			this.txtdisabledcolor.Name = "txtdisabledcolor";
			this.txtdisabledcolor.Size = new System.Drawing.Size(96, 20);
			this.txtdisabledcolor.TabIndex = 56;
			this.txtdisabledcolor.Text = "ff000000";
			// 
			// btndisabledcolor
			// 
			this.btndisabledcolor.BackColor = System.Drawing.SystemColors.Control;
			this.btndisabledcolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btndisabledcolor.Location = new System.Drawing.Point(104, 216);
			this.btndisabledcolor.Name = "btndisabledcolor";
			this.btndisabledcolor.Size = new System.Drawing.Size(32, 20);
			this.btndisabledcolor.TabIndex = 55;
			this.btndisabledcolor.Click += new System.EventHandler(this.btndisabledcolor_Click);
			// 
			// cboxalign
			// 
			this.cboxalign.Items.AddRange(new object[] {
														   "Left",
														   "Center",
														   "Right"});
			this.cboxalign.Location = new System.Drawing.Point(56, 96);
			this.cboxalign.Name = "cboxalign";
			this.cboxalign.Size = new System.Drawing.Size(184, 21);
			this.cboxalign.TabIndex = 54;
			this.cboxalign.Text = "Left";
			// 
			// label2
			// 
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Location = new System.Drawing.Point(8, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 53;
			this.label2.Text = "Align";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtYoffset
			// 
			this.txtYoffset.Location = new System.Drawing.Point(96, 264);
			this.txtYoffset.Name = "txtYoffset";
			this.txtYoffset.Size = new System.Drawing.Size(144, 20);
			this.txtYoffset.TabIndex = 52;
			this.txtYoffset.Text = "";
			this.txtYoffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(8, 264);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 51;
			this.label1.Text = "Text Y  OffSet";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblColor1
			// 
			this.lblColor1.Location = new System.Drawing.Point(8, 168);
			this.lblColor1.Name = "lblColor1";
			this.lblColor1.Size = new System.Drawing.Size(88, 16);
			this.lblColor1.TabIndex = 47;
			this.lblColor1.Text = "Color Key";
			// 
			// CboxLabel
			// 
			this.CboxLabel.Location = new System.Drawing.Point(56, 144);
			this.CboxLabel.Name = "CboxLabel";
			this.CboxLabel.Size = new System.Drawing.Size(184, 21);
			this.CboxLabel.TabIndex = 44;
			this.CboxLabel.Text = "My Programs";
			// 
			// CboxFonts
			// 
			this.CboxFonts.Location = new System.Drawing.Point(56, 120);
			this.CboxFonts.Name = "CboxFonts";
			this.CboxFonts.Size = new System.Drawing.Size(184, 21);
			this.CboxFonts.TabIndex = 43;
			this.CboxFonts.Text = "10";
			// 
			// lblFonts
			// 
			this.lblFonts.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblFonts.Location = new System.Drawing.Point(8, 120);
			this.lblFonts.Name = "lblFonts";
			this.lblFonts.Size = new System.Drawing.Size(40, 16);
			this.lblFonts.TabIndex = 42;
			this.lblFonts.Text = "Font";
			this.lblFonts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtColorkey
			// 
			this.txtColorkey.Location = new System.Drawing.Point(144, 168);
			this.txtColorkey.Name = "txtColorkey";
			this.txtColorkey.Size = new System.Drawing.Size(96, 20);
			this.txtColorkey.TabIndex = 41;
			this.txtColorkey.Text = "ff000000";
			// 
			// btnColorkey
			// 
			this.btnColorkey.BackColor = System.Drawing.SystemColors.Control;
			this.btnColorkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnColorkey.Location = new System.Drawing.Point(104, 168);
			this.btnColorkey.Name = "btnColorkey";
			this.btnColorkey.Size = new System.Drawing.Size(32, 20);
			this.btnColorkey.TabIndex = 40;
			this.btnColorkey.Click += new System.EventHandler(this.btnLabelColor_Click);
			// 
			// btnIgnore
			// 
			this.btnIgnore.Enabled = false;
			this.btnIgnore.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnIgnore.Location = new System.Drawing.Point(88, 288);
			this.btnIgnore.Name = "btnIgnore";
			this.btnIgnore.Size = new System.Drawing.Size(64, 24);
			this.btnIgnore.TabIndex = 39;
			this.btnIgnore.Text = "Delete";
			this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
			// 
			// lblLabel
			// 
			this.lblLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblLabel.Location = new System.Drawing.Point(8, 144);
			this.lblLabel.Name = "lblLabel";
			this.lblLabel.Size = new System.Drawing.Size(40, 20);
			this.lblLabel.TabIndex = 37;
			this.lblLabel.Text = "Label";
			this.lblLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// btnSave
			// 
			this.btnSave.Enabled = false;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSave.Location = new System.Drawing.Point(168, 288);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(72, 24);
			this.btnSave.TabIndex = 36;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnUpdate.Location = new System.Drawing.Point(8, 288);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(64, 24);
			this.btnUpdate.TabIndex = 35;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// txtYPos
			// 
			this.txtYPos.Location = new System.Drawing.Point(104, 72);
			this.txtYPos.Name = "txtYPos";
			this.txtYPos.Size = new System.Drawing.Size(40, 20);
			this.txtYPos.TabIndex = 19;
			this.txtYPos.Text = "";
			this.txtYPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// lblYPos
			// 
			this.lblYPos.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblYPos.Location = new System.Drawing.Point(104, 56);
			this.lblYPos.Name = "lblYPos";
			this.lblYPos.Size = new System.Drawing.Size(40, 16);
			this.lblYPos.TabIndex = 18;
			this.lblYPos.Text = "Y Pos";
			// 
			// txtXPos
			// 
			this.txtXPos.Location = new System.Drawing.Point(56, 72);
			this.txtXPos.Name = "txtXPos";
			this.txtXPos.Size = new System.Drawing.Size(40, 20);
			this.txtXPos.TabIndex = 17;
			this.txtXPos.Text = "";
			this.txtXPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// lblXPos
			// 
			this.lblXPos.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblXPos.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblXPos.Location = new System.Drawing.Point(56, 56);
			this.lblXPos.Name = "lblXPos";
			this.lblXPos.Size = new System.Drawing.Size(40, 16);
			this.lblXPos.TabIndex = 16;
			this.lblXPos.Text = "X Pos";
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(8, 72);
			this.txtID.MaxLength = 4;
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(40, 20);
			this.txtID.TabIndex = 15;
			this.txtID.Text = "";
			this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// lblID
			// 
			this.lblID.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblID.Location = new System.Drawing.Point(16, 56);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(24, 16);
			this.lblID.TabIndex = 14;
			this.lblID.Text = "ID";
			this.lblID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(8, 32);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(232, 20);
			this.txtDescription.TabIndex = 13;
			this.txtDescription.Text = "";
			// 
			// lblDescription
			// 
			this.lblDescription.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblDescription.Location = new System.Drawing.Point(8, 16);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(232, 16);
			this.lblDescription.TabIndex = 12;
			this.lblDescription.Text = "Description";
			this.lblDescription.Click += new System.EventHandler(this.lblDescription_Click);
			// 
			// txtOffSet
			// 
			this.txtOffSet.Location = new System.Drawing.Point(96, 240);
			this.txtOffSet.Name = "txtOffSet";
			this.txtOffSet.Size = new System.Drawing.Size(144, 20);
			this.txtOffSet.TabIndex = 35;
			this.txtOffSet.Text = "";
			this.txtOffSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// lblOffset
			// 
			this.lblOffset.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblOffset.Location = new System.Drawing.Point(8, 240);
			this.lblOffset.Name = "lblOffset";
			this.lblOffset.Size = new System.Drawing.Size(88, 16);
			this.lblOffset.TabIndex = 34;
			this.lblOffset.Text = "Text X  OffSet";
			this.lblOffset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// toolTips
			// 
			this.toolTips.AutomaticDelay = 50;
			this.toolTips.AutoPopDelay = 10000;
			this.toolTips.InitialDelay = 50;
			this.toolTips.ReshowDelay = 10;
			this.toolTips.ShowAlways = true;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Image Files |(*.gif;*.jpg;*.png)";
			// 
			// FrmXFadeLabel
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(248, 318);
			this.Controls.Add(this.gBoxProperties);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(800, 50);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmXFadeLabel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Load += new System.EventHandler(this.FrmXFadeLabel_Load);
			this.gBoxProperties.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnupdateprops_Click(object sender, System.EventArgs e)
		{
		}

		private void btnLabelColor_Click(object sender, System.EventArgs e)
		{
			if (this.colorDialog1.ShowDialog() == DialogResult.OK)
			{
				String Alpha =  (colorDialog1.Color.A.ToString("x") == "0" ? "00":colorDialog1.Color.A.ToString("x"));
				String Red	 =  (colorDialog1.Color.R.ToString("x") == "0" ? "00":colorDialog1.Color.R.ToString("x"));
				String Green =	(colorDialog1.Color.G.ToString("x") == "0" ? "00":colorDialog1.Color.G.ToString("x"));
				String Blue  =  (colorDialog1.Color.B.ToString("x") == "0" ? "00":colorDialog1.Color.B.ToString("x"));
				this.txtColorkey.Text = Alpha += Red += Green += Blue;
				
				this.btnColorkey.BackColor = colorDialog1.Color;
			}
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

			xb.Xpos = (this.txtXPos.Text == "" ? "0" : this.txtXPos.Text);
			xb.Ypos = (this.txtYPos.Text == "" ? "0" : this.txtYPos.Text);
			xb.Labeltext = (this.CboxLabel.Text == "" ? "0" : this.CboxLabel.Text);
			xb.ID = (this.txtID.Text == "" ? "0" : this.txtID.Text);
			xb.XOffset = (this.txtOffSet.Text == "" ? "0" : this.txtOffSet.Text);
			xb.YOffset = (this.txtYoffset.Text == ""  ? "0" : this.txtYoffset.Text);
			xb.XWidth = (this.txtWidth.Text == "" ? "0" : this.txtWidth.Text);
			xb.Align = this.cboxalign.Text;
			xb.Font = this.CboxFonts.Text;
			xb.Description = this.txtDescription.Text;

			if (txtColorkey.Text.Length <= 7)
			{
				txtColorkey.Text = "ff000000";
			}


			if (txtdisabledcolor.Text.Length <= 7)
			{
				txtdisabledcolor.Text = "ff000000";
			}

			ColorBreak cb = new ColorBreak();
			XColor xc1 = new XColor();

			xb.XColor.Add("textcolor", cb.BreakColor(xc1, txtColorkey.Text));

			XColor xc2 = new XColor();
			xb.XColor.Add("disabledcolor", cb.BreakColor(xc2, txtdisabledcolor.Text));

			this.Render();
		}

		private void Render()
		{
			if (this.edit == false)
			{

				if (FirstTime)
				{
					F.AddXFadeLabel(xb, this);
					FirstTime = false;
				}
				else
				{
					cc_xFadeLabel.XB = this.xb;
				}
			}
			else
			{
				cc_xFadeLabel.XB = this.xb;
			}
		}

		private void gBoxProperties_Enter(object sender, System.EventArgs e)
		{
			
		}

		private void FrmXFadeLabel_Load(object sender, System.EventArgs e)
		{
			LabelFromXML labelFromXML = new LabelFromXML();
			String [] Labels = labelFromXML.labelFromXML(Application.StartupPath + @"\strings.xml");

			for (Int32 i = 0; i < Labels.Length - 1; i++)
			{
				this.CboxLabel.Items.Add(Labels[i]);
			}

			GetFontList getFontList = new GetFontList();
			String [] Fonts = getFontList.getFontList(); //Application.StartupPath);

			for (Int32 i = 0; i < Fonts.Length - 1; i++)
			{
				this.CboxFonts.Items.Add(Fonts[i]);
			}

			if (xb == null)
			{
				xb = new XFadeLabel();
			}
			else
			{
				if (backupxb == null)
				{
					backupxb = new XFadeLabel();
					backupxb = xb;
				}

				this.btnIgnore.Enabled = true;

				this.txtXPos.Text = xb.Xpos;
				this.txtYPos.Text = xb.Ypos;
				this.CboxLabel.Text = xb.Labeltext;
				this.txtID.Text = xb.ID;
				
				
				this.txtOffSet.Text = xb.XOffset;
				this.txtYoffset.Text = xb.YOffset;
				this.txtWidth.Text = xb.XWidth;
				this.cboxalign.Text = xb.Align ;
				this.CboxFonts.Text = xb.Font;
				this.txtDescription.Text = xb.Description ;	
				this.txtColorkey.Text = xb.XColor["textcolor"].Color.ToString();
				this.txtdisabledcolor.Text = xb.XColor["disabledcolor"].Color.ToString();
		

				this.btnColorkey.BackColor = Color.FromArgb(xb.XColor["textcolor"].R,xb.XColor["textcolor"].G,xb.XColor["textcolor"].B);
				this.btndisabledcolor.BackColor = Color.FromArgb(xb.XColor["disabledcolor"].R,xb.XColor["disabledcolor"].G,xb.XColor["disabledcolor"].B);
			

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
				F.SaveXFadeLabel(xb);
				this.Close();
			}
		}

		private void btnIgnore_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you wish to Delete this Control? It cannot beundone","Warning",MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				xb.Save = false;
				cc_xFadeLabel.Visible = false;

				this.Close();
			}
		}

		private void btndisabledcolor_Click(object sender, System.EventArgs e)
		{
			if (this.colorDialog1.ShowDialog() == DialogResult.OK)
			{
				String Alpha =  (colorDialog1.Color.A.ToString("x") == "0" ? "00":colorDialog1.Color.A.ToString("x"));
				String Red	 =  (colorDialog1.Color.R.ToString("x") == "0" ? "00":colorDialog1.Color.R.ToString("x"));
				String Green =	(colorDialog1.Color.G.ToString("x") == "0" ? "00":colorDialog1.Color.G.ToString("x"));
				String Blue  =  (colorDialog1.Color.B.ToString("x") == "0" ? "00":colorDialog1.Color.B.ToString("x"));
				this.txtdisabledcolor.Text = Alpha += Red += Green += Blue;
				
				this.btndisabledcolor.BackColor = colorDialog1.Color;
			}
		}

		private void lblDescription_Click(object sender, System.EventArgs e)
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
