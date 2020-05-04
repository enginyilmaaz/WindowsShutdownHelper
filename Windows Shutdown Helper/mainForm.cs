using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using WindowsShutdownHelper.functions;
using WindowsShutdownHelper.Properties;

namespace WindowsShutdownHelper
{
    public partial class mainForm : Form
    {
        public enum enum_combobox_actionType
        {
            Shutdown = 1,
            Restart = 2,
            LogOff = 3,
            Sleep = 4,
            LockComputer = 5,
            TurnOffMonitor = 6
        }

        public enum enum_combobox_triggerType
        {
            SystemIdleTime = 1,
            FromNow = 2,
            CertainTime = 3
        }

        //geçici, dil sistemi gelene kadar kalacak
        public static string systemIdle = "systemIdle";
        public static string certainTime = "certainTime";
        public static string fromNow = "fromNow";
        public static string lockComputer = "lockComputer";
        public static string sleepComputer = "sleepComputer";
        public static string turnOffMonitor = "turnOffMonitor";
        public static string shutdownComputer = "shutdownComputer";
        public static string restartComputer = "restartComputer";
        public static string logOffWindows = "logOffWindows";
        public static List<ActionModel> actionList = new List<ActionModel>();
        public static settings settings = new settings();
        public static Timer timer = new Timer();
        public static int runInTaskbarCounter;

        public mainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            var args = Environment.GetCommandLineArgs();


            foreach (var arg in args)

                if (arg == "-runInTaskbar" && runInTaskbarCounter <= 0)
                {
                    ++runInTaskbarCounter;
                    Hide(); // Hide form window.
                    ShowInTaskbar = false; // Remove from taskbar.
                }

            base.OnLoad(e);
        }


        private void mainForm_Load(object sender, EventArgs e)
        {
            detectScreen.manuelLockingActionLogger();
            if (File.Exists("actionList.json"))
                actionList = JsonSerializer.Deserialize<List<ActionModel>>(File.ReadAllText("actionList.json"));


            timer.Interval = 1000; // 1 sec
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
            comboBox_triggerType.Items.Add(fromNow);
            comboBox_triggerType.Items.Add(certainTime);
            comboBox_triggerType.SelectedIndex = 0;

            notifyIcon_main.Text = "Windows Shutdown Helper is running in background";

            refreshActionList();
        }


