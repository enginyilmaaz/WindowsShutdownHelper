using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace WindowsShutdownHelper.functions
{
    public class Logger
    {
        public static void doLog(string actionType)
        {
            var settings = new settings();

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\settings.json"))
                settings = JsonSerializer.Deserialize<settings>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\settings.json"));
            else
                settings.logsEnabled = true;


            if (settings.logsEnabled)
            {
                var logLists = new List<logSystem>();

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\logs.json"))
                    logLists = JsonSerializer.Deserialize<List<logSystem>>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\logs.json"));


                var newLog = new logSystem();
                newLog.actionType = actionType;
                newLog.actionExecutedDate = DateTime.Now.ToString();

                logLists.Add(newLog);

                jsonWriter.WriteJson(AppDomain.CurrentDomain.BaseDirectory + "\\logs.json", true, logLists);
            }
        }
    }
}