using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsShutdownHelper
{
    internal static class Program
    {
        public static void CreateSetupFiles(string _sourcePath, string _destinationPath)
        {
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\" + _destinationPath);
            var sourcePath = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\" + _sourcePath + "\\";
            var destinationPath = AppDomain.CurrentDomain.BaseDirectory + "\\" + _destinationPath + "\\";

            var FilesWithFileNameOnly = Directory.GetFiles(sourcePath).Select(Path.GetFileName).ToList();
            foreach (var filename in FilesWithFileNameOnly)
                if (!File.Exists(destinationPath + filename))
                    File.Copy(sourcePath + filename, destinationPath + filename);
        }

        public static void CreateSetupFilesIfNotExist()
        {
            CreateSetupFiles("lang", "lang");
            CreateSetupFiles("settings", "");
        }

        public static Process PriorProcess()
            // Returns a System.Diagnostics.Process pointing to
            // a pre-existing process with the same name as the
            // current one, if any; or null if the current process
            // is unique.
        {
            var curr = Process.GetCurrentProcess();
            var procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (var p in procs)
                if (p.Id != curr.Id &&
                    p.MainModule.FileName == curr.MainModule.FileName)
                    return p;
            return null;
        }

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            CreateSetupFilesIfNotExist();

            if (PriorProcess() != null) return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }
    }
}