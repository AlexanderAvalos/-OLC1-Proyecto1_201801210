using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.TablaC
{
    class Dato
    {
        int numero;
        string simbolo;

        public Dato(int numero, string simbolo)
        {
            this.Simbolo = simbolo;
            this.Numero = numero;
        }

        public string Simbolo { get => simbolo; set => simbolo = value; }
        public int Numero { get => numero; set => numero = value; }

    }
}
