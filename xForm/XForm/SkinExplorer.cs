using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using XForm.Data;

namespace XForm
{
	/// <summary>
	/// Summary description for SkinExplorer.
	/// </summary>
	public class SkinExplorer : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView SkinTree;
		/// <Summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SkinExplorer()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//this.CreateTree(skin);
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

		public void CreateTree (Skin skin)
		{
			SkinTree.Nodes.Add(skin.Name);

			if (skin.XButtons != null)
			{
				for (int i = 0; i <	skin.XButtons.Count; i++)
				{
					AddXButton(skin.XButtons[i]);
				}
			}

			if (skin.XButtonT != null)
			{
				for (int i = 0; i <	skin.XButtonT.Count; i++)
				{
					AddXButtonT(skin.XButtonT[i]);
				}
			}

			if (skin.XButtonM != null)
			{
				for (int i = 0; i <	skin.XButtonM.Count; i++)
				{
					AddXButtonM(skin.XButtonM[i]);
				}
			}

			if (skin.XFadeLabel != null)
			{
				for (int i = 0; i <	skin.XFadeLabel.Count; i++)
				{
					AddXFadeLabel(skin.XFadeLabel[i]);
				}
			}

			if (skin.XImage != null)
			{
				for (int i = 0; i <	skin.XImage.Count; i++)
				{
					AddXImage(skin.XImage[i]);
				}
			}

			if (skin.XLabel != null)
			{
				for (int i = 0; i <	skin.XLabel.Count; i++)
				{
					AddXLabel(skin.XLabel[i]);
				}
			}

			if (skin.XListControl != null)
			{
				for (int i = 0; i <	skin.XListControl.Count; i++)
				{
					AddXListControl(skin.XListControl[i]);;
				}
			}

			if (skin.Xmark != null)
			{
				for (int i = 0; i <	skin.Xmark.Count; i++)
				{
					AddXMark(skin.Xmark[i]);;
				}
			}

			if (skin.XProgress != null)
			{
				for (int i = 0; i <	skin.XProgress.Count; i++)
				{
					AddXProgress(skin.XProgress[i]);
				}
			}

			if (skin.XRadio != null)
			{
				for (int i = 0; i <	skin.XRadio.Count; i++)
				{
					AddXRadio(skin.XRadio[i]);
				}
			}

			if (skin.XRam != null)
			{
				for (int i = 0; i <	skin.XRam.Count; i++)
				{
					AddXRam(skin.XRam[i]);
				}
			}

			if (skin.XRss != null)
			{
				for (int i = 0; i <	skin.XRss.Count; i++)
				{
					AddXRss(skin.XRss[i]);
				}
			}

			if (skin.XSelectButton != null)
			{
				for (int i = 0; i <	skin.XSelectButton.Count; i++)
				{
					AddXSelectButton(skin.XSelectButton[i]);
				}
			}

			if (skin.XSlider != null)
			{
				for (int i = 0; i <	skin.XSlider.Count; i++)
				{
					AddXSlider(skin.XSlider[i]);
				}
			}

			if (skin.XSpinButton != null)
			{
				for (int i = 0; i <	skin.XSpinButton.Count; i++)
				{
					AddXSpinButton(skin.XSpinButton[i]);
			
				}
			}

			if (skin.XSpinControl != null)
			{
				for (int i = 0; i <	skin.XSpinControl.Count; i++)
				{
					AddXSpinControl(skin.XSpinControl[i]);
				}
			}

			if (skin.XtextArea != null)
			{
				for (int i = 0; i <	skin.XtextArea.Count; i++)
				{
					AddXTextArea(skin.XtextArea[i]);
				}
			}

			if (skin.XThumbnail != null)
			{
				for (int i = 0; i <	skin.XThumbnail.Count; i++)
				{
					AddXThumbnail(skin.XThumbnail[i]);
				}
			}
		}

