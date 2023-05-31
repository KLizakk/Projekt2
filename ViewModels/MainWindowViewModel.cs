using Avalonia.Controls;
using Projekt2.Views;
using Projekt2.Models;
using System.Linq;


namespace Projekt2.ViewModels;

public class MainWindowViewModel 
{

    public static void PokazKlienta(TextBlock TBimie, TextBlock TBNazwisko, TextBlock TBEmail, TextBlock TBAdres, TextBlock TBtelefon, TextBox tbxEmail)
    {
       
        KatalogKlientów katalogKlientów = new();
        
        Klient klient = katalogKlientów.KatalogKlienta().FirstOrDefault(client => client.Email == tbxEmail.Text);
        if (klient != null)
        {
            TBAdres.Text = klient.Miasto + " " + klient.Ulica + " " + klient.NrBudynku + " " + klient.KodPocztowy;
            TBEmail.Text = klient.Email;
            TBimie.Text = klient.Imię;
            TBNazwisko.Text = klient.Nazwisko;
        }

       


    }
    public static void DodawanieKlientaOkno()
    {
        NowyKlient newWindow = new NowyKlient();
        newWindow.Show();

    }

    
    public static void DodaniePlytyOkno()
    {
        NowaPlyta nowaPlyta = new NowaPlyta();
        nowaPlyta.Show();
    }

  
    public static void Wypozycz(TextBox Email, TextBox NazwaPłyty)
    {

        Wypożyczenie wypożyczenie = new();
        wypożyczenie.NazwaPłyty = NazwaPłyty.Text;
        wypożyczenie.Email = Email.Text;
        Wypożycz.Wypozyczenie(wypożyczenie);
    }

    public static void Zwroc(TextBox Email, TextBox NazwaPlyty)
    {
        Wypożyczenie zwroc = new();
        zwroc.Email = Email.Text;
        zwroc.NazwaPłyty = NazwaPlyty.Text;
        Zwrot.Zwrott(zwroc);
    }










}

