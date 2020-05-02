using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsShutdownHelper
{
  

    public class Action
    {
        public string triggerType { get; set; }
        public string actionType { get; set; }
        public string value { get; set; }
        public string createdDate { get; set; }

    }


    public class settings
    {
        public bool logsEnabled { get; set; }
        public bool startWithWindows { get; set; }
        public bool runInTaskbarWhenClosed { get; set; }


    }









}
