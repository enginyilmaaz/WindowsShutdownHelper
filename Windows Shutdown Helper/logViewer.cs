using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using WindowsShutdownHelper.functions;
using WindowsShutdownHelper.Properties;

namespace WindowsShutdownHelper
{
    public partial class logViewer : Form
    {
        public static List<logSystem> logList = new List<logSystem>();
        public static int x;
        public static int y;

        public logViewer(List<logSystem> _logList, int _x, int _y, int _width, int _height)
        {
            InitializeComponent();
            x = _x + (_width - Width) / 2;
            y = _y + (_height - Height) / 2;
            logList = _logList;
        }


        private void logViewer_Load(object sender, EventArgs e)
        {
            Location = new Point(x, y);

            dataGridView_logs.DataSource = logList;

            dataGridView_logs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_logs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void refreshLogList()
        {
            if (File.Exists("logs.json"))
                logList = JsonSerializer.Deserialize<List<logSystem>>(File.ReadAllText("logs.json"))
                    .OrderByDescending(a => a.actionExecutedDate).Take(250).ToList();


            dataGridView_logs.DataSource = null;
            if (File.Exists("logs.json")) dataGridView_logs.DataSource = logList;

            dataGridView_logs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_logs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button_clearLogs_Click(object sender, EventArgs e)
        {
            if (File.Exists("logs.json")) File.Delete("logs.json");

            refreshLogList();

            var popUpViewer = new popUpViewer("Success", "Logs cleared successfully\nThis windows will close automatically",
                3, Resources.success, Location.X, Location.Y, Width, Height);
            popUpViewer.ShowDialog();

            Dispose(); 
            Close();

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }


        /////////////////////////////////////////
    }
}