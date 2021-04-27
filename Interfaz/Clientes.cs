using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos.Clases;
using AccesoDatos;


namespace Interfaz
{
    public partial class Clientes : Form
    {
        Persona pr = new Persona();
        ClienteAD cl = new ClienteAD();
        TransaccionAD tc = new TransaccionAD();

        //Banderas
        public bool locador = false; //HAY QUE ENCONTRAR LA FORMA DE QUE SEAN PRIVADAS
        public bool locatario = false;
        public bool garante = false;
        public bool comprobantes = false;
        public bool nuevaPropiedad = false;

        Int32 dni; //Estas variables se usan para hacer una nueva búsqueda de teléfono porque si no, no tengo el ID
        Int32 tipo;

        List<int> idTelefonoBorrar = new List<int>();

        public Clientes()
        {
            InitializeComponent();
            ConfiguracionDGV();
            cargaInicial();
        }

        //BOTONES
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

        private void btnBorrarTelefono_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTelefonos.SelectedRows.Count > 0 && dgvTelefonos.CurrentRow != null)
                {
                    DialogResult opcion = MessageBox.Show("¿Está segura que desea borrar el registro?", "¿Borrar registro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (opcion == DialogResult.Yes)
                    {
                        string codigoA = dgvTelefonos.CurrentRow.Cells[1].Value.ToString();
                        string numero = dgvTelefonos.CurrentRow.Cells[2].Value.ToString();

                        for (int i = 0; i < pr.pTelefono.Count; i++) //Es necesario un ciclo For para Remove porque las listas necesitan de los índices para funcionar y no se puede con Foreach
                        {
                            if(pr.pTelefono[i].pcodigoArea.Equals(codigoA) && pr.pTelefono[i].pnumero.Equals(numero))
                            {
                                idTelefonoBorrar.Add(Convert.ToInt32(dgvTelefonos.CurrentRow.Cells[0].Value)); //Obtenemos el Id para después borrar el teléfono al Guardar

                                pr.pTelefono.RemoveAt(i);
                                i--;
                            }
                        }

                        dgvTelefonos.Rows.Clear();

                        if(pr.pTelefono.Count > 0)
                        {
                            foreach (var item in pr.pTelefono)//Volvemos a cargar la lista en el DGV
                            {
                                dgvTelefonos.Rows.Add(item.pIdTelefono, item.pcodigoArea, item.pnumero);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCamposCliente())
            {
                dni = pr.pDNI = Convert.ToInt32(txtDNI.Text);
                tipo = pr.pTipoDNI = Convert.ToInt32(cboTipoDNI.SelectedValue);
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

                //Si la persona No existe, INSERTAR
                if (cl.VerificarPersona(pr.pTipoDNI, pr.pDNI) == 0)
                {
                    cl.InsertarPersona(pr); //Primero se hace la inserción con los campos ingresados

                    pr.pTelefono = null; //Limpio la lista de teléfonos
                    pr.pTelefono = cl.buscarTelefonos(tipo, dni); //Se necesita buscar los teléfonos porque si no, no tienen el ID

                    if (locador == true) //Si se ingresa un nuevo Locador desde Nuevo Contrato
                    {
                        NuevoContrato nc = (NuevoContrato)this.ParentForm;
                        locador = false; //Ponemos la bandera falso
                        abrirVentana<NuevoContrato>(nc);
                        nc.cargarCamposLocador(pr); //Cargamos los campos

                        this.Close();
                    }
                    else if (locatario == true)
                    {
                        NuevoContrato nc = (NuevoContrato)this.ParentForm;
                        locatario = false;
                        abrirVentana<NuevoContrato>(nc);
                        nc.cargarCamposLocatario(pr);

                        this.Close();
                    }
                    else if (garante == true)
                    {
                        NuevoContrato nc = (NuevoContrato)this.ParentForm;
                        garante = false;
                        abrirVentana<NuevoContrato>(nc);
                        nc.cargarCamposGarante(pr);

                        this.Close();
                    }
                    else if (comprobantes == true)
                    {
                        EstadoDeCuentas ec = (EstadoDeCuentas)this.ParentForm;
                        comprobantes = false;
                        abrirVentana<EstadoDeCuentas>(ec);
                        //FALTA CARGA DE DATOS EN LA VENTANA ESTADO DE CUENTAS

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Se ingresó correctamente el registro");
                        this.Close();
                    }
                }

                //Si la persona existe, ACTUALIZAR
                else
                {
                    cl.modificarPersona(pr);
                    foreach (var item in idTelefonoBorrar)
                    {
                        if (item != 0) //Si el valor es 0, es porque el teléfono se cargó y se borró en el momento por lo cual no está ingresado en BD y no hace falta borrarlo
                            cl.BorrarTelefono(item);
                    }
                    pr.pTelefono = null; //Limpio la lista de teléfonos
                    pr.pTelefono = cl.buscarTelefonos(tipo, dni); //Se necesita buscar los teléfonos porque si no, no tienen el ID

                    if (locador == true) 
                    {
                        NuevoContrato nc = (NuevoContrato)this.ParentForm;
                        
                        locador = false; 
                        abrirVentana<NuevoContrato>(nc);
                        nc.cargarCamposLocador(pr); 

                        this.Close();
                    }
                    else if (locatario == true)
                    {
                        NuevoContrato nc = (NuevoContrato)this.ParentForm;
                        locatario = false;
                        abrirVentana<NuevoContrato>(nc);
                        nc.cargarCamposLocatario(pr);

                        this.Close();
                    }
                    else if (garante == true)
                    {
                        NuevoContrato nc = (NuevoContrato)this.ParentForm;
                        garante = false;
                        abrirVentana<NuevoContrato>(nc);
                        nc.cargarCamposGarante(pr);

                        this.Close();
                    }
                    else if (comprobantes == true)
                    {
                        EstadoDeCuentas ec = (EstadoDeCuentas)this.ParentForm;
                        comprobantes = false;
                        abrirVentana<EstadoDeCuentas>(ec);

                        this.Close();
                        //FALTA CARGA DE DATOS EN LA VENTANA ESTADO DE CUENTAS
                    }
                    else
                    {
                        MessageBox.Show("Se modificó correctamente el registro");
                        this.Close();
                    }
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtDNI.Enabled == true)
            {
                habilitarCamposCliente();
                cboTipoDNI.Enabled = false;
                txtDNI.Enabled = false;
            }
            else
            {
                deshabilitarCamposCliente();
                txtDNI.Enabled = true;
                cboTipoDNI.Enabled = true;
            }
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            foreach (Control c in pnlBase.Controls)
            {
                if (c is TextBox && !c.Text.Equals("") && c != txtDNI)
                {
                    DialogResult opcion = MessageBox.Show("Hay campos ingresados, ¿desea salir igual?", "Campos ingresados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (opcion == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    else
                    {
                        return;
                    }

                    break;
                }
            }
            this.Close();
        }

                //Funcionalidad Combo Tipo-DNI
        private void cboTipoDNI_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarCamposCliente();

            if (txtDNI.Text != "")
            {
                try
                {
                    if (cl.VerificarPersona(Convert.ToInt32(cboTipoDNI.SelectedValue), Convert.ToInt32(txtDNI.Text)) != 0)

                    {
                        pr = cl.BuscarPersona(Convert.ToInt32(cboTipoDNI.SelectedValue), Convert.ToInt32(txtDNI.Text));
                        pr.pTelefono = cl.buscarTelefonos(Convert.ToInt32(cboTipoDNI.SelectedValue), Convert.ToInt32(txtDNI.Text)); //Ya carga los teléfonos en la lista

                        foreach (var item in pr.pTelefono)
                        {
                            dgvTelefonos.Rows.Add(item.pIdTelefono, item.pcodigoArea, item.pnumero);
                        }

                        txtApellido.Text = pr.pApellido;
                        txtNombre.Text = pr.pNombre;
                        txtDireccion.Text = pr.pDireccion;

                        if (pr.pAltura == 0)
                            txtAltura.Text = "";
                        else
                            txtAltura.Text = Convert.ToString(pr.pAltura);

                        if (pr.pPiso == 0)
                            txtPiso.Text = "";
                        else
                            txtPiso.Text = Convert.ToString(pr.pPiso);

                        txtDepto.Text = pr.pDepto;
                        cboProvincia.SelectedValue = pr.pProvincia;
                        cboDepartamento.SelectedValue = pr.pdepartamento;
                        cboCiudad.SelectedValue = pr.pciudad;
                        cboBarrio.SelectedValue = pr.pBarrio;
                        txtMail.Text = pr.pMail;
                        deshabilitarCamposCliente();
                    }
                    else
                        btnEditar.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        //MÉTODOS DE CARGA DE DATOS
                //Nuevos clientes cuyos datos vienen de otras ventanas
        public void nuevoCliente(Int32 tipo, string dni, string apellido)
        {
            limpiarCamposCliente();

            cboTipoDNI.SelectedValue = tipo;
            txtDNI.Text = dni;
            txtApellido.Text = apellido;
            cboProvincia.SelectedValue = 14;
            cboDepartamento.SelectedValue = 14021;
        }

                //Clientes cuyos datos vienen para ser editados
        public void editarCliente(Persona per)
        {
            limpiarCamposCliente();
            cboTipoDNI.Enabled = false;
            txtDNI.Enabled = false;
            pr = null;
            pr = per;

            cboTipoDNI.SelectedValue = per.pTipoDNI;
            txtDNI.Text = Convert.ToString(per.pDNI);
            txtApellido.Text = per.pApellido;
            foreach (var item in per.pTelefono)
            {
                dgvTelefonos.Rows.Add(item.pIdTelefono, item.pcodigoArea, item.pnumero);
            }
            txtNombre.Text = per.pNombre;
            txtDireccion.Text = per.pDireccion;
            txtAltura.Text = Convert.ToString(per.pAltura);
            txtPiso.Text = Convert.ToString(per.pPiso);
            txtDepto.Text = per.pDepto;
            cboProvincia.SelectedValue = per.pProvincia;
            cboDepartamento.SelectedValue = per.pdepartamento;
            cboCiudad.SelectedValue = per.pciudad;
            cboBarrio.SelectedValue = per.pBarrio;
            txtMail.Text = per.pMail;
        }

        private void btnBorrarPersona_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion = MessageBox.Show("¿Está segura que desea borrar este registro?", "Borrar Persona", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (opcion == DialogResult.Yes)
                {
                    cl.borrarPersona(pr);
                    limpiarCamposCliente();
                    txtDNI.Clear();
                }
                else
                    return;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //Abrir Ventana
        private void abrirVentana<MiForm>(Form formHijo) where MiForm : Form, new()
        {
            Form fh;
            fh = pnlBase.Controls.OfType<MiForm>().FirstOrDefault();

            if (fh == null)
            {
                fh = formHijo as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.Tag = fh;

                fh.BringToFront();
                fh.Show();
            }
        }


        //CARGA INICIAL
        private void cargaInicial()
        {
            tc.traerCombo(cboTipoDNI, "TiposDNI", "id_DNI", "tipoDNI", "", -1);
            tc.traerCombo(cboProvincia, "Provincias", "id_provincia", "nombre", "", -1);
            tc.traerCombo(cboDepartamento, "Departamentos", "id_departamento", "nombreDpto", "", -1);
            tc.traerCombo(cboCiudad, "Ciudades", "id_ciudad", "nombreCiu", "", -1);
            tc.traerCombo(cboBarrio, "Barrios", "id_barrio", "nombreBarr", "", -1);
            cboProvincia.SelectedValue = 14;
            cboDepartamento.SelectedValue = 14021;
        }


        //CONFIGURACIÓN DATAGRIDVIEW TELÉFONOS
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
            dgv.AutoGenerateColumns = false;
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


        //FUNCIONAMIENTO COMBO-BOXES
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


        #region//VALIDACIONES - HABILITACIÓN Y DESHABILITACIÓN DE CAMPOS

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
            foreach (Control c in pnlBase.Controls)
            {
                if (c is TextBox && !string.IsNullOrEmpty(c.Text) && c != txtDNI)
                {
                    c.Text = "";
                }
            }
            cboProvincia.SelectedIndex = -1;

            cboDepartamento.SelectedIndex = -1;
            cboCiudad.SelectedIndex = -1;
            cboBarrio.SelectedIndex = -1;

            dgvTelefonos.Rows.Clear();
            txtDNI.Focus();
        }

        public void deshabilitarCamposCliente()
        {
            foreach (Control c in pnlBase.Controls)
            {
                if (c is TextBox && c != txtDNI)
                {
                    c.Enabled = false;
                }
                else if (c is ComboBox && c != cboTipoDNI)
                {
                    c.Enabled = false;
                }
                else if (c is Button)
                {
                    c.Enabled = false;
                }
            }
            dgvTelefonos.Enabled = false;
            btnEditar.Enabled = true;
        }

        public void habilitarCamposCliente()
        {
            foreach (Control c in pnlBase.Controls)
            {
                if (c is TextBox)
                {
                    c.Enabled = true;
                }
                else if (c is ComboBox && c != cboTipoDNI)
                {
                    c.Enabled = true;
                }
                else if (c is Button)
                {
                    c.Enabled = true;
                }
            }
            dgvTelefonos.Enabled = true;
        }

            //KEY PRESS - INHABILITACIÓN DE TECLAS EN TEXTBOXES
        private void txtDNI_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void txtApellido_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void txtNombre_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void txtDireccion_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsNumber(e.KeyChar))
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

        private void txtAltura_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void txtMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
                e.Handled = true;
        }

        private void txtCodArea_KeyPress_1(object sender, KeyPressEventArgs e)
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
        
        private void txtTelefono_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void txtPiso_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsNumber(e.KeyChar))
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
        #endregion

        
    }
}
