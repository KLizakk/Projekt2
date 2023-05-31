using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Projekt2.Models;
using Projekt2.ViewModels;
using System.Collections.Generic;


namespace Projekt2.Views
{
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            
        }


        List<string> Lista { get; set; }

        //wyszukiwanie po Emailu klienta
        private void EnterEmail(object sender, KeyEventArgs e)
        {
            //MainWindowViewModel.Pokaz();
            if (e.Key == Key.Enter && EmailKlienta.Text != "")
            {

                MainWindowViewModel.PokazKlienta(TBimie, TBnazwisko, TBemail, TBadres, TBtelefon, EmailKlienta);
                EmailKlienta.Text = "";
            }
        }
        private void Poka�Klient�w(object sender, RoutedEventArgs e)
        {
            KatalogKlient�w katalogKlient�w = new();
            List<string> lista = new List<string>();

            foreach (var item in katalogKlient�w.KatalogKlienta())
            {
                if (!string.IsNullOrEmpty(item.Email))
                {
                    lista.Add(item.Email);
                }

            }
            Lista = lista;
            Listaa.Items = lista;
        }

        private void Poka�P�yty(object sender, RoutedEventArgs e)
        {
            List<string> lista = new();

            MainWindowViewModel.KatalogPlyt(lista);
            Listaa.Items = lista;
            
        }


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
            MainWindowViewModel.Wypozycz(WEmail, WNazwa);
        }
        private void Zwroc(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel.Zwroc(WEmail,WNazwa);

        }



    }
}