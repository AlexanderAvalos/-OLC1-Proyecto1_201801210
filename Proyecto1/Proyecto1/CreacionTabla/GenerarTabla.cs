using Proyecto1.TablaC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Proyecto1.CreacionTabla
{
    class GenerarTabla
    {
        public static StringBuilder sbG;
        Lista tabla = new Lista();
        List<nodoEstados> lst_estados;
        List<nodoComprobacion> lst_comprobacion;
        private int contador_estados = 0;
        private int estado_actual = 0;
        private nodoEstados nodo_actual;
        private List<int> lst_recorridos = new List<int>();
        public string rpng, ruta, nombre;

        public GenerarTabla(Lista tabla,Operador item)
        {
            this.nombre = item.Id;
            ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            this.tabla = tabla;
            lst_estados = new List<nodoEstados>();
            lst_comprobacion = new List<nodoComprobacion>();
            agregarPrimero();
            nodo_actual = lst_estados.ElementAt(estado_actual);
            generarprimeros(1);
            lst_recorridos.Clear();
            recorrerTabla();
            graficarTabla();
            tablaT();
            graficar();
        }

        private void generarprimeros(int estado)
        {
            foreach (nodoTabla item in tabla.get())
            {
                if (estado == item.Key)
                {
                    foreach (Dato item2 in item.Datos)
                    {
                        if (item2.Simbolo == "ε")
                        {
                            if (recorridos(item2.Numero) == false)
                            {
                                lst_recorridos.Add(item2.Numero);
                                generarprimeros(item2.Numero);
                            }
                        }
                        else
                        {
                            nodoComprobacion aux;
                            if (comprobarEstado(item.Key, item2.Numero, item2.Simbolo))
                            {
                                aux = buscarEstado(item.Key, item2.Numero, item2.Simbolo);
                                nodo_actual.Lst_estados.Add(new nodoTransicion(aux.Transicion, aux.Estado));
                            }
                            else
                            {

                                aux = new nodoComprobacion(contador_estados, item2.Simbolo, item.Key, item2.Numero);
                                lst_estados.Add(new nodoEstados(aux.Estado, item2.Numero));
                                nodo_actual.Lst_estados.Add(new nodoTransicion(aux.Transicion, aux.Estado));
                            }

                        }
                    }
                }
            }
        }

        private nodoComprobacion buscarEstado(int inicio, int fin, string transicion)
        {
            foreach (nodoComprobacion item in lst_comprobacion)
            {
                if (item.Inicio == inicio && item.Fin == fin && item.Transicion.Equals(transicion)) return item;
            }
            return null;
        }


        private void agregarPrimero()
        {
            lst_estados.Add(new nodoEstados("A", 1));
        }

        private void recorrerTabla()
        {
            int contador_auxiliar = 1;
            while (lst_estados.Count > contador_auxiliar)
            {
                generarEstados(lst_estados.ElementAt(contador_auxiliar));
                lst_recorridos.Clear();
                contador_auxiliar++;
            }
        }

        private void generarEstados(nodoEstados estado_actual)
        {
            nodo_actual = estado_actual;
            generarprimeros(estado_actual.Numero);

        }

        private bool comprobarEstado(int inicio, int fin, string transicion)
        {

            foreach (nodoComprobacion item in lst_comprobacion)
            {
                if (item.Inicio == inicio && item.Fin == fin && item.Transicion.Equals(transicion)) return true;
            }
            contador_estados++;
            nodoComprobacion nodoaux = new nodoComprobacion(contador_estados, transicion, inicio, fin);
            lst_comprobacion.Add(nodoaux);
            return false;

        }

        private void graficarTabla()
        {
            foreach (nodoEstados item in lst_estados)
            {
                Console.Write(item.Estado +"    ");
                foreach (var item2 in item.Lst_estados)
                {
                    Console.Write( item2.Estado + " " + item2.Transicion + ", ");
                }
                Console.WriteLine();
            }

        }


        private void generatedot(String rdot, String rpng)
        {
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
            GetGraphString();
            String rdot = ruta + "\\" + nombre + "_afd.dot";
            rpng = ruta + "\\" + nombre + "_afd.png";
            this.generatedot(rdot, rpng);
        }
        public string GetGraphString()
        {
            sbG = new StringBuilder("digraph { rankdir = \"LR\"" + "\n");
            foreach (nodoEstados item in lst_estados)
            {
                foreach (var item2 in item.Lst_estados)
                {
                    sbG.Append(item.Estado + "->" + item2.Estado + " [label = " + item2.Transicion + "];" + "\n");
                }
            }
            sbG.Append("}");
            return sbG.ToString();
        }
        private void tablaT()                        
        {

            string rutah = ruta + "\\" + nombre + ".htm";
            using (FileStream fs = new FileStream(rutah, FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine("<Center><TABLE border = 2 ></Center>");
                    w.WriteLine("<TR>");
                    w.WriteLine("<Center><TH COLSPAN = 6 > Tabla en transiciones</TH></Center>");
                    w.WriteLine("</TR>");
                    
                    foreach (nodoEstados item in lst_estados)
                    {
                        w.WriteLine("<TR>");
                        w.WriteLine("<TH>" + item.Estado + "</TH>");
                        foreach (var item2 in item.Lst_estados)
                        {
                            Console.Write(item2.Estado + " " + item2.Transicion + ", ");
                            w.WriteLine("<TH>" + item2.Estado +", "+item2.Transicion + "</TH>");
                        }
                        Console.WriteLine();
                        w.WriteLine("</TR>");
                    }
                   
                }
            }
        }



        private bool recorridos(int estado)
        {
            foreach (var item in lst_recorridos)
            {
                if (item == estado) return true;
            }
            return false;
        }
    }
}
