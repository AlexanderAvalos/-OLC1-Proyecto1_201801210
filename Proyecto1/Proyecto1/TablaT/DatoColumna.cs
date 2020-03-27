using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Proyecto1.TablaT
{
   public class DatoColumna
    {
        string estado;
        int indice;
        List<DatoT> datoTs;

        public DatoColumna(string estado, int indice)
        {
            this.estado = estado ?? throw new ArgumentNullException(nameof(estado));
            this.indice = indice;
            datoTs = new List<DatoT>();
        }


        public string Estado { get => estado; set => estado = value; }
        public int Indice { get => indice; set => indice = value; }
        public List<DatoT> DatoTs { get => datoTs; set => datoTs = value; }
    }
}
