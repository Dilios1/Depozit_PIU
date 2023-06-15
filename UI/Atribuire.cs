using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class Atribuire
    {
        public Clienti Client { get; set; }
        public Mobila Mobila { get; set; }

        public Atribuire(Clienti client, Mobila mobila)
        {
            Client = client;
            Mobila = mobila;
        }

        //atribuire intre 2 obiecte de tip mobila si clienti
        

        public static List<Atribuire> listaAtribuiri = new List<Atribuire>();
    }
}
    

