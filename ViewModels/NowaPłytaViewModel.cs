using Avalonia.Controls;
using Microsoft.Data.SqlClient;
using Projekt2.Models;
using Projekt2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2.ViewModels
{
    public class NowaPłytaViewModel
    {
        DodajPłyte dodaj = new();

        public static void DodajPlyte(TextBox NazwaPlyty, TextBox ilosc)
        {
            Magazyn m = new Magazyn();

            try
            {
                m.NazwaPłyty = NazwaPlyty.Text;
                m.Ilość = int.Parse(ilosc.Text);

                DodajPłyte.DodajPlytee(m);
            }
           catch (Exception ex)
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.Show();
            }
        }
    }
}
