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
    public partial class NudgeForm : Form
    {
        public bool okClicked = false;
        public bool recalcDurationChecked = false;

        public NudgeForm()
        {
            InitializeComponent();

            SetNudge(0);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            okClicked = true;
            recalcDurationChecked = checkBoxRecalcDuration.Checked;
            Close();
        }

        public int GetNudge()
        {        
            int time = -1;
            Match match = Regex.Match(textBoxNudgeTime.Text, @"\s*(-?)(.*)");

            if (match.Success)
            {
                time = Subtitle.ParseHMSTime(match.Groups[2].ToString());
                if (match.Groups[1].ToString() == "-")
                {
                    time *= -1;
                }
            }

            return time;
        }

        public void SetNudge(int time)
        {
            int temp = time;

            string negativeFlag = "";
            if (temp < 0)
            {
                negativeFlag = "-";
                temp *= -1;
            }

            int hours = temp / (60 * 60 * 1000);
            temp -= hours * (60 * 60 * 1000);
            int mins = temp / (60 * 1000);
            temp -= mins * (60 * 1000);
            double floatSecs = ((double)temp) / 1000;
            string formatted = String.Format("{0}{1}:{2:00}:{3:00.000}", negativeFlag, hours, mins, floatSecs);

            textBoxNudgeTime.Text = formatted;
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
            int time = GetNudge();

            time += seekOffset;

            time = Math.Max(time, (((9 * 60) + 59) * 60 + 59) * -1000);
            time = Math.Min(time, (((9 * 60) + 59) * 60 + 59) * 1000);

            SetNudge(time);
        }


        private void backwardTinyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-100);
        }

        private void forwardTinyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(100);
        }


        private void backwardSmallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-1 * 1000);
        }

        private void forwardSmallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(1 * 1000);
        }

        private void backwardMedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-5 * 1000);
        }

        private void forwardMedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(5 * 1000);
        }

        private void backwardBigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-20 * 1000);
        }

        private void forwardBigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(20 * 1000);
        }

        private void backward1mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-1 * 60 * 1000);
        }

        private void forward1mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(1 * 60 * 1000);
        }

        private void backward5mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-5 * 60 * 1000);
        }

        private void forward5mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(5 * 60 * 1000);
        }

        private void backward20mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-20 * 60 * 1000);
        }

        private void forward20mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(20 * 60 * 1000);
        }

        private void buttonPlusMinus_Click(object sender, EventArgs e)
        {
            int time = GetNudge();

            if (time == 0)
            {
                string timeText = textBoxNudgeTime.Text;

                if (timeText.Length > 0 && timeText.Substring(0, 1) == "-")
                {
                    string newTimeText = timeText.Substring(1);

                    textBoxNudgeTime.Text = newTimeText;
                }
                else if (!timeText.Contains("-"))
                {
                    string newTimeText = "-" + timeText;

                    textBoxNudgeTime.Text = newTimeText;
                }
            }
            else
            {

                time *= -1;

                SetNudge(time);
            }

            textBoxNudgeTime_TextChanged(sender, e);
        }

        private void textBoxNudgeTime_TextChanged(object sender, EventArgs e)
        {
            string timeText = textBoxNudgeTime.Text;

            if (timeText.Length > 0 && timeText.Substring(0, 1) == "-")
            {
                labelTimeHelp.Text = " h:mm:ss.ttt";
            }
            else
            {
                labelTimeHelp.Text = "h:mm:ss.ttt";
            }
        }
    }
}
