
using System;
using System.Data;
using System.Xml;
using System.Drawing;
using System.IO;

namespace XForm.Data
{
	/// <summary>
	/// Summary description for XMLLoad.
	/// </summary>
	public class XMLLoad
	{
		public XMLLoad()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private String GetValue (DataRow drLabels, String property)
		{
			if (drLabels[property] != null)
			{
				String ret;

				ret = drLabels[property].ToString();

				return (ret);
			}
			else
			{
				return ("-");
			}
		}

		public Boolean LoadSkin(Skin skin, String path, String apppath, String mediapath)
		{	

			GetLabel getlabel = new GetLabel();
			getlabel.Path = apppath;

			ColorBreak colorBreak = new ColorBreak();

			DataSet dsOpenXML = new DataSet("window");

			dsOpenXML.ReadXml(path);

			Int32 j = dsOpenXML.Tables[2].Rows.Count;

			skin.Name = Path.GetFileNameWithoutExtension(path);
			skin.Path = Path.GetDirectoryName(path) + @"\";
			skin.ID = Convert.ToInt32(dsOpenXML.Tables[0].Rows[0][0].ToString());
			skin.Control = Convert.ToInt32(dsOpenXML.Tables[0].Rows[0][1].ToString());

			for (Int32 i = 0; i < j; i++)
			{
				DataRow	drLabels = dsOpenXML.Tables[2].Rows[i];

				if (this.GetValue(drLabels, "description") == "BackGround Image")
				{
					Picture picture = new Picture();
					picture.Path = mediapath + drLabels["texture"];
					picture.Picwidth = this.GetValue(drLabels, "width");
					picture.Pichieght = this.GetValue(drLabels, "height");
					picture.Picxpos = this.GetValue(drLabels, "posX");
					picture.Picypos = this.GetValue(drLabels, "posY");

					skin.Picture.Add("BG-Picture", picture);
				}

				switch (this.GetValue(drLabels, "type"))
				{
					case "button":
					{
						XButton xb = new XButton();

						xb.Save = true;

						xb.Save = true;
						xb.ID = this.GetValue(drLabels, "id");
						xb.XOffset = this.GetValue(drLabels, "textOffsetX");
						xb.YOffset = this.GetValue(drLabels, "textOffsetY");


						xb.Xpos = this.GetValue(drLabels, "posX");
						xb.Ypos = this.GetValue(drLabels, "posY");
						xb.XWidth = this.GetValue(drLabels, "width");
						xb.YHieght = this.GetValue(drLabels, "height");

						if (drLabels["textureFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureFocus"];
							xb.Picture.Add("textureFocus",p);
						}

						if (drLabels["textureNoFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureNoFocus"];
							xb.Picture.Add("textureNoFocus",p);
						}

						xb.Font = this.GetValue(drLabels, "font");
						
						
						String Label = Convert.ToString(drLabels["label"].ToString() == "-" ? "9999" : drLabels["label"]);

						xb.Labeltext = getlabel.GetLabelFromValue(Convert.ToInt32(Label),path);

						xb.Description = this.GetValue(drLabels, "description");

						xb.Up = this.GetValue(drLabels, "onup");
						xb.Down = this.GetValue(drLabels, "ondown");
						xb.Left = this.GetValue(drLabels, "onleft");
						xb.Right = this.GetValue(drLabels, "onright");
						xb.Hyperlink = this.GetValue(drLabels, "hyperlink");

						XColor xc1 = new XColor();
						xb.XColor.Add("textcolor", colorBreak.BreakColor(xc1, this.GetValue(drLabels, "textcolor")));
						xb.XColor.Add("colordiffuse", colorBreak.BreakColor(xc1, this.GetValue(drLabels, "colordiffuse")));
						xb.XColor.Add("disabledcolor", colorBreak.BreakColor(xc1, this.GetValue(drLabels, "disabledcolor")));

						skin.XButtons.Add("button",xb);

						break;
					}

					case "image":
					{
						if (this.GetValue(drLabels, "description") != "BackGround Image")
						{
							XImage xb = new XImage();

							xb.Save = true;

							xb.ID = this.GetValue(drLabels, "id");

							xb.Xpos = this.GetValue(drLabels, "posX");
							xb.Ypos = this.GetValue(drLabels, "posY");
							xb.XWidth = this.GetValue(drLabels, "width");
							xb.YHieght = this.GetValue(drLabels, "height");

							if (drLabels["texture"] !=null)
							{
								Picture p = new Picture();
								p.Path = mediapath + drLabels["texture"];
								xb.Picture.Add("texture",p);
							}

							xb.Description = this.GetValue(drLabels, "description");

							XColor xc1 = new XColor();
							xb.XColor.Add("colorkey", colorBreak.BreakColor(xc1, this.GetValue(drLabels, "colorkey")));
							XColor xc2 = new XColor();
							xb.XColor.Add("colordiffuse", colorBreak.BreakColor(xc2, this.GetValue(drLabels, "colordiffuse")));

							skin.XImage.Add("image",xb);
						}
						break;
					}

					case "label":
					{
						XLabel xb = new XLabel();

						xb.Save = true;

						xb.ID = this.GetValue(drLabels, "id");
						xb.XOffset = this.GetValue(drLabels, "textOffsetX");
						xb.YOffset = this.GetValue(drLabels, "textOffsetY");

						xb.Xpos = this.GetValue(drLabels, "posX");
						xb.Ypos = this.GetValue(drLabels, "posY");
						xb.XWidth = this.GetValue(drLabels, "width");
				

						xb.Font = this.GetValue(drLabels, "font");
						
						String Label = Convert.ToString(drLabels["label"].ToString() == "-" ? "9999" : drLabels["label"]);

						xb.Labeltext = getlabel.GetLabelFromValue(Convert.ToInt32(Label),path);

						xb.Description = this.GetValue(drLabels, "description");
			
						XColor xc1 = new XColor();
						xb.XColor.Add("textcolor", colorBreak.BreakColor(xc1, this.GetValue(drLabels, "textcolor")));
						XColor xc2 = new XColor();
						xb.XColor.Add("disabledcolor", colorBreak.BreakColor(xc2, this.GetValue(drLabels, "disabledcolor")));

						skin.XLabel.Add("label",xb);

						break;
					}

					
					case "listcontrol":
					{
						XListControl xb = new XListControl();

						xb.Save = true;

						xb.ID = this.GetValue(drLabels, "id");
//						xb.XOffset = this.GetValue(drLabels, "textOffsetX");
//						xb.YOffset = this.GetValue(drLabels, "textOffsetY");

						
						xb.Up = this.GetValue(drLabels, "onup");
						xb.Down = this.GetValue(drLabels, "ondown");
						xb.Left = this.GetValue(drLabels, "onleft");
						xb.Right = this.GetValue(drLabels, "onright");

						xb.Xpos = this.GetValue(drLabels, "posX");
						xb.Ypos = this.GetValue(drLabels, "posY");
						xb.XWidth = this.GetValue(drLabels, "width");
						xb.YHieght = this.GetValue(drLabels, "height");

						if (drLabels["textureUp"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureUp"];
							p.Pichieght = this.GetValue(drLabels, "spinHeight");
							p.Picwidth = this.GetValue(drLabels, "spinWidth");
							p.Picxpos = this.GetValue(drLabels, "spinPosX");
							p.Picypos = this.GetValue(drLabels, "spinPosY");
							xb.Picture.Add("textureUp",p);
						}

						if (drLabels["textureDown"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureDown"];
							xb.Picture.Add("textureDown",p);
						}

						if (drLabels["textureUpFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureUpFocus"];
							xb.Picture.Add("textureUpFocus",p);
						}

						if (drLabels["textureDownFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureDownFocus"];
							xb.Picture.Add("textureNoFocus",p);
						}

						if (drLabels["image"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["image"];
							xb.Picture.Add("image",p);
						}

						if (drLabels["textureFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureFocus"];
							p.Pichieght = this.GetValue(drLabels, "textureHeight");
							xb.Picture.Add("textureFocus",p);
							
						}

						if (drLabels["textureNoFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureNoFocus"];
							xb.Picture.Add("textureNoFocus",p);
						}

						xb.Font = this.GetValue(drLabels, "font");

						xb.Description = this.GetValue(drLabels, "description");

						XColor xc1 = new XColor();
						xb.XColor.Add("textcolor", colorBreak.BreakColor(xc1, this.GetValue(drLabels, "textcolor")));
						XColor xc2 = new XColor();
						xb.XColor.Add("colordiffuse", colorBreak.BreakColor(xc2, this.GetValue(drLabels, "colordiffuse")));
						XColor xc3 = new XColor();
						xb.XColor.Add("selectedColor", colorBreak.BreakColor(xc3, this.GetValue(drLabels, "selectedColor")));
						XColor xc4 = new XColor();
						xb.XColor.Add("spinColor", colorBreak.BreakColor(xc4, this.GetValue(drLabels, "spinColor")));

						//xb.Suffix = this.GetValue(drLabels, "suffix");

						skin.XListControl.Add("listcontrol",xb);

						break;
					}

					case "rss":
					{
						XRss xb = new XRss();

						xb.Save = true;

						xb.ID = this.GetValue(drLabels, "id");
						xb.XOffset = this.GetValue(drLabels, "textOffsetX");
						xb.YOffset = this.GetValue(drLabels, "textOffsetY");


						xb.Xpos = this.GetValue(drLabels, "posX");
						xb.Ypos = this.GetValue(drLabels, "posY");
						xb.XWidth = this.GetValue(drLabels, "width");

						xb.Font = this.GetValue(drLabels, "font");

						xb.Description = this.GetValue(drLabels, "description");

						xb.Feed = this.GetValue(drLabels, "feed");

						XColor xc1 = new XColor();
						xb.XColor.Add("textcolor", colorBreak.BreakColor(xc1, this.GetValue(drLabels, "textcolor")));
						XColor xc2 = new XColor();
						xb.XColor.Add("titlecolor", colorBreak.BreakColor(xc2, this.GetValue(drLabels, "titlecolor")));
						XColor xc3 = new XColor();
						xb.XColor.Add("headlinecolor", colorBreak.BreakColor(xc3, this.GetValue(drLabels, "headlinecolor")));

						//xb.Suffix = this.GetValue(drLabels, "suffix");

						skin.XRss.Add("rss",xb);

						break;
					}

					

					case "thumbnailpanel":
					{
						Xthumbnail xb = new Xthumbnail();

						xb.Save = true;

						xb.ID = this.GetValue(drLabels, "id");
						
						xb.Up = this.GetValue(drLabels, "onup");
						xb.Down = this.GetValue(drLabels, "ondown");
						xb.Left = this.GetValue(drLabels, "onleft");
						xb.Right = this.GetValue(drLabels, "onright");

						xb.Xpos = this.GetValue(drLabels, "posX");
						xb.Ypos = this.GetValue(drLabels, "posY");
						xb.XWidth = this.GetValue(drLabels, "width");
						xb.YHieght = this.GetValue(drLabels, "height");

						if (drLabels["textureUp"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + this.GetValue(drLabels, "textureUp");
							p.Pichieght = this.GetValue(drLabels, "spinHeight");
							p.Picwidth = this.GetValue(drLabels, "spinWidth");
							p.Picxpos = this.GetValue(drLabels, "spinPosX");
							p.Picypos = this.GetValue(drLabels, "spinPosY");
							xb.Picture.Add("textureUp",p);
						}

						if (drLabels["textureDown"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureDown"];
							xb.Picture.Add("textureDown",p);
						}

						if (drLabels["textureUpFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureUpFocus"];
							xb.Picture.Add("textureUpFocus",p);
						}

						if (drLabels["textureDownFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureDownFocus"];
							xb.Picture.Add("textureDownFocus",p);
						}

						if (drLabels["imageFolder"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["imageFolder"];
							xb.Picture.Add("imageFolder",p);
						}

						if (drLabels["imageFolderFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["imageFolderFocus"];
							xb.Picture.Add("imageFolderFocus",p);
						}

						xb.Font = this.GetValue(drLabels, "font");

						xb.Description = this.GetValue(drLabels, "description");

						XColor xc1 = new XColor();
						xb.XColor.Add("textcolor", colorBreak.BreakColor(xc1, this.GetValue(drLabels, "textcolor")));
						XColor xc2 = new XColor();
						xb.XColor.Add("colordiffuse", colorBreak.BreakColor(xc2, this.GetValue(drLabels, "colordiffuse")));
						XColor xc3 = new XColor();
						xb.XColor.Add("selectedColor", colorBreak.BreakColor(xc3, this.GetValue(drLabels, "selectedColor")));
						XColor xc4 = new XColor();
						xb.XColor.Add("spinColor", colorBreak.BreakColor(xc4, this.GetValue(drLabels, "spinColor")));

						xb.ItemWidth = this.GetValue(drLabels, "itemWidth");
						xb.ItemHeight = this.GetValue(drLabels, "itemHeight");
						xb.TextureWidth = this.GetValue(drLabels, "textureWidth");
						xb.TextureHeight = this.GetValue(drLabels, "textureHeight");
						xb.ThumbWidth = this.GetValue(drLabels, "thumbWidth");
						xb.ThumbHeight = this.GetValue(drLabels, "thumbHeight");
						xb.ThumbPosX = this.GetValue(drLabels, "thumbPosX");
						xb.ThumbPosY = this.GetValue(drLabels, "thumbPosY");

						xb.TextureWidthBig = this.GetValue(drLabels, "textureWidthBig");
						xb.TextureHeightBig = this.GetValue(drLabels, "textureHeightBig");
						xb.ItemWidthBig = this.GetValue(drLabels, "itemWidthBig");
						xb.ItemHeightBig = this.GetValue(drLabels, "itemHeightBig");
						xb.ThumbWidthBig = this.GetValue(drLabels, "thumbWidthBig");
						xb.ThumbHeightBig = this.GetValue(drLabels, "thumbHeightBig");
						xb.ThumbPosXBig = this.GetValue(drLabels, "thumbPosXBig");
						xb.ThumbPosYBig = this.GetValue(drLabels, "thumbPosYBig");
						//xb.Suffix = this.GetValue(drLabels, "suffix");

						skin.XThumbnail.Add("thumbnail",xb);

						break;
					}

					case "fadelabel":
					{
						XFadeLabel xb = new XFadeLabel();

						xb.Save = true;

						xb.ID = this.GetValue(drLabels, "id");
						xb.XOffset = this.GetValue(drLabels, "textOffsetX");
						xb.YOffset = this.GetValue(drLabels, "textOffsetY");


						xb.Xpos = this.GetValue(drLabels, "posX");
						xb.Ypos = this.GetValue(drLabels, "posY");
						xb.XWidth = this.GetValue(drLabels, "width");

						xb.Font = this.GetValue(drLabels, "font");

						String Label = Convert.ToString(drLabels["label"].ToString() == "-" ? "9999" : drLabels["label"]);

						xb.Labeltext = getlabel.GetLabelFromValue(Convert.ToInt32(Label),path);
						xb.Align = this.GetValue(drLabels, "align");
						xb.Description = this.GetValue(drLabels, "description");

						XColor xc1 = new XColor();
						xb.XColor.Add("textcolor", colorBreak.BreakColor(xc1, this.GetValue(drLabels, "textcolor")));
						XColor xc2 = new XColor();
						xb.XColor.Add("disabledcolor", colorBreak.BreakColor(xc2, this.GetValue(drLabels, "disabledcolor")));

						skin.XFadeLabel.Add("fadelabel",xb);

						break;
					}

					case "spincontrol":
					{
						XSpinControl xb = new XSpinControl();

						xb.Save = true;

						xb.ID = this.GetValue(drLabels, "id");
						xb.XOffset = this.GetValue(drLabels, "textOffsetX");
						xb.YOffset = this.GetValue(drLabels, "textOffsetY");

						xb.Xpos = this.GetValue(drLabels, "posX");
						xb.Ypos = this.GetValue(drLabels, "posY");
						xb.XWidth = this.GetValue(drLabels, "width");
						xb.YHieght = this.GetValue(drLabels, "height");

						
						xb.Up = this.GetValue(drLabels, "onup");
						xb.Down = this.GetValue(drLabels, "ondown");
						xb.Left = this.GetValue(drLabels, "onleft");
						xb.Right = this.GetValue(drLabels, "onright");

						xb.Font = this.GetValue(drLabels, "font");
						

						if (drLabels["textureDownFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureDownFocus"];
							xb.Picture.Add("textureDownFocus",p);
						}

						if (drLabels["textureUp"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + this.GetValue(drLabels, "textureUp");
							p.Pichieght = Convert.ToString(Image.FromFile(p.Path).Height);
							p.Picwidth = Convert.ToString(Image.FromFile(p.Path).Width);
							xb.Picture.Add("textureUp",p);
						}

						if (drLabels["textureDown"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureDown"];
							xb.Picture.Add("textureDown",p);
						}

						if (drLabels["textureUpFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureUpFocus"];
							xb.Picture.Add("textureUpFocus",p);
						}

						xb.Description = this.GetValue(drLabels, "description");
						xb.Align = this.GetValue(drLabels, "align");
						xb.Subtype = this.GetValue(drLabels, "subtype");
						xb.Reverse = (this.GetValue(drLabels, "reverse") == "yes" ? "true" : "false");
						xb.XOffset = this.GetValue(drLabels, "textOffsetX");
						xb.YOffset = this.GetValue(drLabels, "textOffsetY");

						XColor xc1 = new XColor();
						xb.XColor.Add("textcolor", colorBreak.BreakColor(xc1, this.GetValue(drLabels, "textcolor")));
						XColor xc2 = new XColor();
						xb.XColor.Add("disabledcolor", colorBreak.BreakColor(xc2, this.GetValue(drLabels, "disabledcolor")));

						skin.XSpinControl.Add("spincontrol",xb);

						break;
					}

					case "checkmark":
					{
						Xmark xb = new Xmark();

						xb.Save = true;

						xb.ID = this.GetValue(drLabels, "id");
						xb.XOffset = this.GetValue(drLabels, "textOffsetX");
						xb.YOffset = this.GetValue(drLabels, "textOffsetY");

						
						xb.Up = this.GetValue(drLabels, "onup");
						xb.Down = this.GetValue(drLabels, "ondown");
						xb.Left = this.GetValue(drLabels, "onleft");
						xb.Right = this.GetValue(drLabels, "onright");

						xb.Xpos = this.GetValue(drLabels, "posX");
						xb.Ypos = this.GetValue(drLabels, "posY");
						xb.XWidth = this.GetValue(drLabels, "MarkWidth");
						xb.YHieght = this.GetValue(drLabels, "MarkHeight");

						xb.Font = this.GetValue(drLabels, "font");
						
						String Label = Convert.ToString(drLabels["label"].ToString() == "-" ? "9999" : drLabels["label"]);

						xb.Labeltext = getlabel.GetLabelFromValue(Convert.ToInt32(Label),path);

						if (drLabels["textureCheckmark"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureCheckmark"];
							xb.Picture.Add("textureCheckmark",p);
						}

						if (drLabels["textureCheckmarkNoFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + this.GetValue(drLabels, "textureCheckmarkNoFocus");
							p.Pichieght = this.GetValue(drLabels, "MarkHeight");
							p.Picwidth = this.GetValue(drLabels, "MarkWidth");
							xb.Picture.Add("textureCheckmarkNoFocus",p);
						}

						xb.Description = this.GetValue(drLabels, "description");
						xb.Align = this.GetValue(drLabels, "align");
						xb.XOffset = this.GetValue(drLabels, "textOffsetX");
						xb.Reverse = (this.GetValue(drLabels, "reverse") == "yes" ? "true" : "false");
						//xb.Shadow = this.GetValue(drLabels, "shadow");

						XColor xc1 = new XColor();
						xb.XColor.Add("textcolor", colorBreak.BreakColor(xc1, this.GetValue(drLabels, "textcolor")));
						XColor xc2 = new XColor();
						xb.XColor.Add("disabledcolor", colorBreak.BreakColor(xc2, this.GetValue(drLabels, "disabledcolor")));

						skin.Xmark.Add("checkmark",xb);

						break;
					}

					case "radiobutton":
					{
						XRadio xb = new XRadio();

						xb.Save = true;

						xb.ID = this.GetValue(drLabels, "id");
						xb.XOffset = this.GetValue(drLabels, "textOffsetX");
						xb.YOffset = this.GetValue(drLabels, "textOffsetY");

						xb.Font = this.GetValue(drLabels, "font");
						xb.Xpos = this.GetValue(drLabels, "posX");
						xb.Ypos = this.GetValue(drLabels, "posY");
						xb.XWidth = this.GetValue(drLabels, "width");
						xb.YHieght = this.GetValue(drLabels, "height");

						
						xb.Up = this.GetValue(drLabels, "onup");
						xb.Down = this.GetValue(drLabels, "ondown");
						xb.Left = this.GetValue(drLabels, "onleft");
						xb.Right = this.GetValue(drLabels, "onright");

						String Label = Convert.ToString(drLabels["label"].ToString() == "-" ? "9999" : drLabels["label"]);

						xb.Labeltext = getlabel.GetLabelFromValue(Convert.ToInt32(Label),path);

						if (drLabels["textureRadioFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureRadioFocus"];
							xb.Picture.Add("textureRadioFocus",p);
						}

						if (drLabels["textureRadioNoFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureRadioNoFocus"];
							xb.Picture.Add("textureRadioNoFocus",p);
						}

						if (drLabels["textureFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureFocus"];
							xb.Picture.Add("textureFocus",p);
						}

						if (drLabels["textureNoFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureNoFocus"];
							xb.Picture.Add("textureNoFocus",p);
						}

						xb.Description = this.GetValue(drLabels, "description");
						xb.Align = this.GetValue(drLabels, "align");
						//xb.Shadow = this.GetValue(drLabels, "shadow");

						XColor xc1 = new XColor();
						xb.XColor.Add("textcolor", colorBreak.BreakColor(xc1, this.GetValue(drLabels, "textcolor")));
						XColor xc2 = new XColor();
						xb.XColor.Add("disabledcolor", colorBreak.BreakColor(xc2, this.GetValue(drLabels, "disabledcolor")));

						skin.XRadio.Add("radiobutton",xb);

						break;
					}


					case "selectbutton":
					{
						XSelectButton xb = new XSelectButton();

						xb.Save = true;

						xb.ID = this.GetValue(drLabels, "id");
						xb.XOffset = this.GetValue(drLabels, "textOffsetX");
						xb.YOffset = this.GetValue(drLabels, "textOffsetY");

						xb.Xpos = this.GetValue(drLabels, "posX");
						xb.Ypos = this.GetValue(drLabels, "posY");
						xb.XWidth = this.GetValue(drLabels, "width");
						xb.YHieght = this.GetValue(drLabels, "height");

						xb.Align = this.GetValue(drLabels, "align");
						
						xb.Up = this.GetValue(drLabels, "onup");
						xb.Down = this.GetValue(drLabels, "ondown");
						xb.Left = this.GetValue(drLabels, "onleft");
						xb.Right = this.GetValue(drLabels, "onright");


						if (drLabels["textureFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureFocus"];
							xb.Picture.Add("textureFocus",p);
						}

						if (drLabels["textureNoFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureNoFocus"];
							xb.Picture.Add("textureNoFocus",p);
						}

						if (drLabels["textureLeft"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureLeft"];
							xb.Picture.Add("textureLeft",p);
						}

						if (drLabels["textureLeftFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureLeftFocus"];
							xb.Picture.Add("textureLeftFocus",p);
						}

						if (drLabels["textureRight"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureRight"];
							xb.Picture.Add("textureRight",p);
						}

						if (drLabels["textureRightFocus"] !=null)
						{
							Picture p = new Picture();
							p.Path = mediapath + drLabels["textureRightFocus"];
							xb.Picture.Add("textureRightFocus",p);
						}

						xb.Font = this.GetValue(drLabels, "font");

						String Label = Convert.ToString(drLabels["label"].ToString() == "-" ? "9999" : drLabels["label"]);

						xb.Labeltext = getlabel.GetLabelFromValue(Convert.ToInt32(Label),path);

						xb.Description = this.GetValue(drLabels, "description");

						XColor xc1 = new XColor();
						xb.XColor.Add("textcolor", colorBreak.BreakColor(xc1, this.GetValue(drLabels, "textcolor")));
						XColor xc2 = new XColor();
						xb.XColor.Add("disabledcolor", colorBreak.BreakColor(xc2, this.GetValue(drLabels, "disabledcolor")));
						XColor xc3 = new XColor();
						xb.XColor.Add("colordiffuse", colorBreak.BreakColor(xc3, this.GetValue(drLabels, "colordiffuse")));

						//xb.Suffix = this.GetValue(drLabels, "suffix");

						skin.XSelectButton.Add("selectbutton",xb);

						break;
					}

				}
			
			}
			dsOpenXML.Dispose();

			return (true);
		}
	}
}
