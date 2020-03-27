using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.CreacionTabla
{
    class nodoTransicion
    {
        string transicion;
        string estado;

        public nodoTransicion(string transicion, string estado)
        {
            this.Transicion = transicion;
            this.Estado = estado;
        }

        public string Transicion { get => transicion; set => transicion = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
