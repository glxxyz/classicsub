using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Google.Apis;
using Google.Apis.Translate.v2;
using Google.Apis.Translate.v2.Data;
using TranslationsResource = Google.Apis.Translate.v2.Data.TranslationsResource;

namespace ClassicSub
{
    public partial class GoogleTranslate : Form
    {
        public bool okClicked = false;
        public string sourceLanguage = "";
        public string targetLanguage = "";

        public void DoTranslate(List<string> sources, ref List<string> translations)
        {
            var service = new TranslateService { Key = GetAPIKey() };

            var list = service.Translations.List(sources, targetLanguage);
            list.Source = sourceLanguage;
            TranslationsListResponse response = list.Fetch();

            foreach (TranslationsResource translation in response.Translations)
            {
                translations.Add(translation.TranslatedText);
            }
        }

        public GoogleTranslate(ClassicSubForm csForm)
        {
            InitializeComponent();

            radioText2.Enabled = csForm.Text2Enabled;
            radioText3.Enabled = csForm.Text3Enabled;
            radioText4.Enabled = csForm.Text4Enabled;

            int sel = GetTextRadioSetting();

            if (sel == 1)
            {
                radioText1.Checked = true;
            }
            else if (sel == 2 && radioText2.Enabled)
            {
                radioText2.Checked = true;
            }
            else if (sel == 3 && radioText3.Enabled)
            {
                radioText3.Checked = true;
            }
            else if (sel == 4 && radioText4.Enabled)
            {
                radioText4.Checked = true;
            }
            else
            {
                radioSelection.Checked = true;
            }

            object[] languages = new object[] { "af", "sq", "ar",
                "be", "bg", "ca", "zh-CN", "zh-TW", "hr", "cs", "da",
                "nl", "en", "et", "tl", "fi", "fr", "gl", "de", "el",
                "ht", "iw", "hi", "hu", "is", "id", "ga", "it", "ja",
                "lv", "lt", "mk", "ms", "mt", "no", "fa", "pl", "pt",
                "ro", "ru", "sr", "sk", "sl", "es", "sw", "sv", "th",
                "tr", "uk", "vi", "cy", "yi" };

            comboFrom.Items.AddRange(languages);
            comboTo.Items.AddRange(languages);

            comboFrom.SelectedIndex = GetComboFromSel();
            comboTo.SelectedIndex = GetComboToSel();

            textBoxAPIKey.Text = GetAPIKey();
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            SetAPIKey(textBoxAPIKey.Text);
            SetComboFromSel(comboFrom.SelectedIndex);
            SetComboToSel(comboTo.SelectedIndex);

            if (radioText1.Checked)
            {
                SetTextRadioSetting(1);
            }
            else if (radioText2.Checked)
            {
                SetTextRadioSetting(2);
            }
            else if (radioText3.Checked)
            {
                SetTextRadioSetting(3);
            }
            else if (radioText4.Checked)
            {
                SetTextRadioSetting(4);
            }
            else
            {
                SetTextRadioSetting(0);
            }

            sourceLanguage = comboFrom.SelectedItem.ToString();
            targetLanguage = comboTo.SelectedItem.ToString();

            okClicked = true;

            Close();
        }

        public static string GetAPIKey()
        {
            string val = "You must obtain a Google Translate API key"; // default

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Translate API Key");

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

        public static void SetAPIKey(string val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Translate API Key", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int GetComboFromSel()
        {
            int val = 6; // default = Simplified Chinese

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Translate Combo From Sel");

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

        public static void SetComboFromSel(int val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Translate Combo From Sel", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int GetComboToSel()
        {
            int val = 12; // default = English

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Translate Combo To Sel");

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

        public static void SetComboToSel(int val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Translate Combo To Sel", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int GetTextRadioSetting()
        {
            int val = 0; // default = Selection

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Translate Text Radio Setting");

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

        public static void SetTextRadioSetting(int val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Translate Text Radio Setting", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
