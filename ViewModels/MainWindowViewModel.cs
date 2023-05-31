using Avalonia.Controls;
using Avalonia.Input;

using System.Data;
using Microsoft.Data.SqlClient;
using Projekt2.Views;

using System;
using JetBrains.Annotations;
using Projekt2.Models;
using System.Linq;
using System.IO;

namespace Projekt2.ViewModels;

public class MainWindowViewModel : ViewModelBase
{

    public static void PokazKlienta(TextBlock TBimie, TextBlock TBNazwisko, TextBlock TBEmail, TextBlock TBAdres, TextBlock TBtelefon, TextBox tbxEmail)
    {
       
        KatalogKlientów katalogKlientów = new();
        
        Klient klient = katalogKlientów.KatalogKlienta().FirstOrDefault(client => client.Email == tbxEmail.Text);
        //if (klient == null) { throw new Exception("Nie znaleziono klienta o podanym emailu"); }

        TBAdres.Text = klient.Miasto + " " + klient.Ulica + " " + klient.NrBudynku + " " + klient.KodPocztowy;
        TBEmail.Text = klient.Email;
        TBimie.Text = klient.Imię;
        TBNazwisko.Text = klient.Nazwisko;


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
        try
        {



            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kacper\\Desktop\\AVALONIA\\Projekt2\\DATABASE\\KolekcjaMuzyki.mdf;Integrated Security=True";
            string dodaniePlyty = $"UPDATE Wypozyczenie\r\nSET DataZwrotu = GETDATE()\r\nWHERE NazwaPłyty = '{NazwaPlyty.Text}'\r\nAND [E-Mail] = '{Email.Text}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(dodaniePlyty, connection))
                {

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        catch (Exception ex)
        {
            ErrorWindow errorWindow = new ErrorWindow();
            errorWindow.Show();
        }
    }


 







}

