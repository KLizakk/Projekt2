using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2.Models
{
    public class Utwór
    {
        public int IdUtworu { get; set; }
        public string NazwaUtworu { get; set; }
        public string Język { get; set; }
        public string Wykonawca { get; set; }
        public int Długość { get; set; }
        public string Kategoria { get; set; }
    }
}
