using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Transicion
    {
        private TipoThompson tipo;
        private object valor;

        public Transicion(TipoThompson tipo, object valor)
        {
            this.tipo = tipo;
            this.valor = valor;
        }

        public object Valor { get => valor; set => valor = value; }
        internal TipoThompson Tipo { get => tipo; set => tipo = value; }
    }
}
