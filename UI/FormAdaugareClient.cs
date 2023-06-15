using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UI
{
    public partial class FormAdaugareClient : Form
    {
        private TextBox txtNume;
        private TextBox txtPrenume;
        private TextBox txtAdresa;
        private TextBox txtNumarTelefon;
        private TextBox txtCNP;
        private DateTimePicker dtpDataInregistrare;
        private TextBox txtNumarComenzi;
        private Button btnAdauga;
        
        public FormAdaugareClient()
        {
            InitializeComponent();
            
        }

        

        

        private bool ValidareDate(string nume, string prenume, string adresa, string numarTelefon, string cnp, DateTime dataInregistrare, int numarComenzi)
        {
            // Efectuează validarea datelor introduse
            
            // Returnează true dacă datele sunt valide, altfel false

            return !string.IsNullOrEmpty(nume) &&
                   !string.IsNullOrEmpty(prenume) &&
                   !string.IsNullOrEmpty(adresa) &&
                   !string.IsNullOrEmpty(numarTelefon) &&
                   !string.IsNullOrEmpty(cnp) &&
                   numarComenzi >= 0;
        }

        

        private void lblNume_Click(object sender, EventArgs e)
        {

        }

        private void txtAdresa_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdauga_Click_1(object sender, EventArgs e)
        {
            // Obține valorile introduse în câmpuri
            string nume = txtNume.Text;
            string prenume = txtPrenume.Text;
            string adresa = txtAdresa.Text;
            string numarTelefon = txtNumarTelefon.Text;
            string cnp = txtCNP.Text;
            DateTime dataInregistrare = dtpDataInregistrare.Value;
            int numarComenzi = int.Parse(txtNumarComenzi.Text);

            // Validează și adaugă clientul în sistem
            if (ValidareDate(nume, prenume, adresa, numarTelefon, cnp, dataInregistrare, numarComenzi))
            {
                Clienti client = new Clienti(nume, prenume, adresa, numarTelefon, cnp, dataInregistrare, numarComenzi);
                SalveazaClientInFisier(client);
                ClearFields(); // Curăță câmpurile de introducere
                MessageBox.Show("Client adăugat cu succes!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Datele introduse nu sunt valide!");
            }
        }

        private void txtNume_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrenume_TextChanged(object sender, EventArgs e)
        {

        }

        private void SalveazaClientInFisier(Clienti client)
        {
            string linie = $"{client.Nume};{client.Prenume};{client.Adresa};{client.NumarTelefon};{client.CNP};{client.DataInregistrare.ToString("yyyy-MM-dd")};{client.NumarComenzi}";
            File.AppendAllText("clienti.txt", linie + Environment.NewLine);
        }

        private void ClearFields()
        {
            txtNume.Text = string.Empty;
            txtPrenume.Text = string.Empty;
            txtAdresa.Text = string.Empty;
            txtNumarTelefon.Text = string.Empty;
            txtCNP.Text = string.Empty;
            dtpDataInregistrare.Value = DateTime.Now;
            txtNumarComenzi.Text = string.Empty;
        }
    }
}

