using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Material.Dialog;

namespace PostMessage.NET.Avalonia.Views;

public partial class HomeView : UserControl
{
    private readonly MainWindow? _window;

    public HomeView()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime app)
        {
            if (app.MainWindow is not MainWindow w)
                return;

            _window = w;
        }
        InitializeComponent();
    }

    private async void OpenDialogWithView(object? sender, RoutedEventArgs e)
    {
        //await DialogHost.Show(Resources["Sample3View"]!, "MainDialogHost");


        //SingleActionDialog dialog = new()
        //{
        //    Message = "Hello from C# code!",
        //    ButtonText = "Click me!"
        //};
        //await dialog.ShowAsync();


        var dialog = DialogHelper.CreateCustomDialog(new CustomDialogBuilderParams()
        {
            Content = new CustomDialogContentDemo(),
            StartupLocation = WindowStartupLocation.CenterOwner,
            Borderless = false,
        });

        var result = await dialog.ShowDialog(_window);
    }
}