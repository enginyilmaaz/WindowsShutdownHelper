namespace WindowsShutdownHelper
{
    partial class logViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(logViewer));
            this.dataGridView_logs = new System.Windows.Forms.DataGridView();
            this.button_clearLogs = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_logs)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_logs
            // 
            this.dataGridView_logs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_logs.Location = new System.Drawing.Point(2, 1);
            this.dataGridView_logs.Name = "dataGridView_logs";
            this.dataGridView_logs.Size = new System.Drawing.Size(606, 382);
            this.dataGridView_logs.TabIndex = 0;
            // 
            // button_clearLogs
            // 
            this.button_clearLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_clearLogs.Location = new System.Drawing.Point(99, 396);
            this.button_clearLogs.Name = "button_clearLogs";
            this.button_clearLogs.Size = new System.Drawing.Size(174, 30);
            this.button_clearLogs.TabIndex = 1;
            this.button_clearLogs.Text = "Clear Logs";
            this.button_clearLogs.UseVisualStyleBackColor = true;
            this.button_clearLogs.Click += new System.EventHandler(this.button_clearLogs_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_cancel.Location = new System.Drawing.Point(290, 396);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(219, 30);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // logViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 450);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_clearLogs);
            this.Controls.Add(this.dataGridView_logs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "logViewer";
            this.Text = "Log Viewer";
            this.Load += new System.EventHandler(this.logViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_logs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_logs;
        private System.Windows.Forms.Button button_clearLogs;
        private System.Windows.Forms.Button button_cancel;
    }
}