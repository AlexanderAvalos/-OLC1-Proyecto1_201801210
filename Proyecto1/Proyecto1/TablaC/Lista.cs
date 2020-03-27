using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.TablaC
{
    class Lista
    {
        public List<nodoTabla> tabla;

        public Lista()
        {
            this.tabla = new List<nodoTabla>();
        }

        public object Values() {
            return this.tabla;
        }
        
        public bool ContainsKey(int key) {
            foreach (nodoTabla item in tabla)
            {
                if (item.Key == key) return true;
            }
            return false;
        }

        public void Add(int key, List<Dato> lst) {
            tabla.Add(new nodoTabla(key, lst));
        }

        public List<Dato> get(int key) {
            foreach (nodoTabla item in tabla)
            {
                if (item.Key == key) return item.Datos;
            }
            return null;
        }

        public List<nodoTabla> get() {
            return this.tabla;
        }
    }
}
