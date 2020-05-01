using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsPowerManager
{
    public partial class settingsForm : Form
    {
        public static settings settings=new settings();  

        public settingsForm()
        {
            InitializeComponent();
            

        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
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
            }

            else
            {
                settings.logsEnabled = true;
                settings.startWithWindows = false;

            }

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_save_Click(object sender, EventArgs e)
        {

           
          
            if (checkBox_logEnabled.Checked) settings.logsEnabled = true;
            else settings.logsEnabled = false;



            if (checkBox_startWithWindowsEnabled.Checked)
            {
                settings.startWithWindows = true;
                //functions.startWithWindows.RunOnStartup("Windows Power Manager");
                RegistryKey startupKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);
                string keyName = @"Software\Microsoft\Windows\CurrentVersion\Run";
                startupKey = startupKey.OpenSubKey(keyName, true); string ss = "Windows Shutdown Helper";
                startupKey.SetValue(ss, Application.ExecutablePath.ToString(), RegistryValueKind.String);
                startupKey.Close();
            }
            else
            {
                settings.startWithWindows = false;
              
            }

            functions.jsonWriter.WriteJson("settings.json", true, settings);

            refrehSettings();
        }

        ///////////////////////////////////////////////////////////////////////////
    }
}
