using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;

namespace Interfaz
{
    public partial class IngresarBarrio : Form
    {
        string nombreBarrio = "";
        TransaccionAD tc = new TransaccionAD();

        public IngresarBarrio()
        {
            InitializeComponent();
            tc.traerCombo(cboPvcia, "Provincias", "id_provincia", "nombre", "", -1);
            tc.traerCombo(cboDepto, "Departamentos", "id_departamento", "nombreDpto", "", -1);
            tc.traerCombo(cboCiudad, "Ciudades", "id_ciudad", "nombreCiu", "", -1);
        }

        private void cboPvcia_SelectedIndexChanged(object sender, EventArgs e)
        {
              if (cboPvcia.SelectedIndex >= 0)
            {
                tc.traerCombo(cboDepto, "Departamentos", "id_departamento", "nombreDpto", "provincia", Convert.ToInt32(cboPvcia.SelectedValue));
            }
        }

        private void cboDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            if (cboDepto.SelectedIndex >= 0)
            {
                tc.traerCombo(cboCiudad, "Ciudades", "id_ciudad", "nombreCiu", "departamento", Convert.ToInt32(cboDepto.SelectedValue));
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCargarBarrio_Click(object sender, EventArgs e)
        {
            if (txtBarrio.Text != "")
            {
                if (cboPvcia.SelectedIndex >= 0)
                {
                    if (cboPvcia.SelectedIndex >= 0)
                    {
                        if (cboCiudad.SelectedIndex >= 0)
                        {

                            tc.insertarBarrio(txtBarrio.Text, Convert.ToInt32(cboCiudad.SelectedValue));
                            nombreBarrio = txtBarrio.Text;
                            txtBarrio.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Debe Seleccionar una Ciudad");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un Departamento");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una Provincia");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar el nombre del Barrio");
            }
        }
    }
}
