using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace WindowsShutdownHelper
{
    public partial class mainForm : Form
    {

        //geçici, dil sistemi gelene kadar kalacak
        public static string systemIdle = "systemIdle";
        public static string certainTime = "certainTime";
        public static string fromNow =    "fromNow";
        public static string lockComputer ="lockComputer";
        public static string sleepComputer = "sleepComputer";
        public static string turnOffMonitor = "turnOffMonitor";
        public static string shutdownComputer = "shutdownComputer";
        public static string restartComputer = "restartComputer";
        public static string logOffWindows = "logOffWindows";
        public static List<Action> actionList = new List<Action>();
        public static settings settings=new settings(); 
       public static Timer timer = new Timer();
        public static int runInTaskbarCounter=0;

        public mainForm()
        {
            InitializeComponent();
           


        }

        protected override void OnLoad(EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();


            foreach (var arg in args)

            {
                if (arg == "-runInTaskbar" && runInTaskbarCounter <= 0)
                {
                    ++runInTaskbarCounter;
                    Visible = false; 
                   
                }
            }

            base.OnLoad(e);
        }

        

        private void mainForm_Load(object sender, EventArgs e)
        {
            

            if (File.Exists("actionList.json")) actionList = JsonSerializer.Deserialize<List<Action>>(File.ReadAllText("actionList.json"));
             

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


            comboBox_actionType.Items.Add("Choose a task...");
            comboBox_actionType.Items.Add(shutdownComputer);
            comboBox_actionType.Items.Add(restartComputer);
            comboBox_actionType.Items.Add(logOffWindows);
            comboBox_actionType.Items.Add(sleepComputer);
            comboBox_actionType.Items.Add(lockComputer);
            comboBox_actionType.Items.Add(turnOffMonitor);
            comboBox_actionType.SelectedIndex = 0;

            comboBox_triggerType.Items.Add("Choose a trigger...");
            comboBox_triggerType.Items.Add(systemIdle);
            comboBox_triggerType .Items.Add(fromNow);
            comboBox_triggerType .Items.Add(certainTime);
            comboBox_triggerType.SelectedIndex = 0;

            notifyIcon_main.Text = "Windows Shutdown Helper is running in background";

            refreshActionList();
            addlistButtonEnabledOrDisabled();




        }
        

        public void refreshActionList()
        {
            dataGridView_taskList.DataSource = null;
            dataGridView_taskList.DataSource = actionList;
            dataGridView_taskList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_taskList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           
        }


        public void createNewAction(Action newAction)
        {
            if (comboBox_actionType.SelectedIndex == (int)enum_combobox_actionType.LockComputer) newAction.actionType = lockComputer;
            if (comboBox_actionType.SelectedIndex == (int)enum_combobox_actionType.LogOff) newAction.actionType = logOffWindows;
            if (comboBox_actionType.SelectedIndex == (int)enum_combobox_actionType.Restart) newAction.actionType = restartComputer;
            if (comboBox_actionType.SelectedIndex == (int)enum_combobox_actionType.Shutdown) newAction.actionType = shutdownComputer;
            if (comboBox_actionType.SelectedIndex == (int)enum_combobox_actionType.Sleep) newAction.actionType = sleepComputer;
            if (comboBox_actionType.SelectedIndex == (int)enum_combobox_actionType.TurnOffMonitor) newAction.actionType = turnOffMonitor;
        }

        
        public void addlistButtonEnabledOrDisabled()
        {
            if (actionList.Count > 4)
            {
                button_AddToList.Enabled = false;
                button_AddToList.Text = "Exceed limit: Delete an existing one to add a new one.";
            }
            if (actionList.Count < 5)
            {
                if (comboBox_actionType.SelectedIndex > 0 && comboBox_triggerType.SelectedIndex > 0)
                {
                    button_AddToList.Enabled = true;
                    button_AddToList.Text = "Add To Action List";
                }
                else
                {
                    button_AddToList.Enabled = false;
                    button_AddToList.Text = "Firstly, choose a action and trigger.";
                }
            }
        }

        public void writeJsonToActionList()
        {

            functions.jsonWriter.WriteJson("actionList.json", true, actionList);
            refreshActionList();
        }

        public enum enum_combobox_actionType
        {
            Shutdown=1,
            Restart=2,
            LogOff=3,
            Sleep=4,
            LockComputer=5,
            TurnOffMonitor=6

        }
        public enum enum_combobox_triggerType
        {
           SystemIdleTime = 1,
            FromNow = 2,
            CertainTime = 3,
  
        }

        public void doActions(Action action)
        {
            if (action.actionType == "lockComputer") functions.Actions.Lock.Computer();
            if (action.actionType == "sleepComputer") functions.Actions.Sleep.Computer();
            if (action.actionType == "turnOffMonitor") functions.Actions.TurnOff.Monitor();
            if (action.actionType == "shutdownComputer") functions.Actions.ShutdownComputer();
            if (action.actionType == "restartComputer") functions.Actions.RestartComputer();
            if (action.actionType == "logOffWindows") functions.Actions.LogOff.Windows();
        }


        private void timerTick(object sender, EventArgs e)
        {
            toolStripStatusLabel_CurrentTime.Text = "Current Time: " + DateTime.Now.ToString();

            uint idleTimeMin = functions.systemIdleDetector.GetLastInputTime();

            if (idleTimeMin == 0) timer.Stop(); timer.Start();





            foreach (var action in actionList.ToList())
            {

             if (action.triggerType == "systemIdle" && idleTimeMin == Convert.ToInt32(action.value)) doActions(action);     
             
             if (action.triggerType == "certainTime" && action.value == DateTime.Now.ToString("HH:mm:ss")) doActions(action);

             if (action.triggerType == "fromNow" && action.value == DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")) 
                {
                    doActions(action);
                    actionList.Remove(action);
                    writeJsonToActionList();
                }

            }//foreach






        }


        private void deleteAction()
        {
            
         
            
            if (dataGridView_taskList.Rows.Count > 0)
            {
                actionList.RemoveAt(dataGridView_taskList.CurrentCell.RowIndex);
               
                writeJsonToActionList();
            }

            addlistButtonEnabledOrDisabled();

        }


        private void trigger_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void button_AddToList_Click(object sender, EventArgs e)
        {
           
           
            
            if (actionList.Count < 5)
            {
                Action newAction = new Action();//fixed for all actions
                newAction.createdDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"); //fixed for all actions 
                DateTime now = DateTime.Now;  //fixed for all actions 

                if (comboBox_triggerType.SelectedIndex == (int)enum_combobox_triggerType.FromNow)
                {
                    newAction.triggerType = fromNow;
                    newAction.value = DateTime.Now.AddMinutes(Convert.ToDouble(numericUpDown_value.Value)).ToString("dd.MM.yyyy HH:mm:ss");

                    createNewAction(newAction);

                    
                }



                else if (comboBox_triggerType.SelectedIndex == (int)enum_combobox_triggerType.SystemIdleTime)
                {
                    newAction.triggerType = systemIdle;
                    newAction.value = numericUpDown_value.Value.ToString();

                    createNewAction(newAction);

                   
                }


               else if (comboBox_triggerType.SelectedIndex == (int)enum_combobox_triggerType.CertainTime)
                {
                    newAction.triggerType = certainTime;
                    newAction.value = dateTimePicker_time.Value.ToString("HH:mm:00");

                    createNewAction(newAction);

                }

                actionList.Add(newAction);

                writeJsonToActionList();

                addlistButtonEnabledOrDisabled();
            }// if (actionList.Count < 5)



        }

      

        private void comboBox_trigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_triggerType.SelectedIndex == 0 )
            {
                label_firstly_choose_a_trigger.Visible = true;
                numericUpDown_value.Visible = false;
                dateTimePicker_time.Visible = false;

            }
            if (comboBox_triggerType.SelectedIndex==1|| comboBox_triggerType.SelectedIndex==2)
            {
                label_firstly_choose_a_trigger.Visible = false;
                numericUpDown_value.Visible =true;
                dateTimePicker_time.Visible = false;
            }
            else if (comboBox_triggerType.SelectedIndex == 3)
            {
                label_firstly_choose_a_trigger.Visible = false;

                numericUpDown_value.Visible = false;
                dateTimePicker_time.Visible =true;
            }
            addlistButtonEnabledOrDisabled();
        }

        private void deleteSelectedTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteAction();

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

        private void comboBox_actionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            addlistButtonEnabledOrDisabled();
        }

        private void pictureBox_logs_Click(object sender, EventArgs e)
        {
            logViewer logViewerForm = new logViewer();
            this.Visible = false;
            logViewerForm .ShowDialog();
            this.Visible = true;

        }

        private void pictureBox_settings_Click(object sender, EventArgs e)
        {
            settingsForm settingsForm = new settingsForm();
            this.Visible = false;
            settingsForm.ShowDialog();
            this.Visible = true;
        }

        private void mainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon_main.Visible = true;
            }
        }

        private void notifyIcon_main_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
                if (File.Exists("settings.json"))
                {
                settings = JsonSerializer.Deserialize<settings>(File.ReadAllText("settings.json"));

                if (settings.runInTaskbarWhenClosed)
                    {
                    e.Cancel = true;
                    this.Hide();

                }



            }




        }

        private void exitTheProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void addNewActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm settingsForm = new settingsForm();
          
            settingsForm.Show();
          
        }

        private void showTheLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logViewer logViewerForm = new logViewer();
            logViewerForm.ShowDialog();
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            //    string[] args = Environment.GetCommandLineArgs();

            //    foreach (string param in args)
            //    {
            //        if (param == "-runInTaskBar")
            //        {
            //            this.Hide();
            //            notifyIcon_main.Visible = true;
            //        }



            //    } //foreach (string param in args)
        }

        private void mainForm_Activated(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();


            foreach (var arg in args)
                           
            {
                if (arg=="-runInTaskbar" && runInTaskbarCounter<=0)
                {
                    ++runInTaskbarCounter;
                    this.Hide();
                }
            }



        }// mainForm_Activated

        private void clearAllActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actionList.Clear();
            writeJsonToActionList();
            addlistButtonEnabledOrDisabled();
        }






        ////
    }
}
