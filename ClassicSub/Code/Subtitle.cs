using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MpcApi;
using System.IO;
using System.Text.RegularExpressions;

namespace ClassicSub
{
    class SubDataGridView : System.Windows.Forms.DataGridView
    {
        protected override void OnNewRowNeeded(DataGridViewRowEventArgs e)
        {
            base.OnNewRowNeeded(e);
        }
    }

    class Subtitle : INotifyPropertyChanged
    {
        public static int NextNewSubtitleNumber = 1;
        public static int NextNewSubtitleStartMs = 0;

        public Subtitle()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private int _Number = NextNewSubtitleNumber;
        private int _StartMs = NextNewSubtitleStartMs;
        private int _EndMs = NextNewSubtitleStartMs;
        private string _SubText1 = "";
        private string _SubText2 = "";
        private string _SubText3 = "";
        private string _SubText4 = "";

        public int Number
        {
            get
            {
                return _Number;
            }
            set
            {
                _Number = value;
                NotifyPropertyChanged("Number");
            }
        }

        public string SubText1
        {
            get
            {
                return _SubText1;
            }
            set
            {
                if (value == null)
                {
                    _SubText1 = "";
                }
                else
                {
                    _SubText1 = value;
                }
                NotifyPropertyChanged("SubText1");
            }
        }

        public string SubText2
        {
            get
            {
                return _SubText2;
            }
            set
            {
                if (value == null)
                {
                    _SubText2 = "";
                }
                else
                {
                    _SubText2 = value;
                }
                NotifyPropertyChanged("SubText2");
            }
        }

        public string SubText3
        {
            get
            {
                return _SubText3;
            }
            set
            {
                if (value == null)
                {
                    _SubText3 = "";
                }
                else
                {
                    _SubText3 = value;
                }
                NotifyPropertyChanged("SubText3");
            }
        }

        public string SubText4
        {
            get
            {
                return _SubText4;
            }
            set
            {
                if (value == null)
                {
                    _SubText4 = "";
                }
                else
                {
                    _SubText4 = value;
                }
                NotifyPropertyChanged("SubText4");
            }
        }

        public void SetSubText(int textNum, string text)
        {
            if (textNum == 2)
            {
                SubText2 = text;
            }
            else if (textNum == 3)
            {
                SubText3 = text;
            }
            else if (textNum == 4)
            {
                SubText4 = text;
            }
            else
            {
                SubText1 = text;
            }
        }

        public string GetSubText(int textNum)
        {
            if (textNum == 2)
            {
                return SubText2;
            }
            else if (textNum == 3)
            {
                return SubText3;
            }
            else if (textNum == 4)
            {
                return SubText4;
            }

            return SubText1;
        }

        static public string GetSubTextName(int textNum)
        {
            if (textNum == 2)
            {
                return "SubText2";
            }
            else if (textNum == 3)
            {
                return "SubText3";
            }
            else if (textNum == 4)
            {
                return "SubText4";
            }

            return "SubText1";
        }

        [Browsable(false)]
        public int StartMs
        {
            get
            {
                return _StartMs;
            }
            set
            {
                _StartMs = value;
                NotifyPropertyChanged("Start");
                NotifyPropertyChanged("Duration");
            }
        }

        [Browsable(false)]
        public int EndMs
        {
            get
            {
                return _EndMs;
            }
            set
            {
                _EndMs = value;
                NotifyPropertyChanged("End");
                NotifyPropertyChanged("Duration");
            }
        }

        [Browsable(false)]
        public int DurationMs
        {
            get
            {
                if (StartMs < EndMs)
                {
                    return EndMs - StartMs;
                }
                return 0;
            }
            set
            {
                if (StartMs == 0 && EndMs != 0)
                {
                    StartMs = EndMs - value;
                }
                else
                {
                    EndMs = StartMs + value;
                }
            }
        }

        static public int ParseHMSTime(string value)
        {
            int time = -1;
            Match match = Regex.Match(value, @"\s*(\d+):\s*(\d+):\s*(\d+[,.]?\d*)\s*");
            if (match.Success)
            {
                int hours = Convert.ToInt32(match.Groups[1].ToString());
                int minutes = Convert.ToInt32(match.Groups[2].ToString());
                double seconds = Convert.ToDouble(match.Groups[3].ToString().Replace(',', '.'));
                time = (int)(((double)(((hours * 60) + minutes) * 60) + seconds) * 1000);
            }
            else
            {
                match = Regex.Match(value, @"\s*(\d+):\s*(\d+[,.]?\d*)\s*");
                if (match.Success)
                {
                    int minutes = Convert.ToInt32(match.Groups[1].ToString());
                    double seconds = Convert.ToDouble(match.Groups[2].ToString().Replace(',', '.'));
                    time = (int)(((double)(minutes * 60) + seconds) * 1000);
                }
                else
                {
                    match = Regex.Match(value, @"\s*(\d+[,.]?\d*)\s*");
                    if (match.Success)
                    {
                        double seconds = Convert.ToDouble(match.Groups[1].ToString().Replace(',', '.'));
                        time = (int)(seconds * 1000);
                    }
                }
            }
            return time;
        }

