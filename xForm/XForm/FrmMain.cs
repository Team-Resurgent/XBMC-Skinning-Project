using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

using XForm.Data;

namespace XForm
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FrmMain : System.Windows.Forms.Form
	{
		private Skin skin;

		private SkinDetails skinDetails;
		private FrmNew frmnew;
		private FrmLoad frmload;
		private FrmXButton frmxbutton;
		private FrmXMark   frmxmark;
		private FrmXImage  frmximage;
		private FrmXLabel  frmxlabel;
		private FrmDesign  frmdesign;
		private FrmXFadeLabel frmxfadelabel;
		private FrmXRss frmxrss;
		private FrmXSelectButton frmxselectbutton;
		private FrmXButtonT frmxbuttont;
		private FrmXSpinControl frmxspincontrol;
		private FrmXSpinButton frmxspinbutton;
		private FrmXListControl frmxlistcontrol;
		private FrmXThumbnail frmxthumbnail;
		private FrmxRadio frmxradio;
		private String projectPath; 

		private Boolean Res;
		private Boolean Ratio;
		private Boolean toggle;

		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.Button btnList;
		private System.Windows.Forms.Button btnSpin;
		private System.Windows.Forms.Button btnRadio;
		private System.Windows.Forms.Button btnMark;
		private System.Windows.Forms.Button btnThumb;
		private System.Windows.Forms.Button btnMutli;
		private System.Windows.Forms.Button btnToggle;
		private System.Windows.Forms.Button btnButton;
		private System.Windows.Forms.Button btnLabel;
		private System.Windows.Forms.Button btnImage;
		private System.Windows.Forms.PictureBox BtnNew;
		private System.Windows.Forms.PictureBox BtnLoad;
		private System.Windows.Forms.PictureBox BtnSave;
		private System.Windows.Forms.PictureBox BackgroundPicture;
		private System.Windows.Forms.PictureBox BtnSystem1;
		private System.Windows.Forms.PictureBox BtnSystem2;
		private System.Windows.Forms.PictureBox BtnSystem3;
		private System.Windows.Forms.PictureBox BtnSystem4;
		private System.Windows.Forms.ToolTip toolTips;
		private System.Windows.Forms.ImageList ImgBtnLst;
		private System.Windows.Forms.Button btnTextArea;
		private System.Windows.Forms.Button BtnSlider;
		private System.Windows.Forms.Button BtnSpinButton;
		private System.Windows.Forms.Button btnBlsnk;
		private System.Windows.Forms.Button BtnSelectButton;
		private System.Windows.Forms.Button btnFadeLabel;
		private System.Windows.Forms.Button BtnBlank;
		private System.Windows.Forms.Button btnRss;
		private System.Windows.Forms.OpenFileDialog OpnFile;
		private System.ComponentModel.IContainer components;

		public Boolean RES
		{
			get {return(this.Res);}
			set	{this.Res = value;}
		}

		public Boolean RATIO
		{
			get {return(this.Ratio);}
			set	{this.Ratio = value;}
		}

		public Boolean Toggle
		{
			get {return(this.toggle);}
			set	{this.toggle = value;}
		}

		public Skin SKIN
		{
			get {return(this.skin);}
			set	
			{
				this.skin = value;
				this.ChangeStatus();
			}
		}

		public FrmMain()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmMain));
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.BtnNew = new System.Windows.Forms.PictureBox();
			this.btnTextArea = new System.Windows.Forms.Button();
			this.ImgBtnLst = new System.Windows.Forms.ImageList(this.components);
			this.BtnSlider = new System.Windows.Forms.Button();
			this.BtnSpinButton = new System.Windows.Forms.Button();
			this.btnBlsnk = new System.Windows.Forms.Button();
			this.BtnSelectButton = new System.Windows.Forms.Button();
			this.btnFadeLabel = new System.Windows.Forms.Button();
			this.BtnBlank = new System.Windows.Forms.Button();
			this.btnList = new System.Windows.Forms.Button();
			this.btnSpin = new System.Windows.Forms.Button();
			this.btnRadio = new System.Windows.Forms.Button();
			this.btnMark = new System.Windows.Forms.Button();
			this.btnThumb = new System.Windows.Forms.Button();
			this.btnMutli = new System.Windows.Forms.Button();
			this.btnToggle = new System.Windows.Forms.Button();
			this.btnButton = new System.Windows.Forms.Button();
			this.btnLabel = new System.Windows.Forms.Button();
			this.btnImage = new System.Windows.Forms.Button();
			this.btnRss = new System.Windows.Forms.Button();
			this.BtnLoad = new System.Windows.Forms.PictureBox();
			this.BtnSave = new System.Windows.Forms.PictureBox();
			this.BackgroundPicture = new System.Windows.Forms.PictureBox();
			this.BtnSystem1 = new System.Windows.Forms.PictureBox();
			this.BtnSystem2 = new System.Windows.Forms.PictureBox();
			this.BtnSystem3 = new System.Windows.Forms.PictureBox();
			this.BtnSystem4 = new System.Windows.Forms.PictureBox();
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			this.OpnFile = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			// 
			// BtnNew
			// 
			this.BtnNew.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnNew.Image = ((System.Drawing.Image)(resources.GetObject("BtnNew.Image")));
			this.BtnNew.Location = new System.Drawing.Point(25, 20);
			this.BtnNew.Name = "BtnNew";
			this.BtnNew.Size = new System.Drawing.Size(81, 21);
			this.BtnNew.TabIndex = 20;
			this.BtnNew.TabStop = false;
			this.BtnNew.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// btnTextArea
			// 
			this.btnTextArea.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnTextArea.Enabled = false;
			this.btnTextArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTextArea.ImageIndex = 14;
			this.btnTextArea.ImageList = this.ImgBtnLst;
			this.btnTextArea.Location = new System.Drawing.Point(710, 102);
			this.btnTextArea.Name = "btnTextArea";
			this.btnTextArea.Size = new System.Drawing.Size(44, 44);
			this.btnTextArea.TabIndex = 19;
			this.toolTips.SetToolTip(this.btnTextArea, "This Button is not active in this beta version");
			this.btnTextArea.Click += new System.EventHandler(this.btnTextArea_Click);
			// 
			// ImgBtnLst
			// 
			this.ImgBtnLst.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
			this.ImgBtnLst.ImageSize = new System.Drawing.Size(44, 44);
			this.ImgBtnLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgBtnLst.ImageStream")));
			this.ImgBtnLst.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// BtnSlider
			// 
			this.BtnSlider.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnSlider.Enabled = false;
			this.BtnSlider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnSlider.ImageIndex = 0;
			this.BtnSlider.ImageList = this.ImgBtnLst;
			this.BtnSlider.Location = new System.Drawing.Point(654, 102);
			this.BtnSlider.Name = "BtnSlider";
			this.BtnSlider.Size = new System.Drawing.Size(44, 44);
			this.BtnSlider.TabIndex = 18;
			this.toolTips.SetToolTip(this.BtnSlider, "This Button is not active in this beta version");
			this.BtnSlider.Click += new System.EventHandler(this.BtnSlider_Click);
			// 
			// BtnSpinButton
			// 
			this.BtnSpinButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnSpinButton.Enabled = false;
			this.BtnSpinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnSpinButton.ImageIndex = 13;
			this.BtnSpinButton.ImageList = this.ImgBtnLst;
			this.BtnSpinButton.Location = new System.Drawing.Point(542, 102);
			this.BtnSpinButton.Name = "BtnSpinButton";
			this.BtnSpinButton.Size = new System.Drawing.Size(44, 44);
			this.BtnSpinButton.TabIndex = 15;
			this.toolTips.SetToolTip(this.BtnSpinButton, "This Button is not active in this beta version");
			this.BtnSpinButton.Click += new System.EventHandler(this.button5_Click);
			// 
			// btnBlsnk
			// 
			this.btnBlsnk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBlsnk.Enabled = false;
			this.btnBlsnk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBlsnk.ImageIndex = 0;
			this.btnBlsnk.ImageList = this.ImgBtnLst;
			this.btnBlsnk.Location = new System.Drawing.Point(430, 102);
			this.btnBlsnk.Name = "btnBlsnk";
			this.btnBlsnk.Size = new System.Drawing.Size(44, 44);
			this.btnBlsnk.TabIndex = 14;
			this.toolTips.SetToolTip(this.btnBlsnk, "This Button is not active in this beta version");
			// 
			// BtnSelectButton
			// 
			this.BtnSelectButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnSelectButton.Enabled = false;
			this.BtnSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnSelectButton.ImageIndex = 12;
			this.BtnSelectButton.ImageList = this.ImgBtnLst;
			this.BtnSelectButton.Location = new System.Drawing.Point(374, 102);
			this.BtnSelectButton.Name = "BtnSelectButton";
			this.BtnSelectButton.Size = new System.Drawing.Size(44, 44);
			this.BtnSelectButton.TabIndex = 13;
			this.toolTips.SetToolTip(this.BtnSelectButton, "Add a Select Button to the skin");
			this.BtnSelectButton.Click += new System.EventHandler(this.button7_Click);
			// 
			// btnFadeLabel
			// 
			this.btnFadeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnFadeLabel.Enabled = false;
			this.btnFadeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFadeLabel.ImageIndex = 3;
			this.btnFadeLabel.ImageList = this.ImgBtnLst;
			this.btnFadeLabel.Location = new System.Drawing.Point(318, 102);
			this.btnFadeLabel.Name = "btnFadeLabel";
			this.btnFadeLabel.Size = new System.Drawing.Size(44, 44);
			this.btnFadeLabel.TabIndex = 11;
			this.toolTips.SetToolTip(this.btnFadeLabel, "Add a Fade Label to your Skin");
			this.btnFadeLabel.Click += new System.EventHandler(this.button9_Click);
			// 
			// BtnBlank
			// 
			this.BtnBlank.BackColor = System.Drawing.Color.Transparent;
			this.BtnBlank.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnBlank.Enabled = false;
			this.BtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnBlank.ImageIndex = 0;
			this.BtnBlank.ImageList = this.ImgBtnLst;
			this.BtnBlank.Location = new System.Drawing.Point(262, 102);
			this.BtnBlank.Name = "BtnBlank";
			this.BtnBlank.Size = new System.Drawing.Size(44, 44);
			this.BtnBlank.TabIndex = 10;
			this.BtnBlank.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTips.SetToolTip(this.BtnBlank, "This Button is not active in this beta version");
			this.BtnBlank.Click += new System.EventHandler(this.BtnBlank_Click);
			// 
			// btnList
			// 
			this.btnList.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnList.Enabled = false;
			this.btnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnList.ImageIndex = 6;
			this.btnList.ImageList = this.ImgBtnLst;
			this.btnList.Location = new System.Drawing.Point(710, 3);
			this.btnList.Name = "btnList";
			this.btnList.Size = new System.Drawing.Size(44, 44);
			this.btnList.TabIndex = 9;
			this.toolTips.SetToolTip(this.btnList, "Add a Listview to your Skin");
			this.btnList.Click += new System.EventHandler(this.btnList_Click);
			// 
			// btnSpin
			// 
			this.btnSpin.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSpin.Enabled = false;
			this.btnSpin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSpin.ImageIndex = 11;
			this.btnSpin.ImageList = this.ImgBtnLst;
			this.btnSpin.Location = new System.Drawing.Point(654, 3);
			this.btnSpin.Name = "btnSpin";
			this.btnSpin.Size = new System.Drawing.Size(44, 44);
			this.btnSpin.TabIndex = 8;
			this.toolTips.SetToolTip(this.btnSpin, "Add a SpinControl to your Skin");
			this.btnSpin.Click += new System.EventHandler(this.btnSpin_Click);
			// 
			// btnRadio
			// 
			this.btnRadio.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRadio.Enabled = false;
			this.btnRadio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRadio.ImageIndex = 9;
			this.btnRadio.ImageList = this.ImgBtnLst;
			this.btnRadio.Location = new System.Drawing.Point(598, 102);
			this.btnRadio.Name = "btnRadio";
			this.btnRadio.Size = new System.Drawing.Size(44, 44);
			this.btnRadio.TabIndex = 7;
			this.toolTips.SetToolTip(this.btnRadio, "Add a Radio Button  to your Skin");
			this.btnRadio.Click += new System.EventHandler(this.btnRadio_Click);
			// 
			// btnMark
			// 
			this.btnMark.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMark.Enabled = false;
			this.btnMark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMark.ImageIndex = 2;
			this.btnMark.ImageList = this.ImgBtnLst;
			this.btnMark.Location = new System.Drawing.Point(598, 3);
			this.btnMark.Name = "btnMark";
			this.btnMark.Size = new System.Drawing.Size(44, 44);
			this.btnMark.TabIndex = 6;
			this.toolTips.SetToolTip(this.btnMark, "Add a Mark Field to your Skin");
			this.btnMark.Click += new System.EventHandler(this.btnMark_Click);
			// 
			// btnThumb
			// 
			this.btnThumb.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnThumb.Enabled = false;
			this.btnThumb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnThumb.ImageIndex = 15;
			this.btnThumb.ImageList = this.ImgBtnLst;
			this.btnThumb.Location = new System.Drawing.Point(542, 3);
			this.btnThumb.Name = "btnThumb";
			this.btnThumb.Size = new System.Drawing.Size(44, 44);
			this.btnThumb.TabIndex = 5;
			this.toolTips.SetToolTip(this.btnThumb, "Add a ThumbPanel to your Skin");
			this.btnThumb.Click += new System.EventHandler(this.btnThumb_Click);
			// 
			// btnMutli
			// 
			this.btnMutli.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMutli.Enabled = false;
			this.btnMutli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMutli.ImageIndex = 7;
			this.btnMutli.ImageList = this.ImgBtnLst;
			this.btnMutli.Location = new System.Drawing.Point(486, 3);
			this.btnMutli.Name = "btnMutli";
			this.btnMutli.Size = new System.Drawing.Size(44, 44);
			this.btnMutli.TabIndex = 4;
			this.toolTips.SetToolTip(this.btnMutli, "This Button is not active in this beta version");
			this.btnMutli.Click += new System.EventHandler(this.btnMutli_Click);
			// 
			// btnToggle
			// 
			this.btnToggle.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnToggle.Enabled = false;
			this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnToggle.ImageIndex = 16;
			this.btnToggle.ImageList = this.ImgBtnLst;
			this.btnToggle.Location = new System.Drawing.Point(430, 3);
			this.btnToggle.Name = "btnToggle";
			this.btnToggle.Size = new System.Drawing.Size(44, 44);
			this.btnToggle.TabIndex = 3;
			this.toolTips.SetToolTip(this.btnToggle, "This Button is not active in this beta version");
			this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
			// 
			// btnButton
			// 
			this.btnButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnButton.Enabled = false;
			this.btnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnButton.ImageIndex = 1;
			this.btnButton.ImageList = this.ImgBtnLst;
			this.btnButton.Location = new System.Drawing.Point(374, 3);
			this.btnButton.Name = "btnButton";
			this.btnButton.Size = new System.Drawing.Size(44, 44);
			this.btnButton.TabIndex = 2;
			this.toolTips.SetToolTip(this.btnButton, "Add a Button to your Skin");
			this.btnButton.Click += new System.EventHandler(this.btnButton_Click);
			// 
			// btnLabel
			// 
			this.btnLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnLabel.Enabled = false;
			this.btnLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLabel.ImageIndex = 5;
			this.btnLabel.ImageList = this.ImgBtnLst;
			this.btnLabel.Location = new System.Drawing.Point(318, 3);
			this.btnLabel.Name = "btnLabel";
			this.btnLabel.Size = new System.Drawing.Size(44, 44);
			this.btnLabel.TabIndex = 1;
			this.toolTips.SetToolTip(this.btnLabel, "Add a Label to your Skin");
			this.btnLabel.Click += new System.EventHandler(this.btnLabel_Click);
			// 
			// btnImage
			// 
			this.btnImage.BackColor = System.Drawing.Color.Transparent;
			this.btnImage.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnImage.Enabled = false;
			this.btnImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnImage.ImageIndex = 4;
			this.btnImage.ImageList = this.ImgBtnLst;
			this.btnImage.Location = new System.Drawing.Point(262, 3);
			this.btnImage.Name = "btnImage";
			this.btnImage.Size = new System.Drawing.Size(44, 44);
			this.btnImage.TabIndex = 0;
			this.toolTips.SetToolTip(this.btnImage, "Add an Image to your Skin");
			this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
			// 
			// btnRss
			// 
			this.btnRss.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRss.Enabled = false;
			this.btnRss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRss.ImageIndex = 10;
			this.btnRss.ImageList = this.ImgBtnLst;
			this.btnRss.Location = new System.Drawing.Point(486, 102);
			this.btnRss.Name = "btnRss";
			this.btnRss.Size = new System.Drawing.Size(44, 44);
			this.btnRss.TabIndex = 12;
			this.toolTips.SetToolTip(this.btnRss, "Add a RSS to your Skin");
			this.btnRss.Click += new System.EventHandler(this.button8_Click);
			// 
			// BtnLoad
			// 
			this.BtnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnLoad.Image = ((System.Drawing.Image)(resources.GetObject("BtnLoad.Image")));
			this.BtnLoad.Location = new System.Drawing.Point(25, 44);
			this.BtnLoad.Name = "BtnLoad";
			this.BtnLoad.Size = new System.Drawing.Size(81, 21);
			this.BtnLoad.TabIndex = 22;
			this.BtnLoad.TabStop = false;
			this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
			// 
			// BtnSave
			// 
			this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnSave.Enabled = false;
			this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
			this.BtnSave.Location = new System.Drawing.Point(25, 68);
			this.BtnSave.Name = "BtnSave";
			this.BtnSave.Size = new System.Drawing.Size(81, 21);
			this.BtnSave.TabIndex = 23;
			this.BtnSave.TabStop = false;
			this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// BackgroundPicture
			// 
			this.BackgroundPicture.Image = ((System.Drawing.Image)(resources.GetObject("BackgroundPicture.Image")));
			this.BackgroundPicture.Location = new System.Drawing.Point(0, 0);
			this.BackgroundPicture.Name = "BackgroundPicture";
			this.BackgroundPicture.Size = new System.Drawing.Size(775, 150);
			this.BackgroundPicture.TabIndex = 5;
			this.BackgroundPicture.TabStop = false;
			this.BackgroundPicture.Click += new System.EventHandler(this.BackgroundPicture_Click);
			// 
			// BtnSystem1
			// 
			this.BtnSystem1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnSystem1.Enabled = false;
			this.BtnSystem1.Image = ((System.Drawing.Image)(resources.GetObject("BtnSystem1.Image")));
			this.BtnSystem1.Location = new System.Drawing.Point(1, 117);
			this.BtnSystem1.Name = "BtnSystem1";
			this.BtnSystem1.Size = new System.Drawing.Size(33, 29);
			this.BtnSystem1.TabIndex = 24;
			this.BtnSystem1.TabStop = false;
			this.toolTips.SetToolTip(this.BtnSystem1, "Skin Properties");
			this.BtnSystem1.Click += new System.EventHandler(this.BtnSystem1_Click);
			// 
			// BtnSystem2
			// 
			this.BtnSystem2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnSystem2.Image = ((System.Drawing.Image)(resources.GetObject("BtnSystem2.Image")));
			this.BtnSystem2.Location = new System.Drawing.Point(33, 116);
			this.BtnSystem2.Name = "BtnSystem2";
			this.BtnSystem2.Size = new System.Drawing.Size(30, 29);
			this.BtnSystem2.TabIndex = 25;
			this.BtnSystem2.TabStop = false;
			this.toolTips.SetToolTip(this.BtnSystem2, "Skin Explorer");
			this.BtnSystem2.Click += new System.EventHandler(this.BtnSystem2_Click);
			// 
			// BtnSystem3
			// 
			this.BtnSystem3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnSystem3.Image = ((System.Drawing.Image)(resources.GetObject("BtnSystem3.Image")));
			this.BtnSystem3.Location = new System.Drawing.Point(64, 117);
			this.BtnSystem3.Name = "BtnSystem3";
			this.BtnSystem3.Size = new System.Drawing.Size(30, 29);
			this.BtnSystem3.TabIndex = 26;
			this.BtnSystem3.TabStop = false;
			this.toolTips.SetToolTip(this.BtnSystem3, "About X-Form");
			this.BtnSystem3.Click += new System.EventHandler(this.BtnSystem3_Click);
			// 
			// BtnSystem4
			// 
			this.BtnSystem4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnSystem4.Image = ((System.Drawing.Image)(resources.GetObject("BtnSystem4.Image")));
			this.BtnSystem4.Location = new System.Drawing.Point(94, 116);
			this.BtnSystem4.Name = "BtnSystem4";
			this.BtnSystem4.Size = new System.Drawing.Size(33, 29);
			this.BtnSystem4.TabIndex = 27;
			this.BtnSystem4.TabStop = false;
			this.toolTips.SetToolTip(this.BtnSystem4, "System Button Four");
			// 
			// toolTips
			// 
			this.toolTips.AutomaticDelay = 50;
			this.toolTips.AutoPopDelay = 10000;
			this.toolTips.InitialDelay = 50;
			this.toolTips.ReshowDelay = 10;
			this.toolTips.ShowAlways = true;
			// 
			// FrmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(772, 149);
			this.Controls.Add(this.BtnSystem4);
			this.Controls.Add(this.BtnSystem3);
			this.Controls.Add(this.BtnSystem2);
			this.Controls.Add(this.BtnSystem1);
			this.Controls.Add(this.btnButton);
			this.Controls.Add(this.btnLabel);
			this.Controls.Add(this.btnImage);
			this.Controls.Add(this.btnRss);
			this.Controls.Add(this.BtnNew);
			this.Controls.Add(this.BtnSave);
			this.Controls.Add(this.btnTextArea);
			this.Controls.Add(this.BtnLoad);
			this.Controls.Add(this.BtnSlider);
			this.Controls.Add(this.BtnSpinButton);
			this.Controls.Add(this.btnBlsnk);
			this.Controls.Add(this.BtnSelectButton);
			this.Controls.Add(this.btnFadeLabel);
			this.Controls.Add(this.BtnBlank);
			this.Controls.Add(this.btnList);
			this.Controls.Add(this.btnSpin);
			this.Controls.Add(this.btnRadio);
			this.Controls.Add(this.btnMark);
			this.Controls.Add(this.btnThumb);
			this.Controls.Add(this.btnMutli);
			this.Controls.Add(this.btnToggle);
			this.Controls.Add(this.BackgroundPicture);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(50, 600);
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "X Form";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.Run(new FrmMain());
			Application.DoEvents();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.projectPath = String.Empty;
		}

		public String ProjectPath
		{
			get {return this.projectPath;}
			set {this.projectPath = value;}
		}

		public void UpdateButton(XButton xb, Boolean FirstTime)
		{
			return;
		}

		public void AddXButton(XButton xb )
		{
		}

		public void AddXButtonT(XButtonT xb )
		{
		}

		public void AddXButtonM(XButtonM xb )
		{
		}

		public void AddXFadeLabel(XFadeLabel xb )
		{
		}

		public void AddXImage(XImage xb )
		{
		}

		public void AddXLabel(XLabel xb )
		{
		}

		public void AddXListControl(XListControl xb )
		{
		}

		public void AddXMark(Xmark xb )
		{
		}

		public void AddXProgress(XProgress xb )
		{
		}

		public void AddXRadio(XRadio xb )
		{
		}

		public void AddXRam(XRam xb )
		{
		}

		public void AddXRss(XRss xb )
		{
		}

		public void AddXSelectButton(XSelectButton xb)
		{
		}

		public void AddXSlider(XSlider xb )
		{
		}

		public void AddXSpinButton(XSpinButton xb )
		{
		}

		public void AddXSpinControl(XSpinControl xb )
		{
		}

		public void AddXTextArea(XtextArea xb )
		{
		}

		public void AddXThumbnail(Xthumbnail xb )
		{
		}

		private void mitemLoad_Click(object sender, System.EventArgs e)
		{
			Skin skin = new Skin();
			skin = skin.Load();

			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				AddXButton(skin.XButtons[i]);
			}

			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				 AddXButtonT(skin.XButtonT[i]);
			}
			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				AddXButtonM(skin.XButtonM[i]);
			}
			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				AddXFadeLabel(skin.XFadeLabel[i]);
			}
			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				AddXImage(skin.XImage[i]);
			}
			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				AddXLabel(skin.XLabel[i]);
			}
			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				AddXListControl(skin.XListControl[i]);;
			}
			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				AddXMark(skin.Xmark[i]);;
			}
			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				AddXProgress(skin.XProgress[i]);
			}
			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				AddXRadio(skin.XRadio[i]);
			}
			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				AddXRam(skin.XRam[i]);
			}
			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				AddXRss(skin.XRss[i]);
			}
			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				AddXSelectButton(skin.XSelectButton[i]);
			}
			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				AddXSlider(skin.XSlider[i]);
			}
			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				AddXSpinButton(skin.XSpinButton[i]);
			}
			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				AddXSpinControl(skin.XSpinControl[i]);
			}
			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				AddXTextArea(skin.XtextArea[i]);
			}
			for (int i = 0; i <	skin.XButtons.Count; i++)
			{
				AddXThumbnail(skin.XThumbnail[i]);
			}
		}

		private void mitemSkinEcplorer_Click(object sender, System.EventArgs e)
		{
			SkinExplorer s = new SkinExplorer();
			s.Show();
		}

		private void btnButton_Click(object sender, System.EventArgs e)
		{
			frmxbutton = new FrmXButton();
			frmxbutton.F = frmdesign;
			frmxbutton.Show();
		}

		private void btnImage_Click(object sender, System.EventArgs e)
		{
			frmximage = new FrmXImage();
			frmximage.F = frmdesign;
			frmximage.Show();
		}

		private void btnLabel_Click(object sender, System.EventArgs e)
		{
			frmxlabel = new FrmXLabel();
			frmxlabel.F = frmdesign;
			frmxlabel.Show();
		}

		private void btnMark_Click(object sender, System.EventArgs e)
		{
			frmxmark = new FrmXMark();
			frmxmark.F = frmdesign;
			frmxmark.Show();
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			frmxfadelabel = new FrmXFadeLabel();
			frmxfadelabel.F = frmdesign;
			frmxfadelabel.Show();
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			frmxrss = new FrmXRss();
			frmxrss.F = frmdesign;
			frmxrss.Show();
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			frmxselectbutton = new FrmXSelectButton();
			frmxselectbutton.F = frmdesign;
			frmxselectbutton.Show();
		}

		private void btnToggle_Click(object sender, System.EventArgs e)
		{

		}

		private void btnSpin_Click(object sender, System.EventArgs e)
		{
			frmxspincontrol = new FrmXSpinControl();
			frmxspincontrol.F = frmdesign;
			frmxspincontrol.Show();
		}

		private void button5_Click(object sender, System.EventArgs e)
		{

		}

		private void btnList_Click(object sender, System.EventArgs e)
		{
			frmxlistcontrol = new FrmXListControl();
			frmxlistcontrol.F = frmdesign;
			frmxlistcontrol.Show();
		}

		private void btnThumb_Click(object sender, System.EventArgs e)
		{
			frmxthumbnail = new FrmXThumbnail();
			frmxthumbnail.F = frmdesign;
			frmxthumbnail.Show();
		}

		private void btnMutli_Click(object sender, System.EventArgs e)
		{
		
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
			frmnew = new FrmNew();
			frmnew.F = frmdesign;
			frmnew.M = this;
			frmnew.Show();
		}

		private void gBoxToolbox_Enter(object sender, System.EventArgs e)
		{
		
		}

		public FrmDesign CreateNewSKinFile()
		{
			frmdesign = new FrmDesign();
			frmdesign.F = frmdesign;
			frmdesign.M = this;

			if (this.Res) //Ntsc
			{
				if (this.Ratio) //widescreen
				{
					frmdesign.Size = new Size(720,480);
				}
				else
				{
					frmdesign.Size = new Size(640, 480);
				}
			}

			else
			{
				if (this.Ratio) //widescreen
				{
					frmdesign.Size = new Size(768, 576);
				}
				else
				{	
					frmdesign.Size = new Size(720, 576);
				}
			}
	
			frmdesign.Show();

			return (frmdesign);
		}

		private void BtnProperties_Click(object sender, System.EventArgs e)
		{
			
		}

		private void BtnSave_Click(object sender, System.EventArgs e)
		{
			if (frmdesign.skin.Path.Length > 1)
			{
				frmdesign.SkinSave();
			}
			else
			{
				MessageBox.Show("Please select a image for the skin before clicking save");
			}
		}

		private void BtnLoad_Click(object sender, System.EventArgs e)
		{
			frmload = new FrmLoad();
			frmload.F = frmdesign;
			frmload.M = this;
			frmload.Show();
		}

		private void BackgroundPicture_Click(object sender, System.EventArgs e)
		{

		}

		private void BtnBlank_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnRadio_Click(object sender, System.EventArgs e)
		{
			frmxradio = new FrmxRadio();
			frmxradio.F = frmdesign;
			frmxradio.Show();
		}

		private void BtnSlider_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnTextArea_Click(object sender, System.EventArgs e)
		{
		
		}

		private void BtnSystem1_Click(object sender, System.EventArgs e)
		{
			skinDetails = new SkinDetails();
			skinDetails.F = frmdesign;
			skinDetails.M = this;
			skinDetails.Show();
		}

		private void BtnSystem2_Click(object sender, System.EventArgs e)
		{
			SkinExplorer skinExplorer = new SkinExplorer();
			skinExplorer.CreateTree(frmdesign.skin);
			skinExplorer.Show();
		}

		private void BtnSystem3_Click(object sender, System.EventArgs e)
		{
			About about = new About();
			about.Show();
		}

		private void ChangeStatus()
		{
			if (this.toggle)
			{
				this.toggle = false;	
			}
			else
			{
				this.toggle = true;
			}

			this.BtnSave.Enabled = this.toggle;
			this.BtnSystem1.Enabled = this.toggle;
			this.btnBlsnk.Enabled = this.toggle;
			this.btnList.Enabled = this.toggle;
			this.btnSpin.Enabled = this.toggle;
			this.btnRadio.Enabled = this.toggle;
			this.btnMark.Enabled = this.toggle;
			this.btnThumb.Enabled = this.toggle;
			this.btnMutli.Enabled = this.toggle;
			//this.btnToggle.Enabled = this.toggle;
			this.btnButton.Enabled = this.toggle;
			this.btnLabel.Enabled = this.toggle;
			this.btnImage.Enabled = this.toggle;
			this.btnTextArea.Enabled = this.toggle;
			this.BtnSlider.Enabled = this.toggle;
			//this.BtnSpinButton.Enabled = this.toggle;
			this.btnBlsnk.Enabled = this.toggle;
			this.BtnSelectButton.Enabled = this.toggle;
			this.btnFadeLabel.Enabled = this.toggle;
			this.BtnBlank.Enabled = this.toggle;
			this.btnRss.Enabled = this.toggle;
		}
	}
}
