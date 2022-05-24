using System.Data;
using System.Xml.Linq;
using Projekat1.DataAccess;
using Projekat1.Models;

namespace Projekat1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             panel_Korisnici.Visible = false;
             panel_Lokacije.Visible = false;
             panel_Usluge.Visible = false;
             panel_PruzeneUsluge.Visible = false;
             panel_Main.Visible = false;
             panel_Orgj.Visible = true;
           


            labelOrgJedinica.Visible = false;
        }

        private void Nazad_Click(object sender, EventArgs e)
        {
            panel_Korisnici.Visible = false;
            panel_Lokacije.Visible = false;
            panel_Usluge.Visible = false;
            panel_PruzeneUsluge.Visible = false;
            panel_Main.Visible = true;

        }

        private void Korisnici_Click(object sender, EventArgs e)
        {
            panel_Korisnici.Visible = true;
            panel_Main.Visible = false;
        }
        private void Btn_Lokacije_Click(object sender, EventArgs e)
        {
            panel_Lokacije.Visible = true;
            panel_Main.Visible = false;
        }
        private void Btn_Usluge_Click(object sender, EventArgs e)
        {
            panel_Usluge.Visible = true;
            panel_Main.Visible = false;
        }
        private void Btn_PruzeneUsluge_Click(object sender, EventArgs e)
        {
            panel_PruzeneUsluge.Visible = true;
            panel_Main.Visible = false;
        }

        private void Btn_SviKorisnici_Click(object sender, EventArgs e)
        {
            dataGridViewKorisnici.DataSource = DataAccessKorisnici.GetKorisnike();
        }

        private void Btn_SacuvajKorisnika_Click_1(object sender, EventArgs e)
        {
            List<TextBox> listaTextBox = new List<TextBox>()
            {
                textBox_IdKorisnika,
                textBox_NazivKorisnika,
                textBox_SifraKorisnika,
                textBox_TipKorisnika
            };

            foreach (TextBox textBox in listaTextBox)
            {
                if(textBox.Text == "")
                {
                    MessageBox.Show($"Niste upisali neko polje. ({textBox.Name.Substring(8)})");
                    return;
                }
            }

            int id, tip;
            try
            {
                id = Convert.ToInt32(textBox_IdKorisnika.Text);
                tip = Convert.ToInt32(textBox_TipKorisnika.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Upisi brojnu vrednost za Id Korisnika ili Tip!");
                return;
            }

            DataTable korisnikVecPostoji = DataAccessKorisnici.GetKorisnika(id);

            if (korisnikVecPostoji.Rows.Count != 0)
            {
                MessageBox.Show($"Korisnik sa Id = {id} vec postoji!");
                return;
            }

            Korisnik novKorisnik = new()
            {
                Id = id,
                Tip = tip,
                Naziv = textBox_NazivKorisnika.Text,
                Sifra = textBox_SifraKorisnika.Text
            };

            DataAccessKorisnici.SaveKorisnika(novKorisnik);

            dataGridViewKorisnici.DataSource = DataAccessKorisnici.GetKorisnike();
        }

        private void Btn_PronadjiKorisnika_Click_1(object sender, EventArgs e)
        {
            int id;

            try
            {
                id = Convert.ToInt32(textBox_IdKorisnika.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Upisi brojnu vrednost za Id Korisnika!");
                return;
            }


            DataTable korisnik = DataAccessKorisnici.GetKorisnika(id);

            if (korisnik.Rows.Count == 0)
            {
                MessageBox.Show($"Nema korisnika sa Id = {id}");
            }
            else
            {
                textBox_IdKorisnika.Text = korisnik.Rows[0]["Id"].ToString();
                textBox_NazivKorisnika.Text = korisnik.Rows[0]["Naziv"].ToString();
                textBox_SifraKorisnika.Text = korisnik.Rows[0]["Sifra"].ToString();
                textBox_TipKorisnika.Text = korisnik.Rows[0]["Tip"].ToString();
            }
        }

        private void Btn_PromeniKorisnika_Click(object sender, EventArgs e)
        {
            List<TextBox> listaTextBox = new List<TextBox>()
            {
                textBox_IdKorisnika,
                textBox_NazivKorisnika,
                textBox_SifraKorisnika,
                textBox_TipKorisnika
            };

            foreach (TextBox textBox in listaTextBox)
            {
                if (textBox.Text == "")
                {
                    MessageBox.Show($"Niste upisali neko polje. ({textBox.Name.Substring(8)})");
                    return;
                }
            }

            int id, tip;
            try
            {
                id = Convert.ToInt32(textBox_IdKorisnika.Text);
                tip = Convert.ToInt32(textBox_TipKorisnika.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Upisi brojnu vrednost za Id Korisnika ili Tip!");
                return;
            }

            DataTable korisnik = DataAccessKorisnici.GetKorisnika(id);

            if (korisnik.Rows.Count == 0)
            {
                MessageBox.Show($"Korisnik sa Id = {id} ne postoji!");
                return;
            }
            
            Korisnik promenjenKorisnik = new()
            {
                Id = id,
                Tip = tip,
                Naziv = textBox_NazivKorisnika.Text,
                Sifra = textBox_SifraKorisnika.Text
            };

            DataAccessKorisnici.UpdateKorisnika(promenjenKorisnik);

            dataGridViewKorisnici.DataSource = DataAccessKorisnici.GetKorisnike();
        }

        private void Btn_ObrisiKorisnika_Click(object sender, EventArgs e)
        {
            int id;

            try
            {
                id = Convert.ToInt32(textBox_IdKorisnika.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Upisi brojnu vrednost za Id Korisnika!");
                return;
            }

            DataTable korisnik = DataAccessKorisnici.GetKorisnika(id);

            if (korisnik.Rows.Count == 0)
            {
                MessageBox.Show($"Nema korisnika sa Id = {id}");
            }
            else
            {
                DataAccessKorisnici.DeleteKorisnik(id);
            }
            dataGridViewKorisnici.DataSource = DataAccessKorisnici.GetKorisnike();
        }

        private void Btn_SveLokacije_Click(object sender, EventArgs e)
        {
            dataGridViewLokacije.DataSource = DataAccessLokacije.GetLokacije();
        }

        private void Btn_SacuvajLokaciju_Click(object sender, EventArgs e)
        {
            List<TextBox> listaTextBox = new List<TextBox>()
            {
                textBox_IdLokacije,
                textBox_NazivLokacije,
                textBox_SifraLokacije,
            };

            foreach (TextBox textBox in listaTextBox)
            {
                if (textBox.Text == "")
                {
                    MessageBox.Show($"Niste upisali neko polje. ({textBox.Name.Substring(8)})");
                    return;
                }
            }

            int id;
            try
            {
                id = Convert.ToInt32(textBox_IdLokacije.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Upisi brojnu vrednost za Id Lokacije!");
                return;
            }

            DataTable lokacijaVecPostoji = DataAccessLokacije.GetLokaciju(id);

            if (lokacijaVecPostoji.Rows.Count != 0)
            {
                MessageBox.Show($"Lokacija sa Id = {id} vec postoji!");
                return;
            }

            Lokacija novaLokacija = new()
            {
                Id = id,
                Naziv = textBox_NazivLokacije.Text,
                Sifra = textBox_SifraLokacije.Text
            };

            DataAccessLokacije.SaveLokaciju(novaLokacija);

            dataGridViewLokacije.DataSource = DataAccessLokacije.GetLokacije();
        }

        private void Btn_PronadjiLokaciju_Click(object sender, EventArgs e)
        {
            int id;

            try
            {
                id = Convert.ToInt32(textBox_IdLokacije.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Upisi brojnu vrednost za Id Lokacije!");
                return;
            }


            DataTable lokacija = DataAccessLokacije.GetLokaciju(id);

            if (lokacija.Rows.Count == 0)
            {
                MessageBox.Show($"Nema lokacije sa Id = {id}");
            }
            else
            {
                textBox_IdLokacije.Text = lokacija.Rows[0]["Id"].ToString();
                textBox_NazivLokacije.Text = lokacija.Rows[0]["Naziv"].ToString();
                textBox_SifraLokacije.Text = lokacija.Rows[0]["Sifra"].ToString();
            }

        }

        private void Btn_PromeniLokaciju_Click(object sender, EventArgs e)
        {
            List<TextBox> listaTextBox = new List<TextBox>()
            {
                textBox_IdLokacije,
                textBox_NazivLokacije,
                textBox_SifraLokacije,
            };

            foreach (TextBox textBox in listaTextBox)
            {
                if (textBox.Text == "")
                {
                    MessageBox.Show($"Niste upisali neko polje. ({textBox.Name.Substring(8)})");
                    return;
                }
            }

            int id;
            try
            {
                id = Convert.ToInt32(textBox_IdLokacije.Text);
               

            }
            catch (Exception)
            {
                MessageBox.Show("Upisi brojnu vrednost za Id Lokacije!");
                return;
            }

            DataTable lokacija = DataAccessLokacije.GetLokaciju(id);

            if (lokacija.Rows.Count == 0)
            {
                MessageBox.Show($"Lokacija sa Id = {id} ne postoji!");
                return;
            }

            Lokacija promenjenaLokacija = new()
            {
                Id = id,
                Naziv = textBox_NazivLokacije.Text,
                Sifra = textBox_SifraLokacije.Text
            };

            DataAccessLokacije.UpdateLokaciju(promenjenaLokacija);

            dataGridViewLokacije.DataSource = DataAccessLokacije.GetLokacije();
        }

        private void Btn_ObrisiLokaciju_Click(object sender, EventArgs e)
        {
            int id;

            try
            {
                id = Convert.ToInt32(textBox_IdLokacije.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Upisi brojnu vrednost za Id Lokacije!");
                return;
            }

            DataTable lokacija = DataAccessLokacije.GetLokaciju(id);

            if (lokacija.Rows.Count == 0)
            {
                MessageBox.Show($"Nema lokacije sa Id = {id}");
            }
            else
            {
                DataAccessLokacije.DeleteLokaciju(id);
            }
            dataGridViewLokacije.DataSource = DataAccessLokacije.GetLokacije();
        }

        private void Btn_XmlExportUsluge_Click(object sender, EventArgs e)
        {
            var sveUsluge = DataAccessUsluge.GetUsluge();
            
            sveUsluge.TableName = "Usluge";

            sveUsluge.WriteXml(@"C:\Users\PC\source\repos\DSUMProjekat\XmlFajlovi\SveUsluge.xml");

            /*
             List<XElement> listaXML = new();
             foreach (DataRow row in sveUsluge.Rows)
             {
                 listaXML.Add(new XElement("Usluga", new XAttribute("Id", Convert.ToInt32(row["Id"])),
                                                   new XElement("Naziv", row["Naziv"].ToString()),
                                                   new XElement("Sifra", row["Sifra"].ToString()),
                                                   new XElement("Komentar", row["Komentar"].ToString()),
                                                   new XElement("Datum", row["Datum"].ToString()),
                                                   new XElement("Cena", Convert.ToInt32(row["Cena"]))
                                                   ));
             }

             XDocument xmlDocument = new XDocument( new XDeclaration("1.0", "utf-8", "yes"),
                                                     new XElement("Usluge", listaXML ));

             xmlDocument.Save(@"C:\Users\PC\source\repos\DSUMProjekat\XmlFajlovi\SveUsluge.xml"); */

            MessageBox.Show("Sacuvali ste tabelu u XML fajlu \n Ruta: C:/Users/PC/source/repos/DSUMProjekat/XmlFajlovi/SveUsluge.xml");
        }

        private void Btn_SveUsluge_Click(object sender, EventArgs e)
        {
            dataGridViewUsluge.DataSource = DataAccessUsluge.GetUsluge();
        }

        private void Btn_PronadjiUslugu_Click(object sender, EventArgs e)
        {
            int id;

            try
            {
                id = Convert.ToInt32(textBox_IdUsluge.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Upisi brojnu vrednost za Id Usluge!");
                return;
            }


            DataTable usluge = DataAccessUsluge.GetUslugu(id);

            if (usluge.Rows.Count == 0)
            {
                MessageBox.Show($"Nema usluge sa Id = {id}");
            }
            else
            {
                textBox_IdUsluge.Text = usluge.Rows[0]["Id"].ToString();
                textBox_NazivUsluge.Text = usluge.Rows[0]["Naziv"].ToString();
                textBox_SifraUsluge.Text = usluge.Rows[0]["Sifra"].ToString();
                textBox_CenaUsluge.Text = usluge.Rows[0]["Cena"].ToString();
                textBox_KomentarUsluge.Text = usluge.Rows[0]["Komentar"].ToString();
                dateTimePickerUsluge.Text = usluge.Rows[0]["Datum"].ToString();
            }
        }

        private void Btn_XmlImportUslugu_Click(object sender, EventArgs e)
        {
            DataSet loadData = new();

            try
            {
                loadData.ReadXml(@"C:\Users\PC\source\repos\DSUMProjekat\XmlFajlovi\usluga.xml");
            }
            catch (Exception)
            {
                MessageBox.Show("Fajl sa nazivom 'usluga.xml' ne postoji na ruti: \n C:/Users/PC/source/repos/DSUMProjekat/XmlFajlovi/ ");
                return;
            }
            DataTable usluga = loadData.Tables[0];

            textBox_IdUsluge.Text = usluga.Rows[0]["Id"].ToString();
            textBox_NazivUsluge.Text = usluga.Rows[0]["Naziv"].ToString();
            textBox_SifraUsluge.Text = usluga.Rows[0]["Sifra"].ToString();
            textBox_CenaUsluge.Text = usluga.Rows[0]["Cena"].ToString();
            textBox_KomentarUsluge.Text = usluga.Rows[0]["Komentar"].ToString();
            dateTimePickerUsluge.Text = usluga.Rows[0]["Datum"].ToString();


            List<TextBox> listaTextBox = new List<TextBox>()
            {
                textBox_IdUsluge,
                textBox_NazivUsluge,
                textBox_SifraUsluge,
                textBox_CenaUsluge,
                textBox_KomentarUsluge,
            };

            foreach (TextBox textBox in listaTextBox)
            {
                if (textBox.Text == "")
                {
                    MessageBox.Show($"Niste upisali neko polje. ({textBox.Name.Substring(8)})");
                    return;
                }
            }

            int id;
            try
            {
                id = Convert.ToInt32(textBox_IdUsluge.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Upisi brojnu vrednost za Id Usluge!");
                return;
            }

            DataTable uslugaVecPostoji = DataAccessUsluge.GetUslugu(id);

            if (uslugaVecPostoji.Rows.Count != 0)
            {
                MessageBox.Show($"Usluga sa Id = {id} vec postoji!");
                return;
            }

            Usluge novaUsluga = new()
            {
                Id = id,
                Naziv = textBox_NazivUsluge.Text,
                Sifra = textBox_SifraUsluge.Text,
                Komentar = textBox_KomentarUsluge.Text,
                Datum = dateTimePickerUsluge.Text,
                Cena = Convert.ToInt32(textBox_CenaUsluge.Text)
        };

            DataAccessUsluge.SaveUsluge(novaUsluga);

            dataGridViewUsluge.DataSource = DataAccessUsluge.GetUsluge();

        }

        private void Btn_SvePruzeneUsluge_Click(object sender, EventArgs e)
        {
            dataGridViewPruzeneUsluge.DataSource = DataAccessPruzeneUsluge.GetPruzeneUsluge();
        }

        private void Btn_ExportPU_Click(object sender, EventArgs e)
        {
            var svePU = DataAccessPruzeneUsluge.GetPruzeneUsluge();

            svePU.TableName = "PruzeneUsluge";

            string nazivOrgj = Konekcija.NazivKonekcije;

            svePU.WriteXml(@$"C:\Users\PC\source\repos\DSUMProjekat\XmlFajlovi\SvePruzeneUsluge{nazivOrgj}.xml");

            MessageBox.Show($"Sacuvali ste tabelu u XML fajlu \n Ruta: C:/Users/PC/source/repos/DSUMProjekat/XmlFajlovi/SvePruzeneUsluge{nazivOrgj}.xml");
        }

        private void Btn_Beograd_Click(object sender, EventArgs e)
        {
            string nazivOrgJedinice = "Beograd";

            Konekcija.NazivKonekcije = nazivOrgJedinice;
            labelOrgJedinica.Visible = true;
            labelOrgJedinica.Text = nazivOrgJedinice;


            panel_Orgj.Visible = false;
            panel_Main.Visible = true;

        }

        private void Btn_NoviSad_Click(object sender, EventArgs e)
        {
            string nazivOrgJedinice = "NoviSad";

            Konekcija.NazivKonekcije = nazivOrgJedinice;
            labelOrgJedinica.Visible = true;
            labelOrgJedinica.Text = "Novi Sad";

            panel_Orgj.Visible = false;
            panel_Main.Visible = true;
        }

        private void Btn_Nis_Click(object sender, EventArgs e)
        {
            string nazivOrgJedinice = "Nis";

            Konekcija.NazivKonekcije = nazivOrgJedinice;
            labelOrgJedinica.Visible = true;
            labelOrgJedinica.Text = nazivOrgJedinice;

            panel_Orgj.Visible = false;
            panel_Main.Visible = true;
        }

        private void Btn_NazadNaOrgj_Click(object sender, EventArgs e)
        {
            panel_Orgj.Visible = true;
            panel_Main.Visible = false;
            labelOrgJedinica.Visible = false;
            Konekcija.NazivKonekcije = "";

            dataGridViewKorisnici.DataSource = null;
            dataGridViewLokacije.DataSource = null;
            dataGridViewPruzeneUsluge.DataSource = null;
            dataGridViewUsluge.DataSource = null;

            dataGridViewKorisnici.Rows.Clear();
            dataGridViewLokacije.Rows.Clear();
            dataGridViewPruzeneUsluge.Rows.Clear();
            dataGridViewUsluge.Rows.Clear();
        }
    }
}