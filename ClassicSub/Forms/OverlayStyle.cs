using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassicSub.Code;

namespace ClassicSub.Forms
{
    public partial class OverlayStyle : Form
    {
        private Style currentStyle = null;

        public OverlayStyle()
        {
            InitializeComponent();

            currentStyle = new Style();
            string defaultStyle = GetDefaultStyle();
            if (defaultStyle != "")
            {
                currentStyle = Style.FromString(defaultStyle);
            }

            CurrentStyleToUI();

            EnableButtons();
        }

        private void EnableButtons()
        {
            buttonGradientColour.Enabled = checkBoxGradient.Checked;
            
            buttonOutline1Colour.Enabled = checkBoxOutline1.Checked;
            labelOutline1Width.Enabled = checkBoxOutline1.Checked;
            textBoxOutline1Width.Enabled = checkBoxOutline1.Checked;
            labelOutline1Alpha.Enabled = checkBoxOutline1.Checked;
            textBoxOutline1Alpha.Enabled = checkBoxOutline1.Checked;

            buttonOutline2Colour.Enabled = checkBoxOutline2.Checked;
            labelOutline2Width.Enabled = checkBoxOutline2.Checked;
            textBoxOutline2Width.Enabled = checkBoxOutline2.Checked;
            labelOutline2Alpha.Enabled = checkBoxOutline2.Checked;
            textBoxOutline2Alpha.Enabled = checkBoxOutline2.Checked;

            buttonShadowColour.Enabled = checkBoxShadow.Checked;
            labelShadowWidth.Enabled = checkBoxShadow.Checked;
            textBoxShadowWidth.Enabled = checkBoxShadow.Checked;
            labelShadowAlpha.Enabled = checkBoxShadow.Checked;
            textBoxShadowAlpha.Enabled = checkBoxShadow.Checked;
            labelShadowOffsetX.Enabled = checkBoxShadow.Checked;
            textBoxShadowOffsetX.Enabled = checkBoxShadow.Checked;
            labelShadowOffsetY.Enabled = checkBoxShadow.Checked;
            textBoxShadowOffsetY.Enabled = checkBoxShadow.Checked;
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
            }

            Refresh();
        }

        private void radioButtonAlignment_CheckedChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void textBoxMaxSize_TextChanged(object sender, EventArgs e)
        {
           Refresh();
        }

