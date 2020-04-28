using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace AutoShutdown
{
    public partial class mainForm : Form
    {

    
       
       public static List<Action> actionList = JsonSerializer.Deserialize<List<Action>>(File.ReadAllText("actionList.json"));
       public static int actionCounter = actionList.Count();
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

         

            dataGridView_taskList.DataSource = actionList;
            dataGridView_taskList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_taskList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
        }


 //////////////////////////////////////////////////////////////////////


	

        private void timerTick(object sender, EventArgs e)
        {
            toolStripStatusLabel_CurrentTime.Text = "Current Time: " + DateTime.Now.ToString();

            uint idleTimeMin = functions.systemIdleDetector.GetLastInputTime();

            if (idleTimeMin == 0) timer.Stop(); timer.Start();


            //if (set.task_1.triggerType == "systemIdle")
            //{
            //    if (second >= Convert.ToInt32(set.task_1.value)) functions.Tasks.TurnOffMonitor.Computer();
            //        //Tasks.Lock.Computer();
            //}


            foreach (var action in actionList)
            {
               
                if (action.triggerType == "systemIdle" && idleTimeMin == Convert.ToInt32(action.value))

                {
                    if (action.actionType == "lockComputer") functions.Actions.Lock.Computer();
                    if (action.actionType == "sleepComputer") functions.Actions.Sleep.Computer();
                    if (action.actionType == "turnOffMonitor") functions.Actions.TurnOff.Monitor();


                }


                if (action.triggerType == "certainTime" && DateTime.Now.ToString("HH:mm:ss") == action.value)

                {
                    if (action.actionType == "lockComputer") functions.Actions.Lock.Computer();
                    if (action.actionType == "sleepComputer") functions.Actions.Sleep.Computer();
                    if (action.actionType == "turnOffMonitor") functions.Actions.TurnOff.Monitor();


                }

            }




        }


        private void deleteTask(object sender, EventArgs e)
        {
            --actionCounter;
            foreach (var task in actionList)
            {
              
            }



        }

        ////////////////////////////////////////////////////////////////////////////////////

        private void button2_Click(object sender, EventArgs e)
        {
            //if (radioButton_systemIdleFor.Checked)
            //{
            
                //task task_1= new task();
                //task_1.createdDate = DateTime.Now.ToString();
                //task_1.triggerType = "systemIdle";
                //task_1.value = numericUpDown_value.Value.ToString();
                //set.task_1 = task_1;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                //var json = JsonSerializer.Serialize<setting>(set, options);
                //StreamWriter sw = new StreamWriter("settings.json", false);
                //sw.WriteLine(json); sw.Close();
                //string json = File.ReadAllText("en.json");
                //var en = JsonSerializer.Deserialize<lang_English>(json);
            //}
        }

        private void trigger_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void button_AddToList_Click(object sender, EventArgs e)
        {
           
            ++actionCounter;

            if (actionCounter <= 5)
            {


                var json = JsonSerializer.Serialize(actionList);

                MessageBox.Show(json);

            }

            else

            {
                string maxTaskWarn = "You can maximum 5 task";
                string maxTaskWarnTitle = "Maximum Task";
                MessageBox.Show(maxTaskWarn, maxTaskWarnTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

      

        private void comboBox_trigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_trigger.SelectedIndex == 0 )
            {
                label_firstly_choose_a_trigger.Visible = true;
                numericUpDown_value.Visible = false;
                dateTimePicker_time.Visible = false;

            }
            if (comboBox_trigger.SelectedIndex==1|| comboBox_trigger.SelectedIndex==2)
            {
                label_firstly_choose_a_trigger.Visible = false;
                numericUpDown_value.Visible =true;
                dateTimePicker_time.Visible = false;
            }
            else if (comboBox_trigger.SelectedIndex == 3)
            {
                label_firstly_choose_a_trigger.Visible = false;

                numericUpDown_value.Visible = false;
                dateTimePicker_time.Visible =true;
            }

        }

        private void deleteSelectedTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_taskList.Rows.Count > 0)
            {
                actionList.RemoveAt(dataGridView_taskList.CurrentCell.RowIndex);
                dataGridView_taskList.DataSource = null;
                dataGridView_taskList.DataSource = actionList;
                dataGridView_taskList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView_taskList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }

        }

        private void dataGridView_taskList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_taskList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView_taskList.Rows.Count > 0)
            {

                dataGridView_taskList.ContextMenuStrip = contextMenuStrip_mainGrid;
            }

        }

        private void dataGridView_taskList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGridView_taskList.Rows.Count == 0)
            {

                dataGridView_taskList.ContextMenuStrip =null;
            }
        }













        ////
    }
}
