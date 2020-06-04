namespace ClassicSub.Forms
{
    partial class ScaleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScaleForm));
            this.textBoxSubFirstRef = new System.Windows.Forms.TextBox();
            this.labelTimeHelp = new System.Windows.Forms.Label();
            this.textBoxSubSecondRef = new System.Windows.Forms.TextBox();
            this.textBoxMovieFirstRef = new System.Windows.Forms.TextBox();
            this.textBoxMovieSecondRef = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButtonSecondRef = new System.Windows.Forms.RadioButton();
            this.radioButtonFPS = new System.Windows.Forms.RadioButton();
            this.radioButtonRelative = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSubFPS = new System.Windows.Forms.TextBox();
            this.textBoxMovieFPS = new System.Windows.Forms.TextBox();
            this.textBoxSubRelative = new System.Windows.Forms.TextBox();
            this.textBoxMovieRelative = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonSelcted = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSubFirstRef
            // 
            this.textBoxSubFirstRef.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSubFirstRef.Location = new System.Drawing.Point(100, 50);
            this.textBoxSubFirstRef.Name = "textBoxSubFirstRef";
            this.textBoxSubFirstRef.Size = new System.Drawing.Size(94, 22);
            this.textBoxSubFirstRef.TabIndex = 10;
            this.textBoxSubFirstRef.Text = "0:00:00.000";
            this.textBoxSubFirstRef.TextChanged += new System.EventHandler(this.textBoxSubFirstRef_TextChanged);
            // 
            // labelTimeHelp
            // 
            this.labelTimeHelp.AutoSize = true;
            this.labelTimeHelp.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeHelp.Location = new System.Drawing.Point(100, 33);
            this.labelTimeHelp.Name = "labelTimeHelp";
            this.labelTimeHelp.Size = new System.Drawing.Size(84, 14);
            this.labelTimeHelp.TabIndex = 9;
            this.labelTimeHelp.Text = "h:mm:ss.ttt";
            // 
            // textBoxSubSecondRef
            // 
            this.textBoxSubSecondRef.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSubSecondRef.Location = new System.Drawing.Point(100, 106);
            this.textBoxSubSecondRef.Name = "textBoxSubSecondRef";
            this.textBoxSubSecondRef.Size = new System.Drawing.Size(94, 22);
            this.textBoxSubSecondRef.TabIndex = 10;
            this.textBoxSubSecondRef.Text = "0:00:00.000";
            this.textBoxSubSecondRef.TextChanged += new System.EventHandler(this.textBoxSubSecondRef_TextChanged);
            // 
            // textBoxMovieFirstRef
            // 
            this.textBoxMovieFirstRef.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMovieFirstRef.Location = new System.Drawing.Point(204, 50);
            this.textBoxMovieFirstRef.Name = "textBoxMovieFirstRef";
            this.textBoxMovieFirstRef.Size = new System.Drawing.Size(94, 22);
            this.textBoxMovieFirstRef.TabIndex = 10;
            this.textBoxMovieFirstRef.Text = "0:00:00.000";
            this.textBoxMovieFirstRef.TextChanged += new System.EventHandler(this.textBoxSubFirstRef_TextChanged);
            // 
            // textBoxMovieSecondRef
            // 
            this.textBoxMovieSecondRef.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMovieSecondRef.Location = new System.Drawing.Point(204, 106);
            this.textBoxMovieSecondRef.Name = "textBoxMovieSecondRef";
            this.textBoxMovieSecondRef.Size = new System.Drawing.Size(94, 22);
            this.textBoxMovieSecondRef.TabIndex = 10;
            this.textBoxMovieSecondRef.Text = "0:00:00.000";
            this.textBoxMovieSecondRef.TextChanged += new System.EventHandler(this.textBoxSubSecondRef_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "First Anchor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Subtitles";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Movie";
            // 
            // radioButtonSecondRef
            // 
            this.radioButtonSecondRef.AutoSize = true;
            this.radioButtonSecondRef.Checked = true;
            this.radioButtonSecondRef.Location = new System.Drawing.Point(15, 83);
            this.radioButtonSecondRef.Name = "radioButtonSecondRef";
            this.radioButtonSecondRef.Size = new System.Drawing.Size(99, 17);
            this.radioButtonSecondRef.TabIndex = 12;
            this.radioButtonSecondRef.TabStop = true;
            this.radioButtonSecondRef.Text = "Second Anchor";
            this.radioButtonSecondRef.UseVisualStyleBackColor = true;
            this.radioButtonSecondRef.CheckedChanged += new System.EventHandler(this.radioButtonSecondRef_CheckedChanged);
            // 
            // radioButtonFPS
            // 
            this.radioButtonFPS.AutoSize = true;
            this.radioButtonFPS.Location = new System.Drawing.Point(15, 143);
            this.radioButtonFPS.Name = "radioButtonFPS";
            this.radioButtonFPS.Size = new System.Drawing.Size(118, 17);
            this.radioButtonFPS.TabIndex = 12;
            this.radioButtonFPS.Text = "Frames Per Second";
            this.radioButtonFPS.UseVisualStyleBackColor = true;
            this.radioButtonFPS.CheckedChanged += new System.EventHandler(this.radioButtonFPS_CheckedChanged);
            // 
            // radioButtonRelative
            // 
            this.radioButtonRelative.AutoSize = true;
            this.radioButtonRelative.Location = new System.Drawing.Point(15, 194);
            this.radioButtonRelative.Name = "radioButtonRelative";
            this.radioButtonRelative.Size = new System.Drawing.Size(98, 17);
            this.radioButtonRelative.TabIndex = 12;
            this.radioButtonRelative.Text = "Relative Speed";
            this.radioButtonRelative.UseVisualStyleBackColor = true;
            this.radioButtonRelative.CheckedChanged += new System.EventHandler(this.radioButtonRelative_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(204, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "h:mm:ss.ttt";
            // 
            // textBoxSubFPS
            // 
            this.textBoxSubFPS.Enabled = false;
            this.textBoxSubFPS.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSubFPS.Location = new System.Drawing.Point(103, 166);
            this.textBoxSubFPS.Name = "textBoxSubFPS";
            this.textBoxSubFPS.Size = new System.Drawing.Size(94, 22);
            this.textBoxSubFPS.TabIndex = 10;
            this.textBoxSubFPS.Text = "23.97602";
            this.textBoxSubFPS.TextChanged += new System.EventHandler(this.textBoxSubFPS_TextChanged);
            // 
            // textBoxMovieFPS
            // 
            this.textBoxMovieFPS.Enabled = false;
            this.textBoxMovieFPS.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMovieFPS.Location = new System.Drawing.Point(207, 166);
            this.textBoxMovieFPS.Name = "textBoxMovieFPS";
            this.textBoxMovieFPS.Size = new System.Drawing.Size(94, 22);
            this.textBoxMovieFPS.TabIndex = 10;
            this.textBoxMovieFPS.Text = "23.97602";
            this.textBoxMovieFPS.TextChanged += new System.EventHandler(this.textBoxSubFPS_TextChanged);
            // 
            // textBoxSubRelative
            // 
            this.textBoxSubRelative.Enabled = false;
            this.textBoxSubRelative.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSubRelative.Location = new System.Drawing.Point(103, 217);
            this.textBoxSubRelative.Name = "textBoxSubRelative";
            this.textBoxSubRelative.Size = new System.Drawing.Size(94, 22);
            this.textBoxSubRelative.TabIndex = 10;
            this.textBoxSubRelative.Text = "1.0";
            this.textBoxSubRelative.TextChanged += new System.EventHandler(this.textBoxSubRelative_TextChanged);
            // 
            // textBoxMovieRelative
            // 
            this.textBoxMovieRelative.Enabled = false;
            this.textBoxMovieRelative.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMovieRelative.Location = new System.Drawing.Point(207, 217);
            this.textBoxMovieRelative.Name = "textBoxMovieRelative";
            this.textBoxMovieRelative.Size = new System.Drawing.Size(94, 22);
            this.textBoxMovieRelative.TabIndex = 10;
            this.textBoxMovieRelative.Text = "1.0";
            this.textBoxMovieRelative.TextChanged += new System.EventHandler(this.textBoxSubRelative_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonSelcted);
            this.groupBox1.Controls.Add(this.radioButtonAll);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 255);
            this.groupBox1.TabIndex = 13;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonRelative);
            this.groupBox2.Controls.Add(this.radioButtonFPS);
            this.groupBox2.Controls.Add(this.radioButtonSecondRef);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxMovieRelative);
            this.groupBox2.Controls.Add(this.textBoxMovieFPS);
            this.groupBox2.Controls.Add(this.textBoxSubRelative);
            this.groupBox2.Controls.Add(this.textBoxSubFPS);
            this.groupBox2.Controls.Add(this.textBoxSubSecondRef);
            this.groupBox2.Controls.Add(this.textBoxMovieSecondRef);
            this.groupBox2.Controls.Add(this.textBoxMovieFirstRef);
            this.groupBox2.Controls.Add(this.textBoxSubFirstRef);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelTimeHelp);
            this.groupBox2.Location = new System.Drawing.Point(153, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 255);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scale Formula";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(240, 278);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(156, 278);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // ScaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 312);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScaleForm";
            this.Text = "Scale";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSubFirstRef;
        private System.Windows.Forms.Label labelTimeHelp;
        private System.Windows.Forms.TextBox textBoxSubSecondRef;
        private System.Windows.Forms.TextBox textBoxMovieFirstRef;
        private System.Windows.Forms.TextBox textBoxMovieSecondRef;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButtonSecondRef;
        private System.Windows.Forms.RadioButton radioButtonFPS;
        private System.Windows.Forms.RadioButton radioButtonRelative;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSubFPS;
        private System.Windows.Forms.TextBox textBoxMovieFPS;
        private System.Windows.Forms.TextBox textBoxSubRelative;
        private System.Windows.Forms.TextBox textBoxMovieRelative;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonSelcted;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}