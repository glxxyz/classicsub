using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassicSub
{
    public enum DurationRange
    {
        Selected = 1,
        All = 2
    }

    public enum DurationUpdate
    {
        EmptyOnly = 1,
        OnlyIncrease = 2,
        SetToCalculated = 3
    }

    public enum DurationCalculation
    {
        Algorithm = 1,
        ScaleFactor = 2,
    }

    public partial class DurationForm : Form
    {
        public bool ClosedWithOK = false;

        public DurationForm()
        {
            InitializeComponent();

            try
            {
                // only set these 3 textboxes, don't read back this value
                textBoxDurationConstant.Text = (((double)ConfigForm.GetDurationConstant()) / 1000).ToString();
                textBoxDurationVariable.Text = (((double)ConfigForm.GetDurationVariable()) / 1000).ToString();
                textBoxDurationMin.Text = (((double)ConfigForm.GetDurationMinimum()) / 1000).ToString();

                textBoxScale.Text = (((double)GetDurationScale()) / 1000).ToString();

                DurationRange range = GetDurationRange();
                DurationUpdate update = GetDurationUpdate();
                DurationCalculation calc = GetDurationCalculation();

                switch (range)
                {
                    case DurationRange.Selected:
                        radioButtonSelcted.Checked = true;
                        break;

                    case DurationRange.All:
                        radioButtonAll.Checked = true;
                        break;
                }

                switch (update)
                {
                    case DurationUpdate.EmptyOnly:
                        radioButtonOnlyEmpty.Checked = true;
                        break;

                    case DurationUpdate.OnlyIncrease:
                        radioButtonOnlyIncrease.Checked = true;
                        break;

                    case DurationUpdate.SetToCalculated:
                        radioButtonAllInRange.Checked = true;
                        break;
                }

                switch (calc)
                {
                    case DurationCalculation.Algorithm:
                        radioButtonUseAlgorithm.Checked = true;
                        break;

                    case DurationCalculation.ScaleFactor:
                        radioButtonScaleFactor.Checked = true;
                        break;
                }

                UpdateUI();
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
                SetDurationScale((int)(Convert.ToDouble(textBoxScale.Text) * 1000));

                DurationRange range;
                DurationUpdate update;
                DurationCalculation calc;

                if (radioButtonSelcted.Checked == true)
                {
                    range = DurationRange.Selected;
                }
                else
                {
                    range = DurationRange.All;
                }

                if (radioButtonOnlyEmpty.Checked == true)
                {
                    update = DurationUpdate.EmptyOnly;
                }
                else if (radioButtonOnlyIncrease.Checked == true)
                {
                    update = DurationUpdate.OnlyIncrease;
                }
                else
                {
                    update = DurationUpdate.SetToCalculated;
                }

                if (radioButtonUseAlgorithm.Checked == true)
                {
                    calc = DurationCalculation.Algorithm;
                }
                else
                {
                    calc = DurationCalculation.ScaleFactor;
                }

                SetDurationRange(range);
                SetDurationUpdate(update);
                SetDurationCalculation(calc);

                ClosedWithOK = true;

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

        void UpdateUI()
        {
            bool algorithm = (radioButtonUseAlgorithm.Checked == true);

            labelDurationEquals.Enabled = algorithm;
            textBoxDurationConstant.Enabled = algorithm;
            labelPlus.Enabled = algorithm;
            textBoxDurationVariable.Enabled = algorithm;
            labelTimesNum.Enabled = algorithm;
            labelMinimum.Enabled = algorithm;
            textBoxDurationMin.Enabled = algorithm;
            labelAllTimes.Enabled = algorithm;
            labelExperimentation.Enabled = algorithm;

            labelScaleBy.Enabled = !algorithm;
            textBoxScale.Enabled = !algorithm;
            labelAllTimesScale.Enabled = !algorithm;
        }

        public static DurationRange GetDurationRange()
        {
            DurationRange val = DurationRange.Selected;

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Duration Range");

                if (obj != null)
                {
                    val = (DurationRange)int.Parse(obj.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return val;
        }

        public static void SetDurationRange(DurationRange val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Duration Range", (int)val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static DurationUpdate GetDurationUpdate()
        {
            DurationUpdate val = DurationUpdate.EmptyOnly;

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Duration Update");

                if (obj != null)
                {
                    val = (DurationUpdate)int.Parse(obj.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return val;
        }

        public static void SetDurationUpdate(DurationUpdate val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Duration Update", (int)val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static DurationCalculation GetDurationCalculation()
        {
            DurationCalculation val = DurationCalculation.Algorithm;

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Duration Calculation");

                if (obj != null)
                {
                    val = (DurationCalculation)int.Parse(obj.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return val;
        }

        public static void SetDurationCalculation(DurationCalculation val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Duration Calculation", (int)val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int GetDurationScale()
        {
            int val = 1500; // default

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Duration Scale");

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

        public static void SetDurationScale(int val)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Duration Scale", val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButtonUseAlgorithm_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void radioButtonScaleFactor_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();

        }

    }
}
