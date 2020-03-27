using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto1
{
    class sintactico
    {
        public List<Operador> lst_grafos = new List<Operador>();
        Tipos preanalisis = Tipos.S;
        List<Tokens> lst_token = new List<Tokens>();
        public List<Entrada> lst_Entrada = new List<Entrada>();
        public List<Valores> lst_conjunto = new List<Valores>();
        public List<Expresion> lst_expresion = new List<Expresion>();
        public List<ErrorSintactico> lst_Errorsintactico = new List<ErrorSintactico>();
        int indice = 0;
        bool correcto = true;

        public sintactico(List<Tokens> tokens_iniciales)
        {
            this.lst_token.Add(new Tokens("", "", 0, 0, Tipos.S));
            this.lst_token.AddRange(tokens_iniciales);
        }
        private void match(Tipos token)
        {
            if (token == preanalisis)
            {
                preanalisis = siguiente();
            }
            else
            {
                if (correcto == true)
                {
                    lst_Errorsintactico.Add(new ErrorSintactico(lst_token.ElementAt(indice).lexema, lst_token.ElementAt(indice).Fila, lst_token.ElementAt(indice).Columna));
                    Recuperar();

                }
            }
        }
        private void Recuperar()
        {
            bool salir = false;
            while (salir)
            {
                preanalisis = siguiente();
                if (preanalisis != Tipos.PUNTO_Y_COMA)
                {
                    salir = true;
                }
            }
            correcto = false;
        }
        private Tipos siguiente()
        {
            if ((lst_token.Count - 1) != indice)
            {
                indice++;
            }
            return lst_token.ElementAt(indice).tipo;
        }
        public void parser()
        {
            match(Tipos.S);
            S();
            Console.WriteLine("terminado");
        }
        public void S()
        {
            Sentencias();
        }

        private void Sentencias()
        {
            Sentencia(preanalisis);
        }
        public void Sentencia(Tipos token)
        {
            if (token == Tipos.CONJNTO)
            {
                Conjunto();
                Sentencia(preanalisis);
            }
            else if (token == Tipos.IDENTIFICADOR)
            {
                string id = "";
                id = id + lst_token.ElementAt(indice).lexema;
                match(Tipos.IDENTIFICADOR);

                if (preanalisis == Tipos.DOS_PUNTOS)
                {
                    id = id + entrada(preanalisis);
                    lst_Entrada.Add(new Entrada(id));
                }
                else if (preanalisis == Tipos.ASGINACION_ID)
                {
                   
                    Operador op = patron();
                    op.Id = id;
                    lst_grafos.Add(op);
                    Sentencia(preanalisis);
                }
            }
            else if (token == Tipos.COMENTARIO_L || token == Tipos.COMENTARIO_S)
            {
                preanalisis = siguiente();
                Sentencia(preanalisis);
            }
            else if (token == Tipos.PORCENTAJE)
            {
                match(Tipos.PORCENTAJE);
                Sentencia(preanalisis);
            }

        }
        private void Conjunto()
        {
            string linea = "";
            match(Tipos.CONJNTO);
            match(Tipos.DOS_PUNTOS);
            linea = linea + lst_token.ElementAt(indice).lexema;
            match(Tipos.IDENTIFICADOR);

            match(Tipos.ASGINACION_ID);
            lst_conjunto.Add(new Valores(linea));
            Valor(preanalisis);
            match(Tipos.PUNTO_Y_COMA);
            

        }

        public void Valor(Tipos token)
        {
            if (token == Tipos.NUMERO)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.NUMERO);
                simbolos(preanalisis);
            }
            else if (token == Tipos.IDENTIFICADOR)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.IDENTIFICADOR);
                simbolos(preanalisis);
            }
            else if (token == Tipos.CADENA_ENTRADA)
            {
                match(Tipos.CADENA_ENTRADA);
            }
            else if (token == Tipos.SIMBOLO)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.SIMBOLO);
                simbolos(preanalisis);
            }
            else if (token == Tipos.s_COMILLA_D)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.s_COMILLA_D);
                simbolos(preanalisis);
            }
            else if (token == Tipos.S_CORCHETE)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.S_CORCHETE);
                simbolos(preanalisis);
            }
            else if (token == Tipos.S_MENOR)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.S_MENOR);
                simbolos(preanalisis);
            }
            else if (token == Tipos.SALTO)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.SALTO);
                simbolos(preanalisis);
            }
            else if (token == Tipos.TABULADOR)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.TABULADOR);
                simbolos(preanalisis);
            }
            else if (token == Tipos.COMILLA_D)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.s_COMILLA_D);
                simbolos(preanalisis);
            }
            else if (token == Tipos.COMILLA_S)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.s_COMILLA_D);
                simbolos(preanalisis);
            }
            else if (token == Tipos.DIAGONALINVERTIDA)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.DIAGONALINVERTIDA);
                simbolos(preanalisis);
            }
            else if (token == Tipos.PORCENTAJE)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.PORCENTAJE);
                simbolos(preanalisis);
            }
            else if (token == Tipos.SIM_ASTERISCO)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.SIM_ASTERISCO);
                simbolos(preanalisis);
            }
            else if (token == Tipos.SIM_MAS)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.SIM_MAS);
                simbolos(preanalisis);
            }
            else if (token == Tipos.COMA)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.COMA);
                simbolos(preanalisis);
            }
            else if (token == Tipos.CONCATENACION)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.CONCATENACION);
                simbolos(preanalisis);
            }
            else if (token == Tipos.DOS_PUNTOS)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.DOS_PUNTOS);
                simbolos(preanalisis);
            }
            else if (token == Tipos.PUNTO_Y_COMA)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.PUNTO_Y_COMA);
                simbolos(preanalisis);
            }
            else if (token == Tipos.SIM_INTER)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.SIM_INTER);
                simbolos(preanalisis);
            }
            else if (token == Tipos.CORCHETE_IZQUIERDO)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.CORCHETE_IZQUIERDO);
                simbolos(preanalisis);
            }
            else if (token == Tipos.CORCHETE_DERECHO)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.CORCHETE_DERECHO);
                simbolos(preanalisis);
            }
            else if (token == Tipos.DISYUNCION)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.DISYUNCION);
                simbolos(preanalisis);
            }
            else
            {

            }
        }

        private void simbolos(Tipos token)
        {
            if (token == Tipos.SIMBOLO_CONJ)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.SIMBOLO_CONJ);
                Valor(preanalisis);
            }
            else if (token == Tipos.COMA)
            {
                lst_conjunto.Add(new Valores(lst_token.ElementAt(indice).lexema));
                match(Tipos.COMA);
                Valor(preanalisis);
            }
            else
            {

            }
        }

        private Operador patron()
        {
            match(Tipos.ASGINACION_ID);
            Operador op = expresion(preanalisis);
            match(Tipos.PUNTO_Y_COMA);
            return op;
        }

        private Operador expresion(Tipos token)
        {
            if (token == Tipos.CONCATENACION)
            {
                match(Tipos.CONCATENACION);
                Operador op1 = expresion(preanalisis);
                Operador op2 = expresion(preanalisis);
                Signo ab = new Signo(TipoSigno.Concatenacion, op1, op2);
                return new Operador(ab, TipoOperador.OPERADOR);

            }
            else if (token == Tipos.DISYUNCION)
            {
                match(Tipos.DISYUNCION);
                Operador op1 = expresion(preanalisis);
                Operador op2 = expresion(preanalisis);
                Signo ab = new Signo(TipoSigno.Disyuncion, op1, op2);
                return new Operador(ab, TipoOperador.OPERADOR);
            }
            else if (token == Tipos.SIM_INTER)
            {
                match(Tipos.SIM_INTER);
                Operador op1 = expresion(preanalisis);
                Signo ab = new Signo(TipoSigno.Interrogacion, op1);
                return new Operador(ab, TipoOperador.OPERADOR);
            }
            else if (token == Tipos.SIM_ASTERISCO)
            {
                match(Tipos.SIM_ASTERISCO);
                Operador op1 = expresion(preanalisis);
                Signo ab = new Signo(TipoSigno.Asterisco, op1);
                return new Operador(ab, TipoOperador.OPERADOR);
            }
            else if (token == Tipos.SIM_MAS)
            {
                match(Tipos.SIM_MAS);
                Operador op1 = expresion(preanalisis);
                Signo ab = new Signo(TipoSigno.Mas, op1);
                return new Operador(ab, TipoOperador.OPERADOR);
            }
            else
            {
                return new Operador(A(token), TipoOperador.STRING);
            }
        }

        private string A(Tipos token)
        {
            if (token == Tipos.NUMERO || token == Tipos.CADENA_ENTRADA || token == Tipos.IDENTIFICADOR)
            {
                string linea = "";
                linea = linea + lst_token.ElementAt(indice).lexema;
                match(token);
                return linea;
            }
            else if (token == Tipos.COMILLA_S || token == Tipos.COMILLA_D || token == Tipos.SALTO || token == Tipos.TABULADOR)
            {
                string linea = "";
                linea = linea + lst_token.ElementAt(indice).lexema;
                match(token);
                return linea;
            }
            else if (token == Tipos.CORCHETE_IZQUIERDO)
            {
                string linea = "";
                match(Tipos.CORCHETE_IZQUIERDO);
                linea = linea + lst_token.ElementAt(indice).lexema;
                match(Tipos.IDENTIFICADOR);
                match(Tipos.CORCHETE_DERECHO);
                return linea;
            }
            else
            {
                return "";
            }
        }



        public string entrada(Tipos token)
        {
            match(token);
            string linea = lst_token.ElementAt(indice).lexema;
            match(Tipos.CADENA_ENTRADA);
            match(Tipos.PUNTO_Y_COMA);
            Sentencia(preanalisis);
            return linea;
        }
    }
}
