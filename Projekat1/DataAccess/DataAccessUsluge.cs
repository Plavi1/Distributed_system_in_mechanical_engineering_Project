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
    public class DataAccessUsluge
    {
        public static DataTable GetUsluge()
        {
            string connetionString = Konekcija.ConnectionString;

            string queryString = "Select * from tblUsluge";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter(queryString, con);
                DataTable dtbl = new DataTable();

                sqlDa.Fill(dtbl);
                return dtbl;
            }
        }

        public static DataTable GetUslugu(int id)
        {
            string connetionString = Konekcija.ConnectionString;

            string queryString = $"Select * from tblUsluge Where Id = {id}";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter(queryString, con);
                DataTable dtbl = new DataTable();

                sqlDa.Fill(dtbl);
                return dtbl;
            }
        }

        public static void SaveUsluge(Usluge usluge)
        {
            string connetionString = Konekcija.ConnectionString;

            string queryString = $"INSERT INTO tblUsluge(Id, Naziv, Sifra, Komentar, Cena, Datum) VALUES({usluge.Id}, '{usluge.Naziv}', '{usluge.Sifra}', '{usluge.Komentar}', {usluge.Cena}, '{usluge.Datum}');";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(queryString, con);
                com.ExecuteNonQuery();
            }
        }

        public static void UpdateUslugu(Usluge usluge)
        {
            string connetionString = Konekcija.ConnectionString;

            string queryString = $"UPDATE tblUsluge SET Id = {usluge.Id} , Naziv = '{usluge.Naziv}', Sifra = '{usluge.Sifra}',Komentar = '{usluge.Komentar}', Cena = {usluge.Cena}, Datum = '{usluge.Datum}'   WHERE Id = {usluge.Id};";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(queryString, con);
                com.ExecuteNonQuery();
            }
        }
        public static void DeleteUslugu(int id)
        {
            string connetionString = Konekcija.ConnectionString;

            string queryString = $"DELETE FROM tblUsluge WHERE Id = {id};";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(queryString, con);
                com.ExecuteNonQuery();
            }
        }
    }
}
