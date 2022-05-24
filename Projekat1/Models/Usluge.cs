using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat1.Models
{
    public class Usluge
    {
        public int Id { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public string Komentar { get; set; }
        public string Datum { get; set; }
        public int Cena { get; set; }
    }
}
