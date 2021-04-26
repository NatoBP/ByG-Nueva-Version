using AccesoDatos.Clases;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class VisorDeReportes : Form
    {
        public List<Comprobante> com = new List<Comprobante>();
        public List<Persona> p = new List<Persona>();
        public List<CaracteristicaPropiedad> cp = new List<CaracteristicaPropiedad>();

        public VisorDeReportes()
        {
            InitializeComponent();
        }
       
        private void rpvComprobantes_Load(object sender, EventArgs e)
        {
            rpvComprobantes.LocalReport.DataSources.Clear(); //Limpiamos lo que está por defecto
            rpvComprobantes.LocalReport.DataSources.Add(new ReportDataSource("DsComprobante", com)); //Indicamos la fuente de los datos
            rpvComprobantes.LocalReport.DataSources.Add(new ReportDataSource("DsPersona", p));
            rpvComprobantes.LocalReport.DataSources.Add(new ReportDataSource("DsItems", cp));
            this.rpvComprobantes.RefreshReport();
        }
    }
}
