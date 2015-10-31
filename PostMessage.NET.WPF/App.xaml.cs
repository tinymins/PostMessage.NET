using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace PostMessage.NET.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Avoid multi running.
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private const int SW_SHOWNOMAL = 1;
        private static void HandleRunningInstance(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, SW_SHOWNOMAL);
            SetForegroundWindow(instance.MainWindowHandle);
        }
        private static Process GetRuningInstance()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] Processes = Process.GetProcessesByName(currentProcess.ProcessName);
            foreach (Process process in Processes)
            {
                if (process.Id != currentProcess.Id)
                {
                    if (System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == currentProcess.MainModule.FileName)
                    {
                        return process;
                    }
                }
            }
            return null;
        }

        App()
        {
            Process process = GetRuningInstance();
            if (process != null)
            {
                HandleRunningInstance(process);
                System.Environment.Exit(1);
            }
        }
    }
}
