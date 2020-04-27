using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;

namespace AutoShutdown
{
    public partial class mainForm : Form
    {
       

        public static setting set = JsonSerializer.Deserialize<setting>(File.ReadAllText("settings.json"));
       public static List<task> taskList = new List<task>();
       public static Timer timer = new Timer();



        public mainForm()
        {
            InitializeComponent();
        }

        /////////////////////////////////////////////

        private void mainForm_Load(object sender, EventArgs e)
        {
            
            timer.Interval = (1000); // 1 sec
            timer.Tick += timerTick;
            timer.Start();
            
            
            //lang_English en = new lang_English();
            //triggerTabPage t = new triggerTabPage();

            //t.pageName = "Adım 1";
            //t.systemIdleForMin = "Boşta Kalan Zaman";
            //t.inFromNow = "Şuandan itibaren (dk):";
            //en.triggerTabPage = t;


            
            //string json = File.ReadAllText("en.json");
            //var en = JsonSerializer.Deserialize<lang_English>(json);
            //button1.Text = en.triggerTabPage.systemIdleForMin;


            comboBox_taskType.Items.Add("Choose a task...");
            comboBox_taskType.Items.Add("Shutdown");
            comboBox_taskType.Items.Add("Restart");
            comboBox_taskType.Items.Add("Log off");
            comboBox_taskType.Items.Add("Sleep");
            comboBox_taskType.Items.Add("Lock Computer");
            comboBox_taskType.Items.Add("Turn off Monitor");
            comboBox_taskType.SelectedIndex = 0;

            comboBox_trigger.Items.Add("Choose a trigger...");
            comboBox_trigger.Items.Add("System Idle Time");
            comboBox_trigger .Items.Add("From Now");
            comboBox_trigger .Items.Add("Certain Time (Everyday)");
            comboBox_trigger.SelectedIndex = 0;

            if (set.task_1 != null) taskList.Add(set.task_1);
            if (set.task_2 != null) taskList.Add(set.task_2);
            if (set.task_3 != null) taskList.Add(set.task_3);
            if (set.task_4 != null) taskList.Add(set.task_4);
            if (set.task_5 != null) taskList.Add(set.task_5);

            dataGridView_taskList.DataSource = taskList;
            dataGridView_taskList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           dataGridView_taskList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }


 //////////////////////////////////////////////////////////////////////


	

        private void timerTick(object sender, EventArgs e)
        {
           

            uint second = systemIdleDetector.GetLastInputTime();

            if (second == 0) timer.Stop(); timer.Start();


            if (set.task_1.triggerType == "systemIdle")
            {
                if (second >= Convert.ToInt32(set.task_1.value)) Tasks.TurnOffMonitor.Computer();
                    //Tasks.Lock.Computer();
            }

            




            toolStripStatusLabel_CurrentTime.Text = "Current Time: " + DateTime.Now.ToString();
        }


        private void deleteTask(object sender, EventArgs e)
        {

            if (taskList.Count() == 1)
            {
                task task_1 = new task();
                task_1.createdDate = DateTime.Now.ToString();
                task_1.triggerType = "systemIdle";
                task_1.value = numericUpDown_value.Value.ToString();

            }
            if (taskList.Count() == 2)
            {

            }

            if (taskList.Count() == 3)
            {

            }
            if (taskList.Count() == 4)
            {

            }
    

        }

        ////////////////////////////////////////////////////////////////////////////////////

        private void button2_Click(object sender, EventArgs e)
        {
            //if (radioButton_systemIdleFor.Checked)
            //{
            
                task task_1= new task();
                task_1.createdDate = DateTime.Now.ToString();
                task_1.triggerType = "systemIdle";
                task_1.value = numericUpDown_value.Value.ToString();
                set.task_1 = task_1;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                var json = JsonSerializer.Serialize<setting>(set, options);
                StreamWriter sw = new StreamWriter("settings.json", false);
                sw.WriteLine(json); sw.Close();
                //string json = File.ReadAllText("en.json");
                //var en = JsonSerializer.Deserialize<lang_English>(json);
            //}
        }

        private void trigger_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void button_AddToList_Click(object sender, EventArgs e)
        {
            MessageBox.Show(taskList.Count().ToString());
        }

      

        private void comboBox_trigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_trigger.SelectedIndex == 0 )
            {
                label_firstly_choose_a_trigger.Visible = true;
                numericUpDown_value.Visible = false;
                dateTimePicker_date.Visible = false;
                dateTimePicker_time.Visible = false;

            }
            if (comboBox_trigger.SelectedIndex==1|| comboBox_trigger.SelectedIndex==2)
            {
                label_firstly_choose_a_trigger.Visible = false;
                numericUpDown_value.Visible =true;
                dateTimePicker_date.Visible = false;
                dateTimePicker_time.Visible = false;
            }
            else if (comboBox_trigger.SelectedIndex == 3)
            {
                label_firstly_choose_a_trigger.Visible = false;

                numericUpDown_value.Visible = false;
                dateTimePicker_date.Visible = true;
                dateTimePicker_time.Visible =true;
            }

        }












        ////
    }
}
