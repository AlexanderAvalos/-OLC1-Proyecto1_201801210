using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Linq;
using Proyecto1.CreacionTabla;

namespace Proyecto1
{
    public partial class Form1 : Form
    {
        Analizador analizar = new Analizador();
        
        public RichTextBox[] rich = new RichTextBox[10];
        private string[] cadena;
        TabPage tab;

        public Form1()
        {
            InitializeComponent();
            rich[0] = richTextBox1;

            //List<int> lst = new List<int>();
            //lst.Add(1);
            //int contador = 0;
            //while (lst.Count>contador)
            //{
            //    if (lst.ElementAt(contador).Equals(1)) { lst.Add(2); }
            //    if (lst.ElementAt(contador).Equals(2)) { lst.Add(3); }
            //    if (lst.ElementAt(contador).Equals(3)) { lst.Add(4); }
            //    Console.WriteLine(lst.ElementAt(contador));
            //    contador++;

            //}
          
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void agregarPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tab = new TabPage("nuevo");
            RichTextBox rich1 = new RichTextBox();
            rich1.Dock = DockStyle.Fill;
            tab.Controls.Add(rich1);
            tabControl1.Controls.Add(tab);
            Console.WriteLine(tabControl1.SelectedIndex + 1);
            rich[tabControl1.SelectedIndex + 1] = rich1;
        }

