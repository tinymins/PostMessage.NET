using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Windows;
using System.Runtime.InteropServices;
using PostMessage.NET.Avalonia.Utils;

namespace PostMessage.NET.Avalonia.Config
{
    public class ConfigManager
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBoxW(int hWnd, string text, string caption, int type);

        private static ConfigManager _instance;
        private static readonly object _lock = new object();
        private string _configPath;
        private AppConfig _config;

        // 私有构造函数，防止外部实例化
        private ConfigManager()
        {
            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "PostMessage.NET");
            
            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }

            _configPath = Path.Combine(appDataPath, "config.xml");
            LoadConfig();
        }

        // 单例访问器
        public static ConfigManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ConfigManager();
                        }
                    }
                }
                return _instance;
            }
        }

        // 获取配置
        public AppConfig Config
        {
            get { return _config; }
        }

        // 加载配置
        private void LoadConfig()
        {
            try
            {
                if (File.Exists(_configPath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));
                    using (FileStream stream = new FileStream(_configPath, FileMode.Open))
                    {
                        _config = (AppConfig)serializer.Deserialize(stream);
                    }
                }
                else
                {
                    // 创建默认配置
                    ResetConfig();
                }
            }
            catch (Exception ex)
            {
                MessageBoxW(0, $"加载配置文件时出错: {ex.Message}", "配置错误", 0x00000030);
                ResetConfig();
            }
        }

        // 保存配置
        public void SaveConfig()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));
                using (FileStream stream = new FileStream(_configPath, FileMode.Create))
                {
                    serializer.Serialize(stream, _config);
                }
            }
            catch (Exception ex)
            {
                MessageBoxW(0, $"保存配置文件时出错: {ex.Message}", "配置错误", 0x00000030);
            }
        }

        // 重置配置为默认值
        public void ResetConfig()
        {
            _config = new AppConfig();
            _config.CurrentGuid = Guid.NewGuid();
            _config.KeyConfigs.Add(new KeyConfig()
            {
                Guid = _config.CurrentGuid,
                Name = "Default",
                KeySequence = new List<KeyPress>() {
                        new KeyPress() { nKeyCode = VK.F9, nPressTime = 10, nDelayTime = 100 },
                        new KeyPress() { nKeyCode = VK.F10, nPressTime = 10, nDelayTime = 100 },
                        new KeyPress() { nKeyCode = VK.F11, nPressTime = 10, nDelayTime = 100 },
                        new KeyPress() { nKeyCode = VK.F12, nPressTime = 10, nDelayTime = 100 },
                    }
            });
            SaveConfig();
        }
    }
}