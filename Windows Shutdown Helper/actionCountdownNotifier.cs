using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsShutdownHelper.functions;

namespace WindowsShutdownHelper
{
    public partial class actionCountdownNotifier : Form
    {
        public static language language = languageSelector.languageFile();
        public ActionModel action = new ActionModel();
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private bool dragging;
        public string messageContentActionType;
        public string messageContentCountdownNotify;
        public string messageContentYouCanThat;
        public int showTimeSecond;
        public Timer timer = new Timer();

        public actionCountdownNotifier(string messageTitle, string _messageContentCountdownNotify,
            string _messageContentActionType,
            string _messageContentYouCanThat, int _showTimeSecond,
            Image messageIconFile, ActionModel _action)
        {
            InitializeComponent();
            showTimeSecond = 0;
            action = _action;
            showTimeSecond = _showTimeSecond;
            messageContentCountdownNotify = _messageContentCountdownNotify;
            messageContentActionType = _messageContentActionType;
            messageContentYouCanThat = _messageContentYouCanThat;
            label_contentCountdownNotify.Text = showTimeSecond + " " + messageContentCountdownNotify;
            label_contentActionType.Text = messageContentActionType;
            label_contentYouCanThat.Text = _messageContentYouCanThat;
            timer.Interval = 1000;
            timer.Tick += timerTick;
            timer.Start();


            pictureBox_main.Image = messageIconFile;
            label_title.Text = messageTitle;


            if (action.triggerType == "systemIdle")
            {
                button_Ignore.Enabled = true;
                button_skip.Enabled = false;
                button_delete.Enabled = false;
            }

            if (action.triggerType == "fromNow")
            {
                button_Ignore.Enabled = true;
                button_skip.Enabled = false;
                button_delete.Enabled = true;
            }

            if (action.triggerType == "certainTime")
            {
                button_Ignore.Enabled = true;
                button_skip.Enabled = true;
                button_delete.Enabled = true;
            }
        }


        private void actionCountdownNotifier_Load(object sender, EventArgs e)
        {
            button_Ignore.Text = language.actionCountdownNotifier_button_ignore;
            button_delete.Text = language.actionCountdownNotifier_button_delete;
            button_skip.Text = language.actionCountdownNotifier_button_skip;
        }

        private void timerTick(object sender, EventArgs e)
        {
            label_contentCountdownNotify.Text = showTimeSecond + " " + messageContentCountdownNotify;


            if (showTimeSecond == 0)
            {
                timer.Stop();

                GC.Collect();
                GC.SuppressFinalize(this);
                Close();
            }

            if (action.triggerType == "systemIdle")
            {
                var idleTimeMin = systemIdleDetector.GetLastInputTime();
                if (idleTimeMin == 0)
                {
                    timer.Stop();

                    GC.Collect();
                    GC.SuppressFinalize(this);
                    Close();
                }
            }


            --showTimeSecond;
        }


        private void button_Skip_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.SuppressFinalize(this);
            Close();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            mainForm.actionList.Remove(action);
            mainForm.isDeletedFromNotifier = true;
            jsonWriter.WriteJson("actionList.json", true, mainForm.actionList);

            GC.Collect();
            GC.SuppressFinalize(this);
            Close();
        }

        private void panel_main_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = Location;
        }

        private void panel_main_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panel_main_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                var dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void button_skip_Click(object sender, EventArgs e)
        {
            mainForm.isSkippedCertainTimeAction = true;

            GC.Collect();
            GC.SuppressFinalize(this);
            Close();
        }

        private void label_contentIfYouDontWant_Click(object sender, EventArgs e)
        {
        }

        private void label_contentActionType_Click(object sender, EventArgs e)
        {
        }

        private void label_contentCountdownNotify_Click(object sender, EventArgs e)
        {
        }
    }
}