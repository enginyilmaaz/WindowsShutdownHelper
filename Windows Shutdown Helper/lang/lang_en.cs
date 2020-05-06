namespace WindowsShutdownHelper.lang
{
    public static class lang_en
    {
        public static language lang_english()
        {
            var lang = new language();
            lang.main_FormName = "Shutdown Helper for Windows";
            lang.main_groupbox_newAction = "New Action";
            lang.main_label_actionType = "Action Type";
            lang.main_label_trigger = "Trigger";
            lang.main_label_value = "Value";
            lang.main_label_value_duration = "Duration (min)";
            lang.main_label_value_time = "Time(hour)";
            lang.main_button_addAction = "Add to Action List";
            lang.main_groupBox_actionList = "Action List";
            lang.main_statusBar_currentTime = "Current Time";
            lang.main_cbox_ActionType_Item_chooseAction = "Choose a action...";
            lang.main_cbox_ActionType_Item_lockComputer = "Lock computer";
            lang.main_cbox_ActionType_Item_sleepComputer = "Sleep computer";
            lang.main_cbox_ActionType_Item_turnOffMonitor = "Turn off monitor";
            lang.main_cbox_ActionType_Item_shutdownComputer = "Shutdown computer";
            lang.main_cbox_ActionType_Item_restartComputer = "Restart computer";
            lang.main_cbox_ActionType_Item_logOffWindows = "Log off Windows";
            lang.main_cbox_TriggerType_Item_chooseTrigger = "Choose a trigger...";
            lang.main_cbox_TriggerType_Item_systemIdle = "System Idle Time";
            lang.main_cbox_TriggerType_Item_certainTime = "Every day by hour";
            lang.main_cbox_TriggerType_Item_fromNow = "Countdown";
            lang.main_datagrid_main_triggerType = "Trigger";
            lang.main_datagrid_main_actionType = "Action Type";
            lang.main_datagrid_main_value = "Duration / Date";
            lang.main_datagrid_main_createdDate = "Created";
            lang.notifyIcon_main = "now working in background.";
            lang.messageTitle_success = "Success";
            lang.messageTitle_info = "Info";
            lang.messageTitle_warn = "Warning";
            lang.messageTitle_error = "Error";
            lang.messageContent_actionDeleted = "Action deleted successfully";
            lang.messageContent_actionAllDeleted = "All actions deleted successfully";
            lang.messageContent_actionCreated = "Action created successfully";
            lang.messageContent_actionChoose = "Made the missing choice, correct it";
            lang.messageContent_maxActionWarn = "You can create up to 5 actions";
            lang.messageContent_datagridMain_actionChoose = "You did not choose a action";
            lang.messageContent_another = "Another";
            lang.messageContent_windowAlredyOpen = "window is already open";
            lang.settingsForm_Name = "Settings";
            lang.logViewerForm_Name = "Log Viewer";
            lang.messageContent_noLog = "There is no log for now";
            lang.contextMenuStrip_mainGrid_deleteSelectedAction = "Delete selected action";
            lang.contextMenuStrip_mainGrid_deleteAllAction = "Delete all actions";
            lang.contextMenuStrip_notifyIcon_addNewAction = "Create New Action";
            lang.contextMenuStrip_notifyIcon_showSettings = "Settings";
            lang.contextMenuStrip_notifyIcon_showLogs = "Show Logs";
            lang.contextMenuStrip_notifyIcon_exitProgram = "Exit The Program";
            lang.label_firstly_choose_a_trigger = "Choose a trigger first";
            lang.toolTip_showLogs = "Opens the Log Viewer window";
            lang.toolTip_settings = "Opens the Settings window";
            lang.logViewerForm_actionType = "Action Taken";
            lang.logViewerForm_actionExecutionTime = "Performed time";
            lang.logViewerForm_lockComputer = "The computer was locked automatically";
            lang.logViewerForm_lockComputerManually = "The computer was locked manually";
            lang.logViewerForm_unlockComputer = "The computer was unlocked";
            lang.logViewerForm_sleepComputer = "The computer was put to sleep automatically";
            lang.logViewerForm_turnOffMonitor = "The monitor was turned off automatically";
            lang.logViewerForm_shutdownComputer = "The monitor was shutdown automatically";
            lang.logViewerForm_restartComputer = "The monitor was restarted automatically";
            lang.logViewerForm_logOffWindows = "The session was logged off automatically";
            lang.logViewerForm_button_clearLogs = "Delete All Logs";
            lang.logViewerForm_button_cancel = "Cancel";
            lang.logViewerForm_tooltip_sortActionType_ascending = "Sort by actions:  A -> Z";
            lang.logViewerForm_tooltip_sortActionType_descending = "Sort by actions:  Z -> A";
            lang.logViewerForm_tooltip_sortActionExecutedDate_ascending = "Sort by date: Latest first";
            lang.logViewerForm_tooltip_sortActionExecutedDate_descending = "Sort by date: Oldest first";
            lang.messageContent_clearedLogs = "All records deleted successfully";
            lang.messageContent_thisWillAutoClose = "This window will close automatically";
            lang.messageContent_CountdownNotify = "sec. the following action will be performed in";
            lang.messageContent_youCanThat = "You can do the following";
            lang.messageContent_cancelForSystemIdle = "Press a key or move the mouse to cancel";
            lang.actionCountdownNotifier_button_skip = "Skip";
            lang.actionCountdownNotifier_button_delete = "Delete Action";
            lang.actionCountdownNotifier_button_ignore = "Ignore";
            lang.popupViewer_button_ok = "OK";
            lang.settingsForm_label_language = "Language Selection";
            lang.settingsForm_combobox_auto_lang = "Automatic";
            lang.settingsForm_label_logs = "Keep a record";
            lang.settingsForm_label_startWithWindows = "Run at system startup";
            lang.settingsForm_label_runInTaskbarWhenClosed = "Work in the background";
            lang.settingsForm_label_countdownNotifierSeconds = "Time to be warned (sec)";
            lang.settingsForm_label_isCountdownNotifierEnabled = "Show alert before the action";
            lang.settingsForm_checkbox_enabled = "Enable";
            lang.settingsForm_button_save = "Save";
            lang.settingsForm_button_cancel = "Cancel";
            lang.settingsForm_addStartupAppName = "Shutdown Helper for Windows";
            lang.messageContent_settingsSaved = "Settings saved successfully";
            lang.messageContent_settingSavedWithLangChanged = "Please restart the program to apply the changes";

            return lang;
        }
    }
}