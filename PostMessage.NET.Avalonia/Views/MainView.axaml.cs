using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;

namespace PostMessage.NET.Avalonia.Views;

public partial class MainView : UserControl
{
    private readonly MainWindow? _window;

    public MainView()
    {
        InitializeComponent();
    }
}
