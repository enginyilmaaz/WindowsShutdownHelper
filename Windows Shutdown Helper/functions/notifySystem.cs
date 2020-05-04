using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsShutdownHelper.functions
{
    class notifySystem
    {
        public static string actionTypeName;
        public static string messageTitle = "Info";
        public static string messageContentLine_1 = " seconds later it will be:";
        public static string messageContentLine_2 = "If you don't want that";
        public static string messageContentLine_4 = "Please do a action of the following";
        public static string messageContentLine_3 = "Press a key or move the mouse";


        public static void add12(ActionModel action, uint idleTimeMin, int countdownSecond)
        {
           

            actionTypeLocalization(action);
            
            if (action.triggerType == "systemIdle")
            {
                int actionValue = Convert.ToInt32(action.value);
                if (idleTimeMin >= (actionValue * 60 - countdownSecond))
                {
                    actionCountdownNotifier actionCountdownNotifier = new actionCountdownNotifier(messageTitle,
               messageContentLine_1+"\n\n" +actionTypeName+ "\n\n"+ messageContentLine_2 + "\n\n"+ messageContentLine_3, 
               countdownSecond, Properties.Resources.info, action);
                    
                       
                   
                    if (Application.OpenForms.OfType<actionCountdownNotifier>().Count()==0)
                    {
                        actionCountdownNotifier.Show();
                    }



                }
            }

       
        }




        public static void actionTypeLocalization(ActionModel action)
        {

            if (action.actionType == "lockComputer") actionTypeName = "locked computer";
            else if (action.actionType == "shutdownComputer") actionTypeName = "shutdown computer";
            else if(action.actionType == "restartComputer") actionTypeName = "restarted computer";
            else if(action.actionType == "logOffWindows") actionTypeName = "logged off";
            else if(action.actionType == "sleepComputer") actionTypeName = "slept computer";
            else if(action.actionType == "turnOffMonitor") actionTypeName = "turned off the monitor";
        }


       








    }
}
