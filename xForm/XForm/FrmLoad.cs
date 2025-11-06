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
	/// Summary description for FrmNew.
	/// </summary>
	public class FrmLoad : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox BtnNewFile;
		private System.Windows.Forms.PictureBox BtnNewProject;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private FrmDesign f;
		private FrmMain m;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.ToolTip toolTips;
		private System.Windows.Forms.OpenFileDialog openProject;
		private System.Windows.Forms.OpenFileDialog openFile;
		private System.ComponentModel.IContainer components;

		public FrmLoad()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public FrmDesign F
		{
			get {return this.f;}
			set {this.f = value;}
		}

		public FrmMain M
		{
			get {return this.m;}
			set {this.m = value;}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmLoad));
			this.BtnNewFile = new System.Windows.Forms.PictureBox();
			this.BtnNewProject = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			this.openProject = new System.Windows.Forms.OpenFileDialog();
			this.openFile = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// BtnNewFile
			// 
			this.BtnNewFile.Image = ((System.Drawing.Image)(resources.GetObject("BtnNewFile.Image")));
			this.BtnNewFile.Location = new System.Drawing.Point(16, 80);
			this.BtnNewFile.Name = "BtnNewFile";
			this.BtnNewFile.Size = new System.Drawing.Size(48, 48);
			this.BtnNewFile.TabIndex = 0;
			this.BtnNewFile.TabStop = false;
			this.BtnNewFile.Click += new System.EventHandler(this.BtnNewFile_Click);
			// 
			// BtnNewProject
			// 
			this.BtnNewProject.Image = ((System.Drawing.Image)(resources.GetObject("BtnNewProject.Image")));
			this.BtnNewProject.Location = new System.Drawing.Point(16, 16);
			this.BtnNewProject.Name = "BtnNewProject";
			this.BtnNewProject.Size = new System.Drawing.Size(56, 48);
			this.BtnNewProject.TabIndex = 1;
			this.BtnNewProject.TabStop = false;
			this.BtnNewProject.Click += new System.EventHandler(this.BtnNewProject_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(72, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "Load Skin Project";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(73, 90);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "Load Skin File";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(-17, -237);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(349, 239);
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(-1, 165);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(230, 149);
			this.pictureBox2.TabIndex = 8;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(207, -37);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(98, 223);
			this.pictureBox3.TabIndex = 9;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox4
			// 
			this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
			this.pictureBox4.Location = new System.Drawing.Point(-20, -25);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(21, 210);
			this.pictureBox4.TabIndex = 10;
			this.pictureBox4.TabStop = false;
			// 
			// toolTips
			// 
			this.toolTips.AutomaticDelay = 50;
			this.toolTips.AutoPopDelay = 10000;
			this.toolTips.InitialDelay = 50;
			this.toolTips.ReshowDelay = 10;
			this.toolTips.ShowAlways = true;
			// 
			// openProject
			// 
			this.openProject.Filter = "xForm Project|*.xFm";
			// 
			// openFile
			// 
			this.openFile.Filter = "XBMC Skinfile|*.xml";
			// 
			// FrmLoad
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(208, 166);
			this.Controls.Add(this.pictureBox4);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BtnNewProject);
			this.Controls.Add(this.BtnNewFile);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmLoad";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New Project/Skin";
			this.Load += new System.EventHandler(this.FrmNew_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void BtnNewProject_Click(object sender, System.EventArgs e)
		{
			if (this.openProject.ShowDialog() == DialogResult.OK)
			{
				m.ProjectPath = Path.GetDirectoryName(openProject.FileName) + @"\";

				MessageBox.Show("Project " + Path.GetFileNameWithoutExtension(openProject.FileName) + " Loaded Successfully");
				
				this.Close();
			}
		}

		private void BtnNewFile_Click(object sender, System.EventArgs e)
		{
			String path;

			if (m.ProjectPath != String.Empty)
			{
				if (this.openFile.ShowDialog() == DialogResult.OK)
				{
					path = Path.GetFullPath(openFile.FileName);

					String[] Type = path.Split(new char [] {'\\'} );

					switch (Type[Type.Length - 2].ToUpper())
					{
						case "PAL":

							m.RES = false;
							m.RATIO = false;

							break;

						case "PAL16X9":

							m.RES = false;
							m.RATIO = true;

							break;

						case "NTSC":

							m.RES = true;
							m.RATIO = false;

							break;

						case "NTSC16X9":

							m.RES = true;
							m.RATIO = true;

							break;

					}

					FrmDesign frmdesign = new FrmDesign();
					frmdesign = m.CreateNewSKinFile();
					frmdesign.SkinLoad(path, m.ProjectPath);
					frmdesign.UpDateBG();
					frmdesign.Rebuildskin();

					this.Close();
				}
			}
		}

		private void FrmNew_Load(object sender, System.EventArgs e)
		{
			if (m.ProjectPath == String.Empty)
			{
				this.BtnNewFile.Enabled = true;
				this.toolTips.SetToolTip (this.BtnNewFile, "You must create or load a project before you can access this button");
			}
		}
	}
}