		private void AddXButton(XButton xb)
		{
			SkinTree.Nodes.Add("Button " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
					SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
					SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
					SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
					SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
					SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
					SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
					SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));																																								
		}

		private void AddXButtonT(XButtonT xb )
		{
			SkinTree.Nodes.Add("Toggle Button " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
				SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));																																								
		}

		private void AddXButtonM(XButtonM xb )
		{
			SkinTree.Nodes.Add("Multi Button " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
				SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));
		}

		private void AddXFadeLabel(XFadeLabel xb )
		{
			SkinTree.Nodes.Add("Fade Label " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
				SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));
		}

		private void AddXImage(XImage xb )
		{
			SkinTree.Nodes.Add("Image " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
				SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));
		}

		private void AddXLabel(XLabel xb )
		{
			SkinTree.Nodes.Add("Label " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
				SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));
		}

		private void AddXListControl(XListControl xb )
		{
			SkinTree.Nodes.Add("List Control " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
				SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));
		}

		private void AddXMark(Xmark xb )
		{
			SkinTree.Nodes.Add("CheckMark " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
				SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));
		}

		private void AddXProgress(XProgress xb )
		{
			SkinTree.Nodes.Add("Progress Bar " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
				SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));
		}

		private void AddXRadio(XRadio xb )
		{
			SkinTree.Nodes.Add("RadioButton " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
				SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));
		}

		private void AddXRam(XRam xb )
		{
			SkinTree.Nodes.Add("Ram " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
				SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));
		}

		private void AddXRss(XRss xb )
		{
			SkinTree.Nodes.Add("Rss " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
				SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));
		}

		private void AddXSelectButton(XSelectButton xb)
		{
			SkinTree.Nodes.Add("Select Button " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
				SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));
		}

		private void AddXSlider(XSlider xb )
		{
			SkinTree.Nodes.Add("Slider " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
				SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));
		}

		private void AddXSpinButton(XSpinButton xb )
		{
			SkinTree.Nodes.Add("Spin Button " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
				SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));
		}

		private void AddXSpinControl(XSpinControl xb )
		{
			SkinTree.Nodes.Add("Spin Control " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
				SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));
		}

		private void AddXTextArea(XtextArea xb )
		{
			SkinTree.Nodes.Add("Text Area " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
				SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));
		}

		private void AddXThumbnail(Xthumbnail xb )
		{
			SkinTree.Nodes.Add("Thumbnail Panel " + xb.ID.ToString());

			Int32 node = SkinTree.Nodes.Count;
			
			SkinTree.Nodes[node - 1].Nodes.Add("Align = " + (Convert.ToString(xb.Align) == null ? "Empty": (Convert.ToString(xb.Align))));
			SkinTree.Nodes[node - 1].Nodes.Add("Description = " +  (Convert.ToString(xb.Description) == null ? "Empty": (Convert.ToString(xb.Description))));
			SkinTree.Nodes[node - 1].Nodes.Add("Down = " +  (Convert.ToString(xb.Down) == null ? "Empty": (Convert.ToString(xb.Down))));
			SkinTree.Nodes[node - 1].Nodes.Add("Feed = " +  (Convert.ToString(xb.Feed) == null ? "Empty": (Convert.ToString(xb.Feed))));
			SkinTree.Nodes[node - 1].Nodes.Add("Font = " +  (Convert.ToString(xb.Font) == null ? "Empty": (Convert.ToString(xb.Font))));
			SkinTree.Nodes[node - 1].Nodes.Add("Hyperlink = " +  (Convert.ToString(xb.Hyperlink) == null ? "Empty": (Convert.ToString(xb.Hyperlink))));
			SkinTree.Nodes[node - 1].Nodes.Add("ID = " +  (Convert.ToString(xb.ID) == null ? "Empty": (Convert.ToString(xb.ID))));
			SkinTree.Nodes[node - 1].Nodes.Add("Labeltext = " +  (Convert.ToString(xb.Labeltext) == null ? "Empty": (Convert.ToString(xb.Labeltext))));
			SkinTree.Nodes[node - 1].Nodes.Add("Left = " +  (Convert.ToString(xb.Left) == null ? "Empty": (Convert.ToString(xb.Left))));
		
			for (int i = 0; i < xb.Picture.Count; i++)
			{
				SkinTree.Nodes[node - 1].Nodes.Add("Picture = " +  (Convert.ToString(xb.Picture[i].Path) == null ? "Empty": (Convert.ToString(xb.Picture[i].Path))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture H = " +  (Convert.ToString(xb.Picture[i].Pichieght) == null ? "Empty": (Convert.ToString(xb.Picture[i].Pichieght))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture W= " +  (Convert.ToString(xb.Picture[i].Picwidth) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picwidth))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture X= " +  (Convert.ToString(xb.Picture[i].Picxpos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picxpos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture Y= " +  (Convert.ToString(xb.Picture[i].Picypos) == null ? "Empty": (Convert.ToString(xb.Picture[i].Picypos))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture XOff = " +  (Convert.ToString(xb.Picture[i].Spacex) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacex))));
				SkinTree.Nodes[node - 1].Nodes.Add("Picture YOff = " +  (Convert.ToString(xb.Picture[i].Spacey) == null ? "Empty": (Convert.ToString(xb.Picture[i].Spacey))));
			}
								
			SkinTree.Nodes[node - 1].Nodes.Add("Reverse = " +  (Convert.ToString(xb.Reverse) == null ? "Empty": (Convert.ToString(xb.Reverse))));
			SkinTree.Nodes[node - 1].Nodes.Add("Right = " +  (Convert.ToString(xb.Right) == null ? "Empty": (Convert.ToString(xb.Right))));
			SkinTree.Nodes[node - 1].Nodes.Add("Shadow = " +  (Convert.ToString(xb.Shadow) == null ? "Empty": (Convert.ToString(xb.Shadow))));
			SkinTree.Nodes[node - 1].Nodes.Add("Subtype = " +  (Convert.ToString(xb.Subtype) == null ? "Empty": (Convert.ToString(xb.Subtype))));
			SkinTree.Nodes[node - 1].Nodes.Add("Suffix = " +  (Convert.ToString(xb.Suffix) == null ? "Empty": (Convert.ToString(xb.Suffix))));
			SkinTree.Nodes[node - 1].Nodes.Add("Up = " +  (Convert.ToString(xb.Up) == null ? "Empty": (Convert.ToString(xb.Up))));
			SkinTree.Nodes[node - 1].Nodes.Add("Visible = " +  (Convert.ToString(xb.Visible) == null ? "Empty": (Convert.ToString(xb.Visible))));
			SkinTree.Nodes[node - 1].Nodes.Add("XOffset = " +  (Convert.ToString(xb.XOffset) == null ? "Empty": (Convert.ToString(xb.XOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Xpos = " +  (Convert.ToString(xb.Xpos) == null ? "Empty": (Convert.ToString(xb.Xpos))));
			SkinTree.Nodes[node - 1].Nodes.Add("XWidth = " +  (Convert.ToString(xb.XWidth) == null ? "Empty": (Convert.ToString(xb.XWidth))));
			SkinTree.Nodes[node - 1].Nodes.Add("YOffset = " +  (Convert.ToString(xb.YOffset) == null ? "Empty": (Convert.ToString(xb.YOffset))));
			SkinTree.Nodes[node - 1].Nodes.Add("Ypos = " +  (Convert.ToString(xb.Ypos) == null ? "Empty": (Convert.ToString(xb.Ypos))));
			SkinTree.Nodes[node - 1].Nodes.Add("YHieght = " +  (Convert.ToString(xb.YHieght) == null ? "Empty": (Convert.ToString(xb.YHieght))));
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SkinTree = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// SkinTree
			// 
			this.SkinTree.ImageIndex = -1;
			this.SkinTree.Location = new System.Drawing.Point(0, 0);
			this.SkinTree.Name = "SkinTree";
			this.SkinTree.SelectedImageIndex = -1;
			this.SkinTree.Size = new System.Drawing.Size(296, 272);
			this.SkinTree.TabIndex = 0;
			this.SkinTree.Click += new System.EventHandler(this.SkinTree_Click);
			this.SkinTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SkinTree_AfterSelect);
			// 
			// SkinExplorer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.SkinTree);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "SkinExplorer";
			this.Text = "SkinExplorer";
			this.ResumeLayout(false);

		}
		#endregion

		private void SkinTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{

		}

		private void SkinTree_Click(object sender, System.EventArgs e)
		{

		}
	}
}
