using System.Collections.Generic;

namespace Proyecto1
{

    class Analizador
    {
        private string lexema = "";
        private bool cierre = false;
        private int filaL = 0;
        private int estado = 0;
        private bool continua = false;
        private int columna;
        public List<Tokens> lst_tkn = new List<Tokens>();
        public List<ErrorToken> lst_error = new List<ErrorToken>();
        public void analizadorLexico(string linea, int fila)
        {
            filaL = fila;
            char[] caracter;
            char codCaracter;
            int carac = 0;
            for (columna = 0; columna < linea.Length; columna++)
            {
                caracter = linea.ToCharArray();
                codCaracter = caracter[columna];
                carac = (int)caracter[columna];
                if (estado == 0 && continua == false)
                    estado = Iniciales(codCaracter);
                switch (estado)
                {
                    case 1:
                        if (char.IsLetterOrDigit(codCaracter))
                        {
                            lexema = lexema + codCaracter;
                            estado = 1;
                        }
                        else
                        {
                            if (reservadas(lexema) == true)
                            {
                                lst_tkn.Add(new Tokens(lexema, "Reservada", filaL, columna, Tipos.CONJNTO));
                                lexema = "";
                            }
                            else
                            {
                                lst_tkn.Add(new Tokens(lexema, "Identificador", filaL, columna, Tipos.IDENTIFICADOR));
                                lexema = "";
                            }
                            columna--;
                            estado = 0;
                        }
                        break;
                    case 2:
                        if (char.IsDigit(codCaracter))
                        {
                            lexema = lexema + codCaracter;
                            estado = 2;
                        }
                        else
                        {
                            lst_tkn.Add(new Tokens(lexema, "numero", filaL, columna, Tipos.NUMERO));
                            lexema = "";
                            estado = Iniciales(codCaracter);
                        }
                        break;

                    case 4:
                        if (carac == '"' && cierre == true)
                        {
                            lexema = lexema + codCaracter;
                            estado = 5;
                            continua = false;
                            cierre = false;
                        }
                        else
                        {
                            lexema = lexema + codCaracter;
                            estado = 4;
                            cierre = true;
                            continua = true;
                        }
                        break;
                    case 5:
                        lst_tkn.Add(new Tokens('"' + lexema, "cadena", filaL, columna, Tipos.CADENA_ENTRADA));
                        lexema = "";
                        columna--;
                        estado = 0;
                        break;
                    case 6:
                        if (carac == '!')
                        {
                            lexema = "<!";
                            estado = 7;
                        }
                        break;
                    case 7:
                        if (carac == '>' && cierre == true)
                        {
                            lexema = lexema + codCaracter;
                            estado = 8;
                            continua = false;
                            cierre = false;
                        }
                        else
                        {
                            lexema = lexema + codCaracter;
                            estado = 7;
                            cierre = true;
                            continua = true;
                        }
                        break;
                    case 8:
                        lst_tkn.Add(new Tokens(lexema, "comentario multilinea", filaL, columna, Tipos.COMENTARIO_S));
                        lexema = "";
                        estado = 0;
                        break;

                    case 10:
                        if (carac == 10 && cierre == true)
                        {
                            lexema = lexema + codCaracter;
                            estado = 11;
                            continua = false;
                            cierre = false;
                        }
                        else
                        {
                            lexema = lexema + codCaracter;
                            estado = 10;
                            cierre = true;
                            continua = true;
                        }
                        break;
                    case 11:
                        lst_tkn.Add(new Tokens("/" + lexema, "Comentario de linea", filaL, columna, Tipos.COMENTARIO_L));
                        lexema = "";
                        columna--;
                        estado = 0;
                        break;
                    case 12:
                        if (carac == '>')
                        {
                            lst_tkn.Add(new Tokens("->" + lexema, "flecha ", filaL, columna, Tipos.ASGINACION_ID));
                            lexema = "";
                            estado = 0;
                        }
                        break;
                    case 13:
                        if (carac == ':')
                        {
                            estado = 14;
                        }
                        break;
                    case 14:
                        if (carac == ']' && cierre == true)
                        {
                            lexema = lexema + codCaracter;
                            estado = 15;
                            continua = false;
                            cierre = false;
                        }
                        else
                        {
                            lexema = lexema + codCaracter;
                            estado = 14;
                            cierre = true;
                            continua = true;
                        }
                        break;
                    case 15:
                        lst_tkn.Add(new Tokens("[:" + lexema, "Todo", filaL, columna, Tipos.TODO));
                        lexema = "";
                        estado = 0;
                        break;
                    case 17:
                        if (carac == 'n')
                        {
                            lst_tkn.Add(new Tokens("salto", "salto de linea", filaL, columna, Tipos.SALTO));
                            estado = 0;
                        }
                        else if (carac == '"')
                        {
                            lst_tkn.Add(new Tokens("comilla", "comilla doble", filaL, columna, Tipos.COMILLA_D));
                            estado = 0;
                        }
                        else if (carac == 't')
                        {
                            lst_tkn.Add(new Tokens("tabulacion", "tabulacion", filaL, columna, Tipos.TABULADOR));
                            estado = 0;
                        }
                        else if (carac == 39)
                        {
                            lst_tkn.Add(new Tokens("comilla", "comilla simple", filaL, columna, Tipos.COMILLA_S));
                            estado = 0;
                        }
                        else
                        {
                            lst_tkn.Add(new Tokens(carac + "", "diagonal invertida", filaL, columna, Tipos.DIAGONALINVERTIDA));
                            estado = 0;
                        }
                        break;
                    case 20:
                        if (carac == '"')
                        {
                            estado = 21;
                        }

                        break;
                    case 21:
                        if (carac == '~' || carac == ';')
                        {
                            lst_tkn.Add(new Tokens('"' + lexema, "comilla", filaL, columna, Tipos.s_COMILLA_D));
                            lexema = "";
                            columna--;
                            estado = 0;
                        }
                        else
                        {
                            columna--;
                            estado = 4;
                        }
                        break;
                    case 22:
                        if (carac == '<')
                        {
                            estado = 23;
                        }

                        break;
                    case 23:
                        if (carac == '~' || carac == ';')
                        {
                            lst_tkn.Add(new Tokens('<' + lexema, "menor", filaL, columna, Tipos.S_MENOR));
                            lexema = "";
                            columna--;
                            estado = 0;
                        }
                        else
                        {
                            columna--;
                            estado = 6;
                        }
                        break;

                    case 24:
                        if (carac == '[')
                        {
                            estado = 25;
                        }

                        break;
                    case 25:
                        if (carac == '~' || carac == ';')
                        {
                            lst_tkn.Add(new Tokens('[' + lexema, "corchete", filaL, columna, Tipos.S_CORCHETE));
                            lexema = "";
                            columna--;
                            estado = 0;
                        }
                        else
                        {
                            columna--;
                            estado = 13;
                        }
                        break;
                    case 26:
                        if (carac == '/')
                        {
                            estado = 27;
                        }
                        break;
                    case 27:
                        if (carac == '~' || carac == ';')
                        {
                            lst_tkn.Add(new Tokens('/' + lexema, "diagonal", filaL, columna, Tipos.DIAGONAL));
                            lexema = "";
                            columna--;
                            estado = 0;
                        }
                        else
                        {
                            columna--;
                            estado = 10;
                        }
                        break;
                    case 100:
                        lst_error.Add(new ErrorToken((char)carac + lexema, "caracter invalido", filaL, columna));
                        lexema = "";
                        estado = 0;
                        break;
                }
            }
        }

