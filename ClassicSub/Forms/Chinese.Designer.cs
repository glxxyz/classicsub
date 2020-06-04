namespace ClassicSub
{
    partial class Chinese
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chinese));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioText1 = new System.Windows.Forms.RadioButton();
            this.radioSelection = new System.Windows.Forms.RadioButton();
            this.radioText4 = new System.Windows.Forms.RadioButton();
            this.radioText3 = new System.Windows.Forms.RadioButton();
            this.radioText2 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioWordForWord = new System.Windows.Forms.RadioButton();
            this.radioPinyinNumbers = new System.Windows.Forms.RadioButton();
            this.radioPinyin = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioText1);
            this.groupBox1.Controls.Add(this.radioSelection);
            this.groupBox1.Controls.Add(this.radioText4);
            this.groupBox1.Controls.Add(this.radioText3);
            this.groupBox1.Controls.Add(this.radioText2);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 137);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text to Translate";
            // 
            // radioText1
            // 
            this.radioText1.AutoSize = true;
            this.radioText1.Location = new System.Drawing.Point(6, 19);
            this.radioText1.Name = "radioText1";
            this.radioText1.Size = new System.Drawing.Size(55, 17);
            this.radioText1.TabIndex = 0;
            this.radioText1.TabStop = true;
            this.radioText1.Text = "Text 1";
            this.radioText1.UseVisualStyleBackColor = true;
            // 
            // radioSelection
            // 
            this.radioSelection.AutoSize = true;
            this.radioSelection.Location = new System.Drawing.Point(6, 110);
            this.radioSelection.Name = "radioSelection";
            this.radioSelection.Size = new System.Drawing.Size(92, 17);
            this.radioSelection.TabIndex = 0;
            this.radioSelection.TabStop = true;
            this.radioSelection.Text = "Selected Cells";
            this.radioSelection.UseVisualStyleBackColor = true;
            // 
            // radioText4
            // 
            this.radioText4.AutoSize = true;
            this.radioText4.Location = new System.Drawing.Point(6, 88);
            this.radioText4.Name = "radioText4";
            this.radioText4.Size = new System.Drawing.Size(55, 17);
            this.radioText4.TabIndex = 0;
            this.radioText4.TabStop = true;
            this.radioText4.Text = "Text 4";
            this.radioText4.UseVisualStyleBackColor = true;
            // 
            // radioText3
            // 
            this.radioText3.AutoSize = true;
            this.radioText3.Location = new System.Drawing.Point(6, 65);
            this.radioText3.Name = "radioText3";
            this.radioText3.Size = new System.Drawing.Size(55, 17);
            this.radioText3.TabIndex = 0;
            this.radioText3.TabStop = true;
            this.radioText3.Text = "Text 3";
            this.radioText3.UseVisualStyleBackColor = true;
            // 
            // radioText2
            // 
            this.radioText2.AutoSize = true;
            this.radioText2.Location = new System.Drawing.Point(6, 42);
            this.radioText2.Name = "radioText2";
            this.radioText2.Size = new System.Drawing.Size(55, 17);
            this.radioText2.TabIndex = 0;
            this.radioText2.TabStop = true;
            this.radioText2.Text = "Text 2";
            this.radioText2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioWordForWord);
            this.groupBox2.Controls.Add(this.radioPinyinNumbers);
            this.groupBox2.Controls.Add(this.radioPinyin);
            this.groupBox2.Location = new System.Drawing.Point(138, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 137);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Translate";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // radioWordForWord
            // 
            this.radioWordForWord.AutoSize = true;
            this.radioWordForWord.Location = new System.Drawing.Point(6, 65);
            this.radioWordForWord.Name = "radioWordForWord";
            this.radioWordForWord.Size = new System.Drawing.Size(202, 17);
            this.radioWordForWord.TabIndex = 1;
            this.radioWordForWord.TabStop = true;
            this.radioWordForWord.Text = "Hanzi -> English Word-for-word (Beta)";
            this.radioWordForWord.UseVisualStyleBackColor = true;
            // 
            // radioPinyinNumbers
            // 
            this.radioPinyinNumbers.AutoSize = true;
            this.radioPinyinNumbers.Location = new System.Drawing.Point(6, 42);
            this.radioPinyinNumbers.Name = "radioPinyinNumbers";
            this.radioPinyinNumbers.Size = new System.Drawing.Size(174, 17);
            this.radioPinyinNumbers.TabIndex = 0;
            this.radioPinyinNumbers.TabStop = true;
            this.radioPinyinNumbers.Text = "Hanzi -> Pinyin (Tone Numbers)";
            this.radioPinyinNumbers.UseVisualStyleBackColor = true;
            // 
            // radioPinyin
            // 
            this.radioPinyin.AutoSize = true;
            this.radioPinyin.Location = new System.Drawing.Point(6, 19);
            this.radioPinyin.Name = "radioPinyin";
            this.radioPinyin.Size = new System.Drawing.Size(161, 17);
            this.radioPinyin.TabIndex = 0;
            this.radioPinyin.TabStop = true;
            this.radioPinyin.Text = "Hanzi -> Pinyin (Tone Marks)";
            this.radioPinyin.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(175, 157);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(91, 157);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(834, -255);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(17, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Chinese
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(366, 188);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chinese";
            this.Text = "Chinese Tools";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioText1;
        private System.Windows.Forms.RadioButton radioSelection;
        private System.Windows.Forms.RadioButton radioText4;
        private System.Windows.Forms.RadioButton radioText3;
        private System.Windows.Forms.RadioButton radioText2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioWordForWord;
        private System.Windows.Forms.RadioButton radioPinyin;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.RadioButton radioPinyinNumbers;
        private System.Windows.Forms.Button button2;
    }
}