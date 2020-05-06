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

            if (File.Exists("settings.json"))
                settings = JsonSerializer.Deserialize<settings>(File.ReadAllText("settings.json"));
            else
                settings.logsEnabled = true;


            if (settings.logsEnabled)
            {
                var logLists = new List<logSystem>();

                if (File.Exists("logs.json"))
                    logLists = JsonSerializer.Deserialize<List<logSystem>>(File.ReadAllText("logs.json"));


                var newLog = new logSystem();
                newLog.actionType = actionType;
                newLog.actionExecutedDate = DateTime.Now.ToString();

                logLists.Add(newLog);

                jsonWriter.WriteJson("logs.json", true, logLists);
            }
        }
    }
}