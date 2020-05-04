using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsShutdownHelper.functions;

namespace WindowsShutdownHelper
{
    public partial class actionCountdownNotifier : Form
    {
        public Timer timer = new Timer();
        public int showTimeSecond;
        public string messageContent;
        public string actionType;
        public ActionModel action=new ActionModel();
        public actionCountdownNotifier(string messageTitle, string _messageContent, int _showTimeSecond,
            Image messageIconFile, ActionModel _action)
        {
            InitializeComponent();
            actionType = action.actionType;
            action = _action;
            showTimeSecond = _showTimeSecond;
              messageContent =_messageContent;
            label_content.Text = showTimeSecond.ToString()+messageContent;
            pictureBox_main.Image = messageIconFile;
            label_title.Text = messageTitle;
            --showTimeSecond;
           
            if (actionType == "systemIdle")
            {
                button_OK.Enabled = true;
                button_skip.Enabled = false;
                button_delete.Enabled = false;
            }

            if (actionType == "fromNow")
            {
                button_OK.Enabled = true;
                button_skip.Enabled = false;
                button_delete.Enabled = false;
            }

            if (actionType == "certainTime")
            {
                button_OK.Enabled = false;
                button_skip.Enabled = true;
                button_delete.Enabled = true;
            }

        
        }
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void actionCountdownNotifier_Load(object sender, EventArgs e)
        {

            timer.Interval = 1000;
            timer.Tick += new EventHandler(timerTick);
            timer.Start();


        }

        private void timerTick(object sender, EventArgs e)
        {
            var idleTimeMin = systemIdleDetector.GetLastInputTime();
            label_content.Text = showTimeSecond.ToString() + messageContent;
            


           
            if (showTimeSecond== 0)
            {
                timer.Stop();
                Dispose();
                Close();
            }
            if (idleTimeMin == 0)
            {
                timer.Stop();
                Dispose();
                Close();
               
            }
            --showTimeSecond;
        }

      
        private void button_OK_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {

        }
    }
}