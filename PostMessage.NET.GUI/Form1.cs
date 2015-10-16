using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PostMessage.NET.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Process> Procs = new List<Process> { };
        private void AddProcess(Process pJX3)
        {
            ProcessStartInfo psi = null;
            psi = new ProcessStartInfo("PostMessage.exe", pJX3.Id.ToString() + " 82,50,50;49,50,50");
            psi.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = Process.Start(psi);
            Procs.Add(p);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            foreach (Process pJX3 in Process.GetProcessesByName("JX3ClientX64"))
            {
                nCount++;
                AddProcess(pJX3);
            }
            if (nCount > 0)
            {
                btnStart.Text = "正在对" + nCount.ToString() + "个剑网三客户端发送按键中";
                btnStop.Enabled = true;
                btnStart.Enabled = false;
            }
            else
            {
                MessageBox.Show("进程中没有找到剑网三客户端");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            foreach (Process p in Procs)
            {
                if (p != null && !p.HasExited)
                {
                    p.Kill();
                }
            }
            Procs.Clear();
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            btnStart.Text = "开始";
        }
    }
}
