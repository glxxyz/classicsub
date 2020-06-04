using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassicSub.Forms
{
    public enum ScaleRange
    {
        Selected = 1,
        All = 2
    }

    public partial class ScaleForm : Form
    {
        public bool ClosedWithOK = false;
        public ScaleRange Range = ScaleRange.Selected;
        public int SubtitleAnchor = 0;
        public int MovieAnchor = 0;
        public double SubScale = 1;
        public bool RecalcDuration = false;

        private bool updating = false;

        public ScaleForm(int startTime, int endTime)
        {
            InitializeComponent();
            textBoxMovieFirstRef.Text = Subtitle.FormatHMSTime(startTime, false);
            textBoxSubFirstRef.Text = Subtitle.FormatHMSTime(startTime, false);
            textBoxMovieSecondRef.Text = Subtitle.FormatHMSTime(endTime, false);
            textBoxSubSecondRef.Text = Subtitle.FormatHMSTime(endTime, false);
        }

        private void textBoxSubFirstRef_TextChanged(object sender, EventArgs e)
        {
            if (updating)
            {
                return;
            }

            if (radioButtonSecondRef.Checked)
            {
                textBoxSubSecondRef_TextChanged(sender, e);
            }
            else if (radioButtonFPS.Checked)
            {
                textBoxSubFPS_TextChanged(sender, e);
            }
            else
            {
                textBoxSubRelative_TextChanged(sender, e);
            }
        }

        private void textBoxSubSecondRef_TextChanged(object sender, EventArgs e)
        {
            if (updating)
            {
                return;
            }

            updating = true;

            try
            {
                double subAnchor = ((Double)Subtitle.ParseHMSTime(textBoxSubFirstRef.Text)) / ((Double)1000.0);
                double movAnchor = ((Double)Subtitle.ParseHMSTime(textBoxMovieFirstRef.Text)) / ((Double)1000.0);

                double subAnchor2 = ((Double)Subtitle.ParseHMSTime(textBoxSubSecondRef.Text)) / ((Double)1000.0);
                double movAnchor2 = ((Double)Subtitle.ParseHMSTime(textBoxMovieSecondRef.Text)) / ((Double)1000.0);

                double scale = (movAnchor2 - movAnchor) / (subAnchor2 - subAnchor);

                double subFPS = Convert.ToDouble(textBoxSubFPS.Text);
                double movFPS = subFPS / scale;

                double subRel = Convert.ToDouble(textBoxSubRelative.Text);
                double movRel = subRel * scale;

                string movFPSText = String.Format("{0:0.0#######}", movFPS);
                string movRelText = String.Format("{0:0.0#######}", movRel);

                textBoxMovieFPS.Text = movFPSText;
                textBoxMovieRelative.Text = movRelText;

                SubScale = scale;

                okButton.Enabled = true;
            }
            catch
            {
                okButton.Enabled = false;
            }

            updating = false;
        }

        private void textBoxSubFPS_TextChanged(object sender, EventArgs e)
        {
            if (updating)
            {
                return;
            }

            updating = true;

            try
            {
                double subFPS = Convert.ToDouble(textBoxSubFPS.Text);
                double movieFPS = Convert.ToDouble(textBoxMovieFPS.Text);

                double scale = subFPS / movieFPS;

                double subAnchor = ((Double)Subtitle.ParseHMSTime(textBoxSubFirstRef.Text)) / ((Double)1000.0);
                double movAnchor = ((Double)Subtitle.ParseHMSTime(textBoxMovieFirstRef.Text)) / ((Double)1000.0);
                double subAnchor2 = ((Double)Subtitle.ParseHMSTime(textBoxSubSecondRef.Text)) / ((Double)1000.0);
                double movAnchor2 = scale * (subAnchor2 - subAnchor) + movAnchor;
                int movAnchor2Int = (Int32)(movAnchor2 * 1000.0 + 0.5);

                double subRel = Convert.ToDouble(textBoxSubRelative.Text);
                double movRel = subRel * scale;

                string movAnchorText = Subtitle.FormatHMSTime(movAnchor2Int, false);
                string movRelText = String.Format("{0:0.0#######}", movRel);

                textBoxMovieSecondRef.Text = movAnchorText;
                textBoxMovieRelative.Text = movRelText;

                SubScale = scale;

                okButton.Enabled = true;
            }
            catch
            {
                okButton.Enabled = false;
            }

            updating = false;
        }

        private void textBoxSubRelative_TextChanged(object sender, EventArgs e)
        {
            if (updating)
            {
                return;
            }

            updating = true;
            
            try
            {
                double subRel = Convert.ToDouble(textBoxSubRelative.Text);
                double movieRel = Convert.ToDouble(textBoxMovieRelative.Text);

                double scale = movieRel / subRel;

                double subAnchor = ((Double)Subtitle.ParseHMSTime(textBoxSubFirstRef.Text)) / ((Double)1000.0);
                double movAnchor = ((Double)Subtitle.ParseHMSTime(textBoxMovieFirstRef.Text)) / ((Double)1000.0);
                double subAnchor2 = ((Double)Subtitle.ParseHMSTime(textBoxSubSecondRef.Text)) / ((Double)1000.0);
                double movAnchor2 = scale * (subAnchor2 - subAnchor) + movAnchor;
                int movAnchor2Int = (Int32)(movAnchor2 * 1000.0);

                double subFPS = Convert.ToDouble(textBoxSubFPS.Text);
                double movFPS = subFPS / scale;

                string movAnchorText = Subtitle.FormatHMSTime(movAnchor2Int, false);
                string movFPSText = String.Format("{0:0.0#######}", movFPS);

                textBoxMovieSecondRef.Text = movAnchorText;
                textBoxMovieFPS.Text = movFPSText;

                SubScale = scale;

                okButton.Enabled = true;
            }
            catch
            {
                okButton.Enabled = false;
            }

            updating = false;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                ClosedWithOK = true;

                // Note: SubScale should be already updated

                if (radioButtonAll.Checked)
                {
                    Range = ScaleRange.All;
                }
                else
                {
                    Range = ScaleRange.Selected;
                }

                SubtitleAnchor = Subtitle.ParseHMSTime(textBoxSubFirstRef.Text);
                MovieAnchor = Subtitle.ParseHMSTime(textBoxMovieFirstRef.Text);

                RecalcDuration = false; // todo put this in a button

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButtonSecondRef_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSubSecondRef.Enabled = true;
            textBoxMovieSecondRef.Enabled = true;
            textBoxSubFPS.Enabled = false;
            textBoxMovieFPS.Enabled = false;
            textBoxSubRelative.Enabled = false;
            textBoxMovieRelative.Enabled = false;
        }

        private void radioButtonFPS_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSubSecondRef.Enabled = false;
            textBoxMovieSecondRef.Enabled = false;
            textBoxSubFPS.Enabled = true;
            textBoxMovieFPS.Enabled = true;
            textBoxSubRelative.Enabled = false;
            textBoxMovieRelative.Enabled = false;
        }

        private void radioButtonRelative_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSubSecondRef.Enabled = false;
            textBoxMovieSecondRef.Enabled = false;
            textBoxSubFPS.Enabled = false;
            textBoxMovieFPS.Enabled = false;
            textBoxSubRelative.Enabled = true;
            textBoxMovieRelative.Enabled = true;
        }
    }
}
