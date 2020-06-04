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
    public partial class ChineseDict : Form
    {
        private ClassicSubForm parent;

        public ChineseDict(ClassicSubForm p)
        {
            parent = p;

            InitializeComponent();

            textBoxDictLocation.Text = GetDictLocation();
            textBoxOverrideLocation1.Text = GetOverrideLocation1();
            textBoxOverrideLocation2.Text = GetOverrideLocation2();
        }

        private void buttonOverrideBrowse1_Click(object sender, EventArgs e)
        {

        }

        private void buttonOverrideBrowse2_Click(object sender, EventArgs e)
        {

        }

        private void buttonDictBrowse_Click(object sender, EventArgs e)
        {

        }

        private void buttonOverrideEdit1_Click(object sender, EventArgs e)
        {

        }

        private void buttonOverrideEdit2_Click(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SetDictLocation(textBoxDictLocation.Text);
            SetOverrideLocation1(textBoxOverrideLocation1.Text);
            SetOverrideLocation2(textBoxOverrideLocation2.Text);

            parent.chineseDict = null;

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static string GetDictLocation()
        {
            string val = "cedict_ts.u8"; // default

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Chinese Dictionary Location");

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
        
        public static void SetDictLocation(string val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Chinese Dictionary Location", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string GetOverrideLocation1()
        {
            string val = "customdict.u8"; // default

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Override Dictionary Location");

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

        public static void SetOverrideLocation1(string val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Override Dictionary Location", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string GetOverrideLocation2()
        {
            string val = "overridedict.u8"; // default

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Override Dictionary Location 2");

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

        public static void SetOverrideLocation2(string val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Override Dictionary Location 2", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
