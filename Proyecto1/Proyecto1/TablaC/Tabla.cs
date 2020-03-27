using Proyecto1.TablaT;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.TablaC
{
    class Tabla
    {
        public Lista tabla;
        public TablaTT tablaTT = new TablaTT();
        public List<DatoColumna> lst_datos;
        public List<int> lst_recorridos = new List<int>();
        public List<DatoT> lst_datoTs;
        public int contador1 = 0;
        public List<Comparador> lst_comparador = new List<Comparador>();
        public Tabla()
        {
            tabla = new Lista();
        }
        private int cont()
        {
            return ++contador1;
        }
        public void crearNodo(int numero)
        {
            if (tabla.ContainsKey(numero)) return;
            tabla.Add(numero, new List<Dato>());
        }

        public void agregarDato(int key, string transicion, int sigEstado)
        {
            List<Dato> lst_estados = (List<Dato>)tabla.get(key);
            lst_estados.Add(new Dato(sigEstado, transicion));
        }

        //public void crearprimeros(int estado)
        //{
        //    foreach (DictionaryEntry item in tabla)
        //    {
        //        List<Dato> datos = (List<Dato>)item.Value;
        //        if (estado == (int)item.Key)
        //        {
        //            foreach (Dato item2 in datos)
        //            {
        //                if (item2.Simbolo == "ε")
        //                {
        //                    if (recorridos(item2.Numero) == false)
        //                    {
        //                        lst_recorridos.Add(item2.Numero);
        //                        crearprimeros(item2.Numero);
        //                    }
        //                }
        //                else
        //                {

        //                }
        //            }
        //        }
        //    }
        //    Console.WriteLine();
        //}

        //public void crearprimero()
        //{
        //    lst_datos = new List<DatoColumna>();
        //    lst_datoTs = new List<DatoT>();
        //    // crearprimeros(1);
        //    lst_datos.Add(new DatoColumna("A" + 0, 1));
        //    int contador = 0;
        //    while (lst_datos.Count > contador)
        //    {
        //        generartabla(lst_datos.ElementAt(contador));
        //        contador++;
        //    }
        //}

        //public void generartabla(DatoColumna dato)
        //{
        //    foreach (DictionaryEntry item in tabla)
        //    {
        //        List<Dato> datos = (List<Dato>)item.Value;
        //        if (dato.Indice == (int)item.Key)
        //        {
        //            foreach (Dato item2 in datos)
        //            {
        //                if (item2.Simbolo != "ε")
        //                {
        //                    if (comparar(item2.Simbolo, (int)item.Key, item2.Numero) == true)
        //                    {
        //                        Comparador aux = Buscar(item2.Simbolo, (int)item.Key, item2.Numero);
        //                        lst_datoTs.Add(new DatoT(aux.Nombre, aux.Transicion));

        //                    }
        //                    else
        //                    {
        //                        Comparador nuevo = new Comparador(contador1, item2.Simbolo, (int)item.Key, item2.Numero);

        //                        lst_datos.Add(new DatoColumna(nuevo.Nombre, nuevo.Inicio));

        //                    }
        //                }
        //            }
        //        }
        //    }
        //    Console.WriteLine();
        //}
        //public void recorrer()
        //{
        //    foreach (DatoColumna item in lst_datos)
        //    {
        //        Console.Write(item.Estado + " ");
        //        foreach (DatoT item2 in lst_datoTs)
        //        {
        //            Console.Write(item2.Estado + "-" + item2.Transicion);
        //        }
        //        Console.WriteLine();
        //    }
        //}

        //public bool comparar(string transicion, int inicio, int fin)
        //{

        //    foreach (Comparador item in lst_comparador)
        //    {
        //        if (item.Transicion == transicion && item.Inicio == inicio && item.Fin == fin)
        //        {
        //            return true;
        //        }
        //    }
        //    lst_comparador.Add(new Comparador(cont(), transicion, inicio, fin));
        //    return false;
        //}

        //public Comparador Buscar(string transicion, int inicio, int fin)
        //{

        //    foreach (Comparador item in lst_comparador)
        //    {
        //        if (item.Transicion == transicion && item.Inicio == inicio && item.Fin == fin)
        //        {
        //            return item;
        //        }
        //    }
        //    return null;
        //}

        //public bool recorridos(int estado)
        //{
        //    foreach (int item3 in lst_recorridos)
        //    {
        //        if (estado == item3)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }

}

