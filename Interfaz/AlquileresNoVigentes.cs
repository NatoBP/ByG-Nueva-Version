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

namespace Interfaz
{
    public partial class AlquileresNoVigentes : Form
    {
        AlquileresAD alq = new AlquileresAD();

        public AlquileresNoVigentes()
        {
            InitializeComponent();
            buscarNoVigentes();
            ConfiguracionDGV();
            invisibilizarColumnas();
            deshabilitarCampos();
        }

        private void buscarNoVigentes()
        {
            dgvAlquileresNoV.Columns.Clear();
            dgvAlquileresNoV.DataSource = alq.buscarContratoNoVigente("", "").Tables[0];
            if (dgvAlquileresNoV.DataSource != null)
                invisibilizarColumnas();
        }


        //BOTONES

        private void bntBuscarAlquiler_Click(object sender, EventArgs e)
        {
            if (txtApellidoNoV.Text != "" && txtNombreNoV.Text == "")
                dgvAlquileresNoV.DataSource = alq.buscarContratoNoVigente(txtApellidoNoV.Text, "").Tables[0];

            else if (txtApellidoNoV.Text == "" && txtNombreNoV.Text != "")
                dgvAlquileresNoV.DataSource = alq.buscarContratoNoVigente("", txtNombreNoV.Text).Tables[0];

            else if (txtApellidoNoV.Text != "" && txtNombreNoV.Text != "")
                MessageBox.Show("Solo se puede buscar por nombre o por apellido");

            else
                dgvAlquileresNoV.DataSource = alq.buscarContratoNoVigente("", "").Tables[0];
        }

        private void btnEstadoCuenta_Click(object sender, EventArgs e)
        {
            int dni = Convert.ToInt32(dgvAlquileresNoV.CurrentRow.Cells[0].Value);
            int tipo = Convert.ToInt32(dgvAlquileresNoV.CurrentRow.Cells[1].Value);

            if (dgvAlquileresNoV.SelectedRows.Count > 0 && dgvAlquileresNoV.CurrentRow != null)
            {
                EstadoDeCuentas ec = new EstadoDeCuentas();
                abrirVentana<EstadoDeCuentas>(ec);
                ec.AlquileresNoV = true;
                ec.CargarPersona(tipo, dni);
            }
        }


        //CONTROLES DEL DATAGRIDVIEW

        //Selección
        private void dgvAlquileresNoV_SelectionChanged(object sender, EventArgs e)
        {
            cargarDatosACampos();
        }

        //Click
        private void dgvAlquileresNoV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvAlquileresNoV.Rows.Count > 0)
            {
                cargarDatosACampos();
            }
        }

        //Doble Click
        private void dgvAlquileresNoV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Process abrirDoc = new Process();
            abrirDoc.StartInfo.FileName = @"C:\Users\Nato\Documents\GitHub\Contratos\" +
                dgvAlquileresNoV.CurrentRow.Cells[4].Value.ToString().ToUpper() + " " + dgvAlquileresNoV.CurrentRow.Cells[5].Value +
                " - " + dgvAlquileresNoV.CurrentRow.Cells[6].Value + " N°" + dgvAlquileresNoV.CurrentRow.Cells[7].Value + @"\" +
                dgvAlquileresNoV.CurrentRow.Cells[12].Value + " - " + dgvAlquileresNoV.CurrentRow.Cells[4].Value + " " +
                dgvAlquileresNoV.CurrentRow.Cells[5].Value + " - " + dgvAlquileresNoV.CurrentRow.Cells[2].Value + " " +
                dgvAlquileresNoV.CurrentRow.Cells[3].Value + ".docx" + "";
            abrirDoc.Start();
        }

        //Cargar Campos
        private void cargarDatosACampos()
        {
            if (dgvAlquileresNoV.CurrentRow != null)
            {
                txtApellido.Text = Convert.ToString(dgvAlquileresNoV.CurrentRow.Cells[2].Value);
                txtNombre.Text = Convert.ToString(dgvAlquileresNoV.CurrentRow.Cells[3].Value);
                txtAlquilerNoV.Text = Math.Round((Convert.ToDouble(dgvAlquileresNoV.CurrentRow.Cells[8].Value)), 2).ToString();

                DateTime Vigencia = DateTime.Today;

                if (dgvAlquileresNoV.CurrentRow.Cells[11].Value.ToString() != "")
                {
                    Vigencia = Convert.ToDateTime(dgvAlquileresNoV.CurrentRow.Cells[11].Value);
                }

                if (dgvAlquileresNoV.CurrentRow.Cells[13].Value.ToString() != "")
                {
                    dtpUltimoPago.Value = Convert.ToDateTime(dgvAlquileresNoV.CurrentRow.Cells[13].Value);
                }
                else
                {
                    dtpUltimoPago.Text = "01/01/1990";
                }

                dtpFinContrato.Value = Vigencia;
                rtbNotas.Text = Convert.ToString(dgvAlquileresNoV.CurrentRow.Cells[15].Value);
            }
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

        public void Recargar(string apellido) //Hace refresh cuando vuelve de otras ventanas
        {
            dgvAlquileresNoV.Columns.Clear();
            dgvAlquileresNoV.DataSource = alq.buscarContratoNoVigente(apellido, "").Tables[0];
            if (dgvAlquileresNoV.DataSource != null)
                invisibilizarColumnas();
        }

        //CONFIGURACIÓN DATAGRIDVIEW
        private void ConfiguracionDGV()
        {
            var dgv = dgvAlquileresNoV;
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

            invisibilizarColumnas();

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
            var dgv = dgvAlquileresNoV;

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

        //VALIDACIONES Y LIMPIEZAS

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
