using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ClassicSub.Code
{
    public class Style
    {
        public FontStyle TextFontStyle = FontStyle.Regular;
        public string TextFontFamily = "Arial";
        public int TextColour = Color.White.ToArgb();
        public int MinTextSize = 10;
        public int MaxTextSize = 30;

        public StringAlignment TextAlignment = StringAlignment.Near;
        public StringAlignment VerticalAlignment = StringAlignment.Near;
        public StringAlignment HorizontalAlignment = StringAlignment.Center;

        public int BackColour = Color.Black.ToArgb();

        public bool GradientEnabled = false;
        public int GradientColour = Color.Red.ToArgb();

        public bool Outline1Enabled = false;
        public int Outline1Colour = Color.Blue.ToArgb();
        public int Outline1Width = 2;
        public int Outline1Alpha = 200;

        public bool Outline2Enabled = false;
        public int Outline2Colour = Color.Green.ToArgb();
        public int Outline2Width = 4;
        public int Outline2Alpha = 100;

        public bool ShadowEnabled = false;
        public int ShadowColour = Color.Gray.ToArgb();
        public int ShadowWidth = 2;
        public int ShadowAlpha = 150;
        public int ShadowOffsetX = 5;
        public int ShadowOffsetY = 5;

        public string SampleText = "ClassicSub is Great!";

        override public string ToString()
        {
            string serializedXml = "";

            try
            {
                XmlSerializer s = new XmlSerializer(typeof(Style));
                StringWriter sw = new StringWriter();
                s.Serialize(sw, this);
                serializedXml = sw.ToString();
                sw.Close();
            }
            catch (Exception ex)
            {
                string message = String.Format("Cannot Serialize Style.\nException: {0}", ex.Message);
                MessageBox.Show(message);
            }

            return serializedXml;
        }

        static public Style FromString(string serializedXml)
        {
            Style style = new Style();

            try
            {
                XmlSerializer s = new XmlSerializer(typeof(Style));
                StringReader sr = new StringReader(serializedXml);
                style = (Style)s.Deserialize(sr);
                sr.Close();
            }
            catch (Exception ex)
            {
                string message = String.Format("Cannot Deserialize Style.\nException: {0}", ex.Message);
                MessageBox.Show(message);
            }

            return style;
        }
    }
}
