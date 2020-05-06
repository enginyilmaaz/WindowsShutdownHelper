namespace WindowsShutdownHelper.default_settings
{
    public static class settingFileGenerator
    {
        public static settings defaulSettingFile()
        {
            var setting = new settings
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