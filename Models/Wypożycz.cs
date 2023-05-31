using Microsoft.Data.SqlClient;
using Projekt2.Views;
using System;


namespace Projekt2.Models
{
    public class Wypożycz
    {
        public static void Wypozyczenie(Wypożyczenie w)
        {
            try
            {



                string connectionString = Connection.connectionString;
                string WypozyczeniePlyty= $"INSERT Wypozyczenie([E-Mail],NazwaPłyty,DataWypożyczenia) VALUES('{w.Email}','{w.NazwaPłyty}',GETDATE()) UPDATE Magazyn SET Ilość = Ilość -1 WHERE NazwaPłyty = '{w.NazwaPłyty}'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(WypozyczeniePlyty, connection))
                    {

                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                OknoSukcesu oknoSukcesu = new OknoSukcesu();
                oknoSukcesu.Show();
            }
            }
            catch (Exception ex)
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.Show();
            }
        }
    }
}
