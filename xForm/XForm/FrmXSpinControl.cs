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
	/// Summary description for FrmXSpinControl.
	/// </summary>
	public class FrmXSpinControl : System.Windows.Forms.Form
	{
		private Boolean FirstTime = true;

		private CC_xSpinControl cc_xSpinControl;
		private FrmDesign f;
		private XSpinControl xb;
		private XSpinControl backupxb;
		private Boolean edit;

		private System.Windows.Forms.GroupBox gBoxProperties;
		private System.Windows.Forms.Label lblColor1;
		private System.Windows.Forms.Label lblFonts;
		private System.Windows.Forms.Button btnIgnore;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnUpdate;
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
		private System.Windows.Forms.CheckBox reverse;
		private System.Windows.Forms.PictureBox tickdownnofocus;
		private System.Windows.Forms.PictureBox tickdownfocus;
		private System.Windows.Forms.PictureBox tickupnofocus;
		private System.Windows.Forms.PictureBox tickupfocus;
		private System.Windows.Forms.ToolTip toolTips;
		private System.Windows.Forms.ComboBox CboxFonts;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.ComponentModel.IContainer components;

		public FrmXSpinControl()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public CC_xSpinControl cc_XSpinControl
		{
			get {return this.cc_xSpinControl;}
			set {this.cc_xSpinControl = value;}
		}

		public FrmDesign F
		{
			get {return this.f;}
			set {this.f = value;}
		}

		public XSpinControl XB
		{
			get {return this.xb;}
			set {this.xb = value;}
		}

		public XSpinControl BackupXB
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmXSpinControl));
			this.gBoxProperties = new System.Windows.Forms.GroupBox();
			this.reverse = new System.Windows.Forms.CheckBox();
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
			this.lblColor1 = new System.Windows.Forms.Label();
			this.CboxFonts = new System.Windows.Forms.ComboBox();
			this.lblFonts = new System.Windows.Forms.Label();
			this.txtColorkey = new System.Windows.Forms.TextBox();
			this.btnColorkey = new System.Windows.Forms.Button();
			this.btnIgnore = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
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
			this.txtOffSet = new System.Windows.Forms.TextBox();
			this.lblOffset = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnrightfocus = new System.Windows.Forms.Button();
			this.btnrightnofocus = new System.Windows.Forms.Button();
			this.txtrightfocus = new System.Windows.Forms.TextBox();
			this.txtrightnofocus = new System.Windows.Forms.TextBox();
			this.tickdownfocus = new System.Windows.Forms.PictureBox();
			this.tickdownnofocus = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnleftfocus = new System.Windows.Forms.Button();
			this.btnleftnofocus = new System.Windows.Forms.Button();
			this.txtleftfocus = new System.Windows.Forms.TextBox();
			this.txtleftnofocus = new System.Windows.Forms.TextBox();
			this.tickupfocus = new System.Windows.Forms.PictureBox();
			this.tickupnofocus = new System.Windows.Forms.PictureBox();
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
			this.gBoxProperties.Controls.Add(this.reverse);
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
			this.gBoxProperties.Controls.Add(this.lblColor1);
			this.gBoxProperties.Controls.Add(this.CboxFonts);
			this.gBoxProperties.Controls.Add(this.lblFonts);
			this.gBoxProperties.Controls.Add(this.txtColorkey);
			this.gBoxProperties.Controls.Add(this.btnColorkey);
			this.gBoxProperties.Controls.Add(this.btnIgnore);
			this.gBoxProperties.Controls.Add(this.btnSave);
			this.gBoxProperties.Controls.Add(this.btnUpdate);
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
			this.gBoxProperties.Controls.Add(this.txtOffSet);
			this.gBoxProperties.Controls.Add(this.lblOffset);
			this.gBoxProperties.Controls.Add(this.groupBox2);
			this.gBoxProperties.Controls.Add(this.groupBox1);
			this.gBoxProperties.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gBoxProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gBoxProperties.Location = new System.Drawing.Point(0, 0);
			this.gBoxProperties.Name = "gBoxProperties";
			this.gBoxProperties.Size = new System.Drawing.Size(248, 576);
			this.gBoxProperties.TabIndex = 2;
			this.gBoxProperties.TabStop = false;
			this.gBoxProperties.Text = "Button Properties";
			this.gBoxProperties.Enter += new System.EventHandler(this.gBoxProperties_Enter);
			// 
			// reverse
			// 
			this.reverse.Location = new System.Drawing.Point(16, 136);
			this.reverse.Name = "reverse";
			this.reverse.Size = new System.Drawing.Size(88, 24);
			this.reverse.TabIndex = 65;
			this.reverse.Text = "Reversed";
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
			this.label3.Location = new System.Drawing.Point(8, 448);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 16);
			this.label3.TabIndex = 57;
			this.label3.Text = "Disabled Color";
			// 
			// txtdisabledcolor
			// 
			this.txtdisabledcolor.Location = new System.Drawing.Point(144, 448);
			this.txtdisabledcolor.Name = "txtdisabledcolor";
			this.txtdisabledcolor.Size = new System.Drawing.Size(96, 20);
			this.txtdisabledcolor.TabIndex = 56;
			this.txtdisabledcolor.Text = "ff000000";
			// 
			// btndisabledcolor
			// 
			this.btndisabledcolor.BackColor = System.Drawing.SystemColors.Control;
			this.btndisabledcolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btndisabledcolor.Location = new System.Drawing.Point(104, 448);
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
			this.txtYoffset.Location = new System.Drawing.Point(96, 520);
			this.txtYoffset.Name = "txtYoffset";
			this.txtYoffset.Size = new System.Drawing.Size(144, 20);
			this.txtYoffset.TabIndex = 52;
			this.txtYoffset.Text = "";
			this.txtYoffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(8, 520);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 51;
			this.label1.Text = "Text Y  OffSet";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblColor1
			// 
			this.lblColor1.Location = new System.Drawing.Point(8, 400);
			this.lblColor1.Name = "lblColor1";
			this.lblColor1.Size = new System.Drawing.Size(88, 16);
			this.lblColor1.TabIndex = 47;
			this.lblColor1.Text = "Text Color";
			// 
			// CboxFonts
			// 
			this.CboxFonts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CboxFonts.ItemHeight = 13;
			this.CboxFonts.Location = new System.Drawing.Point(56, 352);
			this.CboxFonts.Name = "CboxFonts";
			this.CboxFonts.Size = new System.Drawing.Size(184, 21);
			this.CboxFonts.TabIndex = 43;
			this.CboxFonts.Text = "10";
			// 
			// lblFonts
			// 
			this.lblFonts.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblFonts.Location = new System.Drawing.Point(8, 352);
			this.lblFonts.Name = "lblFonts";
			this.lblFonts.Size = new System.Drawing.Size(40, 16);
			this.lblFonts.TabIndex = 42;
			this.lblFonts.Text = "Font";
			this.lblFonts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtColorkey
			// 
			this.txtColorkey.Location = new System.Drawing.Point(144, 400);
			this.txtColorkey.Name = "txtColorkey";
			this.txtColorkey.Size = new System.Drawing.Size(96, 20);
			this.txtColorkey.TabIndex = 41;
			this.txtColorkey.Text = "ff000000";
			// 
			// btnColorkey
			// 
			this.btnColorkey.BackColor = System.Drawing.SystemColors.Control;
			this.btnColorkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnColorkey.Location = new System.Drawing.Point(104, 400);
			this.btnColorkey.Name = "btnColorkey";
			this.btnColorkey.Size = new System.Drawing.Size(32, 20);
			this.btnColorkey.TabIndex = 40;
			this.btnColorkey.Click += new System.EventHandler(this.btnLabelColor_Click);
			// 
			// btnIgnore
			// 
			this.btnIgnore.Enabled = false;
			this.btnIgnore.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnIgnore.Location = new System.Drawing.Point(88, 544);
			this.btnIgnore.Name = "btnIgnore";
			this.btnIgnore.Size = new System.Drawing.Size(64, 24);
			this.btnIgnore.TabIndex = 39;
			this.btnIgnore.Text = "Delete";
			this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
			// 
			// btnSave
			// 
			this.btnSave.Enabled = false;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSave.Location = new System.Drawing.Point(168, 544);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(72, 24);
			this.btnSave.TabIndex = 36;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnUpdate.Location = new System.Drawing.Point(8, 544);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(64, 24);
			this.btnUpdate.TabIndex = 35;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
			// txtOffSet
			// 
			this.txtOffSet.Location = new System.Drawing.Point(96, 496);
			this.txtOffSet.Name = "txtOffSet";
			this.txtOffSet.Size = new System.Drawing.Size(144, 20);
			this.txtOffSet.TabIndex = 35;
			this.txtOffSet.Text = "";
			this.txtOffSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// lblOffset
			// 
			this.lblOffset.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblOffset.Location = new System.Drawing.Point(8, 496);
			this.lblOffset.Name = "lblOffset";
			this.lblOffset.Size = new System.Drawing.Size(88, 16);
			this.lblOffset.TabIndex = 34;
			this.lblOffset.Text = "Text X  OffSet";
			this.lblOffset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnrightfocus);
			this.groupBox2.Controls.Add(this.btnrightnofocus);
			this.groupBox2.Controls.Add(this.txtrightfocus);
			this.groupBox2.Controls.Add(this.txtrightnofocus);
			this.groupBox2.Controls.Add(this.tickdownfocus);
			this.groupBox2.Controls.Add(this.tickdownnofocus);
			this.groupBox2.Location = new System.Drawing.Point(8, 256);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(232, 88);
			this.groupBox2.TabIndex = 63;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Texture Down";
			// 
			// btnrightfocus
			// 
			this.btnrightfocus.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnrightfocus.Location = new System.Drawing.Point(8, 24);
			this.btnrightfocus.Name = "btnrightfocus";
			this.btnrightfocus.Size = new System.Drawing.Size(192, 24);
			this.btnrightfocus.TabIndex = 38;
			this.btnrightfocus.Text = "Browse For No Focus  Image";
			this.btnrightfocus.Click += new System.EventHandler(this.btnrightfocus_Click);
			// 
			// btnrightnofocus
			// 
			this.btnrightnofocus.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnrightnofocus.Location = new System.Drawing.Point(8, 56);
			this.btnrightnofocus.Name = "btnrightnofocus";
			this.btnrightnofocus.Size = new System.Drawing.Size(192, 24);
			this.btnrightnofocus.TabIndex = 39;
			this.btnrightnofocus.Text = "Browse For Focus Image";
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
			// tickdownfocus
			// 
			this.tickdownfocus.Image = ((System.Drawing.Image)(resources.GetObject("tickdownfocus.Image")));
			this.tickdownfocus.Location = new System.Drawing.Point(204, 24);
			this.tickdownfocus.Name = "tickdownfocus";
			this.tickdownfocus.Size = new System.Drawing.Size(24, 24);
			this.tickdownfocus.TabIndex = 76;
			this.tickdownfocus.TabStop = false;
			this.toolTips.SetToolTip(this.tickdownfocus, "Click to remove the image from this propertie");
			this.tickdownfocus.Visible = false;
			this.tickdownfocus.Click += new System.EventHandler(this.tickdownfocus_Click);
			// 
			// tickdownnofocus
			// 
			this.tickdownnofocus.Image = ((System.Drawing.Image)(resources.GetObject("tickdownnofocus.Image")));
			this.tickdownnofocus.Location = new System.Drawing.Point(204, 56);
			this.tickdownnofocus.Name = "tickdownnofocus";
			this.tickdownnofocus.Size = new System.Drawing.Size(24, 24);
			this.tickdownnofocus.TabIndex = 78;
			this.tickdownnofocus.TabStop = false;
			this.toolTips.SetToolTip(this.tickdownnofocus, "Click to remove the image from this propertie");
			this.tickdownnofocus.Visible = false;
			this.tickdownnofocus.Click += new System.EventHandler(this.tickdownnofocus_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnleftfocus);
			this.groupBox1.Controls.Add(this.btnleftnofocus);
			this.groupBox1.Controls.Add(this.txtleftfocus);
			this.groupBox1.Controls.Add(this.txtleftnofocus);
			this.groupBox1.Controls.Add(this.tickupfocus);
			this.groupBox1.Controls.Add(this.tickupnofocus);
			this.groupBox1.Location = new System.Drawing.Point(8, 168);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 88);
			this.groupBox1.TabIndex = 64;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Texture Up";
			// 
			// btnleftfocus
			// 
			this.btnleftfocus.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnleftfocus.Location = new System.Drawing.Point(8, 24);
			this.btnleftfocus.Name = "btnleftfocus";
			this.btnleftfocus.Size = new System.Drawing.Size(192, 24);
			this.btnleftfocus.TabIndex = 38;
			this.btnleftfocus.Text = "Browse For No Focus  Image";
			this.btnleftfocus.Click += new System.EventHandler(this.btnleftfocus_Click);
			// 
			// btnleftnofocus
			// 
			this.btnleftnofocus.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnleftnofocus.Location = new System.Drawing.Point(8, 56);
			this.btnleftnofocus.Name = "btnleftnofocus";
			this.btnleftnofocus.Size = new System.Drawing.Size(192, 24);
			this.btnleftnofocus.TabIndex = 39;
			this.btnleftnofocus.Text = "Browse For Focus Image";
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
			// tickupfocus
			// 
			this.tickupfocus.Image = ((System.Drawing.Image)(resources.GetObject("tickupfocus.Image")));
			this.tickupfocus.Location = new System.Drawing.Point(204, 24);
			this.tickupfocus.Name = "tickupfocus";
			this.tickupfocus.Size = new System.Drawing.Size(40, 24);
			this.tickupfocus.TabIndex = 79;
			this.tickupfocus.TabStop = false;
			this.toolTips.SetToolTip(this.tickupfocus, "Click to remove the image from this propertie");
			this.tickupfocus.Visible = false;
			this.tickupfocus.Click += new System.EventHandler(this.tickupfocus_Click);
			// 
			// tickupnofocus
			// 
			this.tickupnofocus.Image = ((System.Drawing.Image)(resources.GetObject("tickupnofocus.Image")));
			this.tickupnofocus.Location = new System.Drawing.Point(204, 56);
			this.tickupnofocus.Name = "tickupnofocus";
			this.tickupnofocus.Size = new System.Drawing.Size(40, 24);
			this.tickupnofocus.TabIndex = 77;
			this.tickupnofocus.TabStop = false;
			this.toolTips.SetToolTip(this.tickupnofocus, "Click to remove the image from this propertie");
			this.tickupnofocus.Visible = false;
			this.tickupnofocus.Click += new System.EventHandler(this.tickupnofocus_Click);
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
			// FrmXSpinControl
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(248, 582);
			this.Controls.Add(this.gBoxProperties);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(800, 50);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmXSpinControl";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Load += new System.EventHandler(this.FrmXSpinControl_Load);
			this.gBoxProperties.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
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
			xb.Subtype = "Text";

			if (this.reverse.Checked == true)
			{
				xb.Reverse = "true";
			}
			else
			{
				xb.Reverse = "false";
			}

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

			if (this.txtleftfocus.Text != "-")
			{
				Picture picb = new Picture();
				picb.Path = this.txtleftfocus.Text;
				picb.Picwidth = (Image.FromFile(picb.Path.ToString()).Width).ToString();
				picb.Pichieght = (Image.FromFile(picb.Path.ToString()).Height).ToString();
				xb.Picture.Add("textureUp",picb);
			}
			else
			{
				Picture pica = new Picture();
				pica.Path = "-";
				xb.Picture.Add("textureUp",pica);
			}

			if (this.txtleftnofocus.Text != "-")
			{
				Picture picb = new Picture();
				picb.Path = this.txtleftnofocus.Text;
				picb.Picwidth = (Image.FromFile(picb.Path.ToString()).Width).ToString();
				picb.Pichieght = (Image.FromFile(picb.Path.ToString()).Height).ToString();
				xb.Picture.Add("textureUpFocus",picb);
			}
			else
			{
				Picture pica = new Picture();
				pica.Path = "-";
				xb.Picture.Add("textureUpFocus",pica);
			}

			if (this.txtrightfocus.Text != "-")
			{
				Picture picb = new Picture();
				picb.Path = this.txtrightfocus.Text;
				picb.Picwidth = (Image.FromFile(picb.Path.ToString()).Width).ToString();
				picb.Pichieght = (Image.FromFile(picb.Path.ToString()).Height).ToString();
				xb.Picture.Add("textureDown",picb);
			}
			else
			{
				Picture pica = new Picture();
				pica.Path = "-";
				xb.Picture.Add("textureDown",pica);
			}

			if (this.txtrightnofocus.Text != "-")
			{
				Picture picb = new Picture();
				picb.Path = this.txtrightnofocus.Text;
				picb.Picwidth = (Image.FromFile(picb.Path.ToString()).Width).ToString();
				picb.Pichieght = (Image.FromFile(picb.Path.ToString()).Height).ToString();
				xb.Picture.Add("textureDownFocus",picb);
			}
			else
			{
				Picture pica = new Picture();
				pica.Path = "-";
				xb.Picture.Add("textureDownFocus",pica);
			}

			this.Render();
		}

		private void Render()
		{
			if (this.edit == false)
			{

				if (FirstTime)
				{
					F.AddXSpinControl(xb, this);
					FirstTime = false;
				}
				else
				{
					cc_xSpinControl.XB = this.xb;
				}
			}
			else
			{
				cc_xSpinControl.XB = this.xb;
			}
		}

		private void gBoxProperties_Enter(object sender, System.EventArgs e)
		{
			
		}

		private void FrmXSpinControl_Load(object sender, System.EventArgs e)
		{
			GetFontList getFontList = new GetFontList();
			String [] Fonts = getFontList.getFontList(); //Application.StartupPath);

			for (Int32 i = 0; i < Fonts.Length - 1; i++)
			{
				this.CboxFonts.Items.Add(Fonts[i]);
			}

			if (xb == null)
			{
				xb = new XSpinControl();
			}
			else
			{
				if (backupxb == null)
				{
					backupxb = new XSpinControl();
					backupxb = xb;
				}

				this.btnIgnore.Enabled = true;

				this.txtXPos.Text = xb.Xpos;
				this.txtYPos.Text = xb.Ypos;
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

				this.btnColorkey.BackColor = Color.FromArgb(xb.XColor["textcolor"].R,xb.XColor["textcolor"].G,xb.XColor["textcolor"].B);
				this.btndisabledcolor.BackColor = Color.FromArgb(xb.XColor["disabledcolor"].R,xb.XColor["disabledcolor"].G,xb.XColor["disabledcolor"].B);
			

				this.txtleftfocus.Text = xb.Picture[0].Path;
				this.txtleftnofocus.Text = xb.Picture[1].Path;
				this.txtrightfocus.Text = xb.Picture[2].Path;
				this.txtrightnofocus.Text = xb.Picture[3].Path;

				if (xb.Reverse == "true")
				{
					this.reverse.Checked = true;
				}
				else
				{
					this.reverse.Checked = false;
				}

				if (this.txtleftfocus.Text != "-")
				{
					this.tickupfocus.Visible = true;
				}

				if (this.txtleftnofocus.Text != "-")
				{
					this.tickupnofocus.Visible = true;
				}

				if (this.txtrightfocus.Text != "-")
				{
					this.tickdownfocus.Visible = true;
				}

				if (this.txtrightnofocus.Text != "-")
				{
					this.tickdownnofocus.Visible = true;
				}
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
				F.SaveXSpinControl(xb);
				this.Close();
			}
		}

		private void btnIgnore_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you wish to Delete this Control? It cannot beundone","Warning",MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				xb.Save = false;
				cc_xSpinControl.Visible = false;

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
				this.txtWidth.Text = (Image.FromFile(path).Width).ToString();
				this.txtHeight.Text = (Image.FromFile(path).Height).ToString();

				tickupfocus.Visible = true;

				this.toolTips.SetToolTip(this.btnleftfocus, Path.GetFileName(this.txtleftfocus.Text));
			}
		}

		private void btnleftnofocus_Click(object sender, System.EventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				String path = Path.GetFullPath(openFileDialog1.FileName);
				this.txtleftnofocus.Text = Path.GetFullPath(openFileDialog1.FileName);

				tickupnofocus.Visible = true;

				
				this.toolTips.SetToolTip(this.btnrightnofocus, Path.GetFileName(this.txtleftnofocus.Text));
			}
		}

		private void btnrightfocus_Click(object sender, System.EventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				String path = Path.GetFullPath(openFileDialog1.FileName);
				this.txtrightfocus.Text = Path.GetFullPath(openFileDialog1.FileName);

				tickdownfocus.Visible = true;
				
				this.toolTips.SetToolTip(this.btnrightfocus, Path.GetFileName(this.txtrightfocus.Text));
			}
		}

		private void btnrightnofocus_Click(object sender, System.EventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				String path = Path.GetFullPath(openFileDialog1.FileName);
				this.txtrightnofocus.Text = Path.GetFullPath(openFileDialog1.FileName);

				tickdownnofocus.Visible = true;

				this.toolTips.SetToolTip(this.btnleftnofocus, Path.GetFileName(this.txtrightnofocus.Text));
			}
		}

		private void tickdownnofocus_Click(object sender, System.EventArgs e)
		{
			this.txtrightnofocus.Text = "-";
			this.tickdownnofocus.Visible = false;
		}

		private void tickupfocus_Click(object sender, System.EventArgs e)
		{
			this.txtleftfocus.Text = "-";
			this.tickupfocus.Visible = false;
		}

		private void tickupnofocus_Click(object sender, System.EventArgs e)
		{
			this.txtleftnofocus.Text = "-";
			this.tickupnofocus.Visible = false;
		}

		private void tickdownfocus_Click(object sender, System.EventArgs e)
		{
			this.txtrightfocus.Text = "-";
			this.tickdownfocus.Visible = false;
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
