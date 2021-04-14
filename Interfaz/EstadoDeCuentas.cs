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


        public EstadoDeCuentas()
        {
            InitializeComponent();
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
                        txtApellido.Text = pr.pApellido;
                        txtNombre.Text = pr.pNombre;
                        dgvEstadoDeuda.DataSource = ec.buscarEstadoCuenta(Convert.ToInt32(cboTipoDNI.SelectedValue), Convert.ToInt32(txtDni.Text));

                        double suma = 0;

                        foreach (DataGridViewRow row in dgvEstadoDeuda.Rows)
                        {
                            if (row.Cells["Debe"].Value != null)
                            {
                                suma += (double)row.Cells["Debe"].Value;
                            }
                        }
                        double resta = 0;

                        foreach (DataGridViewRow row in dgvEstadoDeuda.Rows)
                        {
                            if (row.Cells["Haber"].Value != null)
                            {
                                resta += (double)row.Cells["Haber"].Value;
                            }
                        }
                        double saldo = suma - resta;
                        lblSaldoCuenta.Text = Convert.ToString(saldo);
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
                //decimal importe = Convert.ToDecimal(txtImporteItem.Text);

                cp = new CaracteristicaPropiedad(); //Se genera una nueva característica
                cp.pId = Convert.ToInt32(cboItemsRecibo.SelectedIndex + 1);
                cp.pCaracteristica = cboItemsRecibo.Text;
                cp.pDescripcion = txtDescripcion.Text;
                cp.pImporte = Convert.ToDouble(txtImporteItem.Text);

                c.agregarItems(cp); //Se agrega a la lista

                dgvAsientoDelDia.Rows.Add(cp.pId, cp.pValor, cp.pCaracteristica, cp.pDescripcion, cp.pImporte); //Se agrega al DGV

                double suma = 0;

                foreach (DataGridViewRow row in dgvAsientoDelDia.Rows)
                {
                    if (row.Cells["Importe"].Value != null)
                    {
                        suma += (double)row.Cells["Importe"].Value;
                    }
                }

                //ValidarNumeros();
                double totalApagar = suma;
                lblSumatoria.Text = Convert.ToString(totalApagar);
                btnGrabarRegistro.Enabled = true;
                limpiarCampos();
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

        private void btnGrabarRegistro_Click(object sender, EventArgs e)
        {
            if (ValidarNumeros() && ValidarTextos() && dgvAsientoDelDia.RowCount > 0)
            {
                try
                {
                    if (cl.VerificarPersona(Convert.ToInt32(cboTipoDNI.SelectedValue), Convert.ToInt32(txtDni.Text)) > 0)
                    {
                        //pr.pApellido = txtApellido.Text;
                        //pr.pNombre = txtNombre.Text;
                        //pr.pDNI = Convert.ToInt32(txtDni.Text);
                        //pr.pTipoDNI = Convert.ToInt32(cboTipoDNI.SelectedValue);

                        c.pdni = Convert.ToInt32(txtDni.Text);
                        c.ptipoDNI = Convert.ToInt32(cboTipoDNI.SelectedValue);
                        c.pfecha = dtpFecha.Value;
                        c.pDescripcion = txtDescripcion.Text;

                        ec.insertarAsientoDeuda(c);
                        ec.guardarItemAsiento(c.pItem);

                        limpiarCampos();
                    }

                    else
                    {
                        DialogResult opcion = MessageBox.Show("La persona no está ingresada en la base de datos. \n ¿Desea imprimir de todas formas?", "¿Imprimir?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (opcion == DialogResult.Yes)
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

                            limpiarCampos();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox && !string.IsNullOrEmpty(c.Text)) //Si hay algo en los campos
                {
                    DialogResult opcion = MessageBox.Show("¿Desea descartar los campos ingresados?", "¿Borrar campos?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (opcion == DialogResult.Yes)
                    {
                        limpiarCampos();
                    }
                    break; //Hay que cortar el ciclo para que no salga más de un Message Box
                }
            }
        }


        //DATAGRIDVIEW ASIENTO DEL DÍA
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
            dgv.Columns.Add("Id", "Id");
            dgv.Columns[0].Visible = false;
            dgv.Columns.Add("Valor", "Valor");
            dgv.Columns[1].Visible = false;
            dgv.Columns.Add("Item", "Item");
            dgv.Columns.Add("Descripción", "Descripción");
            dgv.Columns.Add("Importe", "Importe");

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

        //DATAGRIDVIEW ESTADO DEUDA
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


        //VALIDACIONES Y LIMPIEZAS
        private void limpiarCampos()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox && !string.IsNullOrEmpty(c.Text))
                {
                    c.Text = "";
                }
            }
            lblSumatoria.Text = "";
            dgvAsientoDelDia.Rows.Clear();
            c.pItem.Clear();
            txtDni.Focus();
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
    }
}
