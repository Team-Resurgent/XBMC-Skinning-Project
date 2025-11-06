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
	/// Summary description for FrmXSelectButton.
	/// </summary>
	public class FrmXSelectButton : System.Windows.Forms.Form
	{
		private Boolean FirstTime = true;

		private CC_xSelectButton cc_xSelectButton;
		private FrmDesign f;
		private XSelectButton xb;
		private XSelectButton backupxb;
		private Boolean edit;

		private System.Windows.Forms.GroupBox gBoxProperties;
		private System.Windows.Forms.Label lblcolor2;
		private System.Windows.Forms.Label lblColor1;
		private System.Windows.Forms.Button btnColorDefuse;
		private System.Windows.Forms.ComboBox CboxLabel;
		private System.Windows.Forms.ComboBox CboxFonts;
		private System.Windows.Forms.Label lblFonts;
		private System.Windows.Forms.Button btnIgnore;
		private System.Windows.Forms.Label lblLabel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnImageBrowse;
		private System.Windows.Forms.TextBox txtImage;
		private System.Windows.Forms.TextBox txtLeft;
		private System.Windows.Forms.Label lblLeft;
		private System.Windows.Forms.TextBox txtRight;
		private System.Windows.Forms.Label lblRight;
		private System.Windows.Forms.TextBox txtDown;
		private System.Windows.Forms.Label lblDown;
		private System.Windows.Forms.TextBox txtUp;
		private System.Windows.Forms.Label lblUp;
		private System.Windows.Forms.TextBox txtYPos;
		private System.Windows.Forms.Label lblYPos;
		private System.Windows.Forms.TextBox txtXPos;
		private System.Windows.Forms.Label lblXPos;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.Label lblID;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Button btnImageBrowse2;
		private System.Windows.Forms.TextBox txtImage2;
		private System.Windows.Forms.TextBox txtOffSet;
		private System.Windows.Forms.Label lblOffset;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.TextBox txtYoffset;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboxalign;
		private System.Windows.Forms.TextBox txtdiffusecolor;
		private System.Windows.Forms.TextBox txtColorkey;
		private System.Windows.Forms.Button btnColorkey;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtdisabledcolor;
		private System.Windows.Forms.Button btndisabledcolor;
		private System.Windows.Forms.TextBox txtHeight;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtWidth;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnrightfocus;
		private System.Windows.Forms.Button btnrightnofocus;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnleftfocus;
		private System.Windows.Forms.Button btnleftnofocus;
		private System.Windows.Forms.TextBox txtleftfocus;
		private System.Windows.Forms.TextBox txtleftnofocus;
		private System.Windows.Forms.TextBox txtrightfocus;
		private System.Windows.Forms.TextBox txtrightnofocus;
		private System.Windows.Forms.PictureBox tickfocus;
		private System.Windows.Forms.PictureBox ticknofocus;
		private System.Windows.Forms.PictureBox tickleftfocus;
		private System.Windows.Forms.PictureBox tickleftnofocus;
		private System.Windows.Forms.PictureBox tickrightfocus;
		private System.Windows.Forms.PictureBox tickrightnofocus;
		private System.Windows.Forms.ToolTip toolTips;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.ComponentModel.IContainer components;

		public FrmXSelectButton()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public CC_xSelectButton cc_XSelectButton
		{
			get {return this.cc_xSelectButton;}
			set {this.cc_xSelectButton = value;}
		}

		public FrmDesign F
		{
			get {return this.f;}
			set {this.f = value;}
		}

		public XSelectButton XB
		{
			get {return this.xb;}
			set {this.xb = value;}
		}

		public XSelectButton BackupXB
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmXSelectButton));
			this.gBoxProperties = new System.Windows.Forms.GroupBox();
			this.ticknofocus = new System.Windows.Forms.PictureBox();
			this.tickfocus = new System.Windows.Forms.PictureBox();
			this.txtHeight = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtWidth = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtdisabledcolor = new System.Windows.Forms.TextBox();
			this.btndisabledcolor = new System.Windows.Forms.Button();
			this.cboxalign = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtYoffset = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblcolor2 = new System.Windows.Forms.Label();
			this.lblColor1 = new System.Windows.Forms.Label();
			this.txtdiffusecolor = new System.Windows.Forms.TextBox();
			this.btnColorDefuse = new System.Windows.Forms.Button();
			this.CboxLabel = new System.Windows.Forms.ComboBox();
			this.CboxFonts = new System.Windows.Forms.ComboBox();
			this.lblFonts = new System.Windows.Forms.Label();
			this.txtColorkey = new System.Windows.Forms.TextBox();
			this.btnColorkey = new System.Windows.Forms.Button();
			this.btnIgnore = new System.Windows.Forms.Button();
			this.lblLabel = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnImageBrowse = new System.Windows.Forms.Button();
			this.txtImage = new System.Windows.Forms.TextBox();
			this.txtLeft = new System.Windows.Forms.TextBox();
			this.lblLeft = new System.Windows.Forms.Label();
			this.txtRight = new System.Windows.Forms.TextBox();
			this.lblRight = new System.Windows.Forms.Label();
			this.txtDown = new System.Windows.Forms.TextBox();
			this.lblDown = new System.Windows.Forms.Label();
			this.txtUp = new System.Windows.Forms.TextBox();
			this.lblUp = new System.Windows.Forms.Label();
			this.txtYPos = new System.Windows.Forms.TextBox();
			this.lblYPos = new System.Windows.Forms.Label();
			this.txtXPos = new System.Windows.Forms.TextBox();
			this.lblXPos = new System.Windows.Forms.Label();
			this.txtID = new System.Windows.Forms.TextBox();
			this.lblID = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.lblDescription = new System.Windows.Forms.Label();
			this.btnImageBrowse2 = new System.Windows.Forms.Button();
			this.txtImage2 = new System.Windows.Forms.TextBox();
			this.txtOffSet = new System.Windows.Forms.TextBox();
			this.lblOffset = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tickrightnofocus = new System.Windows.Forms.PictureBox();
			this.tickrightfocus = new System.Windows.Forms.PictureBox();
			this.btnrightfocus = new System.Windows.Forms.Button();
			this.btnrightnofocus = new System.Windows.Forms.Button();
			this.txtrightfocus = new System.Windows.Forms.TextBox();
			this.txtrightnofocus = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tickleftnofocus = new System.Windows.Forms.PictureBox();
			this.btnleftfocus = new System.Windows.Forms.Button();
			this.btnleftnofocus = new System.Windows.Forms.Button();
			this.txtleftfocus = new System.Windows.Forms.TextBox();
			this.txtleftnofocus = new System.Windows.Forms.TextBox();
			this.tickleftfocus = new System.Windows.Forms.PictureBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.gBoxProperties.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gBoxProperties
			// 
			this.gBoxProperties.Controls.Add(this.ticknofocus);
			this.gBoxProperties.Controls.Add(this.tickfocus);
			this.gBoxProperties.Controls.Add(this.txtHeight);
			this.gBoxProperties.Controls.Add(this.label4);
			this.gBoxProperties.Controls.Add(this.txtWidth);
			this.gBoxProperties.Controls.Add(this.label5);
			this.gBoxProperties.Controls.Add(this.label3);
			this.gBoxProperties.Controls.Add(this.txtdisabledcolor);
			this.gBoxProperties.Controls.Add(this.btndisabledcolor);
			this.gBoxProperties.Controls.Add(this.cboxalign);
			this.gBoxProperties.Controls.Add(this.label2);
			this.gBoxProperties.Controls.Add(this.txtYoffset);
			this.gBoxProperties.Controls.Add(this.label1);
			this.gBoxProperties.Controls.Add(this.lblcolor2);
			this.gBoxProperties.Controls.Add(this.lblColor1);
			this.gBoxProperties.Controls.Add(this.txtdiffusecolor);
			this.gBoxProperties.Controls.Add(this.btnColorDefuse);
			this.gBoxProperties.Controls.Add(this.CboxLabel);
			this.gBoxProperties.Controls.Add(this.CboxFonts);
			this.gBoxProperties.Controls.Add(this.lblFonts);
			this.gBoxProperties.Controls.Add(this.txtColorkey);
			this.gBoxProperties.Controls.Add(this.btnColorkey);
			this.gBoxProperties.Controls.Add(this.btnIgnore);
			this.gBoxProperties.Controls.Add(this.lblLabel);
			this.gBoxProperties.Controls.Add(this.btnSave);
			this.gBoxProperties.Controls.Add(this.btnUpdate);
			this.gBoxProperties.Controls.Add(this.btnImageBrowse);
			this.gBoxProperties.Controls.Add(this.txtImage);
			this.gBoxProperties.Controls.Add(this.txtLeft);
			this.gBoxProperties.Controls.Add(this.lblLeft);
			this.gBoxProperties.Controls.Add(this.txtRight);
			this.gBoxProperties.Controls.Add(this.lblRight);
			this.gBoxProperties.Controls.Add(this.txtDown);
			this.gBoxProperties.Controls.Add(this.lblDown);
			this.gBoxProperties.Controls.Add(this.txtUp);
			this.gBoxProperties.Controls.Add(this.lblUp);
			this.gBoxProperties.Controls.Add(this.txtYPos);
			this.gBoxProperties.Controls.Add(this.lblYPos);
			this.gBoxProperties.Controls.Add(this.txtXPos);
			this.gBoxProperties.Controls.Add(this.lblXPos);
			this.gBoxProperties.Controls.Add(this.txtID);
			this.gBoxProperties.Controls.Add(this.lblID);
			this.gBoxProperties.Controls.Add(this.txtDescription);
			this.gBoxProperties.Controls.Add(this.lblDescription);
			this.gBoxProperties.Controls.Add(this.btnImageBrowse2);
			this.gBoxProperties.Controls.Add(this.txtImage2);
			this.gBoxProperties.Controls.Add(this.txtOffSet);
			this.gBoxProperties.Controls.Add(this.lblOffset);
			this.gBoxProperties.Controls.Add(this.groupBox2);
			this.gBoxProperties.Controls.Add(this.groupBox1);
			this.gBoxProperties.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gBoxProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gBoxProperties.Location = new System.Drawing.Point(0, 0);
			this.gBoxProperties.Name = "gBoxProperties";
			this.gBoxProperties.Size = new System.Drawing.Size(248, 640);
			this.gBoxProperties.TabIndex = 2;
			this.gBoxProperties.TabStop = false;
			this.gBoxProperties.Text = "Select Button  Properties";
			// 
			// ticknofocus
			// 
			this.ticknofocus.Image = ((System.Drawing.Image)(resources.GetObject("ticknofocus.Image")));
			this.ticknofocus.Location = new System.Drawing.Point(214, 194);
			this.ticknofocus.Name = "ticknofocus";
			this.ticknofocus.Size = new System.Drawing.Size(24, 24);
			this.ticknofocus.TabIndex = 66;
			this.ticknofocus.TabStop = false;
			this.toolTips.SetToolTip(this.ticknofocus, "Click to remove the image from this propertie");
			this.ticknofocus.Visible = false;
			this.ticknofocus.Click += new System.EventHandler(this.ticknofocus_Click);
			// 
			// tickfocus
			// 
			this.tickfocus.Image = ((System.Drawing.Image)(resources.GetObject("tickfocus.Image")));
			this.tickfocus.Location = new System.Drawing.Point(214, 162);
			this.tickfocus.Name = "tickfocus";
			this.tickfocus.Size = new System.Drawing.Size(24, 24);
			this.tickfocus.TabIndex = 65;
			this.tickfocus.TabStop = false;
			this.toolTips.SetToolTip(this.tickfocus, "Click to remove the image from this propertie");
			this.tickfocus.Visible = false;
			this.tickfocus.Click += new System.EventHandler(this.tickfocus_Click);
			// 
			// txtHeight
			// 
			this.txtHeight.Location = new System.Drawing.Point(104, 112);
			this.txtHeight.Name = "txtHeight";
			this.txtHeight.Size = new System.Drawing.Size(40, 20);
			this.txtHeight.TabIndex = 61;
			this.txtHeight.Text = "";
			this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label4
			// 
			this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label4.Location = new System.Drawing.Point(104, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 16);
			this.label4.TabIndex = 60;
			this.label4.Text = "Height";
			// 
			// txtWidth
			// 
			this.txtWidth.Location = new System.Drawing.Point(56, 112);
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
			this.label5.Location = new System.Drawing.Point(56, 96);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 58;
			this.label5.Text = "Width";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 512);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 16);
			this.label3.TabIndex = 57;
			this.label3.Text = "Disabled Color";
			// 
			// txtdisabledcolor
			// 
			this.txtdisabledcolor.Location = new System.Drawing.Point(144, 512);
			this.txtdisabledcolor.Name = "txtdisabledcolor";
			this.txtdisabledcolor.Size = new System.Drawing.Size(96, 20);
			this.txtdisabledcolor.TabIndex = 56;
			this.txtdisabledcolor.Text = "ff000000";
			// 
			// btndisabledcolor
			// 
			this.btndisabledcolor.BackColor = System.Drawing.SystemColors.Control;
			this.btndisabledcolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btndisabledcolor.Location = new System.Drawing.Point(104, 512);
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
			this.cboxalign.Location = new System.Drawing.Point(152, 136);
			this.cboxalign.Name = "cboxalign";
			this.cboxalign.Size = new System.Drawing.Size(88, 21);
			this.cboxalign.TabIndex = 54;
			this.cboxalign.Text = "Left";
			// 
			// label2
			// 
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Location = new System.Drawing.Point(104, 144);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 53;
			this.label2.Text = "Align";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtYoffset
			// 
			this.txtYoffset.Location = new System.Drawing.Point(96, 584);
			this.txtYoffset.Name = "txtYoffset";
			this.txtYoffset.Size = new System.Drawing.Size(144, 20);
			this.txtYoffset.TabIndex = 52;
			this.txtYoffset.Text = "";
			this.txtYoffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(8, 584);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 51;
			this.label1.Text = "Text Y  OffSet";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblcolor2
			// 
			this.lblcolor2.Location = new System.Drawing.Point(8, 488);
			this.lblcolor2.Name = "lblcolor2";
			this.lblcolor2.Size = new System.Drawing.Size(88, 16);
			this.lblcolor2.TabIndex = 48;
			this.lblcolor2.Text = "Diffuse Color";
			// 
			// lblColor1
			// 
			this.lblColor1.Location = new System.Drawing.Point(8, 464);
			this.lblColor1.Name = "lblColor1";
			this.lblColor1.Size = new System.Drawing.Size(88, 16);
			this.lblColor1.TabIndex = 47;
			this.lblColor1.Text = "Text Key";
			// 
			// txtdiffusecolor
			// 
			this.txtdiffusecolor.Location = new System.Drawing.Point(144, 488);
			this.txtdiffusecolor.Name = "txtdiffusecolor";
			this.txtdiffusecolor.Size = new System.Drawing.Size(96, 20);
			this.txtdiffusecolor.TabIndex = 46;
			this.txtdiffusecolor.Text = "ff000000";
			// 
			// btnColorDefuse
			// 
			this.btnColorDefuse.BackColor = System.Drawing.SystemColors.Control;
			this.btnColorDefuse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnColorDefuse.Location = new System.Drawing.Point(104, 488);
			this.btnColorDefuse.Name = "btnColorDefuse";
			this.btnColorDefuse.Size = new System.Drawing.Size(32, 20);
			this.btnColorDefuse.TabIndex = 45;
			this.btnColorDefuse.Click += new System.EventHandler(this.btnColorDefuse_Click);
			// 
			// CboxLabel
			// 
			this.CboxLabel.Location = new System.Drawing.Point(56, 440);
			this.CboxLabel.Name = "CboxLabel";
			this.CboxLabel.Size = new System.Drawing.Size(184, 21);
			this.CboxLabel.TabIndex = 44;
			this.CboxLabel.Text = "No Label";
			// 
			// CboxFonts
			// 
			this.CboxFonts.Location = new System.Drawing.Point(56, 416);
			this.CboxFonts.Name = "CboxFonts";
			this.CboxFonts.Size = new System.Drawing.Size(184, 21);
			this.CboxFonts.TabIndex = 43;
			this.CboxFonts.Text = "10";
			// 
			// lblFonts
			// 
			this.lblFonts.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblFonts.Location = new System.Drawing.Point(8, 416);
			this.lblFonts.Name = "lblFonts";
			this.lblFonts.Size = new System.Drawing.Size(40, 16);
			this.lblFonts.TabIndex = 42;
			this.lblFonts.Text = "Font";
			this.lblFonts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtColorkey
			// 
			this.txtColorkey.Location = new System.Drawing.Point(144, 464);
			this.txtColorkey.Name = "txtColorkey";
			this.txtColorkey.Size = new System.Drawing.Size(96, 20);
			this.txtColorkey.TabIndex = 41;
			this.txtColorkey.Text = "ff000000";
			// 
			// btnColorkey
			// 
			this.btnColorkey.BackColor = System.Drawing.SystemColors.Control;
			this.btnColorkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnColorkey.Location = new System.Drawing.Point(104, 464);
			this.btnColorkey.Name = "btnColorkey";
			this.btnColorkey.Size = new System.Drawing.Size(32, 20);
			this.btnColorkey.TabIndex = 40;
			this.btnColorkey.Click += new System.EventHandler(this.btnLabelColor_Click);
			// 
			// btnIgnore
			// 
			this.btnIgnore.Enabled = false;
			this.btnIgnore.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnIgnore.Location = new System.Drawing.Point(88, 608);
			this.btnIgnore.Name = "btnIgnore";
			this.btnIgnore.Size = new System.Drawing.Size(64, 24);
			this.btnIgnore.TabIndex = 39;
			this.btnIgnore.Text = "Delete";
			this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
			// 
			// lblLabel
			// 
			this.lblLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblLabel.Location = new System.Drawing.Point(8, 440);
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
			this.btnSave.Location = new System.Drawing.Point(168, 608);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(72, 24);
			this.btnSave.TabIndex = 36;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnUpdate.Location = new System.Drawing.Point(8, 608);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(64, 24);
			this.btnUpdate.TabIndex = 35;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnImageBrowse
			// 
			this.btnImageBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnImageBrowse.Location = new System.Drawing.Point(8, 160);
			this.btnImageBrowse.Name = "btnImageBrowse";
			this.btnImageBrowse.Size = new System.Drawing.Size(200, 24);
			this.btnImageBrowse.TabIndex = 34;
			this.btnImageBrowse.Text = "Browse For Focus  Image";
			this.btnImageBrowse.Click += new System.EventHandler(this.btnImageBrowse_Click);
			// 
			// txtImage
			// 
			this.txtImage.Location = new System.Drawing.Point(8, 136);
			this.txtImage.Name = "txtImage";
			this.txtImage.Size = new System.Drawing.Size(16, 20);
			this.txtImage.TabIndex = 33;
			this.txtImage.Text = "";
			this.txtImage.Visible = false;
			// 
			// txtLeft
			// 
			this.txtLeft.Location = new System.Drawing.Point(200, 112);
			this.txtLeft.Name = "txtLeft";
			this.txtLeft.Size = new System.Drawing.Size(40, 20);
			this.txtLeft.TabIndex = 31;
			this.txtLeft.Text = "";
			this.txtLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// lblLeft
			// 
			this.lblLeft.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblLeft.Location = new System.Drawing.Point(200, 96);
			this.lblLeft.Name = "lblLeft";
			this.lblLeft.Size = new System.Drawing.Size(32, 16);
			this.lblLeft.TabIndex = 30;
			this.lblLeft.Text = "Left";
			this.lblLeft.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtRight
			// 
			this.txtRight.Location = new System.Drawing.Point(152, 112);
			this.txtRight.Name = "txtRight";
			this.txtRight.Size = new System.Drawing.Size(40, 20);
			this.txtRight.TabIndex = 29;
			this.txtRight.Text = "";
			this.txtRight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// lblRight
			// 
			this.lblRight.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblRight.Location = new System.Drawing.Point(152, 96);
			this.lblRight.Name = "lblRight";
			this.lblRight.Size = new System.Drawing.Size(40, 16);
			this.lblRight.TabIndex = 28;
			this.lblRight.Text = "Right";
			this.lblRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDown
			// 
			this.txtDown.Location = new System.Drawing.Point(200, 72);
			this.txtDown.Name = "txtDown";
			this.txtDown.Size = new System.Drawing.Size(40, 20);
			this.txtDown.TabIndex = 27;
			this.txtDown.Text = "";
			this.txtDown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// lblDown
			// 
			this.lblDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblDown.Location = new System.Drawing.Point(200, 56);
			this.lblDown.Name = "lblDown";
			this.lblDown.Size = new System.Drawing.Size(40, 16);
			this.lblDown.TabIndex = 26;
			this.lblDown.Text = "Down";
			this.lblDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtUp
			// 
			this.txtUp.Location = new System.Drawing.Point(152, 72);
			this.txtUp.Name = "txtUp";
			this.txtUp.Size = new System.Drawing.Size(40, 20);
			this.txtUp.TabIndex = 25;
			this.txtUp.Text = "";
			this.txtUp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// lblUp
			// 
			this.lblUp.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblUp.Location = new System.Drawing.Point(152, 56);
			this.lblUp.Name = "lblUp";
			this.lblUp.Size = new System.Drawing.Size(40, 16);
			this.lblUp.TabIndex = 24;
			this.lblUp.Text = "Up";
			this.lblUp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
			// 
			// btnImageBrowse2
			// 
			this.btnImageBrowse2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnImageBrowse2.Location = new System.Drawing.Point(8, 192);
			this.btnImageBrowse2.Name = "btnImageBrowse2";
			this.btnImageBrowse2.Size = new System.Drawing.Size(200, 24);
			this.btnImageBrowse2.TabIndex = 37;
			this.btnImageBrowse2.Text = "Browse For NoFocus Image";
			this.btnImageBrowse2.Click += new System.EventHandler(this.btnImageBrowse2_Click);
			// 
			// txtImage2
			// 
			this.txtImage2.Location = new System.Drawing.Point(32, 136);
			this.txtImage2.Name = "txtImage2";
			this.txtImage2.Size = new System.Drawing.Size(16, 20);
			this.txtImage2.TabIndex = 36;
			this.txtImage2.Text = "";
			this.txtImage2.Visible = false;
			// 
			// txtOffSet
			// 
			this.txtOffSet.Location = new System.Drawing.Point(96, 560);
			this.txtOffSet.Name = "txtOffSet";
			this.txtOffSet.Size = new System.Drawing.Size(144, 20);
			this.txtOffSet.TabIndex = 35;
			this.txtOffSet.Text = "";
			this.txtOffSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// lblOffset
			// 
			this.lblOffset.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblOffset.Location = new System.Drawing.Point(8, 560);
			this.lblOffset.Name = "lblOffset";
			this.lblOffset.Size = new System.Drawing.Size(88, 16);
			this.lblOffset.TabIndex = 34;
			this.lblOffset.Text = "Text X  OffSet";
			this.lblOffset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tickrightnofocus);
			this.groupBox2.Controls.Add(this.tickrightfocus);
			this.groupBox2.Controls.Add(this.btnrightfocus);
			this.groupBox2.Controls.Add(this.btnrightnofocus);
			this.groupBox2.Controls.Add(this.txtrightfocus);
			this.groupBox2.Controls.Add(this.txtrightnofocus);
			this.groupBox2.Location = new System.Drawing.Point(8, 320);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(232, 88);
			this.groupBox2.TabIndex = 63;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Texture Right";
			// 
			// tickrightnofocus
			// 
			this.tickrightnofocus.Image = ((System.Drawing.Image)(resources.GetObject("tickrightnofocus.Image")));
			this.tickrightnofocus.Location = new System.Drawing.Point(205, 57);
			this.tickrightnofocus.Name = "tickrightnofocus";
			this.tickrightnofocus.Size = new System.Drawing.Size(21, 24);
			this.tickrightnofocus.TabIndex = 70;
			this.tickrightnofocus.TabStop = false;
			this.toolTips.SetToolTip(this.tickrightnofocus, "Click to remove the image from this propertie");
			this.tickrightnofocus.Visible = false;
			this.tickrightnofocus.Click += new System.EventHandler(this.tickrightnofocus_Click);
			// 
			// tickrightfocus
			// 
			this.tickrightfocus.Image = ((System.Drawing.Image)(resources.GetObject("tickrightfocus.Image")));
			this.tickrightfocus.Location = new System.Drawing.Point(205, 25);
			this.tickrightfocus.Name = "tickrightfocus";
			this.tickrightfocus.Size = new System.Drawing.Size(21, 24);
			this.tickrightfocus.TabIndex = 69;
			this.tickrightfocus.TabStop = false;
			this.toolTips.SetToolTip(this.tickrightfocus, "Click to remove the image from this propertie");
			this.tickrightfocus.Visible = false;
			this.tickrightfocus.Click += new System.EventHandler(this.tickrightfocus_Click);
			// 
			// btnrightfocus
			// 
			this.btnrightfocus.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnrightfocus.Location = new System.Drawing.Point(8, 24);
			this.btnrightfocus.Name = "btnrightfocus";
			this.btnrightfocus.Size = new System.Drawing.Size(192, 24);
			this.btnrightfocus.TabIndex = 38;
			this.btnrightfocus.Text = "Browse For Focus  Image";
			this.btnrightfocus.Click += new System.EventHandler(this.btnrightfocus_Click);
			// 
			// btnrightnofocus
			// 
			this.btnrightnofocus.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnrightnofocus.Location = new System.Drawing.Point(8, 56);
			this.btnrightnofocus.Name = "btnrightnofocus";
			this.btnrightnofocus.Size = new System.Drawing.Size(192, 24);
			this.btnrightnofocus.TabIndex = 39;
			this.btnrightnofocus.Text = "Browse For NoFocus Image";
			this.btnrightnofocus.Click += new System.EventHandler(this.btnrightnofocus_Click);
			// 
			// txtrightfocus
			// 
			this.txtrightfocus.Location = new System.Drawing.Point(136, 8);
			this.txtrightfocus.Name = "txtrightfocus";
			this.txtrightfocus.Size = new System.Drawing.Size(16, 20);
			this.txtrightfocus.TabIndex = 67;
			this.txtrightfocus.Text = "";
			this.txtrightfocus.Visible = false;
			// 
			// txtrightnofocus
			// 
			this.txtrightnofocus.Location = new System.Drawing.Point(160, 8);
			this.txtrightnofocus.Name = "txtrightnofocus";
			this.txtrightnofocus.Size = new System.Drawing.Size(16, 20);
			this.txtrightnofocus.TabIndex = 68;
			this.txtrightnofocus.Text = "";
			this.txtrightnofocus.Visible = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tickleftnofocus);
			this.groupBox1.Controls.Add(this.btnleftfocus);
			this.groupBox1.Controls.Add(this.btnleftnofocus);
			this.groupBox1.Controls.Add(this.txtleftfocus);
			this.groupBox1.Controls.Add(this.txtleftnofocus);
			this.groupBox1.Controls.Add(this.tickleftfocus);
			this.groupBox1.Location = new System.Drawing.Point(8, 224);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 88);
			this.groupBox1.TabIndex = 64;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Texture Left";
			// 
			// tickleftnofocus
			// 
			this.tickleftnofocus.Image = ((System.Drawing.Image)(resources.GetObject("tickleftnofocus.Image")));
			this.tickleftnofocus.Location = new System.Drawing.Point(206, 56);
			this.tickleftnofocus.Name = "tickleftnofocus";
			this.tickleftnofocus.Size = new System.Drawing.Size(21, 24);
			this.tickleftnofocus.TabIndex = 68;
			this.tickleftnofocus.TabStop = false;
			this.toolTips.SetToolTip(this.tickleftnofocus, "Click to remove the image from this propertie");
			this.tickleftnofocus.Visible = false;
			this.tickleftnofocus.Click += new System.EventHandler(this.tickleftnofocus_Click);
			// 
			// btnleftfocus
			// 
			this.btnleftfocus.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnleftfocus.Location = new System.Drawing.Point(9, 23);
			this.btnleftfocus.Name = "btnleftfocus";
			this.btnleftfocus.Size = new System.Drawing.Size(192, 24);
			this.btnleftfocus.TabIndex = 38;
			this.btnleftfocus.Text = "Browse For Focus  Image";
			this.btnleftfocus.Click += new System.EventHandler(this.btnleftfocus_Click);
			// 
			// btnleftnofocus
			// 
			this.btnleftnofocus.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnleftnofocus.Location = new System.Drawing.Point(8, 56);
			this.btnleftnofocus.Name = "btnleftnofocus";
			this.btnleftnofocus.Size = new System.Drawing.Size(192, 24);
			this.btnleftnofocus.TabIndex = 39;
			this.btnleftnofocus.Text = "Browse For NoFocus Image";
			this.btnleftnofocus.Click += new System.EventHandler(this.btnleftnofocus_Click);
			// 
			// txtleftfocus
			// 
			this.txtleftfocus.Location = new System.Drawing.Point(128, 8);
			this.txtleftfocus.Name = "txtleftfocus";
			this.txtleftfocus.Size = new System.Drawing.Size(16, 20);
			this.txtleftfocus.TabIndex = 65;
			this.txtleftfocus.Text = "";
			this.txtleftfocus.Visible = false;
			// 
			// txtleftnofocus
			// 
			this.txtleftnofocus.Location = new System.Drawing.Point(152, 8);
			this.txtleftnofocus.Name = "txtleftnofocus";
			this.txtleftnofocus.Size = new System.Drawing.Size(16, 20);
			this.txtleftnofocus.TabIndex = 66;
			this.txtleftnofocus.Text = "";
			this.txtleftnofocus.Visible = false;
			// 
			// tickleftfocus
			// 
			this.tickleftfocus.Image = ((System.Drawing.Image)(resources.GetObject("tickleftfocus.Image")));
			this.tickleftfocus.Location = new System.Drawing.Point(206, 24);
			this.tickleftfocus.Name = "tickleftfocus";
			this.tickleftfocus.Size = new System.Drawing.Size(21, 24);
			this.tickleftfocus.TabIndex = 67;
			this.tickleftfocus.TabStop = false;
			this.toolTips.SetToolTip(this.tickleftfocus, "Click to remove the image from this propertie");
			this.tickleftfocus.Visible = false;
			this.tickleftfocus.Click += new System.EventHandler(this.tickleftfocus_Click);
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
			// FrmXSelectButton
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(248, 638);
			this.Controls.Add(this.gBoxProperties);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(800, 50);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmXSelectButton";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Load += new System.EventHandler(this.FrmXSelectButton_Load_1);
			this.gBoxProperties.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnImageBrowse_Click(object sender, System.EventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				String path = Path.GetFullPath(openFileDialog1.FileName);
				this.txtImage.Text = Path.GetFullPath(openFileDialog1.FileName);
				this.txtWidth.Text = (Image.FromFile(path).Width).ToString();
				this.txtHeight.Text = (Image.FromFile(path).Height).ToString();

				tickfocus.Visible = true;

				this.toolTips.SetToolTip(this.btnImageBrowse, Path.GetFileName(this.txtImage.Text));
			}
		}

		private void btnImageBrowse2_Click(object sender, System.EventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				String path = Path.GetFullPath(openFileDialog1.FileName);
				this.txtImage2.Text = Path.GetFullPath(openFileDialog1.FileName);

				ticknofocus.Visible = true;

				
				this.toolTips.SetToolTip(this.btnImageBrowse2, Path.GetFileName(this.txtImage2.Text));
			}
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

		private void btnColorDefuse_Click(object sender, System.EventArgs e)
		{
			if (this.colorDialog1.ShowDialog() == DialogResult.OK)
			{
				String Alpha =  (colorDialog1.Color.A.ToString("x") == "0" ? "00":colorDialog1.Color.A.ToString("x"));
				String Red	 =  (colorDialog1.Color.R.ToString("x") == "0" ? "00":colorDialog1.Color.R.ToString("x"));
				String Green =	(colorDialog1.Color.G.ToString("x") == "0" ? "00":colorDialog1.Color.G.ToString("x"));
				String Blue  =  (colorDialog1.Color.B.ToString("x") == "0" ? "00":colorDialog1.Color.B.ToString("x"));
				this.txtdiffusecolor.Text = Alpha += Red += Green += Blue;
				
				this.btnColorDefuse.BackColor = colorDialog1.Color;

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
			xb.Up = (this.txtUp.Text == "" ? "0" : this.txtUp.Text);
			xb.Down = (this.txtDown.Text == "" ? "0" : this.txtDown.Text);
			xb.Left = (this.txtLeft.Text == "" ? "0" : this.txtLeft.Text);
			xb.Right = (this.txtRight.Text == "" ? "0" : this.txtRight.Text);
			xb.XOffset = (this.txtOffSet.Text == "" ? "0" : this.txtOffSet.Text);
			xb.YOffset = (this.txtYoffset.Text == ""  ? "0" : this.txtYoffset.Text);
			xb.XWidth = (this.txtWidth.Text == "" ? "0" : this.txtWidth.Text);
			xb.YHieght = (this.txtHeight.Text == "" ? "0" : this.txtHeight.Text);
			xb.Align = this.cboxalign.Text;
			xb.Font = this.CboxFonts.Text;
			xb.Description = this.txtDescription.Text;

			if (txtColorkey.Text.Length <= 7)
			{
				txtColorkey.Text = "ff000000";
			}

			if (txtdiffusecolor.Text.Length <= 7)
			{
				txtdiffusecolor.Text = "ff000000";
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

			XColor xc3 = new XColor();
			xb.XColor.Add("colordiffuse", cb.BreakColor(xc3, txtdiffusecolor.Text));


			if (this.txtImage.Text == String.Empty)
			{
				this.txtImage.Text = "-";
			}

			if (this.txtImage2.Text == String.Empty)
			{
				this.txtImage2.Text = "-";
			}

			if (this.txtleftfocus.Text == String.Empty)
			{
				this.txtleftfocus.Text = "-";
			}

			if (this.txtleftnofocus.Text == String.Empty)
			{
				this.txtleftnofocus.Text = "-";
			}

			if (this.txtrightfocus.Text == String.Empty)
			{
				this.txtrightfocus.Text = "-";
			}

			if (this.txtrightnofocus.Text == String.Empty)
			{
				this.txtrightnofocus.Text = "-";
			}

			if (this.txtImage.Text != "-")
			{
				Picture pica = new Picture();
				pica.Path = this.txtImage.Text;
				pica.Picwidth = (Image.FromFile(pica.Path).Width).ToString();
				pica.Pichieght = (Image.FromFile(pica.Path).Height).ToString();
				xb.Picture.Add("textureFocus",pica);
			}
			else
			{
				Picture pica = new Picture();
				pica.Path = "-";
				xb.Picture.Add("textureFocus",pica);
			}

			if (this.txtImage2.Text != "-")
			{
				Picture picb = new Picture();
				picb.Path = this.txtImage2.Text;
				picb.Picwidth = (Image.FromFile(picb.Path.ToString()).Width).ToString();
				picb.Pichieght = (Image.FromFile(picb.Path.ToString()).Height).ToString();
				xb.Picture.Add("textureNoFocus",picb);
			}
			else
			{
				Picture pica = new Picture();
				pica.Path = "-";
				xb.Picture.Add("textureNoFocus",pica);
			}

			if (this.txtleftfocus.Text != "-")
			{
				Picture picb = new Picture();
				picb.Path = this.txtleftfocus.Text;
				picb.Picwidth = (Image.FromFile(picb.Path.ToString()).Width).ToString();
				picb.Pichieght = (Image.FromFile(picb.Path.ToString()).Height).ToString();
				xb.Picture.Add("textureLeft",picb);
			}
			else
			{
				Picture pica = new Picture();
				pica.Path = "-";
				xb.Picture.Add("textureLeft",pica);
			}

			if (this.txtleftnofocus.Text != "-")
			{
				Picture picb = new Picture();
				picb.Path = this.txtleftnofocus.Text;
				picb.Picwidth = (Image.FromFile(picb.Path.ToString()).Width).ToString();
				picb.Pichieght = (Image.FromFile(picb.Path.ToString()).Height).ToString();
				xb.Picture.Add("textureLeftFocus",picb);
			}
			else
			{
				Picture pica = new Picture();
				pica.Path = "-";
				xb.Picture.Add("textureLeftFocus",pica);
			}

			if (this.txtrightfocus.Text != "-")
			{
				Picture picb = new Picture();
				picb.Path = this.txtrightfocus.Text;
				picb.Picwidth = (Image.FromFile(picb.Path.ToString()).Width).ToString();
				picb.Pichieght = (Image.FromFile(picb.Path.ToString()).Height).ToString();
				xb.Picture.Add("textureRight",picb);
			}
			else
			{
				Picture pica = new Picture();
				pica.Path = "-";
				xb.Picture.Add("textureRight",pica);
			}

			if (this.txtrightnofocus.Text != "-")
			{
				Picture picb = new Picture();
				picb.Path = this.txtrightnofocus.Text;
				picb.Picwidth = (Image.FromFile(picb.Path.ToString()).Width).ToString();
				picb.Pichieght = (Image.FromFile(picb.Path.ToString()).Height).ToString();
				xb.Picture.Add("textureRightFocus",picb);
			}
			else
			{
				Picture pica = new Picture();
				pica.Path = "-";
				xb.Picture.Add("textureRightFocus",pica);
			}

			this.Render();
		}

		private void Render()
		{
			if (this.edit == false)
			{

				if (FirstTime)
				{
					F.AddXSelectButton(xb, this);
					FirstTime = false;
				}
				else
				{
					cc_xSelectButton.XB = this.xb;
				}
			}
			else
			{
				cc_xSelectButton.XB = this.xb;
			}
		}

		private void FrmXSelectButton_Load(object sender, System.EventArgs e)
		{
			
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
				F.SaveXSelectButton(xb);
				this.Close();
			}
		}

		private void btnIgnore_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you wish to Delete this Control? It cannot beundone","Warning",MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				xb.Save = false;
				cc_xSelectButton.Visible = false;

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

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void btnleftfocus_Click(object sender, System.EventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				String path = Path.GetFullPath(openFileDialog1.FileName);
				this.txtleftfocus.Text = Path.GetFullPath(openFileDialog1.FileName);

				tickleftfocus.Visible = true;

				
				this.toolTips.SetToolTip(this.btnleftfocus, Path.GetFileName(this.txtleftfocus.Text));
				
			}
		}

		private void btnleftnofocus_Click(object sender, System.EventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				String path = Path.GetFullPath(openFileDialog1.FileName);
				this.txtleftnofocus.Text = Path.GetFullPath(openFileDialog1.FileName);

				tickleftnofocus.Visible = true;

				this.toolTips.SetToolTip(this.btnleftnofocus, Path.GetFileName(this.txtleftnofocus.Text));
				
			}
		}

		private void btnrightfocus_Click(object sender, System.EventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				String path = Path.GetFullPath(openFileDialog1.FileName);
				this.txtrightfocus.Text = Path.GetFullPath(openFileDialog1.FileName);

				tickrightfocus.Visible = true;

				this.toolTips.SetToolTip(this.btnrightfocus, Path.GetFileName(this.txtrightfocus.Text));
				
			}
		}

		private void btnrightnofocus_Click(object sender, System.EventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				String path = Path.GetFullPath(openFileDialog1.FileName);
				this.txtrightnofocus.Text = Path.GetFullPath(openFileDialog1.FileName);

				tickrightnofocus.Visible = true;

				this.toolTips.SetToolTip(this.btnrightnofocus, Path.GetFileName(this.txtrightnofocus.Text));
			}
		}

		private void tickfocus_Click(object sender, System.EventArgs e)
		{
			this.txtImage.Text = "-";
			this.tickfocus.Visible = false;
		}

		private void ticknofocus_Click(object sender, System.EventArgs e)
		{
			this.txtImage2.Text = "-";
			this.ticknofocus.Visible = false;
		}

		private void tickleftfocus_Click(object sender, System.EventArgs e)
		{
			this.txtleftfocus.Text = "-";
			this.tickleftfocus.Visible = false;
		}

		private void tickleftnofocus_Click(object sender, System.EventArgs e)
		{
			this.txtleftnofocus.Text = "-";
			this.tickleftnofocus.Visible = false;
		}

		private void tickrightfocus_Click(object sender, System.EventArgs e)
		{
			this.txtrightfocus.Text = "-";
			this.tickrightfocus.Visible = false;
		}

		private void tickrightnofocus_Click(object sender, System.EventArgs e)
		{
			this.txtrightnofocus.Text = "-";
			this.tickrightnofocus.Visible = false;
		}

		private void FrmXSelectButton_Load_1(object sender, System.EventArgs e)
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
				xb = new XSelectButton();
			}
			else
			{
				if (backupxb == null)
				{
					backupxb = new XSelectButton();
					backupxb = xb;
				}

				this.btnIgnore.Enabled = true;

				this.txtXPos.Text = xb.Xpos;
				this.txtYPos.Text = xb.Ypos;
				this.CboxLabel.Text = xb.Labeltext;
				this.txtID.Text = xb.ID;
				this.txtUp.Text = xb.Up;
				this.txtDown.Text = xb.Down;
				this.txtLeft.Text = xb.Left;
				this.txtRight.Text = xb.Right;
				this.txtOffSet.Text = xb.XOffset;
				this.txtYoffset.Text = xb.YOffset;
				this.txtWidth.Text = xb.XWidth;
				this.txtHeight.Text = xb.YHieght;
				this.cboxalign.Text = xb.Align ;
				this.CboxFonts.Text = xb.Font;
				this.txtDescription.Text = xb.Description ;	
				this.txtColorkey.Text = xb.XColor["textcolor"].Color.ToString();
				this.txtdisabledcolor.Text = xb.XColor["disabledcolor"].Color.ToString();
				this.txtdiffusecolor.Text = xb.XColor["colordiffuse"].Color.ToString();

				this.btnColorkey.BackColor = Color.FromArgb(xb.XColor["textcolor"].R,xb.XColor["textcolor"].G,xb.XColor["textcolor"].B);
				this.btndisabledcolor.BackColor = Color.FromArgb(xb.XColor["disabledcolor"].R,xb.XColor["disabledcolor"].G,xb.XColor["disabledcolor"].B);
				this.btnColorDefuse.BackColor = Color.FromArgb(xb.XColor["colordiffuse"].R,xb.XColor["colordiffuse"].G,xb.XColor["colordiffuse"].B);

				this.txtImage.Text = xb.Picture["textureFocus"].Path;
				this.txtImage2.Text = xb.Picture["textureNoFocus"].Path;
				this.txtleftfocus.Text = xb.Picture["textureLeft"].Path;
				this.txtleftnofocus.Text = xb.Picture["textureLeftFocus"].Path;
				this.txtrightfocus.Text = xb.Picture["textureRight"].Path;
				this.txtrightnofocus.Text = xb.Picture["textureRightFocus"].Path;

				if (this.txtImage.Text == String.Empty)
				{
					this.tickfocus.Visible = false;
				}

				if (this.txtImage2.Text == String.Empty)
				{
					this.ticknofocus.Visible = false;
				}

				if (this.txtleftfocus.Text == String.Empty)
				{
					this.tickleftfocus.Visible = false;
				}

				if (this.txtleftnofocus.Text == String.Empty)
				{
					this.tickleftnofocus.Visible = false;
				}

				if (this.txtrightfocus.Text == String.Empty)
				{
					this.tickrightfocus.Visible = false;
				}

				if (this.txtrightnofocus.Text == String.Empty)
				{
					this.tickrightnofocus.Visible = false;
				}

				this.toolTips.SetToolTip(this.btnImageBrowse, Path.GetFileName(this.txtImage.Text));
				this.toolTips.SetToolTip(this.btnImageBrowse2, Path.GetFileName(this.txtImage2.Text));
				this.toolTips.SetToolTip(this.btnleftfocus, Path.GetFileName(this.txtleftfocus.Text));
				this.toolTips.SetToolTip(this.btnleftnofocus, Path.GetFileName(this.txtleftnofocus.Text));
				this.toolTips.SetToolTip(this.btnrightfocus, Path.GetFileName(this.txtrightfocus.Text));
				this.toolTips.SetToolTip(this.btnrightnofocus, Path.GetFileName(this.txtrightnofocus.Text));
			}	
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
