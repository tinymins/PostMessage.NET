using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PostMessage.NET.Avalonia.Config;
using PostMessage.NET.Avalonia.ViewModels;
using System;

namespace PostMessage.NET.Avalonia.Views
{
    public partial class KeyConfigEditorView : Window
    {
        public KeyConfigEditorView()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        public KeyConfigEditorView(KeyConfig config, Action<KeyConfig> saveCallback)
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            
            DataContext = new KeyConfigEditorViewModel(config, 
                savedConfig => 
                {
                    saveCallback?.Invoke(savedConfig);
                    Close();
                }, 
                () => Close());
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}