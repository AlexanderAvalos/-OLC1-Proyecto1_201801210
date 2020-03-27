namespace Proyecto1
{
    public class Signo
    {


        public TipoSigno ope;
        public string nombre;
        public Operador operador1, operador2;

        public Signo(TipoSigno tipos, Operador operador1, Operador operador2)
        {
            this.ope = tipos;
            this.operador1 = operador1;
            this.operador2 = operador2;
        }
        public Signo(TipoSigno tipos, Operador operador1)
        {
            this.ope = tipos;
            this.operador1 = operador1;
            this.operador2 = null;
        }

        public Signo(string nombre)
        {
            this.nombre = nombre;
            this.operador2 = null;
            this.operador1 = null;
        }


    }

}