        private int Iniciales(char codCaracter)
        {
            int caracter = (int)codCaracter;
            if (char.IsLetter(codCaracter))
            {
                return 1;
            }
            else if (char.IsDigit(codCaracter))
            {
                return 2;
            }
            else if (codCaracter == '"')
            {
                return 20;
            }
            else if (codCaracter == '<')
            {
                return 22;
            }
            else if (codCaracter == '/')
            {
                return 26;
            }
            else if (codCaracter == '-')
            {
                return 12;
            }
            else if (codCaracter == '[')
            {
                return 24;
            }
            else if (caracter == 92)
            {
                return 17;
            }
            else if (codCaracter == '!')
            {
                lst_tkn.Add(new Tokens(codCaracter + "", "simbolo ", filaL, columna, Tipos.SIMBOLO));
                return 0;
            }
            else if (codCaracter == ':')
            {
                lst_tkn.Add(new Tokens(codCaracter + "", "Dos puntos ", filaL, columna, Tipos.DOS_PUNTOS));
                return 0;
            }
            else if (codCaracter == ',')
            {
                lst_tkn.Add(new Tokens(codCaracter + "", "coma ", filaL, columna, Tipos.COMA));
                return 0;
            }
            else if (codCaracter == ';')
            {
                lst_tkn.Add(new Tokens(codCaracter + "", "punto y coma ", filaL, columna, Tipos.PUNTO_Y_COMA));
                return 0;
            }
            else if (codCaracter == '~')
            {
                lst_tkn.Add(new Tokens(codCaracter + "", "simbolo ", filaL, columna, Tipos.SIMBOLO_CONJ));
                return 0;
            }
            else if (codCaracter == '*')
            {
                lst_tkn.Add(new Tokens(codCaracter + "", "asterisco ", filaL, columna, Tipos.SIM_ASTERISCO));
                return 0;
            }
            else if (codCaracter == '|')
            {
                lst_tkn.Add(new Tokens(codCaracter + "", "disyuncion ", filaL, columna, Tipos.DISYUNCION));
                return 0;
            }
            else if (codCaracter == '%')
            {
                lst_tkn.Add(new Tokens(codCaracter + "", "Porcentaje ", filaL, columna, Tipos.PORCENTAJE));
                return 0;
            }
            else if (codCaracter == '?')
            {
                lst_tkn.Add(new Tokens(codCaracter + "", "interrogacion ", filaL, columna, Tipos.SIM_INTER));
                return 0;
            }
            else if (codCaracter == '+')
            {
                lst_tkn.Add(new Tokens(codCaracter + "", "más ", filaL, columna, Tipos.SIM_MAS));
                return 0;
            }
            else if (codCaracter == '{')
            {
                lst_tkn.Add(new Tokens(codCaracter + "", "Llave Izquierda ", filaL, columna, Tipos.CORCHETE_IZQUIERDO));
                return 0;
            }
            else if (codCaracter == '}')
            {
                lst_tkn.Add(new Tokens(codCaracter + "", "Llave Derecha ", filaL, columna, Tipos.CORCHETE_DERECHO));
                return 0;
            }
            else if (codCaracter == '.')
            {
                lst_tkn.Add(new Tokens(codCaracter + "", "Concatenacion ", filaL, columna, Tipos.CONCATENACION));
                return 0;
            }
            else if ((caracter > 32 && caracter <= 47) || (caracter >= 58 && caracter <= 64) || (caracter >= 91 && caracter <= 96) || (caracter >= 123 && caracter <= 125))
            {
                if (caracter == 34 || (caracter >= 42 && caracter <= 47) || (caracter >= 58 && caracter <= 60) || caracter == 63 || (caracter >= 92 && caracter <= 93) ||
                    (caracter >= 123 && caracter <= 125))
                {
                    return 0;
                }
                else
                {
                    lst_tkn.Add(new Tokens(codCaracter + "", "simbolo ", filaL, columna, Tipos.SIMBOLO));
                    return 0;
                }
            }
            else if (caracter == 9 || caracter == 13 || caracter == 32 || caracter == 10)
            {
                return 0;
            }
            else
            {
                return 100;
            }
        }
        private bool reservadas(string lexema)
        {
            if (lexema.Equals("CONJ"))
            {
                return true;
            }
            else
                return false;
        }
    }
}