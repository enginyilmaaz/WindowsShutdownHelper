using System;
using System.Windows.Forms;
using Microsoft.Win32;
namespace WindowsShutdownHelper.functions
{
   public class startWithWindows
    {
        ////public static RegistryKey startupKey;
        public static void RunOnStartup(string appTitleName)
        {
            //if(Environment.Is64BitOperatingSystem)
            //{
            //    startupKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            //}
            //else
            //{
            //    startupKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);
            //}
            RegistryKey startupKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);
            string keyName = @"Software\Microsoft\Windows\CurrentVersion\Run";
            startupKey = startupKey.OpenSubKey(keyName, true);
            startupKey.SetValue(appTitleName, Application.ExecutablePath.ToString(), RegistryValueKind.String);
            startupKey.Close();
        }

        public static void RemoveFromStartup(string appName)
        {
            const string HKCU = "HKEY_CURRENT_USER";
            const string RUN_KEY = @"SOFTWARE\\Microsoft\Windows\CurrentVersion\Run";
            string exePath = System.Windows.Forms.Application.ExecutablePath;
            Registry.SetValue(HKCU + "\\" + RUN_KEY, appName, exePath, RegistryValueKind.String);

            if (Registry.GetValue(HKCU + "\\" + RUN_KEY,appName,false) !=null)
            {
                
            }
        }




        public static bool Is64BitOS()
        {
            if (Environment.Is64BitOperatingSystem) return true;
            else return false;         
        }










        public static bool RemoveFromStartup(string AppTitle, string AppPath)
            {
                RegistryKey rk;
                try
                {
                    rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    if (AppPath == null)
                    {
                        rk.DeleteValue(AppTitle);
                    }
                    else
                    {
                        if (rk.GetValue(AppTitle).ToString().ToLower() == AppPath.ToLower())
                        {
                            rk.DeleteValue(AppTitle);
                        }
                    }
                    return true;
                }
                catch (Exception)
                {
                }

                try
                {
                    rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    if (AppPath == null)
                    {
                        rk.DeleteValue(AppTitle);
                    }
                    else
                    {
                        if (rk.GetValue(AppTitle).ToString().ToLower() == AppPath.ToLower())
                        {
                            rk.DeleteValue(AppTitle);
                        }
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }

            /// <summary>
            /// Checks if this executable is in the startup list.
            /// </summary>
            /// <returns></returns>
            public static bool IsInStartup()
            {
                return IsInStartup(Application.ProductName, Application.ExecutablePath);
            }

            /// <summary>
            /// Checks if specified executable is in the startup list.
            /// </summary>
            /// <param name="AppTitle">Registry key title.</param>
            /// <param name="AppPath">Path of the executable.</param>
            /// <returns></returns>
            public static bool IsInStartup(string AppTitle, string AppPath)
            {
                RegistryKey rk;
                string value;

                try
                {
                    rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    value = rk.GetValue(AppTitle).ToString();
                    if (value == null)
                    {
                        return false;
                    }
                    else if (!value.ToLower().Equals(AppPath.ToLower()))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                }

                try
                {
                    rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    value = rk.GetValue(AppTitle).ToString();
                    if (value == null)
                    {
                        return false;
                    }
                    else if (!value.ToLower().Equals(AppPath.ToLower()))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                }

                return false;
            }
        }
    }


