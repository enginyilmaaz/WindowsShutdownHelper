using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AutoShutdown.functions
{
    public class Tasks { 

         public class Lock
    {

        [DllImport("user32.dll")]
        public static extern void LockWorkStation();

        public static void Computer()
        {
            LockWorkStation();

        }

    }

        public static void ShutdownComputer()
        {
            Process.Start("shutdown", "/s /t 0");    // starts the shutdown application 
                                                     // the argument /s is to shut down the computer
                                                     // the argument /t 0 is to tell the process that 
                                                     // the specified operation needs to be completed 
                                                     // after 0 seconds

        }




        public static void RestartComputer()
        {
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

            public static void Computer()
            {
                ExitWindowsEx(0, 0);

            }

        }

        public class Sleep
        {

            [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

            public static void Computer()
            {
                SetSuspendState(false, true, true);

            }

        }


        public class TurnOffMonitor
        {

            [DllImport("user32.dll")]
            static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

            private static int SC_MONITORPOWER = 0xF170;
            private static int WM_SYSCOMMAND = 0x0112;

            public enum MonitorState
            {
                ON = -1,
                OFF = 2,
                STANDBY = 1
            }

            public static void SetMonitorState(MonitorState state)
            {
                SendMessage(Process.GetCurrentProcess().Handle, WM_SYSCOMMAND, SC_MONITORPOWER, (int)state);
            }
            
            public static void Computer()
            {
                SetMonitorState(MonitorState.OFF);

            }

        }






        /////////////
    }
}
