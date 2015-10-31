using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Windows.Interop;
using System.Diagnostics;
using System.ComponentModel;

namespace PostMessage.NET.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, INotifyPropertyChanged
    {
        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        // Garbage collecting.
        ~MainWindow()
        {
            RemoveAllProcess();
        }

        // Data binding event handle.
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        // Hotkey binding.
        int hotkeyPause;
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            HwndSource hWndSource;
            WindowInteropHelper wih = new WindowInteropHelper(this);
            hWndSource = HwndSource.FromHwnd(wih.Handle);
            hWndSource.AddHook(WndProc);
            hotkeyPause = HotKey.GlobalAddAtom("PAUSE");
            if (!HotKey.RegisterHotKey(wih.Handle, hotkeyPause, HotKey.KeyModifiers.None, (int)VK.PAUSE))
            {
                MessageBox.Show("Register Global Hotkey Failed! Please check if your PAUSE key has been occupied by other application!", "Register Hotkey Failed!", MessageBoxButton.OK, MessageBoxImage.Error);
                System.Environment.Exit(1);
            }
        }

        // Catch global hotkeys.
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case HotKey.WM_HOTKEY:
                    {
                        int sid = wParam.ToInt32();
                        if (sid == hotkeyPause)
                        {
                            int pid;
                            HotKey.GetWindowThreadProcessId(HotKey.GetForegroundWindow(), out pid);
                            Process p = Process.GetProcessById(pid);
                            if (p != null && p.ProcessName == "JX3Client" || p.ProcessName == "JX3ClientX64")
                            {
                                ToggleProcess(p);
                                if (m_Procs.Count == 0)
                                    Status = "Waiting for hotkeys...";
                                else
                                    Status = "Posting key serial F9-F10-F11-F12 to " + m_Procs.Count + " process(es).";
                            }
                        }
                        handled = true;
                        break;
                    }
            }
            return IntPtr.Zero;
        }
        
        // UI display.
        private string status = "Waiting for hotkeys...";
        public string Status { get { return status; } set { status = value; OnPropertyChanged("Status"); } }
        private string mainBrushColor = "#FF41B1E1";
        public string MainBrushColor { get { return mainBrushColor; } set { mainBrushColor = value; OnPropertyChanged("MainBrushColor"); } }
        private void metroWindow_Activated(object sender, EventArgs e)
        {
            MainBrushColor = "#FF41B1E1";
        }
        private void metroWindow_Deactivated(object sender, EventArgs e)
        {
            MainBrushColor = "#FF808080";
        }

        // Processes management.
        private Dictionary<int, Process> m_Procs = new Dictionary<int, Process> { };
        private void ToggleProcess(Process pJX3, bool bEnabled)
        {
            ToggleProcess(pJX3.Id, bEnabled);
        }
        private void ToggleProcess(int nJX3PID, bool bEnabled)
        {
            if (bEnabled && !m_Procs.ContainsKey(nJX3PID))
            {
                ProcessStartInfo psi = null;
                psi = new ProcessStartInfo("PostMessage.exe", "--active " + nJX3PID.ToString() + " "
                    + VK.F9.GetHashCode() + ",10,10;" + VK.F10.GetHashCode() + ",10,10;"
                    + VK.F11.GetHashCode() + ",10,10;" + VK.F12.GetHashCode() + ",10,10"
                );
                psi.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                Process p = Process.Start(psi);
                m_Procs[nJX3PID] = p;
            }
            else if (m_Procs.ContainsKey(nJX3PID))
            {
                Process p = m_Procs[nJX3PID];
                if (!p.HasExited)
                {
                    p.Kill();
                }
                m_Procs.Remove(nJX3PID);
            }
        }
        private void ToggleProcess(Process pJX3)
        {
            ToggleProcess(pJX3.Id, !m_Procs.ContainsKey(pJX3.Id));
        }
        private void ToggleProcess(int nJX3PID)
        {
            ToggleProcess(nJX3PID, !m_Procs.ContainsKey(nJX3PID));
        }
        private void RemoveAllProcess()
        {
            foreach (Process p in m_Procs.Values)
            {
                if (!p.HasExited)
                    p.Kill();
            }
            m_Procs.Clear();
        }
    }
}
