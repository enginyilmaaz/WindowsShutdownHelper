using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShutdown
{
    public class lang_English
    {

        public triggerTabPage triggerTabPage { get; set; }
        public comboboxTask comboboxTask { get; set; }
} 


    public class triggerTabPage
    {
        public string pageName { get; set; }
        public string systemIdleForMin { get; set; } //boştaki süreye göre dk bazında
        public string inFromNow { get; set; } // şuandan itibaren dk bazında

    }

    public class comboboxTask
    {
        public string ChooseATask { get; set; }
        public string Shutdown { get; set; }
        public string Restart { get; set; }
        public string LogOff { get; set; }
        public string Sleep { get; set; }
        public string LockComputer { get; set; }
        public string TurnOffMonitor { get; set; }

}
    public class labels
    {
        public string Shutdown { get; set; }
        public string Restart { get; set; }
        public string LogOff { get; set; }
        public string Sleep { get; set; }
        public string LockComputer { get; set; }
        public string TurnOffMonitor { get; set; }
        public string toolStripStatusLabel_CurrentTime { get; set; }

    }



}
