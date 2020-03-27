using Proyecto1.TablaC;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Proyecto1
{//lst_tablaT.Add(new TablaTransicion(operadorA.Dato.ToString(), nodo2.Nodo));
 // lst_tabla.Add(new Tabla(nodo1, lst_tablaT));
    class Grafica_Thompson
    {
        public static StringBuilder sbG;
        public Grafica_Thompson Grafica;
        public string rpng, ruta;
        public List<string> lst_grafica = new List<string>();
        public List<Thompson> lst_nodo = new List<Thompson>();

        public int contador = 1;
        private string nombre;
        public int inicio, fin;
        public int inicio1, fin1;
        public int inicio2, fin2, t;
        public int inicio3, fin3, t1;
        public int inicio4, fin4;
        public int indice = 0;
        public Tabla tabla = new Tabla();
        public Grafica_Thompson()
        {
            ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }
        public Grafica_Thompson(Operador item)
        {
            this.nombre = item.Id;
            ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }

        private int cont()
        {
            return ++contador;
        }

        public void imprimir(Operador operador)
        {
            Operador operadorA, operadorB;
            if (operador.Tipo == TipoOperador.OPERADOR)
            {
                Signo operacion = (Signo)operador.Dato;
                switch (operacion.ope)
                {
                    case TipoSigno.Concatenacion:
                        operadorA = operacion.operador1;
                        operadorB = operacion.operador2;
                        inicio = contador;
                        if (operadorA.Tipo == TipoOperador.OPERADOR)
                        {
                            imprimir(operadorA);
                        }
                        else
                        {
                            //lst_grafica.Add("" + inicio + "->" + "" + cont() + "[label = " + operadorA.Dato + "]");
                            Transicion transA = new Transicion(TipoThompson.valor, operadorA.Dato);
                            NodoThomson nodo1 = new NodoThomson("" + inicio);
                            tabla.crearNodo(inicio);
                            NodoThomson nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                        }

                        if (operadorB.Tipo == TipoOperador.OPERADOR)
                        {

                            imprimir(operadorB);
                        }
                        else
                        {
                            //lst_grafica.Add("" + (contador) + "->" + "" + (fin = cont()) + "[label = " + operadorB.Dato + "]");
                            Transicion transB = new Transicion(TipoThompson.valor, operadorB.Dato);
                            NodoThomson nodo1 = new NodoThomson("" + contador);
                            tabla.crearNodo(contador);
                            NodoThomson nodo2 = new NodoThomson("" + (fin = cont()));
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transB));
                            fin2 = fin;
                            t = fin;
                            fin4 = fin;
                            fin1 = fin;
                        }

                        break;
                    case TipoSigno.Asterisco:

                        operadorA = operacion.operador1;
                        inicio1 = contador;
                        int ciclo1, ciclo2;
                        if (operadorA.Tipo == TipoOperador.OPERADOR)
                        {
                            //lst_grafica.Add("" + (inicio1) + "->" + "" + (ciclo1 = cont()));
                            Transicion transA = new Transicion(TipoThompson.Epsilon, "ε");
                            NodoThomson nodo1 = new NodoThomson("" + inicio1);
                            tabla.crearNodo(inicio1);
                            NodoThomson nodo2 = new NodoThomson("" + (ciclo1 = cont()));
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            imprimir(operadorA);
                            //lst_grafica.Add("" + (t) + "->" + "" + (fin1 = cont()));
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + t);
                            tabla.crearNodo(t);
                            nodo2 = new NodoThomson("" + (fin1 = cont()));
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + (t) + "->" + "" + (ciclo1));
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + t);
                            nodo2 = new NodoThomson("" + (ciclo1));
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + inicio1 + "->" + "" + fin1);
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + inicio1);
                            nodo2 = new NodoThomson("" + fin1);
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                        }
                        else
                        {
                            //lst_grafica.Add("" + (inicio1) + "->" + "" + cont());
                            Transicion transA = new Transicion(TipoThompson.Epsilon, "ε");
                            NodoThomson nodo1 = new NodoThomson("" + inicio1);
                            tabla.crearNodo(inicio1);
                            NodoThomson nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + (ciclo1 = contador) + "->" + "" + cont() + "[label = " + operadorA.Dato + "]");
                            transA = new Transicion(TipoThompson.valor, operadorA.Dato);
                            nodo1 = new NodoThomson("" + (ciclo1 = contador));
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + (ciclo2 = contador) + "->" + "" + (fin1 = cont()));
                            nodo1 = new NodoThomson("" + (ciclo2 = contador));
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + (fin1 = cont()));
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + (ciclo2) + "->" + "" + (ciclo1));
                            nodo1 = new NodoThomson("" + ciclo2);
                            nodo2 = new NodoThomson("" + ciclo1);
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + inicio1 + "->" + "" + fin1);
                            nodo1 = new NodoThomson("" + inicio1);
                            nodo2 = new NodoThomson("" + fin1);
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            t = fin1;
                        }

                        break;
                    case TipoSigno.Disyuncion:
                        operadorA = operacion.operador1;
                        operadorB = operacion.operador2;
                        inicio2 = contador;
                        int fint;

                        if (operadorA.Tipo == TipoOperador.OPERADOR)
                        {
                            //  lst_grafica.Add("" + inicio2 + " -> " + "" + cont());
                            Transicion transA = new Transicion(TipoThompson.Epsilon, "ε");
                            NodoThomson nodo1 = new NodoThomson("" + inicio2);
                            tabla.crearNodo(inicio2);
                            NodoThomson nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            imprimir(operadorA);
                            // lst_grafica.Add("" + (contador) + " -> " + "" + (fint = cont()));
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + contador);
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + (fint = cont()));
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                        }
                        else
                        {
                            //lst_grafica.Add("" + inicio2 + " -> " + "" + cont());
                            Transicion transA = new Transicion(TipoThompson.Epsilon, "ε");
                            NodoThomson nodo1 = new NodoThomson("" + inicio2);
                            tabla.crearNodo(inicio2);
                            NodoThomson nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            // lst_grafica.Add("" + (contador) + " -> " + "" + cont() + "[label = " + operadorA.Dato + "]");
                            transA = new Transicion(TipoThompson.valor, operadorA.Dato);
                            nodo1 = new NodoThomson("" + contador);
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            // lst_grafica.Add("" + (contador) + " -> " + "" + (fin2 = (fint = cont())));
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + contador);
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + (fin2 = (fint = cont())));
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                        }
                        if (operadorB.Tipo == TipoOperador.OPERADOR)
                        {
                            //lst_grafica.Add("" + inicio2 + " -> " + "" + cont());
                            Transicion transB = new Transicion(TipoThompson.Epsilon, "ε");
                            NodoThomson nodo1 = new NodoThomson("" + inicio2);
                            NodoThomson nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transB));
                            imprimir(operadorB);
                            // lst_grafica.Add("" + (fin2) + " -> " + "" + (fint));
                            transB = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + fin2);
                            tabla.crearNodo(fin2);
                            nodo2 = new NodoThomson("" + fint);
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transB));
                            t = fint;
                        }
                        else
                        {
                            // lst_grafica.Add("" + inicio2 + " -> " + "" + cont());
                            Transicion transB = new Transicion(TipoThompson.Epsilon, "ε");
                            NodoThomson nodo1 = new NodoThomson("" + inicio2);
                            tabla.crearNodo(inicio2);
                            NodoThomson nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transB));
                            // lst_grafica.Add("" + (contador) + " -> " + "" + cont() + "[label = " + operadorB.Dato + "]");
                            transB = new Transicion(TipoThompson.valor, operadorB.Dato);
                            nodo1 = new NodoThomson("" + contador);
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transB));
                            // lst_grafica.Add("" + (contador) + " -> " + "" + (fin2));
                            transB = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + contador);
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + fin2);
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transB));
                            t = fin2;
                        }

                        break;
                    case TipoSigno.Mas:

                        operadorA = operacion.operador1;
                        inicio3 = contador;
                        int ciclo1m, ciclo2m;
                        if (operadorA.Tipo == TipoOperador.OPERADOR)
                        {
                            Operador temporal = operadorA;
                            imprimir(operadorA);
                            //lst_grafica.Add("" + (inicio3) + "->" + "" + (ciclo1m = cont()));
                            Transicion transA = new Transicion(TipoThompson.Epsilon, "ε");
                            NodoThomson nodo1 = new NodoThomson("" + (ciclo2m = t));
                            tabla.crearNodo(ciclo2m);
                            NodoThomson nodo2 = new NodoThomson("" + (ciclo1m = cont()));
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            imprimir(temporal);
                            //lst_grafica.Add("" + (t) + "->" + "" + (fin3 = cont()));
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + t);
                            tabla.crearNodo(t);
                            nodo2 = new NodoThomson("" + (fin3 = cont()));
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + (t) + "->" + "" + (ciclo1m));
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + t);
                            nodo2 = new NodoThomson("" + (ciclo1m));
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + inicio3 + "->" + "" + fin3);
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + ciclo2m);
                            nodo2 = new NodoThomson("" + fin3);
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                        }
                        else
                        {
                            //lst_grafica.Add("" + inicio3 + "->" + "" + cont() + "[label = " + operadorA.Dato + "]");
                            Transicion transA = new Transicion(TipoThompson.valor, operadorA.Dato);
                            NodoThomson nodo1 = new NodoThomson("" + inicio3);
                            tabla.crearNodo(inicio3);
                            NodoThomson nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + (contador) + " -> " + "" + cont());
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + contador);
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + (ciclo1m = contador) + "->" + "" + cont() + "[label = " + operadorA.Dato + "]");
                            transA = new Transicion(TipoThompson.valor, operadorA.Dato);
                            nodo1 = new NodoThomson("" + (ciclo1m = contador));
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + (ciclo2m = contador) + " -> " + "" + (fin3 = cont()));
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + (ciclo2m = contador));
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + (fin3 = cont()));
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + (inicio3 + 1) + " -> " + "" + fin3);
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + (inicio3 + 1));
                            nodo2 = new NodoThomson("" + fin3);

                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + (ciclo2m) + " -> " + "" + (ciclo1m));
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + ciclo2m);
                            nodo2 = new NodoThomson("" + ciclo1m);
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            t = fin3;
                        }

                        break;
                    case TipoSigno.Interrogacion:
                        operadorA = operacion.operador1;

                        inicio4 = contador;
                        int finta;
                        if (operadorA.Tipo == TipoOperador.OPERADOR)
                        {
                            // lst_grafica.Add("" + inicio4 + " -> " + "" + cont());
                            Transicion transA = new Transicion(TipoThompson.Epsilon, "ε");
                            NodoThomson nodo1 = new NodoThomson("" + inicio4);
                            tabla.crearNodo(inicio4);
                            NodoThomson nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            imprimir(operadorA);
                            // lst_grafica.Add("" + (contador) + " -> " + "" + (finta = cont()));
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + contador);
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + (fin4 = (finta = cont())));
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + inicio4 + " -> " + "" + cont());
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + inicio4);
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + (cont()));
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + (contador) + " -> " + "" + cont());
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + contador);
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + (fin2) + " -> " + "" + (finta));
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + contador);
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + (fin4));
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            t = finta;
                        }
                        else
                        {
                            //lst_grafica.Add("" + inicio4 + " -> " + "" + cont());
                            Transicion transA = new Transicion(TipoThompson.Epsilon, "ε");
                            NodoThomson nodo1 = new NodoThomson("" + inicio4);
                            tabla.crearNodo(inicio4);
                            NodoThomson nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + (contador) + " -> " + "" + cont() + "[label = " + operadorA.Dato + "]");
                            transA = new Transicion(TipoThompson.valor, operadorA.Dato);
                            nodo1 = new NodoThomson("" + (contador));
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + (contador) + " -> " + "" + (fin4 = (finta = cont())));
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + contador);
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + (fin4 = (finta = cont())));
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + inicio4 + " -> " + "" + cont());
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + inicio4);
                            nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + (contador) + " -> " + "" + cont());
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + (contador));
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + cont());
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            //lst_grafica.Add("" + (contador) + " -> " + "" + (fin4));
                            transA = new Transicion(TipoThompson.Epsilon, "ε");
                            nodo1 = new NodoThomson("" + (contador));
                            tabla.crearNodo(contador);
                            nodo2 = new NodoThomson("" + (fin4));
                            lst_nodo.Add(new Thompson(nodo1, nodo2, transA));
                            t = fin4;
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine((Operador)operador.Dato);
            }

        }
        private void generatedot(String rdot, String rpng)
        {
            Grafica = new Grafica_Thompson();
            File.WriteAllText(rdot, sbG.ToString());
            string comanDot = "dot -Tpng " + rdot + " -o " + rpng + "";
            var comand = string.Format(comanDot);
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + comand);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = false;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            proc.WaitForExit();
            string result = proc.StandardOutput.ReadToEnd();
            Console.WriteLine(result);
        }

        public void graficar()
        {
            GetGraphString(lst_grafica);
            String rdot = ruta + "\\" + nombre + "_afn.dot";
            rpng = ruta + "\\" + nombre + "_afn.png";
            this.generatedot(rdot, rpng);
        }
        public string GetGraphString(List<string> lst_grafica)
        {
            sbG = new StringBuilder("digraph { rankdir = \"LR\"" + "\n");
            sbG.Append("edge[label = \"ε\"] " + "\n");
            foreach (string item in lst_grafica)
            {
                try
                {
                    sbG.Append(item + "\n");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al encontrar saturacion");
                }
            }
            sbG.Append("}");
            return sbG.ToString();
        }

        public void grafic(Thompson nodo)
        {
            if (nodo.Transicion.Tipo == TipoThompson.valor)
            {
                tabla.agregarDato(Convert.ToInt32( nodo.Nodo1.Nodo), nodo.Transicion.Valor.ToString(), Convert.ToInt32(nodo.Nodo2.Nodo));
                lst_grafica.Add(nodo.Nodo1.Nodo + " -> " + nodo.Nodo2.Nodo + " [label = " + nodo.Transicion.Valor.ToString() + "]");
            }
            else if (nodo.Transicion.Tipo == TipoThompson.Epsilon)
            {
                tabla.agregarDato(Convert.ToInt32(nodo.Nodo1.Nodo), "ε", Convert.ToInt32(nodo.Nodo2.Nodo));
                lst_grafica.Add(nodo.Nodo1.Nodo + " -> " + nodo.Nodo2.Nodo);
            }
        }
    }
}
