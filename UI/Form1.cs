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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormClienti formClienti = new FormClienti(); // Creează o instanță a formularului pentru gestionarea clienților
            formClienti.Show(); // Afișează formularul
            this.Hide(); // Ascunde formularul curent (meniul principal)
        }

        private void btnMobila_Click(object sender, EventArgs e)
        {
            FormMobila formMobila = new FormMobila(); // Creează o instanță a formularului pentru gestionarea mobilei
            formMobila.Show(); // Afișează formularul
            this.Hide(); // Ascunde formularul curent (meniul principal)
        }

        private void btnDepozit_Click(object sender, EventArgs e)
        {
            FormListaClienti formListaClienti = new FormListaClienti();
            FormListaMobila formListaMobila = new FormListaMobila();

            List<Clienti> listaClienti = formListaClienti.listaClientiCreataDeTine;
            List<Mobila> listaMobila = formListaMobila.listaMobilaCreataDeTine;

            FormDepozit formDepozit = new FormDepozit(listaClienti, listaMobila);

            formDepozit.Show();
            this.Hide();
        }

        private void btnIesire_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Închide aplicația
        }

        
    }
}
