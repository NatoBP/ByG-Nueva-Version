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
    public partial class Clientes : Form
    {

        Persona pr = new Persona();
        ClienteAD cl = new ClienteAD();
        TransaccionAD tc = new TransaccionAD();

        public Clientes()
        {
            InitializeComponent();
            ConfiguracionDGV();
            tc.traerCombo(cboTipoDNI, "TiposDNI", "id_DNI", "tipoDNI", "", -1);
            tc.traerCombo(cboProvincia, "Provincias", "id_provincia", "nombre", "", -1);
            tc.traerCombo(cboDepartamento, "Departamentos", "id_departamento", "nombreDpto", "", -1);
            tc.traerCombo(cboCiudad, "Ciudades", "id_ciudad", "nombreCiu", "", -1);
            tc.traerCombo(cboBarrio, "Barrios", "id_barrio", "nombreBarr", "", -1);
            cboProvincia.SelectedValue = 14;
            bool locador = false;
            bool locatario = false;
            bool garante = false;
        }

        private void btnCargarBarrio_Click(object sender, EventArgs e)
        {
            IngresarBarrio ib = new IngresarBarrio();
            ib.cboPvcia.SelectedValue = cboProvincia.SelectedValue;
            ib.cboDepto.SelectedValue = cboDepartamento.SelectedValue;
            ib.cboCiudad.SelectedValue = cboCiudad.SelectedValue;
            ib.ShowDialog();
        }

        private void btnCargarTelefono_Click(object sender, EventArgs e)
        {
            if (txtTelefono.Text != "" && txtCodArea.Text != "" && txtDNI.Text != "" && cboTipoDNI.SelectedIndex != -1)
            {
                Telefono t = new Telefono();
                t.pfkIdDocumento = Convert.ToInt32(txtDNI.Text);
                t.pfkIdTipoDNI = Convert.ToInt32(cboTipoDNI.SelectedValue);
                t.pcodigoArea = txtCodArea.Text;
                t.pnumero = txtTelefono.Text;
                pr.agregarTelefono(t);


                dgvTelefonos.Rows.Add(null, t.pcodigoArea, t.pnumero);
                txtTelefono.Clear();
                txtCodArea.Clear();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCamposCliente())
            {
                pr.pDNI = Convert.ToInt32(txtDNI.Text);
                pr.pTipoDNI = Convert.ToInt32(cboTipoDNI.SelectedValue);
                pr.pApellido = txtApellido.Text;
                pr.pNombre = txtNombre.Text;
                pr.pDireccion = txtDireccion.Text;
                pr.pAltura = Convert.ToInt32(txtAltura.Text);
                if (txtPiso.Text == "")
                    pr.pPiso = 0;
                else
                    pr.pPiso = Convert.ToInt32(txtPiso.Text);
                if (txtDepto.Text == "")
                    pr.pDepto = "";
                else
                    pr.pDepto = txtDepto.Text;
                if (cboBarrio.SelectedIndex != -1)
                {
                    pr.pBarrio = Convert.ToInt32(cboBarrio.SelectedValue);
                }
                else
                {
                    MessageBox.Show("Debe ingresar un barrio");
                }

                pr.pciudad = Convert.ToInt32(cboCiudad.SelectedValue);
                pr.pdepartamento = Convert.ToInt32(cboDepartamento.SelectedValue);
                pr.pProvincia = Convert.ToInt32(cboProvincia.SelectedValue);
                pr.pMail = txtMail.Text.Trim();

                if (cl.VerificarPersona(Convert.ToInt32(cboTipoDNI.SelectedValue), Convert.ToInt32(txtDNI.Text)) == 0)//Si la persona no existe en BD
                {
                    cl.InsertarPersona(pr);

                    if (pr.pTelefono.Count() > 0) 
                    {
                        cl.InsertarTelefono(pr.pTelefono);
                    }

                    
                }
            } 
        }


        private void ConfiguracionDGV()
        {
            var dgv = dgvTelefonos;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            //COLUMNAS
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(229, 134, 89);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Orange;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add("idTelefono", "idTelefono");
            dgv.Columns[0].Visible = false;
            dgv.Columns.Add("Cod. Area", "Cód. Área:");
            dgv.Columns.Add("Numero", "Número:");
            //FUENTE
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Oxygen", 9);
            dgv.ColumnHeadersHeight = 20;

            //FILAS
            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(177, 179, 190);
            dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.RowsDefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Regular);
            dgv.RowsDefaultCellStyle.Font = new Font("Oxygen", 9);

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.RowHeadersVisible = false;

            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;

        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedIndex >= 0)
            {
                tc.traerCombo(cboDepartamento, "Departamentos", "id_departamento", "nombreDpto", "provincia", Convert.ToInt32(cboProvincia.SelectedValue));
            }
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.SelectedIndex >= 0)
            {
                tc.traerCombo(cboCiudad, "Ciudades", "id_ciudad", "nombreCiu", "departamento", Convert.ToInt32(cboDepartamento.SelectedValue));
            }
        }

        private void cboCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCiudad.SelectedIndex >= 0)
            {
                tc.traerCombo(cboBarrio, "Barrios", "id_barrio", "nombreBarr", "ciudad", Convert.ToInt32(cboCiudad.SelectedValue));
            }
        }

        private void cboTipoDNI_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDNI.Text != "")
                {

                    //if (bd.VerificarPersona(Convert.ToInt32(cboTipoDNI.SelectedValue), Convert.ToInt32(txtDNI.Text)) > 0)

                    //{


                    //    Int32 dni = Convert.ToInt32(txtDNI.Text);
                    //    Int32 tipoDNI = cboTipoDNI.SelectedIndex + 1;
                    //    p = new Persona();
                    //    p = bd.CargarPersona(dni, tipoDNI);
                    //    //pr.pTelefono = bd.CargarListaTelefonos(Convert.ToInt32(txtDNI.Text), Convert.ToInt32(cboTipoDNI.SelectedIndex + 1));
                    //    foreach (var item in pr.pTelefono)
                    //    {
                    //        dgvTelefonos.Rows.Add(item.pIdTelefono, item.pcodigoArea, item.pnumero);
                    //    }
                    //    dgvTelefonos.Columns[0].Visible = false;
                    //    txtApellido.Text = p.pApellido;
                    //    txtNombre.Text = p.pNombre;
                    //    txtDireccion.Text = p.pDireccion;
                    //    txtAltura.Text = Convert.ToString(p.pAltura);
                    //    cboProvincia.SelectedValue = p.pProvincia;
                    //    cboDepartamento.SelectedValue = p.pdepartamento;
                    //    cboCiudad.SelectedValue = p.pciudad;
                    //    cboBarrio.SelectedValue = p.pBarrio;
                    //    txtMail.Text = p.pMail;

                    //}

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private bool validarCamposCliente()
        {
            bool validar = false;
            if (cboTipoDNI.SelectedIndex == -1 && cboBarrio.SelectedIndex == -1)
            {
                validar = false;
                MessageBox.Show("Debe ingresar todos los campos");
            }
            else
            {
                foreach (Control c in this.Controls)
                {
                    if (c is TextBox && string.IsNullOrEmpty(c.Text) && c != txtTelefono && c != txtCodArea && c != txtMail)
                    {
                        MessageBox.Show("Debe ingresar todos los campos");
                        validar = false;
                        break;
                    }
                    else
                    {
                        validar = true;
                    }
                }
            }
            return validar;
        }

        public void limpiarCamposCliente()
        {
            //foreach (Control c in tblLocador.Controls)
            //{
            //    if (c is TextBox && !string.IsNullOrEmpty(c.Text))
            //    {
            //        c.Text = "";
            //    }
            //}
            //cboTipoDNI.SelectedIndex = -1;
            //cboProvincia.SelectedIndex = -1;
            ////pr.pTelefono.Clear();

            //cboDepartamento.SelectedIndex = -1;
            //cboCiudad.SelectedIndex = -1;
            //cboBarrio.SelectedIndex = -1;

            //dgvTelefonos.Rows.Clear();
            //txtDNI.Focus();
        }

        public void deshabilitarCamposCliente()
        {
            //foreach (Control c in tblLocador.Controls)
            //{
            //    if (c is TextBox)
            //    {
            //        c.Enabled = false;
            //    }
            //    else if (c is ComboBox)
            //    {
            //        c.Enabled = false;
            //    }
            //    else if (c is Button)
            //    {
            //        c.Enabled = false;
            //    }
            //}
            //dgvTelefonos.Enabled = false;
        }

        public void habilitarCamposCliente()
        {
            //foreach (Control c in tblLocador.Controls)
            //{
            //    if (c is TextBox)
            //    {
            //        c.Enabled = true;
            //    }
            //    else if (c is ComboBox && c != cboTipoDNI)
            //    {
            //        c.Enabled = true;
            //    }
            //    else if (c is Button)
            //    {
            //        c.Enabled = true;
            //    }
            //}
            //dgvTelefonos.Enabled = true;
        }
    }
}
