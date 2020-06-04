using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace ClassicSub
{
    public partial class FrameRateForm : Form
    {
        public bool okClicked = false;

        public FrameRateForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (GetFrameRate() > 0)
            {
                okClicked = true;
                Close();
            }
        }

        public double GetFrameRate()
        {
            double rate = 0;
            
            try
            {
                rate = double.Parse(textBoxFrameRate.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return rate;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void testToolStripMenuItem2397_Click(object sender, EventArgs e)
        {
            textBoxFrameRate.Text = "23.97602";
        }

        private void testToolStripMenuItem24_Click(object sender, EventArgs e)
        {
            textBoxFrameRate.Text = "24";
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            textBoxFrameRate.Text = "25";
        }

        private void toolStripMenuItem2997_Click(object sender, EventArgs e)
        {
            textBoxFrameRate.Text = "29.97003";
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            textBoxFrameRate.Text = "30";
        }

        private void toolStripMenuItem50_Click(object sender, EventArgs e)
        {
            textBoxFrameRate.Text = "50";
        }

        private void toolStripMenuItem60_Click(object sender, EventArgs e)
        {
            textBoxFrameRate.Text = "60";
        }
    }
}
