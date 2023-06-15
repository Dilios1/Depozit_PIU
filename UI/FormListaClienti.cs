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
    public partial class FormListaClienti : Form
    {
        private ListView listViewClienti;
        private Button btnDetalii;
        private Button btnSterge;
        public List<Clienti> listaClientiCreataDeTine;
        public FormListaClienti()
        {
            listaClientiCreataDeTine = new List<Clienti>(); // Inițializează lista
            InitializeComponent();
            PopuleazaListView();
            AdaugaClientiDinFisierInListView("clienti.txt");
            AfiseazaClientiInListView(listaClientiCreataDeTine); // Adaugă clienții creați de tine în ListView

        }


        private void PopuleazaListView()
        {
            listViewClienti.Items.Clear();

            
            
            

        }

        private void AfiseazaClientiInListView(List<Clienti> listaClienti)
        {
            foreach (Clienti client in listaClienti)
            {
                ListViewItem item = new ListViewItem(client.Nume);
                item.SubItems.Add(client.Prenume);
                item.SubItems.Add(client.Adresa);
                item.SubItems.Add(client.NumarTelefon);
                item.SubItems.Add(client.CNP);
                item.SubItems.Add(client.DataInregistrare.ToString());
                item.SubItems.Add(client.NumarComenzi.ToString());
                listViewClienti.Items.Add(item);
            }
        }

        








        

        private void btnDetalii_Click(object sender, EventArgs e)
        {
            if (listViewClienti.SelectedItems.Count > 0)
            {
                // Obține detaliile clientului selectat din ListView
                string nume = listViewClienti.SelectedItems[0].Text;
                string prenume = listViewClienti.SelectedItems[0].SubItems[1].Text;
                string adresa = listViewClienti.SelectedItems[0].SubItems[2].Text;
                string numarTelefon = listViewClienti.SelectedItems[0].SubItems[3].Text;
                string cnp = listViewClienti.SelectedItems[0].SubItems[4].Text;
                string dataInregistrare = listViewClienti.SelectedItems[0].SubItems[5].Text;
                string numarComenzi = listViewClienti.SelectedItems[0].SubItems[6].Text;

                // Afiseaza detaliile intr-un MessageBox
                string detaliiClient = $"Detalii client:\n" +
                    $"Nume: {nume}\n" +
                    $"Prenume: {prenume}\n" +
                    $"Adresa: {adresa}\n" +
                    $"Numar Telefon: {numarTelefon}\n" +
                    $"CNP: {cnp}\n" +
                    $"Data Inregistrare: {dataInregistrare}\n" +
                    $"Numar Comenzi: {numarComenzi}";

                MessageBox.Show(detaliiClient);
            }
            else
            {
                // Daca nu este selectat niciun client, afiseaza un mesaj de avertizare
                MessageBox.Show("Selectați un client din listă.");
            }
        }

        private void btnSterge_Click(object sender, EventArgs e)
        {
            if (listViewClienti.SelectedItems.Count > 0)
            {
                // Obține detaliile clientului selectat din ListView
                string nume = listViewClienti.SelectedItems[0].Text;
                string prenume = listViewClienti.SelectedItems[0].SubItems[1].Text;
                string adresa = listViewClienti.SelectedItems[0].SubItems[2].Text;
                string numarTelefon = listViewClienti.SelectedItems[0].SubItems[3].Text;
                string cnp = listViewClienti.SelectedItems[0].SubItems[4].Text;
                string dataInregistrare = listViewClienti.SelectedItems[0].SubItems[5].Text;
                string numarComenzi = listViewClienti.SelectedItems[0].SubItems[6].Text;

                // Afiseaza un dialog de confirmare pentru stergerea clientului
                DialogResult result = MessageBox.Show($"Doriți să ștergeți clientul:\n" +
                    $"Nume: {nume}\n" +
                    $"Prenume: {prenume}\n" +
                    $"Adresa: {adresa}\n" +
                    $"Numar Telefon: {numarTelefon}\n" +
                    $"CNP: {cnp}\n" +
                    $"Data Inregistrare: {dataInregistrare}\n" +
                    $"Numar Comenzi: {numarComenzi}",
                    "Confirmare ștergere", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    

                    // Șterge clientul selectat din ListView
                    StergeClientDinListView(listViewClienti.SelectedItems[0]);
                    PopuleazaListView();
                }
            }
        }
        
        private void AdaugaClientiDinFisierInListView(string caleFisier)
        {
            if (File.Exists(caleFisier))
            {
                string[] linii = File.ReadAllLines(caleFisier);

                foreach (string linie in linii)
                {
                    string[] valori = linie.Split(';');

                    if (valori.Length == 7)
                    {
                        string nume = valori[0];
                        string prenume = valori[1];
                        string adresa = valori[2];
                        string numarTelefon = valori[3];
                        string cnp = valori[4];
                        DateTime dataInregistrare = DateTime.Parse(valori[5]);
                        int numarComenzi = int.Parse(valori[6]);

                        Clienti client = new Clienti(nume, prenume, adresa, numarTelefon, cnp, dataInregistrare, numarComenzi);
                        listaClientiCreataDeTine.Add(client);
                    }
                    else
                    {
                        MessageBox.Show("Formatul liniei din fișier este incorect.");
                    }
                }

                // Actualizează ListView-ul cu clienții din lista combinată
                PopuleazaListView();
            }
            else
            {
                MessageBox.Show("Fișierul nu există.");
            }
        }

        private void StergeClientDinListView(ListViewItem item)
        {
            // Șterge elementul selectat din ListView
            listViewClienti.Items.Remove(item);
        }

    }
}

