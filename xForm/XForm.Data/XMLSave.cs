using System;
using System.Xml;
using System.IO;

namespace XForm.Data
{
	/// <summary>
	/// Summary description for XMLSave.
	/// </summary>
	public class XMLSave
	{
		private GetLabel getLabel;

		public XMLSave()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public Boolean SaveSkin(	String							name,
			String							path,
			String							projectpath,
			String							apppath,
			Int32							control,
			Int32							id,
			XButtonCollection				xButton,
			XImageCollection				xImage,
			XLabelCollection				xLabel,
			XColorCollection				xColor,
			PictureCollection				picture,
			XButtonMCollection				xButtonM,
			XButtonTCollection				xButtonT,
			XFadeLabelCollection			xFadeLabel,
			XListControlCollection			xListcontrol,
			XmarkCollection					xmark,
			XProgressCollection				xProgress,
			XRadioCollection				xRadio,
			XRamCollection					xRam,
			XRssCollection					xRss,
			XSelectButtonCollection			xSelectButton,
			XSliderCollection				xSlider,
			XSpinButtonCollection			xSpinButton,
			XSpinControlCollection			xSpincontrol,
			XtextAreaCollection				xtextArea,
			XthumbnailCollection			xthumbnail
			)
		{
			getLabel = new GetLabel();
			getLabel.Path = apppath;

			
			XmlTextWriter xwriter = new XmlTextWriter(path + name + @".xml",System.Text.Encoding.UTF8);
	
			xwriter.Formatting = Formatting.Indented;

			xwriter.WriteStartElement ("window");
			xwriter.WriteElementString ("id",id.ToString());
			xwriter.WriteElementString ("defaultcontrol",control.ToString());
			xwriter.WriteStartElement ("controls");

			xwriter.WriteStartElement ("control");
			xwriter.WriteElementString ("type","image");
			xwriter.WriteElementString ("description","BackGround Image");
			xwriter.WriteElementString ("id","0");
			xwriter.WriteElementString ("posX","0");
			xwriter.WriteElementString ("posY","0");
			xwriter.WriteElementString ("width",picture[0].Picwidth.ToString());
			xwriter.WriteElementString ("height",picture[0].Pichieght.ToString());
			xwriter.WriteElementString ("texture",Path.GetFileName(picture[0].Path));

			if (picture[0].Path == projectpath + @"media\" + Path.GetFileName(picture[0].Path))
			{}
			else
			{
				try{File.Copy(Path.GetFileName(picture[0].Path),projectpath + @"Media\" + Path.GetFileName(picture[0].Path),true);}
				catch(System.IO.IOException){return (false);}
			}

			xwriter.WriteEndElement();
			
			if (xButton != null ){ AddButton(xButton, xwriter, projectpath);}
//			if (xButtonM != null ){ AddButtonM(xButtonM, xwriter, projectpath);}
//			if (xButtonT != null ){ AddButtonT(xButtonT, xwriter, projectpath);}
			if (xFadeLabel != null ){ AddFadeLabel(xFadeLabel, xwriter, projectpath);}
			if (xImage != null ){ AddImage(xImage, xwriter, projectpath);}
			if (xLabel != null ){ AddLabel(xLabel, xwriter, projectpath);}
			if (xListcontrol != null ){ AddListcontrol(xListcontrol, xwriter, projectpath);}
			if (xmark != null ){ AddMark(xmark, xwriter, projectpath);}
//			if (xProgress != null ){ AddProgress(xProgress, xwriter, projectpath);}
			if (xRadio != null ){ AddRadio(xRadio, xwriter, projectpath);}
//			if (xRam != null ){ AddRam(xRam, xwriter, projectpath);}
			if (xRss != null ){ AddRss(xRss, xwriter, projectpath);}
			if (xSelectButton != null ){ AddSelectButton(xSelectButton, xwriter, projectpath);}
//			if (xSlider != null ){ AddSlider(xSlider, xwriter, projectpath);}
//			if (xSpinButton != null ){ AddSpinButton(xSpinButton, xwriter, projectpath);}
			if (xSpincontrol != null ){ AddSpincontrol(xSpincontrol, xwriter, projectpath);}
//			if (xtextArea != null ){ AddTextArea(xtextArea, xwriter, projectpath);}
			if (xthumbnail != null ){ AddThumbnail(xthumbnail, xwriter, projectpath);}

			xwriter.Close();

			return (true);
		}

		private Boolean AddButton(XButtonCollection xb, XmlTextWriter xwriter, String projectpath)
		{
			for (int i = 0 ; i < xb.Count; i++)
			{
				if (xb[i].Save)
				{

					xwriter.WriteStartElement ("control");
					xwriter.WriteElementString ("description",xb[i].Description);
					xwriter.WriteElementString ("type","button");
					xwriter.WriteElementString ("id",Convert.ToString(xb[i].ID));
					xwriter.WriteElementString ("posX",Convert.ToString(xb[i].Xpos));
					xwriter.WriteElementString ("posY",Convert.ToString(xb[i].Ypos));
					xwriter.WriteElementString ("width",Convert.ToString(xb[i].XWidth));
					xwriter.WriteElementString ("height",Convert.ToString(xb[i].YHieght));
					xwriter.WriteElementString ("label", getLabel.GetValueFromLabel(xb[i].Labeltext));
					xwriter.WriteElementString ("font",xb[i].Font);
					xwriter.WriteElementString ("hyperlink",Convert.ToString(xb[i].Hyperlink));
					xwriter.WriteElementString ("textureFocus",Path.GetFileName(xb[i].Picture["textureFocus"].Path));
					xwriter.WriteElementString ("textureNoFocus",Path.GetFileName(xb[i].Picture["textureNoFocus"].Path));
					xwriter.WriteElementString ("textcolor",xb[i].XColor["textcolor"].Color);
					xwriter.WriteElementString ("colordiffuse",xb[i].XColor["colordiffuse"].Color);
					xwriter.WriteElementString ("disabledcolor",xb[i].XColor["disabledcolor"].Color);
					xwriter.WriteElementString ("onleft",Convert.ToString(xb[i].Left));
					xwriter.WriteElementString ("onright",Convert.ToString(xb[i].Right));
					xwriter.WriteElementString ("onup",Convert.ToString(xb[i].Up));
					xwriter.WriteElementString ("ondown",Convert.ToString(xb[i].Down));
					xwriter.WriteElementString ("textOffsetX",Convert.ToString(xb[i].XOffset));
					xwriter.WriteElementString ("textOffsetY",Convert.ToString(xb[i].YOffset));
					xwriter.WriteEndElement();

					if (xb[i].Picture[0].Path == projectpath + @"media\" + Path.GetFileName(xb[i].Picture[0].Path))
					{}
					else
					{
						try{File.Copy(xb[i].Picture[0].Path,projectpath + @"Media\" + Path.GetFileName(xb[i].Picture[0].Path),true);}
						catch(System.IO.IOException){return(false);}
					}

					if (xb[i].Picture[1].Path == projectpath + @"media\" + Path.GetFileName(xb[i].Picture[1].Path))
					{}
					else
					{
						try	{File.Copy(xb[i].Picture[1].Path,projectpath + @"Media\" + Path.GetFileName(xb[i].Picture[1].Path),true);}
						catch(System.IO.IOException){return(false);}
					}
				}	
			}
			return (true);
		}

		private Boolean AddImage(XImageCollection xi, XmlTextWriter xwriter, String projectpath)
		{
			for (int i = 0 ; i < xi.Count; i++)
			{
				if (xi[i].Save)
				{
					xwriter.WriteStartElement ("control");
					xwriter.WriteElementString ("description",xi[i].Description);
					xwriter.WriteElementString ("type","image");
					xwriter.WriteElementString ("id",Convert.ToString(xi[i].ID));
					xwriter.WriteElementString ("posX",Convert.ToString(xi[i].Xpos));
					xwriter.WriteElementString ("posY",Convert.ToString(xi[i].Ypos));
					xwriter.WriteElementString ("width",Convert.ToString(xi[i].XWidth));
					xwriter.WriteElementString ("height",Convert.ToString(xi[i].YHieght));
					xwriter.WriteElementString ("texture",Path.GetFileName(xi[i].Picture["textureFocus"].Path));
					xwriter.WriteElementString ("colorkey",xi[i].XColor[0].Color);
					xwriter.WriteElementString ("colordiffuse",xi[i].XColor[1].Color);
					xwriter.WriteEndElement();

					if (xi[i].Picture[0].Path == projectpath + @"media\" + Path.GetFileName(xi[i].Picture[0].Path))
					{}
					else
					{
						try{File.Copy(xi[i].Picture[0].Path,projectpath + @"Media\" + Path.GetFileName(xi[i].Picture[0].Path),true);}
						catch(System.IO.IOException){return(false);}
					}
				}
			}	
			return (true);
		}
		
		private Boolean AddLabel(XLabelCollection xl, XmlTextWriter xwriter, String projectpath)
		{
			for (int i = 0 ; i < xl.Count; i++)
			{
				if (xl[i].Save)
				{
					xwriter.WriteStartElement ("control");
					xwriter.WriteElementString ("description",xl[i].Description);
					xwriter.WriteElementString ("type","label");
					xwriter.WriteElementString ("id",Convert.ToString(xl[i].ID));
					xwriter.WriteElementString ("posX",Convert.ToString(xl[i].Xpos));
					xwriter.WriteElementString ("posY",Convert.ToString(xl[i].Ypos));
					xwriter.WriteElementString ("width",Convert.ToString(xl[i].XWidth));
					
					xwriter.WriteElementString ("label", getLabel.GetValueFromLabel(xl[i].Labeltext));
					xwriter.WriteElementString ("font",xl[i].Font);
					xwriter.WriteElementString ("textcolor",xl[i].XColor["textcolor"].Color);
					xwriter.WriteElementString ("disabledcolor",xl[i].XColor["disabledcolor"].Color);
					xwriter.WriteElementString ("textOffsetX",Convert.ToString(xl[i].XOffset));
					xwriter.WriteElementString ("textOffsetY",Convert.ToString(xl[i].YOffset));

					xwriter.WriteEndElement();
				}
			}	
			return (true);
		}

		

		private Boolean AddListcontrol(XListControlCollection xb, XmlTextWriter xwriter, String projectpath)
		{
			for (int i = 0 ; i < xb.Count; i++)
			{
				if (xb[i].Save)
				{
					xwriter.WriteStartElement ("control");
					xwriter.WriteElementString ("description",xb[i].Description);
					xwriter.WriteElementString ("type","listcontrol");
					xwriter.WriteElementString ("id",Convert.ToString(xb[i].ID));
					xwriter.WriteElementString ("posX",Convert.ToString(xb[i].Xpos));
					xwriter.WriteElementString ("posY",Convert.ToString(xb[i].Ypos));
					xwriter.WriteElementString ("width",Convert.ToString(xb[i].XWidth));
					xwriter.WriteElementString ("height",Convert.ToString(xb[i].YHieght));
					xwriter.WriteElementString ("spinWidth",Convert.ToString(xb[i].Picture["textureUp"].Picwidth));
					xwriter.WriteElementString ("spinHeight",Convert.ToString(xb[i].Picture["textureUp"].Pichieght));
					xwriter.WriteElementString ("spinPosX",Convert.ToString(xb[i].Picture["textureUp"].Picxpos));
					xwriter.WriteElementString ("spinPosY",Convert.ToString(xb[i].Picture["textureUp"].Picypos));
					xwriter.WriteElementString ("label", getLabel.GetValueFromLabel(xb[i].Labeltext));
					xwriter.WriteElementString ("font",xb[i].Font);
					xwriter.WriteElementString ("hyperlink",Convert.ToString(xb[i].Hyperlink));
					xwriter.WriteElementString ("textureUp",Path.GetFileName(xb[i].Picture["textureUp"].Path));
					xwriter.WriteElementString ("textureDown",Path.GetFileName(xb[i].Picture["textureDown"].Path));
					xwriter.WriteElementString ("textureUpFocus",Path.GetFileName(xb[i].Picture["textureUpFocus"].Path));
					xwriter.WriteElementString ("textureDownFocus",Path.GetFileName(xb[i].Picture["textureDownFocus"].Path));
					xwriter.WriteElementString ("textureFocus",Path.GetFileName(xb[i].Picture["textureFocus"].Path));
					xwriter.WriteElementString ("textureNoFocus",Path.GetFileName(xb[i].Picture["textureNoFocus"].Path));
					xwriter.WriteElementString ("image",Path.GetFileName(xb[i].Picture["image"].Path));
					xwriter.WriteElementString ("textureHeight",Path.GetFileName(xb[i].Picture["textureFocus"].Pichieght));
					xwriter.WriteElementString ("selectedColor",xb[i].XColor["textcolor"].Color);
					xwriter.WriteElementString ("textcolor",xb[i].XColor["textcolor"].Color);
					xwriter.WriteElementString ("colordiffuse",xb[i].XColor["colordiffuse"].Color);
					xwriter.WriteElementString ("spinColor",xb[i].XColor["spinColor"].Color);
					xwriter.WriteElementString ("onleft",Convert.ToString(xb[i].Left));
					xwriter.WriteElementString ("onright",Convert.ToString(xb[i].Right));
					xwriter.WriteElementString ("onup",Convert.ToString(xb[i].Up));
					xwriter.WriteElementString ("ondown",Convert.ToString(xb[i].Up));
//					xwriter.WriteElementString ("textOffsetX",Convert.ToString(xb[i].XOffset));
//					xwriter.WriteElementString ("textOffsetY",Convert.ToString(xb[i].YOffset));
					xwriter.WriteEndElement();

					for (int j = 0; j < xb[i].Picture.Count; j++)
					{
						if (xb[i].Picture[j].Path == projectpath + @"media\" + Path.GetFileName(xb[i].Picture[j].Path))
						{}
						else
						{
							try{File.Copy(xb[i].Picture[j].Path,projectpath + @"Media\" + Path.GetFileName(xb[i].Picture[j].Path),true);}
							catch(System.IO.IOException){return(false);}
						}
					}
				}
			}	
			return (true);
		}

		private Boolean AddRss(XRssCollection xl, XmlTextWriter xwriter, String projectpath)
		{
			for (int i = 0 ; i < xl.Count; i++)
			{
				if (xl[i].Save)
				{
					xwriter.WriteStartElement ("control");
					xwriter.WriteElementString ("description",xl[i].Description);
					xwriter.WriteElementString ("type","rss");
					xwriter.WriteElementString ("id",Convert.ToString(xl[i].ID));
					xwriter.WriteElementString ("posX",Convert.ToString(xl[i].Xpos));
					xwriter.WriteElementString ("posY",Convert.ToString(xl[i].Ypos));
					xwriter.WriteElementString ("width",Convert.ToString(xl[i].XWidth));
					xwriter.WriteElementString ("feed",xl[i].Feed);
					xwriter.WriteElementString ("font",xl[i].Font);
					xwriter.WriteElementString ("titlecolor",xl[i].XColor["titlecolor"].Color);
					xwriter.WriteElementString ("textcolor",xl[i].XColor["textcolor"].Color);
					xwriter.WriteElementString ("headlinecolor",xl[i].XColor["headlinecolor"].Color);
					xwriter.WriteElementString ("textOffsetX",Convert.ToString(xl[i].XOffset));
					xwriter.WriteElementString ("textOffsetY",Convert.ToString(xl[i].YOffset));

					xwriter.WriteEndElement();
				}	
			}
			return (true);
		}
		
		private Boolean AddThumbnail(XthumbnailCollection xb, XmlTextWriter xwriter, String projectpath)
		{
			for (int i = 0 ; i < xb.Count; i++)
			{
				if (xb[i].Save)
				{
					xwriter.WriteStartElement ("control");
					xwriter.WriteElementString ("description",xb[i].Description);
					xwriter.WriteElementString ("type","thumbnailpanel");
					xwriter.WriteElementString ("id",Convert.ToString(xb[i].ID));
					xwriter.WriteElementString ("posX",Convert.ToString(xb[i].Xpos));
					xwriter.WriteElementString ("posY",Convert.ToString(xb[i].Ypos));
					xwriter.WriteElementString ("width",Convert.ToString(xb[i].XWidth));
					xwriter.WriteElementString ("height",Convert.ToString(xb[i].YHieght));
					xwriter.WriteElementString ("spinWidth",Convert.ToString(xb[i].Picture["textureUp"].Picwidth));
					xwriter.WriteElementString ("spinHeight",Convert.ToString(xb[i].Picture["textureUp"].Pichieght));
					xwriter.WriteElementString ("spinPosX",Convert.ToString(xb[i].Picture["textureUp"].Picxpos));
					xwriter.WriteElementString ("spinPosY",Convert.ToString(xb[i].Picture["textureUp"].Picypos));
					xwriter.WriteElementString ("font",xb[i].Font);
					xwriter.WriteElementString ("textureUp",Path.GetFileName(xb[i].Picture["textureUp"].Path));
					xwriter.WriteElementString ("textureDown",Path.GetFileName(xb[i].Picture["textureDown"].Path));
					xwriter.WriteElementString ("textureUpFocus",Path.GetFileName(xb[i].Picture["textureUpFocus"].Path));
					xwriter.WriteElementString ("textureDownFocus",Path.GetFileName(xb[i].Picture["textureDownFocus"].Path));
					xwriter.WriteElementString ("imageFolder",Path.GetFileName(xb[i].Picture["imageFolder"].Path));
					xwriter.WriteElementString ("imageFolderFocus",Path.GetFileName(xb[i].Picture["imageFolderFocus"].Path));
					xwriter.WriteElementString ("selectedColor",xb[i].XColor["textcolor"].Color);
					xwriter.WriteElementString ("textcolor",xb[i].XColor["textcolor"].Color);
					xwriter.WriteElementString ("colordiffuse",xb[i].XColor["colordiffuse"].Color);
					xwriter.WriteElementString ("spinColor",xb[i].XColor["spinColor"].Color);
					xwriter.WriteElementString ("onleft",Convert.ToString(xb[i].Left));
					xwriter.WriteElementString ("onright",Convert.ToString(xb[i].Right));
					xwriter.WriteElementString ("onup",Convert.ToString(xb[i].Up));
					xwriter.WriteElementString ("ondown",Convert.ToString(xb[i].Up));
					xwriter.WriteElementString ("suffix",Convert.ToString(xb[i].Suffix));
					xwriter.WriteElementString ("itemWidth",Convert.ToString(xb[i].ItemWidth));
					xwriter.WriteElementString ("itemHeight",Convert.ToString(xb[i].ItemHeight));
					xwriter.WriteElementString ("textureWidth",Convert.ToString(xb[i].TextureWidth));
					xwriter.WriteElementString ("textureHeight",Convert.ToString(xb[i].TextureHeight));
					xwriter.WriteElementString ("thumbWidth",Convert.ToString(xb[i].ThumbWidth));
					xwriter.WriteElementString ("thumbHeight",Convert.ToString(xb[i].ThumbHeight));
					xwriter.WriteElementString ("thumbPosX",Convert.ToString(xb[i].ThumbPosX));
					xwriter.WriteElementString ("thumbPosY",Convert.ToString(xb[i].ThumbPosY));
					xwriter.WriteElementString ("textureWidthBig",Convert.ToString(xb[i].TextureWidthBig));
					xwriter.WriteElementString ("textureHeightBig ",Convert.ToString(xb[i].TextureHeightBig));
					xwriter.WriteElementString ("itemWidthBig",Convert.ToString(xb[i].ItemWidthBig));
					xwriter.WriteElementString ("itemHeightBig",Convert.ToString(xb[i].ItemHeightBig));
					xwriter.WriteElementString ("thumbWidthBig",Convert.ToString(xb[i].ThumbWidthBig));
					xwriter.WriteElementString ("thumbHeightBig",Convert.ToString(xb[i].ThumbHeightBig));
					xwriter.WriteElementString ("thumbPosXBig",Convert.ToString(xb[i].ThumbPosXBig));
					xwriter.WriteElementString ("thumbPosYBig ",Convert.ToString(xb[i].ThumbPosYBig));
					xwriter.WriteEndElement();

					for (int j = 0; j < xb[i].Picture.Count; j++)
					{
						if (xb[i].Picture[j].Path == projectpath + @"media\" + Path.GetFileName(xb[i].Picture[j].Path))
						{}
						else
						{
							try{File.Copy(xb[i].Picture[j].Path,projectpath + @"Media\" + Path.GetFileName(xb[i].Picture[j].Path),true);}
							catch(System.IO.IOException){return(false);}
						}
					}
				}	
			}
			return (true);
		}

		private Boolean AddFadeLabel(XFadeLabelCollection xl, XmlTextWriter xwriter, String projectpath)
		{
			for (int i = 0 ; i < xl.Count; i++)
			{
				if (xl[i].Save)
				{
					xwriter.WriteStartElement ("control");
					xwriter.WriteElementString ("description",xl[i].Description);
					xwriter.WriteElementString ("type","fadelabel");
					xwriter.WriteElementString ("id",Convert.ToString(xl[i].ID));
					xwriter.WriteElementString ("posX",Convert.ToString(xl[i].Xpos));
					xwriter.WriteElementString ("posY",Convert.ToString(xl[i].Ypos));
					xwriter.WriteElementString ("width",Convert.ToString(xl[i].XWidth));
					xwriter.WriteElementString ("align",Convert.ToString(xl[i].Align));
					xwriter.WriteElementString ("label", getLabel.GetValueFromLabel(xl[i].Labeltext));
					xwriter.WriteElementString ("font",xl[i].Font);
					xwriter.WriteElementString ("textcolor",xl[i].XColor["textcolor"].Color);
					xwriter.WriteElementString ("disabledcolor",xl[i].XColor["disabledcolor"].Color);
					xwriter.WriteElementString ("textOffsetX",Convert.ToString(xl[i].XOffset));
					xwriter.WriteElementString ("textOffsetY",Convert.ToString(xl[i].YOffset));

					xwriter.WriteEndElement();
				}	
			}
			return (true);
		}

		

		private Boolean AddSpincontrol(XSpinControlCollection xb, XmlTextWriter xwriter, String projectpath)
		{
			for (int i = 0 ; i < xb.Count; i++)
			{
				if (xb[i].Save)
				{
					xwriter.WriteStartElement ("control");
					xwriter.WriteElementString ("description",xb[i].Description);
					xwriter.WriteElementString ("type","spincontrol");
					xwriter.WriteElementString ("id",Convert.ToString(xb[i].ID));
					xwriter.WriteElementString ("posX",Convert.ToString(xb[i].Xpos));
					xwriter.WriteElementString ("posY",Convert.ToString(xb[i].Ypos));
					xwriter.WriteElementString ("width",Convert.ToString(xb[i].XWidth));
					xwriter.WriteElementString ("height",Convert.ToString(xb[i].YHieght));
		
					xwriter.WriteElementString ("font",xb[i].Font);
					
					xwriter.WriteElementString ("textureUp",Path.GetFileName(xb[i].Picture["textureUp"].Path));
					xwriter.WriteElementString ("textureDown",Path.GetFileName(xb[i].Picture["textureDown"].Path));
					xwriter.WriteElementString ("textureUpFocus",Path.GetFileName(xb[i].Picture["textureUpFocus"].Path));
					xwriter.WriteElementString ("textureDownFocus",Path.GetFileName(xb[i].Picture["textureDownFocus"].Path));
					xwriter.WriteElementString ("textcolor",xb[i].XColor["textcolor"].Color);
					xwriter.WriteElementString ("disabledcolor",xb[i].XColor["disabledcolor"].Color);
					xwriter.WriteElementString ("onleft",Convert.ToString(xb[i].Left));
					xwriter.WriteElementString ("onright",Convert.ToString(xb[i].Right));
					xwriter.WriteElementString ("onup",Convert.ToString(xb[i].Up));
					xwriter.WriteElementString ("ondown",Convert.ToString(xb[i].Up));
					xwriter.WriteElementString ("align",Convert.ToString(xb[i].Align));
					xwriter.WriteElementString ("reverse", (getLabel.GetValueFromLabel(xb[i].Reverse)) == "true" ? "yes" : "no");
					xwriter.WriteElementString ("subtype",Convert.ToString(xb[i].Subtype));
					xwriter.WriteElementString ("textOffsetX",Convert.ToString(xb[i].XOffset));
					xwriter.WriteElementString ("textOffsetY",Convert.ToString(xb[i].YOffset));
					xwriter.WriteEndElement();

					for (int j = 0; j < xb[i].Picture.Count; j++)
					{
						if (xb[i].Picture[j].Path == projectpath + @"media\" + Path.GetFileName(xb[i].Picture[j].Path))
						{}
						else
						{
							try{File.Copy(xb[i].Picture[j].Path,projectpath + @"Media\" + Path.GetFileName(xb[i].Picture[j].Path),true);}
							catch(System.IO.IOException){return(false);}
						}
					}
				}
			}	
			return (true);
		}

		private Boolean AddMark(XmarkCollection xb, XmlTextWriter xwriter, String projectpath)
		{
			for (int i = 0 ; i < xb.Count; i++)
			{
				if (xb[i].Save)
				{
					xwriter.WriteStartElement ("control");
					xwriter.WriteElementString ("description",xb[i].Description);
					xwriter.WriteElementString ("type","checkmark");
					xwriter.WriteElementString ("id",Convert.ToString(xb[i].ID));
					xwriter.WriteElementString ("posX",Convert.ToString(xb[i].Xpos));
					xwriter.WriteElementString ("posY",Convert.ToString(xb[i].Ypos));
					xwriter.WriteElementString ("MarkWidth",Convert.ToString(xb[i].Picture["textureCheckmark"].Picwidth));
					xwriter.WriteElementString ("MarkHeight",Convert.ToString(xb[i].Picture["textureCheckmark"].Pichieght));;
					xwriter.WriteElementString ("label", getLabel.GetValueFromLabel(xb[i].Labeltext));
					xwriter.WriteElementString ("reverse", (getLabel.GetValueFromLabel(xb[i].Reverse)) == "true" ? "yes" : "no");
					xwriter.WriteElementString ("font",xb[i].Font);
					xwriter.WriteElementString ("align",Convert.ToString(xb[i].Align));
					xwriter.WriteElementString ("textureCheckmark",Path.GetFileName(xb[i].Picture["textureCheckmark"].Path));
					xwriter.WriteElementString ("textureCheckmarkNoFocus",Path.GetFileName(xb[i].Picture["textureCheckmarkNoFocus"].Path));
					xwriter.WriteElementString ("textcolor",xb[i].XColor["textcolor"].Color);
					xwriter.WriteElementString ("disabledcolor",xb[i].XColor["disabledcolor"].Color);
					xwriter.WriteElementString ("onleft",Convert.ToString(xb[i].Left));
					xwriter.WriteElementString ("onright",Convert.ToString(xb[i].Right));
					xwriter.WriteElementString ("onup",Convert.ToString(xb[i].Up));
					xwriter.WriteElementString ("ondown",Convert.ToString(xb[i].Up));
					xwriter.WriteElementString ("textOffsetX",Convert.ToString(xb[i].XOffset));
					xwriter.WriteElementString ("textOffsetY",Convert.ToString(xb[i].YOffset));
					xwriter.WriteEndElement();

					for (int j = 0; j < xb[i].Picture.Count; j++)
					{
						if (xb[i].Picture[j].Path == projectpath + @"media\" + Path.GetFileName(xb[i].Picture[j].Path))
						{}
						else
						{
							try{File.Copy(xb[i].Picture[j].Path,projectpath + @"Media\" + Path.GetFileName(xb[i].Picture[j].Path),true);}
							catch(System.IO.IOException){return(false);}
						}
					}
				}
			}	
			return (true);
		}

		


		private Boolean AddSelectButton(XSelectButtonCollection xb, XmlTextWriter xwriter, String projectpath)
		{
			for (int i = 0 ; i < xb.Count; i++)
			{
				if (xb[i].Save)
				{
					xwriter.WriteStartElement ("control");
					xwriter.WriteElementString ("description",xb[i].Description);
					xwriter.WriteElementString ("type","selectbutton");
					xwriter.WriteElementString ("id",Convert.ToString(xb[i].ID));
					xwriter.WriteElementString ("posX",Convert.ToString(xb[i].Xpos));
					xwriter.WriteElementString ("posY",Convert.ToString(xb[i].Ypos));
					xwriter.WriteElementString ("width",Convert.ToString(xb[i].XWidth));
					xwriter.WriteElementString ("height",Convert.ToString(xb[i].YHieght));
					xwriter.WriteElementString ("label", getLabel.GetValueFromLabel(xb[i].Labeltext));
					xwriter.WriteElementString ("font",xb[i].Font);
					xwriter.WriteElementString ("align",Convert.ToString(xb[i].Align));
					xwriter.WriteElementString ("textureFocus",Path.GetFileName(xb[i].Picture["textureFocus"].Path));
					xwriter.WriteElementString ("textureNoFocus",Path.GetFileName(xb[i].Picture["textureNoFocus"].Path));
					xwriter.WriteElementString ("textureLeft",Path.GetFileName(xb[i].Picture["textureLeft"].Path));
					xwriter.WriteElementString ("textureLeftFocus",Path.GetFileName(xb[i].Picture["textureLeftFocus"].Path));
					xwriter.WriteElementString ("textureRight",Path.GetFileName(xb[i].Picture["textureRight"].Path));
					xwriter.WriteElementString ("textureRightFocus",Path.GetFileName(xb[i].Picture["textureRightFocus"].Path));
					xwriter.WriteElementString ("colordiffuse",xb[i].XColor["colordiffuse"].Color);
					xwriter.WriteElementString ("textcolor",xb[i].XColor["textcolor"].Color);
					xwriter.WriteElementString ("disabledcolor",xb[i].XColor["disabledcolor"].Color);
					xwriter.WriteElementString ("onleft",Convert.ToString(xb[i].Left));
					xwriter.WriteElementString ("onright",Convert.ToString(xb[i].Right));
					xwriter.WriteElementString ("onup",Convert.ToString(xb[i].Up));
					xwriter.WriteElementString ("ondown",Convert.ToString(xb[i].Up));
					xwriter.WriteElementString ("textOffsetX",Convert.ToString(xb[i].XOffset));
					xwriter.WriteElementString ("textOffsetY",Convert.ToString(xb[i].YOffset));
					xwriter.WriteEndElement();

					for (int j = 0; j < xb[i].Picture.Count; j++)
					{
						if (xb[i].Picture[j].Path == projectpath + @"media\" + Path.GetFileName(xb[i].Picture[j].Path))
						{}
						else
						{
							try{File.Copy(xb[i].Picture[j].Path,projectpath + @"Media\" + Path.GetFileName(xb[i].Picture[j].Path),true);}
							catch(System.IO.IOException){return(false);}
						}
					}
				}

			}	
			return (true);
		}

		private Boolean AddRadio(XRadioCollection xb, XmlTextWriter xwriter, String projectpath)
		{
			for (int i = 0 ; i < xb.Count; i++)
			{
				if (xb[i].Save)
				{
					xwriter.WriteStartElement ("control");
					xwriter.WriteElementString ("description",xb[i].Description);
					xwriter.WriteElementString ("type","radiobutton");
					xwriter.WriteElementString ("id",Convert.ToString(xb[i].ID));
					xwriter.WriteElementString ("posX",Convert.ToString(xb[i].Xpos));
					xwriter.WriteElementString ("posY",Convert.ToString(xb[i].Ypos));
					xwriter.WriteElementString ("width",Convert.ToString(xb[i].XWidth));
					xwriter.WriteElementString ("height",Convert.ToString(xb[i].YHieght));;
					xwriter.WriteElementString ("label", getLabel.GetValueFromLabel(xb[i].Labeltext));
					xwriter.WriteElementString ("font",xb[i].Font);
					xwriter.WriteElementString ("textureRadioFocus",Path.GetFileName(xb[i].Picture["textureRadioFocus"].Path));
					xwriter.WriteElementString ("textureRadioNoFocus",Path.GetFileName(xb[i].Picture["textureRadioNoFocus"].Path));
					xwriter.WriteElementString ("textureFocus",Path.GetFileName(xb[i].Picture["textureFocus"].Path));
					xwriter.WriteElementString ("textureNoFocus",Path.GetFileName(xb[i].Picture["textureNoFocus"].Path));
					xwriter.WriteElementString ("textcolor",xb[i].XColor["textcolor"].Color);
					xwriter.WriteElementString ("disabledcolor",xb[i].XColor["disabledcolor"].Color);
					//xwriter.WriteElementString ("colordiffuse",xb[i].XColor["colordiffuse"].Color);
					xwriter.WriteElementString ("align",Convert.ToString(xb[i].Align));
					xwriter.WriteElementString ("onleft",Convert.ToString(xb[i].Left));
					xwriter.WriteElementString ("onright",Convert.ToString(xb[i].Right));
					xwriter.WriteElementString ("onup",Convert.ToString(xb[i].Up));
					xwriter.WriteElementString ("ondown",Convert.ToString(xb[i].Up));
					xwriter.WriteElementString ("textOffsetX",Convert.ToString(xb[i].XOffset));
					xwriter.WriteElementString ("textOffsetY",Convert.ToString(xb[i].YOffset));
					xwriter.WriteEndElement();

					for (int j = 0; j < xb[i].Picture.Count; j++)
					{
						if (xb[i].Picture[j].Path == projectpath + @"media\" + Path.GetFileName(xb[i].Picture[j].Path))
						{}
						else
						{
							try{File.Copy(xb[i].Picture[j].Path,projectpath + @"Media\" + Path.GetFileName(xb[i].Picture[j].Path),true);}
							catch(System.IO.IOException){return(false);}
						}
					}
				}
			}
			return (true);
		}

	}
}
