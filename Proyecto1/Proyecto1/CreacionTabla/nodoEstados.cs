using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.CreacionTabla
{
    public class nodoEstados
    {
        string estado;
        int numero;
        List<nodoTransicion> lst_estados;

        public nodoEstados(string estado, int numeros)
        {
            this.Estado = estado;
            this.Numero = numeros;
            this.Lst_estados =  new List<nodoTransicion>();
        }

        public string Estado { get => estado; set => estado = value; }
        public int Numero { get => numero; set => numero = value; }
        internal List<nodoTransicion> Lst_estados { get => lst_estados; set => lst_estados = value; }
    }
}
