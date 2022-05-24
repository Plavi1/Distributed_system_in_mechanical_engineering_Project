using Projekat1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat1.DataAccess
{
    public static class DataAccessKorisnici
    {
        public static DataTable GetKorisnike()
        {
            string connetionString = Konekcija.ConnectionString;

            string queryString = "Select * from tblKorisnici";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter(queryString, con);
                DataTable dtbl = new DataTable();

                sqlDa.Fill(dtbl);
                return dtbl;
            }
        }

        public static DataTable GetKorisnika(int id)
        {
            string connetionString = Konekcija.ConnectionString;

            string queryString = $"Select * from tblKorisnici Where Id = {id}";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter(queryString, con);
                DataTable dtbl = new DataTable();

                sqlDa.Fill(dtbl);
                return dtbl;
            }
        }

        public static void SaveKorisnika(Korisnik korisnik)
        {
            string connetionString = Konekcija.ConnectionString;

            string queryString = $"INSERT INTO tblKorisnici(Id, Naziv, Sifra, Tip) VALUES({korisnik.Id}, '{korisnik.Naziv}', '{korisnik.Sifra}', {korisnik.Tip});";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(queryString, con);
                com.ExecuteNonQuery();
            }
        }
        
        public static void UpdateKorisnika(Korisnik korisnik)
        {
            string connetionString = Konekcija.ConnectionString;

            string queryString = $"UPDATE tblKorisnici SET Id = {korisnik.Id} , Naziv = '{korisnik.Naziv}', Sifra = '{korisnik.Sifra}', Tip = {korisnik.Tip}  WHERE Id = {korisnik.Id};";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(queryString, con);
                com.ExecuteNonQuery();
            }
        }
        public static void DeleteKorisnik(int id)
        {
            string connetionString = Konekcija.ConnectionString;

            string queryString = $"DELETE FROM tblKorisnici WHERE Id = {id};";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(queryString, con);
                com.ExecuteNonQuery();
            }
        }
    }
}
