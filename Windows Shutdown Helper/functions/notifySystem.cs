using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using WindowsShutdownHelper.Properties;

namespace WindowsShutdownHelper.functions
{
    internal class notifySystem
    {
        public static language language = languageSelector.languageFile();
        public static string actionTypeName;
        public static string messageTitle = "Info";
        public static string messageContent_CountdownNotify = " seconds later it will be:";
        public static string messageContent_youCanThat = "If you don't want that";
        public static string messageContent_DoThatForNotWant_systemIdle = "Press a key or move the mouse";


        public static void showNotification(ActionModel action, uint idleTimeMin)
        {
            var settings = new settings();

            if (File.Exists("settings.json"))
                settings = JsonSerializer.Deserialize<settings>(File.ReadAllText("settings.json"));
            else
                settings.isCountdownNotifierEnabled = false;


            if (settings.isCountdownNotifierEnabled)
            {
                actionTypeLocalization(action);

                if (action.triggerType == "systemIdle")
                {
                    var actionValue = Convert.ToInt32(action.value);
                    if (idleTimeMin >= actionValue * 60 - settings.countdownNotifierSeconds - 2)
                        if (Application.OpenForms.OfType<actionCountdownNotifier>().Any() == false)
                        {
                            var actionCountdownNotifier = new actionCountdownNotifier(language.messageTitle_info,
                                language.messageContent_CountdownNotify,
                                actionTypeName, language.messageContent_cancelForSystemIdle,
                                settings.countdownNotifierSeconds - 2,
                                Resources.info, action);

                            actionCountdownNotifier.Show();
                            actionCountdownNotifier.Focus();
                        }
                }

                else if (action.triggerType == "fromNow")
                {
                    var actionExecuteDate = DateTime.Parse(action.value)
                        .AddSeconds(Convert.ToDouble(-settings.countdownNotifierSeconds));
                    var nowDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                    var executionDate = actionExecuteDate.ToString("dd.MM.yyyy HH:mm:ss");

                    if (executionDate == nowDate)
                        if (Application.OpenForms.OfType<actionCountdownNotifier>().Any() == false)
                        {
                            var actionCountdownNotifier = new actionCountdownNotifier(language.messageTitle_info,
                                language.messageContent_CountdownNotify,
                                actionTypeName, language.messageContent_youCanThat,
                                settings.countdownNotifierSeconds - 2,
                                Resources.info, action);

                            actionCountdownNotifier.Show();
                            actionCountdownNotifier.Focus();
                        }
                }


                else if (action.triggerType == "certainTime")
                {
                    var actionExecuteDate = DateTime.Parse(action.value)
                        .AddSeconds(Convert.ToDouble(-settings.countdownNotifierSeconds));
                    var nowDate = DateTime.Now.ToString("HH:mm:ss");
                    var executionDate = actionExecuteDate.ToString("HH:mm:ss");

                    if (executionDate == nowDate)
                        if (Application.OpenForms.OfType<actionCountdownNotifier>().Any() == false)
                        {
                            var actionCountdownNotifier = new actionCountdownNotifier(language.messageTitle_info,
                                language.messageContent_CountdownNotify,
                                actionTypeName, language.messageContent_youCanThat,
                                settings.countdownNotifierSeconds - 2,
                                Resources.info, action);

                            actionCountdownNotifier.Show();
                            actionCountdownNotifier.Focus();
                        }
                }
            }
        }


        public static void actionTypeLocalization(ActionModel action)
        {
            if (action.actionType == "lockComputer") actionTypeName = language.main_cbox_ActionType_Item_lockComputer;
            else if (action.actionType == "shutdownComputer")
                actionTypeName = language.main_cbox_ActionType_Item_shutdownComputer;
            else if (action.actionType == "restartComputer")
                actionTypeName = language.main_cbox_ActionType_Item_restartComputer;
            else if (action.actionType == "logOffWindows")
                actionTypeName = language.main_cbox_ActionType_Item_logOffWindows;
            else if (action.actionType == "sleepComputer")
                actionTypeName = language.main_cbox_ActionType_Item_sleepComputer;
            else if (action.actionType == "turnOffMonitor")
                actionTypeName = language.main_cbox_ActionType_Item_turnOffMonitor;
        }
    }
}