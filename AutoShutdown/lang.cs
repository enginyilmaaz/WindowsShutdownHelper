using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShutdown.lang
{

    public class lang_English
    {

        public static triggerTabPage triggerTabPage { get; set; }
        public static comboboxTask comboboxTask { get; set; }
} 


    public class triggerTabPage
    {
        public static string pageName { get; set; }
        public static string systemIdleForMin { get; set; } //boştaki süreye göre dk bazında
        public static string inFromNow { get; set; } // şuandan itibaren dk bazında

    }

    public  class comboboxTask
    {
        public string ChooseATask { get; set; }
        public string Shutdown { get; set; }
        public static string Restart { get; set; }
        public static string LogOff { get; set; }
        public static string Sleep { get; set; }
        public static string LockComputer { get; set; }
        public static string TurnOffMonitor { get; set; }

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
