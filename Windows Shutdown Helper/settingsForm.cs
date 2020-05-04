using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using WindowsShutdownHelper.functions;
using WindowsShutdownHelper.Properties;
using Microsoft.Win32;

namespace WindowsShutdownHelper
{
    public partial class settingsForm : Form
    {
        public static int x;
        public static int y;

        public static settings settings = new settings();
        public settingsForm(int _x, int _y, int _width, int _height)
        {
            InitializeComponent();
            x = _x + (_width - Width) / 2;
            y = _y + (_height - Height) / 2;
        }


        private void settingsForm_Load(object sender, EventArgs e)
        {
            Location = new Point(x, y);


            refrehSettings();
        }

        public void refrehSettings()
        {
            if (File.Exists("settings.json"))
            {
                settings = JsonSerializer.Deserialize<settings>(File.ReadAllText("settings.json"));
                if (settings.logsEnabled) checkBox_logEnabled.Checked = true;
                else checkBox_logEnabled.Checked = false;

                if (settings.startWithWindows) checkBox_startWithWindowsEnabled.Checked = true;
                else checkBox_startWithWindowsEnabled.Checked = false;

                if (settings.runInTaskbarWhenClosed) checkBox_runInTaskbarWhenClosed.Checked = true;
                else checkBox_runInTaskbarWhenClosed.Checked = false;

                if (settings.isCountdownNotifierEnabled) checkBox_isCountdownNotifierEnabled.Checked = true;
                else checkBox_isCountdownNotifierEnabled.Checked = false;

                numericUpDown_countdownNotifierSeconds.Value = settings.countdownNotifierSeconds;
            }

            
            else
            {
                checkBox_logEnabled.Checked = true;
                checkBox_startWithWindowsEnabled.Checked = false;
                checkBox_runInTaskbarWhenClosed.Checked = false;
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_logEnabled.Checked) settings.logsEnabled = true;
                else settings.logsEnabled = false;
                if (checkBox_runInTaskbarWhenClosed.Checked) settings.runInTaskbarWhenClosed = true;
                else settings.runInTaskbarWhenClosed = false;


                if (checkBox_startWithWindowsEnabled.Checked)
                {
                    settings.startWithWindows = true;
                    functions.startWithWindows.AddStartup("Shutwdown Helper for Windows");
                 
                }

                else
                {
                    settings.startWithWindows = false;
                    functions.startWithWindows.DeleteStartup("Shutwdown Helper for Windows");
                 }

                if (checkBox_isCountdownNotifierEnabled.Checked)
                {
                    settings.isCountdownNotifierEnabled = true;
                }
                else
                {
                    settings.isCountdownNotifierEnabled = false;
                }

                 settings.countdownNotifierSeconds= Convert.ToInt16(numericUpDown_countdownNotifierSeconds.Value);

                jsonWriter.WriteJson("settings.json", true, settings);

                refrehSettings();

                var popUpViewer = new popUpViewer("Success", "Setting saved successfully", 
                    2, Resources.success,  Location.X, Location.Y, Width, Height);
                popUpViewer.ShowDialog();
            }


            catch
            {
            }
        }

        private void numericUpDown_countdownNotifierSeconds_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        ///////////////////////////////////////////////////////////////////////////
    }
}