        private void analizar_Lexicamente()
        {
            cadena = rich[tabControl1.SelectedIndex].Lines;
            for (int posfila = 0; posfila < cadena.Length; posfila++)
            {
                analizar.analizadorLexico(cadena[posfila] + '\n', posfila);
            }
        }
        private void abrir()
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "Archivos con extension ER|*.er";
            Dialog.Title = "Seleccione el archivo";
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                string url = Dialog.FileName;
                tabControl1.SelectedTab.Text = Dialog.SafeFileName;
                try
                {
                    TextReader Leer = new StreamReader(url);
                    rich[tabControl1.SelectedIndex].Text = Leer.ReadToEnd();
                }
                catch
                {
                    MessageBox.Show("Error De Carga");
                }
            }
        }

        private void guardar()
        {
            try
            {
                SaveFileDialog Dialog = new SaveFileDialog();
                Dialog.Filter = "Archivos con extension ER|*.er";
                Dialog.Title = "Guardar";
                string rutah = Dialog.FileName;
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    rich[tabControl1.SelectedIndex].SaveFile(Dialog.FileName, RichTextBoxStreamType.PlainText);
                    MessageBox.Show("Archivo Guardado");
                }
            }
            catch
            {
                MessageBox.Show("Error al guardar");
            }
        }


        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir();
            
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            analizar_Lexicamente();
            mostrar();
            M_sintactico();

        }
        private void M_sintactico()
        {
            analizar.lst_tkn.Add(new Tokens("EOF", "EOF", -1, -1, Tipos.EOF));
            sintactico sintactico = new sintactico(analizar.lst_tkn);
            sintactico.parser();
            List<NodoThomson> lst_no = new List<NodoThomson>();
            foreach (Entrada item in sintactico.lst_Entrada)
            {
                Console.WriteLine(item.entrada + " ");
            }
            foreach (Operador item in sintactico.lst_grafos)
            {

                Grafica_Thompson graficador = new Grafica_Thompson(item);
                graficador.imprimir(item);
                foreach (var item2 in graficador.lst_nodo)
                {
                    
                    graficador.grafic(item2);

                }  
                graficador.graficar();
                GenerarTabla generador = new GenerarTabla(graficador.tabla.tabla,item);
            }
           
        }
    
        private void mostrar()
        {
            foreach (Tokens token in analizar.lst_tkn)
            {
                Console.WriteLine(token.lexema + " " + token.lexico);
            }
            foreach (ErrorToken error in analizar.lst_error)
            {
                Console.WriteLine(error.lexema + " " + error.Descripcion);
            }
        }
        private void crear_XML_Error()
        {
            XmlDocument archivo = new XmlDocument();
            XmlDeclaration xmlDeclaration = archivo.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = archivo.DocumentElement;
            archivo.InsertBefore(xmlDeclaration, root);
            XmlElement cabeza = archivo.CreateElement(string.Empty, "Lista_Error", string.Empty);
            archivo.AppendChild(cabeza);
            foreach (ErrorToken error in analizar.lst_error)
            {
                XmlElement tok = archivo.CreateElement(string.Empty, "token", string.Empty);
                cabeza.AppendChild(tok);
                XmlElement valor = archivo.CreateElement(string.Empty, "Valor", string.Empty);
                XmlText val = archivo.CreateTextNode(error.lexema);
                valor.AppendChild(val);
                tok.AppendChild(valor);
                XmlElement fila = archivo.CreateElement(string.Empty, "Fila", string.Empty);
                XmlText valor_F = archivo.CreateTextNode(error.fila + "");
                fila.AppendChild(valor_F);
                tok.AppendChild(fila);
                XmlElement colunma = archivo.CreateElement(string.Empty, "Columna", string.Empty);
                XmlText valor_C = archivo.CreateTextNode(error.columna + "");
                colunma.AppendChild(valor_C);
                tok.AppendChild(colunma);
            }
            archivo.Save("Error.xml");

        }
        private void Crear_XML()
        {
            XmlDocument archivo = new XmlDocument();
            XmlDeclaration xmlDeclaration = archivo.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = archivo.DocumentElement;
            archivo.InsertBefore(xmlDeclaration, root);
            XmlElement cabeza = archivo.CreateElement(string.Empty, "Lista_Token", string.Empty);
            archivo.AppendChild(cabeza);
            foreach (Tokens token in analizar.lst_tkn)
            {
                XmlElement tok = archivo.CreateElement(string.Empty, "token", string.Empty);
                cabeza.AppendChild(tok);
                XmlElement nombre = archivo.CreateElement(string.Empty, "Nombre", string.Empty);
                XmlText valor_N = archivo.CreateTextNode(token.lexico);
                nombre.AppendChild(valor_N);
                tok.AppendChild(nombre);
                XmlElement valor = archivo.CreateElement(string.Empty, "Valor", string.Empty);
                XmlText val = archivo.CreateTextNode(token.lexema);
                valor.AppendChild(val);
                tok.AppendChild(valor);
                XmlElement fila = archivo.CreateElement(string.Empty, "Fila", string.Empty);
                XmlText valor_F = archivo.CreateTextNode(token.Fila + "");
                fila.AppendChild(valor_F);
                tok.AppendChild(fila);
                XmlElement colunma = archivo.CreateElement(string.Empty, "Columna", string.Empty);
                XmlText valor_C = archivo.CreateTextNode(token.Columna + "");
                colunma.AppendChild(valor_C);
                tok.AppendChild(colunma);
            }
            archivo.Save("token.xml");
        }


        public void convertir()
        {
            int cont = 1;
            Document doc = new Document();
            PdfPTable tabla = new PdfPTable(5);
            PdfWriter.GetInstance(doc, new FileStream("Lista Error.pdf", FileMode.Create));
            doc.Open();
            Paragraph titulo = new Paragraph();
            titulo.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLACK);
            titulo.Add("Tabla Error");
            doc.Add(titulo);
            doc.Add(new Paragraph(" "));
            tabla.AddCell("No.");
            tabla.AddCell("Fila");
            tabla.AddCell("Columna");
            tabla.AddCell("Token.");
            tabla.AddCell("Descripcion");
            foreach (ErrorToken token in analizar.lst_error)
            {
                tabla.AddCell(cont.ToString());
                tabla.AddCell(token.fila.ToString());
                tabla.AddCell(token.columna.ToString());
                tabla.AddCell(token.Descripcion);
                tabla.AddCell(token.lexema);
                cont++;
            }
            doc.Add(tabla);
            doc.Close();
        }


        private void guardarTokensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Crear_XML();
        }

        private void guardarErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crear_XML_Error();
        }

        private void errorLexicoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            convertir();
        }
    }
}
