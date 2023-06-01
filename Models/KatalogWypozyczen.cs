using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2.Models
{
    public class KatalogWypozyczen
    {
        public List<Wypożyczenie> Wypo()
        {
            List<Wypożyczenie> W = new();
            string connectionString = Connection.connectionString;
            string sqlEmail = "SELECT * FROM Wypozyczenie WHERE DataZwrotu is NULL";
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
                                Wypożyczenie w = new();
                                w.NazwaPłyty = reader["NazwaPłyty"].ToString();
                                w.Email = reader["E-Mail"].ToString();
                                w.DataWypożyczenia = reader["DataWypożyczenia"].ToString();
                                w.DataZwrotu = reader["DataZwrotu"].ToString();
                                W.Add(w);
                                
                            }





                        }
                    }
                }
                connection.Close();

            }
            return W;
        }


    }
}
