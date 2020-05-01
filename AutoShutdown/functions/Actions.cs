using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsPowerManager.functions
{
    public class Actions { 

         public class Lock
    {

        [DllImport("user32.dll")]
        public static extern void LockWorkStation();

        public static void Computer()
        {

            functions.Logger.doLog("lockComputer");
            LockWorkStation();

        }

    }

        public static void ShutdownComputer()
        {
            functions.Logger.doLog("shutdownComputer");
            Process.Start("shutdown", "/s /t 0");    // starts the shutdown application 
                                                     // the argument /s is to shut down the computer
                                                     // the argument /t 0 is to tell the process that 
                                                     // the specified operation needs to be completed 
                                                     // after 0 seconds

        }




        public static void RestartComputer()
        {
            functions.Logger.doLog("restartComputer");
            Process.Start("shutdown", "/r /t 0");    // starts the shutdown application 
                                                     // the argument /s is to shut down the computer
                                                     // the argument /t 0 is to tell the process that 
                                                     // the specified operation needs to be completed 
                                                     // after 0 seconds

        }


        public class LogOff
        {

            [DllImport("user32")]
            public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

            public static void Windows()
            {
                functions.Logger.doLog("logOffWindows");
                ExitWindowsEx(0, 0);

            }

        }

        public class Sleep
        {

            [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

            public static void Computer()
            {

                functions.Logger.doLog("sleepComputer");
                SetSuspendState(false, true, true);

            }

        }


        public class TurnOff
        {

            [DllImport("user32.dll")]
            public static extern IntPtr SendMessage(int hWnd, int Msg, int wParam, int lParam);
            [DllImport("user32.dll")]
            public static extern IntPtr PostMessage(int hWnd, int Msg, int wParam, int lParam);
            private static int SC_MONITORPOWER = 0xF170;
            private static int WM_SYSCOMMAND = 0x0112;
            private static int HWND_BROADCAST = 0xFFFF;
            public enum MonitorState
            {
                ON = -1,
                OFF = 2,
                STANDBY = 1
            }

            public static void SetMonitorState(MonitorState state)
            {
                 PostMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, (int)MonitorState.OFF);

                //SendMessage(-1, WM_SYSCOMMAND, SC_MONITORPOWER, (int)2);
               // SendMessage(-1, WM_SYSCOMMAND, SC_MONITORPOWER, (int)state);
            }
            
            public static void Monitor()
            {
                functions.Logger.doLog("turnOffMonitor");
                SetMonitorState(MonitorState.OFF);

                
                
               
            }

        }






        /////////////
    }
}
