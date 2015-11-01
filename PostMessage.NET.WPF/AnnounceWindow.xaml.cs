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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Threading;

namespace PostMessage.NET.WPF
{
    /// <summary>
    /// Interaction logic for AnnouncdWindow.xaml
    /// </summary>
    public partial class AnnounceWindow : Window, INotifyPropertyChanged
    {
        SynchronizationContext m_SyncContext = null;
        public AnnounceWindow()
        {
            this.Hide();
            this.DataContext = this;
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }

        // Data binding event handle.
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        // UI display.
        private string message = "This is an announcement...";
        public string Message { get { return message; } set { message = value; OnPropertyChanged("Message"); } }
        private string messageBrush = "#FF51F7FF";
        public string MessageBrush { get { return messageBrush; } set { messageBrush = value; OnPropertyChanged("MessageBrush"); } }

        // Message Animation.
        private Thread m_threadAnimate = null;
        private double m_animateStartTime = 0;
        private void Hide(int animateDuring)
        {
            m_animateStartTime = (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1))).TotalMilliseconds;
            if (m_threadAnimate == null || !m_threadAnimate.IsAlive)
            {
                m_threadAnimate = new System.Threading.Thread(() =>
                {
                    m_SyncContext.Post(SetMessageVisible, true);
                    while (GetCurrentTime() - m_animateStartTime < animateDuring)
                    {
                        m_SyncContext.Post(SetMessageOpacity, 1 - (GetCurrentTime() - m_animateStartTime) / animateDuring);
                        Thread.Sleep(50);
                    }
                    m_SyncContext.Post(SetMessageVisible, false);
                });
                m_threadAnimate.Start();
            }
        }
        private double GetCurrentTime()
        {
            return (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1))).TotalMilliseconds;
        }
        private void SetMessageOpacity(object opacity)
        {
            this.Opacity = (double)opacity;
        }
        private void SetMessageVisible(object visible)
        {
            if ((bool)visible)
                this.Show();
            else
                this.Hide();
        }

        // OutputMessage
        public void OutputMessage(string channel, string message){
            if (channel == "MSG_ANNOUNCE_RED")
                MessageBrush = "#FFFF0000";
            else if (channel == "MSG_ANNOUNCE_YELLOW")
                MessageBrush = "#FFFFFF00";
            else if (channel == "MSG_ANNOUNCE_BLUE")
                MessageBrush = "#FF51F7FF";
            Message = message;
            Hide(1500);
        }
    }
}
