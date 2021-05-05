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
using AccesoDatos.Clases;

namespace Interfaz
{
    public partial class EstadoDeCuentas : Form
    {

        Persona pr = new Persona();
        Comprobante c = new Comprobante();
        CaracteristicaPropiedad cp;


        ClienteAD cl = new ClienteAD();
        EstadoCuentaAD ec = new EstadoCuentaAD();
        TransaccionAD tc = new TransaccionAD();

        public bool AlquileresV = false;
        public bool AlquileresNoV = false;

        public EstadoDeCuentas()
        {
            InitializeComponent();
            cargaInicial();
            ConfiguracionDgvAsientoDelDia();
            ConfiguracionDgvEstadoDeuda();
            DeshabilitarAsientoDia();
        }

        //BOTONES

        private void cboTipoDNI_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDni.Text != "" && cboTipoDNI.SelectedIndex != -1)
                {
                    if (cl.VerificarPersona(Convert.ToInt32(cboTipoDNI.SelectedValue), Convert.ToInt32(txtDni.Text)) > 0)
                    {
                        pr = null;
                        pr = cl.BuscarPersona(Convert.ToInt32(cboTipoDNI.SelectedValue), Convert.ToInt32(txtDni.Text));

                        limpiarVentana();

                        txtApellido.Text = pr.pApellido;
                        txtNombre.Text = pr.pNombre;

                        RefreshEstadoCuenta(pr.pDNI, pr.pTipoDNI);
                        TotalEstadoCuenta();
                        cboOperacion.Enabled = true;
                    }
                    else
                    {
                        DialogResult opcion = MessageBox.Show("La persona no está registrada, ¿desea realizar el asiento de todas formas?", "Persona no ingresada", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(opcion == DialogResult.Yes)
                        {
                            limpiarVentana();
                            cboOperacion.Enabled = true;
                        }
                        else
                        {
                            limpiarVentana();
                            DeshabilitarAsientoDia();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            if (txtImporteItem.Text != "" && cboItemsRecibo.SelectedIndex != -1)
            {
                cp = new CaracteristicaPropiedad(); //Se genera una nueva característica
                cp.pId = Convert.ToInt32(cboItemsRecibo.SelectedValue);
                cp.pValor = 0;
                cp.pCaracteristica = cboItemsRecibo.Text;
                cp.pDescripcion = txtDescripcion.Text;
                if (cboOperacion.SelectedIndex == 1)
                    cp.pImporte = -Convert.ToDouble(txtImporteItem.Text);
                else
                    cp.pImporte = Convert.ToDouble(txtImporteItem.Text);


                c.agregarItems(cp); //Solo se cargan los valores del asiento de deuda. Luego se guarda en BD junto con los datos del Comprobante en el botón Guardar

                dgvAsientoDelDia.Rows.Add(cp.pId, cp.pValor, cp.pCaracteristica, cp.pDescripcion, cp.pImporte); //Se agrega al DGV

                TotalAsientoDia();
                btnGrabarRegistro.Enabled = true;
                limpiarCampos(0);
            }
            else
            {
                MessageBox.Show("Debo ingresar un Importe y seleccionar un item");
            }
        }

        private void btnQuitarItem_Click(object sender, EventArgs e)
        {
            if (c.pItem.Count >= 1 && dgvAsientoDelDia.SelectedRows.Count > 0)
            {
                int a = dgvAsientoDelDia.CurrentRow.Index;
                c.pItem.RemoveAt(a);

                double resta = Convert.ToDouble(dgvAsientoDelDia.CurrentRow.Cells[4].Value); //Extraigo el valor
                dgvAsientoDelDia.Rows.Remove(dgvAsientoDelDia.CurrentRow);//Después borro la fila

                double total = Convert.ToDouble(lblSumatoria.Text) - resta;//Y se lo resto al total
                lblSumatoria.Text = Convert.ToString(total);
            }
        }

        private void cboOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboItemsRecibo.Enabled == false)
                HabilitarAsientoDia();

            limpiarCampos(1);
            ConfiguracionDgvAsientoDelDia();

            if(cboOperacion.SelectedIndex == 1)
            {
                txtImporteItem.ForeColor = Color.Red;
            }
            else if(cboOperacion.SelectedIndex == 0)
            {
                txtImporteItem.ForeColor = Color.Black;
            }
        }

        private void dgvEstadoDeuda_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvEstadoDeuda.CurrentRow != null && dgvEstadoDeuda.SelectedRows.Count > 0)
            {
                limpiarCampos(2); //Limpiar Todo
                int id = Convert.ToInt32(dgvEstadoDeuda.CurrentRow.Cells[0].Value);

                dgvAsientoDelDia.Columns.Clear();
                dgvAsientoDelDia.AutoGenerateColumns = true;
                dgvAsientoDelDia.DataSource = null; //Limpio todo

                if (Convert.ToInt32(dgvEstadoDeuda.CurrentRow.Cells[4].Value) == 0)
                    dgvAsientoDelDia.DataSource = ec.consultaAsientoDeudaCompleto(id).Tables[0];
                else
                    dgvAsientoDelDia.DataSource = ec.consultaComprobanteCompleto(id).Tables[0];

                TotalAsientoDia();
                rtbNotas.Text = dgvEstadoDeuda.CurrentRow.Cells[5].Value.ToString();
                
            }
        }

        private void dgvEstadoDeuda_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEstadoDeuda.CurrentRow != null && dgvEstadoDeuda.SelectedRows.Count > 0)
            {
                limpiarCampos(2); //Limpiar Todo
                int id = Convert.ToInt32(dgvEstadoDeuda.CurrentRow.Cells[0].Value);

                if (dgvAsientoDelDia.CurrentRow != null && dgvAsientoDelDia.SelectedRows.Count > 0)
                {
                    dgvAsientoDelDia.Columns.Clear();
                    dgvAsientoDelDia.AutoGenerateColumns = true;
                    dgvAsientoDelDia.DataSource = null;
                }
                
                if (Convert.ToInt32(dgvEstadoDeuda.CurrentRow.Cells[4].Value) == 0)
                    dgvAsientoDelDia.DataSource = ec.consultaAsientoDeudaCompleto(id).Tables[0];
                else
                    dgvAsientoDelDia.DataSource = ec.consultaComprobanteCompleto(id).Tables[0];

                rtbNotas.Text = dgvEstadoDeuda.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void btnGrabarRegistro_Click(object sender, EventArgs e)
        {
            if (ValidarNumeros() && ValidarTextos() && (dgvAsientoDelDia.RowCount > 0) && (cboOperacion.SelectedIndex != -1))
            {
                try
                {
                    //Si la persona está registrada en BD
                    if (cl.VerificarPersona(Convert.ToInt32(cboTipoDNI.SelectedValue), Convert.ToInt32(txtDni.Text)) > 0)
                    {
                        c.pdni = Convert.ToInt32(txtDni.Text);
                        c.ptipoDNI = Convert.ToInt32(cboTipoDNI.SelectedValue);
                        c.pfecha = dtpFecha.Value;
                        c.pDescripcion = rtbNotas.Text;

                        if(cboOperacion.SelectedIndex == 0)
                        {
                            ec.insertarComprobante(c);
                            ec.guardarItemRecibo(c.pItem);
                            AbrirVentanaComprobante(pr, c, c.pItem);
                        }
                        else if(cboOperacion.SelectedIndex == 1)
                        {
                            ec.insertarAsientoDeuda(c); //Primero ingresa los datos del comprobante
                            ec.guardarItemAsiento(c.pItem); //Después ingresa los datos de los Items pagados
                        }

                        RefreshEstadoCuenta(c.pdni, c.ptipoDNI);
                        TotalEstadoCuenta();
                    }
                    //Si la persona No está registrada en BD
                    else
                    {
                        pr.pApellido = txtApellido.Text;
                        pr.pNombre = txtNombre.Text;
                        pr.pDNI = Convert.ToInt32(txtDni.Text);
                        pr.pTipoDNI = Convert.ToInt32(cboTipoDNI.SelectedValue);
                        cl.InsertarPersona(pr);

                        c.pdni = Convert.ToInt32(txtDni.Text);
                        c.ptipoDNI = Convert.ToInt32(cboTipoDNI.SelectedValue);
                        c.pfecha = dtpFecha.Value;
                        c.pDescripcion = txtDescripcion.Text;

                        ec.insertarAsientoDeuda(c);
                        ec.guardarItemAsiento(c.pItem);

                        RefreshEstadoCuenta(c.pdni, c.ptipoDNI);
                        TotalEstadoCuenta();

                        AbrirVentanaComprobante(pr, c, c.pItem); //Imprimir
                    }
                    //Si hay que volver a la ventana Alquileres Vigentes
                    if (AlquileresV == true)
                    {
                        AlquileresVigentes aV = (AlquileresVigentes)this.ParentForm;
                        AlquileresV = false;

                        AbrirVentana<AlquileresVigentes>();
                        aV.Recargar(pr.pApellido);

                        this.Close();
                    }
                    else if (AlquileresNoV == true)
                    {
                        AlquileresNoVigentes aNv = (AlquileresNoVigentes)this.ParentForm;
                        AlquileresNoV = false;

                        AbrirVentana<AlquileresNoVigentes>();
                        aNv.Recargar(pr.pApellido);

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }
            limpiarCampos(1);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            foreach (Control c in grpEstado.Controls)
            {
                if (c is TextBox && !string.IsNullOrEmpty(c.Text)) //Si hay algo en los campos
                {
                    DialogResult opcion = MessageBox.Show("¿Desea descartar los campos ingresados?", "¿Borrar campos?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (opcion == DialogResult.Yes)
                    {
                        limpiarCampos(1);
                        this.Close();
                    }
                    break; //Hay que cortar el ciclo para que no salga más de un Message Box
                }
            }
        }

        
        //CONFIGURACIONES DATAGRIDVIEW
        //Dgv Asientos del día
        private void ConfiguracionDgvAsientoDelDia()
        {
            var dgv = dgvAsientoDelDia;
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
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Add("Id", "Id");
            dgv.Columns[0].Visible = false;
            dgv.Columns.Add("Valor", "Valor");
            dgv.Columns[1].Visible = false;
            dgv.Columns.Add("Item", "Item:");
            dgv.Columns.Add("Descripción", "Descripción:");
            dgv.Columns.Add("Importe: ", "Importe: ");

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

                //Dgv Estado Deuda
        private void ConfiguracionDgvEstadoDeuda()
        {
            var dgv = dgvEstadoDeuda;
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
            dgv.AutoGenerateColumns = true;
            DataGridViewColumn fecha = new DataGridViewColumn();
            fecha.DataPropertyName = "Fecha";
            dgv.Columns.Add("Fecha", "Fecha");

            DataGridViewColumn concepto = new DataGridViewColumn();
            concepto.DataPropertyName = "Concepto";
            dgv.Columns.Add("Concepto", "Concepto");

            DataGridViewColumn debe = new DataGridViewColumn();
            debe.DataPropertyName = "Debe";
            dgv.Columns.Add("Debe", "Debe");

            DataGridViewColumn haber = new DataGridViewColumn();
            haber.DataPropertyName = "Haber";
            dgv.Columns.Add("Haber", "Haber");

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


        //MÉTODO DE CARGA DE DE DATOS 
        public void CargarPersona(int tipo, int dni) //Datos que vienen de Alquileres Vigentes y Alquileres No Vigentes
        {
            limpiarVentana();
            txtDni.Text = Convert.ToString(dni);
            cboTipoDNI.SelectedValue = tipo;
        }

        private void AbrirVentana<MiForm>() where MiForm : Form, new()
        {
            Form fh;
            fh = ActiveForm.Controls.OfType<MiForm>().FirstOrDefault();

            if (fh == null)
            {
                fh = new MiForm();
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.Controls.Add(fh);
                this.Tag = fh;

                fh.BringToFront();
                fh.Show();
            }
            else
            {
                fh.BringToFront();
            }
        }

        private void AbrirVentanaComprobante(Persona p, Comprobante c, List<CaracteristicaPropiedad> cp)
        {
            VisorDeReportes vr = new VisorDeReportes();
            vr.p.Add(pr);
            vr.cp.AddRange(c.pItem);
            vr.com.Add(c);
            vr.ShowDialog();
        }

        private void cargaInicial()
        {
            tc.traerCombo(cboTipoDNI, "TiposDNI", "id_DNI", "tipoDNI", "", -1);
            tc.traerCombo(cboItemsRecibo, "ItemComprobantes", "id_Item", "concepto", "", -1);
            cboItemsRecibo.SelectedIndex = -1;
            cboTipoDNI.SelectedIndex = -1;
        }

        private void RefreshEstadoCuenta(int dni, int tipo)
        {
            dgvEstadoDeuda.Columns.Clear();
            dgvEstadoDeuda.DataSource = ec.buscarEstadoCuenta(dni, tipo).Tables[0];
            dgvEstadoDeuda.Columns[5].Visible = false;
        }

        private void TotalEstadoCuenta() //Hace las sumas y restas del dgvEstadoCuentas para obtener el total
        {
            double suma = 0;

            foreach (DataGridViewRow row in dgvEstadoDeuda.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    suma += (double)row.Cells[3].Value;
                }
            }
            double resta = 0;

            foreach (DataGridViewRow row in dgvEstadoDeuda.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    resta += (double)row.Cells[4].Value;
                }
            }
            double saldo = suma - resta;
            lblSaldoCuenta.Text = Convert.ToString(saldo);
        }

        private void TotalAsientoDia()
        {
            double suma = 0;

            foreach (DataGridViewRow row in dgvAsientoDelDia.Rows)
            {
                if (row.Cells["Importe: "].Value != null)
                {
                    suma += (double)row.Cells["Importe: "].Value;
                }
            }

            ValidarNumeros();
            double totalApagar = suma;
            lblSumatoria.Text = Convert.ToString(totalApagar);
        }

        //VALIDACIONES Y LIMPIEZAS

        private void limpiarCampos(int i) //Se utiliza para cargar un asiento en DGV
        {
            if(i == 0)
            {
                cboItemsRecibo.SelectedValue = -1;
                cboItemsRecibo.Focus();
                txtDescripcion.Clear();
                txtImporteItem.Clear();
            }
            else if(i ==1)
            {
                cboItemsRecibo.SelectedValue = -1;
                cboItemsRecibo.Focus();
                txtDescripcion.Clear();
                txtImporteItem.Clear();
                rtbNotas.Clear();
                if (dgvAsientoDelDia.CurrentRow != null && dgvAsientoDelDia.SelectedRows.Count > 0)
                {
                    dgvAsientoDelDia.DataSource = null;
                    dgvAsientoDelDia.Rows.Clear();
                }
                    
                lblSumatoria.Text = "";
            }
            else
            {
                cboItemsRecibo.SelectedValue = -1;
                txtDescripcion.Clear();
                txtImporteItem.Clear();
                rtbNotas.Clear();
                if (dgvAsientoDelDia.CurrentRow != null && dgvAsientoDelDia.SelectedRows.Count > 0)
                {
                    dgvAsientoDelDia.DataSource = null;
                    dgvAsientoDelDia.Rows.Clear();
                }

                lblSumatoria.Text = "";
            }
        }

        private void limpiarVentana()
        {
            foreach (Control c in grpEstado.Controls)
            {
                if (c is TextBox && c.Text != "" && c != txtDni)
                {
                    c.Text = "";
                }
            }

            foreach (Control c in grpAsiento.Controls)
            {
                if (c is TextBox && c.Text != "")
                {
                    c.Text = "";
                }
            }
            lblSaldoCuenta.Text = "";
            lblSumatoria.Text = "";
            rtbNotas.Clear();

            dgvAsientoDelDia.Rows.Clear();
            if (dgvEstadoDeuda.CurrentRow != null && dgvEstadoDeuda.SelectedRows.Count > 0)
            {
                dgvEstadoDeuda.DataSource = null;
                dgvEstadoDeuda.Rows.Clear();
                ConfiguracionDgvEstadoDeuda();
            }
            c.pItem.Clear();
            txtDni.Focus();
        }

        private void HabilitarAsientoDia()
        {
            foreach (Control c in grpAsiento.Controls)
            {
                c.Enabled = true;
            }
        }

        private void DeshabilitarAsientoDia()
        {
            foreach (Control c in grpAsiento.Controls)
            {
                c.Enabled = false;
            }
        }

        private bool ValidarNumeros()
        {
            bool validar = true;

            if (lblSumatoria.Text == "" && dgvAsientoDelDia.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar el importe");
                validar = false;
            }
            return validar;
        }

        private bool ValidarTextos()
        {
            bool validar = false;
            if (txtApellido.Text == "" || txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar el apellido y el nombre");
            }
            else
            {
                validar = true;
            }
            return validar;
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtImporteItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cboItemsRecibo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDescripcion.Focus();
        }
    }
}
