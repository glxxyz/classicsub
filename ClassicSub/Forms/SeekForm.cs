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
    public partial class SeekForm : Form
    {
        public bool okClicked = false;

        public SeekForm(int seekTime)
        {
            InitializeComponent();

            SetSeekTime(seekTime);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (GetSeekTime() >= 0)
            {
                okClicked = true;
                Close();
            }
        }

        public int GetSeekTime()
        {
            int time = Subtitle.ParseHMSTime(maskedTextBoxSeekTime.Text);

            return time;
        }

        public void SetSeekTime(int time)
        {
            int temp = time;
            int hours = temp / (60 * 60 * 1000);
            temp -= hours * (60 * 60 * 1000);
            int mins = temp / (60 * 1000);
            temp -= mins * (60 * 1000);
            int secs = temp / 1000;

            string formatted = String.Format("{0}:{1:00}:{2:00}", hours, mins, secs);

            maskedTextBoxSeekTime.Text = formatted;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void maskedTextBoxSeekTime_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        void SendJump(int seekOffset)
        {
            int time = GetSeekTime();

            time += (seekOffset * 1000);

            time = Math.Max(time, 0);
            time = Math.Min(time, (((9 * 60) + 59) * 60 + 59) * 1000);

            SetSeekTime(time);
        }

        private void backwardSmallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-1);
        }

        private void forwardSmallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(1);
        }

        private void backwardMedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-5);
        }

        private void forwardMedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(5);
        }

        private void backwardBigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-20);
        }

        private void forwardBigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(20);
        }

        private void backward1mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-1 * 60);
        }

        private void forward1mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(1 * 60);
        }

        private void backward5mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-5 * 60);
        }

        private void forward5mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(5 * 60);
        }

        private void backward20mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-20 * 60);
        }

        private void forward20mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(20 * 60);
        }
    }
}
