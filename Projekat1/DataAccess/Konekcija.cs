using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat1.DataAccess
{
    public static class Konekcija
    {
        private static string _nazivKonekcije = "";
        public static string NazivKonekcije 
        {
            get { return _nazivKonekcije; }
            set
            {
                if(value == "Beograd")
                {
                    ConnectionString = "Data Source = DESKTOP-MLH6E2F; Initial Catalog = DSUMBeograd; Integrated Security = True";
                }
                else if(value == "NoviSad")
                {
                    ConnectionString = "Data Source = DESKTOP-MLH6E2F; Initial Catalog = DSUMNoviSad; Integrated Security = True";
                }
                else if(value == "Nis")
                {
                    ConnectionString = "Data Source = DESKTOP-MLH6E2F; Initial Catalog = DSUMNis; Integrated Security = True";
                }
                else
                {
                    ConnectionString = "";
                }
                _nazivKonekcije = value;
            }
        }
        public static string ConnectionString { get; private set; } = "";

    }
}
