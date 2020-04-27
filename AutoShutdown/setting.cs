using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShutdown
{
    public class setting
    {
        public task task_1 { get; set; }
        public task task_2 { get; set; }
        public task task_3 { get; set; }
        public task task_4 { get; set; }
        public task task_5 { get; set; }

    }


    public class task
    {
        public string triggerType { get; set; }
        public string value { get; set; }
        public string createdDate { get; set; }

    }












}
