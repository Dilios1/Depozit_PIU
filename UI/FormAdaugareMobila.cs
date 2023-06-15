using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormAdaugareMobila : Form
    {
        private System.Windows.Forms.RadioButton radioButtonRosu;
        private System.Windows.Forms.RadioButton radioButtonVerde;
        private System.Windows.Forms.RadioButton radioButtonAlbastru;
        private System.Windows.Forms.CheckBox checkBoxScaun;
        private System.Windows.Forms.CheckBox checkBoxMasa;
        private System.Windows.Forms.CheckBox checkBoxDulap;
       
        private string caleFisier = "mobila.txt";

        public FormAdaugareMobila()
        {
            InitializeComponent();
        }

        private void lblTitluAdaugareMobila_Click(object sender, EventArgs e)
        {

        }

        private bool ValidareDate(string tipMobila, string nume, string material, string culoare, int cantitate, double pret)
        {
            // Efectuează validarea datelor introduse
            // Poți adăuga orice validări necesare aici
            // Returnează true dacă datele sunt valide, altfel false

            return !string.IsNullOrEmpty(tipMobila) &&
                   !string.IsNullOrEmpty(nume) &&
                   !string.IsNullOrEmpty(material) &&
                   !string.IsNullOrEmpty(culoare) &&
                   cantitate > 0 &&
                   pret > 0;
        }

        private void AdaugaMobila(string culoare, string tipMobila, string nume, string material, int cantitate, double pret)
        {
            string[] tipuriMobila = tipMobila.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var tip in tipuriMobila)
            {
                Mobila mobila = new Mobila(tip, nume, material, culoare, cantitate, pret);
                Mobila.listaMobila.Add(mobila);

                AdaugaMobilaInFisier(mobila);
            }
        }





        private void btnAdaugaMobila_Click(object sender, EventArgs e)
        {
            // Obține valoarea selectată pentru culoare
            string culoare = "";

            if (radioButtonRosu.Checked)
                culoare = "Rosu";
            else if (radioButtonVerde.Checked)
                culoare = "Verde";
            else if (radioButtonAlbastru.Checked)
                culoare = "Albastru";
            else if (radioButtonNegru.Checked)
                culoare = "Negru";

            // Obține tipurile de mobilă selectate
            string tipuriMobila = "";

            if (checkBoxScaun.Checked)
                tipuriMobila += "Scaun; ";

            if (checkBoxMasa.Checked)
                tipuriMobila += "Masa; ";

            if (checkBoxDulap.Checked)
                tipuriMobila += "Dulap; ";

            string nume = textBoxNume.Text;
            string material = textBoxMaterial.Text;
            int cantitate = int.Parse(textBoxCantitate.Text);
            double pret = double.Parse(textBoxPret.Text);
            // Elimină ultima virgulă și spațiu din tipuriMobila
            if (!string.IsNullOrEmpty(tipuriMobila))
                tipuriMobila = tipuriMobila.TrimEnd(';', ' ');

            if (ValidareDate(culoare, tipuriMobila, nume, material, cantitate, pret))
            {
                AdaugaMobila(culoare, tipuriMobila, nume, material, cantitate, pret);
                MessageBox.Show("Mobila adăugată cu succes!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Datele introduse nu sunt valide!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AdaugaMobilaInFisier(Mobila mobila)
        {
            using (StreamWriter sw = new StreamWriter(caleFisier, true))
            {
                sw.WriteLine($"{mobila.TipMobila}; {mobila.Nume}; {mobila.Material}; {mobila.Culoare}; {mobila.Cantitate}; {mobila.Pret}");
            }
        }

        private void labelCuloare_Click(object sender, EventArgs e)
        {

        }
    }


}

