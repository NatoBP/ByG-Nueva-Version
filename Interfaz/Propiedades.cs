using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using AccesoDatos.Clases;

namespace Interfaz
{
    public partial class Propiedades : Form
    {
        TransaccionAD tc = new TransaccionAD();
        PropiedadAD pAd = new PropiedadAD();

        Propiedad p = new Propiedad();

        List<LocadorDTO> lista = new List<LocadorDTO>();
        List<CaracteristicaPropiedad> caracteristicasP = new List<CaracteristicaPropiedad>();

        Int32 contadorFoto = 0;
        int[] ubicacion = new int[4];

        public Propiedades()
        {
            InitializeComponent();
            ConfiguracionDgvPropiedades();
            ConfiguracionDgvCaracteristicas();
            cargaInicial();
            cargarPropiedades();
            deshabilitarCampos();
        }


        //BOTONES

        private void btnBuscarLoc_Click(object sender, EventArgs e)
        {
            lista = null;
            lista = pAd.BuscarPropiedadPorNombreDireccion(txtApellido.Text, txtDireccion.Text);
            dgvPropiedades.Rows.Clear();
            foreach (var item in lista)
            {
                dgvPropiedades.Rows.Add(item.Id, item.Dni, item.TipoDni, item.Apellido, item.Nombre, item.Calle, item.Nro, item.Piso, 
                                        item.Depto, item.Descripcion, item.TipoPropiedad, item.IdBarrio, item.Barrio, item.Ciudad, item.Departamento, item.Provincia);
            }
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            habilitarCampos();
        }

        private void btnVerFotos_Click(object sender, EventArgs e)
        {
            //VisorDeFotos vf = new VisorDeFotos(Convert.ToInt32(dgvPropiedades.CurrentRow.Cells[0].Value));
            //if (vf.noHayFotos() == 0)
            //    return;
            //else
            //    vf.ShowDialog();
        }

        private void btnAgregarCaracteristica_Click(object sender, EventArgs e)
        {
            if (txtOtros.Text != "" && txtOtros.Text != "0")
            {
                if (!existeEnDGV(Convert.ToInt32(cboCaracteristicas.SelectedValue)))
                {
                    CaracteristicaPropiedad cP = new CaracteristicaPropiedad(Convert.ToInt32(cboCaracteristicas.SelectedValue), 
                                                                               cboCaracteristicas.Text, Convert.ToInt32(txtOtros.Text));

                    p.agregarCaracteristica(cP);

                    cargarDGV();

                    txtOtros.Clear();
                    cboCaracteristicas.Focus();
                }

            }
            else
                MessageBox.Show("Verifique los datos ingresados");
        }

        private void btnQuitarCaracteristica_Click(object sender, EventArgs e)
        {
            if(p.Caracteristicas.Count >= 1)
            {
                int a = dgvCaracteristicas.CurrentRow.Index;
                p.Caracteristicas.RemoveAt(Convert.ToInt32(a));
                dgvCaracteristicas.Rows.Remove(dgvCaracteristicas.CurrentRow);
            }
            cargarDGV();
            cboCaracteristicas.Focus();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Archivos de imagen(*.BMP;*.JPG;*PNG)|*.BMP;*.JPG;*.PNG";
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); //directorio Mis Imágenes
                ofd.Title = "Seleccionar imagen";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK) //VALIDACIÓN DE ACEPTAR EN VENTANA EMERGENTE
                {
                    if (lstNombreImagen.Items.Count > 0) //VALIDACIÓN DE ELEMENTOS EN LISTA
                    {
                        for (int i = 0; i < ofd.FileNames.Length; i++)
                        {

                            lstNombreImagen.Items.Add(ofd.SafeFileNames[i].ToString());
                            string descripcion = ofd.SafeFileNames[i].ToString();

                            pctImagen.Image = Image.FromFile(ofd.FileNames[i].ToString());
                            MemoryStream ms = new MemoryStream();
                            pctImagen.Image.Save(ms, ImageFormat.Jpeg);
                            byte[] miByte = ms.ToArray();

                            Foto f = new Foto(contadorFoto, descripcion, miByte);
                            p.agregarFotos(f);
                            contadorFoto++;
                        }

                        lstNombreImagen.SelectedIndex = lstNombreImagen.Items.Count - 1;
                    }
                    else
                    {

                        for (int i = 0; i < ofd.FileNames.Length; i++)
                        {

                            lstNombreImagen.Items.Add(ofd.SafeFileNames[i].ToString());
                            string descripcion = ofd.SafeFileNames[i].ToString();

                            pctImagen.Image = Image.FromFile(ofd.FileNames[i].ToString());
                            MemoryStream ms = new MemoryStream();
                            pctImagen.Image.Save(ms, ImageFormat.Jpeg);
                            byte[] miByte = ms.ToArray();

                            Foto f = new Foto(contadorFoto, descripcion, miByte);
                            p.agregarFotos(f);
                            contadorFoto++;
                        }
                        lstNombreImagen.SelectedIndex = lstNombreImagen.Items.Count - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido: \n" + ex.Message);
            }
        }

