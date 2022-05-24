using System.Data;

namespace Centrala
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridViewBeograd.DataSource = ocitajFajl("SvePruzeneUslugeBeograd.xml");
            dataGridViewNoviSad.DataSource = ocitajFajl("SvePruzeneUslugeNoviSad.xml");
            dataGridViewNis.DataSource = ocitajFajl("SvePruzeneUslugeNis.xml");
        }
        private DataTable ocitajFajl(string nazivFajla)
        {
            DataSet loadData = new();

            try
            {
                loadData.ReadXml(@$"C:\Users\PC\source\repos\DSUMProjekat\XmlFajlovi\{nazivFajla}");
            }
            catch (Exception)
            {
                MessageBox.Show($"Fajl sa nazivom '{nazivFajla}' ne postoji na ruti: \n C:/Users/PC/source/repos/DSUMProjekat/XmlFajlovi/ ");
                return new DataTable();
            } 

            return loadData.Tables[0];

        }

    }
}