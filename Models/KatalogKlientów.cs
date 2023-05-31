using Avalonia.Controls;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2.Models
{
    public class KatalogKlientów
    {
        public List<Klient>  KatalogKlienta()
        {
            List<Klient> katalog = new List<Klient>();

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kacper\\Desktop\\AVALONIA\\Projekt2\\DATABASE\\KolekcjaMuzyki.mdf;Integrated Security=True";
            string sqlEmail = "SELECT * FROM KLIENT";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlEmail, connection))
                {
                   
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        if (reader.Read())
                        {
                            while (reader.Read())
                            {
                                Klient k = new Klient();
                                k.Imię = reader["Imię"].ToString();
                                k.Nazwisko = reader["Nazwisko"].ToString();
                                k.TELEFON = reader["Telefon"].ToString();
                                k.Miasto = reader["Miasto"].ToString();
                                k.Ulica = reader["Ulica"].ToString();
                                k.NrBudynku = reader["NrBudynku"].ToString();
                                k.KodPocztowy = reader["KodPocztowy"].ToString();
                                k.Email = reader["E-Mail"].ToString();
                                katalog.Add(k);
                            }



                            //Przypisanie wartości do TextBoxów

                        }
                    }
                }
                connection.Close();
                
            }
            return katalog;
            
        }
    }
}