        private void btnBorrarImagen_Click(object sender, EventArgs e)
        {
            if (lstNombreImagen.SelectedIndex >= 0)
            {
                foreach (var item in p.ListaFotos)
                {
                    if (lstNombreImagen.SelectedItem.Equals(item.pDescripcion))
                    {
                        //ELIMINA LA FOTO DE LA LISTA
                        p.ListaFotos.Remove(new Foto() { pIdPropiedad = item.pIdPropiedad, pFotoBinaria = item.pFotoBinaria, pDescripcion = item.pDescripcion });
                        lstNombreImagen.Items.Remove(lstNombreImagen.SelectedItem);
                        pctImagen.Image = null;
                        break;
                    }
                }
            }
        }

        //Muestra las fotos al seleccionar
        private void lstNombreImagen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNombreImagen.SelectedIndex >= 0)
            {
                foreach (var item in p.ListaFotos)
                {
                    if (lstNombreImagen.SelectedItem.Equals(item.pDescripcion))
                    {
                        MemoryStream ms = new MemoryStream(item.pFotoBinaria);
                        pctImagen.Image = Image.FromStream(ms);
                        break;
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int ultimaPropiedad = 0;
            var dgv = dgvPropiedades;

            if (validarCamposPropiedad())
            {
                p = null;

                p.pDni = Convert.ToInt32(dgv.CurrentRow.Cells[1].Value);
                p.pTipoDNI = Convert.ToInt32(dgv.CurrentRow.Cells[2].Value);
                p.pCalle = txtDireccionProp.Text;
                p.pNumeroCalle = Convert.ToInt32(txtNro.Text);
                p.pBarrio = Convert.ToInt32(cboBarrio.SelectedValue);
                p.pCiudad = Convert.ToInt32(cboCiudad.SelectedValue);
                p.pDepartamento = Convert.ToInt32(cboDepto.SelectedValue);
                p.pProvincia = Convert.ToInt32(cboProvincia.SelectedValue);
                p.pDescripcion = rtxtObservaciones.Text;

                p.TipoPropiedad = Convert.ToInt32(cboTipoProp.SelectedValue);
                if (p.TipoPropiedad == 2)
                {
                    p.pPiso = Convert.ToInt32(txtPiso.Text);
                    p.pDpto = txtDpto.Text;
                }
                else
                {
                    p.pPiso = 0;
                    p.pDpto = "";
                }

                pAd.InsertarPropiedad(p);

                p.agregarCaracteristica(new CaracteristicaPropiedad(1, Convert.ToInt32(txtSupCub.Text)));

                p.agregarCaracteristica(new CaracteristicaPropiedad(2, Convert.ToInt32(txtHabitaciones.Text)));

                p.agregarCaracteristica(new CaracteristicaPropiedad(3, Convert.ToInt32(txtLivingComedor.Text)));

                p.agregarCaracteristica(new CaracteristicaPropiedad(4, Convert.ToInt32(txtCocina.Text)));

                p.agregarCaracteristica(new CaracteristicaPropiedad(5, Convert.ToInt32(txtBaño.Text)));

                p.agregarCaracteristica(new CaracteristicaPropiedad(6, Convert.ToInt32(txtPatio.Text)));

                //////////////////////////////////////////////////////////////////
                //VER MANERA DE INGRESAR NUEVA PROPIEDAD Y QUE APAREZCAN CAMPOS DNI, TIPO Y NOMBRE, O ACTUALIZAR


                //foreach (var item in p.Caracteristicas) //Refuncionalizar para que funcione la lista de la Clase Propiedad como en las Fotos
                //{
                //    int caract = Convert.ToInt32(dgv.CurrentRow.Cells[0]);
                //    ad.consultaID("Select id_Propiedad from Propiedades ");

                //    int valor = Convert.ToInt32(item.Valor);

                //    comando = "EXEC CargarCaracteristicas @idCaracteristic = " + caract + ", " +
                //        "@idPropiedad = " + ultimaPropiedad + ", @valor = " + valor;
                //    ad.actualizarBD(comando);
                //}
                ////INSERTA LAS FOTOS UNA POR UNA
                //if (p.ListaFotos != null)
                //{
                //    foreach (var item in p.ListaFotos)
                //    {
                //        ad.guardarFoto(item.FotoBinaria, ultimaPropiedad);
                //    }

                //    p.ListaFotos.Clear();
                //}
                //registroGuardado();
                //// tblInmo.SelectedIndex = 0;
                //// btnIngresarPropiedad.Enabled = true;
                //caracPorProp.Clear(); //Se limpia la lista de características
                //LisPropiedades.Clear();
                //limpiarCamposPropiedad();
                ////deshabilitarCamposPropiedad();
            }
        }


        //MÉTODOS DE CARGA DE DATOS

        private void cargarPropiedades()
        {
            lista = null;
            lista = pAd.BuscarPropiedadPorNombreDireccion("","");
            dgvPropiedades.Rows.Clear();
            foreach (var item in lista)
            {
                dgvPropiedades.Rows.Add(item.Id, item.Dni, item.TipoDni, item.Apellido, item.Nombre, item.Calle, item.Nro, item.Piso, 
                                        item.Depto, item.Descripcion, item.TipoPropiedad, item.IdBarrio , item.Barrio, item.Ciudad, item.Departamento, item.Provincia);
            }
        }
        
        private void cargaInicial()
        {
            tc.traerCombo(cboTipoProp, "TipoPropiedades", "id_tipoPropiedad", "descripcion", "", -1);
            tc.traerCombo(cboCaracteristicas, "Caracteristicas", "idCaracteristicas", "descripcion", "idCaracteristicas >", 6);
            tc.traerCombo(cboProvincia, "Provincias", "id_provincia", "nombre", "", -1);
            tc.traerCombo(cboDepto, "Departamentos", "id_departamento", "nombreDpto", "", -1);
            tc.traerCombo(cboCiudad, "Ciudades", "id_ciudad", "nombreCiu", "", -1);
            tc.traerCombo(cboBarrio, "Barrios", "id_barrio", "nombreBarr", "", -1);
           
            cboProvincia.SelectedValue = 14;
            cboDepto.SelectedValue = 14021;
        }


        //CONFIGURACIONES DATAGRID VIEW

            //DGV PROPIEDADES

        private void seleccion()
        {
            if (dgvPropiedades.Rows.Count > 0 && dgvPropiedades.CurrentRow != null)
            {

                foreach (var item in lista)
                {
                    if(item.Id == Convert.ToInt32(dgvPropiedades.CurrentRow.Cells[0].Value))
                    {
                        txtDireccionProp.Text = item.Calle;
                        txtNro.Text = item.Nro.ToString();
                        txtDpto.Text = item.Depto.ToString();

                        if (item.Piso == 0)
                            txtPiso.Text = "";
                        else
                            txtPiso.Text = item.Piso.ToString();

                        cboTipoProp.SelectedValue = item.TipoPropiedad;

                        ubicacion = tc.buscarUbicacion(Convert.ToInt32(dgvPropiedades.CurrentRow.Cells[11].Value));
               
                        for (int i = 0; i < ubicacion.Length; i++)
                        {
                            if (i == 0)
                                cboProvincia.SelectedValue = ubicacion[3];
                            else if (i == 1)
                                cboDepto.SelectedValue = ubicacion[2];
                            else if (i == 2)
                                cboCiudad.SelectedValue = ubicacion[1];
                            else if (i == 3)
                                cboBarrio.SelectedValue = ubicacion[0];
                        }
                        rtxtObservaciones.Text = item.Descripcion;
                    }
                }

                caracteristicasP = pAd.CargarCaracteristicas(Convert.ToInt32(dgvPropiedades.CurrentRow.Cells[0].Value));

                dgvCaracteristicas.Rows.Clear();
                foreach (var i in caracteristicasP)
                {

                    switch (i.pId)
                    {
                        case 1:
                            txtSupCub.Text = Convert.ToString(i.pValor);
                            break;
                        case 2:
                            txtHabitaciones.Text = Convert.ToString(i.pValor);
                            break;
                        case 3:
                            txtLivingComedor.Text = Convert.ToString(i.pValor);
                            break;
                        case 4:
                            txtCocina.Text = Convert.ToString(i.pValor);
                            break;
                        case 5:
                            txtBaño.Text = Convert.ToString(i.pValor);
                            break;
                        case 6:
                            txtPatio.Text = Convert.ToString(i.pValor);
                            break;
                        default:
                            dgvCaracteristicas.Rows.Add(i.pCaracteristica, i.pValor);
                            break;
                    }
                }
                btnVerFotos.Enabled = true;
            }
        }

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
            dgv.Columns.Add("idPropiedad", "idPropiedad");
            dgv.Columns[0].Visible = false;
            dgv.Columns.Add("DNI", "D.N.I.:");
            dgv.Columns[1].Visible = false;
            dgv.Columns.Add("Tipo DNI", "Tipo D.N.I.:");
            dgv.Columns[2].Visible = false;

            dgv.Columns.Add("Apellido", "Apellido:");
            dgv.Columns.Add("Nombre", "Nombre:");
            dgv.Columns.Add("Calle", "Calle:");
            dgv.Columns.Add("Numero", "Número:");

            dgv.Columns.Add("Piso", "Piso:");
            dgv.Columns[7].Visible = false;
            dgv.Columns.Add("Depto", "Depto.:");
            dgv.Columns[8].Visible = false;
            dgv.Columns.Add("Descripcion", "Descripción:");
            dgv.Columns[9].Visible = false;
            dgv.Columns.Add("Tipo", "Tipo:");
            dgv.Columns[10].Visible = false;
            dgv.Columns.Add("idBarrio", "IdBarrio:");
            dgv.Columns[11].Visible = false;

            dgv.Columns.Add("Barrio", "Barrio:");
            dgv.Columns.Add("Ciudad", "Ciudad:");

            dgv.Columns.Add("Departamento", "Departamento:");
            dgv.Columns[14].Visible = false;
            dgv.Columns.Add("Provincia", "Provincia:");
            dgv.Columns[15].Visible = false;

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

        private void dgvPropiedades_Click(object sender, EventArgs e)
        {
            seleccion();
        }

        private void dgvPropiedades_SelectionChanged(object sender, EventArgs e)
        {
            seleccion();
            if (txtDireccion.Enabled == true)
            {
                deshabilitarCampos();
                limpiarCampos();
            }
        }

            //DGV CARACTERÍSTICAS

        private void ConfiguracionDgvCaracteristicas()
        {
            var dgv = dgvCaracteristicas;
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

            dgv.Columns.Add("id", "ID:");
            dgv.Columns[0].Visible = false;

            dgv.Columns.Add("caracteristica", "Item:");


            dgv.Columns.Add("Descripcion", "Descripcion:");
            dgv.Columns[2].Visible = false;

            dgv.Columns.Add("Cantidad", "Cantidad:");

            dgv.Columns.Add("importe", "Importe:");
            dgv.Columns[4].Visible = false;


            dgv.AutoResizeColumns();

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

        public bool existeEnDGV(int id)
        {
            for (int fila = 0; fila < dgvCaracteristicas.Rows.Count; fila++)
            {
                if (Convert.ToInt32(dgvCaracteristicas.Rows[fila].Cells[0].Value) == id)
                {
                    return true;
                }
            }
            return false;
        }

        private void cargarDGV()
        {
            dgvCaracteristicas.Rows.Clear();

            if (p.Caracteristicas.Count != 0)

                foreach (var item in p.Caracteristicas)
                {
                    dgvCaracteristicas.Rows.Add(item.pId, item.pCaracteristica, item.pDescripcion, item.pValor, item.pImporte);
                }
            btnQuitarCaracteristica.Enabled = true;
        }


        //VALIDACIONES / LIMPIEZAS / HABILITAR / DESHABILITAR

        private bool validarCamposPropiedad()
        {
            bool validar = true;

            if (txtPiso.Text.Equals(""))
                txtPiso.Text = "0";
            if (txtDpto.Text.Equals(""))
                txtDpto.Text = "0";

            foreach (Control c in grpPropiedad.Controls)
            {
                if (c is TextBox && c.Text.Equals(""))
                {
                    validar = false;
                    break;
                }
                else if (c is ComboBox && c.Text.Equals(""))
                {
                    validar = false;
                    break;
                }
            }

            foreach (Control c in grpCaracteristicas.Controls)
            {
                if (c is TextBox && c.Text.Equals(""))
                {
                    c.Text = "0";

                }
                else if (c is ComboBox && c.Text.Equals(""))
                {
                    c.Text = "";
                }
            }
            if (validar == false)
            {
                MessageBox.Show("Sólo las Características pueden estar vacías");
            }
            return validar;
        }

        private void deshabilitarCampos()
        {
            foreach (Control c in grpPropiedad.Controls)
            {
                if (c is TextBox)
                    c.Enabled = false;

                else if (c is ComboBox)
                    c.Enabled = false;
            }
            foreach (Control c in grpCaracteristicas.Controls)
            {
                if (c is TextBox)
                    c.Enabled = false;

                else if (c is ComboBox)
                    c.Enabled = false;

                else if (c is Button)
                    c.Enabled = false;
            }
        }

        private void habilitarCampos()
        {
            foreach (Control c in grpPropiedad.Controls)
            {
                if (c is TextBox)
                    c.Enabled = true;

                else if (c is ComboBox)
                    c.Enabled = true;
            }
            foreach (Control c in grpCaracteristicas.Controls)
            {
                if (c is TextBox)
                    c.Enabled = true;

                else if (c is ComboBox)
                    c.Enabled = true;

                else if (c is Button)
                    c.Enabled = true;
            }
        }

        private void limpiarCampos()
        {
            foreach (Control item in grpCaracteristicas.Controls)
            {
                if (item is TextBox)
                    item.Text = "";
            }
            foreach (Control item in grpPropiedad.Controls)
            {
                if (item is TextBox)
                    item.Text = "";
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

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDireccionProp_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNro_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDpto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSupCub_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHabitaciones_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtLivingComedor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCocina_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBaño_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPatio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtOtros_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
