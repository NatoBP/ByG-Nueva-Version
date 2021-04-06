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
    public partial class NuevoContrato : Form
    {
        //ACCESO A DATOS
        TransaccionAD tc = new TransaccionAD();
        ClienteAD cl = new ClienteAD();
        PropiedadAD p = new PropiedadAD();

        //OBJETOS
        Persona locador = new Persona();
        Persona locatario = new Persona();
        Persona garante = new Persona();
        List<Propiedad> listaProp = new List<Propiedad>();
        List<Persona> listaGarantes = new List<Persona>();
        int[] ubicacion = new int[4];

        //INTERFAZ
        Clientes c;

        public NuevoContrato()
        {
            InitializeComponent();
            cargaInicial();
        }

        //BOTONES LOCADOR
        private void btnBuscarProp_Click(object sender, EventArgs e)
        {
            dgvPropiedades.Rows.Clear();

            try
            {
                if (txtDNILocador.Text != "" && cboTipo.SelectedIndex != -1)
                {
                    if (cl.VerificarPersona(Convert.ToInt32(cboTipo.SelectedValue), Convert.ToInt32(txtDNILocador.Text)) > 0)
                    {
                        locador = cl.BuscarPersona(Convert.ToInt32(cboTipo.SelectedValue), Convert.ToInt32(txtDNILocador.Text));
                        locador.pTelefono = cl.buscarTelefonos(Convert.ToInt32(cboTipo.SelectedValue), Convert.ToInt32(txtDNILocador.Text));

                        lblApellidoLocador.Text = locador.pApellido;
                        lblNombreLocador.Text = locador.pNombre;
                        lblDirLocador.Text = locador.pDireccion + " nº" + locador.pAltura;
                        tc.traerCombo(cboBarrioLocador, "Barrios", "id_barrio", "nombreBarr", "ciudad", locador.pciudad);


                        listaProp = p.CargarListaPropiedades(Convert.ToInt32(txtDNILocador.Text), Convert.ToInt32(cboTipo.SelectedValue));
                        foreach (var item in listaProp)
                        {
                            dgvPropiedades.Rows.Add(item.pId_propiedad, item.pCalle, item.pNumeroCalle);
                        }

                        btnIngresarPropiedad.Enabled = true;
                    }
                    else
                    {
                        btnIngresarPropiedad.Enabled = false;
                        DialogResult opcion = MessageBox.Show("El registro no existe. ¿Desea cargar un nuevo Locador/a?", "¿Nuevo Locador/a?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (opcion == DialogResult.Yes)
                        {
                            c = new Clientes();
                            c.locador = true;
                            c.habilitarCamposCliente();
                            c.nuevoCliente(Convert.ToInt32(cboTipo.SelectedValue), txtDNILocador.Text);

                            AddOwnedForm(c);
                            c.TopLevel = false;
                            c.Dock = DockStyle.Fill;
                            this.Controls.Add(c);
                            this.Tag = c;

                            c.BringToFront();
                            c.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void btnEditarLocador_Click(object sender, EventArgs e)
        {
            if (txtDNILocador.Text != "" && cboTipo.SelectedIndex != -1)
            {
                c = new Clientes();
                c.locador = true;
                c.habilitarCamposCliente();

                AddOwnedForm(c);
                c.TopLevel = false;
                c.Dock = DockStyle.Fill;
                this.Controls.Add(c);
                this.Tag = c;

                c.BringToFront();
                c.Show();
                c.editarCliente(locador);
            }
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
                limpiarCamposLocador();
        }

        private void btnIngresarPropiedad_Click(object sender, EventArgs e)
        {
            //limpiarCamposPropiedad();
            //habilitarCamposPropiedad();
            //btnQuitarCaracteristica.Enabled = false; //deshabilita el sacar caracteristicas, hasta que haya alguna
            //inicializarText();

            if (txtDNILocador.Text != "" && cboTipo.SelectedIndex != -1)
            {
                Propiedades prop = new Propiedades();
                prop.cargarNuevaPropiedad(locador.pTipoDNI, locador.pDNI);

                //lblPropietario.Text = pr.pApellido + " " + pr.pNombre;
                //lblDNIProp.Text = Convert.ToString(pr.pDNI);
                //lblTipoDNI.Text = Convert.ToString(cboTipo.SelectedIndex + 1);
            }
        }


        //BOTONES LOCATARIO
        private void cboTipoLocatario_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarCamposLocatario();
        }

        private void btnBuscarLocatario_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDNILocatario.Text != "" && cboTipoLocatario.SelectedIndex != -1)
                {
                    if (cl.VerificarPersona(Convert.ToInt32(cboTipoLocatario.SelectedValue), Convert.ToInt32(txtDNILocatario.Text)) > 0)
                    {
                        locatario = cl.BuscarPersona(Convert.ToInt32(cboTipoLocatario.SelectedValue), Convert.ToInt32(txtDNILocatario.Text));
                        locatario.pTelefono = cl.buscarTelefonos(Convert.ToInt32(cboTipoLocatario.SelectedValue), Convert.ToInt32(txtDNILocatario.Text));

                        lblApeLocatario.Text = locatario.pApellido;
                        lblNomLocatario.Text = locatario.pNombre;
                        lblDirLocatario.Text = locatario.pDireccion;
                        lblNumLocatario.Text = Convert.ToString(locatario.pAltura);
                        if(locatario.pTelefono.Count > 0)
                        {
                            foreach (var item in locatario.pTelefono)
                            {
                                lblCodArLocatario.Text = Convert.ToString(item.pcodigoArea);
                                lblTelLocatario.Text = Convert.ToString(item.pnumero);
                                break;
                            }
                        }
                        lblPisoLocatario.Text = Convert.ToString(locatario.pPiso);
                        lblDepartLocatario.Text = locatario.pDepto;
                        lblMailLocatario.Text = locatario.pMail;
                        cboBarrioLocatario.SelectedValue = locatario.pBarrio;
                        cboCiudadLocatario.SelectedValue = locatario.pciudad;
                        cboDeptoLocatario.SelectedValue = locatario.pdepartamento;
                        cboProvinciaLocatario.SelectedValue = locatario.pProvincia;
                    }
                    else
                    {
                        DialogResult opcion = MessageBox.Show("El registro no existe. ¿Desea cargar un nuevo Locatario/a?", "¿Nuevo Locatario/a?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (opcion == DialogResult.Yes)
                        {
                            c = new Clientes();
                            c.locatario = true;
                            c.habilitarCamposCliente();
                            c.nuevoCliente(Convert.ToInt32(cboTipoLocatario.SelectedValue), txtDNILocatario.Text);

                            AddOwnedForm(c);
                            c.TopLevel = false;
                            c.Dock = DockStyle.Fill;
                            this.Controls.Add(c);
                            this.Tag = c;

                            c.BringToFront();
                            c.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void btnEditarLocatario_Click(object sender, EventArgs e)
        {
            if (txtDNILocatario.Text != "" && cboTipoLocatario.SelectedIndex != -1)
            {
                c = new Clientes();
                c.locatario = true;
                c.habilitarCamposCliente();


                AddOwnedForm(c);
                c.TopLevel = false;
                c.Dock = DockStyle.Fill;
                this.Controls.Add(c);
                this.Tag = c;

                c.BringToFront();
                c.Show();
                c.editarCliente(locatario);
            }
        }


        //BOTONES GARANTES
        private void cboTipoGarante_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarCamposGarante();
        }

        private void btnBuscarGarante_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDNIGarante.Text != "" && cboTipoGarante.SelectedIndex != -1)
                {
                    if (cl.VerificarPersona(Convert.ToInt32(cboTipoGarante.SelectedValue), Convert.ToInt32(txtDNIGarante.Text)) > 0)
                    {
                        garante = cl.BuscarPersona(Convert.ToInt32(cboTipoGarante.SelectedValue), Convert.ToInt32(txtDNIGarante.Text));
                        garante.pTelefono = cl.buscarTelefonos(Convert.ToInt32(cboTipoGarante.SelectedValue), Convert.ToInt32(txtDNIGarante.Text));

                        lblApeGarante.Text = garante.pApellido;
                        lblNomGarante.Text = garante.pNombre;
                        lblDirGarante.Text = garante.pDireccion;
                        lblNumGarante.Text = Convert.ToString(garante.pAltura);
                        if (garante.pTelefono.Count > 0)
                        {
                            foreach (var item in garante.pTelefono)
                            {
                                lblCodArGarante.Text = Convert.ToString(item.pcodigoArea);
                                lblTelGarante.Text = Convert.ToString(item.pnumero);
                                break;
                            }
                        }
                        lblPisoGarante.Text = Convert.ToString(garante.pPiso);
                        lblDeptoGarante.Text = garante.pDepto;
                        lblMailGarante.Text = garante.pMail;
                        cboBarrioGarante.SelectedValue = garante.pBarrio;
                        cboCiudadGarante.SelectedValue = garante.pciudad;
                        cboDeptoGarante.SelectedValue = garante.pdepartamento;
                        cboProvinciaGarante.SelectedValue = garante.pProvincia;
                    }
                    else
                    {
                        DialogResult opcion = MessageBox.Show("El registro no existe. ¿Desea cargar un nuevo garante?", "¿Nuevo garante?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (opcion == DialogResult.Yes)
                        {
                            c = new Clientes();
                            c.garante = true;
                            c.habilitarCamposCliente();
                            c.nuevoCliente(Convert.ToInt32(cboTipoGarante.SelectedValue), txtDNIGarante.Text);

                            AddOwnedForm(c);
                            c.TopLevel = false;
                            c.Dock = DockStyle.Fill;
                            this.Controls.Add(c);
                            this.Tag = c;

                            c.BringToFront();
                            c.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void btnEditarGarante_Click(object sender, EventArgs e)
        {
            if (txtDNIGarante .Text != "" && cboTipoGarante.SelectedIndex != -1)
            {
                c = new Clientes();
                c.garante = true;
                c.habilitarCamposCliente();


                AddOwnedForm(c);
                c.TopLevel = false;
                c.Dock = DockStyle.Fill;
                this.Controls.Add(c);
                this.Tag = c;

                c.BringToFront();
                c.Show();
                c.editarCliente(garante);
            }
        }

        private void btnCargarGarante_Click(object sender, EventArgs e)
        {
            if (lblApeGarante.Text != "" && lblNomGarante.Text != "" && txtDNIGarante.Text != "" && cboTipoGarante.SelectedIndex != -1)
            {
                listaGarantes.Add(garante);
                dgvGarantes.Rows.Add(garante.pApellido, garante.pNombre);
                limpiarCamposGarante();
                txtDNIGarante.Text = "";
                cboTipoGarante.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Los campos DNI, Tipo de DNI, Apellido y Nombre son obligatorios");
            }
        }

        private void btnQuitarGarante_Click(object sender, EventArgs e)
        {
            if(dgvGarantes.CurrentRow != null && dgvGarantes.SelectedRows.Count > 0)
            {
                foreach (var item in listaGarantes) //Primero borramos el registro de la lista
                {
                    if (dgvGarantes.CurrentRow.Cells[1].Value.ToString() == item.pApellido && dgvGarantes.CurrentRow.Cells[2].Value.ToString() == item.pNombre)
                    {
                        listaGarantes.Remove(new Persona() { pDNI = item.pDNI, pTipoDNI = item.pTipoDNI, pApellido = item.pApellido, pNombre = item.pNombre,
                                                             pTelefono = item.pTelefono, pDireccion = item.pDireccion, pAltura = item.pAltura, pPiso = item.pPiso,
                                                             pDepto = item.pDepto, pMail = item.pMail, pBarrio = item.pBarrio, pciudad = item.pciudad, pdepartamento = item.pdepartamento,
                                                             pProvincia = item.pProvincia});
                    }
                }
                dgvGarantes.Rows.Remove(dgvGarantes.CurrentRow);//Después eliminamos la fila en el DGV
            }
        }


        //CARGAR CAMPOS DESDE CLIENTES (NUEVO CLIENTE / ACTUALIZAR)
        public void cargarCamposLocador(Persona p)
        {
            locador = null;
            locador = p;
            txtDNILocador.Text = Convert.ToString(p.pDNI);
            cboTipo.SelectedValue = p.pTipoDNI;
            lblApellidoLocador.Text = p.pApellido;
            lblNombreLocador.Text = p.pNombre;
            lblDirLocador.Text = p.pDireccion + " n°" + p.pAltura;
            tc.traerCombo(cboBarrioLocador, "Barrios", "id_barrio", "nombreBarr", "id_barrio", p.pBarrio);
        }

        public void cargarCamposLocatario(Persona p)
        {
            locatario = p;
            txtDNILocatario.Text = Convert.ToString(p.pDNI);
            cboTipoLocatario.SelectedValue = p.pTipoDNI;
            lblApeLocatario.Text = p.pApellido;
            lblNomLocatario.Text = p.pNombre;

            if (p.pTelefono.Count > 0)
                foreach (var item in p.pTelefono)
                {
                    lblCodArLocatario.Text = Convert.ToString(item.pcodigoArea);
                    lblTelLocatario.Text = Convert.ToString(item.pnumero);
                    break;
                }

            lblDirLocatario.Text = Convert.ToString(p.pDireccion);
            lblNumLocatario.Text = Convert.ToString(p.pAltura);
            lblPisoLocatario.Text = Convert.ToString(p.pPiso);
            lblDepartLocatario.Text = p.pDepto;
            lblMailLocatario.Text = p.pMail;

            ubicacion = tc.buscarUbicacion(p.pBarrio);

            for (int i = 0; i < ubicacion.Length; i++)
            {
                if (i == 0)
                    cboProvinciaLocatario.SelectedValue = ubicacion[3];
                else if (i == 1)
                    cboDeptoLocatario.SelectedValue = ubicacion[2];
                else if (i == 2)
                    cboCiudadLocatario.SelectedValue = ubicacion[1];
                else if (i == 3)
                    cboCiudadLocatario.SelectedValue = ubicacion[0];
            }
        }

        public void cargarCamposGarante(Persona p)
        {
            garante = p;
            txtDNIGarante.Text = Convert.ToString(p.pDNI);
            cboTipoGarante.SelectedValue = p.pTipoDNI;
            lblApeGarante.Text = p.pApellido;
            lblNomGarante.Text = p.pNombre;

            if (p.pTelefono.Count > 0)
                foreach (var item in p.pTelefono)
                {
                    lblCodArGarante.Text = Convert.ToString(item.pcodigoArea);
                    lblNumGarante.Text = Convert.ToString(item.pnumero);
                    break;
                }
            lblDirGarante.Text = p.pDireccion;
            lblNumGarante.Text = Convert.ToString(p.pAltura);
            lblPisoGarante.Text = Convert.ToString(p.pPiso);
            lblDeptoGarante.Text = p.pDepto;
            lblMailGarante.Text = p.pMail;

            ubicacion = tc.buscarUbicacion(p.pBarrio);

            for (int i = 0; i < ubicacion.Length; i++)
            {
                if (i == 0)
                    cboProvinciaGarante.SelectedValue = ubicacion[3];
                else if (i == 1)
                    cboDeptoGarante.SelectedValue = ubicacion[2];
                else if (i == 2)
                    cboCiudadGarante.SelectedValue = ubicacion[1];
                else if (i == 3)
                    cboBarrioGarante.SelectedValue = ubicacion[0];
            }
        }


        //CONFIGURACIONES

        //CARGA INICIAL
        private void cargaInicial()
        {
            tc.traerCombo(cboTipo, "TiposDNI", "id_DNI", "tipoDNI", "", -1);

            btnIngresarPropiedad.Enabled = false;

            tc.traerCombo(cboTipoLocatario, "TiposDNI", "id_DNI", "tipoDNI", "", -1);
            tc.traerCombo(cboProvinciaLocatario, "Provincias", "id_provincia", "nombre", "", -1);
            cboProvinciaLocatario.SelectedValue = 14;
            tc.traerCombo(cboDeptoLocatario, "Departamentos", "id_departamento", "nombreDpto", "", -1);
            cboDeptoLocatario.SelectedValue = 14021;
            tc.traerCombo(cboCiudadLocatario, "Ciudades", "id_ciudad", "nombreCiu", "", -1);
            cboCiudadLocatario.SelectedIndex = -1;
            tc.traerCombo(cboBarrioLocatario, "Barrios", "id_barrio", "nombreBarr", "", -1);
            cboBarrioLocatario.SelectedIndex = -1;

            tc.traerCombo(cboTipoGarante, "TiposDNI", "id_DNI", "tipoDNI", "", -1);
            tc.traerCombo(cboProvinciaGarante, "Provincias", "id_provincia", "nombre", "", -1);
            cboProvinciaGarante.SelectedValue = 14;
            tc.traerCombo(cboDeptoGarante, "Departamentos", "id_departamento", "nombreDpto", "", -1);
            cboDeptoGarante.SelectedValue = 14021;
            tc.traerCombo(cboCiudadGarante, "Ciudades", "id_ciudad", "nombreCiu", "", -1);
            cboCiudadGarante.SelectedIndex = -1;
            tc.traerCombo(cboBarrioGarante, "Barrios", "id_barrio", "nombreBarr", "", -1);
            cboBarrioGarante.SelectedIndex = -1;

            tc.traerCombo(cboUsoPropiedad, "UsoPropiedad", "id_Uso", "descripcion", "", -1);

            cboTipo.SelectedIndex = -1;
            cboTipoGarante.SelectedIndex = -1;
            cboTipoLocatario.SelectedIndex = -1;

            ConfiguracionDgvPropiedades();
            ConfiguracionDgvGarantes();
        }

        //DATAGRIDVIEW PROPIEDADES
        private void ConfiguracionDgvPropiedades()
        {
            var dgv = dgvPropiedades;
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
            dgvPropiedades.Columns.Add("idPropiedad", "idPropiedad");
            dgvPropiedades.Columns[0].Visible = false;
            dgvPropiedades.Columns.Add("Dirección", "Dirección:");
            dgvPropiedades.Columns.Add("Altura", "Altura:");

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

        //DATAGRIDVIEW GARANTES
        private void ConfiguracionDgvGarantes()
        {
            var dgv = dgvGarantes;
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

            //dgv.Columns.Add("dni", "DNI:");
            //dgv.Columns[0].Visible = false;

            //dgv.Columns.Add("tipo", "TIPO:");
            //dgv.Columns[1].Visible = false;

            dgv.Columns.Add("apellido", "Apellido:");
            dgv.Columns.Add("nombre", "Nombre:");
            //dgv.Columns.Add("cod area", "Cód. Área:");
            //dgv.Columns[4].Visible = false;
            //dgv.Columns.Add("telefono", "Teléfono:");
            //dgv.Columns[5].Visible = false;

            //dgv.Columns.Add("direccion", "Direccion:");
            //dgv.Columns[6].Visible = false;

            //dgv.Columns.Add("numero", "Número:");
            //dgv.Columns[7].Visible = false;

            //dgv.Columns.Add("ciudad", "Ciudad:");
            //dgv.Columns[8].Visible = false;

            //dgv.Columns.Add("provincia", "Provincia:");
            //dgv.Columns[9].Visible = false;

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
        private void limpiarCamposLocador()
        {
            lblApellidoLocador.Text = "";
            lblNombreLocador.Text = "";
            lblDirLocador.Text = "";
            cboBarrioLocador.SelectedIndex = -1;
        }

        private void limpiarCamposLocatario()
        {
            lblApeLocatario.Text = "";
            lblNomLocatario.Text = "";
            lblCodArLocatario.Text = "";
            lblTelLocatario.Text = "";
            lblDirLocatario.Text = "";
            lblNumLocatario.Text = "";
            lblPisoLocatario.Text = "";
            lblDepartLocatario.Text = "";
            lblMailLocatario.Text = "";
            cboBarrioLocatario.SelectedIndex = -1;
            cboCiudadLocatario.SelectedIndex = -1;
            cboDeptoLocatario.SelectedIndex = -1;
            cboProvinciaLocatario.SelectedIndex = -1;
        }

        private void limpiarCamposGarante()
        {
            lblApeGarante.Text = "";
            lblNomGarante.Text = "";
            lblCodArGarante.Text = "";
            lblTelGarante.Text = "";
            lblDirGarante.Text = "";
            lblNumGarante.Text = "";
            lblPisoGarante.Text = "";
            lblDeptoGarante.Text = "";
            lblMailGarante.Text = "";
            cboBarrioGarante.SelectedIndex = -1;
            cboCiudadGarante.SelectedIndex = -1;
            cboDeptoGarante.SelectedIndex = -1;
            cboProvinciaGarante.SelectedIndex = -1;
        }
       
    }
}