        private void textBoxMinSize_TextChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void buttonTextColour_Click(object sender, EventArgs e)
        {
            colorDialog.Color = buttonTextColour.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonTextColour.BackColor = colorDialog.Color;
                Refresh();
            }
        }

        private void checkBoxGradient_CheckedChanged(object sender, EventArgs e)
        {
            EnableButtons();
            Refresh();
        }

        private void buttonGradientColour_Click(object sender, EventArgs e)
        {
            colorDialog.Color = buttonGradientColour.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonGradientColour.BackColor = colorDialog.Color;
                Refresh();
            }
        }

        private void buttonBackColour_Click(object sender, EventArgs e)
        {
            colorDialog.Color = buttonBackColour.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonBackColour.BackColor = colorDialog.Color;
                Refresh();
            }
        }

        private void checkBoxOutline1_CheckedChanged(object sender, EventArgs e)
        {
            EnableButtons();
            Refresh();
        }

        private void buttonOutline1Colour_Click(object sender, EventArgs e)
        {
            colorDialog.Color = buttonOutline1Colour.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonOutline1Colour.BackColor = colorDialog.Color;
                Refresh();
            }
        }

        private void textBoxOutline1Width_TextChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void textBoxOutline1Alpha_TextChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void checkBoxOutline2_CheckedChanged(object sender, EventArgs e)
        {
            EnableButtons();
            Refresh();
        }

        private void textBoxOutline2Width_TextChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void textBoxOutline2Alpha_TextChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void checkBoxShadow_CheckedChanged(object sender, EventArgs e)
        {
            EnableButtons();
            Refresh();
        }

        private void textBoxShadowWidth_TextChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void textBoxShadowAlpha_TextChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void textBoxShadowOffsetX_TextChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void textBoxShadowOffsetY_TextChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void textBoxSampleText_TextChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        public static string GetDefaultStyle()
        {
            string val = ""; // default

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Overlay default style");

                if (obj != null)
                {
                    val = obj.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return val;
        }

        public static void SetDefaultStyle(string val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Overlay default style", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            UIToCurrentStyle();
            String defaultStyle = currentStyle.ToString();
            SetDefaultStyle(defaultStyle);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {            
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;

                FileInfo fi = new FileInfo(openFileDialog.FileName);

                if (fi.Exists)
                {
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader reader = new StreamReader(fs))
                        {
                            string currentStyleString = reader.ReadToEnd();

                            currentStyle = Style.FromString(currentStyleString);
                        }
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UIToCurrentStyle();
            String styleToSave = currentStyle.ToString();

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;

                FileInfo fi = new FileInfo(saveFileDialog.FileName);
                using (FileStream fs = fi.Create())
                {
                    using (StreamWriter writer = new StreamWriter(fs, new UTF8Encoding(true)))
                    {
                        writer.Write(styleToSave);
                    }
                }
            }
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            currentStyle = new Style();

            CurrentStyleToUI();
        }

        void UIToCurrentStyle()
        {
            currentStyle.BackColour = buttonBackColour.BackColor.ToArgb();
            currentStyle.TextColour = buttonTextColour.BackColor.ToArgb();

            if (radioButtonTextAlign1.Checked)
                currentStyle.TextAlignment = StringAlignment.Near;
            else if (radioButtonTextAlign2.Checked)
                currentStyle.TextAlignment = StringAlignment.Center;
            else
                currentStyle.TextAlignment = StringAlignment.Far;

            if (radioButtonAlignment1.Checked || radioButtonAlignment2.Checked || radioButtonAlignment3.Checked)
                currentStyle.VerticalAlignment = StringAlignment.Near;
            else if (radioButtonAlignment4.Checked || radioButtonAlignment5.Checked || radioButtonAlignment6.Checked)
                currentStyle.VerticalAlignment = StringAlignment.Center;
            else
                currentStyle.VerticalAlignment = StringAlignment.Far;

            if (radioButtonAlignment1.Checked || radioButtonAlignment4.Checked || radioButtonAlignment7.Checked)
                currentStyle.HorizontalAlignment = StringAlignment.Near;
            else if (radioButtonAlignment2.Checked || radioButtonAlignment5.Checked || radioButtonAlignment8.Checked)
                currentStyle.HorizontalAlignment = StringAlignment.Center;
            else
                currentStyle.HorizontalAlignment = StringAlignment.Far;

            currentStyle.MinTextSize = Convert.ToInt32(textBoxMinSize.Text);
            currentStyle.MaxTextSize = Convert.ToInt32(textBoxMaxSize.Text);

            currentStyle.GradientEnabled = checkBoxGradient.Checked;
            currentStyle.GradientColour = buttonGradientColour.BackColor.ToArgb();

            currentStyle.Outline1Enabled = checkBoxOutline1.Checked;
            currentStyle.Outline1Colour = buttonOutline1Colour.BackColor.ToArgb();
            currentStyle.Outline1Width = Convert.ToInt32(textBoxOutline1Width.Text);
            currentStyle.Outline1Alpha = Convert.ToInt32(textBoxOutline1Alpha.Text);

            currentStyle.Outline2Enabled = checkBoxOutline2.Checked;
            currentStyle.Outline2Colour = buttonOutline2Colour.BackColor.ToArgb();
            currentStyle.Outline2Width = Convert.ToInt32(textBoxOutline2Width.Text);
            currentStyle.Outline2Alpha = Convert.ToInt32(textBoxOutline2Alpha.Text);

            currentStyle.ShadowEnabled = checkBoxShadow.Checked;
            currentStyle.ShadowColour = buttonShadowColour.BackColor.ToArgb();
            currentStyle.ShadowWidth = Convert.ToInt32(textBoxShadowWidth.Text);
            currentStyle.ShadowAlpha = Convert.ToInt32(textBoxShadowAlpha.Text);
            currentStyle.ShadowOffsetX = Convert.ToInt32(textBoxShadowOffsetX.Text);
            currentStyle.ShadowOffsetY = Convert.ToInt32(textBoxShadowOffsetY.Text);

            currentStyle.SampleText = textBoxSampleText.Text;
        }

        void CurrentStyleToUI()
        {
            buttonBackColour.BackColor = Color.FromArgb(currentStyle.BackColour);
            buttonTextColour.BackColor = Color.FromArgb(currentStyle.TextColour);

            if (currentStyle.TextAlignment == StringAlignment.Near)
                radioButtonTextAlign1.Checked = true;
            else if (currentStyle.TextAlignment == StringAlignment.Center)
                radioButtonTextAlign2.Checked = true;
            else
                radioButtonTextAlign3.Checked = true;

            if (currentStyle.VerticalAlignment == StringAlignment.Near)
                if (currentStyle.HorizontalAlignment == StringAlignment.Near)
                    radioButtonAlignment1.Checked = true;
                else if (currentStyle.HorizontalAlignment == StringAlignment.Center)
                    radioButtonAlignment2.Checked = true;
                else
                    radioButtonAlignment3.Checked = true;
            else if (currentStyle.VerticalAlignment == StringAlignment.Center)
                if (currentStyle.HorizontalAlignment == StringAlignment.Near)
                    radioButtonAlignment4.Checked = true;
                else if (currentStyle.HorizontalAlignment == StringAlignment.Center)
                    radioButtonAlignment5.Checked = true;
                else
                    radioButtonAlignment6.Checked = true;
            else
                if (currentStyle.HorizontalAlignment == StringAlignment.Near)
                    radioButtonAlignment7.Checked = true;
                else if (currentStyle.HorizontalAlignment == StringAlignment.Center)
                    radioButtonAlignment8.Checked = true;
                else
                    radioButtonAlignment9.Checked = true;

            textBoxMinSize.Text = currentStyle.MinTextSize.ToString();
            textBoxMaxSize.Text = currentStyle.MaxTextSize.ToString();

            checkBoxGradient.Checked = currentStyle.GradientEnabled;
            buttonGradientColour.BackColor = Color.FromArgb(currentStyle.GradientColour);

            checkBoxOutline1.Checked = currentStyle.Outline1Enabled;
            buttonOutline1Colour.BackColor = Color.FromArgb(currentStyle.Outline1Colour);
            textBoxOutline1Width.Text = currentStyle.Outline1Width.ToString();
            textBoxOutline1Alpha.Text = currentStyle.Outline1Alpha.ToString();

            checkBoxOutline2.Checked = currentStyle.Outline2Enabled;
            buttonOutline2Colour.BackColor = Color.FromArgb(currentStyle.Outline2Colour);
            textBoxOutline2Width.Text = currentStyle.Outline2Width.ToString();
            textBoxOutline2Alpha.Text = currentStyle.Outline2Alpha.ToString();

            currentStyle.ShadowEnabled = checkBoxShadow.Checked;
            buttonShadowColour.BackColor = Color.FromArgb(currentStyle.ShadowColour);
            textBoxShadowWidth.Text = currentStyle.ShadowWidth.ToString();
            textBoxShadowAlpha.Text = currentStyle.ShadowAlpha.ToString();
            textBoxShadowOffsetX.Text = currentStyle.ShadowOffsetX.ToString();
            textBoxShadowOffsetY.Text = currentStyle.ShadowOffsetY.ToString();

            textBoxSampleText.Text = currentStyle.SampleText;
        }

    }
}
