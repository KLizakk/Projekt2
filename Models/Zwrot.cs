using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2.Models
{
    public class Zwrot
    {
        public static void Zwrott(Wypożyczenie w)
        {

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kacper\\Desktop\\AVALONIA\\Projekt2\\DATABASE\\KolekcjaMuzyki.mdf;Integrated Security=True";
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
    }
}
