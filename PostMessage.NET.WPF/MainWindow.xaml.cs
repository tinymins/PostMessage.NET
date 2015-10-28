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
using System.Diagnostics;

namespace PostMessage.NET.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, INotifyPropertyChanged
    {
        // Data binding event handle.
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
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
            HotKey.RegisterHotKey(wih.Handle, hotkeyPause, HotKey.KeyModifiers.None, (int)VK.PAUSE);
        }

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
                                    Status = "Posting key serial F5-F6-F7-F8 to " + m_Procs.Count + " process(es).";
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

        // Processes management.
        private Dictionary<int, Process> m_Procs = new Dictionary<int, Process> { };
        private void ToggleProcess(Process pJX3, bool bEnabled)
        {
            if (bEnabled && !m_Procs.ContainsKey(pJX3.Id))
            {
                ProcessStartInfo psi = null;
                psi = new ProcessStartInfo("PostMessage.exe", pJX3.Id.ToString() + " "
                    + VK.F5.GetHashCode() + ",10,10;" + VK.F6.GetHashCode() + ",10,10;"
                    + VK.F7.GetHashCode() + ",10,10;" + VK.F8.GetHashCode() + ",10,10"
                );
                psi.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                Process p = Process.Start(psi);
                m_Procs[pJX3.Id] = p;
            }
            else if (m_Procs.ContainsKey(pJX3.Id))
            {
                Process p = m_Procs[pJX3.Id];
                if (!p.HasExited)
                {
                    p.Kill();
                }
                m_Procs.Remove(pJX3.Id);
            }
        }
        private void ToggleProcess(Process pJX3)
        {
            ToggleProcess(pJX3, !m_Procs.ContainsKey(pJX3.Id));
        }
    }
}
