using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Projekt2.ViewModels;

namespace Projekt2.Views;

public partial class NowaPlyta : Window
{
    public NowaPlyta()
    {
        InitializeComponent();
    }

    private void Dodaj_Click(object sender, RoutedEventArgs e)
    {
        MainWindowViewModel.DodajPlyte(NazwaPlyty,Ilosc);
    }
}