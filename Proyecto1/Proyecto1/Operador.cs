using System;

namespace Proyecto1
{
    public class Operador
    {
        private Object dato;
        private TipoOperador tipo;

        private string id;

        public Operador(object dato, TipoOperador tipo)
        {
            this.dato = dato;
            this.tipo = tipo;
        }

        public object Dato { get => dato; set => dato = value; }
        public TipoOperador Tipo { get => tipo; set => tipo = value; }
        public string Id { get => id; set => id = value; }
    }
}
