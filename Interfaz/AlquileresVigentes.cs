using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using AccesoDatos.Clases;

namespace Interfaz
{
    public partial class AlquileresVigentes : Form
    {
        AlquileresAD alq = new AlquileresAD();
        Persona pr;

        public AlquileresVigentes()
        {
            InitializeComponent();
            buscarVigentes();
            ConfiguracionDGV();
            
            deshabilitarCampos();
        }

        private void buscarVigentes()
        {
            dgvAlquileresV.Columns.Clear();
            dgvAlquileresV.DataSource = alq.buscarContratoVigente("", "").Tables[0];
            if (dgvAlquileresV.DataSource != null)
                invisibilizarColumnas();
        }

        //BOTONES

        private void bntBuscarAlquiler_Click(object sender, EventArgs e)
        {
            if (txtApellidoV.Text != "" && txtNombreV.Text == "")
            {
                dgvAlquileresV.Columns.Clear();
                dgvAlquileresV.DataSource = alq.buscarContratoVigente(txtApellidoV.Text, "").Tables[0];
                invisibilizarColumnas();
                txtApellidoV.Clear();
            }

            else if (txtApellidoV.Text == "" && txtNombreV.Text != "")
            {
                dgvAlquileresV.Columns.Clear();
                dgvAlquileresV.DataSource = alq.buscarContratoVigente("", txtNombreV.Text).Tables[0];
                invisibilizarColumnas();
                txtNombreV.Clear();
            }

            else if (txtApellidoV.Text != "" && txtNombreV.Text != "")
                MessageBox.Show("Solo se puede buscar por nombre o por apellido");

            else
            {
                dgvAlquileresV.Columns.Clear();
                dgvAlquileresV.DataSource = alq.buscarContratoVigente("", "").Tables[0];
                invisibilizarColumnas();
            }
            txtApellidoV.Focus();
        }

        private void btnBajaContrato_Click(object sender, EventArgs e)
        {
            if (dgvAlquileresV.Rows.Count > 0)
            {
                DialogResult opcion = MessageBox.Show("¿Está segura que desea dar de baja el contrato?", "Baja Contrato", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (opcion == DialogResult.Yes)
                {
                    alq.bajaContrato(DateTime.Today, Convert.ToInt32(dgvAlquileresV.CurrentRow.Cells[12].Value));
                }
            }
            buscarVigentes();
        }

        private void btnEstadoCuenta_Click(object sender, EventArgs e)
        {
            int dni = Convert.ToInt32(dgvAlquileresV.CurrentRow.Cells[0].Value);
            int tipo = Convert.ToInt32(dgvAlquileresV.CurrentRow.Cells[1].Value);

            if (dgvAlquileresV.SelectedRows.Count > 0 && dgvAlquileresV.CurrentRow != null)
            {
                EstadoDeCuentas ec = new EstadoDeCuentas();
                abrirVentana<EstadoDeCuentas>(ec);
                ec.AlquileresV = true;
                ec.CargarPersona(tipo, dni);
            }
        }


        //CONTROLES DEL DATAGRIDVIEW

        //Selección
        private void dgvAlquileresV_SelectionChanged(object sender, EventArgs e)
        {
            cargarDatosACampos();
        }

        //Click
        private void dgvAlquileresV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvAlquileresV.Rows.Count > 0)
            {
                cargarDatosACampos();
            }
        }

