using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class ListaS
    {
        string simbolo;
        int siguiente;

        public ListaS(string simbolo, int siguiente)
        {
            this.simbolo = simbolo;
            this.siguiente = siguiente;
        }

        public string Simbolo { get => simbolo; set => simbolo = value; }
        public int Siguiente { get => siguiente; set => siguiente = value; }
    }

    class ListaE 
    {
        int siguiente;

        public ListaE(int siguiente)
        {
            this.siguiente = siguiente;
        }

        public int Siguiente { get => siguiente; set => siguiente = value; }
    }
}
