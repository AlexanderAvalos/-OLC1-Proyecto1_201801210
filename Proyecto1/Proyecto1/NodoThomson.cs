using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
     class NodoThomson
    {
         private string nodo;


        public NodoThomson(string nodo)
        {
            this.nodo = nodo;

        }

        public string Nodo { get => nodo; set => nodo = value; }

   
    }
}
