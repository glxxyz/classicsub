using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MpcApi;

namespace ClassicSub
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            try
            {
                textBoxMPCLocation.Text = MPCControlForm.GetMPCPath();
                checkBoxAutoSave.Checked = GetAutoSaveOnEdit();
                checkBoxFindRegex.Checked = GetFindRegex();
                checkBoxHighlightInvalid.Checked = GetHighlightInvalidCells();
                checkBoxHighlightCounter.Checked = GetHighlightCounter();
                checkBoxAutoDuration.Checked = GetAutoDuration();
                textBoxDurationConstant.Text = (((double)GetDurationConstant())/1000).ToString();
                textBoxDurationVariable.Text = (((double)GetDurationVariable())/1000).ToString();
                textBoxDurationMin.Text = (((double)GetDurationMinimum()) / 1000).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                MPCControlForm.SetMPCPath(textBoxMPCLocation.Text);
                SetAutoSaveOnEdit(checkBoxAutoSave.Checked);
                SetFindRegex(checkBoxFindRegex.Checked);
                SetHighlightInvalidCells(checkBoxHighlightInvalid.Checked);
                SetHighlightCounter(checkBoxHighlightInvalid.Checked);
                SetAutoDuration(checkBoxAutoDuration.Checked);
                SetDurationConstant((int)(Convert.ToDouble(textBoxDurationConstant.Text) * 1000));
                SetDurationVariable((int)(Convert.ToDouble(textBoxDurationVariable.Text) * 1000));
                SetDurationMinimum((int)(Convert.ToDouble(textBoxDurationMin.Text) * 1000));

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static bool GetAutoSaveOnEdit()
        {
            bool val = false; // default

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Auto Save On Edit");

                if (obj != null)
                {
                    val = bool.Parse(obj.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return val;
        }

        public static void SetAutoSaveOnEdit(bool val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Auto Save On Edit", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool GetFindRegex()
        {
            bool val = false; // default

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Find Regex");

                if (obj != null)
                {
                    val = bool.Parse(obj.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return val;
        }

        public static void SetFindRegex(bool val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Find Regex", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int GetDurationConstant()
        {
            int val = 1000; // default

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Duration Constant");

                if (obj != null)
                {
                    val = int.Parse(obj.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return val;
        }

        public static void SetDurationConstant(int val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Duration Constant", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int GetDurationVariable()
        {
            int val = 100; // default

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Duration Variable");

                if (obj != null)
                {
                    val = int.Parse(obj.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return val;
        }

        public static void SetDurationVariable(int val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Duration Variable", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int GetDurationMinimum()
        {
            int val = 2000; // default

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Duration Minimum");

                if (obj != null)
                {
                    val = int.Parse(obj.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return val;
        }

        public static void SetDurationMinimum(int val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Duration Minimum", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool GetHighlightInvalidCells()
        {
            bool val = true; // default

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Highlight Invalid Cells");

                if (obj != null)
                {
                    val = bool.Parse(obj.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return val;
        }

        public static void SetHighlightInvalidCells(bool val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Highlight Invalid Cells", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool GetHighlightCounter()
        {
            bool val = true; // default

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Highlight Counter");

                if (obj != null)
                {
                    val = bool.Parse(obj.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return val;
        }

        public static void SetHighlightCounter(bool val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Highlight Counter", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool GetAutoDuration()
        {
            bool val = true; // default

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Auto Duration");

                if (obj != null)
                {
                    val = bool.Parse(obj.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return val;
        }

        public static void SetAutoDuration(bool val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Auto Duration", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Path.GetDirectoryName(textBoxMPCLocation.Text);
            openFileDialog.FileName = Path.GetFileName(textBoxMPCLocation.Text);
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxMPCLocation.Text = openFileDialog.FileName;
            }
        }
    }
}
