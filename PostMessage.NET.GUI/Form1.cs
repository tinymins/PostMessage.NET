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

        private List<Process> m_Procs = new List<Process> { };
        private void AddProcess(Process pJX3)
        {
            ProcessStartInfo psi = null;
            psi = new ProcessStartInfo("PostMessage.exe", pJX3.Id.ToString() + " "
                + VK.F5.GetHashCode() + ",10,10;" + VK.F6.GetHashCode() + ",10,10;"
                + VK.F7.GetHashCode() + ",10,10;" + VK.F8.GetHashCode() + ",10,10"
            );
            psi.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = Process.Start(psi);
            m_Procs.Add(p);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            foreach (Process pJX3 in Process.GetProcessesByName("JX3Client"))
            {
                nCount++;
                AddProcess(pJX3);
            }
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
            foreach (Process p in m_Procs)
            {
                if (p != null && !p.HasExited)
                {
                    p.Kill();
                }
            }
            m_Procs.Clear();
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            btnStart.Text = "开始";
        }

        private int m_SpaceHeight, m_SpaceWidth, m_SplitHeight;

        private void Form1_Resize(object sender, EventArgs e)
        {
            btnStart.Width = this.Width - m_SpaceWidth;
            btnStart.Height = (this.Height - m_SpaceHeight) / 2;
            btnStop.Width = this.Width - m_SpaceWidth;
            btnStop.Height = (this.Height - m_SpaceHeight) / 2;
            btnStop.Top = btnStart.Top + btnStart.Height + m_SplitHeight;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_SpaceWidth = this.Width - btnStart.Width;
            m_SpaceHeight = this.Height - btnStart.Height - btnStop.Height;
            m_SplitHeight = btnStop.Top - btnStart.Top - btnStart.Height;
        }
    }
}
