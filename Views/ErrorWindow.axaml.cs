using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;


namespace Projekt2.Views;

public partial class ErrorWindow : Window
{
    public ErrorWindow()
    {
        InitializeComponent();
    }

    private void OK_click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}