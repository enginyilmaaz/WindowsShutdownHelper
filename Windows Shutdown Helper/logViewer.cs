﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using WindowsShutdownHelper.functions;
using WindowsShutdownHelper.Properties;

namespace WindowsShutdownHelper
{
    public partial class logViewer : Form
    {
        public static bool sortAscending_actionExecutedDate;
        public static language language = languageSelector.languageFile();
        public static List<logSystem> logList = new List<logSystem>();
        public static int x;
        public static int y;
        public static int cursorX;
        public static int cursorY;
        public List<logSystem> logListLocal = new List<logSystem>();
        public bool sortAscending_column_actionType = true;

        public logViewer(List<logSystem> _logList, int _x, int _y, int _width, int _height)
        {
            InitializeComponent();
            x = _x + (_width - Width) / 2;
            y = _y + (_height - Height) / 2;
            logList = _logList;
        }


        private void logViewer_Load(object sender, EventArgs e)
        {
            Location = new Point(x, y);

            Text = language.logViewerForm_Name;
            button_cancel.Text = language.logViewerForm_button_cancel;
            button_clearLogs.Text = language.logViewerForm_button_clearLogs;

            logRecordShowLocally();


            dataGridView_logs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_logs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_logs.Columns["actionExecutedDate"].HeaderText = language.logViewerForm_actionExecutionTime;
            dataGridView_logs.Columns["actionType"].HeaderText = language.logViewerForm_actionType;
            dataGridView_logs.Columns["actionExecutedDate"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView_logs.Columns["actionType"].DefaultCellStyle.Padding =
                new Padding(20, 0, 0, 0);
        }


        private void button_clearLogs_Click(object sender, EventArgs e)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\logs.json"))
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\logs.json");
            }

            logRecordShowLocally();

            popUpViewer popUpViewer = new popUpViewer(language.messageTitle_success,
                language.messageContent_clearedLogs + "\n" + language.messageContent_thisWillAutoClose,
                3, Resources.success, Location.X, Location.Y, Width, Height);
            popUpViewer.ShowDialog();

            GC.Collect();
            GC.SuppressFinalize(this);
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.SuppressFinalize(this);
            Close();
        }

        private void logViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }


        public void logRecordShowLocally()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\logs.json"))
            {
                logListLocal = JsonSerializer
                    .Deserialize<List<logSystem>>(
                        File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\logs.json"))
                    .OrderBy(a => a.actionExecutedDate).Take(250).ToList();
            }

            foreach (logSystem act in logListLocal)
            {
                if (act.actionType == "logOffWindows")
                {
                    act.actionType = language.logViewerForm_logOffWindows;
                }

                if (act.actionType == "lockComputer")
                {
                    act.actionType = language.logViewerForm_lockComputer;
                }

                if (act.actionType == "shutdownComputer")
                {
                    act.actionType = language.logViewerForm_shutdownComputer;
                }

                if (act.actionType == "restartComputer")
                {
                    act.actionType = language.logViewerForm_restartComputer;
                }

                if (act.actionType == "turnOffMonitor")
                {
                    act.actionType = language.logViewerForm_turnOffMonitor;
                }

                if (act.actionType == "sleepComputer")
                {
                    act.actionType = language.logViewerForm_sleepComputer;
                }

                if (act.actionType == "lockComputerManually")
                {
                    act.actionType = language.logViewerForm_lockComputerManually;
                }

                if (act.actionType == "unlockComputer")
                {
                    act.actionType = language.logViewerForm_unlockComputer;
                }

                if (act.actionType == "appStarted")
                {
                    act.actionType = language.logViewerForm_appStarted;
                }

                if (act.actionType == "appClosed")
                {
                    act.actionType = language.logViewerForm_appClosed;
                }
            }

            dataGridView_logs.DataSource = null;
            dataGridView_logs.DataSource = logListLocal;


            cellHeaderNumerator();
        }

        public void cellHeaderNumerator()
        {
            int rowNumber = 1;
            foreach (DataGridViewRow row in dataGridView_logs.Rows)
            {
                if (row.IsNewRow == false)
                {
                    row.HeaderCell.Value = "" + rowNumber;
                }

                rowNumber = rowNumber + 1;
            }

            dataGridView_logs.AutoResizeRowHeadersWidth(
                DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void dataGridView_logs_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridView_logs.Columns[e.ColumnIndex].Name;
            toolTip.Hide(dataGridView_logs);
            if (columnName == "actionExecutedDate")
            {
                if (sortAscending_actionExecutedDate)
                {
                    dataGridView_logs.DataSource = logListLocal.OrderBy(s => s.actionExecutedDate).ToList();
                }
                else
                {
                    dataGridView_logs.DataSource = logListLocal.OrderByDescending(s => s.actionExecutedDate).ToList();
                }

                sortAscending_actionExecutedDate = !sortAscending_actionExecutedDate;
            }


            else if (columnName == "actionType")
            {
                if (sortAscending_column_actionType)
                {
                    dataGridView_logs.DataSource = logListLocal.OrderByDescending(s => s.actionType).ToList();
                    sortAscending_column_actionType = !sortAscending_column_actionType;
                }
                else
                {
                    dataGridView_logs.DataSource = logListLocal.OrderBy(s => s.actionType).ToList();
                    sortAscending_column_actionType = !sortAscending_column_actionType;
                }
            }

            cellHeaderNumerator();
        }

        private void dataGridView_logs_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex < 0 && e.ColumnIndex >= 0)
            {
                dataGridView_logs.Cursor = Cursors.Hand;

                if (dataGridView_logs.Columns[e.ColumnIndex].Name == "actionType")
                {
                    if (sortAscending_column_actionType)
                    {
                        if (toolTip.GetToolTip(dataGridView_logs) !=
                            language.logViewerForm_tooltip_sortActionType_ascending)
                        {

                            toolTip.SetToolTip(dataGridView_logs,
                                language.logViewerForm_tooltip_sortActionType_ascending);
                            cursorX = Cursor.Position.X;
                            cursorY = Cursor.Position.Y;
                        }

                        else
                        {
                            if (cursorX == Cursor.Position.X || cursorY == Cursor.Position.Y)
                            {
                                toolTip.SetToolTip(dataGridView_logs,
                                    language.logViewerForm_tooltip_sortActionType_ascending);
                            }
                        }


                    }
                    else
                    {
                        if (toolTip.GetToolTip(dataGridView_logs) !=
                            language.logViewerForm_tooltip_sortActionType_descending)
                        {

                            toolTip.SetToolTip(dataGridView_logs,
                                language.logViewerForm_tooltip_sortActionType_descending);
                        }
                    }

                }

                else
                {
                    if (dataGridView_logs.Columns[e.ColumnIndex].Name == "actionExecutedDate")
                    {
                        if (sortAscending_actionExecutedDate)
                        {
                            if (toolTip.GetToolTip(dataGridView_logs) !=
                                language.logViewerForm_tooltip_sortActionExecutedDate_ascending)
                            {
                                toolTip.SetToolTip(dataGridView_logs,
                                    language.logViewerForm_tooltip_sortActionExecutedDate_ascending);
                            }
                        }

                        else
                        {
                            if (toolTip.GetToolTip(dataGridView_logs) !=
                                language.logViewerForm_tooltip_sortActionExecutedDate_descending)
                            {

                                toolTip.SetToolTip(dataGridView_logs,
                                    language.logViewerForm_tooltip_sortActionExecutedDate_descending);
                            }
                        }
                    }

                }
            }
            else
            {
                dataGridView_logs.Cursor = Cursors.Default;
            }
        }


        /////////////////////////////////////////
    }
}