using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.TablaC
{
    class nodoTabla
    {
        int key;
        List<Dato> datos;

        public nodoTabla(int key, List<Dato> datos)
        {
            this.key = key;
            this.datos = datos ?? throw new ArgumentNullException(nameof(datos));
        }

        public int Key { get => key; set => key = value; }
        internal List<Dato> Datos { get => datos; set => datos = value; }
    }
}
