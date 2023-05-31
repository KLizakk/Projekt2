using Microsoft.Data.SqlClient;
using Projekt2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2.Models;

public class DodajPłyte
{
   
    public static void DodajPlytee(Magazyn m)
    {
        try
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kacper\\Desktop\\AVALONIA\\Projekt2\\DATABASE\\KolekcjaMuzyki.mdf;Integrated Security=True";
            string dodanieplyty = $"INSERT Magazyn(NazwaPłyty,Ilość)\r\nVALUES('{m.NazwaPłyty}',{m.Ilość});";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(dodanieplyty, connection))
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




