using Avalonia.Controls;
using Projekt2.Models;


namespace Projekt2.ViewModels;

public class NowyKlientViewModel
{
    public static void DodanieKlienta(TextBox Email, TextBox Imie, TextBox Nazwisko, TextBox Telefon, TextBox Miasto, TextBox Ulica, TextBox NrDomu, TextBox KodPocztowy)
    {


        Klient klient = new();
        klient.Miasto = Miasto.Text;
        klient.Email = Email.Text;
        klient.TELEFON = Telefon.Text;
        klient.Ulica = Ulica.Text;
        klient.Imię = Imie.Text;
        klient.Nazwisko = Nazwisko.Text;
        klient.NrBudynku = NrDomu.Text;
        klient.KodPocztowy = KodPocztowy.Text;
        DodajKlienta.DodajKlientaa(klient);


    }
}
