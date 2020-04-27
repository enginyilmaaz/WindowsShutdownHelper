namespace AutoShutdown
{
    partial class mainForm
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
            this.numericUpDown_value = new System.Windows.Forms.NumericUpDown();
            this.comboBox_taskType = new System.Windows.Forms.ComboBox();
            this.label_taskType = new System.Windows.Forms.Label();
            this.statusStrip_default = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_CurrentTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView_taskList = new System.Windows.Forms.DataGridView();
            this.label_taskList = new System.Windows.Forms.Label();
            this.button_AddToList = new System.Windows.Forms.Button();
            this.label_trigger = new System.Windows.Forms.Label();
            this.comboBox_trigger = new System.Windows.Forms.ComboBox();
            this.label_value = new System.Windows.Forms.Label();
            this.dateTimePicker_date = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_time = new System.Windows.Forms.DateTimePicker();
            this.label_firstly_choose_a_trigger = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_value)).BeginInit();
            this.statusStrip_default.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_taskList)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown_value
            // 
            this.numericUpDown_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numericUpDown_value.Location = new System.Drawing.Point(173, 116);
            this.numericUpDown_value.Name = "numericUpDown_value";
            this.numericUpDown_value.Size = new System.Drawing.Size(257, 24);
            this.numericUpDown_value.TabIndex = 2;
            this.numericUpDown_value.Visible = false;
            // 
            // comboBox_taskType
            // 
            this.comboBox_taskType.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox_taskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_taskType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_taskType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox_taskType.FormattingEnabled = true;
            this.comboBox_taskType.Location = new System.Drawing.Point(173, 28);
            this.comboBox_taskType.Name = "comboBox_taskType";
            this.comboBox_taskType.Size = new System.Drawing.Size(257, 26);
            this.comboBox_taskType.TabIndex = 5;
            // 
            // label_taskType
            // 
            this.label_taskType.AutoSize = true;
            this.label_taskType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_taskType.Location = new System.Drawing.Point(37, 31);
            this.label_taskType.Name = "label_taskType";
            this.label_taskType.Size = new System.Drawing.Size(81, 18);
            this.label_taskType.TabIndex = 7;
            this.label_taskType.Text = "taskType:";
            // 
            // statusStrip_default
            // 
            this.statusStrip_default.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_CurrentTime});
            this.statusStrip_default.Location = new System.Drawing.Point(0, 443);
            this.statusStrip_default.Name = "statusStrip_default";
            this.statusStrip_default.Size = new System.Drawing.Size(492, 22);
            this.statusStrip_default.TabIndex = 8;
            this.statusStrip_default.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_CurrentTime
            // 
            this.toolStripStatusLabel_CurrentTime.Name = "toolStripStatusLabel_CurrentTime";
            this.toolStripStatusLabel_CurrentTime.Size = new System.Drawing.Size(73, 17);
            this.toolStripStatusLabel_CurrentTime.Text = "CurrentTime";
            // 
            // dataGridView_taskList
            // 
            this.dataGridView_taskList.AllowUserToAddRows = false;
            this.dataGridView_taskList.AllowUserToDeleteRows = false;
            this.dataGridView_taskList.AllowUserToResizeColumns = false;
            this.dataGridView_taskList.AllowUserToResizeRows = false;
            this.dataGridView_taskList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_taskList.Location = new System.Drawing.Point(40, 244);
            this.dataGridView_taskList.Name = "dataGridView_taskList";
            this.dataGridView_taskList.ReadOnly = true;
            this.dataGridView_taskList.RowHeadersVisible = false;
            this.dataGridView_taskList.Size = new System.Drawing.Size(390, 171);
            this.dataGridView_taskList.TabIndex = 9;
            // 
            // label_taskList
            // 
            this.label_taskList.AutoSize = true;
            this.label_taskList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_taskList.Location = new System.Drawing.Point(37, 214);
            this.label_taskList.Name = "label_taskList";
            this.label_taskList.Size = new System.Drawing.Size(77, 18);
            this.label_taskList.TabIndex = 10;
            this.label_taskList.Text = "task List:";
            // 
            // button_AddToList
            // 
            this.button_AddToList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_AddToList.Location = new System.Drawing.Point(173, 167);
            this.button_AddToList.Name = "button_AddToList";
            this.button_AddToList.Size = new System.Drawing.Size(257, 28);
            this.button_AddToList.TabIndex = 12;
            this.button_AddToList.Text = "Add To List";
            this.button_AddToList.UseVisualStyleBackColor = true;
            this.button_AddToList.Click += new System.EventHandler(this.button_AddToList_Click);
            // 
            // label_trigger
            // 
            this.label_trigger.AutoSize = true;
            this.label_trigger.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_trigger.Location = new System.Drawing.Point(37, 75);
            this.label_trigger.Name = "label_trigger";
            this.label_trigger.Size = new System.Drawing.Size(66, 18);
            this.label_trigger.TabIndex = 14;
            this.label_trigger.Text = "trigger: ";
            // 
            // comboBox_trigger
            // 
            this.comboBox_trigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_trigger.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox_trigger.FormattingEnabled = true;
            this.comboBox_trigger.Location = new System.Drawing.Point(173, 72);
            this.comboBox_trigger.Name = "comboBox_trigger";
            this.comboBox_trigger.Size = new System.Drawing.Size(257, 26);
            this.comboBox_trigger.TabIndex = 13;
            this.comboBox_trigger.SelectedIndexChanged += new System.EventHandler(this.comboBox_trigger_SelectedIndexChanged);
            // 
            // label_value
            // 
            this.label_value.AutoSize = true;
            this.label_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_value.Location = new System.Drawing.Point(37, 118);
            this.label_value.Name = "label_value";
            this.label_value.Size = new System.Drawing.Size(57, 18);
            this.label_value.TabIndex = 15;
            this.label_value.Text = "value: ";
            // 
            // dateTimePicker_date
            // 
            this.dateTimePicker_date.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker_date.CustomFormat = "dd MMMM yyyy";
            this.dateTimePicker_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_date.Location = new System.Drawing.Point(173, 116);
            this.dateTimePicker_date.Name = "dateTimePicker_date";
            this.dateTimePicker_date.Size = new System.Drawing.Size(179, 24);
            this.dateTimePicker_date.TabIndex = 16;
            this.dateTimePicker_date.Visible = false;
            // 
            // dateTimePicker_time
            // 
            this.dateTimePicker_time.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker_time.CustomFormat = "HH:mm";
            this.dateTimePicker_time.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePicker_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker_time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_time.Location = new System.Drawing.Point(358, 116);
            this.dateTimePicker_time.Name = "dateTimePicker_time";
            this.dateTimePicker_time.ShowUpDown = true;
            this.dateTimePicker_time.Size = new System.Drawing.Size(72, 24);
            this.dateTimePicker_time.TabIndex = 17;
            this.dateTimePicker_time.Visible = false;
            // 
            // label_firstly_choose_a_trigger
            // 
            this.label_firstly_choose_a_trigger.AutoSize = true;
            this.label_firstly_choose_a_trigger.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_firstly_choose_a_trigger.Location = new System.Drawing.Point(184, 118);
            this.label_firstly_choose_a_trigger.Name = "label_firstly_choose_a_trigger";
            this.label_firstly_choose_a_trigger.Size = new System.Drawing.Size(207, 18);
            this.label_firstly_choose_a_trigger.TabIndex = 18;
            this.label_firstly_choose_a_trigger.Text = "Firstly, choose a trigger... ";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 465);
            this.Controls.Add(this.label_firstly_choose_a_trigger);
            this.Controls.Add(this.dateTimePicker_time);
            this.Controls.Add(this.dateTimePicker_date);
            this.Controls.Add(this.label_value);
            this.Controls.Add(this.label_trigger);
            this.Controls.Add(this.comboBox_trigger);
            this.Controls.Add(this.button_AddToList);
            this.Controls.Add(this.label_taskList);
            this.Controls.Add(this.numericUpDown_value);
            this.Controls.Add(this.dataGridView_taskList);
            this.Controls.Add(this.statusStrip_default);
            this.Controls.Add(this.label_taskType);
            this.Controls.Add(this.comboBox_taskType);
            this.Name = "mainForm";
            this.Text = "System Shutdown Manager";
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_value)).EndInit();
            this.statusStrip_default.ResumeLayout(false);
            this.statusStrip_default.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_taskList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDown_value;
        private System.Windows.Forms.ComboBox comboBox_taskType;
        private System.Windows.Forms.Label label_taskType;
        private System.Windows.Forms.StatusStrip statusStrip_default;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_CurrentTime;
        private System.Windows.Forms.DataGridView dataGridView_taskList;
        private System.Windows.Forms.Label label_taskList;
        private System.Windows.Forms.Button button_AddToList;
        private System.Windows.Forms.Label label_trigger;
        private System.Windows.Forms.ComboBox comboBox_trigger;
        private System.Windows.Forms.Label label_value;
        private System.Windows.Forms.DateTimePicker dateTimePicker_date;
        private System.Windows.Forms.DateTimePicker dateTimePicker_time;
        private System.Windows.Forms.Label label_firstly_choose_a_trigger;
    }
}