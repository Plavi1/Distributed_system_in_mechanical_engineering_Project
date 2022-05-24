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
    public class DataAccessLokacije
    {
        public static DataTable GetLokacije()
        {
            string connetionString = Konekcija.ConnectionString;

            string queryString = "Select * from tblLokacije";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter(queryString, con);
                DataTable dtbl = new DataTable();

                sqlDa.Fill(dtbl);
                return dtbl;
            }
        }

        public static DataTable GetLokaciju(int id)
        {
            string connetionString = Konekcija.ConnectionString;

            string queryString = $"Select * from tblLokacije Where Id = {id}";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter(queryString, con);
                DataTable dtbl = new DataTable();

                sqlDa.Fill(dtbl);
                return dtbl;
            }
        }

        public static void SaveLokaciju(Lokacija lokacija)
        {
            string connetionString = Konekcija.ConnectionString;

            string queryString = $"INSERT INTO tblLokacije(Id, Naziv, Sifra) VALUES({lokacija.Id}, '{lokacija.Naziv}', '{lokacija.Sifra}');";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(queryString, con);
                com.ExecuteNonQuery();
            }
        }

        public static void UpdateLokaciju(Lokacija lokacija)
        {
            string connetionString = Konekcija.ConnectionString;

            string queryString = $"UPDATE tblLokacije SET Id = {lokacija.Id} , Naziv = '{lokacija.Naziv}', Sifra = '{lokacija.Sifra}' WHERE Id = {lokacija.Id};";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(queryString, con);
                com.ExecuteNonQuery();
            }
        }
        public static void DeleteLokaciju(int id)
        {
            string connetionString = Konekcija.ConnectionString;

            string queryString = $"DELETE FROM tblLokacije WHERE Id = {id};";

            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(queryString, con);
                com.ExecuteNonQuery();
            }
        }
    }
}
