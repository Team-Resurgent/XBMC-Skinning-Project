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
	/// Summary description for FrmXImage.
	/// </summary>
	public class SkinDetails : System.Windows.Forms.Form
	{
		private Boolean FirstTime = true;

		private FrmMain m;
		private FrmDesign f;
		private XImage xb;
		private System.Windows.Forms.Label lblcolor2;
		private System.Windows.Forms.Label lblColor1;
		private System.Windows.Forms.Button btnColorDefuse;
		private System.Windows.Forms.ComboBox CboxLabel;
		private System.Windows.Forms.ComboBox CboxFonts;
		private System.Windows.Forms.Label lblFonts;
		private System.Windows.Forms.Button btnIgnore;
		private System.Windows.Forms.Label lblLabel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnImageBrowse;
		private System.Windows.Forms.TextBox txtImage;
		private System.Windows.Forms.TextBox txtYPos;
		private System.Windows.Forms.Label lblYPos;
		private System.Windows.Forms.TextBox txtXPos;
		private System.Windows.Forms.Label lblXPos;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.Label lblID;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.TextBox txtdiffusecolor;
		private System.Windows.Forms.TextBox txtColorkey;
		private System.Windows.Forms.Button btnColorkey;
		private System.Windows.Forms.TextBox txtHeight;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtWidth;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.PictureBox tickimage;
		private System.Windows.Forms.TextBox txtDefualt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolTip toolTips;
		private System.ComponentModel.IContainer components;

		public SkinDetails()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SkinDetails));
			this.txtDefualt = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tickimage = new System.Windows.Forms.PictureBox();
			this.txtHeight = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtWidth = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnImageBrowse = new System.Windows.Forms.Button();
			this.txtImage = new System.Windows.Forms.TextBox();
			this.txtYPos = new System.Windows.Forms.TextBox();
			this.lblYPos = new System.Windows.Forms.Label();
			this.txtXPos = new System.Windows.Forms.TextBox();
			this.lblXPos = new System.Windows.Forms.Label();
			this.txtID = new System.Windows.Forms.TextBox();
			this.lblID = new System.Windows.Forms.Label();
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
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.label2 = new System.Windows.Forms.Label();
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// txtDefualt
			// 
			this.txtDefualt.Location = new System.Drawing.Point(67, 48);
			this.txtDefualt.Name = "txtDefualt";
			this.txtDefualt.Size = new System.Drawing.Size(40, 20);
			this.txtDefualt.TabIndex = 64;
			this.txtDefualt.Text = "";
			this.txtDefualt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(58, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 63;
			this.label1.Text = "Default Ctrl";
			// 
			// tickimage
			// 
			this.tickimage.Image = ((System.Drawing.Image)(resources.GetObject("tickimage.Image")));
			this.tickimage.Location = new System.Drawing.Point(216, 282);
			this.tickimage.Name = "tickimage";
			this.tickimage.Size = new System.Drawing.Size(20, 20);
			this.tickimage.TabIndex = 62;
			this.tickimage.TabStop = false;
			this.tickimage.Visible = false;
			this.tickimage.Click += new System.EventHandler(this.tickimage_Click);
			// 
			// txtHeight
			// 
			this.txtHeight.Location = new System.Drawing.Point(199, 89);
			this.txtHeight.Name = "txtHeight";
			this.txtHeight.Size = new System.Drawing.Size(40, 20);
			this.txtHeight.TabIndex = 61;
			this.txtHeight.Text = "";
			this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(199, 71);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 16);
			this.label4.TabIndex = 60;
			this.label4.Text = "Height";
			// 
			// txtWidth
			// 
			this.txtWidth.Location = new System.Drawing.Point(151, 89);
			this.txtWidth.Name = "txtWidth";
			this.txtWidth.Size = new System.Drawing.Size(40, 20);
			this.txtWidth.TabIndex = 59;
			this.txtWidth.Text = "";
			this.txtWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Cursor = System.Windows.Forms.Cursors.Default;
			this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(151, 71);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 58;
			this.label5.Text = "Width";
			// 
			// btnSave
			// 
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSave.Location = new System.Drawing.Point(64, 344);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(120, 24);
			this.btnSave.TabIndex = 36;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnImageBrowse
			// 
			this.btnImageBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnImageBrowse.Location = new System.Drawing.Point(8, 280);
			this.btnImageBrowse.Name = "btnImageBrowse";
			this.btnImageBrowse.Size = new System.Drawing.Size(200, 24);
			this.btnImageBrowse.TabIndex = 34;
			this.btnImageBrowse.Text = "Browse For Image";
			this.btnImageBrowse.Click += new System.EventHandler(this.btnImageBrowse_Click);
			// 
			// txtImage
			// 
			this.txtImage.Location = new System.Drawing.Point(8, 312);
			this.txtImage.Name = "txtImage";
			this.txtImage.Size = new System.Drawing.Size(232, 20);
			this.txtImage.TabIndex = 33;
			this.txtImage.Text = "";
			this.txtImage.Visible = false;
			// 
			// txtYPos
			// 
			this.txtYPos.Location = new System.Drawing.Point(199, 49);
			this.txtYPos.Name = "txtYPos";
			this.txtYPos.Size = new System.Drawing.Size(40, 20);
			this.txtYPos.TabIndex = 19;
			this.txtYPos.Text = "";
			this.txtYPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// lblYPos
			// 
			this.lblYPos.BackColor = System.Drawing.Color.Transparent;
			this.lblYPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.lblYPos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblYPos.ForeColor = System.Drawing.Color.Black;
			this.lblYPos.Location = new System.Drawing.Point(199, 25);
			this.lblYPos.Name = "lblYPos";
			this.lblYPos.Size = new System.Drawing.Size(40, 16);
			this.lblYPos.TabIndex = 18;
			this.lblYPos.Text = "Y Pos";
			// 
			// txtXPos
			// 
			this.txtXPos.Location = new System.Drawing.Point(151, 49);
			this.txtXPos.Name = "txtXPos";
			this.txtXPos.Size = new System.Drawing.Size(40, 20);
			this.txtXPos.TabIndex = 17;
			this.txtXPos.Text = "";
			this.txtXPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// lblXPos
			// 
			this.lblXPos.BackColor = System.Drawing.Color.Transparent;
			this.lblXPos.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblXPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.lblXPos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblXPos.ForeColor = System.Drawing.Color.Black;
			this.lblXPos.Location = new System.Drawing.Point(151, 25);
			this.lblXPos.Name = "lblXPos";
			this.lblXPos.Size = new System.Drawing.Size(40, 16);
			this.lblXPos.TabIndex = 16;
			this.lblXPos.Text = "X Pos";
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(8, 48);
			this.txtID.MaxLength = 4;
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(40, 20);
			this.txtID.TabIndex = 15;
			this.txtID.Text = "";
			this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FieldKeyPress);
			// 
			// lblID
			// 
			this.lblID.BackColor = System.Drawing.Color.Transparent;
			this.lblID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.lblID.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblID.ForeColor = System.Drawing.Color.Black;
			this.lblID.Location = new System.Drawing.Point(16, 27);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(24, 16);
			this.lblID.TabIndex = 14;
			this.lblID.Text = "ID";
			this.lblID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblcolor2
			// 
			this.lblcolor2.Location = new System.Drawing.Point(0, 0);
			this.lblcolor2.Name = "lblcolor2";
			this.lblcolor2.TabIndex = 0;
			// 
			// lblColor1
			// 
			this.lblColor1.Location = new System.Drawing.Point(0, 0);
			this.lblColor1.Name = "lblColor1";
			this.lblColor1.TabIndex = 0;
			// 
			// txtdiffusecolor
			// 
			this.txtdiffusecolor.Location = new System.Drawing.Point(0, 0);
			this.txtdiffusecolor.Name = "txtdiffusecolor";
			this.txtdiffusecolor.TabIndex = 0;
			this.txtdiffusecolor.Text = "";
			// 
			// btnColorDefuse
			// 
			this.btnColorDefuse.Location = new System.Drawing.Point(0, 0);
			this.btnColorDefuse.Name = "btnColorDefuse";
			this.btnColorDefuse.TabIndex = 0;
			// 
			// CboxLabel
			// 
			this.CboxLabel.Location = new System.Drawing.Point(0, 0);
			this.CboxLabel.Name = "CboxLabel";
			this.CboxLabel.Size = new System.Drawing.Size(121, 21);
			this.CboxLabel.TabIndex = 0;
			// 
			// CboxFonts
			// 
			this.CboxFonts.Location = new System.Drawing.Point(0, 0);
			this.CboxFonts.Name = "CboxFonts";
			this.CboxFonts.Size = new System.Drawing.Size(121, 21);
			this.CboxFonts.TabIndex = 0;
			// 
			// lblFonts
			// 
			this.lblFonts.Location = new System.Drawing.Point(0, 0);
			this.lblFonts.Name = "lblFonts";
			this.lblFonts.TabIndex = 0;
			// 
			// txtColorkey
			// 
			this.txtColorkey.Location = new System.Drawing.Point(0, 0);
			this.txtColorkey.Name = "txtColorkey";
			this.txtColorkey.TabIndex = 0;
			this.txtColorkey.Text = "";
			// 
			// btnColorkey
			// 
			this.btnColorkey.Location = new System.Drawing.Point(0, 0);
			this.btnColorkey.Name = "btnColorkey";
			this.btnColorkey.TabIndex = 0;
			// 
			// btnIgnore
			// 
			this.btnIgnore.Location = new System.Drawing.Point(0, 0);
			this.btnIgnore.Name = "btnIgnore";
			this.btnIgnore.TabIndex = 0;
			// 
			// lblLabel
			// 
			this.lblLabel.Location = new System.Drawing.Point(0, 0);
			this.lblLabel.Name = "lblLabel";
			this.lblLabel.TabIndex = 0;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Image Files |(*.gif;*.jpg;*.png)";
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(21, 139);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(217, 108);
			this.label2.TabIndex = 65;
			this.label2.Text = "Welcome to xForm this is the skin propertie editor you must use the button below " +
				"to search for a background image for your skin before clicking save.  If the ima" +
				"ge wraps dont worry it wont do it in XBMC graphical hitch im afraid :)";
			// 
			// toolTips
			// 
			this.toolTips.AutomaticDelay = 50;
			this.toolTips.AutoPopDelay = 10000;
			this.toolTips.InitialDelay = 50;
			this.toolTips.ReshowDelay = 10;
			this.toolTips.ShowAlways = true;
			// 
			// SkinDetails
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(248, 400);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtYPos);
			this.Controls.Add(this.lblYPos);
			this.Controls.Add(this.txtXPos);
			this.Controls.Add(this.lblXPos);
			this.Controls.Add(this.txtID);
			this.Controls.Add(this.lblID);
			this.Controls.Add(this.tickimage);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtDefualt);
			this.Controls.Add(this.txtHeight);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtWidth);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnImageBrowse);
			this.Controls.Add(this.txtImage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Location = new System.Drawing.Point(800, 50);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SkinDetails";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;
			this.Load += new System.EventHandler(this.FrmXImage_Load);
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
				this.txtWidth.Text = (Image.FromFile(path).Width).ToString();
				this.txtHeight.Text = (Image.FromFile(path).Height).ToString();
			
				tickimage.Visible = true;
			}

			this.toolTips.SetToolTip(this.btnImageBrowse, Path.GetFileName(this.txtImage.Text));
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			this.btnSave.Enabled = true;		
		}

		private void FrmXImage_Load(object sender, System.EventArgs e)
		{
			if (f.skin.ID.ToString() != null)
			{
				this.txtID.Text = f.skin.ID.ToString();
			}

			if (f.skin.Control.ToString() != null)
			{
				this.txtDefualt.Text = f.skin.Control.ToString();
			}

			if (f.skin.Picture.Count != 0)
			{
				this.txtImage.Text = f.skin.Picture[0].Path;
				this.txtXPos.Text = f.skin.Picture[0].Picxpos;
				this.txtYPos.Text = f.skin.Picture[0].Picypos;
				this.txtWidth.Text = f.skin.Picture[0].Picwidth;
				this.txtHeight.Text = f.skin.Picture[0].Pichieght;
				this.tickimage.Visible = true;
			}

			
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (this.txtImage.Text != String.Empty)
			{
				Picture pica = new Picture();
				pica.Path = this.txtImage.Text;
				pica.Picwidth = (Image.FromFile(pica.Path).Width).ToString();
				pica.Pichieght = (Image.FromFile(pica.Path).Height).ToString();
			
				f.skin.ID = Convert.ToInt32(this.txtID.Text == "" ? "0" : this.txtID.Text);
				f.skin.Picture.Add("BG-Picture",pica);
				f.skin.Control = Convert.ToInt32(this.txtDefualt.Text == "" ? "0" : this.txtDefualt.Text);

				f.UpDateBG();

				this.Close();
			}
			else
			{
				MessageBox.Show("You must select a valid image before saving","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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

		private void tickimage_Click(object sender, System.EventArgs e)
		{
			this.tickimage.Visible = false;
			this.txtImage.Text = String.Empty;
		}

		private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
		
		}
	}
}
