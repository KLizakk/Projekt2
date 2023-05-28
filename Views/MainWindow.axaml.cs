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
<<<<<<< HEAD
                MainWindowViewModel.PokazKlienta(TBimie, TBnazwisko, TBemail, TBadres, TBtelefon, EmailKlienta);
=======
                MainWindowViewModel.PokazKlienta(TBimie,TBnazwisko,TBemail,TBadres,TBtelefon,EmailKlienta);
>>>>>>> 1487d57bfcc4e91284d8affd50e68e5e2a2b3fdb
                EmailKlienta.Text = "";
            }
        }

        //wyszukiwanie nazw p³yt po Nazwie utworu , ma zwracac liste p³yt na których wystêpuje dany utwór
        private void UtworEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && NazwaUtworu.Text != "")
            {
<<<<<<< HEAD
                MainWindowViewModel.PokazUtwor(NazwaUtworu, LBNazwyPlyt);
=======
                MainWindowViewModel.PokazUtwor(NazwaUtworu,LBNazwyPlyt);
>>>>>>> 1487d57bfcc4e91284d8affd50e68e5e2a2b3fdb
            }
        }

        //otwiera okno dodawania klienta
        private void DodanieKlienta_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel.DodawanieKlientaOkno();
<<<<<<< HEAD


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
=======
            

>>>>>>> 1487d57bfcc4e91284d8affd50e68e5e2a2b3fdb
        }



    }
}