using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using PostMessage.NET.Avalonia.ViewModels;

namespace PostMessage.NET.Avalonia.Views;

public partial class MainWrapperView : UserControl
{
    public MainWrapperView()
    {
        DataContext = null;
        InitializeComponent();
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        // Lazy Initialize view model
        DataContext ??= new MainWrapperViewModel();

        base.OnApplyTemplate(e);
    }
}