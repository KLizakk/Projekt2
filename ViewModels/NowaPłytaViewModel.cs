using Avalonia.Controls;
using Projekt2.Models;
using Projekt2.Views;
using System;


namespace Projekt2.ViewModels;

public class NowaPłytaViewModel
{
    

    public static void DodajPlyte(TextBox NazwaPlyty, TextBox ilosc)
    {
        Magazyn m = new Magazyn();

        try
        {
            m.NazwaPłyty = NazwaPlyty.Text;
            m.Ilość = int.Parse(ilosc.Text);

            DodajPłyte.DodajPlytee(m);
            OknoSukcesu oknoSukcesu = new();
            oknoSukcesu.Show();
        }
        catch (Exception ex)
        {
            ErrorWindow errorWindow = new ErrorWindow();
            
            errorWindow.Show();
        }
    }
}
