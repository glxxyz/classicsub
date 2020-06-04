namespace ClassicSub
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMPCLocation = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.checkBoxAutoSave = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxHighlightInvalid = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDurationVariable = new System.Windows.Forms.TextBox();
            this.textBoxDurationMin = new System.Windows.Forms.TextBox();
            this.textBoxDurationConstant = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxFindRegex = new System.Windows.Forms.CheckBox();
            this.checkBoxHighlightCounter = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoDuration = new System.Windows.Forms.CheckBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Media Player Classic .exe Location:";
            // 
            // textBoxMPCLocation
            // 
            this.textBoxMPCLocation.Location = new System.Drawing.Point(16, 30);
            this.textBoxMPCLocation.Name = "textBoxMPCLocation";
            this.textBoxMPCLocation.Size = new System.Drawing.Size(511, 20);
            this.textBoxMPCLocation.TabIndex = 1;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(534, 26);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(38, 23);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(300, 322);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(216, 322);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // checkBoxAutoSave
            // 
            this.checkBoxAutoSave.AutoSize = true;
            this.checkBoxAutoSave.Enabled = false;
            this.checkBoxAutoSave.Location = new System.Drawing.Point(16, 65);
            this.checkBoxAutoSave.Name = "checkBoxAutoSave";
            this.checkBoxAutoSave.Size = new System.Drawing.Size(300, 17);
            this.checkBoxAutoSave.TabIndex = 5;
            this.checkBoxAutoSave.Text = "Auto Save on Edit (changes show up in MPC Immediately)";
            this.checkBoxAutoSave.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "That\'s all for now...";
            // 
            // checkBoxHighlightInvalid
            // 
            this.checkBoxHighlightInvalid.AutoSize = true;
            this.checkBoxHighlightInvalid.Location = new System.Drawing.Point(16, 111);
            this.checkBoxHighlightInvalid.Name = "checkBoxHighlightInvalid";
            this.checkBoxHighlightInvalid.Size = new System.Drawing.Size(126, 17);
            this.checkBoxHighlightInvalid.TabIndex = 5;
            this.checkBoxHighlightInvalid.Text = "Highlight Invalid Cells";
            this.checkBoxHighlightInvalid.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBoxDurationVariable);
            this.groupBox3.Controls.Add(this.textBoxDurationMin);
            this.groupBox3.Controls.Add(this.textBoxDurationConstant);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(16, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(556, 103);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Duration Calculation";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Some suggestions: (TODO)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(303, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Experimentation may be needed to find the best values for you.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "All times are in seconds, decimals are allowed.";
            // 
            // textBoxDurationVariable
            // 
            this.textBoxDurationVariable.Location = new System.Drawing.Point(134, 20);
            this.textBoxDurationVariable.Name = "textBoxDurationVariable";
            this.textBoxDurationVariable.Size = new System.Drawing.Size(45, 20);
            this.textBoxDurationVariable.TabIndex = 1;
            // 
            // textBoxDurationMin
            // 
            this.textBoxDurationMin.Location = new System.Drawing.Point(415, 20);
            this.textBoxDurationMin.Name = "textBoxDurationMin";
            this.textBoxDurationMin.Size = new System.Drawing.Size(45, 20);
            this.textBoxDurationMin.TabIndex = 1;
            // 
            // textBoxDurationConstant
            // 
            this.textBoxDurationConstant.Location = new System.Drawing.Point(69, 20);
            this.textBoxDurationConstant.Name = "textBoxDurationConstant";
            this.textBoxDurationConstant.Size = new System.Drawing.Size(45, 20);
            this.textBoxDurationConstant.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "+ ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(354, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Minimum:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(182, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "x Number of Characters";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Duration = ";
            // 
            // checkBoxFindRegex
            // 
            this.checkBoxFindRegex.AutoSize = true;
            this.checkBoxFindRegex.Location = new System.Drawing.Point(16, 88);
            this.checkBoxFindRegex.Name = "checkBoxFindRegex";
            this.checkBoxFindRegex.Size = new System.Drawing.Size(198, 17);
            this.checkBoxFindRegex.TabIndex = 5;
            this.checkBoxFindRegex.Text = "Find uses .NET Regular Expressions";
            this.checkBoxFindRegex.UseVisualStyleBackColor = true;
            // 
            // checkBoxHighlightCounter
            // 
            this.checkBoxHighlightCounter.AutoSize = true;
            this.checkBoxHighlightCounter.Location = new System.Drawing.Point(16, 134);
            this.checkBoxHighlightCounter.Name = "checkBoxHighlightCounter";
            this.checkBoxHighlightCounter.Size = new System.Drawing.Size(182, 17);
            this.checkBoxHighlightCounter.TabIndex = 5;
            this.checkBoxHighlightCounter.Text = "Highlight Counter Position in Blue";
            this.checkBoxHighlightCounter.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoDuration
            // 
            this.checkBoxAutoDuration.AutoSize = true;
            this.checkBoxAutoDuration.Location = new System.Drawing.Point(16, 157);
            this.checkBoxAutoDuration.Name = "checkBoxAutoDuration";
            this.checkBoxAutoDuration.Size = new System.Drawing.Size(249, 17);
            this.checkBoxAutoDuration.TabIndex = 5;
            this.checkBoxAutoDuration.Text = "Auto Calculate Durations for new/modified cells";
            this.checkBoxAutoDuration.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.AddExtension = false;
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Executables|*.exe|All files|*.*";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(583, 361);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxFindRegex);
            this.Controls.Add(this.checkBoxAutoDuration);
            this.Controls.Add(this.checkBoxHighlightCounter);
            this.Controls.Add(this.checkBoxHighlightInvalid);
            this.Controls.Add(this.checkBoxAutoSave);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxMPCLocation);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigForm";
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMPCLocation;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox checkBoxAutoSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxHighlightInvalid;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDurationVariable;
        private System.Windows.Forms.TextBox textBoxDurationMin;
        private System.Windows.Forms.TextBox textBoxDurationConstant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxFindRegex;
        private System.Windows.Forms.CheckBox checkBoxHighlightCounter;
        private System.Windows.Forms.CheckBox checkBoxAutoDuration;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}