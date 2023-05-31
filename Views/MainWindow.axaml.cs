using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Projekt2.ViewModels;
using System;

namespace Projekt2.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //wyszukiwanie po Emailu klienta
        private void EnterEmail(object sender, KeyEventArgs e)
        {
            //MainWindowViewModel.Pokaz();
            if (e.Key == Key.Enter && EmailKlienta.Text != "")
            {

                MainWindowViewModel.PokazKlienta(TBimie, TBnazwisko, TBemail, TBadres, TBtelefon, EmailKlienta);

                MainWindowViewModel.PokazKlienta(TBimie,TBnazwisko,TBemail,TBadres,TBtelefon,EmailKlienta);

                EmailKlienta.Text = "";
            }
        }

        //wyszukiwanie nazw p³yt po Nazwie utworu , ma zwracac liste p³yt na których wystêpuje dany utwór
        private void UtworEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && NazwaUtworu.Text != "")
            {

                MainWindowViewModel.PokazUtwor(NazwaUtworu, LBNazwyPlyt);

                MainWindowViewModel.PokazUtwor(NazwaUtworu,LBNazwyPlyt);

            }
        }

        //otwiera okno dodawania klienta
        private void DodanieKlienta_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel.DodawanieKlientaOkno();



        }

        private void DodaniePlyty_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel.DodaniePlytyOkno();
        }

        private void Wypozycz(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel.Wypozyczenie(WEmail,WNazwa);
        }
        private void Zwroc(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel.Zwroc(WEmail,WNazwa);

        }



    }
}