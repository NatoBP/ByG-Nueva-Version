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
            deshabilitarCampos();
            buscarNoVigentes();
            ConfiguracionDGV();
        }

        private void buscarNoVigentes()
        {
            dgvAlquileresNoV.DataSource = alq.buscarContratoNoVigente("", "");
        }


        //BOTONES

        private void bntBuscarAlquiler_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text != "" && txtNombre.Text == "")
                dgvAlquileresNoV.DataSource = alq.buscarContratoNoVigente(txtApellido.Text, "");

            else if (txtApellido.Text == "" && txtNombre.Text != "")
                dgvAlquileresNoV.DataSource = alq.buscarContratoNoVigente("", txtNombre.Text);

            else if (txtApellido.Text != "" && txtNombre.Text != "")
                MessageBox.Show("Solo se puede buscar por nombre o por apellido");

            else
                dgvAlquileresNoV.DataSource = alq.buscarContratoNoVigente("", "");
        }

        private void btnEstadoCuenta_Click(object sender, EventArgs e)
        {
            //Comprobantes c = new Comprobantes();
            //AddOwnedForm(c);
            //c.TopLevel = false;
            //c.Dock = DockStyle.Fill;
            //this.Controls.Add(c);
            //this.Tag = c;

            //c.txtApellido.Text = dgvAlquileresV.CurrentRow.Cells[2].Value.ToString();
            //c.txtNombre.Text = dgvAlquileresV.CurrentRow.Cells[3].Value.ToString();
            //c.txtDni.Text = dgvAlquileresV.CurrentRow.Cells[0].Value.ToString();
            //c.cboTipoDNI.SelectedValue = Convert.ToInt32(dgvAlquileresV.CurrentRow.Cells[1].Value);
            //c.rtbNot.Text = this.rtbNotas.Text;
            //c.txtIdContrato.Text = dgvAlquileresV.CurrentRow.Cells[12].Value.ToString();
            //c.BringToFront();
            //c.Show();
            //FALTAN INSTRUCCIONES PARA TRAER LOS DATOS DEL LOCATARIO
        }


        //CONTROLES DEL DATAGRIDVIEW

        //Selección
        private void dgvAlquileresNoV_SelectionChanged(object sender, EventArgs e)
        {
            cargarCampos();
        }

        //Click
        private void dgvAlquileresNoV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvAlquileresNoV.Rows.Count > 0)
            {
                cargarCampos();
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
        private void cargarCampos()
        {
            if (dgvAlquileresNoV.CurrentRow != null)
            {
                //txtApellido.Text = Convert.ToString(dgvAlquileresV.CurrentRow.Cells[2].Value);
                //txtNombre.Text = Convert.ToString(dgvAlquileresV.CurrentRow.Cells[3].Value);
                //txtAlquilerV.Text = Math.Round((Convert.ToDouble(dgvAlquileresV.CurrentRow.Cells[8].Value)), 2).ToString();

                //if (dgvAlquileresV.CurrentRow.Cells[14].Value.ToString() != "")
                //{
                //    dtpUltimoPago.Value = Convert.ToDateTime(dgvAlquileresV.CurrentRow.Cells[13].Value);
                //}

                //if (Convert.ToDateTime(dgvAlquileresV.CurrentRow.Cells[9].Value) >= DateTime.Now && banderaUltimoAño == 0)
                //{
                //    dtp1raRenovacion.Value = Convert.ToDateTime(dgvAlquileresV.CurrentRow.Cells[9].Value);
                //}
                //else if (Convert.ToDateTime(dgvAlquileresV.CurrentRow.Cells[10].Value) >= DateTime.Now && banderaUltimoAño == 0)
                //{
                //    dtp1raRenovacion.Value = Convert.ToDateTime(dgvAlquileresV.CurrentRow.Cells[10].Value);
                //}
                //else if (banderaUltimoAño == 0)
                //{
                //    MessageBox.Show("está transcurriendo el último año de contrato");
                //    dtp1raRenovacion.Value = Convert.ToDateTime(dgvAlquileresV.CurrentRow.Cells[11].Value);
                //    banderaUltimoAño = 1;
                //}


                //dtpFinContrato.Value = Convert.ToDateTime(dgvAlquileresV.CurrentRow.Cells[11].Value);
                //rtbNotas.Text = Convert.ToString(dgvAlquileresV.CurrentRow.Cells[15].Value);
            }


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

            dgv.AutoGenerateColumns = false;
            dgv.Columns.Add("Apellido Locatario", "Apellido Locatario/a:");
            dgv.Columns.Add("Nombre Locatario", "Nombre Locatario/a:");
            dgv.Columns.Add("Apellido Locador", "Apellido Locador/a:");
            dgv.Columns.Add("Nombre Locador", "Nombre Locador/a:");
            dgv.Columns.Add("Direccion", "Dirección:");
            dgv.Columns.Add("Numero", "Número:");
            dgv.Columns.Add("Precio alquiler", "Precio Alquiler:");

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
