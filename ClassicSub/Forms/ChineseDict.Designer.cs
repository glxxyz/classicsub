namespace ClassicSub.Forms
{
    partial class ChineseDict
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonOverrideEdit2 = new System.Windows.Forms.Button();
            this.buttonOverrideEdit1 = new System.Windows.Forms.Button();
            this.buttonOverrideBrowse2 = new System.Windows.Forms.Button();
            this.buttonOverrideBrowse1 = new System.Windows.Forms.Button();
            this.textBoxOverrideLocation2 = new System.Windows.Forms.TextBox();
            this.textBoxOverrideLocation1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDictBrowse = new System.Windows.Forms.Button();
            this.textBoxDictLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(435, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "take precedence. There are 2 dictionaries to allow a movie-specific and a global " +
                "dictionary.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(533, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "The Dictionaries are checked in order. Hanzi character matches (even partial) fro" +
                "m the first dictionary will always";
            // 
            // buttonOverrideEdit2
            // 
            this.buttonOverrideEdit2.Location = new System.Drawing.Point(531, 30);
            this.buttonOverrideEdit2.Name = "buttonOverrideEdit2";
            this.buttonOverrideEdit2.Size = new System.Drawing.Size(54, 23);
            this.buttonOverrideEdit2.TabIndex = 22;
            this.buttonOverrideEdit2.Text = "Edit...";
            this.buttonOverrideEdit2.UseVisualStyleBackColor = true;
            this.buttonOverrideEdit2.Click += new System.EventHandler(this.buttonOverrideEdit2_Click);
            // 
            // buttonOverrideEdit1
            // 
            this.buttonOverrideEdit1.Location = new System.Drawing.Point(531, 4);
            this.buttonOverrideEdit1.Name = "buttonOverrideEdit1";
            this.buttonOverrideEdit1.Size = new System.Drawing.Size(54, 23);
            this.buttonOverrideEdit1.TabIndex = 23;
            this.buttonOverrideEdit1.Text = "&Edit...";
            this.buttonOverrideEdit1.UseVisualStyleBackColor = true;
            this.buttonOverrideEdit1.Click += new System.EventHandler(this.buttonOverrideEdit1_Click);
            // 
            // buttonOverrideBrowse2
            // 
            this.buttonOverrideBrowse2.Location = new System.Drawing.Point(487, 31);
            this.buttonOverrideBrowse2.Name = "buttonOverrideBrowse2";
            this.buttonOverrideBrowse2.Size = new System.Drawing.Size(38, 23);
            this.buttonOverrideBrowse2.TabIndex = 20;
            this.buttonOverrideBrowse2.Text = "...";
            this.buttonOverrideBrowse2.UseVisualStyleBackColor = true;
            this.buttonOverrideBrowse2.Click += new System.EventHandler(this.buttonOverrideBrowse2_Click);
            // 
            // buttonOverrideBrowse1
            // 
            this.buttonOverrideBrowse1.Location = new System.Drawing.Point(487, 4);
            this.buttonOverrideBrowse1.Name = "buttonOverrideBrowse1";
            this.buttonOverrideBrowse1.Size = new System.Drawing.Size(38, 23);
            this.buttonOverrideBrowse1.TabIndex = 21;
            this.buttonOverrideBrowse1.Text = "...";
            this.buttonOverrideBrowse1.UseVisualStyleBackColor = true;
            this.buttonOverrideBrowse1.Click += new System.EventHandler(this.buttonOverrideBrowse1_Click);
            // 
            // textBoxOverrideLocation2
            // 
            this.textBoxOverrideLocation2.Location = new System.Drawing.Point(176, 33);
            this.textBoxOverrideLocation2.Name = "textBoxOverrideLocation2";
            this.textBoxOverrideLocation2.Size = new System.Drawing.Size(305, 20);
            this.textBoxOverrideLocation2.TabIndex = 19;
            // 
            // textBoxOverrideLocation1
            // 
            this.textBoxOverrideLocation1.Location = new System.Drawing.Point(176, 6);
            this.textBoxOverrideLocation1.Name = "textBoxOverrideLocation1";
            this.textBoxOverrideLocation1.Size = new System.Drawing.Size(305, 20);
            this.textBoxOverrideLocation1.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "2nd Override Dictionary Location";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "1st Override Dictionary Location";
            // 
            // buttonDictBrowse
            // 
            this.buttonDictBrowse.Location = new System.Drawing.Point(487, 57);
            this.buttonDictBrowse.Name = "buttonDictBrowse";
            this.buttonDictBrowse.Size = new System.Drawing.Size(38, 23);
            this.buttonDictBrowse.TabIndex = 15;
            this.buttonDictBrowse.Text = "...";
            this.buttonDictBrowse.UseVisualStyleBackColor = true;
            this.buttonDictBrowse.Click += new System.EventHandler(this.buttonDictBrowse_Click);
            // 
            // textBoxDictLocation
            // 
            this.textBoxDictLocation.Location = new System.Drawing.Point(176, 59);
            this.textBoxDictLocation.Name = "textBoxDictLocation";
            this.textBoxDictLocation.Size = new System.Drawing.Size(305, 20);
            this.textBoxDictLocation.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "CC-CEDICT File Location";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(283, 133);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 27;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(199, 133);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 26;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "UTF8 Dictionary|*.u8|All Files|*.*";
            // 
            // ChineseDict
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(598, 168);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonOverrideEdit2);
            this.Controls.Add(this.buttonOverrideEdit1);
            this.Controls.Add(this.buttonOverrideBrowse2);
            this.Controls.Add(this.buttonOverrideBrowse1);
            this.Controls.Add(this.textBoxOverrideLocation2);
            this.Controls.Add(this.textBoxOverrideLocation1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonDictBrowse);
            this.Controls.Add(this.textBoxDictLocation);
            this.Controls.Add(this.label1);
            this.Name = "ChineseDict";
            this.Text = "Chinese Dictionaries";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOverrideEdit2;
        private System.Windows.Forms.Button buttonOverrideEdit1;
        private System.Windows.Forms.Button buttonOverrideBrowse2;
        private System.Windows.Forms.Button buttonOverrideBrowse1;
        private System.Windows.Forms.TextBox textBoxOverrideLocation2;
        private System.Windows.Forms.TextBox textBoxOverrideLocation1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDictBrowse;
        private System.Windows.Forms.TextBox textBoxDictLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}