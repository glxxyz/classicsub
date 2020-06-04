namespace ClassicSub
{
    partial class AppendForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppendForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.maskedTextBoxSeekTime = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.seekShortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backwardSmallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardSmallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backwardMedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardMedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backwardBigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardBigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backward1mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forward1mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backward5mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forward5mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backward20mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forward20mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTimeHelp = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(127, 82);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(43, 82);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // maskedTextBoxSeekTime
            // 
            this.maskedTextBoxSeekTime.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxSeekTime.Location = new System.Drawing.Point(127, 45);
            this.maskedTextBoxSeekTime.Mask = "0:00:00.000";
            this.maskedTextBoxSeekTime.Name = "maskedTextBoxSeekTime";
            this.maskedTextBoxSeekTime.Size = new System.Drawing.Size(86, 22);
            this.maskedTextBoxSeekTime.TabIndex = 5;
            this.maskedTextBoxSeekTime.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBoxSeekTime_MaskInputRejected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Append offset:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seekShortcutsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(261, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // seekShortcutsToolStripMenuItem
            // 
            this.seekShortcutsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backwardSmallToolStripMenuItem,
            this.forwardSmallToolStripMenuItem,
            this.backwardMedToolStripMenuItem,
            this.forwardMedToolStripMenuItem,
            this.backwardBigToolStripMenuItem,
            this.forwardBigToolStripMenuItem,
            this.backward1mToolStripMenuItem,
            this.forward1mToolStripMenuItem,
            this.backward5mToolStripMenuItem,
            this.forward5mToolStripMenuItem,
            this.backward20mToolStripMenuItem,
            this.forward20mToolStripMenuItem});
            this.seekShortcutsToolStripMenuItem.Name = "seekShortcutsToolStripMenuItem";
            this.seekShortcutsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.seekShortcutsToolStripMenuItem.Text = "&Offsets";
            // 
            // backwardSmallToolStripMenuItem
            // 
            this.backwardSmallToolStripMenuItem.Name = "backwardSmallToolStripMenuItem";
            this.backwardSmallToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+,";
            this.backwardSmallToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemcomma)));
            this.backwardSmallToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.backwardSmallToolStripMenuItem.Text = "&Backward 1s";
            this.backwardSmallToolStripMenuItem.Click += new System.EventHandler(this.backwardSmallToolStripMenuItem_Click);
            // 
            // forwardSmallToolStripMenuItem
            // 
            this.forwardSmallToolStripMenuItem.Name = "forwardSmallToolStripMenuItem";
            this.forwardSmallToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+.";
            this.forwardSmallToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemPeriod)));
            this.forwardSmallToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.forwardSmallToolStripMenuItem.Text = "Forward &1s";
            this.forwardSmallToolStripMenuItem.Click += new System.EventHandler(this.forwardSmallToolStripMenuItem_Click);
            // 
            // backwardMedToolStripMenuItem
            // 
            this.backwardMedToolStripMenuItem.Name = "backwardMedToolStripMenuItem";
            this.backwardMedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.backwardMedToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.backwardMedToolStripMenuItem.Text = "B&ackward 5s";
            this.backwardMedToolStripMenuItem.Click += new System.EventHandler(this.backwardMedToolStripMenuItem_Click);
            // 
            // forwardMedToolStripMenuItem
            // 
            this.forwardMedToolStripMenuItem.Name = "forwardMedToolStripMenuItem";
            this.forwardMedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.forwardMedToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.forwardMedToolStripMenuItem.Text = "Forward &5s";
            this.forwardMedToolStripMenuItem.Click += new System.EventHandler(this.forwardMedToolStripMenuItem_Click);
            // 
            // backwardBigToolStripMenuItem
            // 
            this.backwardBigToolStripMenuItem.Name = "backwardBigToolStripMenuItem";
            this.backwardBigToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.backwardBigToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.backwardBigToolStripMenuItem.Text = "Ba&ckward 20s";
            this.backwardBigToolStripMenuItem.Click += new System.EventHandler(this.backwardBigToolStripMenuItem_Click);
            // 
            // forwardBigToolStripMenuItem
            // 
            this.forwardBigToolStripMenuItem.Name = "forwardBigToolStripMenuItem";
            this.forwardBigToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.forwardBigToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.forwardBigToolStripMenuItem.Text = "Forward &20s";
            this.forwardBigToolStripMenuItem.Click += new System.EventHandler(this.forwardBigToolStripMenuItem_Click);
            // 
            // backward1mToolStripMenuItem
            // 
            this.backward1mToolStripMenuItem.Name = "backward1mToolStripMenuItem";
            this.backward1mToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+,";
            this.backward1mToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Oemcomma)));
            this.backward1mToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.backward1mToolStripMenuItem.Text = "Bac&kward 1m";
            this.backward1mToolStripMenuItem.Click += new System.EventHandler(this.backward1mToolStripMenuItem_Click);
            // 
            // forward1mToolStripMenuItem
            // 
            this.forward1mToolStripMenuItem.Name = "forward1mToolStripMenuItem";
            this.forward1mToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+.";
            this.forward1mToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.OemPeriod)));
            this.forward1mToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.forward1mToolStripMenuItem.Text = "For&ward 1m";
            this.forward1mToolStripMenuItem.Click += new System.EventHandler(this.forward1mToolStripMenuItem_Click);
            // 
            // backward5mToolStripMenuItem
            // 
            this.backward5mToolStripMenuItem.Name = "backward5mToolStripMenuItem";
            this.backward5mToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Left)));
            this.backward5mToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.backward5mToolStripMenuItem.Text = "Backw&ard 5m";
            this.backward5mToolStripMenuItem.Click += new System.EventHandler(this.backward5mToolStripMenuItem_Click);
            // 
            // forward5mToolStripMenuItem
            // 
            this.forward5mToolStripMenuItem.Name = "forward5mToolStripMenuItem";
            this.forward5mToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Right)));
            this.forward5mToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.forward5mToolStripMenuItem.Text = "Forwa&rd 5m";
            this.forward5mToolStripMenuItem.Click += new System.EventHandler(this.forward5mToolStripMenuItem_Click);
            // 
            // backward20mToolStripMenuItem
            // 
            this.backward20mToolStripMenuItem.Name = "backward20mToolStripMenuItem";
            this.backward20mToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Up)));
            this.backward20mToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.backward20mToolStripMenuItem.Text = "Backwar&d 20m";
            this.backward20mToolStripMenuItem.Click += new System.EventHandler(this.backward20mToolStripMenuItem_Click);
            // 
            // forward20mToolStripMenuItem
            // 
            this.forward20mToolStripMenuItem.Name = "forward20mToolStripMenuItem";
            this.forward20mToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Down)));
            this.forward20mToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.forward20mToolStripMenuItem.Text = "Forward 20&m";
            this.forward20mToolStripMenuItem.Click += new System.EventHandler(this.forward20mToolStripMenuItem_Click);
            // 
            // labelTimeHelp
            // 
            this.labelTimeHelp.AutoSize = true;
            this.labelTimeHelp.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeHelp.Location = new System.Drawing.Point(127, 28);
            this.labelTimeHelp.Name = "labelTimeHelp";
            this.labelTimeHelp.Size = new System.Drawing.Size(84, 14);
            this.labelTimeHelp.TabIndex = 8;
            this.labelTimeHelp.Text = "h:mm:ss.ttt";
            // 
            // AppendForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(261, 112);
            this.Controls.Add(this.labelTimeHelp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBoxSeekTime);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AppendForm";
            this.Text = "Append";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxSeekTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem seekShortcutsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backwardSmallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardSmallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backwardMedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardMedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backwardBigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardBigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backward1mToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forward1mToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backward5mToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forward5mToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backward20mToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forward20mToolStripMenuItem;
        private System.Windows.Forms.Label labelTimeHelp;
    }
}