﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoShutdown.functions
{
    public class logSystem
    {
        public string actionType { get; set; }
        public string actionExecutedDate { get; set; }
    }

    public class Logger {

        public static void doLog(string actionType)
        {
            settings settings = new settings();

            if (File.Exists("settings.json"))
            {
                settings = JsonSerializer.Deserialize<settings>(File.ReadAllText("settings.json"));
            }
            else
            {
                settings.logsEnabled = true;
            }



            if (settings.logsEnabled == true) { 


                List<logSystem> logLists = new List<logSystem>();

            if (File.Exists("logs.json"))
            {
                logLists = JsonSerializer.Deserialize<List<logSystem>>(File.ReadAllText("logs.json"));

            }// if (File.Exists("logs.json"))


            logSystem newLog = new logSystem();
            newLog.actionType = actionType;
            newLog.actionExecutedDate = DateTime.Now.ToString();

            logLists.Add(newLog);

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                var json = JsonSerializer.Serialize(logLists,options);
            StreamWriter sw = new StreamWriter("logs.json", false);
            sw.WriteLine(json); sw.Close();

            }//if (settings.logsEnabled == true) { 
        } //dolog

    }//class logger









}