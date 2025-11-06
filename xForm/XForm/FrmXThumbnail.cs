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
	/// Summary description for FrmXThumbnail.
	/// </summary>
	public class FrmXThumbnail : System.Windows.Forms.Form
	{
		private Boolean FirstTime = true;

		private CC_xThumbnail cc_xThumbnail;
		private FrmDesign f;
		private Xthumbnail xb;
		private Xthumbnail backupxb;
		private Boolean edit;

		private System.Windows.Forms.GroupBox gBoxProperties;
		private System.Windows.Forms.Label lblcolor2;
		private System.Windows.Forms.Label lblColor1;
		private System.Windows.Forms.Button btnColorDefuse;
		private System.Windows.Forms.ComboBox CboxFonts;
		private System.Windows.Forms.Label lblFonts;
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
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtspinh;
		private System.Windows.Forms.TextBox txtspinw;
		private System.Windows.Forms.TextBox txtspiny;
		private System.Windows.Forms.TextBox txtspinx;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtitemw;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txtitemh;
		private System.Windows.Forms.TextBox txtthumbh;
		private System.Windows.Forms.TextBox txtthumbw;
		private System.Windows.Forms.TextBox txttextureh;
		private System.Windows.Forms.TextBox txttexturew;
		private System.Windows.Forms.TextBox txtthumby;
		private System.Windows.Forms.TextBox txtthumbx;
		private System.Windows.Forms.TextBox txtbigtextureh;
		private System.Windows.Forms.TextBox txtbigtexturew;
		private System.Windows.Forms.TextBox txtbigthumby;
		private System.Windows.Forms.TextBox txtbigthumbx;
		private System.Windows.Forms.TextBox txtbigthumbh;
		private System.Windows.Forms.TextBox txtbigthumbw;
		private System.Windows.Forms.TextBox txtbigitemh;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox txtbigitemw;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Button btnIgnore;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.PictureBox ticknofocus;
		private System.Windows.Forms.PictureBox tickfocus;
		private System.Windows.Forms.PictureBox tickupfocus;
		private System.Windows.Forms.PictureBox tickupnofocus;
		private System.Windows.Forms.PictureBox tickdownfocus;
		private System.Windows.Forms.PictureBox tickdownnofocus;
		private System.Windows.Forms.ToolTip toolTips;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.ComponentModel.IContainer components;

		public FrmXThumbnail()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public CC_xThumbnail cc_XThumbnail
		{
			get {return this.cc_xThumbnail;}
			set {this.cc_xThumbnail = value;}
		}

		public FrmDesign F
		{
			get {return this.f;}
			set {this.f = value;}
		}

		public Xthumbnail XB
		{
			get {return this.xb;}
			set {this.xb = value;}
		}

		public Xthumbnail BackupXB
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmXThumbnail));
			this.gBoxProperties = new System.Windows.Forms.GroupBox();
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
			this.tickdownfocus = new System.Windows.Forms.PictureBox();
			this.tickdownnofocus = new System.Windows.Forms.PictureBox();
			this.btnrightfocus = new System.Windows.Forms.Button();
			this.btnrightnofocus = new System.Windows.Forms.Button();
			this.txtrightfocus = new System.Windows.Forms.TextBox();
			this.txtrightnofocus = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnleftfocus = new System.Windows.Forms.Button();
			this.btnleftnofocus = new System.Windows.Forms.Button();
			this.tickupfocus = new System.Windows.Forms.PictureBox();
			this.tickupnofocus = new System.Windows.Forms.PictureBox();
			this.txtleftnofocus = new System.Windows.Forms.TextBox();
			this.txtleftfocus = new System.Windows.Forms.TextBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnIgnore = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txttextureh = new System.Windows.Forms.TextBox();
			this.txttexturew = new System.Windows.Forms.TextBox();
			this.txtthumby = new System.Windows.Forms.TextBox();
			this.txtthumbx = new System.Windows.Forms.TextBox();
			this.txtthumbh = new System.Windows.Forms.TextBox();
			this.txtthumbw = new System.Windows.Forms.TextBox();
			this.txtitemh = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtitemw = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.txtbigtextureh = new System.Windows.Forms.TextBox();
			this.txtbigtexturew = new System.Windows.Forms.TextBox();
			this.txtbigthumby = new System.Windows.Forms.TextBox();
			this.txtbigthumbx = new System.Windows.Forms.TextBox();
			this.txtbigthumbh = new System.Windows.Forms.TextBox();
			this.txtbigthumbw = new System.Windows.Forms.TextBox();
			this.txtbigitemh = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.txtbigitemw = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.gBoxProperties.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// gBoxProperties
			// 
			this.gBoxProperties.Controls.Add(this.ticknofocus);
			this.gBoxProperties.Controls.Add(this.tickfocus);
			this.gBoxProperties.Controls.Add(this.groupBox3);
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
			this.gBoxProperties.Controls.Add(this.txtleftnofocus);
			this.gBoxProperties.Controls.Add(this.txtleftfocus);
			this.gBoxProperties.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gBoxProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gBoxProperties.Location = new System.Drawing.Point(8, 0);
			this.gBoxProperties.Name = "gBoxProperties";
			this.gBoxProperties.Size = new System.Drawing.Size(248, 624);
			this.gBoxProperties.TabIndex = 2;
			this.gBoxProperties.TabStop = false;
			this.gBoxProperties.Enter += new System.EventHandler(this.gBoxProperties_Enter);
			// 
			// ticknofocus
			// 
			this.ticknofocus.Image = ((System.Drawing.Image)(resources.GetObject("ticknofocus.Image")));
			this.ticknofocus.Location = new System.Drawing.Point(213, 240);
			this.ticknofocus.Name = "ticknofocus";
			this.ticknofocus.Size = new System.Drawing.Size(22, 24);
			this.ticknofocus.TabIndex = 82;
			this.ticknofocus.TabStop = false;
			this.toolTips.SetToolTip(this.ticknofocus, "Click to remove the image from this propertie");
			this.ticknofocus.Visible = false;
			this.ticknofocus.Click += new System.EventHandler(this.ticknofocus_Click);
			// 
			// tickfocus
			// 
			this.tickfocus.Image = ((System.Drawing.Image)(resources.GetObject("tickfocus.Image")));
			this.tickfocus.Location = new System.Drawing.Point(213, 208);
			this.tickfocus.Name = "tickfocus";
			this.tickfocus.Size = new System.Drawing.Size(22, 24);
			this.tickfocus.TabIndex = 83;
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
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 560);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 67;
			this.label1.Text = "Spin Color";
			// 
			// txtspincolor
			// 
			this.txtspincolor.Location = new System.Drawing.Point(144, 560);
			this.txtspincolor.Name = "txtspincolor";
			this.txtspincolor.Size = new System.Drawing.Size(96, 20);
			this.txtspincolor.TabIndex = 66;
			this.txtspincolor.Text = "ff000000";
			// 
			// btnspincolor
			// 
			this.btnspincolor.BackColor = System.Drawing.SystemColors.Control;
			this.btnspincolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnspincolor.Location = new System.Drawing.Point(104, 560);
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
			this.label3.Location = new System.Drawing.Point(8, 536);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 16);
			this.label3.TabIndex = 57;
			this.label3.Text = "Selected Color";
			// 
			// txtdisabledcolor
			// 
			this.txtdisabledcolor.Location = new System.Drawing.Point(144, 536);
			this.txtdisabledcolor.Name = "txtdisabledcolor";
			this.txtdisabledcolor.Size = new System.Drawing.Size(96, 20);
			this.txtdisabledcolor.TabIndex = 56;
			this.txtdisabledcolor.Text = "ff000000";
			// 
			// btndisabledcolor
			// 
			this.btndisabledcolor.BackColor = System.Drawing.SystemColors.Control;
			this.btndisabledcolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btndisabledcolor.Location = new System.Drawing.Point(104, 536);
			this.btndisabledcolor.Name = "btndisabledcolor";
			this.btndisabledcolor.Size = new System.Drawing.Size(32, 20);
			this.btndisabledcolor.TabIndex = 55;
			this.btndisabledcolor.Click += new System.EventHandler(this.btndisabledcolor_Click);
			// 
			// lblcolor2
			// 
			this.lblcolor2.Location = new System.Drawing.Point(8, 512);
			this.lblcolor2.Name = "lblcolor2";
			this.lblcolor2.Size = new System.Drawing.Size(88, 16);
			this.lblcolor2.TabIndex = 48;
			this.lblcolor2.Text = "Diffuse Color";
			// 
			// lblColor1
			// 
			this.lblColor1.Location = new System.Drawing.Point(8, 488);
			this.lblColor1.Name = "lblColor1";
			this.lblColor1.Size = new System.Drawing.Size(88, 16);
			this.lblColor1.TabIndex = 47;
			this.lblColor1.Text = "Text Key";
			// 
			// txtdiffusecolor
			// 
			this.txtdiffusecolor.Location = new System.Drawing.Point(144, 512);
			this.txtdiffusecolor.Name = "txtdiffusecolor";
			this.txtdiffusecolor.Size = new System.Drawing.Size(96, 20);
			this.txtdiffusecolor.TabIndex = 46;
			this.txtdiffusecolor.Text = "ff000000";
			// 
			// btnColorDefuse
			// 
			this.btnColorDefuse.BackColor = System.Drawing.SystemColors.Control;
			this.btnColorDefuse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnColorDefuse.Location = new System.Drawing.Point(104, 512);
			this.btnColorDefuse.Name = "btnColorDefuse";
			this.btnColorDefuse.Size = new System.Drawing.Size(32, 20);
			this.btnColorDefuse.TabIndex = 45;
			this.btnColorDefuse.Click += new System.EventHandler(this.btnColorDefuse_Click);
			// 
			// CboxFonts
			// 
			this.CboxFonts.Location = new System.Drawing.Point(56, 464);
			this.CboxFonts.Name = "CboxFonts";
			this.CboxFonts.Size = new System.Drawing.Size(184, 21);
			this.CboxFonts.TabIndex = 43;
			this.CboxFonts.Text = "10";
			// 
			// lblFonts
			// 
			this.lblFonts.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblFonts.Location = new System.Drawing.Point(16, 464);
			this.lblFonts.Name = "lblFonts";
			this.lblFonts.Size = new System.Drawing.Size(40, 16);
			this.lblFonts.TabIndex = 42;
			this.lblFonts.Text = "Font";
			this.lblFonts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtColorkey
			// 
			this.txtColorkey.Location = new System.Drawing.Point(144, 488);
			this.txtColorkey.Name = "txtColorkey";
			this.txtColorkey.Size = new System.Drawing.Size(96, 20);
			this.txtColorkey.TabIndex = 41;
			this.txtColorkey.Text = "ff000000";
			// 
			// btnColorkey
			// 
			this.btnColorkey.BackColor = System.Drawing.SystemColors.Control;
			this.btnColorkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnColorkey.Location = new System.Drawing.Point(104, 488);
			this.btnColorkey.Name = "btnColorkey";
			this.btnColorkey.Size = new System.Drawing.Size(32, 20);
			this.btnColorkey.TabIndex = 40;
			this.btnColorkey.Click += new System.EventHandler(this.btnLabelColor_Click);
			// 
			// btnImageBrowse
			// 
			this.btnImageBrowse.BackColor = System.Drawing.SystemColors.Control;
			this.btnImageBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnImageBrowse.Location = new System.Drawing.Point(7, 208);
			this.btnImageBrowse.Name = "btnImageBrowse";
			this.btnImageBrowse.Size = new System.Drawing.Size(202, 24);
			this.btnImageBrowse.TabIndex = 34;
			this.btnImageBrowse.Text = "Browse For Folder  Image";
			this.btnImageBrowse.Click += new System.EventHandler(this.btnImageBrowse_Click);
			// 
			// txtImage
			// 
			this.txtImage.Location = new System.Drawing.Point(232, 200);
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
			this.btnImageBrowse2.Location = new System.Drawing.Point(7, 240);
			this.btnImageBrowse2.Name = "btnImageBrowse2";
			this.btnImageBrowse2.Size = new System.Drawing.Size(202, 24);
			this.btnImageBrowse2.TabIndex = 37;
			this.btnImageBrowse2.Text = "Browse For Folder NoFocus Image";
			this.btnImageBrowse2.Click += new System.EventHandler(this.btnImageBrowse2_Click);
			// 
			// txtImage2
			// 
			this.txtImage2.Location = new System.Drawing.Point(232, 224);
			this.txtImage2.Name = "txtImage2";
			this.txtImage2.Size = new System.Drawing.Size(16, 20);
			this.txtImage2.TabIndex = 36;
			this.txtImage2.Text = "";
			this.txtImage2.Visible = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tickdownfocus);
			this.groupBox2.Controls.Add(this.tickdownnofocus);
			this.groupBox2.Controls.Add(this.btnrightfocus);
			this.groupBox2.Controls.Add(this.btnrightnofocus);
			this.groupBox2.Controls.Add(this.txtrightfocus);
			this.groupBox2.Controls.Add(this.txtrightnofocus);
			this.groupBox2.Location = new System.Drawing.Point(8, 368);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(232, 88);
			this.groupBox2.TabIndex = 63;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Texture Spin Down";
			// 
			// tickdownfocus
			// 
			this.tickdownfocus.Image = ((System.Drawing.Image)(resources.GetObject("tickdownfocus.Image")));
			this.tickdownfocus.Location = new System.Drawing.Point(204, 24);
			this.tickdownfocus.Name = "tickdownfocus";
			this.tickdownfocus.Size = new System.Drawing.Size(22, 24);
			this.tickdownfocus.TabIndex = 82;
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
			this.tickdownnofocus.Size = new System.Drawing.Size(22, 24);
			this.tickdownnofocus.TabIndex = 83;
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnleftfocus);
			this.groupBox1.Controls.Add(this.btnleftnofocus);
			this.groupBox1.Controls.Add(this.tickupfocus);
			this.groupBox1.Controls.Add(this.tickupnofocus);
			this.groupBox1.Location = new System.Drawing.Point(8, 272);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 88);
			this.groupBox1.TabIndex = 64;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Texture Spin Up";
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
			// tickupfocus
			// 
			this.tickupfocus.Image = ((System.Drawing.Image)(resources.GetObject("tickupfocus.Image")));
			this.tickupfocus.Location = new System.Drawing.Point(205, 24);
			this.tickupfocus.Name = "tickupfocus";
			this.tickupfocus.Size = new System.Drawing.Size(22, 24);
			this.tickupfocus.TabIndex = 80;
			this.tickupfocus.TabStop = false;
			this.toolTips.SetToolTip(this.tickupfocus, "Click to remove the image from this propertie");
			this.tickupfocus.Visible = false;
			this.tickupfocus.Click += new System.EventHandler(this.tickupfocus_Click);
			// 
			// tickupnofocus
			// 
			this.tickupnofocus.Image = ((System.Drawing.Image)(resources.GetObject("tickupnofocus.Image")));
			this.tickupnofocus.Location = new System.Drawing.Point(205, 56);
			this.tickupnofocus.Name = "tickupnofocus";
			this.tickupnofocus.Size = new System.Drawing.Size(22, 24);
			this.tickupnofocus.TabIndex = 81;
			this.tickupnofocus.TabStop = false;
			this.toolTips.SetToolTip(this.tickupnofocus, "Click to remove the image from this propertie");
			this.tickupnofocus.Visible = false;
			this.tickupnofocus.Click += new System.EventHandler(this.tickupnofocus_Click);
			// 
			// txtleftnofocus
			// 
			this.txtleftnofocus.Location = new System.Drawing.Point(232, 264);
			this.txtleftnofocus.Name = "txtleftnofocus";
			this.txtleftnofocus.Size = new System.Drawing.Size(16, 20);
			this.txtleftnofocus.TabIndex = 66;
			this.txtleftnofocus.Text = "";
			this.txtleftnofocus.Visible = false;
			// 
			// txtleftfocus
			// 
			this.txtleftfocus.Location = new System.Drawing.Point(232, 288);
			this.txtleftfocus.Name = "txtleftfocus";
			this.txtleftfocus.Size = new System.Drawing.Size(16, 20);
			this.txtleftfocus.TabIndex = 65;
			this.txtleftfocus.Text = "";
			this.txtleftfocus.Visible = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(264, 608);
			this.tabControl1.TabIndex = 71;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.gBoxProperties);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(256, 582);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Main Properties";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnIgnore);
			this.tabPage2.Controls.Add(this.btnSave);
			this.tabPage2.Controls.Add(this.btnUpdate);
			this.tabPage2.Controls.Add(this.groupBox4);
			this.tabPage2.Controls.Add(this.groupBox5);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(256, 582);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Item Properties";
			// 
			// btnIgnore
			// 
			this.btnIgnore.Enabled = false;
			this.btnIgnore.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnIgnore.Location = new System.Drawing.Point(96, 472);
			this.btnIgnore.Name = "btnIgnore";
			this.btnIgnore.Size = new System.Drawing.Size(64, 24);
			this.btnIgnore.TabIndex = 42;
			this.btnIgnore.Text = "Delete";
			this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
			// 
			// btnSave
			// 
			this.btnSave.Enabled = false;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSave.Location = new System.Drawing.Point(176, 472);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(72, 24);
			this.btnSave.TabIndex = 41;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnUpdate.Location = new System.Drawing.Point(16, 472);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(64, 24);
			this.btnUpdate.TabIndex = 40;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.txttextureh);
			this.groupBox4.Controls.Add(this.txttexturew);
			this.groupBox4.Controls.Add(this.txtthumby);
			this.groupBox4.Controls.Add(this.txtthumbx);
			this.groupBox4.Controls.Add(this.txtthumbh);
			this.groupBox4.Controls.Add(this.txtthumbw);
			this.groupBox4.Controls.Add(this.txtitemh);
			this.groupBox4.Controls.Add(this.label15);
			this.groupBox4.Controls.Add(this.label16);
			this.groupBox4.Controls.Add(this.label14);
			this.groupBox4.Controls.Add(this.label13);
			this.groupBox4.Controls.Add(this.label12);
			this.groupBox4.Controls.Add(this.label11);
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Controls.Add(this.txtitemw);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Location = new System.Drawing.Point(8, 8);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(240, 232);
			this.groupBox4.TabIndex = 0;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Standard Items";
			// 
			// txttextureh
			// 
			this.txttextureh.Location = new System.Drawing.Point(96, 192);
			this.txttextureh.Name = "txttextureh";
			this.txttextureh.Size = new System.Drawing.Size(136, 20);
			this.txttextureh.TabIndex = 15;
			this.txttextureh.Text = "";
			this.txttextureh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// txttexturew
			// 
			this.txttexturew.Location = new System.Drawing.Point(96, 168);
			this.txttexturew.Name = "txttexturew";
			this.txttexturew.Size = new System.Drawing.Size(136, 20);
			this.txttexturew.TabIndex = 14;
			this.txttexturew.Text = "";
			this.txttexturew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// txtthumby
			// 
			this.txtthumby.Location = new System.Drawing.Point(96, 144);
			this.txtthumby.Name = "txtthumby";
			this.txtthumby.Size = new System.Drawing.Size(136, 20);
			this.txtthumby.TabIndex = 13;
			this.txtthumby.Text = "";
			this.txtthumby.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// txtthumbx
			// 
			this.txtthumbx.Location = new System.Drawing.Point(96, 120);
			this.txtthumbx.Name = "txtthumbx";
			this.txtthumbx.Size = new System.Drawing.Size(136, 20);
			this.txtthumbx.TabIndex = 12;
			this.txtthumbx.Text = "";
			this.txtthumbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// txtthumbh
			// 
			this.txtthumbh.Location = new System.Drawing.Point(96, 96);
			this.txtthumbh.Name = "txtthumbh";
			this.txtthumbh.Size = new System.Drawing.Size(136, 20);
			this.txtthumbh.TabIndex = 11;
			this.txtthumbh.Text = "";
			this.txtthumbh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// txtthumbw
			// 
			this.txtthumbw.Location = new System.Drawing.Point(96, 72);
			this.txtthumbw.Name = "txtthumbw";
			this.txtthumbw.Size = new System.Drawing.Size(136, 20);
			this.txtthumbw.TabIndex = 10;
			this.txtthumbw.Text = "";
			this.txtthumbw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// txtitemh
			// 
			this.txtitemh.Location = new System.Drawing.Point(96, 48);
			this.txtitemh.Name = "txtitemh";
			this.txtitemh.Size = new System.Drawing.Size(136, 20);
			this.txtitemh.TabIndex = 9;
			this.txtitemh.Text = "";
			this.txtitemh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(8, 200);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(80, 23);
			this.label15.TabIndex = 8;
			this.label15.Text = "Texture Hieght";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(8, 176);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(88, 23);
			this.label16.TabIndex = 7;
			this.label16.Text = "Texture Width";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 152);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(80, 23);
			this.label14.TabIndex = 6;
			this.label14.Text = "Thumb YPos";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(8, 128);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(88, 23);
			this.label13.TabIndex = 5;
			this.label13.Text = "Thumb Xpos";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 104);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(88, 23);
			this.label12.TabIndex = 4;
			this.label12.Text = "Thumb Hieght";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 80);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(72, 23);
			this.label11.TabIndex = 3;
			this.label11.Text = "Thumb Width";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 56);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 23);
			this.label10.TabIndex = 2;
			this.label10.Text = "Item Hieght";
			// 
			// txtitemw
			// 
			this.txtitemw.Location = new System.Drawing.Point(96, 24);
			this.txtitemw.Name = "txtitemw";
			this.txtitemw.Size = new System.Drawing.Size(136, 20);
			this.txtitemw.TabIndex = 1;
			this.txtitemw.Text = "";
			this.txtitemw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 32);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 23);
			this.label9.TabIndex = 0;
			this.label9.Text = "Item Width";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.txtbigtextureh);
			this.groupBox5.Controls.Add(this.txtbigtexturew);
			this.groupBox5.Controls.Add(this.txtbigthumby);
			this.groupBox5.Controls.Add(this.txtbigthumbx);
			this.groupBox5.Controls.Add(this.txtbigthumbh);
			this.groupBox5.Controls.Add(this.txtbigthumbw);
			this.groupBox5.Controls.Add(this.txtbigitemh);
			this.groupBox5.Controls.Add(this.label17);
			this.groupBox5.Controls.Add(this.label18);
			this.groupBox5.Controls.Add(this.label19);
			this.groupBox5.Controls.Add(this.label20);
			this.groupBox5.Controls.Add(this.label21);
			this.groupBox5.Controls.Add(this.label22);
			this.groupBox5.Controls.Add(this.label23);
			this.groupBox5.Controls.Add(this.txtbigitemw);
			this.groupBox5.Controls.Add(this.label24);
			this.groupBox5.Location = new System.Drawing.Point(8, 240);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(240, 224);
			this.groupBox5.TabIndex = 1;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Large Items";
			// 
			// txtbigtextureh
			// 
			this.txtbigtextureh.Location = new System.Drawing.Point(96, 192);
			this.txtbigtextureh.Name = "txtbigtextureh";
			this.txtbigtextureh.Size = new System.Drawing.Size(136, 20);
			this.txtbigtextureh.TabIndex = 31;
			this.txtbigtextureh.Text = "";
			this.txtbigtextureh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// txtbigtexturew
			// 
			this.txtbigtexturew.Location = new System.Drawing.Point(96, 168);
			this.txtbigtexturew.Name = "txtbigtexturew";
			this.txtbigtexturew.Size = new System.Drawing.Size(136, 20);
			this.txtbigtexturew.TabIndex = 30;
			this.txtbigtexturew.Text = "";
			this.txtbigtexturew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// txtbigthumby
			// 
			this.txtbigthumby.Location = new System.Drawing.Point(96, 144);
			this.txtbigthumby.Name = "txtbigthumby";
			this.txtbigthumby.Size = new System.Drawing.Size(136, 20);
			this.txtbigthumby.TabIndex = 29;
			this.txtbigthumby.Text = "";
			this.txtbigthumby.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// txtbigthumbx
			// 
			this.txtbigthumbx.Location = new System.Drawing.Point(96, 120);
			this.txtbigthumbx.Name = "txtbigthumbx";
			this.txtbigthumbx.Size = new System.Drawing.Size(136, 20);
			this.txtbigthumbx.TabIndex = 28;
			this.txtbigthumbx.Text = "";
			this.txtbigthumbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// txtbigthumbh
			// 
			this.txtbigthumbh.Location = new System.Drawing.Point(96, 96);
			this.txtbigthumbh.Name = "txtbigthumbh";
			this.txtbigthumbh.Size = new System.Drawing.Size(136, 20);
			this.txtbigthumbh.TabIndex = 27;
			this.txtbigthumbh.Text = "";
			this.txtbigthumbh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// txtbigthumbw
			// 
			this.txtbigthumbw.Location = new System.Drawing.Point(96, 72);
			this.txtbigthumbw.Name = "txtbigthumbw";
			this.txtbigthumbw.Size = new System.Drawing.Size(136, 20);
			this.txtbigthumbw.TabIndex = 26;
			this.txtbigthumbw.Text = "";
			this.txtbigthumbw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// txtbigitemh
			// 
			this.txtbigitemh.Location = new System.Drawing.Point(96, 48);
			this.txtbigitemh.Name = "txtbigitemh";
			this.txtbigitemh.Size = new System.Drawing.Size(136, 20);
			this.txtbigitemh.TabIndex = 25;
			this.txtbigitemh.Text = "";
			this.txtbigitemh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(8, 200);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(80, 23);
			this.label17.TabIndex = 24;
			this.label17.Text = "Texture Hieght";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(8, 176);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(88, 23);
			this.label18.TabIndex = 23;
			this.label18.Text = "Texture Width";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(8, 152);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(80, 23);
			this.label19.TabIndex = 22;
			this.label19.Text = "Thumb YPos";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(8, 128);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(88, 23);
			this.label20.TabIndex = 21;
			this.label20.Text = "Thumb Xpos";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(8, 104);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(88, 23);
			this.label21.TabIndex = 20;
			this.label21.Text = "Thumb Hieght";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(8, 80);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(72, 23);
			this.label22.TabIndex = 19;
			this.label22.Text = "Thumb Width";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(8, 56);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(72, 23);
			this.label23.TabIndex = 18;
			this.label23.Text = "Item Hieght";
			// 
			// txtbigitemw
			// 
			this.txtbigitemw.Location = new System.Drawing.Point(96, 24);
			this.txtbigitemw.Name = "txtbigitemw";
			this.txtbigitemw.Size = new System.Drawing.Size(136, 20);
			this.txtbigitemw.TabIndex = 17;
			this.txtbigitemw.Text = "";
			this.txtbigitemw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(8, 32);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(72, 23);
			this.label24.TabIndex = 16;
			this.label24.Text = "Item Width";
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
			// FrmXThumbnail
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(264, 614);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(800, 50);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmXThumbnail";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Load += new System.EventHandler(this.FrmXThumbnail_Load);
			this.gBoxProperties.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private void btnImageBrowse_Click(object sender, System.EventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				String path = Path.GetFullPath(openFileDialog1.FileName);
				this.txtImage.Text = Path.GetFullPath(openFileDialog1.FileName);
				this.txttexturew.Text = (Image.FromFile(path).Width).ToString();
				this.txttextureh.Text = (Image.FromFile(path).Height).ToString();

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

			xb.ItemHeightBig = txtbigitemh.Text;
			xb.ItemWidthBig = txtbigitemw.Text;
			xb.TextureHeightBig = txtbigtextureh.Text;
			xb.TextureWidthBig = txtbigtexturew.Text;
			xb.ThumbHeight = txtbigthumbh.Text;
			xb.ThumbWidthBig = txtbigthumbw.Text;
			xb.ThumbPosXBig = txtbigthumbx.Text;
			xb.ThumbPosYBig = txtbigthumby.Text;
			xb.ItemHeight = txtitemh.Text;
			xb.ItemWidth = txtitemw.Text;
			xb.TextureHeight = txttextureh.Text;
			xb.TextureWidth = txttexturew.Text;
			xb.ThumbHeight = txtthumbh.Text;
			xb.ThumbWidth = txtthumbw.Text;
			xb.ThumbPosX = txtthumbx.Text;
			xb.ThumbPosY = txtthumby.Text;

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

			if (txtspincolor.Text.Length <= 7)
			{
				txtspincolor.Text = "ff000000";
			}

			ColorBreak cb = new ColorBreak();
			XColor xc1 = new XColor();

			xb.XColor.Add("textcolor", cb.BreakColor(xc1, txtColorkey.Text));

			XColor xc2 = new XColor();
			xb.XColor.Add("selectedColor", cb.BreakColor(xc2, txtdisabledcolor.Text));

			XColor xc3 = new XColor();
			xb.XColor.Add("colordiffuse", cb.BreakColor(xc3, txtdiffusecolor.Text));

			XColor xc4 = new XColor();
			xb.XColor.Add("spinColor", cb.BreakColor(xc4, txtspincolor.Text));


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
				xb.Picture.Add("imageFolder",pica);
			}
			else
			{
				Picture pica = new Picture();
				pica.Path = "-";
				xb.Picture.Add("imageFolder",pica);
			}

			if (this.txtImage2.Text != "-")
			{
				Picture picb = new Picture();
				picb.Path = this.txtImage2.Text;
				picb.Picwidth = (Image.FromFile(picb.Path.ToString()).Width).ToString();
				picb.Pichieght = (Image.FromFile(picb.Path.ToString()).Height).ToString();
				xb.Picture.Add("imageFolderFocus",picb);
			}
			else
			{
				Picture pica = new Picture();
				pica.Path = "-";
				xb.Picture.Add("imageFolderFocus",pica);
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

			this.Render();
		}

		private void Render()
		{
			if (this.edit == false)
			{

				if (FirstTime)
				{
					F.AddXthumbnail(xb, this);
					FirstTime = false;
				}
				else
				{
					cc_xThumbnail.XB = this.xb;
				}
			}
			else
			{
				cc_xThumbnail.XB = this.xb;
			}
		}

		private void gBoxProperties_Enter(object sender, System.EventArgs e)
		{
			
		}

		private void FrmXThumbnail_Load(object sender, System.EventArgs e)
		{
			GetFontList getFontList = new GetFontList();
			String [] Fonts = getFontList.getFontList(); //Application.StartupPath);

			for (Int32 i = 0; i < Fonts.Length - 1; i++)
			{
				this.CboxFonts.Items.Add(Fonts[i]);
			}

			if (xb == null)
			{
				xb = new Xthumbnail();
			}
			else
			{
				if (backupxb == null)
				{
					backupxb = new Xthumbnail();
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

				this.txtbigitemh.Text = xb.ItemHeightBig;
				this.txtbigitemw.Text = xb.ItemWidthBig;
				this.txtbigtextureh.Text = xb.TextureHeightBig;
				this.txtbigtexturew.Text = xb.TextureWidthBig;
				this.txtbigthumbh.Text = xb.ThumbHeight; 
				this.txtbigthumbw.Text = xb.ThumbWidthBig;
				this.txtbigthumbx.Text = xb.ThumbPosXBig; 
				this.txtbigthumby.Text = xb.ThumbPosYBig; 
				this.txtitemh.Text = xb.ItemHeight;
				this.txtitemw.Text = xb.ItemWidth; 
				this.txttextureh.Text = xb.TextureHeight; 
				this.txttexturew.Text = xb.TextureWidth; 
				this.txtthumbh.Text = xb.ThumbHeight; 
				this.txtthumbw.Text = xb.ThumbWidth; 
				this.txtthumbx.Text = xb.ThumbPosX; 
				this.txtthumby.Text = xb.ThumbPosY; 

				this.txtspinh.Text = xb.Picture["textureUp"].Pichieght;
				this.txtspinw.Text = xb.Picture["textureUp"].Picwidth;
				this.txtspinx.Text = xb.Picture["textureUp"].Picxpos;
				this.txtspiny.Text = xb.Picture["textureUp"].Picypos;

				this.CboxFonts.Text = xb.Font;
				this.txtDescription.Text = xb.Description ;	
				this.txtColorkey.Text = xb.XColor["textcolor"].Color.ToString();
				this.txtdisabledcolor.Text = xb.XColor["selectedColor"].Color.ToString();
				this.txtdiffusecolor.Text = xb.XColor["colordiffuse"].Color.ToString();
				this.txtspincolor.Text = xb.XColor["spinColor"].Color.ToString();

				this.btnColorkey.BackColor = Color.FromArgb(xb.XColor["textcolor"].R,xb.XColor["textcolor"].G,xb.XColor["textcolor"].B);
				this.btndisabledcolor.BackColor = Color.FromArgb(xb.XColor["selectedColor"].R,xb.XColor["selectedColor"].G,xb.XColor["selectedColor"].B);
				this.btnColorDefuse.BackColor = Color.FromArgb(xb.XColor["colordiffuse"].R,xb.XColor["colordiffuse"].G,xb.XColor["colordiffuse"].B);
				this.btnspincolor.BackColor = Color.FromArgb(xb.XColor["spinColor"].R,xb.XColor["spinColor"].G,xb.XColor["spinColor"].B);

				this.txtImage.Text = xb.Picture["imageFolder"].Path;
				this.txtImage2.Text = xb.Picture["imageFolderFocus"].Path;
				this.txtleftfocus.Text = xb.Picture["textureUp"].Path;
				this.txtleftnofocus.Text = xb.Picture["textureUpFocus"].Path;
				this.txtrightfocus.Text = xb.Picture["textureDown"].Path;
				this.txtrightnofocus.Text = xb.Picture["textureDownFocus"].Path;

				if (this.txtImage.Text != "-")
				{
					this.tickfocus.Visible = true;
				}

				if (this.txtImage2.Text != "-")
				{
					this.ticknofocus.Visible = true;
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

				this.toolTips.SetToolTip(this.btnleftfocus, Path.GetFileName(this.txtleftfocus.Text));
				this.toolTips.SetToolTip(this.btnleftnofocus, Path.GetFileName(this.txtleftnofocus.Text));
				this.toolTips.SetToolTip(this.btnrightfocus, Path.GetFileName(this.txtrightfocus.Text));
				this.toolTips.SetToolTip(this.btnrightnofocus, Path.GetFileName(this.txtrightnofocus.Text));
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
				F.SaveXthumbnail(xb);
				this.Close();
			}
		}

		private void btnIgnore_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you wish to Delete this Control? It cannot beundone","Warning",MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				xb.Save = false;
				cc_xThumbnail.Visible = false;

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

		private void btnspincolor_Click(object sender, System.EventArgs e)
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

		private void tickdownnofocus_Click(object sender, System.EventArgs e)
		{
			this.txtrightnofocus.Text = "-";
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
