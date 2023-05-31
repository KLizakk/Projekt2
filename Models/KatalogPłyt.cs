using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2.Models;

public class KatalogPłyt
{
    public List<Magazyn> KatalogPlyt()
    {
        List<Magazyn> magazyns = new List<Magazyn>();
        string connectionString = Connection.connectionString;
        string sqlEmail = "SELECT* FROM Magazyn";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(sqlEmail, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        while (reader.Read())
                        {
                            Magazyn m = new Magazyn();
                            m.NazwaPłyty = reader["NazwaPłyty"].ToString();
                            m.Ilość= int.Parse(reader["Ilość"].ToString());

                            magazyns.Add(m);
                        }



                        

                    }
                }
            }
            connection.Close();
        }

        return magazyns;
    }
}






