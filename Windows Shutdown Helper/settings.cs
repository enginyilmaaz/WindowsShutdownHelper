﻿namespace WindowsShutdownHelper
{
    public class settings
    {
        public bool logsEnabled { get; set; }
        public bool startWithWindows { get; set; }
        public bool runInTaskbarWhenClosed { get; set; }
        public bool isCountdownNotifierEnabled { get; set; }
        public int  countdownNotifierSeconds { get; set; }
    }
}