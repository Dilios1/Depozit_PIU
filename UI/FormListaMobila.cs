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
    public partial class FormListaMobila : Form
    {
        private ListView listViewMobila;
        private Button btnDetalii;
        private Button btnSterge;
        public List<Mobila> listaMobilaCreataDeTine;

        public FormListaMobila()
        {
            listaMobilaCreataDeTine = new List<Mobila>(); // Inițializează lista
            InitializeComponent();
            AdaugaMobilaDinFisierInListView("mobila.txt");
            AfiseazaMobilaInListView(listaMobilaCreataDeTine); // Adaugă mobila creată de tine în ListView
        }


        private void PopuleazaListViewMobila()
        {
            listViewMobila.Items.Clear();
            // Aici poți adăuga coloanele dorite pentru ListView-ul pentru mobila
            listViewMobila.Columns.Add("Tip mobilă");
            listViewMobila.Columns.Add("Material");
            listViewMobila.Columns.Add("Culoare");
            listViewMobila.Columns.Add("Cantitate");
            listViewMobila.Columns.Add("Preț");
        }





        private void btnDetMobila_Click_1(object sender, EventArgs e)
        {
            if (listViewMobila.SelectedItems.Count > 0)
            {
                // Obține detaliile obiectului de mobilă selectat din ListView
                string nume = listViewMobila.SelectedItems[0].SubItems[0].Text;
                string tipMobila = listViewMobila.SelectedItems[0].Text;
                string material = listViewMobila.SelectedItems[0].SubItems[1].Text;
                string culoare = listViewMobila.SelectedItems[0].SubItems[2].Text;
                string cantitate = listViewMobila.SelectedItems[0].SubItems[3].Text;
                string pret = listViewMobila.SelectedItems[0].SubItems[4].Text;

                // Afiseaza detaliile intr-un MessageBox
                string detaliiMobila = $"Detalii mobilă:\n" +
                    $"Nume: {nume}\n" +
                    $"Tip mobilă: {tipMobila}\n" +
                    $"Material: {material}\n" +
                    $"Culoare: {culoare}\n" +
                    $"Cantitate: {cantitate}\n" +
                    $"Pret: {pret}";

                MessageBox.Show(detaliiMobila);
            }
            else
            {
                // Daca nu este selectat niciun obiect de mobilă, afiseaza un mesaj de avertizare
                MessageBox.Show("Selectați un obiect de mobilă din listă.");
            }
        }

        private void btnStergeMobila_Click_1(object sender, EventArgs e)
        {
            if (listViewMobila.SelectedItems.Count > 0)
            {
                // Obține detaliile obiectului de mobilă selectat din ListView
                string nume = listViewMobila.SelectedItems[0].SubItems[0].Text;
                string tipMobila = listViewMobila.SelectedItems[0].Text;
                string material = listViewMobila.SelectedItems[0].SubItems[1].Text;
                string culoare = listViewMobila.SelectedItems[0].SubItems[2].Text;
                string cantitate = listViewMobila.SelectedItems[0].SubItems[3].Text;
                string pret = listViewMobila.SelectedItems[0].SubItems[4].Text;

                // Afiseaza un dialog de confirmare pentru stergerea obiectului de mobilă
                DialogResult result = MessageBox.Show($"Doriți să ștergeți obiectul de mobilă:\n" +
                    $"Nume: {nume}\n" +
                    $"Tip mobilă: {tipMobila}\n" +
                    $"Material: {material}\n" +
                    $"Culoare: {culoare}\n" +
                    $"Cantitate: {cantitate}\n" +
                    $"Pret: {pret}",
                    "Confirmare ștergere", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Șterge obiectul de mobilă din lista
                    StergeMobilaDinListView(listViewMobila.SelectedItems[0]);

                    // Refresh ListView după ștergere
                    PopuleazaListViewMobila();
                }
            }
            else
            {
                // Daca nu este selectat niciun obiect de mobilă, afiseaza un mesaj de avertizare
                MessageBox.Show("Selectați un obiect de mobilă din listă.");
            }
        }

        private void StergeMobilaDinListView(ListViewItem item)
        {
            Mobila mobila = listaMobilaCreataDeTine.Find(m => m.TipMobila == item.SubItems[0].Text
                                                    && m.Material == item.SubItems[1].Text
                                                    && m.Culoare == item.SubItems[2].Text
                                                    && m.Cantitate.ToString() == item.SubItems[3].Text
                                                    && m.Pret.ToString() == item.SubItems[4].Text);

            if (mobila != null)
            {
                // Șterge obiectul de mobilă din lista
                listaMobilaCreataDeTine.Remove(mobila);

                // Șterge obiectul de mobilă din ListView
                listViewMobila.Items.Remove(item);

                // Actualizează fișierul sursă cu lista de mobilă actualizată
                SalveazaMobilaInFisier("mobila.txt", listaMobilaCreataDeTine);
            }
        }

        private void AdaugaMobilaDinFisierInListView(string caleFisier)
        {
            if (File.Exists(caleFisier))
            {
                string[] linii = File.ReadAllLines(caleFisier);

                foreach (string linie in linii)
                {
                    string[] valori = linie.Split(';');

                    if (valori.Length == 6)
                    {
                        string tip = valori[0];
                        string nume = valori[1];
                        string material = valori[2];
                        string culoare = valori[3];
                        int cantitate = int.Parse(valori[4]);
                        double pret = double.Parse(valori[5]);

                        Mobila mobila = new Mobila(tip, nume, material, culoare, cantitate, pret);
                        listaMobilaCreataDeTine.Add(mobila);
                    }
                    else
                    {
                        MessageBox.Show($"Formatul liniei din fișier este incorect. Linia: {linie}");
                    }
                }

                // Actualizează ListView-ul cu mobila din lista combinată
                PopuleazaListViewMobila();
            }
            else
            {
                MessageBox.Show("Fișierul nu există.");
            }
        }

        private void AfiseazaMobilaInListView(List<Mobila> listaMobila)
        {
            foreach (Mobila mobila in listaMobila)
            {
                ListViewItem item = new ListViewItem(mobila.TipMobila);
                item.SubItems.Add(mobila.Material);
                item.SubItems.Add(mobila.Culoare);
                item.SubItems.Add(mobila.Cantitate.ToString());
                item.SubItems.Add(mobila.Pret.ToString());
                listViewMobila.Items.Add(item);
            }
        }

        private void SalveazaMobilaInFisier(string caleFisier, List<Mobila> listaMobila)
        {
            using (StreamWriter sw = new StreamWriter(caleFisier))
            {
                foreach (Mobila mobila in listaMobila)
                {
                    string linie = $"{mobila.TipMobila};{mobila.Nume};{mobila.Material};{mobila.Culoare};{mobila.Cantitate};{mobila.Pret}";
                    sw.WriteLine(linie);
                }
            }
        }



    }
}
