namespace ClassicSub
{
    partial class GoogleTranslate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoogleTranslate));
            this.radioText1 = new System.Windows.Forms.RadioButton();
            this.radioText2 = new System.Windows.Forms.RadioButton();
            this.radioText3 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxAPIKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboFrom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboTo = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.radioSelection = new System.Windows.Forms.RadioButton();
            this.radioText4 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            // radioText2
            // 
            this.radioText2.AutoSize = true;
            this.radioText2.Location = new System.Drawing.Point(67, 19);
            this.radioText2.Name = "radioText2";
            this.radioText2.Size = new System.Drawing.Size(55, 17);
            this.radioText2.TabIndex = 0;
            this.radioText2.TabStop = true;
            this.radioText2.Text = "Text 2";
            this.radioText2.UseVisualStyleBackColor = true;
            // 
            // radioText3
            // 
            this.radioText3.AutoSize = true;
            this.radioText3.Location = new System.Drawing.Point(128, 18);
            this.radioText3.Name = "radioText3";
            this.radioText3.Size = new System.Drawing.Size(55, 17);
            this.radioText3.TabIndex = 0;
            this.radioText3.TabStop = true;
            this.radioText3.Text = "Text 3";
            this.radioText3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioText1);
            this.groupBox1.Controls.Add(this.radioSelection);
            this.groupBox1.Controls.Add(this.radioText4);
            this.groupBox1.Controls.Add(this.radioText3);
            this.groupBox1.Controls.Add(this.radioText2);
            this.groupBox1.Location = new System.Drawing.Point(12, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 45);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text to Translate";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboTo);
            this.groupBox2.Controls.Add(this.comboFrom);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxAPIKey);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 81);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Translation";
            // 
            // textBoxAPIKey
            // 
            this.textBoxAPIKey.Location = new System.Drawing.Point(141, 20);
            this.textBoxAPIKey.Name = "textBoxAPIKey";
            this.textBoxAPIKey.Size = new System.Drawing.Size(323, 20);
            this.textBoxAPIKey.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Google Translate API Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Translate From";
            // 
            // comboFrom
            // 
            this.comboFrom.FormattingEnabled = true;
            this.comboFrom.Location = new System.Drawing.Point(141, 46);
            this.comboFrom.Name = "comboFrom";
            this.comboFrom.Size = new System.Drawing.Size(121, 21);
            this.comboFrom.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "To";
            // 
            // comboTo
            // 
            this.comboTo.FormattingEnabled = true;
            this.comboTo.Location = new System.Drawing.Point(294, 46);
            this.comboTo.Name = "comboTo";
            this.comboTo.Size = new System.Drawing.Size(121, 21);
            this.comboTo.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(267, 158);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(183, 158);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // radioSelection
            // 
            this.radioSelection.AutoSize = true;
            this.radioSelection.Location = new System.Drawing.Point(250, 18);
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
            this.radioText4.Location = new System.Drawing.Point(189, 18);
            this.radioText4.Name = "radioText4";
            this.radioText4.Size = new System.Drawing.Size(55, 17);
            this.radioText4.TabIndex = 0;
            this.radioText4.TabStop = true;
            this.radioText4.Text = "Text 4";
            this.radioText4.UseVisualStyleBackColor = true;
            // 
            // GoogleTranslate
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(538, 193);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GoogleTranslate";
            this.Text = "Google Translate";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioText1;
        private System.Windows.Forms.RadioButton radioText2;
        private System.Windows.Forms.RadioButton radioText3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboTo;
        private System.Windows.Forms.ComboBox comboFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAPIKey;
        private System.Windows.Forms.RadioButton radioSelection;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.RadioButton radioText4;
    }
}