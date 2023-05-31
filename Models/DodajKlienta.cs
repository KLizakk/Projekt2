using Microsoft.Data.SqlClient;
using Projekt2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2.Models
{
    public class DodajKlienta
    {
        public static void DodajKlientaa(Klient klient)
        {
            try
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kacper\\Desktop\\AVALONIA\\Projekt2\\DATABASE\\KolekcjaMuzyki.mdf;Integrated Security=True";
                string dodanieklienta = $"INSERT Klient([E-Mail],Imię,Nazwisko,TELEFON,Miasto,Ulica,NrBudynku,KodPocztowy)\r\nVALUES('{klient.Email}','{klient.Imię}','{klient.Nazwisko}','{klient.TELEFON}','{klient.Miasto}','{klient.Ulica}','{klient.NrBudynku}','{klient.KodPocztowy}');";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(dodanieklienta, connection))
                    {

                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                OknoSukcesu oknoSukcesu = new OknoSukcesu();
                oknoSukcesu.Show();

            }

            catch (Exception ex)
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.Show();
            }
        }
    }
}
