namespace ClassicSub
{
    partial class DurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DurationForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonSelcted = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonOnlyIncrease = new System.Windows.Forms.RadioButton();
            this.radioButtonOnlyEmpty = new System.Windows.Forms.RadioButton();
            this.radioButtonAllInRange = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonUseAlgorithm = new System.Windows.Forms.RadioButton();
            this.labelExperimentation = new System.Windows.Forms.Label();
            this.radioButtonScaleFactor = new System.Windows.Forms.RadioButton();
            this.labelAllTimesScale = new System.Windows.Forms.Label();
            this.labelAllTimes = new System.Windows.Forms.Label();
            this.textBoxDurationVariable = new System.Windows.Forms.TextBox();
            this.textBoxScale = new System.Windows.Forms.TextBox();
            this.textBoxDurationMin = new System.Windows.Forms.TextBox();
            this.textBoxDurationConstant = new System.Windows.Forms.TextBox();
            this.labelPlus = new System.Windows.Forms.Label();
            this.labelScaleBy = new System.Windows.Forms.Label();
            this.labelMinimum = new System.Windows.Forms.Label();
            this.labelTimesNum = new System.Windows.Forms.Label();
            this.labelDurationEquals = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonSelcted);
            this.groupBox1.Controls.Add(this.radioButtonAll);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Range";
            // 
            // radioButtonSelcted
            // 
            this.radioButtonSelcted.AutoSize = true;
            this.radioButtonSelcted.Checked = true;
            this.radioButtonSelcted.Location = new System.Drawing.Point(19, 19);
            this.radioButtonSelcted.Name = "radioButtonSelcted";
            this.radioButtonSelcted.Size = new System.Drawing.Size(97, 17);
            this.radioButtonSelcted.TabIndex = 1;
            this.radioButtonSelcted.TabStop = true;
            this.radioButtonSelcted.Text = "Selected Rows";
            this.radioButtonSelcted.UseVisualStyleBackColor = true;
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(19, 42);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(66, 17);
            this.radioButtonAll.TabIndex = 0;
            this.radioButtonAll.Text = "All Rows";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(199, 231);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(283, 231);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonOnlyIncrease);
            this.groupBox2.Controls.Add(this.radioButtonOnlyEmpty);
            this.groupBox2.Controls.Add(this.radioButtonAllInRange);
            this.groupBox2.Location = new System.Drawing.Point(12, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 99);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rows to update";
            // 
            // radioButtonOnlyIncrease
            // 
            this.radioButtonOnlyIncrease.AutoSize = true;
            this.radioButtonOnlyIncrease.Location = new System.Drawing.Point(18, 43);
            this.radioButtonOnlyIncrease.Name = "radioButtonOnlyIncrease";
            this.radioButtonOnlyIncrease.Size = new System.Drawing.Size(133, 17);
            this.radioButtonOnlyIncrease.TabIndex = 2;
            this.radioButtonOnlyIncrease.Text = "Only Increase Duration";
            this.radioButtonOnlyIncrease.UseVisualStyleBackColor = true;
            // 
            // radioButtonOnlyEmpty
            // 
            this.radioButtonOnlyEmpty.AutoSize = true;
            this.radioButtonOnlyEmpty.Checked = true;
            this.radioButtonOnlyEmpty.Location = new System.Drawing.Point(18, 20);
            this.radioButtonOnlyEmpty.Name = "radioButtonOnlyEmpty";
            this.radioButtonOnlyEmpty.Size = new System.Drawing.Size(126, 17);
            this.radioButtonOnlyEmpty.TabIndex = 1;
            this.radioButtonOnlyEmpty.TabStop = true;
            this.radioButtonOnlyEmpty.Text = "Empty Durations Only";
            this.radioButtonOnlyEmpty.UseVisualStyleBackColor = true;
            // 
            // radioButtonAllInRange
            // 
            this.radioButtonAllInRange.AutoSize = true;
            this.radioButtonAllInRange.Location = new System.Drawing.Point(18, 66);
            this.radioButtonAllInRange.Name = "radioButtonAllInRange";
            this.radioButtonAllInRange.Size = new System.Drawing.Size(148, 17);
            this.radioButtonAllInRange.TabIndex = 0;
            this.radioButtonAllInRange.Text = "Set to calculated Duration";
            this.radioButtonAllInRange.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonUseAlgorithm);
            this.groupBox3.Controls.Add(this.labelExperimentation);
            this.groupBox3.Controls.Add(this.radioButtonScaleFactor);
            this.groupBox3.Controls.Add(this.labelAllTimesScale);
            this.groupBox3.Controls.Add(this.labelAllTimes);
            this.groupBox3.Controls.Add(this.textBoxDurationVariable);
            this.groupBox3.Controls.Add(this.textBoxScale);
            this.groupBox3.Controls.Add(this.textBoxDurationMin);
            this.groupBox3.Controls.Add(this.textBoxDurationConstant);
            this.groupBox3.Controls.Add(this.labelPlus);
            this.groupBox3.Controls.Add(this.labelScaleBy);
            this.groupBox3.Controls.Add(this.labelMinimum);
            this.groupBox3.Controls.Add(this.labelTimesNum);
            this.groupBox3.Controls.Add(this.labelDurationEquals);
            this.groupBox3.Location = new System.Drawing.Point(189, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(365, 201);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Duration Calculation";
            // 
            // radioButtonUseAlgorithm
            // 
            this.radioButtonUseAlgorithm.AutoSize = true;
            this.radioButtonUseAlgorithm.Checked = true;
            this.radioButtonUseAlgorithm.Location = new System.Drawing.Point(13, 19);
            this.radioButtonUseAlgorithm.Name = "radioButtonUseAlgorithm";
            this.radioButtonUseAlgorithm.Size = new System.Drawing.Size(68, 17);
            this.radioButtonUseAlgorithm.TabIndex = 1;
            this.radioButtonUseAlgorithm.TabStop = true;
            this.radioButtonUseAlgorithm.Text = "Algorithm";
            this.radioButtonUseAlgorithm.UseVisualStyleBackColor = true;
            this.radioButtonUseAlgorithm.CheckedChanged += new System.EventHandler(this.radioButtonUseAlgorithm_CheckedChanged);
            // 
            // labelExperimentation
            // 
            this.labelExperimentation.AutoSize = true;
            this.labelExperimentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExperimentation.Location = new System.Drawing.Point(35, 112);
            this.labelExperimentation.Name = "labelExperimentation";
            this.labelExperimentation.Size = new System.Drawing.Size(303, 13);
            this.labelExperimentation.TabIndex = 2;
            this.labelExperimentation.Text = "Experimentation may be needed to find the best values for you.";
            // 
            // radioButtonScaleFactor
            // 
            this.radioButtonScaleFactor.AutoSize = true;
            this.radioButtonScaleFactor.Location = new System.Drawing.Point(13, 131);
            this.radioButtonScaleFactor.Name = "radioButtonScaleFactor";
            this.radioButtonScaleFactor.Size = new System.Drawing.Size(85, 17);
            this.radioButtonScaleFactor.TabIndex = 0;
            this.radioButtonScaleFactor.Text = "Scale Factor";
            this.radioButtonScaleFactor.UseVisualStyleBackColor = true;
            this.radioButtonScaleFactor.CheckedChanged += new System.EventHandler(this.radioButtonScaleFactor_CheckedChanged);
            // 
            // labelAllTimesScale
            // 
            this.labelAllTimesScale.AutoSize = true;
            this.labelAllTimesScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAllTimesScale.Location = new System.Drawing.Point(35, 172);
            this.labelAllTimesScale.Name = "labelAllTimesScale";
            this.labelAllTimesScale.Size = new System.Drawing.Size(179, 13);
            this.labelAllTimesScale.TabIndex = 2;
            this.labelAllTimesScale.Text = "Decimals are allowed in scale factor.";
            // 
            // labelAllTimes
            // 
            this.labelAllTimes.AutoSize = true;
            this.labelAllTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAllTimes.Location = new System.Drawing.Point(35, 99);
            this.labelAllTimes.Name = "labelAllTimes";
            this.labelAllTimes.Size = new System.Drawing.Size(224, 13);
            this.labelAllTimes.TabIndex = 2;
            this.labelAllTimes.Text = "All times are in seconds, decimals are allowed.";
            // 
            // textBoxDurationVariable
            // 
            this.textBoxDurationVariable.Location = new System.Drawing.Point(159, 39);
            this.textBoxDurationVariable.Name = "textBoxDurationVariable";
            this.textBoxDurationVariable.Size = new System.Drawing.Size(45, 20);
            this.textBoxDurationVariable.TabIndex = 1;
            // 
            // textBoxScale
            // 
            this.textBoxScale.Location = new System.Drawing.Point(140, 148);
            this.textBoxScale.Name = "textBoxScale";
            this.textBoxScale.Size = new System.Drawing.Size(45, 20);
            this.textBoxScale.TabIndex = 1;
            // 
            // textBoxDurationMin
            // 
            this.textBoxDurationMin.Location = new System.Drawing.Point(94, 69);
            this.textBoxDurationMin.Name = "textBoxDurationMin";
            this.textBoxDurationMin.Size = new System.Drawing.Size(45, 20);
            this.textBoxDurationMin.TabIndex = 1;
            // 
            // textBoxDurationConstant
            // 
            this.textBoxDurationConstant.Location = new System.Drawing.Point(94, 39);
            this.textBoxDurationConstant.Name = "textBoxDurationConstant";
            this.textBoxDurationConstant.Size = new System.Drawing.Size(45, 20);
            this.textBoxDurationConstant.TabIndex = 1;
            // 
            // labelPlus
            // 
            this.labelPlus.AutoSize = true;
            this.labelPlus.Location = new System.Drawing.Point(144, 43);
            this.labelPlus.Name = "labelPlus";
            this.labelPlus.Size = new System.Drawing.Size(16, 13);
            this.labelPlus.TabIndex = 0;
            this.labelPlus.Text = "+ ";
            // 
            // labelScaleBy
            // 
            this.labelScaleBy.AutoSize = true;
            this.labelScaleBy.Location = new System.Drawing.Point(35, 151);
            this.labelScaleBy.Name = "labelScaleBy";
            this.labelScaleBy.Size = new System.Drawing.Size(99, 13);
            this.labelScaleBy.TabIndex = 0;
            this.labelScaleBy.Text = "Scale Durations by:";
            // 
            // labelMinimum
            // 
            this.labelMinimum.AutoSize = true;
            this.labelMinimum.Location = new System.Drawing.Point(33, 73);
            this.labelMinimum.Name = "labelMinimum";
            this.labelMinimum.Size = new System.Drawing.Size(51, 13);
            this.labelMinimum.TabIndex = 0;
            this.labelMinimum.Text = "Minimum:";
            // 
            // labelTimesNum
            // 
            this.labelTimesNum.AutoSize = true;
            this.labelTimesNum.Location = new System.Drawing.Point(207, 43);
            this.labelTimesNum.Name = "labelTimesNum";
            this.labelTimesNum.Size = new System.Drawing.Size(118, 13);
            this.labelTimesNum.TabIndex = 0;
            this.labelTimesNum.Text = "x Number of Characters";
            // 
            // labelDurationEquals
            // 
            this.labelDurationEquals.AutoSize = true;
            this.labelDurationEquals.Location = new System.Drawing.Point(33, 43);
            this.labelDurationEquals.Name = "labelDurationEquals";
            this.labelDurationEquals.Size = new System.Drawing.Size(59, 13);
            this.labelDurationEquals.TabIndex = 0;
            this.labelDurationEquals.Text = "Duration = ";
            // 
            // DurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(566, 268);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DurationForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Set Durations";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton radioButtonSelcted;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonOnlyIncrease;
        private System.Windows.Forms.RadioButton radioButtonOnlyEmpty;
        private System.Windows.Forms.RadioButton radioButtonAllInRange;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonUseAlgorithm;
        private System.Windows.Forms.Label labelExperimentation;
        private System.Windows.Forms.RadioButton radioButtonScaleFactor;
        private System.Windows.Forms.Label labelAllTimesScale;
        private System.Windows.Forms.Label labelAllTimes;
        private System.Windows.Forms.TextBox textBoxDurationVariable;
        private System.Windows.Forms.TextBox textBoxScale;
        private System.Windows.Forms.TextBox textBoxDurationMin;
        private System.Windows.Forms.TextBox textBoxDurationConstant;
        private System.Windows.Forms.Label labelPlus;
        private System.Windows.Forms.Label labelScaleBy;
        private System.Windows.Forms.Label labelMinimum;
        private System.Windows.Forms.Label labelTimesNum;
        private System.Windows.Forms.Label labelDurationEquals;
    }
}