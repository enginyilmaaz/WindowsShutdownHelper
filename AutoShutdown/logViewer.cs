using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
namespace WindowsPowerManager
{
    public partial class logViewer : Form
    {

             public static List<functions.logSystem> logList;

        public logViewer()
        {
            InitializeComponent();
        }

        
        private void logViewer_Load(object sender, EventArgs e)
        {
              if (File.Exists("logs.json"))
            {
                logList = JsonSerializer.Deserialize<List<functions.logSystem>>(File.ReadAllText("logs.json"))
                                                 .OrderByDescending(a => a.actionExecutedDate).Take(250).ToList();
               
            }


            refreshLogList();

        }

        public void refreshLogList()
        {
           
        
            dataGridView_logs.DataSource = null;
            if (File.Exists("logs.json"))
            {
                dataGridView_logs.DataSource = logList;

            }
            
            dataGridView_logs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_logs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

            private void button_clearLogs_Click(object sender, EventArgs e)
        {
            if (File.Exists("logs.json"))
            {
                File.Delete("logs.json");

            }

            refreshLogList();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /////////////////////////////////////////
    }
}