        //Doble Click
        private void dgvAlquileresV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Process abrirDoc = new Process();
            abrirDoc.StartInfo.FileName = @"C:\Users\Nato\Documents\GitHub\Contratos\" +
                dgvAlquileresV.CurrentRow.Cells[4].Value.ToString().ToUpper() + " " + dgvAlquileresV.CurrentRow.Cells[5].Value +
                " - " + dgvAlquileresV.CurrentRow.Cells[6].Value + " N°" + dgvAlquileresV.CurrentRow.Cells[7].Value + @"\" +
                dgvAlquileresV.CurrentRow.Cells[12].Value + " - " + dgvAlquileresV.CurrentRow.Cells[4].Value + " " +
                dgvAlquileresV.CurrentRow.Cells[5].Value + " - " + dgvAlquileresV.CurrentRow.Cells[2].Value + " " +
                dgvAlquileresV.CurrentRow.Cells[3].Value + ".docx" + "";
            abrirDoc.Start();
        }

        //Cargar Campos

        private void cargarDatosACampos()
        {
            if (dgvAlquileresV.CurrentRow != null)
            {
                txtApellido.Text = Convert.ToString(dgvAlquileresV.CurrentRow.Cells[2].Value);
                txtNombre.Text = Convert.ToString(dgvAlquileresV.CurrentRow.Cells[3].Value);
                txtAlquilerV.Text = Math.Round((Convert.ToDouble(dgvAlquileresV.CurrentRow.Cells[8].Value)), 2).ToString();

                DateTime PrimeraRenovacion = DateTime.Today;
                DateTime SegundaRenovacion = DateTime.Today;
                DateTime Vigencia = DateTime.Today;

                if (dgvAlquileresV.CurrentRow.Cells[9].Value.ToString() != "")
                {
                    PrimeraRenovacion = Convert.ToDateTime(dgvAlquileresV.CurrentRow.Cells[9].Value);
                }
                if (dgvAlquileresV.CurrentRow.Cells[10].Value.ToString() != "")
                {
                    SegundaRenovacion = Convert.ToDateTime(dgvAlquileresV.CurrentRow.Cells[10].Value);
                }
                if (dgvAlquileresV.CurrentRow.Cells[11].Value.ToString() != "")
                {
                    Vigencia = Convert.ToDateTime(dgvAlquileresV.CurrentRow.Cells[11].Value);
                }

                DateTime Hoy = DateTime.Today;

                if (dgvAlquileresV.CurrentRow.Cells[13].Value.ToString() != "")
                {
                    dtpUltimoPago.Value = Convert.ToDateTime(dgvAlquileresV.CurrentRow.Cells[13].Value);
                }
                else
                {
                    dtpUltimoPago.Text = "01/01/1990";
                }

                if ( PrimeraRenovacion >= Hoy) //Primera Actualización
                {
                    dtpRenovacion.Value = PrimeraRenovacion;
                }
                else if (SegundaRenovacion >= Hoy && PrimeraRenovacion < Hoy)//Segunda Actualización
                {
                    dtpRenovacion.Value = SegundaRenovacion;
                }
                else if (SegundaRenovacion < Hoy)
                {
                    lblAlerta.Text = "Último año de contrato";
                    dtpRenovacion.Value = Vigencia; //Fin del Contrato
                }

                dtpFinContrato.Value = Vigencia;
                rtbNotas.Text = Convert.ToString(dgvAlquileresV.CurrentRow.Cells[15].Value);
            }
        }

        public void Recargar(string apellido) //Hace refresh cuando vuelve de otras ventanas
        {
            dgvAlquileresV.Columns.Clear();
            dgvAlquileresV.DataSource = alq.buscarContratoVigente(apellido, "").Tables[0];
            if (dgvAlquileresV.DataSource != null)
                invisibilizarColumnas();
        }

        private void abrirVentana<MiForm>(Form formHijo) where MiForm : Form, new()
        {
            Form fh;
            fh = pnlBase.Controls.OfType<MiForm>().FirstOrDefault();

            if (fh == null)
            {
                fh = formHijo as Form;
                AddOwnedForm(fh);
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.Controls.Add(fh);
                this.Tag = fh;

                fh.BringToFront();
                fh.Show();
            }
        }


        //CONFIGURACIÓN DATAGRIDVIEW
        private void ConfiguracionDGV()
        {
            var dgv = dgvAlquileresV;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            //COLUMNAS
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(99, 103, 125);
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

        private void invisibilizarColumnas()
        {
            var dgv = dgvAlquileresV;
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
            dgv.Columns[8].Visible = false;
            dgv.Columns[9].Visible = false;
            dgv.Columns[10].Visible = false;
            dgv.Columns[11].Visible = false;
            dgv.Columns[12].Visible = false;
            dgv.Columns[13].Visible = false;
            dgv.Columns[14].Visible = false;
            dgv.Columns[15].Visible = false;
        }


        private void deshabilitarCampos()
        {
            foreach (Control c in pnlDatos.Controls)
            {
                if (c is TextBox)
                {
                    c.Enabled = false;
                }
                else if (c is DateTimePicker)
                {
                    c.Enabled = false;
                }
            }
        }

        private void txtApellidoV_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNombreV_KeyPress(object sender, KeyPressEventArgs e)
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
