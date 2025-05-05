using PostMessage.NET.Avalonia.Utils;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PostMessage.NET.Avalonia.Config
{
    [Serializable]
    public class AppConfig
    {
        public VK HotKey { get; set; }

        public Guid CurrentGuid { get; set; }

        public List<KeyConfig> KeyConfigs { get; set; }

        public AppConfig()
        {
            HotKey = VK.PAUSE;
            CurrentGuid = Guid.Empty;
            KeyConfigs = new List<KeyConfig>();
        }
    }

    public struct KeyPress
    {
        public VK nKeyCode;
        public int nPressTime;
        public int nDelayTime;
    }

    [Serializable]
    public class KeyConfig
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public List<KeyPress> KeySequence { get; set; }

        public KeyConfig()
        {
            Guid = Guid.NewGuid();
            Name = string.Empty;
            KeySequence = new List<KeyPress>();
        }
    }
}
