using System;
using System.Diagnostics;

namespace runInTaskbar
{
    class Program
    {
        static void Main(string[] args)
        {
            Process.Start("Windows Shutdown Helper.exe");
        }
    }
}
