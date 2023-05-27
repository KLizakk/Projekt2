using Avalonia.Controls;
using Avalonia.Input;

using System.Data;
using Microsoft.Data.SqlClient;
using Projekt2.Views;

namespace Projekt2.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    


    public static void PokazKlienta(TextBlock TBimie, TextBlock TBNazwisko, TextBlock TBEmail, TextBlock TBAdres, TextBlock TBtelefon, TextBox tbxEmail)
    {
        TBEmail.Text = string.Empty;
        TBNazwisko.Text = string.Empty;
        TBimie.Text = string.Empty;
        TBAdres.Text = string.Empty;
        TBtelefon.Text = string.Empty;
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kacper\\Desktop\\AVALONIA\\Projekt2\\DATABASE\\KolekcjaMuzyki.mdf;Integrated Security=True";
        string sqlEmail = $"SELECT * FROM KLIENT WHERE \"E-Mail\" = '{tbxEmail.Text}'";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(sqlEmail, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string imie = reader["Imię"].ToString(); // Pobierz wartość kolumny "Imie" jako string
                        string nazwisko = reader["Nazwisko"].ToString();
                        string telefon = reader["Telefon"].ToString();
                        string Miasto = reader["Miasto"].ToString();
                        string Ulica = reader["Ulica"].ToString();
                        string NrBudynku = reader["NrBudynku"].ToString();
                        string KodPocztowy = reader["KodPocztowy"].ToString();
                        string Email = reader["E-Mail"].ToString();


                        //Przypisanie wartości do TextBoxów
                        TBimie.Text = imie;
                        TBNazwisko.Text = nazwisko;
                        TBtelefon.Text = telefon;
                        TBAdres.Text = Miasto + "ul.  " + Ulica + "nr. " + NrBudynku + "KP " + KodPocztowy;
                        TBEmail.Text = Email;
                    }
                }
            }
            connection.Close();
        }


    }

    public static void PokazUtwor(TextBox NazwaUtworu, TextBlock LBnazwaPlyty)
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kacper\\Desktop\\AVALONIA\\Projekt2\\DATABASE\\KolekcjaMuzyki.mdf;Integrated Security=True";
        string ListaPlyt = $"SELECT NazwaPłyty FROM UtworyNaPłycie AS UP JOIN Utwór AS U ON U.IdUtworu = UP.IdUtworu WHERE U.NazwaUtworu = '{NazwaUtworu.Text}';";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(ListaPlyt, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string NazwaPlyty = reader["NazwaPłyty"].ToString();

                        LBnazwaPlyty.Text = NazwaPlyty;
                        //Przypisanie wartości do TextBoxów

                    }
                }
            }
            connection.Close();
        }

    }

    public static void DodawanieKlientaOkno()
    {
        NowyKlient newWindow = new NowyKlient();
        newWindow.Show();

    }

    public static void DodanieKlienta(TextBox Email , TextBox Imie, TextBox Nazwisko,TextBox Telefon, TextBox Miasto, TextBox Ulica, TextBox NrDomu, TextBox KodPocztowy)
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kacper\\Desktop\\AVALONIA\\Projekt2\\DATABASE\\KolekcjaMuzyki.mdf;Integrated Security=True";
        string dodanieklienta = $"INSERT Klient([E-Mail],Imię,Nazwisko,TELEFON,Miasto,Ulica,NrBudynku,KodPocztowy)\r\nVALUES('{Email.Text}','{Imie.Text}','{Nazwisko.Text}','{Telefon.Text}','{Miasto.Text}','{Ulica.Text}','{NrDomu.Text}','{KodPocztowy.Text}');";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(dodanieklienta, connection))
            {

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

    }






}

