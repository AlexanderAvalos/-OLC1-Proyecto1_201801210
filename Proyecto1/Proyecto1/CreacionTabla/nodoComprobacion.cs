using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.CreacionTabla
{
    public class nodoComprobacion
    {
        string estado;
        string transicion;
        int inicio;
        int fin;

        public nodoComprobacion(int numero, string transicion, int inicio, int fin)
        {
            this.estado = "A" + numero;
            this.transicion = transicion;
            this.inicio = inicio;
            this.fin = fin;
        }

        public string Estado { get => estado; set => estado = value; }
        public string Transicion { get => transicion; set => transicion = value; }
        public int Inicio { get => inicio; set => inicio = value; }
        public int Fin { get => fin; set => fin = value; }
    }
}
