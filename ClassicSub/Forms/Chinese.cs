using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


namespace ClassicSub
{
    public partial class Chinese : Form
    {
        public bool okClicked = false;

        public string Translate(string source)
        {
            if (parentsub.chineseDict != null)
            {
                if (GetOperationRadioSetting() == 1)
                {
                    return parentsub.chineseDict.PinyinToneMarksV2(source);
                }
                else if (GetOperationRadioSetting() == 2)
                {
                    return parentsub.chineseDict.PinyinToneNumbersV2(source);
                }
                else
                {
                   return parentsub.chineseDict.WordForWord(source);
                }
            }

            return source;
        }

        ClassicSubForm parentsub = null;

        public Chinese(ClassicSubForm p)
        {
            parentsub = p;

            InitializeComponent();

            radioText2.Enabled = parentsub.Text2Enabled;
            radioText3.Enabled = parentsub.Text3Enabled;
            radioText4.Enabled = parentsub.Text4Enabled;

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

            int op = GetOperationRadioSetting();

            if (op == 1)
            {
                radioPinyin.Checked = true;
            }
            else if (op == 2)
            {
                radioPinyinNumbers.Checked = true;
            }
            else
            {
                radioWordForWord.Checked = true;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (parentsub.chineseDict == null)
            {
                parentsub.chineseDict = new ChineseDictionary(
                    ClassicSub.Forms.ChineseDict.GetDictLocation(),
                    ClassicSub.Forms.ChineseDict.GetOverrideLocation1(),
                    ClassicSub.Forms.ChineseDict.GetOverrideLocation2());
            }

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

            if (radioPinyin.Checked)
            {
                SetOperationRadioSetting(1);
            }
            else if (radioPinyinNumbers.Checked)
            {
                SetOperationRadioSetting(2);
            }
            else
            {
                SetOperationRadioSetting(3);
            }

            okClicked = true;

            Close();
        }

        public static int GetTextRadioSetting()
        {
            int val = 1; // default

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Chinese Text Radio Setting");

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
                Application.UserAppDataRegistry.SetValue("Chinese Text Radio Setting", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int GetOperationRadioSetting()
        {
            int val = 1; // default

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Chinese Operation Radio Setting");

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

        public static void SetOperationRadioSetting(int val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Chinese Operation Radio Setting", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }

    public class ChineseDictionary
    {
        SubDict mainDict;
        SubDict overrideDict1;
        SubDict overrideDict2;

        public ChineseDictionary(string dictFileName, string overrideFileName1, string overrideFileName2)
        {
            mainDict = new SubDict(dictFileName);
            overrideDict1 = new SubDict(overrideFileName1);
            overrideDict2 = new SubDict(overrideFileName2);
        }

        Regex westernChars = new Regex(@"^[0-9a-zA-Z\s]");

        public string PinyinToneMarksV1(string source)
        {
            string buffer = source;
            string result = "";

            while (buffer.Length > 0)
            {
                if (westernChars.IsMatch(buffer))
                {
                    if (result.Length > 0)
                    {
                        result += " ";
                    }

                    // Eat up all the 'Western' characters
                    while (buffer.Length > 0 && westernChars.IsMatch(buffer))
                    {
                        result += buffer[0];
                        buffer = buffer.Substring(1);
                    }
                }
                else if (Char.IsPunctuation(buffer[0]))
                {
                    result += buffer[0];
                    buffer = buffer.Substring(1);
                }
                else
                {
                    if (result.Length > 0)
                    {
                        result += " ";
                    }
                    
                    string mainResult = "";
                    string overResult1 = "";
                    string overResult2 = "";
                    int mainLen = mainDict.LookupPinyin(buffer, ref mainResult);
                    int overLen1 = overrideDict1.LookupPinyin(buffer, ref overResult1);
                    int overLen2 = overrideDict2.LookupPinyin(buffer, ref overResult2);

                    if (mainLen > 0 || overLen1 > 0 || overLen2 > 0)
                    {
                        if (result.Length > 0)
                        {
                            result += " ";
                        }

                        if (overLen1 >= mainLen && overLen1 >= overLen2)
                        {
                            result += AddToneMarks(overResult1);
                            buffer = buffer.Substring(overLen1);
                        }
                        else if (overLen2 >= mainLen)
                        {
                            result += AddToneMarks(overResult2);
                            buffer = buffer.Substring(overLen2);
                        }
                        else
                        {
                            result += AddToneMarks(mainResult);
                            buffer = buffer.Substring(mainLen);
                        }
                    }
                    else
                    {
                        // No match found, use first character
                        result += buffer[0];
                        buffer = buffer.Substring(1);
                    }
                }
            }

            return result;
        }

        public string PinyinToneNumbersV1(string source)
        {
            string buffer = source;
            string result = "";

            while (buffer.Length > 0)
            {
                if (westernChars.IsMatch(buffer))
                {
                    if (result.Length > 0)
                    {
                        result += " ";
                    }

                    // Eat up all the 'Western' characters
                    while (buffer.Length > 0 && westernChars.IsMatch(buffer))
                    {
                        result += buffer[0];
                        buffer = buffer.Substring(1);
                    }
                }
                else if (Char.IsPunctuation(buffer[0]))
                {
                    result += buffer[0];
                    buffer = buffer.Substring(1);
                }
                else
                {
                    if (result.Length > 0)
                    {
                        result += " ";
                    }

                    string mainResult = "";
                    string overResult1 = "";
                    string overResult2 = "";
                    int mainLen = mainDict.LookupPinyin(buffer, ref mainResult);
                    int overLen1 = overrideDict1.LookupPinyin(buffer, ref overResult1);
                    int overLen2 = overrideDict2.LookupPinyin(buffer, ref overResult2);

                    if (mainLen > 0 || overLen1 > 0 || overLen2 > 0)
                    {
                        if (overLen1 >= mainLen && overLen1 >= overLen2)
                        {
                            result += overResult1;
                            buffer = buffer.Substring(overLen1);
                        }
                        else if (overLen2 >= mainLen)
                        {
                            result += overResult2;
                            buffer = buffer.Substring(overLen2);
                        }
                        else
                        {
                            result += mainResult;
                            buffer = buffer.Substring(mainLen);
                        }
                    }
                    else
                    {
                        // No match found, use first character
                        result += buffer[0];
                        buffer = buffer.Substring(1);
                    }
                }
            }

            return result;
        }

        class ChBit
        {
            public bool isHanzi = false;
            public bool continuation = false;

            // for chinese chars, this is non-empty
            public string hanzi = "";

            // this is always set (non-empty)
            public string str = "";

            public ChBit(string nonChinese)
            {
                str = nonChinese;
                isHanzi = false;
            }

            public ChBit(string hanziChar, string pinyinStr, bool cont)
            {
                hanzi = hanziChar;
                str = pinyinStr;
                isHanzi = true;
                continuation = cont;
            }
        };

        // This newer version does (well at least 'attempts') the tone sandhi
        public string PinyinToneMarksV2(string source)
        {
            List<ChBit> bits = CreateChineseBits(source);

            // It seems tone sandhi are not written, disabling - could switch on with an option
            // PerformToneSandhi(bits);

            return BitsToToneMarksString(bits);
        }

        // This newer version does (well at least 'attempts') the tone sandhi
        public string PinyinToneNumbersV2(string source)
        {
            List<ChBit> bits = CreateChineseBits(source);

            // It seems tone sandhi are not written, disabling - could switch on with an option
            // PerformToneSandhi(bits);

            return BitsToToneNumbersString(bits);
        }

        string BitsToToneMarksString(List<ChBit> bits)
        {
            string result = "";

            bool lastWasHanzi = false;
            foreach (ChBit bit in bits)
            {
                if (bit.isHanzi)
                {
                    if (lastWasHanzi && bit.str != "r5" && !bit.continuation)
                    {
                        result = result + " ";
                    }

                    result = result + AddToneMarks(bit.str);

                    lastWasHanzi = true;
                }
                else
                {
                    result = result + bit.str;

                    lastWasHanzi = false;
                }
            }

            return result;
        }

        string BitsToToneNumbersString(List<ChBit> bits)
        {
            string result = "";

            bool lastWasHanzi = false;
            foreach (ChBit bit in bits)
            {
                if (bit.isHanzi)
                {
                    if (lastWasHanzi && bit.str != "r5" && !bit.continuation)
                    {
                        result = result + " ";
                    }

                    result = result + bit.str;

                    lastWasHanzi = true;
                }
                else
                {
                    result = result + bit.str;

                    lastWasHanzi = false;
                }
            }

            return result;
        }

        void PerformToneSandhi(List<ChBit> bits)
        {
            /* From Wikipedia: http://en.wikipedia.org/wiki/Tone_sandhi
             * Mandarin features three sandhi tone rules.
             * 1. When there are two 3rd tones in a row, the first one becomes 2nd tone, and the second one becomes a
             *    half-third tone (which only falls and does not rise). E.g. 你好 (nǐ + hǎo = ní hǎo)
             * 2. 不 (bù) is 4th tone except when followed by another 4th tone, when it becomes second tone.
             *    E.g. 不对 (bù + duì = bú duì)
             * 3. 一 (Yī) is a) 1st tone when alone, b) 2nd tone when followed by a 4th tone, and c) 4th tone when followed by
             *    any other tone. Examples: 一个 (yī + gè = yí gè), 一次 (yī + cì = yí cì), 一半 (yī + bàn = yí bàn),
             *    一般 (yī + bān = yì bān), 一毛 (yī + máo = yì máo), 一会儿 (yī + huǐr = yì huǐr).
             *
             Minimal unit test:
            恰好 我国 你好 不一 不对 一 一半 一般 一毛 一会儿

            恰好	  = qià hǎo (rule 1 not applied)
            我国	  = wǒ guó (rule 1 not applied)
            你好  = ní hǎo (rule 1 applied)
            不一	  = bù yī (rule 2 not applied)
            不对  = bú duì (rule 2 applied)
            一    = yī (rule 3a applied)
            一半  = yí bàn (rule 3b applied)
            一般  = yì bān  (rule 3c applied)
            一毛  = yì máo) (rule 3c applied)
            一会儿 = yì huǐr (rule 3c applied)

             */

            for (int i = 0; i < bits.Count(); i++)
            {
                // rule 1 - test for two third tones and replace with 2nd
                if (bits[i].isHanzi && bits[i].str.Contains("3") && i < (bits.Count() - 1) && bits[i+1].isHanzi && bits[i+1].str.Contains("3"))
                {
                    bits[i].str = bits[i].str.Replace("3", "2");
                }
                
                // rule 2 - 'bu' 
                if (bits[i].hanzi == "不" && i < (bits.Count() - 1) && bits[i + 1].isHanzi && bits[i + 1].str.Contains("4"))
                {
                    bits[i].str = bits[i].str.Replace("4", "2");
                }
                
                // rule 3
                if (bits[i].hanzi == "一" && i < (bits.Count() - 1) && bits[i + 1].isHanzi)
                {
                    if (bits[i + 1].str.Contains("4"))
                    {
                        bits[i].str = bits[i].str.Replace("1", "2");
                    }
                    else if (bits[i + 1].str.Contains("1") || bits[i + 1].str.Contains("2") || bits[i + 1].str.Contains("3"))
                    {
                        bits[i].str = bits[i].str.Replace("1", "4");
                    }
                }

            }
        }

        List<ChBit> CreateChineseBits(string source)
        {
            string buffer = source;
            List<ChBit> result = new List<ChBit>();

            bool lastWasWestern = false;
            bool lastWasPunctuation = false;
            bool lastWasChinese = false;
            
            while (buffer.Length > 0)
            {
                if (Char.IsWhiteSpace(buffer[0]))
                {
                    // Add only a single whitespace
                    if (lastWasChinese || lastWasWestern || lastWasPunctuation)
                    {
                        result.Add(new ChBit(buffer.Substring(0, 1)));
                    }

                    buffer = buffer.Substring(1);

                    lastWasWestern = false;
                    lastWasPunctuation = false;
                    lastWasChinese = false;
                }
                else if (westernChars.IsMatch(buffer))
                {
                    // Add a space after chinese characters
                    if (lastWasChinese)
                    {
                        result.Add(new ChBit(" "));
                    }

                    result.Add(new ChBit(buffer.Substring(0, 1)));
                    buffer = buffer.Substring(1);

                    lastWasWestern = true;
                    lastWasPunctuation = false;
                    lastWasChinese = false;
                }
                else if (Char.IsPunctuation(buffer[0]))
                {
                    result.Add(new ChBit(buffer.Substring(0, 1)));
                    buffer = buffer.Substring(1);

                    lastWasWestern = false;
                    lastWasPunctuation = true;
                    lastWasChinese = false;
                }
                else
                {
                    // Add a space after Western characters
                    if (lastWasWestern)
                    {
                        result.Add(new ChBit(" "));
                    }

                    string mainResult = "";
                    string overResult1 = "";
                    string overResult2 = "";
                    int mainLen = mainDict.LookupPinyin(buffer, ref mainResult);
                    int overLen1 = overrideDict1.LookupPinyin(buffer, ref overResult1);
                    int overLen2 = overrideDict2.LookupPinyin(buffer, ref overResult2);

                    if (mainLen > 0 || overLen1 > 0 || overLen2 > 0)
                    {
                        string resultToUse = "";
                        int lenToUse = 0;

                        if (overLen1 >= mainLen && overLen1 >= overLen2)
                        {
                            resultToUse = overResult1;
                            lenToUse = overLen1;
                        }
                        else if (overLen2 >= mainLen)
                        {
                            resultToUse = overResult2;
                            lenToUse = overLen2;
                        }
                        else
                        {
                            resultToUse = mainResult;
                            lenToUse = mainLen;
                        }

                        string hanziChars = buffer.Substring(0, lenToUse);

                        bool cont = false;
                        foreach (Char ch in hanziChars)
                        {
                            string pinyin = "";

                            if (resultToUse.Contains(" "))
                            {
                                int pos = resultToUse.IndexOf(" ");
                                pinyin = resultToUse.Substring(0, pos);
                                resultToUse = resultToUse.Substring(pos+1);
                            }
                            else
                            {
                                pinyin = resultToUse;
                                resultToUse = "";
                            }

                            result.Add(new ChBit(new string(ch, 1), pinyin, cont));
                            cont = true;
                        }

                        buffer = buffer.Substring(lenToUse);
                    }
                    else
                    {
                        // No match found, use first character
                        result.Add(new ChBit(buffer.Substring(0, 1)));
                        buffer = buffer.Substring(1);
                    }

                    lastWasWestern = false;
                    lastWasPunctuation = false;
                    lastWasChinese = true;
                }
            }

            return result;
        }


        // This word for word idea sucks so bad there is literally no point using it. Literally (Jamie)
        public string WordForWord(string source)
        {
            string buffer = source;
            string result = "";

            while (buffer.Length > 0)
            {
                if (westernChars.IsMatch(buffer))
                {
                    if (result.Length > 0)
                    {
                        result += " ";
                    }

                    // Eat up all the 'Western' characters
                    while (buffer.Length > 0 && westernChars.IsMatch(buffer))
                    {
                        result += buffer[0];
                        buffer = buffer.Substring(1);
                    }
                }
                else if (Char.IsPunctuation(buffer[0]))
                {
                    result += buffer[0];
                    buffer = buffer.Substring(1);
                }
                else
                {
                    if (result.Length > 0)
                    {
                        result += " ";
                    }

                    string mainResult = "";
                    string overResult1 = "";
                    string overResult2 = "";
                    int mainLen = mainDict.LookupWordForWord(buffer, ref mainResult);
                    int overLen1 = overrideDict1.LookupWordForWord(buffer, ref overResult1);
                    int overLen2 = overrideDict2.LookupWordForWord(buffer, ref overResult2);

                    if (mainLen > 0 || overLen1 > 0 || overLen2 > 0)
                    {
                        if (overLen1 >= mainLen && overLen1 >= overLen2)
                        {
                            result += overResult1;
                            buffer = buffer.Substring(overLen1);
                        }
                        else if (overLen2 >= mainLen)
                        {
                            result += overResult2;
                            buffer = buffer.Substring(overLen2);
                        }
                        else
                        {
                            result += mainResult;
                            buffer = buffer.Substring(mainLen);
                        }
                    }
                    else
                    {
                        // No match found, use first character
                        result += buffer[0];
                        buffer = buffer.Substring(1);
                    }
                }
            }

            return result;
        }

        private string AddToneMarks(string source)
        {
            string withTones = "";
            string[] tokens = source.Split(' ');

            foreach (string syllable in tokens)
            {
                if (syllable.Length > 0)
                {
                    if (withTones.Length == 0)
                    {
                        withTones = PinyinSyllable(syllable);
                    }
                    else
                    {
                        withTones += " " + PinyinSyllable(syllable);
                    }
                }
            }

            return withTones;
        }

        // assumes lower case for now; remove comments if needed in the future
        private string PinyinSyllable(string original)
        {
            string source = original.Replace("u:", "ü");

            if (source.Contains('1'))
            {
                if      (source.Contains('a'))  source = source.Replace('a', 'ā').Replace("1", "");
                else if (source.Contains('e'))  source = source.Replace('e', 'ē').Replace("1", "");
                else if (source.Contains('o'))  source = source.Replace('o', 'ō').Replace("1", "");
                else if (source.Contains("ui")) source = source.Replace("ui", "uī").Replace("1", "");
                else if (source.Contains('u'))  source = source.Replace('u', 'ū').Replace("1", "");
                else if (source.Contains('i'))  source = source.Replace('i', 'ī').Replace("1", "");
                else if (source.Contains('ü'))  source = source.Replace('ü', 'ǖ').Replace("1", "");
                /*else if (source.Contains('A'))  source = source.Replace('A', 'Ā').Replace("1", "");
                else if (source.Contains('E'))  source = source.Replace('E', 'Ē').Replace("1", "");
                else if (source.Contains('O'))  source = source.Replace('O', 'Ō').Replace("1", "");
                else if (source.Contains("Ui")) source = source.Replace("Ui", "Uī").Replace("1", "");
                else if (source.Contains('U'))  source = source.Replace('U', 'Ū').Replace("1", "");
                else if (source.Contains('I'))  source = source.Replace('I', 'Ī').Replace("1", "");
                else if (source.Contains('Ü'))  source = source.Replace('Ü', 'Ǖ').Replace("1", "");*/
            }
            else if (source.Contains('2'))
            {
                if      (source.Contains('a'))  source = source.Replace('a', 'á').Replace("2", "");
                else if (source.Contains('e'))  source = source.Replace('e', 'é').Replace("2", "");
                else if (source.Contains('o'))  source = source.Replace('o', 'ó').Replace("2", "");
                else if (source.Contains("ui")) source = source.Replace("ui", "uí").Replace("2", "");
                else if (source.Contains('u'))  source = source.Replace('u', 'ú').Replace("2", "");
                else if (source.Contains('i'))  source = source.Replace('i', 'í').Replace("2", "");
                else if (source.Contains('ü'))  source = source.Replace('ü', 'ǘ').Replace("2", "");
                /*else if (source.Contains('A'))  source = source.Replace('A', 'Á').Replace("2", "");
                else if (source.Contains('E'))  source = source.Replace('E', 'É').Replace("2", "");
                else if (source.Contains('O'))  source = source.Replace('O', 'Ó').Replace("2", "");
                else if (source.Contains("Ui")) source = source.Replace("Ui", "Uí").Replace("2", "");
                else if (source.Contains('U'))  source = source.Replace('U', 'Ú').Replace("2", "");
                else if (source.Contains('I'))  source = source.Replace('I', 'Í').Replace("2", "");
                else if (source.Contains('Ü'))  source = source.Replace('Ü', 'Ǘ').Replace("2", "");*/
            }
            else if (source.Contains('3'))
            {
                if      (source.Contains('a'))  source = source.Replace('a', 'ă').Replace("3", "");
                else if (source.Contains('e'))  source = source.Replace('e', 'ĕ').Replace("3", "");
                else if (source.Contains('o'))  source = source.Replace('o', 'ŏ').Replace("3", "");
                else if (source.Contains("ui")) source = source.Replace("ui", "uĭ").Replace("3", "");
                else if (source.Contains('u'))  source = source.Replace('u', 'ŭ').Replace("3", "");
                else if (source.Contains('i'))  source = source.Replace('i', 'ĭ').Replace("3", "");
                else if (source.Contains('ü'))  source = source.Replace('ü', 'ǚ').Replace("3", "");
                /*else if (source.Contains('A'))  source = source.Replace('A', 'Ă').Replace("3", "");
                else if (source.Contains('E'))  source = source.Replace('E', 'Ĕ').Replace("3", "");
                else if (source.Contains('O'))  source = source.Replace('O', 'Ŏ').Replace("3", "");
                else if (source.Contains("Ui")) source = source.Replace("Ui", "Uĭ").Replace("3", "");
                else if (source.Contains('U'))  source = source.Replace('U', 'Ŭ').Replace("3", "");
                else if (source.Contains('I'))  source = source.Replace('I', 'Ĭ').Replace("3", "");
                else if (source.Contains('Ü'))  source = source.Replace('Ü', 'Ǚ').Replace("3", "");*/
            }
            else if (source.Contains('4'))
            {
                if      (source.Contains('a'))  source = source.Replace('a', 'à').Replace("4", "");
                else if (source.Contains('e'))  source = source.Replace('e', 'è').Replace("4", "");
                else if (source.Contains('o'))  source = source.Replace('o', 'ò').Replace("4", "");
                else if (source.Contains("ui")) source = source.Replace("ui", "uì").Replace("4", "");
                else if (source.Contains('u'))  source = source.Replace('u', 'ù').Replace("4", "");
                else if (source.Contains('i'))  source = source.Replace('i', 'ì').Replace("4", "");
                else if (source.Contains('ü'))  source = source.Replace('ü', 'ǜ').Replace("4", "");
                /*else if (source.Contains('A'))  source = source.Replace('A', 'À').Replace("4", "");
                else if (source.Contains('E'))  source = source.Replace('E', 'È').Replace("4", "");
                else if (source.Contains('O'))  source = source.Replace('O', 'Ò').Replace("4", "");
                else if (source.Contains("Ui")) source = source.Replace("Ui", "Uì").Replace("4", "");
                else if (source.Contains('U'))  source = source.Replace('U', 'Ù').Replace("4", "");
                else if (source.Contains('I'))  source = source.Replace('I', 'Ì').Replace("4", "");
                else if (source.Contains('Ü'))  source = source.Replace('Ü', 'Ǜ').Replace("4", "");*/
            }
            else if (source.Contains('5'))
            {
                source = source.Replace("5", "");
            }

            return source;
        }
    }

    class SubDict
    {
        Dictionary<string, bool> subwordSet = new Dictionary<string, bool>();
        Dictionary<string, string> pinyinDict = new Dictionary<string, string>();
        Dictionary<string, string> definitionDict = new Dictionary<string, string>();

        public SubDict(string filename)
        {
            LoadFile(filename);
        }

        void LoadFile(string filename)
        {
            FileInfo fi = new FileInfo(filename);

            if (fi.Exists)
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(fs))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            line = line.Trim();
                            ParseLine(line);
                        }
                    }
                }
            }
        }

        private void ParseLine(string line)
        {
            if (line.Length > 0 && line[0] != '#')
            {
                Match match = Regex.Match(line, @"(\S+)\s+(\S+)\s+\[([^\[]+)\]\s(.+)");
                if (match.Success)
                {
                    string traditional = match.Groups[1].ToString().Trim();
                    string simplified = match.Groups[2].ToString().Trim();
                    string pinyin = match.Groups[3].ToString().Trim();
                    string[] definitions = match.Groups[4].ToString().Trim().Split('/');

                    bool maybeIgnore = false;

                    if (definitions.Length > 0 && definitions[0].IndexOf("see") == 0)
                    {
                        // if the entry starts with 'see', it is just referencing another entry - maybe ignore it.
                        maybeIgnore = true;
                    }

                    if (pinyin.Length > 0)
                    {
                        if (simplified.Length > 0)
                        {
                            if (pinyinDict.ContainsKey(simplified))
                            {
                                if (!maybeIgnore)
                                {
                                    // remove and re-add
                                    pinyinDict.Remove(simplified);
                                    pinyinDict.Add(simplified, pinyin);
                                }
                            }
                            else
                            {
                                AddSubWords(simplified);
                                pinyinDict.Add(simplified, pinyin);
                            }
                        }

                        if (simplified != traditional)
                        {
                            if (traditional.Length > 0)
                            {
                                if (pinyinDict.ContainsKey(traditional))
                                {
                                    if (!maybeIgnore)
                                    {
                                        // remove and re-add
                                        pinyinDict.Remove(traditional);
                                        pinyinDict.Add(traditional, pinyin);
                                    }
                                }
                                else
                                {
                                    AddSubWords(traditional);
                                    pinyinDict.Add(traditional, pinyin);
                                }
                            }
                        }
                    }

                    foreach (string def in definitions)
                    {
                        string definition = def.Trim();

                        if (definition.Length > 0 && definition.IndexOf("see") != 0)
                        {
                            if (simplified.Length > 0 && !definitionDict.ContainsKey(simplified))
                            {
                                if (definitionDict.ContainsKey(simplified))
                                {
                                    if (!maybeIgnore)
                                    {
                                        // remove and re-add
                                        definitionDict.Remove(simplified);
                                        definitionDict.Add(simplified, definition);
                                    }
                                }
                                else
                                {
                                    AddSubWords(simplified);
                                    definitionDict.Add(simplified, definition);
                                }
                            }

                            if (simplified != traditional)
                            {
                                if (traditional.Length > 0)
                                {
                                    if (definitionDict.ContainsKey(traditional))
                                    {
                                        if (!maybeIgnore)
                                        {
                                            // remove and re-add
                                            definitionDict.Remove(traditional);
                                            definitionDict.Add(traditional, definition);
                                        }
                                    }
                                    else
                                    {
                                        AddSubWords(traditional);
                                        definitionDict.Add(traditional, definition);
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }

        void AddSubWords(string word)
        {
            if (word.Length > 0 && !subwordSet.ContainsKey(word))
            {
                subwordSet.Add(word, true);
                AddSubWords(word.Substring(0, word.Count()-1));
            }
        }

        public int LookupPinyin(string source, ref string result)
        {
            int longestFound = 0;

            for (int i = 1; i <= source.Length; i++)
            {
                string lookup = source.Substring(0, i);

                if (pinyinDict.ContainsKey(lookup))
                {
                    // Always lower case now! Have to change this line and the
                    // regexes if upper case is wanted again
                    result = pinyinDict[lookup].ToLower();
                    longestFound = i;
                }
                else
                {
                    if (!subwordSet.ContainsKey(lookup))
                    {
                        break;
                    }
                }
            }

            return longestFound;
        }

        Regex variant = new Regex(@"variant of (.*)|.+");
        
        public int LookupWordForWord(string source, ref string result)
        {
            int longestFound = 0;

            for (int i = 1; i <= source.Length; i++)
            {
                string lookup = source.Substring(0, i);

                if (definitionDict.ContainsKey(lookup))
                {
                    result = definitionDict[lookup];
                    longestFound = i;
                }
                else
                {
                    if (!subwordSet.ContainsKey(lookup))
                    {
                        break;
                    }
                }
            }

            // fall back on the pinyin if nothing else was found
            if (longestFound == 0)
            {
                longestFound = LookupPinyin(source, ref result);
            }
            
            if (variant.IsMatch(result))
            {
                string alternate = variant.Replace(result, "$1");
                longestFound = LookupWordForWord(alternate, ref result);
            }
            
            if (longestFound > 0)
            {
                result = CleanupWord(result);
            }

            return longestFound;
        }

        Regex clean0 = new Regex(@"^(.*particle.+)$");
        Regex clean1 = new Regex(@"\s*\(.+\)\s*");
        Regex clean2 = new Regex(@"^to (.+)");
        Regex clean3 = new Regex(@"^surname (.+)");
        Regex clean4 = new Regex(@"^([^,\(\[\|]+)[,\(\[\|].+");
        string CleanupWord(string source)
        {
            string processed = source;

            processed = clean0.Replace(processed, "P");
            processed = clean1.Replace(processed, "");
            processed = clean2.Replace(processed, "$1");
            processed = clean3.Replace(processed, "$1");
            processed = clean4.Replace(processed, "$1");
            // return "{" + source + "} -> [" + processed + "]";
            return processed;
        }
    }
}