        public void refreshActionList()
        {
            dataGridView_taskList.DataSource = null;
            dataGridView_taskList.DataSource = actionList;
            dataGridView_taskList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_taskList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        public void createNewAction(ActionModel newAction)
        {
            if (comboBox_actionType.SelectedIndex == (int) enum_combobox_actionType.LockComputer)
                newAction.actionType = lockComputer;
            if (comboBox_actionType.SelectedIndex == (int) enum_combobox_actionType.LogOff)
                newAction.actionType = logOffWindows;
            if (comboBox_actionType.SelectedIndex == (int) enum_combobox_actionType.Restart)
                newAction.actionType = restartComputer;
            if (comboBox_actionType.SelectedIndex == (int) enum_combobox_actionType.Shutdown)
                newAction.actionType = shutdownComputer;
            if (comboBox_actionType.SelectedIndex == (int) enum_combobox_actionType.Sleep)
                newAction.actionType = sleepComputer;
            if (comboBox_actionType.SelectedIndex == (int) enum_combobox_actionType.TurnOffMonitor)
                newAction.actionType = turnOffMonitor;
        }


        public void writeJsonToActionList()
        {
            jsonWriter.WriteJson("actionList.json", true, actionList);
            refreshActionList();
        }

        private void doAction(ActionModel action, uint idleTimeMin)
        {
            if (action.triggerType == "systemIdle" && idleTimeMin == Convert.ToInt32(action.value) * 60)
                Actions.doActionByTypes(action); //a.Close();  

            if (action.triggerType == "certainTime" && action.value == DateTime.Now.ToString("HH:mm:ss"))
                Actions.doActionByTypes(action);

            if (action.triggerType == "fromNow" && action.value == DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"))
            {
                Actions.doActionByTypes(action);
                actionList.Remove(action);
                writeJsonToActionList();
            }
        }



        private void timerTick(object sender, EventArgs e)
        {
            toolStripStatusLabel_CurrentTime.Text = "Current Time: " + DateTime.Now;

            var idleTimeMin = systemIdleDetector.GetLastInputTime();

            if (idleTimeMin == 0) {timer.Stop(); timer.Start();}



            foreach (var action in actionList.ToList())
            {
                doAction(action, idleTimeMin);
                notifySystem.add12(action, idleTimeMin,10);

            } //foreach
        }
        

        private void deleteAction()
        {
            if (Application.OpenForms.OfType<popUpViewer>().Count() == 0)
            {

                var popUpViewer = new popUpViewer("Success", "Action deleted successfully", 2, Resources.success, Location.X,
                    Location.Y, Width, Height);
                popUpViewer.ShowDialog();
            }
            if (dataGridView_taskList.Rows.Count > 0)
            {
                actionList.RemoveAt(dataGridView_taskList.CurrentCell.RowIndex);

                writeJsonToActionList();
            }
        }


        private void trigger_groupBox_Enter(object sender, EventArgs e)
        {
        }

        private void button_AddToList_Click(object sender, EventArgs e)
        {
            if (actionList.Count < 5)
            {

                if (comboBox_actionType.SelectedIndex > 0 && comboBox_triggerType.SelectedIndex > 0)
                {
                    var newAction = new ActionModel();
                    newAction.createdDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                    var now = DateTime.Now;

                    if (comboBox_triggerType.SelectedIndex == (int)enum_combobox_triggerType.FromNow)
                    {
                        newAction.triggerType = fromNow;
                        newAction.value = DateTime.Now.AddMinutes(Convert.ToDouble(numericUpDown_value.Value))
                            .ToString("dd.MM.yyyy HH:mm:ss");

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
                    if (Application.OpenForms.OfType<popUpViewer>().Count() == 0)
                    {

                        var popUpViewer = new popUpViewer("Success", "Action created successfully",
                            2, Resources.success, Location.X,
                            Location.Y, Width, Height);
                        popUpViewer.ShowDialog();
                    }

                    writeJsonToActionList();
                }

                else
                {
                    if (Application.OpenForms.OfType<popUpViewer>().Count() == 0)
                    {

                        var popUpViewer = new popUpViewer("Warn", "Firstly make a choose",
                            2, Resources.warn, Location.X,
                            Location.Y, Width, Height);
                        popUpViewer.ShowDialog();
                    }
                }
            }

            else if (actionList.Count >= 5)
            {
                if (Application.OpenForms.OfType<popUpViewer>().Count() == 0)
                {

                    var popUpViewer = new popUpViewer("Warn", "Only can be create 5 actions", 
                        2, Resources.warn, Location.X,
                        Location.Y, Width, Height);
                    popUpViewer.ShowDialog();
                }
            }
        }


        private void comboBox_trigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_triggerType.SelectedIndex == 0)
            {
                label_firstly_choose_a_trigger.Visible = true;
                numericUpDown_value.Visible = false;
                dateTimePicker_time.Visible = false;
            }

            if (comboBox_triggerType.SelectedIndex == 1 || comboBox_triggerType.SelectedIndex == 2)
            {
                label_firstly_choose_a_trigger.Visible = false;
                numericUpDown_value.Visible = true;
                dateTimePicker_time.Visible = false;
            }
            else if (comboBox_triggerType.SelectedIndex == 3)
            {
                label_firstly_choose_a_trigger.Visible = false;

                numericUpDown_value.Visible = false;
                dateTimePicker_time.Visible = true;
            }
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
                dataGridView_taskList.ContextMenuStrip = contextMenuStrip_mainGrid;
        }

        private void dataGridView_taskList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGridView_taskList.Rows.Count == 0) dataGridView_taskList.ContextMenuStrip = null;
        }

        private void comboBox_actionType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox_logs_Click(object sender, EventArgs e)
        {
            showLogs();
        }

        private void pictureBox_settings_Click(object sender, EventArgs e)
        {
            settingsFormOpen();
        }

        private void mainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon_main.Visible = true;
            }
        }

        public void settingsFormOpen()
        {
          
            var settingsForm = new settingsForm(Location.X, Location.Y, Width, Height);
            if (Application.OpenForms.OfType<settingsForm>().Count() == 0)
            {


                settingsForm.Show();
            }
            else if (Application.OpenForms.OfType<settingsForm>().Count() > 0)
            {
                var popUpViewer = new popUpViewer("İnfo", "Another '" + settingsForm.Text + "' window is already open.", 2, Resources.info, Location.X,
                    Location.Y, Width, Height);
                popUpViewer.ShowDialog();
            }

        }

        public void showMain()
        {
            Show();
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }
        private void notifyIcon_main_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showMain();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists("settings.json"))
            {
                settings = JsonSerializer.Deserialize<settings>(File.ReadAllText("settings.json"));

                if (settings.runInTaskbarWhenClosed)
                {
                    e.Cancel = true;
                    Hide();
                }
            }
        }

        private void exitTheProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void addNewActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showMain();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            settingsFormOpen();
           
        }

        private void showTheLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            showLogs();
        }

        private void clearAllActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actionList.Clear();
            writeJsonToActionList();

            if (Application.OpenForms.OfType<popUpViewer>().Count() == 0)
            {

                var popUpViewer = new popUpViewer("Success", "Cleared all actions successfully", 2, Resources.success, Location.X,
                    Location.Y, Width, Height);
                popUpViewer.ShowDialog();
            }
        }


        public void showLogs()
        {
            if (File.Exists("logs.json"))
            {
                var logList = JsonSerializer.Deserialize<List<logSystem>>(File.ReadAllText("logs.json"))
                    .OrderByDescending(a => a.actionExecutedDate).Take(250).ToList();
                if (logList.Count > 0)
                {
                    var logViewerForm = new logViewer(logList, Location.X, Location.Y, Width, Height);
                    if (Application.OpenForms.OfType<logViewer>().Count() == 0)
                    {
                        

                        logViewerForm.Show();
                    }
                    else if (Application.OpenForms.OfType<logViewer>().Count() > 0)
                    {
                        var popUpViewer = new popUpViewer("İnfo", "Another '" + logViewerForm.Text+ "' window is already open.", 2, Resources.info, Location.X,
                            Location.Y, Width, Height);
                        popUpViewer.ShowDialog();
                    }
                }

                else
                {
                    var popUpViewer = new popUpViewer("Warning", "There is no log", 3, Resources.warn, Location.X,
                        Location.Y, Width, Height);
                    popUpViewer.ShowDialog();
                }
            }

            else
            {
                var popUpViewer = new popUpViewer("Warning", "There is no log file", 3, Resources.warn, Location.X,
                    Location.Y, Width, Height);
                popUpViewer.ShowDialog();
            }
        }

        private void contextMenuStrip_notifyIcon_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


        ////
    }
}