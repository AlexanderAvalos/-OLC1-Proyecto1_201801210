using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.TablaT
{
    public class DatoT
    {
        string estado;
        string transicion;

        public DatoT(string estado, string transicion)
        {
            this.estado = estado;
            this.transicion = transicion;
        }

        public string Estado { get => estado; set => estado = value; }
        public string Transicion { get => transicion; set => transicion = value; }
    }
}
