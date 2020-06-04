namespace ClassicSub
{
    partial class NudgeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NudgeForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.seekShortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backWardTinyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardTinyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.textBoxNudgeTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(159, 103);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(75, 103);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nudge Offset:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seekShortcutsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(289, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // seekShortcutsToolStripMenuItem
            // 
            this.seekShortcutsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backWardTinyToolStripMenuItem,
            this.forwardTinyToolStripMenuItem,
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
            this.seekShortcutsToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.seekShortcutsToolStripMenuItem.Text = "&Nudge Steps";
            // 
            // backWardTinyToolStripMenuItem
            // 
            this.backWardTinyToolStripMenuItem.Name = "backWardTinyToolStripMenuItem";
            this.backWardTinyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+-";
            this.backWardTinyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.backWardTinyToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.backWardTinyToolStripMenuItem.Text = "Backward &0.1s";
            this.backWardTinyToolStripMenuItem.Click += new System.EventHandler(this.backwardTinyToolStripMenuItem_Click);
            // 
            // forwardTinyToolStripMenuItem
            // 
            this.forwardTinyToolStripMenuItem.Name = "forwardTinyToolStripMenuItem";
            this.forwardTinyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+=";
            this.forwardTinyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.forwardTinyToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.forwardTinyToolStripMenuItem.Text = "Forward 0.1&s";
            this.forwardTinyToolStripMenuItem.Click += new System.EventHandler(this.forwardTinyToolStripMenuItem_Click);
            // 
            // backwardSmallToolStripMenuItem
            // 
            this.backwardSmallToolStripMenuItem.Name = "backwardSmallToolStripMenuItem";
            this.backwardSmallToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+,";
            this.backwardSmallToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemcomma)));
            this.backwardSmallToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.backwardSmallToolStripMenuItem.Text = "&Backward 1s";
            this.backwardSmallToolStripMenuItem.Click += new System.EventHandler(this.backwardSmallToolStripMenuItem_Click);
            // 
            // forwardSmallToolStripMenuItem
            // 
            this.forwardSmallToolStripMenuItem.Name = "forwardSmallToolStripMenuItem";
            this.forwardSmallToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+.";
            this.forwardSmallToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemPeriod)));
            this.forwardSmallToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.forwardSmallToolStripMenuItem.Text = "Forward &1s";
            this.forwardSmallToolStripMenuItem.Click += new System.EventHandler(this.forwardSmallToolStripMenuItem_Click);
            // 
            // backwardMedToolStripMenuItem
            // 
            this.backwardMedToolStripMenuItem.Name = "backwardMedToolStripMenuItem";
            this.backwardMedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.backwardMedToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.backwardMedToolStripMenuItem.Text = "B&ackward 5s";
            this.backwardMedToolStripMenuItem.Click += new System.EventHandler(this.backwardMedToolStripMenuItem_Click);
            // 
            // forwardMedToolStripMenuItem
            // 
            this.forwardMedToolStripMenuItem.Name = "forwardMedToolStripMenuItem";
            this.forwardMedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.forwardMedToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.forwardMedToolStripMenuItem.Text = "Forward &5s";
            this.forwardMedToolStripMenuItem.Click += new System.EventHandler(this.forwardMedToolStripMenuItem_Click);
            // 
            // backwardBigToolStripMenuItem
            // 
            this.backwardBigToolStripMenuItem.Name = "backwardBigToolStripMenuItem";
            this.backwardBigToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.backwardBigToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.backwardBigToolStripMenuItem.Text = "Ba&ckward 20s";
            this.backwardBigToolStripMenuItem.Click += new System.EventHandler(this.backwardBigToolStripMenuItem_Click);
            // 
            // forwardBigToolStripMenuItem
            // 
            this.forwardBigToolStripMenuItem.Name = "forwardBigToolStripMenuItem";
            this.forwardBigToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.forwardBigToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.forwardBigToolStripMenuItem.Text = "Forward &20s";
            this.forwardBigToolStripMenuItem.Click += new System.EventHandler(this.forwardBigToolStripMenuItem_Click);
            // 
            // backward1mToolStripMenuItem
            // 
            this.backward1mToolStripMenuItem.Name = "backward1mToolStripMenuItem";
            this.backward1mToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+,";
            this.backward1mToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.Oemcomma)));
            this.backward1mToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.backward1mToolStripMenuItem.Text = "Bac&kward 1m";
            this.backward1mToolStripMenuItem.Click += new System.EventHandler(this.backward1mToolStripMenuItem_Click);
            // 
            // forward1mToolStripMenuItem
            // 
            this.forward1mToolStripMenuItem.Name = "forward1mToolStripMenuItem";
            this.forward1mToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+.";
            this.forward1mToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.OemPeriod)));
            this.forward1mToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.forward1mToolStripMenuItem.Text = "For&ward 1m";
            this.forward1mToolStripMenuItem.Click += new System.EventHandler(this.forward1mToolStripMenuItem_Click);
            // 
            // backward5mToolStripMenuItem
            // 
            this.backward5mToolStripMenuItem.Name = "backward5mToolStripMenuItem";
            this.backward5mToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.Left)));
            this.backward5mToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.backward5mToolStripMenuItem.Text = "Backw&ard 5m";
            this.backward5mToolStripMenuItem.Click += new System.EventHandler(this.backward5mToolStripMenuItem_Click);
            // 
            // forward5mToolStripMenuItem
            // 
            this.forward5mToolStripMenuItem.Name = "forward5mToolStripMenuItem";
            this.forward5mToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.Right)));
            this.forward5mToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.forward5mToolStripMenuItem.Text = "Forwa&rd 5m";
            this.forward5mToolStripMenuItem.Click += new System.EventHandler(this.forward5mToolStripMenuItem_Click);
            // 
            // backward20mToolStripMenuItem
            // 
            this.backward20mToolStripMenuItem.Name = "backward20mToolStripMenuItem";
            this.backward20mToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.Up)));
            this.backward20mToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.backward20mToolStripMenuItem.Text = "Backwar&d 20m";
            this.backward20mToolStripMenuItem.Click += new System.EventHandler(this.backward20mToolStripMenuItem_Click);
            // 
            // forward20mToolStripMenuItem
            // 
            this.forward20mToolStripMenuItem.Name = "forward20mToolStripMenuItem";
            this.forward20mToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.Down)));
            this.forward20mToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.forward20mToolStripMenuItem.Text = "Forward 20&m";
            this.forward20mToolStripMenuItem.Click += new System.EventHandler(this.forward20mToolStripMenuItem_Click);
            // 
            // textBoxNudgeTime
            // 
            this.textBoxNudgeTime.Location = new System.Drawing.Point(135, 29);
            this.textBoxNudgeTime.Name = "textBoxNudgeTime";
            this.textBoxNudgeTime.Size = new System.Drawing.Size(77, 20);
            this.textBoxNudgeTime.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nudge will modify any Start/End cells that were selected";
            // 
            // NudgeForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(289, 138);
            this.Controls.Add(this.textBoxNudgeTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NudgeForm";
            this.Text = "Nudge";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
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
        private System.Windows.Forms.ToolStripMenuItem backWardTinyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardTinyToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxNudgeTime;
        private System.Windows.Forms.Label label2;
    }
}