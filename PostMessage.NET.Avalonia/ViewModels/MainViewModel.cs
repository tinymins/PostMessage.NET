using PostMessage.NET.Avalonia.Config;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Windows.Input;
using Avalonia.Controls;
using System.Collections.Generic;
using PostMessage.NET.Avalonia.Utils;
using ReactiveUI;
using PostMessage.NET.Avalonia.Views;

namespace PostMessage.NET.Avalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
    private AppConfig _appConfig;
    private KeyConfig _selectedKeyConfig;
    private VK _selectedHotKey;
    private ObservableCollection<KeyConfig> _keyConfigs;
    private List<VK> _hotKeyOptions;

    public string Greeting => "Welcome to Avalonia!";

    public MainViewModel()
    {
        _appConfig = ConfigManager.Instance.Config;
        
        // 初始化热键选项列表
        _hotKeyOptions = Enum.GetValues(typeof(VK)).Cast<VK>().ToList();
        _selectedHotKey = _appConfig.HotKey;
        
        // 初始化按键配置列表
        _keyConfigs = new ObservableCollection<KeyConfig>(_appConfig.KeyConfigs);
        
        // 设置当前选中的按键配置
        _selectedKeyConfig = _keyConfigs.FirstOrDefault(k => k.Guid == _appConfig.CurrentGuid);
        
        // 初始化命令
        AddKeyConfigCommand = ReactiveCommand.Create(AddKeyConfig);
        EditKeyConfigCommand = ReactiveCommand.Create(EditKeyConfig);
        DeleteKeyConfigCommand = ReactiveCommand.Create(DeleteKeyConfig);
    }

    // 热键选项列表
    public List<VK> HotKeyOptions
    {
        get => _hotKeyOptions;
        set => this.RaiseAndSetIfChanged(ref _hotKeyOptions, value);
    }

    // 当前选中的热键
    public VK SelectedHotKey
    {
        get => _selectedHotKey;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedHotKey, value);
            _appConfig.HotKey = value;
            ConfigManager.Instance.SaveConfig();
        }
    }

    // 按键配置列表
    public ObservableCollection<KeyConfig> KeyConfigs
    {
        get => _keyConfigs;
        set => this.RaiseAndSetIfChanged(ref _keyConfigs, value);
    }

    // 当前选中的按键配置
    public KeyConfig SelectedKeyConfig
    {
        get => _selectedKeyConfig;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedKeyConfig, value);
            if (value != null)
            {
                _appConfig.CurrentGuid = value.Guid;
                ConfigManager.Instance.SaveConfig();
            }
        }
    }

    // 命令
    public ICommand AddKeyConfigCommand { get; }
    public ICommand EditKeyConfigCommand { get; }
    public ICommand DeleteKeyConfigCommand { get; }

    // 添加按键配置
    private async void AddKeyConfig()
    {
        var newConfig = new KeyConfig
        {
            Name = $"新配置 {_keyConfigs.Count + 1}",
            KeySequence = new List<KeyPress>
            {
                new KeyPress { nKeyCode = VK.F1, nPressTime = 10, nDelayTime = 100 }
            }
        };
        
        var editorWindow = new KeyConfigEditorView(newConfig, savedConfig => 
        {
            _appConfig.KeyConfigs.Add(savedConfig);
            _keyConfigs.Add(savedConfig);
            SelectedKeyConfig = savedConfig;
            ConfigManager.Instance.SaveConfig();
        });
        
        await editorWindow.ShowDialog(null);
    }

    // 编辑按键配置
    private async void EditKeyConfig()
    {
        if (_selectedKeyConfig != null)
        {
            var editorWindow = new KeyConfigEditorView(_selectedKeyConfig, savedConfig => 
            {
                // 更新UI
                var index = _keyConfigs.IndexOf(_selectedKeyConfig);
                if (index >= 0)
                {
                    _keyConfigs[index] = savedConfig;
                }
                
                ConfigManager.Instance.SaveConfig();
            });
            
            await editorWindow.ShowDialog(null);
        }
    }

    // 删除按键配置
    private void DeleteKeyConfig()
    {
        if (_selectedKeyConfig != null)
        {
            _appConfig.KeyConfigs.Remove(_selectedKeyConfig);
            _keyConfigs.Remove(_selectedKeyConfig);
            
            if (_keyConfigs.Count > 0)
            {
                SelectedKeyConfig = _keyConfigs[0];
            }
            else
            {
                SelectedKeyConfig = null;
                _appConfig.CurrentGuid = Guid.Empty;
            }
            
            ConfigManager.Instance.SaveConfig();
        }
    }
}
