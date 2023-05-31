using Microsoft.Data.SqlClient;
using Projekt2.Views;
using System;


namespace Projekt2.Models
{
    public class Zwrot
    {
        public static void Zwrott(Wypożyczenie w)
        {
            try
            {
                string connectionString = Connection.connectionString;
                string WypozyczeniePlyty = $"UPDATE Wypozyczenie SET DataZwrotu = GETDATE()  WHERE [E-Mail] = '{w.Email}' AND NazwaPłyty = '{w.NazwaPłyty}' UPDATE Magazyn SET Ilość = Ilość+1 WHERE NazwaPłyty = '{w.NazwaPłyty}'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(WypozyczeniePlyty, connection))
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
}
