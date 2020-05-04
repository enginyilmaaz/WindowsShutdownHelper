namespace WindowsShutdownHelper
{
    partial class actionCountdownNotifier
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
            this.label_content = new System.Windows.Forms.Label();
            this.panel_main = new System.Windows.Forms.Panel();
            this.button_skip = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.label_title = new System.Windows.Forms.Label();
            this.pictureBox_main = new System.Windows.Forms.PictureBox();
            this.panel_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).BeginInit();
            this.SuspendLayout();
            // 
            // label_content
            // 
            this.label_content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_content.Location = new System.Drawing.Point(11, 60);
            this.label_content.Name = "label_content";
            this.label_content.Size = new System.Drawing.Size(450, 160);
            this.label_content.TabIndex = 0;
            this.label_content.Text = "label_content";
            this.label_content.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel_main
            // 
            this.panel_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_main.Controls.Add(this.button_skip);
            this.panel_main.Controls.Add(this.button_delete);
            this.panel_main.Controls.Add(this.button_OK);
            this.panel_main.Controls.Add(this.label_title);
            this.panel_main.Controls.Add(this.pictureBox_main);
            this.panel_main.Controls.Add(this.label_content);
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(474, 267);
            this.panel_main.TabIndex = 1;
            this.panel_main.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button_skip
            // 
            this.button_skip.Enabled = false;
            this.button_skip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_skip.Location = new System.Drawing.Point(310, 223);
            this.button_skip.Name = "button_skip";
            this.button_skip.Size = new System.Drawing.Size(136, 31);
            this.button_skip.TabIndex = 5;
            this.button_skip.Text = "Skip";
            this.button_skip.UseVisualStyleBackColor = true;
            // 
            // button_delete
            // 
            this.button_delete.Enabled = false;
            this.button_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_delete.Location = new System.Drawing.Point(26, 223);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(136, 31);
            this.button_delete.TabIndex = 4;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_OK
            // 
            this.button_OK.Enabled = false;
            this.button_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_OK.Location = new System.Drawing.Point(168, 223);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(136, 31);
            this.button_OK.TabIndex = 3;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label_title
            // 
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_title.Location = new System.Drawing.Point(225, 8);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(142, 37);
            this.label_title.TabIndex = 2;
            this.label_title.Text = "label_title";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox_main
            // 
            this.pictureBox_main.Image = global::WindowsShutdownHelper.Properties.Resources.success;
            this.pictureBox_main.Location = new System.Drawing.Point(121, 8);
            this.pictureBox_main.Name = "pictureBox_main";
            this.pictureBox_main.Size = new System.Drawing.Size(83, 37);
            this.pictureBox_main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_main.TabIndex = 1;
            this.pictureBox_main.TabStop = false;
            // 
            // actionCountdownNotifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 267);
            this.Controls.Add(this.panel_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "actionCountdownNotifier";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "popUpViewer";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.actionCountdownNotifier_Load);
            this.panel_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_content;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.PictureBox pictureBox_main;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_skip;
        private System.Windows.Forms.Button button_delete;
    }
}