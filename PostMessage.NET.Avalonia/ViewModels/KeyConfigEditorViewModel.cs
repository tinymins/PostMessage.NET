using PostMessage.NET.Avalonia.Config;
using PostMessage.NET.Avalonia.Utils;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PostMessage.NET.Avalonia.ViewModels
{
    public class KeyConfigEditorViewModel : ViewModelBase
    {
        private string _configName;
        private ObservableCollection<KeyPressViewModel> _keySequence;
        private readonly KeyConfig _originalConfig;
        private readonly Action<KeyConfig> _saveCallback;
        private readonly Action _cancelCallback;

        public KeyConfigEditorViewModel(KeyConfig config, Action<KeyConfig> saveCallback, Action cancelCallback)
        {
            _originalConfig = config;
            _saveCallback = saveCallback;
            _cancelCallback = cancelCallback;
            
            ConfigName = config.Name;
            
            // 初始化按键序列
            _keySequence = new ObservableCollection<KeyPressViewModel>();
            foreach (var keyPress in config.KeySequence)
            {
                _keySequence.Add(new KeyPressViewModel(keyPress));
            }
            
            // 初始化命令
            AddKeyPressCommand = ReactiveCommand.Create(AddKeyPress);
            RemoveKeyPressCommand = ReactiveCommand.Create<KeyPressViewModel>(RemoveKeyPress);
            SaveCommand = ReactiveCommand.Create(Save);
            CancelCommand = ReactiveCommand.Create(Cancel);
        }

        public string ConfigName
        {
            get => _configName;
            set => this.RaiseAndSetIfChanged(ref _configName, value);
        }

        public ObservableCollection<KeyPressViewModel> KeySequence
        {
            get => _keySequence;
            set => this.RaiseAndSetIfChanged(ref _keySequence, value);
        }

        public ICommand AddKeyPressCommand { get; }
        public ICommand RemoveKeyPressCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        private void AddKeyPress()
        {
            var newKeyPress = new KeyPress { nKeyCode = VK.F1, nPressTime = 10, nDelayTime = 100 };
            KeySequence.Add(new KeyPressViewModel(newKeyPress));
        }

        private void RemoveKeyPress(KeyPressViewModel keyPress)
        {
            KeySequence.Remove(keyPress);
        }

        private void Save()
        {
            // 更新配置
            _originalConfig.Name = ConfigName;
            _originalConfig.KeySequence = KeySequence.Select(kp => new KeyPress
            {
                nKeyCode = kp.SelectedKey,
                nPressTime = kp.PressTime,
                nDelayTime = kp.DelayTime
            }).ToList();
            
            // 调用保存回调
            _saveCallback?.Invoke(_originalConfig);
        }

        private void Cancel()
        {
            _cancelCallback?.Invoke();
        }
    }

    public class KeyPressViewModel : ViewModelBase
    {
        private VK _selectedKey;
        private int _pressTime;
        private int _delayTime;
        private List<VK> _keyOptions;

        public KeyPressViewModel(KeyPress keyPress)
        {
            _selectedKey = keyPress.nKeyCode;
            _pressTime = keyPress.nPressTime;
            _delayTime = keyPress.nDelayTime;
            
            // 初始化按键选项
            _keyOptions = Enum.GetValues(typeof(VK)).Cast<VK>().ToList();
        }

        public List<VK> KeyOptions
        {
            get => _keyOptions;
            set => this.RaiseAndSetIfChanged(ref _keyOptions, value);
        }

        public VK SelectedKey
        {
            get => _selectedKey;
            set => this.RaiseAndSetIfChanged(ref _selectedKey, value);
        }

        public int PressTime
        {
            get => _pressTime;
            set => this.RaiseAndSetIfChanged(ref _pressTime, value);
        }

        public int DelayTime
        {
            get => _delayTime;
            set => this.RaiseAndSetIfChanged(ref _delayTime, value);
        }
    }
}