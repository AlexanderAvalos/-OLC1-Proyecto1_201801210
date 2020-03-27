namespace Proyecto1
{
    class Tokens
    {
        public string lexema;
        public string lexico;
        public int Fila;
        public int Columna;
        public Tipos tipo;
        public Tokens(string lexema, string lexico, int fila, int columna, Tipos tipo)
        {
            this.lexema = lexema;
            this.lexico = lexico;
            this.Fila = fila;
            this.Columna = columna;
            this.tipo = tipo;
        }
    }
    class ErrorToken
    {
        public string lexema;
        public string Descripcion;
        public int fila;
        public int columna;

        public ErrorToken(string lexema, string descripcion, int fila, int columna)
        {
            this.lexema = lexema;
            Descripcion = descripcion;
            this.fila = fila;
            this.columna = columna;
        }
    }
    class ErrorSintactico
    {
        public string Token_Entra;
        public int fila;
        public int columna;

        public ErrorSintactico(string token_Entra, int fila, int columna)
        {
            Token_Entra = token_Entra;
            this.fila = fila;
            this.columna = columna;
        }
    }

}