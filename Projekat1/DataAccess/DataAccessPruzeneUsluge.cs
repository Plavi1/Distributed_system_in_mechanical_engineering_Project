using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat1.DataAccess
{
    public class DataAccessPruzeneUsluge
    {
        public static DataTable GetPruzeneUsluge()
        {
            string connetionString = Konekcija.ConnectionString;

            string queryString = @" SELECT Id, Naziv_Korisnika, Naziv_Usluge, Naziv_Lokacije, Vreme, Opis
                                    From tblPreuzeneUsluge as pu
                                    INNER JOIN (SELECT Id as Idk, Naziv as Naziv_Korisnika from tblKorisnici) as korisnici
                                    ON pu.Korisnik = korisnici.Idk
                                    INNER JOIN (SELECT Id as Idu, Naziv as Naziv_Usluge from tblUsluge) as usluge
                                    ON pu.Usluga = usluge.Idu
                                    INNER JOIN (SELECT Id as Idl, Naziv as Naziv_Lokacije from tblLokacije) as lokacije
                                    ON pu.Lokacija = lokacije.Idl";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter(queryString, con);
                DataTable dtbl = new DataTable();

                sqlDa.Fill(dtbl);
                return dtbl;
            }
        }
    }
}
