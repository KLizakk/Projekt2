using Avalonia.Controls;
using Avalonia.Interactivity;
using Projekt2.ViewModels;

namespace Projekt2.Views
{
    public partial class NowyKlient : Window
    {
        public NowyKlient()
        {
            InitializeComponent();
        }
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel.DodanieKlienta(DEmail,DImie,DNazwisko,DTelefon,DMiasto,DUlica,DNrBudynku,DKodPocztowy);
        }

    }
}
