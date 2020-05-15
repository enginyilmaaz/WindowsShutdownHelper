using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsShutdownHelper.functions
{
    public class ActionModel
    {
        public string triggerType { get; set; }
        public string actionType { get; set; }
        public string value { get; set; }
        public string createdDate { get; set; }
    }

    public class Actions
    {
        public static void doActionByTypes(ActionModel action)
        {
            if (action.actionType == "lockComputer")
            {
                Lock.Computer();
            }

            if (action.actionType == "sleepComputer")
            {
                Sleep.Computer();
            }

            if (action.actionType == "turnOffMonitor")
            {
                TurnOff.Monitor();
            }

            if (action.actionType == "shutdownComputer")
            {
                ShutdownComputer();
            }

            if (action.actionType == "restartComputer")
            {
                RestartComputer();
            }

            if (action.actionType == "logOffWindows")
            {
                LogOff.Windows();
            }
        }

        public static void ShutdownComputer()
        {
            Logger.doLog("shutdownComputer");
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "shutdown",
                Arguments = "/s /t 0"
            };
            process.StartInfo = startInfo;
            process.Start();
        }


        public static void RestartComputer()
        {
            Logger.doLog("restartComputer");
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "shutdown",
                Arguments = "/r /t 0"
            };

            process.StartInfo = startInfo;
            process.Start();
        }


        public class Lock
        {
            public static bool manualLocked = true;

            [DllImport("user32.dll")]
            public static extern void LockWorkStation();

            public static void Computer()
            {
                if (detectScreen.isLockedWorkstation() == false)
                {
                    manualLocked = false;
                    Logger.doLog("lockComputer");
                    LockWorkStation();
                }
            }


            public static bool isLockedManually()
            {
                return manualLocked;
            }
        }


        public class LogOff
        {
            [DllImport("user32")]
            public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

            public static void Windows()
            {
                Logger.doLog("logOffWindows");
                ExitWindowsEx(0, 0);
            }
        }

        public class Sleep
        {
            [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

            public static void Computer()
            {
                Logger.doLog("sleepComputer");
                SetSuspendState(false, true, true);
            }
        }


        public class TurnOff
        {
            public enum MonitorState
            {
                ON = -1,
                OFF = 2
            }

            private static readonly int SC_MONITORPOWER = 0xF170;
            private static readonly int WM_SYSCOMMAND = 0x0112;
            private static readonly int HWND_BROADCAST = 0xFFFF;


            [DllImport("user32.dll")]
            public static extern IntPtr SendMessage(int hWnd, int Msg, int wParam, int lParam);

            public static void SetMonitorState(MonitorState state)
            {
                SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, (int)MonitorState.OFF);
            }

            public static void Monitor()
            {
                Logger.doLog("turnOffMonitor");
                SetMonitorState(MonitorState.OFF);
            }
        }


        /////////////
    }
}