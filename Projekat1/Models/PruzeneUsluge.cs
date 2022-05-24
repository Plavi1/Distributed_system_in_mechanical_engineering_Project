using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat1.Models
{
    public class PruzeneUsluge
    {
        public int Korisnik { get; set; }
        public int Usluga { get; set; }
        public int Lokacija { get; set; }
        public string Opis { get; set; }
        public DateTime Vreme { get; set; }
        public int Id { get; set; }
    }
}
