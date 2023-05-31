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
        TBtelefon.Text = klient.TELEFON;
        TBAdres.Text = klient.Miasto + " " + klient.Ulica + " " + klient.NrBudynku + " " + klient.KodPocztowy;
        TBEmail.Text = klient.Email;
        TBimie.Text = klient.Imię;
        TBNazwisko.Text = klient.Nazwisko;


    }





    //public static void PokazKlienta(TextBlock TBimie, TextBlock TBNazwisko, TextBlock TBEmail, TextBlock TBAdres, TextBlock TBtelefon, TextBox tbxEmail)
    //{
    //    TBEmail.Text = string.Empty;
    //    TBNazwisko.Text = string.Empty;
    //    TBimie.Text = string.Empty;
    //    TBAdres.Text = string.Empty;
    //    TBtelefon.Text = string.Empty;
    //    string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kacper\\Desktop\\AVALONIA\\Projekt2\\DATABASE\\KolekcjaMuzyki.mdf;Integrated Security=True";
    //    string sqlEmail = $"SELECT * FROM KLIENT WHERE \"E-Mail\" = '{tbxEmail.Text}'";
    //    using (SqlConnection connection = new SqlConnection(connectionString))
    //    {
    //        connection.Open();
    //        using (SqlCommand command = new SqlCommand(sqlEmail, connection))
    //        {
    //            using (SqlDataReader reader = command.ExecuteReader())
    //            {
    //                if (reader.Read())
    //                {
    //                    string imie = reader["Imię"].ToString(); // Pobierz wartość kolumny "Imie" jako string
    //                    string nazwisko = reader["Nazwisko"].ToString();
    //                    string telefon = reader["Telefon"].ToString();
    //                    string Miasto = reader["Miasto"].ToString();
    //                    string Ulica = reader["Ulica"].ToString();
    //                    string NrBudynku = reader["NrBudynku"].ToString();
    //                    string KodPocztowy = reader["KodPocztowy"].ToString();
    //                    string Email = reader["E-Mail"].ToString();


    //                    //Przypisanie wartości do TextBoxów
    //                    TBimie.Text = imie;
    //                    TBNazwisko.Text = nazwisko;
    //                    TBtelefon.Text = telefon;
    //                    TBAdres.Text = Miasto + "ul.  " + Ulica + "nr. " + NrBudynku + "KP " + KodPocztowy;
    //                    TBEmail.Text = Email;
    //                }
    //            }
    //        }
    //        connection.Close();
    //    }


    //}

    //public static void PokazUtwor(TextBox NazwaUtworu, TextBlock LBnazwaPlyty)
    //{
    //    string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kacper\\Desktop\\AVALONIA\\Projekt2\\DATABASE\\KolekcjaMuzyki.mdf;Integrated Security=True";
    //    string ListaPlyt = $"SELECT NazwaPłyty FROM UtworyNaPłycie AS UP JOIN Utwór AS U ON U.IdUtworu = UP.IdUtworu WHERE U.NazwaUtworu = '{NazwaUtworu.Text}';";
    //    using (SqlConnection connection = new SqlConnection(connectionString))
    //    {
    //        connection.Open();
    //        using (SqlCommand command = new SqlCommand(ListaPlyt, connection))
    //        {
    //            using (SqlDataReader reader = command.ExecuteReader())
    //            {
    //                if (reader.Read())
    //                {
    //                    string NazwaPlyty = reader["NazwaPłyty"].ToString();

    //                    LBnazwaPlyty.Text = NazwaPlyty;
    //                    //Przypisanie wartości do TextBoxów

    //                }
    //            }
    //        }
    //        connection.Close();
    //    }

    //}

    public static void DodawanieKlientaOkno()
    {
        NowyKlient newWindow = new NowyKlient();
        newWindow.Show();

    }

    //public static void DodanieKlienta(TextBox Email, TextBox Imie, TextBox Nazwisko, TextBox Telefon, TextBox Miasto, TextBox Ulica, TextBox NrDomu, TextBox KodPocztowy)
    //{


    //    Klient klient = new();
    //    klient.Miasto = Miasto.Text;
    //    klient.Email = Email.Text;
    //    klient.TELEFON = Telefon.Text;
    //    klient.Ulica = Ulica.Text;
    //    klient.Imię = Imie.Text;
    //    klient.Nazwisko = Nazwisko.Text;
    //    klient.NrBudynku = NrDomu.Text;
    //    klient.KodPocztowy = KodPocztowy.Text;
    //    DodajKlienta.DodajKlientaa(klient);

    //}
    //Dodanie plyty okno
    public static void DodaniePlytyOkno()
    {
        NowaPlyta nowaPlyta = new NowaPlyta();
        nowaPlyta.Show();
    }

    //Dodanie płyty
    public static void DodajPlyte(TextBox NazwaPlyty, TextBox Ilosc)
    {

        try
        {


            int x = int.Parse(Ilosc.Text);
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kacper\\Desktop\\AVALONIA\\Projekt2\\DATABASE\\KolekcjaMuzyki.mdf;Integrated Security=True";
            string dodaniePlyty = $"INSERT Magazyn (NazwaPłyty,Ilość)\r\nVALUES('{NazwaPlyty.Text}',{x});";
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

    public static void Wypozyczenie(TextBox Email, TextBox NazwaPlyty)
    {
        try
        {



            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kacper\\Desktop\\AVALONIA\\Projekt2\\DATABASE\\KolekcjaMuzyki.mdf;Integrated Security=True";
            string dodaniePlyty = $"INSERT Wypozyczenie(\"E-mail\",NazwaPłyty,DataWypożyczenia)\r\nVALUES('{Email.Text}','{NazwaPlyty.Text}',GETDATE())";
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

