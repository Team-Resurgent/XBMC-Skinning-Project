using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace XForm
{
	/// <summary>
	/// Summary description for FrmNew.
	/// </summary>
	public class FrmNew : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox BtnNewFile;
		private System.Windows.Forms.PictureBox BtnNewProject;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private FrmDesign f;
		private FrmMain m;
		private System.Windows.Forms.SaveFileDialog sfdNewProject;
		private System.Windows.Forms.SaveFileDialog sfdNewFile;
		private System.Windows.Forms.RadioButton RadPal;
		private System.Windows.Forms.CheckBox ChkWidescreen;
		private System.Windows.Forms.RadioButton RadNtsc;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.ToolTip toolTips;
		private System.ComponentModel.IContainer components;

		public FrmNew()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmNew));
			this.BtnNewFile = new System.Windows.Forms.PictureBox();
			this.BtnNewProject = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.sfdNewProject = new System.Windows.Forms.SaveFileDialog();
			this.sfdNewFile = new System.Windows.Forms.SaveFileDialog();
			this.RadPal = new System.Windows.Forms.RadioButton();
			this.ChkWidescreen = new System.Windows.Forms.CheckBox();
			this.RadNtsc = new System.Windows.Forms.RadioButton();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
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
			this.label1.Location = new System.Drawing.Point(72, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "New Skin Project";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(72, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "New Skin File";
			// 
			// sfdNewProject
			// 
			this.sfdNewProject.AddExtension = false;
			this.sfdNewProject.Filter = "XBMC Folder|*.*";
			// 
			// sfdNewFile
			// 
			this.sfdNewFile.AddExtension = false;
			this.sfdNewFile.Filter = "XBMC SkinFile|*.xml";
			// 
			// RadPal
			// 
			this.RadPal.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.RadPal.Location = new System.Drawing.Point(80, 88);
			this.RadPal.Name = "RadPal";
			this.RadPal.TabIndex = 4;
			this.RadPal.Text = "Pal";
			// 
			// ChkWidescreen
			// 
			this.ChkWidescreen.Location = new System.Drawing.Point(80, 136);
			this.ChkWidescreen.Name = "ChkWidescreen";
			this.ChkWidescreen.TabIndex = 5;
			this.ChkWidescreen.Text = "Widescreen";
			// 
			// RadNtsc
			// 
			this.RadNtsc.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.RadNtsc.Location = new System.Drawing.Point(80, 110);
			this.RadNtsc.Name = "RadNtsc";
			this.RadNtsc.TabIndex = 6;
			this.RadNtsc.Text = "Ntsc";
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
			// FrmNew
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(208, 166);
			this.Controls.Add(this.pictureBox4);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.RadNtsc);
			this.Controls.Add(this.ChkWidescreen);
			this.Controls.Add(this.RadPal);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BtnNewProject);
			this.Controls.Add(this.BtnNewFile);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmNew";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New Project/Skin";
			this.Load += new System.EventHandler(this.FrmNew_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void BtnNewProject_Click(object sender, System.EventArgs e)
		{
			if (this.sfdNewProject.ShowDialog() == DialogResult.OK)
			{
				String path = Path.GetFullPath(sfdNewProject.FileName);
				Directory.CreateDirectory(path);
				Directory.CreateDirectory(path + @"\media");
				Directory.CreateDirectory(path + @"\fonts");
				Directory.CreateDirectory(path + @"\NTSC");
				Directory.CreateDirectory(path + @"\PAL");
				Directory.CreateDirectory(path + @"\NTSC16x9");
				Directory.CreateDirectory(path + @"\PAL16x9");
				path += @"\";

				if (Directory.GetFiles(Application.StartupPath + @"\fonts\",@"*.*").Length >0)
				{
					String[] Files = Directory.GetFiles(Application.StartupPath + @"\fonts\",@"*.*");

					for (Int32 i = 0; i < Files.Length; i++)
					{
						try{File.Copy(Files[i], path + @"fonts\" + Path.GetFileName(Files[i]),true);}
						catch(System.IO.IOException){MessageBox.Show("Error Copying Fonts");};
					}
				}

				try{File.Copy(Application.StartupPath + @"\references.xml", path + @"NTSC\" + @"references.xml",true);}
				catch(System.IO.IOException){MessageBox.Show("Error Copying Reference Files");};

				try{File.Copy(Application.StartupPath + @"\references.xml", path + @"NTSC16x9\" + @"references.xml",true);}
				catch(System.IO.IOException){MessageBox.Show("Error Copying Reference Files");};

				try{File.Copy(Application.StartupPath + @"\references.xml", path + @"PAL\" + @"references.xml",true);}
				catch(System.IO.IOException){MessageBox.Show("Error Copying Reference Files");};

				try{File.Copy(Application.StartupPath + @"\references.xml", path + @"PAL16x9\" + @"references.xml",true);}
				catch(System.IO.IOException){MessageBox.Show("Error Copying Reference Files");};

				try{File.Copy(Application.StartupPath + @"\font.xml", path + @"NTSC\" + @"font.xml",true);}
				catch(System.IO.IOException){MessageBox.Show("Error Copying Reference Files");};

				try{File.Copy(Application.StartupPath + @"\font.xml", path + @"NTSC16x9\" + @"font.xml",true);}
				catch(System.IO.IOException){MessageBox.Show("Error Copying Reference Files");};

				try{File.Copy(Application.StartupPath + @"\font.xml", path + @"PAL\" + @"font.xml",true);}
				catch(System.IO.IOException){MessageBox.Show("Error Copying Reference Files");};

				try{File.Copy(Application.StartupPath + @"\font.xml", path + @"PAL16x9\" + @"font.xml",true);}
				catch(System.IO.IOException){MessageBox.Show("Error Copying Reference Files");};

				String[] Type = path.Split(new char [] {'\\'} );

				XmlTextWriter xwriter = new XmlTextWriter(path + Type[Type.Length - 2] + @".xFm",System.Text.Encoding.UTF8);
	
				xwriter.Formatting = Formatting.Indented;

				xwriter.WriteStartElement ("xForm Project");
				
				xwriter.WriteEndElement();

				xwriter.Close();

				m.ProjectPath = path;

				this.Close();
			}
		}

		private void BtnNewFile_Click(object sender, System.EventArgs e)
		{
			if (m.ProjectPath != String.Empty)
			{
				if (this.RadPal.Checked)
				{
					if (this.ChkWidescreen.Checked)
					{
						sfdNewFile.InitialDirectory = m.ProjectPath + @"PAL16x9\";
					}
					else
					{
						sfdNewFile.InitialDirectory = m.ProjectPath + @"PAL\";
					}
				}
				else
				{
					if (this.ChkWidescreen.Checked)
					{
						sfdNewFile.InitialDirectory = m.ProjectPath + @"NTSC16x9\";
					}
					else
					{
						sfdNewFile.InitialDirectory = m.ProjectPath + @"NTSC\";
					}
				}
			
				if (this.sfdNewFile.ShowDialog() == DialogResult.OK)
				{
					Boolean Ratio;
					Boolean Res;

					if (this.RadPal.Checked)
					{
						Res = false;
					}
					else
					{
						Res = true;
					}

					Ratio = this.ChkWidescreen.Checked;

					m.RES = Res;
					m.RATIO = Ratio;

					f = m.CreateNewSKinFile();

					String path = Path.GetDirectoryName(sfdNewFile.FileName) + @"\";
					String projectpath = "";

					String[] paths = path.Split(new char[] {'\\'});

					for (Int32 i = 0; i < paths.Length - 2; i++)
					{
						projectpath += paths[i] + @"\";
					}

					f.skin.Name = Path.GetFileNameWithoutExtension(sfdNewFile.FileName);
					f.skin.Res = Res;
					f.skin.Ratio = Ratio;

					SkinDetails skinDetails = new SkinDetails();
					skinDetails.F = f;
					skinDetails.M = m;
					skinDetails.Show();

					m.ProjectPath = projectpath;
					f.skin.Path = path;
				
					this.Close();
				}
			}
		}

		private void FrmNew_Load(object sender, System.EventArgs e)
		{
			this.RadNtsc.Select();
			if (m.ProjectPath == String.Empty)
			{
				this.BtnNewFile.Enabled = true;
				this.toolTips.SetToolTip (this.BtnNewFile, "You must create or load a project before you can access this button");
			}
		}
	}
}
