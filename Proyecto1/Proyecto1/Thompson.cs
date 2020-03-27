using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Thompson
    {
        private NodoThomson nodo1;
        private NodoThomson nodo2;
        private Transicion transicion;
        public Thompson(NodoThomson nodo1, NodoThomson nodo2,Transicion transicion )
        {
            this.nodo1 = nodo1;
            this.nodo2 = nodo2;
            this.transicion = transicion;
        }

        public NodoThomson Nodo1 { get => nodo1; set => nodo1 = value; }
        public NodoThomson Nodo2 { get => nodo2; set => nodo2 = value; }
        internal Transicion Transicion { get => transicion; set => transicion = value; }
    }
}