        public string Start
        {
            get
            {
                int temp = StartMs;
                int hours = temp / (60 * 60 * 1000);
                temp -= hours * (60 * 60 * 1000);
                int mins = temp / (60 * 1000);
                temp -= mins * (60 * 1000);
                double floatSecs = ((double)temp) / 1000;
                string formatted = String.Format("{0}:{1:00}:{2:00.000}", hours, mins, floatSecs);
                return formatted;
            }
            set
            {
                int time = ParseHMSTime(value);
                if (time >= 0)
                {
                    StartMs = time;
                }
            }
        }

        public string GetStartForSRT()
        {
            int temp = StartMs;
            int hours = temp / (60 * 60 * 1000);
            temp -= hours * (60 * 60 * 1000);
            int mins = temp / (60 * 1000);
            temp -= mins * (60 * 1000);
            double floatSecs = ((double)temp) / 1000;
            string formatted = String.Format("{0:00}:{1:00}:{2:00.000}", hours, mins, floatSecs);
            return formatted.Replace(".",",");
        }

        public string End
        {
            get
            {
                int temp = EndMs;
                int hours = temp / (60 * 60 * 1000);
                temp -= hours * (60 * 60 * 1000);
                int mins = temp / (60 * 1000);
                temp -= mins * (60 * 1000);
                double floatSecs = ((double)temp) / 1000;
                string formatted = String.Format("{0}:{1:00}:{2:00.000}", hours, mins, floatSecs);
                return formatted;
            }
            set
            {
                int time = ParseHMSTime(value);
                if (time >= 0)
                {
                    EndMs = time;
                }
            }
        }

        public string GetEndForSRT()
        {
            int temp = EndMs;
            int hours = temp / (60 * 60 * 1000);
            temp -= hours * (60 * 60 * 1000);
            int mins = temp / (60 * 1000);
            temp -= mins * (60 * 1000);
            double floatSecs = ((double)temp) / 1000;
            string formatted = String.Format("{0:00}:{1:00}:{2:00.000}", hours, mins, floatSecs);
            return formatted.Replace(".", ",");
        }

        public string Duration
        {
            get
            {
                double floatSecs = ((double)DurationMs) / 1000;
                string formatted = String.Format("{0:0.###}", floatSecs);
                return formatted;
            }
            set
            {
                int time = ParseHMSTime(value);
                if (time >= 0)
                {
                    DurationMs = time;
                }
            }
        }

        public int GetOverlap(Subtitle other)
        {
            return Math.Min(EndMs, other.EndMs) - Math.Max(StartMs, other.StartMs);
        }

        public static BindingList<Subtitle> ReadSubtitleFile(string fileName)
        {
            BindingList<Subtitle> subListTemp = null;

            FileInfo fi = new FileInfo(fileName);

            if (fi.Exists)
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(fs))
                    {
                        subListTemp = new BindingList<Subtitle>();

                        Subtitle subObj = null;
                        string line;
                        int lineNum = 0;
                        bool haveReadTime = false;

                        while ((line = reader.ReadLine()) != null)
                        {
                            lineNum++;
                            line = line.Trim();

                            if (line == "")
                            {
                                // We have found an empty line; add the previous subtitle, if any, to the list
                                if (subObj != null)
                                {
                                    subListTemp.Add(subObj);
                                    subObj = null;
                                }
                                haveReadTime = false;
                            }
                            else if (subObj == null)
                            {
                                // We have a line but no subtitle object yet.
                                // Only create a new subtitle if the subtitle number can be read
                                try
                                {
                                    int subNum = Convert.ToInt32(line);
                                    subObj = new Subtitle();
                                    subObj.Number = subNum;
                                }
                                catch (Exception ex)
                                {
                                    string message = String.Format("Error on line {0}.\nInvalid Subtitle Number: {1}\nException: {2}", lineNum, line, ex.Message);
                                    MessageBox.Show(message);
                                    return null;
                                }
                            }
                            else
                            {
                                // We have a line and a subtitle object.
                                if (!haveReadTime)
                                {
                                    // Ugly hack for some subtitle files with spaces after the comma
                                    string correctedLine = Regex.Replace(line, @",\s\s\s", ",000");
                                    correctedLine = Regex.Replace(correctedLine, @",\s\s", ",00");
                                    correctedLine = Regex.Replace(correctedLine, @",\s", ",0");

                                    // Try to interpret it as a timing line.
                                    string regex = @"(\s*\d+:\s*\d+:\s*\d+[,.]\d+)\s*-->\s*(\d+:\s*\d+:\s*\d+[,.]\d+)";
                                    Match match = Regex.Match(correctedLine, regex);

                                    if (match.Success)
                                    {
                                        subObj.Start = match.Groups[1].ToString();
                                        subObj.End = match.Groups[2].ToString();
                                        haveReadTime = true;
                                    }
                                    else
                                    {
                                        string message = String.Format("Error on line {0}.\nInvalid Subtitle Timing: {1}", lineNum, line);
                                        MessageBox.Show(message);
                                        return null;
                                    }
                                }
                                else
                                {
                                    // This is a text line
                                    if (subObj.SubText1.Length == 0)
                                    {
                                        subObj.SubText1 = line;
                                    }
                                    else
                                    {
                                        // append it to the previous lines.
                                        subObj.SubText1 = subObj.SubText1 + "\r\n" + line;
                                    }
                                }
                            }
                        }

                        if (subObj != null)
                        {
                            subListTemp.Add(subObj);
                        }

                    }
                }
            }

            return subListTemp;
        }
    }
}
