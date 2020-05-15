﻿namespace WindowsShutdownHelper.default_settings
{
    public static class settingsINI
    {
        public static settings defaulSettingFile()
        {
            settings setting = new settings
            {
                logsEnabled = true,
                startWithWindows = false,
                runInTaskbarWhenClosed = false,
                isCountdownNotifierEnabled = true,
                countdownNotifierSeconds = 5,
                language = "en"
            };


            return setting;
        }
    }
}