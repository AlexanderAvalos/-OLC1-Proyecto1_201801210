namespace Proyecto1
{
    class Valores
    {
        public string valor;

        public Valores(string valor)
        {
            this.valor = valor;
        }


    }
    class Expresion
    {
        public Tipos valorToken;
        public string simbolo;

        public Expresion(Tipos valorToken, string simbolo)
        {
            this.valorToken = valorToken;
            this.simbolo = simbolo;
        }
    }
    class Entrada
    {
        public string entrada;

        public Entrada(string entrada)
        {
            this.entrada = entrada;
        }
    }


}
