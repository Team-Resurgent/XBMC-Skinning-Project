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
	/// Summary description for FrmXListControl.
	/// </summary>
	public class FrmXListControl : System.Windows.Forms.Form
	{
		private Boolean FirstTime = true;

		private CC_xListControl cc_xListControl;
		private FrmDesign f;
		private XListControl xb;
		private XListControl backupxb;
		private Boolean edit;

		private System.Windows.Forms.GroupBox gBoxProperties;
		private System.Windows.Forms.Label lblcolor2;
		private System.Windows.Forms.Label lblColor1;
		private System.Windows.Forms.Button btnColorDefuse;
		private System.Windows.Forms.ComboBox CboxFonts;
		private System.Windows.Forms.Label lblFonts;
		private System.Windows.Forms.Button btnIgnore;
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
		private System.Windows.Forms.ColorDialog colorDialog1;
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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtspincolor;
		private System.Windows.Forms.Button btnspincolor;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtthumbimage;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtspinh;
		private System.Windows.Forms.TextBox txtspinw;
		private System.Windows.Forms.TextBox txtspiny;
		private System.Windows.Forms.TextBox txtspinx;
		private System.Windows.Forms.PictureBox tickfocus;
		private System.Windows.Forms.PictureBox ticknofocus;
		private System.Windows.Forms.PictureBox tickthumb;
		private System.Windows.Forms.PictureBox tickupfocus;
		private System.Windows.Forms.PictureBox tickupnofocus;
		private System.Windows.Forms.PictureBox tickdownfocus;
		private System.Windows.Forms.PictureBox tickdownnofocus;
		private System.Windows.Forms.ToolTip toolTips;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.ComponentModel.IContainer components;

		public FrmXListControl()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public CC_xListControl cc_XListControl
		{
			get {return this.cc_xListControl;}
			set {this.cc_xListControl = value;}
		}

		public FrmDesign F
		{
			get {return this.f;}
			set {this.f = value;}
		}

		public XListControl XB
		{
			get {return this.xb;}
			set {this.xb = value;}
		}

		public XListControl BackupXB
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmXListControl));
			this.gBoxProperties = new System.Windows.Forms.GroupBox();
			this.tickthumb = new System.Windows.Forms.PictureBox();
			this.ticknofocus = new System.Windows.Forms.PictureBox();
			this.tickfocus = new System.Windows.Forms.PictureBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtspinh = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtspinw = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtspiny = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtspinx = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtthumbimage = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtspincolor = new System.Windows.Forms.TextBox();
			this.btnspincolor = new System.Windows.Forms.Button();
			this.txtHeight = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtWidth = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtdisabledcolor = new System.Windows.Forms.TextBox();
			this.btndisabledcolor = new System.Windows.Forms.Button();
			this.lblcolor2 = new System.Windows.Forms.Label();
			this.lblColor1 = new System.Windows.Forms.Label();
			this.txtdiffusecolor = new System.Windows.Forms.TextBox();
			this.btnColorDefuse = new System.Windows.Forms.Button();
			this.CboxFonts = new System.Windows.Forms.ComboBox();
			this.lblFonts = new System.Windows.Forms.Label();
			this.txtColorkey = new System.Windows.Forms.TextBox();
			this.btnColorkey = new System.Windows.Forms.Button();
			this.btnIgnore = new System.Windows.Forms.Button();
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tickdownnofocus = new System.Windows.Forms.PictureBox();
			this.btnrightfocus = new System.Windows.Forms.Button();
			this.btnrightnofocus = new System.Windows.Forms.Button();
			this.txtrightfocus = new System.Windows.Forms.TextBox();
			this.txtrightnofocus = new System.Windows.Forms.TextBox();
			this.tickdownfocus = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tickupnofocus = new System.Windows.Forms.PictureBox();
			this.btnleftfocus = new System.Windows.Forms.Button();
			this.btnleftnofocus = new System.Windows.Forms.Button();
			this.txtleftfocus = new System.Windows.Forms.TextBox();
			this.txtleftnofocus = new System.Windows.Forms.TextBox();
			this.tickupfocus = new System.Windows.Forms.PictureBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.gBoxProperties.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gBoxProperties
			// 
			this.gBoxProperties.Controls.Add(this.tickthumb);
			this.gBoxProperties.Controls.Add(this.ticknofocus);
			this.gBoxProperties.Controls.Add(this.tickfocus);
			this.gBoxProperties.Controls.Add(this.groupBox3);
			this.gBoxProperties.Controls.Add(this.txtthumbimage);
			this.gBoxProperties.Controls.Add(this.button1);
			this.gBoxProperties.Controls.Add(this.label1);
			this.gBoxProperties.Controls.Add(this.txtspincolor);
			this.gBoxProperties.Controls.Add(this.btnspincolor);
			this.gBoxProperties.Controls.Add(this.txtHeight);
			this.gBoxProperties.Controls.Add(this.label4);
			this.gBoxProperties.Controls.Add(this.txtWidth);
			this.gBoxProperties.Controls.Add(this.label5);
			this.gBoxProperties.Controls.Add(this.label3);
			this.gBoxProperties.Controls.Add(this.txtdisabledcolor);
			this.gBoxProperties.Controls.Add(this.btndisabledcolor);
			this.gBoxProperties.Controls.Add(this.lblcolor2);
			this.gBoxProperties.Controls.Add(this.lblColor1);
			this.gBoxProperties.Controls.Add(this.txtdiffusecolor);
			this.gBoxProperties.Controls.Add(this.btnColorDefuse);
			this.gBoxProperties.Controls.Add(this.CboxFonts);
			this.gBoxProperties.Controls.Add(this.lblFonts);
			this.gBoxProperties.Controls.Add(this.txtColorkey);
			this.gBoxProperties.Controls.Add(this.btnColorkey);
			this.gBoxProperties.Controls.Add(this.btnIgnore);
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
			this.gBoxProperties.Controls.Add(this.groupBox2);
			this.gBoxProperties.Controls.Add(this.groupBox1);
			this.gBoxProperties.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gBoxProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gBoxProperties.Location = new System.Drawing.Point(0, 0);
			this.gBoxProperties.Name = "gBoxProperties";
			this.gBoxProperties.Size = new System.Drawing.Size(248, 648);
			this.gBoxProperties.TabIndex = 2;
			this.gBoxProperties.TabStop = false;
			this.gBoxProperties.Text = "ListControl Properties";
			this.gBoxProperties.Enter += new System.EventHandler(this.gBoxProperties_Enter);
			// 
			// tickthumb
			// 
			this.tickthumb.Image = ((System.Drawing.Image)(resources.GetObject("tickthumb.Image")));
			this.tickthumb.Location = new System.Drawing.Point(214, 272);
			this.tickthumb.Name = "tickthumb";
			this.tickthumb.Size = new System.Drawing.Size(22, 24);
			this.tickthumb.TabIndex = 73;
			this.tickthumb.TabStop = false;
			this.toolTips.SetToolTip(this.tickthumb, "Click to remove the image from this propertie");
			this.tickthumb.Visible = false;
			this.tickthumb.Click += new System.EventHandler(this.tickthumb_Click);
			// 
			// ticknofocus
			// 
			this.ticknofocus.Image = ((System.Drawing.Image)(resources.GetObject("ticknofocus.Image")));
			this.ticknofocus.Location = new System.Drawing.Point(214, 240);
			this.ticknofocus.Name = "ticknofocus";
			this.ticknofocus.Size = new System.Drawing.Size(22, 24);
			this.ticknofocus.TabIndex = 72;
			this.ticknofocus.TabStop = false;
			this.toolTips.SetToolTip(this.ticknofocus, "Click to remove the image from this propertie");
			this.ticknofocus.Visible = false;
			this.ticknofocus.Click += new System.EventHandler(this.ticknofocus_Click);
			// 
			// tickfocus
			// 
			this.tickfocus.Image = ((System.Drawing.Image)(resources.GetObject("tickfocus.Image")));
			this.tickfocus.Location = new System.Drawing.Point(214, 208);
			this.tickfocus.Name = "tickfocus";
			this.tickfocus.Size = new System.Drawing.Size(22, 24);
			this.tickfocus.TabIndex = 71;
			this.tickfocus.TabStop = false;
			this.toolTips.SetToolTip(this.tickfocus, "Click to remove the image from this propertie");
			this.tickfocus.Visible = false;
			this.tickfocus.Click += new System.EventHandler(this.tickfocus_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtspinh);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.txtspinw);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.txtspiny);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.txtspinx);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Location = new System.Drawing.Point(8, 136);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(232, 64);
			this.groupBox3.TabIndex = 70;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Spin Properties";
			// 
			// txtspinh
			// 
			this.txtspinh.Location = new System.Drawing.Point(168, 32);
			this.txtspinh.Name = "txtspinh";
			this.txtspinh.Size = new System.Drawing.Size(40, 20);
			this.txtspinh.TabIndex = 70;
			this.txtspinh.Text = "";
			this.txtspinh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label2
			// 
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Location = new System.Drawing.Point(168, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 69;
			this.label2.Text = "Height";
			// 
			// txtspinw
			// 
			this.txtspinw.Location = new System.Drawing.Point(120, 32);
			this.txtspinw.Name = "txtspinw";
			this.txtspinw.Size = new System.Drawing.Size(40, 20);
			this.txtspinw.TabIndex = 68;
			this.txtspinw.Text = "";
			this.txtspinw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label6
			// 
			this.label6.Cursor = System.Windows.Forms.Cursors.Default;
			this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label6.Location = new System.Drawing.Point(120, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 16);
			this.label6.TabIndex = 67;
			this.label6.Text = "Width";
			// 
			// txtspiny
			// 
			this.txtspiny.Location = new System.Drawing.Point(72, 32);
			this.txtspiny.Name = "txtspiny";
			this.txtspiny.Size = new System.Drawing.Size(40, 20);
			this.txtspiny.TabIndex = 66;
			this.txtspiny.Text = "";
			this.txtspiny.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label7
			// 
			this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label7.Location = new System.Drawing.Point(72, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 16);
			this.label7.TabIndex = 65;
			this.label7.Text = "Y Pos";
			// 
			// txtspinx
			// 
			this.txtspinx.Location = new System.Drawing.Point(24, 32);
			this.txtspinx.Name = "txtspinx";
			this.txtspinx.Size = new System.Drawing.Size(40, 20);
			this.txtspinx.TabIndex = 64;
			this.txtspinx.Text = "";
			this.txtspinx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label8
			// 
			this.label8.Cursor = System.Windows.Forms.Cursors.Default;
			this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label8.Location = new System.Drawing.Point(24, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 16);
			this.label8.TabIndex = 63;
			this.label8.Text = "X Pos";
			// 
			// txtthumbimage
			// 
			this.txtthumbimage.Location = new System.Drawing.Point(232, 184);
			this.txtthumbimage.Name = "txtthumbimage";
			this.txtthumbimage.Size = new System.Drawing.Size(16, 20);
			this.txtthumbimage.TabIndex = 69;
			this.txtthumbimage.Text = "";
			this.txtthumbimage.Visible = false;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(8, 272);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(200, 24);
			this.button1.TabIndex = 68;
			this.button1.Text = "Browse For Thumb Image";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 592);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 67;
			this.label1.Text = "Spin Color";
			// 
			// txtspincolor
			// 
			this.txtspincolor.Location = new System.Drawing.Point(144, 592);
			this.txtspincolor.Name = "txtspincolor";
			this.txtspincolor.Size = new System.Drawing.Size(96, 20);
			this.txtspincolor.TabIndex = 66;
			this.txtspincolor.Text = "ff000000";
			// 
			// btnspincolor
			// 
			this.btnspincolor.BackColor = System.Drawing.SystemColors.Control;
			this.btnspincolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnspincolor.Location = new System.Drawing.Point(104, 592);
			this.btnspincolor.Name = "btnspincolor";
			this.btnspincolor.Size = new System.Drawing.Size(32, 20);
			this.btnspincolor.TabIndex = 65;
			this.btnspincolor.Click += new System.EventHandler(this.btnspincolor_Click);
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
			this.label3.Location = new System.Drawing.Point(8, 568);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 16);
			this.label3.TabIndex = 57;
			this.label3.Text = "Selected Color";
			// 
			// txtdisabledcolor
			// 
			this.txtdisabledcolor.Location = new System.Drawing.Point(144, 568);
			this.txtdisabledcolor.Name = "txtdisabledcolor";
			this.txtdisabledcolor.Size = new System.Drawing.Size(96, 20);
			this.txtdisabledcolor.TabIndex = 56;
			this.txtdisabledcolor.Text = "ff000000";
			// 
			// btndisabledcolor
			// 
			this.btndisabledcolor.BackColor = System.Drawing.SystemColors.Control;
			this.btndisabledcolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btndisabledcolor.Location = new System.Drawing.Point(104, 568);
			this.btndisabledcolor.Name = "btndisabledcolor";
			this.btndisabledcolor.Size = new System.Drawing.Size(32, 20);
			this.btndisabledcolor.TabIndex = 55;
			this.btndisabledcolor.Click += new System.EventHandler(this.btndisabledcolor_Click);
			// 
			// lblcolor2
			// 
			this.lblcolor2.Location = new System.Drawing.Point(8, 544);
			this.lblcolor2.Name = "lblcolor2";
			this.lblcolor2.Size = new System.Drawing.Size(88, 16);
			this.lblcolor2.TabIndex = 48;
			this.lblcolor2.Text = "Diffuse Color";
			// 
			// lblColor1
			// 
			this.lblColor1.Location = new System.Drawing.Point(8, 520);
			this.lblColor1.Name = "lblColor1";
			this.lblColor1.Size = new System.Drawing.Size(88, 16);
			this.lblColor1.TabIndex = 47;
			this.lblColor1.Text = "Text Key";
			// 
			// txtdiffusecolor
			// 
			this.txtdiffusecolor.Location = new System.Drawing.Point(144, 544);
			this.txtdiffusecolor.Name = "txtdiffusecolor";
			this.txtdiffusecolor.Size = new System.Drawing.Size(96, 20);
			this.txtdiffusecolor.TabIndex = 46;
			this.txtdiffusecolor.Text = "ff000000";
			// 
			// btnColorDefuse
			// 
			this.btnColorDefuse.BackColor = System.Drawing.SystemColors.Control;
			this.btnColorDefuse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnColorDefuse.Location = new System.Drawing.Point(104, 544);
			this.btnColorDefuse.Name = "btnColorDefuse";
			this.btnColorDefuse.Size = new System.Drawing.Size(32, 20);
			this.btnColorDefuse.TabIndex = 45;
			this.btnColorDefuse.Click += new System.EventHandler(this.btnColorDefuse_Click);
			// 
			// CboxFonts
			// 
			this.CboxFonts.Location = new System.Drawing.Point(56, 496);
			this.CboxFonts.Name = "CboxFonts";
			this.CboxFonts.Size = new System.Drawing.Size(184, 21);
			this.CboxFonts.TabIndex = 43;
			this.CboxFonts.Text = "10";
			// 
			// lblFonts
			// 
			this.lblFonts.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblFonts.Location = new System.Drawing.Point(16, 496);
			this.lblFonts.Name = "lblFonts";
			this.lblFonts.Size = new System.Drawing.Size(40, 16);
			this.lblFonts.TabIndex = 42;
			this.lblFonts.Text = "Font";
			this.lblFonts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtColorkey
			// 
			this.txtColorkey.Location = new System.Drawing.Point(144, 520);
			this.txtColorkey.Name = "txtColorkey";
			this.txtColorkey.Size = new System.Drawing.Size(96, 20);
			this.txtColorkey.TabIndex = 41;
			this.txtColorkey.Text = "ff000000";
			// 
			// btnColorkey
			// 
			this.btnColorkey.BackColor = System.Drawing.SystemColors.Control;
			this.btnColorkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnColorkey.Location = new System.Drawing.Point(104, 520);
			this.btnColorkey.Name = "btnColorkey";
			this.btnColorkey.Size = new System.Drawing.Size(32, 20);
			this.btnColorkey.TabIndex = 40;
			this.btnColorkey.Click += new System.EventHandler(this.btnLabelColor_Click);
			// 
			// btnIgnore
			// 
			this.btnIgnore.Enabled = false;
			this.btnIgnore.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnIgnore.Location = new System.Drawing.Point(88, 624);
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
			this.btnSave.Location = new System.Drawing.Point(168, 624);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(72, 24);
			this.btnSave.TabIndex = 36;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnUpdate.Location = new System.Drawing.Point(8, 624);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(64, 24);
			this.btnUpdate.TabIndex = 35;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnImageBrowse
			// 
			this.btnImageBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnImageBrowse.Location = new System.Drawing.Point(8, 208);
			this.btnImageBrowse.Name = "btnImageBrowse";
			this.btnImageBrowse.Size = new System.Drawing.Size(200, 24);
			this.btnImageBrowse.TabIndex = 34;
			this.btnImageBrowse.Text = "Browse For Focus  Image";
			this.btnImageBrowse.Click += new System.EventHandler(this.btnImageBrowse_Click);
			// 
			// txtImage
			// 
			this.txtImage.Location = new System.Drawing.Point(200, 208);
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
			this.btnImageBrowse2.Location = new System.Drawing.Point(8, 240);
			this.btnImageBrowse2.Name = "btnImageBrowse2";
			this.btnImageBrowse2.Size = new System.Drawing.Size(200, 24);
			this.btnImageBrowse2.TabIndex = 37;
			this.btnImageBrowse2.Text = "Browse For NoFocus Image";
			this.btnImageBrowse2.Click += new System.EventHandler(this.btnImageBrowse2_Click);
			// 
			// txtImage2
			// 
			this.txtImage2.Location = new System.Drawing.Point(224, 192);
			this.txtImage2.Name = "txtImage2";
			this.txtImage2.Size = new System.Drawing.Size(16, 20);
			this.txtImage2.TabIndex = 36;
			this.txtImage2.Text = "";
			this.txtImage2.Visible = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tickdownnofocus);
			this.groupBox2.Controls.Add(this.btnrightfocus);
			this.groupBox2.Controls.Add(this.btnrightnofocus);
			this.groupBox2.Controls.Add(this.txtrightfocus);
			this.groupBox2.Controls.Add(this.txtrightnofocus);
			this.groupBox2.Controls.Add(this.tickdownfocus);
			this.groupBox2.Location = new System.Drawing.Point(8, 400);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(232, 88);
			this.groupBox2.TabIndex = 63;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Texture Spin Down";
			// 
			// tickdownnofocus
			// 
			this.tickdownnofocus.Image = ((System.Drawing.Image)(resources.GetObject("tickdownnofocus.Image")));
			this.tickdownnofocus.Location = new System.Drawing.Point(206, 56);
			this.tickdownnofocus.Name = "tickdownnofocus";
			this.tickdownnofocus.Size = new System.Drawing.Size(22, 24);
			this.tickdownnofocus.TabIndex = 77;
			this.tickdownnofocus.TabStop = false;
			this.toolTips.SetToolTip(this.tickdownnofocus, "Click to remove the image from this propertie");
			this.tickdownnofocus.Visible = false;
			this.tickdownnofocus.Click += new System.EventHandler(this.tickdownnofocus_Click);
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
			// tickdownfocus
			// 
			this.tickdownfocus.Image = ((System.Drawing.Image)(resources.GetObject("tickdownfocus.Image")));
			this.tickdownfocus.Location = new System.Drawing.Point(206, 24);
			this.tickdownfocus.Name = "tickdownfocus";
			this.tickdownfocus.Size = new System.Drawing.Size(22, 24);
			this.tickdownfocus.TabIndex = 76;
			this.tickdownfocus.TabStop = false;
			this.toolTips.SetToolTip(this.tickdownfocus, "Click to remove the image from this propertie");
			this.tickdownfocus.Visible = false;
			this.tickdownfocus.Click += new System.EventHandler(this.tickdownfocus_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tickupnofocus);
			this.groupBox1.Controls.Add(this.btnleftfocus);
			this.groupBox1.Controls.Add(this.btnleftnofocus);
			this.groupBox1.Controls.Add(this.txtleftfocus);
			this.groupBox1.Controls.Add(this.txtleftnofocus);
			this.groupBox1.Controls.Add(this.tickupfocus);
			this.groupBox1.Location = new System.Drawing.Point(8, 304);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 88);
			this.groupBox1.TabIndex = 64;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Texture Spin Up";
			// 
			// tickupnofocus
			// 
			this.tickupnofocus.Image = ((System.Drawing.Image)(resources.GetObject("tickupnofocus.Image")));
			this.tickupnofocus.Location = new System.Drawing.Point(206, 56);
			this.tickupnofocus.Name = "tickupnofocus";
			this.tickupnofocus.Size = new System.Drawing.Size(22, 24);
			this.tickupnofocus.TabIndex = 75;
			this.tickupnofocus.TabStop = false;
			this.toolTips.SetToolTip(this.tickupnofocus, "Click to remove the image from this propertie");
			this.tickupnofocus.Visible = false;
			this.tickupnofocus.Click += new System.EventHandler(this.tickupnofocus_Click);
			// 
			// btnleftfocus
			// 
			this.btnleftfocus.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnleftfocus.Location = new System.Drawing.Point(8, 24);
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
			// tickupfocus
			// 
			this.tickupfocus.Image = ((System.Drawing.Image)(resources.GetObject("tickupfocus.Image")));
			this.tickupfocus.Location = new System.Drawing.Point(206, 24);
			this.tickupfocus.Name = "tickupfocus";
			this.tickupfocus.Size = new System.Drawing.Size(22, 24);
			this.tickupfocus.TabIndex = 74;
			this.tickupfocus.TabStop = false;
			this.toolTips.SetToolTip(this.tickupfocus, "Click to remove the image from this propertie");
			this.tickupfocus.Visible = false;
			this.tickupfocus.Click += new System.EventHandler(this.tickupfocus_Click);
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
			// FrmXListControl
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(248, 654);
			this.Controls.Add(this.gBoxProperties);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(800, 50);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmXListControl";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Load += new System.EventHandler(this.FrmXListControl_Load);
			this.gBoxProperties.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnupdateprops_Click(object sender, System.EventArgs e)
		{
		}

		private void btnImageBrowse_Click(object sender, System.EventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				String path = Path.GetFullPath(openFileDialog1.FileName);
				this.txtImage.Text = Path.GetFullPath(openFileDialog1.FileName);

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
			xb.ID = (this.txtID.Text == "" ? "0" : this.txtID.Text);
			xb.Up = (this.txtUp.Text == "" ? "0" : this.txtUp.Text);
			xb.Down = (this.txtDown.Text == "" ? "0" : this.txtDown.Text);
			xb.Left = (this.txtLeft.Text == "" ? "0" : this.txtLeft.Text);
			xb.Right = (this.txtRight.Text == "" ? "0" : this.txtRight.Text);
			xb.XWidth = (this.txtWidth.Text == "" ? "0" : this.txtWidth.Text);
			xb.YHieght = (this.txtHeight.Text == "" ? "0" : this.txtHeight.Text);
			xb.Font = this.CboxFonts.Text;
			xb.Description = this.txtDescription.Text;
			xb.Suffix = "|";

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

			if (this.txtthumbimage.Text == String.Empty)
			{
				this.txtthumbimage.Text = "-";
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
				picb.Picxpos = txtspinx.Text;
				picb.Picypos = txtspiny.Text;
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

			if (this.txtthumbimage.Text != "-")
			{
				Picture picb = new Picture();
				picb.Path = this.txtthumbimage.Text;
				picb.Picwidth = (Image.FromFile(picb.Path.ToString()).Width).ToString();
				picb.Pichieght = (Image.FromFile(picb.Path.ToString()).Height).ToString();
				xb.Picture.Add("image",picb);
			}
			else
			{
				Picture pica = new Picture();
				pica.Path = "-";
				xb.Picture.Add("image",pica);
			}

			if (txtColorkey.Text.Length <= 7)
			{
				txtColorkey.Text = "ff000000";
			}

			if (txtspincolor.Text.Length <= 7)
			{
				txtspincolor.Text = "ff000000";
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
			xb.XColor.Add("SelectedColor", cb.BreakColor(xc2, txtdisabledcolor.Text));

			XColor xc3 = new XColor();
			xb.XColor.Add("colordiffuse", cb.BreakColor(xc3, txtdiffusecolor.Text));

			XColor xc4 = new XColor();
			xb.XColor.Add("spinColor", cb.BreakColor(xc4, txtspincolor.Text));

			this.Render();
		}

		private void Render()
		{
			if (this.edit == false)
			{

				if (FirstTime)
				{
					F.AddXListControl(xb, this);
					FirstTime = false;
				}
				else
				{
					cc_xListControl.XB = this.xb;
				}
			}
			else
			{
				cc_xListControl.XB = this.xb;
			}
		}

		private void gBoxProperties_Enter(object sender, System.EventArgs e)
		{
			
		}

		private void FrmXListControl_Load(object sender, System.EventArgs e)
		{
			GetFontList getFontList = new GetFontList();
			String [] Fonts = getFontList.getFontList(); //Application.StartupPath);

			for (Int32 i = 0; i < Fonts.Length - 1; i++)
			{
				this.CboxFonts.Items.Add(Fonts[i]);
			}

			if (xb == null)
			{
				xb = new XListControl();
			}
			else
			{
				if (backupxb == null)
				{
					backupxb = new XListControl();
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

				this.txtWidth.Text = xb.XWidth;
				this.txtHeight.Text = xb.YHieght;
	
				this.CboxFonts.Text = xb.Font;
				this.txtDescription.Text = xb.Description ;	
				this.txtColorkey.Text = xb.XColor["textcolor"].Color.ToString();
				this.txtdisabledcolor.Text = xb.XColor["disabledcolor"].Color.ToString();
				this.txtdiffusecolor.Text = xb.XColor["colordiffuse"].Color.ToString();

				this.btnColorkey.BackColor = Color.FromArgb(xb.XColor["textcolor"].R,xb.XColor["textcolor"].G,xb.XColor["textcolor"].B);
				this.btndisabledcolor.BackColor = Color.FromArgb(xb.XColor["disabledcolor"].R,xb.XColor["disabledcolor"].G,xb.XColor["disabledcolor"].B);
				this.btnColorDefuse.BackColor = Color.FromArgb(xb.XColor["colordiffuse"].R,xb.XColor["colordiffuse"].G,xb.XColor["colordiffuse"].B);
				this.btnspincolor.BackColor = Color.FromArgb(xb.XColor["spinColor"].R,xb.XColor["spinColor"].G,xb.XColor["spinColor"].B);

				this.txtImage.Text = xb.Picture["textureFocus"].Path;
				this.txtImage2.Text = xb.Picture["textureNoFocus"].Path;
				this.txtleftfocus.Text = xb.Picture["textureUp"].Path;

				this.txtspinw.Text = xb.Picture["textureUp"].Picwidth;
				this.txtspinh.Text = xb.Picture["textureUp"].Pichieght;
				this.txtspinx.Text = xb.Picture["textureUp"].Picxpos;
				this.txtspiny.Text = xb.Picture["textureUp"].Picypos;

				this.txtleftnofocus.Text = xb.Picture["textureUpFocus"].Path;
				this.txtrightfocus.Text = xb.Picture["textureDown"].Path;
				this.txtrightnofocus.Text = xb.Picture["textureDownFocus"].Path;
				this.txtthumbimage.Text = xb.Picture["image"].Path;

				if (this.txtImage.Text == String.Empty)
				{
					this.tickfocus.Visible = false;
				}

				if (this.txtImage2.Text == String.Empty)
				{
					this.ticknofocus.Visible = true;
				}

				if (this.txtleftfocus.Text == String.Empty)
				{
					this.tickthumb.Visible = false;
				}

				if (this.txtleftnofocus.Text == String.Empty)
				{
					this.tickupfocus.Visible = false;
				}

				if (this.txtrightfocus.Text == String.Empty)
				{
					this.tickupnofocus.Visible = false;
				}

				if (this.txtrightnofocus.Text == String.Empty)
				{
					this.tickdownfocus.Visible = false;
				}

				if (this.txtthumbimage.Text == String.Empty)
				{
					this.tickdownnofocus.Visible = false;
				}

				this.toolTips.SetToolTip(this.btnImageBrowse, Path.GetFileName(this.txtImage.Text));
				this.toolTips.SetToolTip(this.btnImageBrowse2, Path.GetFileName(this.txtImage2.Text));
				this.toolTips.SetToolTip(this.button1, Path.GetFileName(this.txtleftfocus.Text));
				this.toolTips.SetToolTip(this.btnrightnofocus, Path.GetFileName(this.txtrightnofocus.Text));
				this.toolTips.SetToolTip(this.btnrightfocus, Path.GetFileName(this.txtrightfocus.Text));
				this.toolTips.SetToolTip(this.btnleftnofocus, Path.GetFileName(this.txtleftnofocus.Text));
				this.toolTips.SetToolTip(this.btnleftfocus, Path.GetFileName(this.txtleftfocus.Text));
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
				F.SaveXListControl(xb);
				this.Close();
			}
		}

		private void btnIgnore_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you wish to Delete this Control? It cannot beundone","Warning",MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				xb.Save = false;
				cc_xListControl.Visible = false;

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

				this.txtspinw.Text = (Image.FromFile(path).Width).ToString();
				this.txtspinh.Text = (Image.FromFile(path).Height).ToString();

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

				this.toolTips.SetToolTip(this.btnleftnofocus, Path.GetFileName(this.txtleftnofocus.Text));
				
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

				this.toolTips.SetToolTip(this.btnrightnofocus, Path.GetFileName(this.txtrightnofocus.Text));
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				String path = Path.GetFullPath(openFileDialog1.FileName);
				this.txtthumbimage.Text = Path.GetFullPath(openFileDialog1.FileName);

				tickthumb.Visible = true;

				this.toolTips.SetToolTip(this.button1, Path.GetFileName(this.txtleftfocus.Text));
				
			}
		}

		private void btnspincolor_Click(object sender, System.EventArgs e)
		{
			if (this.colorDialog1.ShowDialog() == DialogResult.OK)
			{
				String Alpha =  (colorDialog1.Color.A.ToString("x") == "0" ? "00":colorDialog1.Color.A.ToString("x"));
				String Red	 =  (colorDialog1.Color.R.ToString("x") == "0" ? "00":colorDialog1.Color.R.ToString("x"));
				String Green =	(colorDialog1.Color.G.ToString("x") == "0" ? "00":colorDialog1.Color.G.ToString("x"));
				String Blue  =  (colorDialog1.Color.B.ToString("x") == "0" ? "00":colorDialog1.Color.B.ToString("x"));
				this.txtspincolor.Text = Alpha += Red += Green += Blue;
				
				this.btnspincolor.BackColor = colorDialog1.Color;
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

		private void tickthumb_Click(object sender, System.EventArgs e)
		{
			this.txtleftfocus.Text = "-";
			this.tickthumb.Visible = false;
		}

		private void tickupfocus_Click(object sender, System.EventArgs e)
		{
			this.txtleftnofocus.Text = "-";
			this.tickupfocus.Visible = false;
		}

		private void tickupnofocus_Click(object sender, System.EventArgs e)
		{
			this.txtrightfocus.Text = "-";
			this.tickupnofocus.Visible = false;
		}

		private void tickdownfocus_Click(object sender, System.EventArgs e)
		{
			this.txtrightnofocus.Text = "-";
			this.tickdownfocus.Visible = false;
		}

		private void tickdownnofocus_Click(object sender, System.EventArgs e)
		{
			this.txtthumbimage.Text = "-";
			this.tickdownnofocus.Visible = false;
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
