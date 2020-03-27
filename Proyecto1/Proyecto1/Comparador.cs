using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Comparador
    {
        string nombre;
        string transicion;
        int inicio;
        int fin;
        public Comparador( int contador ,string transicion, int inicio, int fin)
        {
            this.nombre = "A" + contador;
            this.transicion = transicion;
            this.inicio = inicio;
            this.fin = fin;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Transicion { get => transicion; set => transicion = value; }
        public int Inicio { get => inicio; set => inicio = value; }
        public int Fin { get => fin; set => fin = value; }


        //public void letras()
        //{
        //    char letra = 'A';
        //    if (letra <= 'Z')
        //    {
        //        letra++;
        //        Console.WriteLine(letra);
        //    }
        //}

    }
}
