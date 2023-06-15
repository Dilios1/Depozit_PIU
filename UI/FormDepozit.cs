using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormDepozit : Form
    {


        private List<Clienti> listaClienti;
        private List<Mobila> listaMobila;
        private List<Atribuire> listaAsocieri;



        public FormDepozit(List<Clienti> listaClienti, List<Mobila> listaMobila)
        {
            InitializeComponent();
            this.listaClienti = listaClienti;
            this.listaMobila = listaMobila;
            this.listaAsocieri = new List<Atribuire>();

            // Configurare listă de clienți
            listViewClienti.View = View.Details;
            listViewClienti.Columns.Add("Nume");
            listViewClienti.Columns.Add("Prenume");
            // Adăugare elemente în listă
            foreach (Clienti client in listaClienti)
            {
                ListViewItem item = new ListViewItem(new string[] { client.Nume, client.Prenume });
                item.Tag = client;
                listViewClienti.Items.Add(item);
            }

            // Configurare listă de mobilă
            listViewMobila.View = View.Details;
            listViewMobila.Columns.Add("Denumire");
            listViewMobila.Columns.Add("Stoc");
            // Adăugare elemente în listă
            foreach (Mobila mobila in listaMobila)
            {
                ListViewItem item = new ListViewItem(new string[] { mobila.Nume, mobila.Cantitate.ToString() });
                item.Tag = mobila;
                listViewMobila.Items.Add(item);
            }

            listViewAtribuiri.View = View.Details;
            listViewAtribuiri.Columns.Add("Nume client");
            listViewAtribuiri.Columns.Add("Prenume client");
            listViewAtribuiri.Columns.Add("Denumire mobilă");
            listViewAtribuiri.Columns.Add("Stoc mobilă");

        }





        private void ActualizeazaListViewAsocieri()
        {
            // Ștergeți toate elementele din lista de asocieri
            listViewAtribuiri.Items.Clear();

            // Adăugați noile asocieri în lista de asocieri
            foreach (Atribuire atribuire in listaAsocieri)
            {
                ListViewItem item = new ListViewItem(new string[] {
            atribuire.Client.Nume,
            atribuire.Client.Prenume,
            atribuire.Mobila.Nume,
            atribuire.Mobila.Material,
            atribuire.Mobila.Culoare,
            atribuire.Mobila.Cantitate.ToString()
        });

                // Adăugați elementul în ListView
                listViewAtribuiri.Items.Add(item);
            }
        }

        private void buttonCumpara_Click(object sender, EventArgs e)
        {
            // Verificați dacă un client și un obiect de tip mobila sunt selectate
            if (listViewClienti.SelectedItems.Count > 0 && listViewMobila.SelectedItems.Count > 0)
            {
                // Obțineți clientul selectat din lista de clienți
                Clienti clientSelectat = (Clienti)listViewClienti.SelectedItems[0].Tag;

                // Obțineți mobila selectată din lista de mobile
                Mobila mobilaSelectata = (Mobila)listViewMobila.SelectedItems[0].Tag;

                // Atribuiți obiectul de tip mobila clientului
                clientSelectat.MobilaPreferata = mobilaSelectata;

                // Adăugați asocierea în lista de asocieri
                listaAsocieri.Add(new Atribuire(clientSelectat, mobilaSelectata));

                ActualizeazaListViewAsocieri();


                // Afisați un mesaj de confirmare
                MessageBox.Show("Mobila a fost asociată clientului.");

                // Puteți efectua și alte acțiuni necesare în urma asociării
            }
            else
            {
                MessageBox.Show("Selectați un client și un obiect de tip mobila pentru a le asocia.");
            }
        }

        private void listViewClienti_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewMobila_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewAtribuiri_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonDetalii_Click(object sender, EventArgs e)
        {
            if (listViewAtribuiri.SelectedItems.Count > 0)
            {
                // Obțineți detaliile atribuirii din elementul selectat al listview-ului
                string numeClient = listViewAtribuiri.SelectedItems[0].SubItems[0].Text;
                string prenumeClient = listViewAtribuiri.SelectedItems[0].SubItems[1].Text;
                string numeMobila = listViewAtribuiri.SelectedItems[0].SubItems[2].Text;
                string materialMobila = listViewAtribuiri.SelectedItems[0].SubItems[3].Text;
                string culoareMobila = listViewAtribuiri.SelectedItems[0].SubItems[4].Text;
                string cantitateMobila = listViewAtribuiri.SelectedItems[0].SubItems[5].Text;

                // Construiți mesajul de detaliu
                string detaliiAtribuire = $"Detalii atribuire:\n" +
                    $"Nume client: {numeClient}\n" +
                    $"Prenume client: {prenumeClient}\n" +
                    $"Nume mobila: {numeMobila}\n" +
                    $"Material mobila: {materialMobila}\n" +
                    $"Culoare mobila: {culoareMobila}\n" +
                    $"Cantitate mobila: {cantitateMobila}";

                // Afișați mesajul de detaliu în MessageBox
                MessageBox.Show(detaliiAtribuire, "Detalii atribuire");
            }
            else
            {
                // Dacă nu este selectată nicio atribuire, afișați un mesaj de avertizare
                MessageBox.Show("Selectați o atribuire din listă.");
            }
        }

        private void btnInapoi_Click(object sender, EventArgs e)
        {
            // Deschide meniul de selecție a Clienti, Mobila sau Depozit
            var form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
