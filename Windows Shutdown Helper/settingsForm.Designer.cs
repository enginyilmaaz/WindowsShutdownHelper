namespace WindowsShutdownHelper
{
    partial class settingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.label_logs = new System.Windows.Forms.Label();
            this.label_startWithWindows = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.checkBox_logEnabled = new System.Windows.Forms.CheckBox();
            this.checkBox_startWithWindowsEnabled = new System.Windows.Forms.CheckBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label_runInTaskbarWhenClosed = new System.Windows.Forms.Label();
            this.checkBox_runInTaskbarWhenClosed = new System.Windows.Forms.CheckBox();
            this.checkBox_isCountdownNotifierEnabled = new System.Windows.Forms.CheckBox();
            this.label_isCountdownNotifierEnabled = new System.Windows.Forms.Label();
            this.label_countdownNotifierSeconds = new System.Windows.Forms.Label();
            this.numericUpDown_countdownNotifierSeconds = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_countdownNotifierSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // label_logs
            // 
            this.label_logs.AutoSize = true;
            this.label_logs.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_logs.Location = new System.Drawing.Point(25, 21);
            this.label_logs.Name = "label_logs";
            this.label_logs.Size = new System.Drawing.Size(110, 22);
            this.label_logs.TabIndex = 0;
            this.label_logs.Text = "Record Logs:";
            // 
            // label_startWithWindows
            // 
            this.label_startWithWindows.AutoSize = true;
            this.label_startWithWindows.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_startWithWindows.Location = new System.Drawing.Point(25, 65);
            this.label_startWithWindows.Name = "label_startWithWindows";
            this.label_startWithWindows.Size = new System.Drawing.Size(148, 22);
            this.label_startWithWindows.TabIndex = 0;
            this.label_startWithWindows.Text = "StartwithWindows";
            // 
            // button_save
            // 
            this.button_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_save.Location = new System.Drawing.Point(63, 258);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(133, 39);
            this.button_save.TabIndex = 6;
            this.button_save.Text = "save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // checkBox_logEnabled
            // 
            this.checkBox_logEnabled.AutoSize = true;
            this.checkBox_logEnabled.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox_logEnabled.Location = new System.Drawing.Point(316, 20);
            this.checkBox_logEnabled.Name = "checkBox_logEnabled";
            this.checkBox_logEnabled.Size = new System.Drawing.Size(87, 26);
            this.checkBox_logEnabled.TabIndex = 1;
            this.checkBox_logEnabled.Text = "Enabled";
            this.checkBox_logEnabled.UseVisualStyleBackColor = true;
            // 
            // checkBox_startWithWindowsEnabled
            // 
            this.checkBox_startWithWindowsEnabled.AutoSize = true;
            this.checkBox_startWithWindowsEnabled.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox_startWithWindowsEnabled.Location = new System.Drawing.Point(316, 64);
            this.checkBox_startWithWindowsEnabled.Name = "checkBox_startWithWindowsEnabled";
            this.checkBox_startWithWindowsEnabled.Size = new System.Drawing.Size(87, 26);
            this.checkBox_startWithWindowsEnabled.TabIndex = 2;
            this.checkBox_startWithWindowsEnabled.Text = "Enabled";
            this.checkBox_startWithWindowsEnabled.UseVisualStyleBackColor = true;
            // 
            // button_cancel
            // 
            this.button_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_cancel.Location = new System.Drawing.Point(230, 258);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(131, 39);
            this.button_cancel.TabIndex = 7;
            this.button_cancel.Text = "cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label_runInTaskbarWhenClosed
            // 
            this.label_runInTaskbarWhenClosed.AutoSize = true;
            this.label_runInTaskbarWhenClosed.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_runInTaskbarWhenClosed.Location = new System.Drawing.Point(25, 109);
            this.label_runInTaskbarWhenClosed.Name = "label_runInTaskbarWhenClosed";
            this.label_runInTaskbarWhenClosed.Size = new System.Drawing.Size(196, 22);
            this.label_runInTaskbarWhenClosed.TabIndex = 0;
            this.label_runInTaskbarWhenClosed.Text = "runInTaskbarWhenClosed";
            // 
            // checkBox_runInTaskbarWhenClosed
            // 
            this.checkBox_runInTaskbarWhenClosed.AutoSize = true;
            this.checkBox_runInTaskbarWhenClosed.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox_runInTaskbarWhenClosed.Location = new System.Drawing.Point(316, 108);
            this.checkBox_runInTaskbarWhenClosed.Name = "checkBox_runInTaskbarWhenClosed";
            this.checkBox_runInTaskbarWhenClosed.Size = new System.Drawing.Size(87, 26);
            this.checkBox_runInTaskbarWhenClosed.TabIndex = 3;
            this.checkBox_runInTaskbarWhenClosed.Text = "Enabled";
            this.checkBox_runInTaskbarWhenClosed.UseVisualStyleBackColor = true;
            // 
            // checkBox_isCountdownNotifierEnabled
            // 
            this.checkBox_isCountdownNotifierEnabled.AutoSize = true;
            this.checkBox_isCountdownNotifierEnabled.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox_isCountdownNotifierEnabled.Location = new System.Drawing.Point(316, 196);
            this.checkBox_isCountdownNotifierEnabled.Name = "checkBox_isCountdownNotifierEnabled";
            this.checkBox_isCountdownNotifierEnabled.Size = new System.Drawing.Size(87, 26);
            this.checkBox_isCountdownNotifierEnabled.TabIndex = 5;
            this.checkBox_isCountdownNotifierEnabled.Text = "Enabled";
            this.checkBox_isCountdownNotifierEnabled.UseVisualStyleBackColor = true;
            // 
            // label_isCountdownNotifierEnabled
            // 
            this.label_isCountdownNotifierEnabled.AutoSize = true;
            this.label_isCountdownNotifierEnabled.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_isCountdownNotifierEnabled.Location = new System.Drawing.Point(25, 197);
            this.label_isCountdownNotifierEnabled.Name = "label_isCountdownNotifierEnabled";
            this.label_isCountdownNotifierEnabled.Size = new System.Drawing.Size(225, 22);
            this.label_isCountdownNotifierEnabled.TabIndex = 0;
            this.label_isCountdownNotifierEnabled.Text = "isCountdownNotifierEnabled";
            // 
            // label_countdownNotifierSeconds
            // 
            this.label_countdownNotifierSeconds.AutoSize = true;
            this.label_countdownNotifierSeconds.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_countdownNotifierSeconds.Location = new System.Drawing.Point(25, 153);
            this.label_countdownNotifierSeconds.Name = "label_countdownNotifierSeconds";
            this.label_countdownNotifierSeconds.Size = new System.Drawing.Size(215, 22);
            this.label_countdownNotifierSeconds.TabIndex = 0;
            this.label_countdownNotifierSeconds.Text = "countdownNotifierSeconds";
            // 
            // numericUpDown_countdownNotifierSeconds
            // 
            this.numericUpDown_countdownNotifierSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numericUpDown_countdownNotifierSeconds.Location = new System.Drawing.Point(316, 152);
            this.numericUpDown_countdownNotifierSeconds.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown_countdownNotifierSeconds.Name = "numericUpDown_countdownNotifierSeconds";
            this.numericUpDown_countdownNotifierSeconds.Size = new System.Drawing.Size(79, 26);
            this.numericUpDown_countdownNotifierSeconds.TabIndex = 4;
            this.numericUpDown_countdownNotifierSeconds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown_countdownNotifierSeconds_KeyPress);
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 325);
            this.Controls.Add(this.numericUpDown_countdownNotifierSeconds);
            this.Controls.Add(this.label_countdownNotifierSeconds);
            this.Controls.Add(this.checkBox_isCountdownNotifierEnabled);
            this.Controls.Add(this.label_isCountdownNotifierEnabled);
            this.Controls.Add(this.checkBox_runInTaskbarWhenClosed);
            this.Controls.Add(this.label_runInTaskbarWhenClosed);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.checkBox_startWithWindowsEnabled);
            this.Controls.Add(this.checkBox_logEnabled);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label_startWithWindows);
            this.Controls.Add(this.label_logs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "settingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.settingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_countdownNotifierSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_logs;
        private System.Windows.Forms.Label label_startWithWindows;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.CheckBox checkBox_logEnabled;
        private System.Windows.Forms.CheckBox checkBox_startWithWindowsEnabled;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label_runInTaskbarWhenClosed;
        private System.Windows.Forms.CheckBox checkBox_runInTaskbarWhenClosed;
        private System.Windows.Forms.CheckBox checkBox_isCountdownNotifierEnabled;
        private System.Windows.Forms.Label label_isCountdownNotifierEnabled;
        private System.Windows.Forms.Label label_countdownNotifierSeconds;
        private System.Windows.Forms.NumericUpDown numericUpDown_countdownNotifierSeconds;
    }
}