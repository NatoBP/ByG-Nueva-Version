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
//using Word = Microsoft.Office.Interop.Word;



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
        Contrato ct = new Contrato();
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

        //BOTONES 
                //Locador
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
                            c.nuevoCliente(Convert.ToInt32(cboTipo.SelectedValue), txtDNILocador.Text, "");
                            //abrirVentana(c);
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
                c.editarCliente(locador);
                abrirVentana<Clientes>(c);
            }
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
                limpiarCamposLocador();
        }

        private void btnIngresarPropiedad_Click(object sender, EventArgs e)
        {
            if (txtDNILocador.Text != "" && cboTipo.SelectedIndex != -1)
            {
                Propiedades prop = new Propiedades();
                prop.NuevoContrato = true;
                prop.nuevaPropiedad(locador);
                abrirVentana<Propiedades>(prop);
            }
        }

               //Locatario
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
                            c.nuevoCliente(Convert.ToInt32(cboTipoLocatario.SelectedValue), txtDNILocatario.Text,"");

                            //abrirVentana(c);
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
                c.editarCliente(locatario);
                abrirVentana<Clientes>(c);
            }
        }

                //Garantes
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
                            c.nuevoCliente(Convert.ToInt32(cboTipoGarante.SelectedValue), txtDNIGarante.Text,"");

                            //abrirVentana(c);
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
                c.editarCliente(garante);

                abrirVentana<Clientes>(c);
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

                //Registrar Contrato
        private void btnRegistrarContrato_Click(object sender, EventArgs e)
        {
            if (ValidarPestanaContrato())
            {
                try
                {
                    ////LOCATARIO
                    //Persona i = new Inquilino();
                    //i.pDNI = Convert.ToInt32(txtDNIInquilino.Text);
                    //i.pTipoDNI = Convert.ToInt32(cboTipoLocatario.SelectedValue);
                    //i.pApellido = lblApeLocatario.Text;
                    //i.pNombre = lblNomLocatario.Text;
                    //i.pDireccion = lblDirLocatario.Text;
                    //i.pAltura = Convert.ToInt32(lblNumLocatario.Text);
                    //if (lblPisoLocatario.Text == "")
                    //{
                    //    i.pPiso = 0;
                    //}
                    //else
                    //{
                    //    i.pPiso = Convert.ToInt32(lblPisoLocatario.Text);
                    //}

                    //i.pDepto = lblDepartLocatario.Text;
                    //i.pMail = lblMailLocatario.Text;
                    //i.pBarrio = Convert.ToInt32(cboBarrioLocatario.SelectedValue);
                    //i.pciudad = Convert.ToInt32(cboCiudadLocatario.SelectedValue);
                    //i.pdepartamento = Convert.ToInt32(cboDeptoLocatario.SelectedValue);
                    //i.pProvincia = Convert.ToInt32(cboProvinciaLocatario.SelectedValue);

                    //Telefono t = new Telefono();
                    //t.pcodigoArea = lblCodArLocatario.Text;
                    //t.pnumero = lblTelLocatario.Text;
                    //i.agregarTelefono(t);


                    //c.IdPropiedad = Convert.ToInt32(dgvPropiedades.CurrentRow.Cells[0].Value);
                    //c.DniInquilino = i.pDNI;
                    //c.TipoDniInquilino = i.pTipoDNI;
                    //c.Duracion = Convert.ToInt32(txtDuracion.Text);
                    //c.PrecioAlquiler = Convert.ToDouble(txtPrecioAlquiler.Text);
                    //c.InteresDiario = Convert.ToDecimal(txtIntereses.Text);
                    //c.Deposito = Convert.ToDouble(txtDeposito.Text);
                    //c.UsoPropiedad = cboUsoPropiedad.SelectedIndex + 1;
                    //c.Vigencia = dtpFechaFin.Value;
                    //c.DiaDeVencimiento = Convert.ToInt32(txtDiaVencimiento.Text);//Agregar este campo en la tabla ContratosAlquiler de la BD
                    //c.FechaInicioContrato = dtpFechaInicio.Value; //Agregar este campo en la tabla ContratosAlquiler de la BD
                    //c.Fecha1raActualizacion = dtpActualizacion1.Value;
                    //c.Aumento1raActualizacion = Convert.ToDouble(txt1erAumento.Text);
                    //c.Fecha2daActualizacion = dtpActualizacion2.Value;
                    //c.Aumento2daActualizacion = Convert.ToDouble(txt2doAumento.Text);

                   
                    //DataSet data = new DataSet();
                    //var param = new SqlParameter[] { new SqlParameter("@idPropiedad", c.IdPropiedad),
                    //             new SqlParameter("@dniInquilino", c.DniInquilino),
                    //             new SqlParameter("@tipoDni", c.TipoDniInquilino),
                    //             new SqlParameter("@duracion", c.Duracion),
                    //             new SqlParameter("@precio", c.PrecioAlquiler),
                    //             new SqlParameter("@interesDiario", c.InteresDiario),
                    //             new SqlParameter("@deposito", c.Deposito),
                    //             new SqlParameter("@usoPropiedad", c.UsoPropiedad),
                    //             new SqlParameter("@vigencia", c.Vigencia),
                    //             new SqlParameter("@1raFecha", c.Fecha1raActualizacion),
                    //             new SqlParameter("@1erAumento", c.Aumento1raActualizacion),
                    //             new SqlParameter("@2daFecha", c.Fecha2daActualizacion),
                    //             new SqlParameter("@2doAumento", c.Aumento2daActualizacion),
                    //             new SqlParameter("@bajalogica", 1),
                    //             new SqlParameter("@fechaBaja", c.Vigencia),
                    //             new SqlParameter("@fechaInicio", c.FechaInicioContrato)};

                    //ad.ExecProcedure("insertarContrato", param, ref data);

                    //int idContrato = ad.consultaID("Select Max(id_Contrato) from ContratosAlquiler");
                    //ad.Desconectar();

                    ////GARANTES
                    //List<Persona> lista = c.devolverGarante();
                    //foreach (var item1 in lista)
                    //{
                    //    string verificarGarante = "Select Count(*) From Personas Where id_DNI = " + item1.pDNI + " AND tipoDNI = " + item1.pTipoDNI;

                    //    if (ad.Verificar(verificarGarante) > 0)
                    //    {
                    //        //ad.actualizarBD("exec insertarGarante @dni = " + item1.pDNI + ", @tipoDNI = " + item1.pTipoDNI + ", @sugerencias = '" + 0 + "', @idContrato = " + idContrato + " ");
                    //        //ad.Desconectar();
                    //        ////////////////////////////////////// CODIGO QUE ME PASARON POR STACKOVERFLOW
                    //        //SqlConnection con = null;
                    //        DataSet ds = new DataSet();
                    //        var parametros = new SqlParameter[] { new SqlParameter("@dni", item1.pDNI),
                    //             new SqlParameter("@tipoDNI", item1.pTipoDNI),
                    //             new SqlParameter("@sugerencias", "0"),
                    //             new SqlParameter("@idContrato", idContrato)};
                    //        ad.ExecProcedure("insertarGarante", parametros, ref ds);
                    //        //////////////////////////////////////////
                    //    }
                        
                    //}

                    //String direccion = dgvPropiedades.CurrentRow.Cells[1].Value.ToString() + " N°" + dgvPropiedades.CurrentRow.Cells[2].Value.ToString();

                    //DTOPropiedad tempo = ad.buscarPropiedad(Convert.ToInt32(dgvPropiedades.CurrentRow.Cells[0].Value));
                    //int indice = dgvPropiedades.CurrentRow.Index;
                    //String ciudadLocador = ad.buscarCiudad(pr.pciudad);
                    //String ciudadPropiedad = tempo.Ciudad;
                    //String pciaPropiedad = tempo.Provincia;


                    //object ObjMiss = System.Reflection.Missing.Value;
                    //Word.Application ObjWord = new Word.Application();
                    ////ruta del contrato base

                    //string ruta = @"C:\Users\felip_000\Documents\InmobiliariaBustosGuidoneFelipe\contratosLocacion\CONTRATO DE LOCACION.docx";
                    ////string directorio = @"C:\Users\Nato\Documents\GitHub\Contratos\";
                    ////C:\Users\felip_000\Documents\InmobiliariaBustosGuidoneFelipe\contratosLocacion
                    ////C:\Users\Usuario\Desktop\B&G ADMINISTRACION ALQUILERES\contratosLocacion
                    //string directorio = @"C:\Users\felip_000\Documents\InmobiliariaBustosGuidoneFelipe\contratosLocacionn\" + @"\" +
                    //    lblApellidoLocador.Text.ToUpper() + " " + lblNombreLocador.Text + " - " + direccion.ToUpper();
                    //if (!Directory.Exists(directorio))
                    //{
                    //    //Console.WriteLine("Creando el directorio: {0}", directorio);
                    //    DirectoryInfo di = Directory.CreateDirectory(directorio);
                    //}
                    ////ruta destino con el nombre elegido(datos locador, datos locatario, fecha y hora)


                    //string destFile = directorio + @"\" + idContrato + " - " + lblApellidoLocador.Text + " " + lblNombreLocador.Text + " - " + lblApeLocatario.Text
                    //                    + " " + lblNomLocatario.Text + ".docx";

                    ////// LO ORIGINAL ESTA ARRIBA
                    /////
                    ////string destFile = directorio + @"\" + 1115 + " - " + lblApellidoLocador.Text + " " + lblNombreLocador.Text + " - " + lblApeLocatario.Text
                    ////    + " " + lblNomLocatario.Text + ".docx";

                    ////+ " " +DateTime.Now.ToString("yyyyMMdd", CultureInfo.InvariantCulture) Esto iba antes de .docx
                    ////esto genera una copia del archivo con los datos del locador y locatario

                    //System.IO.File.Copy(ruta, destFile, true);


                    //object parametro = destFile;
                    //object apelLoc = "ApellidoLocador"; //Marcadores
                    //object nomLoc = "NombreLocador";
                    //object tipoLoc = "TipoDocLocador";
                    //object docLoc = "DocLocador";
                    //object ciuLoc = "CiudadLocador";
                    //object domLoc = "CalleLocador";

                    //object apelLocat = "ApellidoLocatario";
                    //object nomLocat = "NombreLocatario";
                    //object tipoLocat = "TipoDocLocatario";
                    //object docLocat = "DocLocatario";

                    //object domProp = "DomicilioPropiedad";
                    //object ciuProp = "CiudadPropiedad";
                    //object pciaProp = "ProvinciaPropiedad";
                    //object tipoProp = "TipoPropiedad";
                    //object supTerreno = "SuperficieTerreno";


                    //Word.Document ObjDoc = ObjWord.Documents.Open(parametro, ObjMiss);


                    //Word.Range ape = ObjDoc.Bookmarks.get_Item(ref apelLoc).Range;
                    //ape.Text = lblApellidoLocador.Text.ToUpper();
                    //ObjDoc.Bookmarks.Add(apelLoc.ToString(), ape);

                    //Word.Range nom = ObjDoc.Bookmarks.get_Item(ref nomLoc).Range;
                    //nom.Text = lblNombreLocador.Text;
                    //ObjDoc.Bookmarks.Add(nomLoc.ToString(), nom);

                    //Word.Range tipo = ObjDoc.Bookmarks.get_Item(ref tipoLoc).Range;
                    //tipo.Text = cboTipo.Text; //ver si no es necesario un select tipo
                    //ObjDoc.Bookmarks.Add(tipoLoc.ToString(), tipo);

                    //Word.Range doc = ObjDoc.Bookmarks.get_Item(ref docLoc).Range;
                    //doc.Text = txtDNIProp.Text;
                    //ObjDoc.Bookmarks.Add(docLoc.ToString(), doc);

                    //Word.Range ciu = ObjDoc.Bookmarks.get_Item(ref ciuLoc).Range;
                    //ciu.Text = ciudadLocador.ToUpper();
                    //ObjDoc.Bookmarks.Add(ciuLoc.ToString(), ciu);

                    //Word.Range calle = ObjDoc.Bookmarks.get_Item(ref domLoc).Range;
                    //calle.Text = lblDomLocador.Text;
                    //ObjDoc.Bookmarks.Add(domLoc.ToString(), calle);

                    //Word.Range apeI = ObjDoc.Bookmarks.get_Item(ref apelLocat).Range;
                    //apeI.Text = lblApeLocatario.Text.ToUpper();
                    //ObjDoc.Bookmarks.Add(apelLocat.ToString(), apeI);

                    //Word.Range nomI = ObjDoc.Bookmarks.get_Item(ref nomLocat).Range;
                    //nomI.Text = lblNomLocatario.Text;
                    //ObjDoc.Bookmarks.Add(nomLocat.ToString(), nomI);

                    //Word.Range tipoI = ObjDoc.Bookmarks.get_Item(ref tipoLocat).Range;
                    //tipoI.Text = cboTipoLocatario.Text;
                    //ObjDoc.Bookmarks.Add(tipoLocat.ToString(), tipoI);

                    //Word.Range docI = ObjDoc.Bookmarks.get_Item(ref docLocat).Range;
                    //docI.Text = txtDNIInquilino.Text;
                    //ObjDoc.Bookmarks.Add(docLocat.ToString(), docI);

                    //Word.Range domP = ObjDoc.Bookmarks.get_Item(ref domProp).Range;
                    //domP.Text = direccion;
                    //ObjDoc.Bookmarks.Add(domProp.ToString(), domP);

                    //Word.Range ciuP = ObjDoc.Bookmarks.get_Item(ref ciuProp).Range;
                    //ciuP.Text = ciudadPropiedad.ToUpper();
                    //ObjDoc.Bookmarks.Add(ciuProp.ToString(), ciuP);

                    //Word.Range pciaP = ObjDoc.Bookmarks.get_Item(ref pciaProp).Range;
                    //pciaP.Text = pciaPropiedad;
                    //ObjDoc.Bookmarks.Add(pciaProp.ToString(), pciaP);

                    //Word.Range tipoP = ObjDoc.Bookmarks.get_Item(ref tipoProp).Range;
                    //tipoP.Text = tempo.TipoPropiedad;
                    //ObjDoc.Bookmarks.Add(tipoProp.ToString(), tipoP);

                    //Word.Range supP = ObjDoc.Bookmarks.get_Item(ref supTerreno).Range;
                    //supP.Text = Convert.ToString(tempo.Superficie);
                    //ObjDoc.Bookmarks.Add(supTerreno.ToString(), supP);

                    //object Observ = "Observaciones";
                    //Word.Range Obs = ObjDoc.Bookmarks.get_Item(ref Observ).Range;
                    //Obs.Text = Convert.ToString(tempo.Observaciones);
                    //ObjDoc.Bookmarks.Add(Observ.ToString(), Obs);

                    //object fechaInicio = "fechaInicioAlquiler";
                    //Word.Range fInicio = ObjDoc.Bookmarks.get_Item(ref fechaInicio).Range;
                    //fInicio.Text = dtpFechaInicio.Text;
                    //ObjDoc.Bookmarks.Add(fechaInicio.ToString(), fInicio);

                    //object fechaFin = "fechaFinAlquiler";
                    //Word.Range fFin = ObjDoc.Bookmarks.get_Item(ref fechaFin).Range;
                    //fFin.Text = dtpFechaFin.Text;
                    //ObjDoc.Bookmarks.Add(fechaFin.ToString(), fFin);

                    //object moraLetras = "moraLetra";
                    //Word.Range moraD = ObjDoc.Bookmarks.get_Item(ref moraLetras).Range;
                    //moraD.Text = enLetras(txtIntereses.Text);
                    //ObjDoc.Bookmarks.Add(moraLetras.ToString(), moraD);

                    //object multaDiaria = "MoraDiaria";
                    //Word.Range multaD = ObjDoc.Bookmarks.get_Item(ref multaDiaria).Range;
                    //multaD.Text = txtIntereses.Text;
                    //ObjDoc.Bookmarks.Add(multaDiaria.ToString(), multaD);

                    //object usoProp = "usoQueLeDaran";
                    //Word.Range usoP = ObjDoc.Bookmarks.get_Item(ref usoProp).Range;
                    //usoP.Text = cboUsoPropiedad.Text;
                    //ObjDoc.Bookmarks.Add(usoProp.ToString(), usoP);

                    //object precioAlquiler = "precioAlquilerLetras";
                    //Word.Range precioAlq = ObjDoc.Bookmarks.get_Item(ref precioAlquiler).Range;
                    //precioAlq.Text = enLetras(txtPrecioAlquiler.Text);
                    //ObjDoc.Bookmarks.Add(precioAlquiler.ToString(), precioAlq);

                    //object precioAlquilerN = "precioAlquilerNros";
                    //Word.Range precioAlqN = ObjDoc.Bookmarks.get_Item(ref precioAlquilerN).Range;
                    //precioAlqN.Text = txtPrecioAlquiler.Text;
                    //ObjDoc.Bookmarks.Add(precioAlquilerN.ToString(), precioAlqN);

                    //object diaDePago = "diaDePago";
                    //Word.Range diaPago = ObjDoc.Bookmarks.get_Item(ref diaDePago).Range;
                    //diaPago.Text = txtDiaVencimiento.Text;
                    //ObjDoc.Bookmarks.Add(diaDePago.ToString(), diaPago);

                    //object diaDePagoL = "diaDePagoLetras";
                    //Word.Range diaPagoL = ObjDoc.Bookmarks.get_Item(ref diaDePagoL).Range;
                    //diaPagoL.Text = enLetras(txtDiaVencimiento.Text);
                    //ObjDoc.Bookmarks.Add(diaDePagoL.ToString(), diaPagoL);

                    //object apelG1 = "ApellidoGarante";
                    //Word.Range apeG1 = ObjDoc.Bookmarks.get_Item(ref apelG1).Range;
                    //apeG1.Text = dgvGarantes.Rows[0].Cells[2].Value.ToString();
                    //ObjDoc.Bookmarks.Add(apelG1.ToString(), apeG1);

                    //object nombreG1 = "NombreGarante";
                    //Word.Range nomG1 = ObjDoc.Bookmarks.get_Item(ref nombreG1).Range;
                    //nomG1.Text = dgvGarantes.Rows[0].Cells[3].Value.ToString();
                    //ObjDoc.Bookmarks.Add(nombreG1.ToString(), nomG1);

                    //object tipoG1 = "TipoDocGarante";
                    //Word.Range tipG1 = ObjDoc.Bookmarks.get_Item(ref tipoG1).Range;
                    //tipG1.Text = ad.buscarValor(Convert.ToInt32(dgvGarantes.Rows[0].Cells[1].Value), "id_DNI", "tipoDNI", "TiposDNI");
                    //ObjDoc.Bookmarks.Add(tipoG1.ToString(), tipG1);

                    //object docuG1 = "DocumGarante";
                    //Word.Range docG1 = ObjDoc.Bookmarks.get_Item(ref docuG1).Range;
                    //docG1.Text = dgvGarantes.Rows[0].Cells[0].Value.ToString();
                    //ObjDoc.Bookmarks.Add(docuG1.ToString(), docG1);

                    //object calleG1 = "calleGarante";
                    //Word.Range calG1 = ObjDoc.Bookmarks.get_Item(ref calleG1).Range;
                    //calG1.Text = dgvGarantes.Rows[0].Cells[6].Value.ToString() + " Nº" + dgvGarantes.Rows[0].Cells[7].Value.ToString();
                    //ObjDoc.Bookmarks.Add(calleG1.ToString(), calG1);

                    //object telefG1 = "TelGarante";
                    //Word.Range telG1 = ObjDoc.Bookmarks.get_Item(ref telefG1).Range;
                    //telG1.Text = dgvGarantes.Rows[0].Cells[4].Value.ToString() + dgvGarantes.Rows[0].Cells[5].Value.ToString(); ;
                    //ObjDoc.Bookmarks.Add(telefG1.ToString(), telG1);


                    //object pciaG1 = "PciaGarante";
                    //Word.Range provG1 = ObjDoc.Bookmarks.get_Item(ref pciaG1).Range;
                    //provG1.Text = ad.buscarValor(Convert.ToInt32(dgvGarantes.Rows[0].Cells[9].Value), "id_provincia", "nombre", "Provincias");
                    //ObjDoc.Bookmarks.Add(pciaG1.ToString(), provG1);

                    //object ciudadG1 = "CiudadGarante";
                    //Word.Range ciuG1 = ObjDoc.Bookmarks.get_Item(ref ciudadG1).Range;
                    //ciuG1.Text = ad.buscarValor(Convert.ToInt32(dgvGarantes.Rows[0].Cells[8].Value), "id_ciudad", "nombreCiu", "Ciudades");
                    //ObjDoc.Bookmarks.Add(ciudadG1.ToString(), ciuG1);


                    ////if (dgvGarantes.RowCount.ToString().Equals("2"))
                    ////{

                    //object apelG2 = "ApellidoGarante2";
                    //Word.Range apeG2 = ObjDoc.Bookmarks.get_Item(ref apelG2).Range;
                    //apeG2.Text = dgvGarantes.Rows[1].Cells[2].Value.ToString();
                    //ObjDoc.Bookmarks.Add(apelG2.ToString(), apeG2);

                    //object nombreG2 = "NombreGarante2";
                    //Word.Range nomG2 = ObjDoc.Bookmarks.get_Item(ref nombreG2).Range;
                    //nomG2.Text = dgvGarantes.Rows[1].Cells[3].Value.ToString();
                    //ObjDoc.Bookmarks.Add(nombreG2.ToString(), nomG2);

                    //object tipoG2 = "TipoDocGarante2";
                    //Word.Range tipG2 = ObjDoc.Bookmarks.get_Item(ref tipoG2).Range;
                    //tipG2.Text = ad.buscarValor(Convert.ToInt32(dgvGarantes.Rows[1].Cells[1].Value), "id_DNI", "tipoDNI", "TiposDNI");
                    //ObjDoc.Bookmarks.Add(tipoG2.ToString(), tipG2);

                    //object docuG2 = "DocumGarante2";
                    //Word.Range docG2 = ObjDoc.Bookmarks.get_Item(ref docuG2).Range;
                    //docG2.Text = dgvGarantes.Rows[1].Cells[0].Value.ToString();
                    //ObjDoc.Bookmarks.Add(docuG2.ToString(), docG2);

                    //object calleG2 = "calleGarante2";
                    //Word.Range calG2 = ObjDoc.Bookmarks.get_Item(ref calleG2).Range;
                    //calG2.Text = dgvGarantes.Rows[1].Cells[6].Value.ToString() + " Nº" + dgvGarantes.Rows[1].Cells[7].Value.ToString();
                    //ObjDoc.Bookmarks.Add(calleG2.ToString(), calG2);

                    //object telefG2 = "TelGarante2";
                    //Word.Range telG2 = ObjDoc.Bookmarks.get_Item(ref telefG2).Range;
                    //telG2.Text = dgvGarantes.Rows[1].Cells[4].Value.ToString() + dgvGarantes.Rows[1].Cells[5].Value.ToString();
                    //ObjDoc.Bookmarks.Add(telefG2.ToString(), telG2);

                    //object pciaG2 = "PciaGarante2";
                    //Word.Range provG2 = ObjDoc.Bookmarks.get_Item(ref pciaG2).Range;
                    //provG2.Text = ad.buscarValor(Convert.ToInt32(dgvGarantes.Rows[1].Cells[9].Value), "id_provincia", "nombre", "Provincias");
                    //ObjDoc.Bookmarks.Add(pciaG2.ToString(), provG2);

                    //object ciudadG2 = "CiudadGarante2";
                    //Word.Range ciuG2 = ObjDoc.Bookmarks.get_Item(ref ciudadG2).Range;
                    //ciuG2.Text = ad.buscarValor(Convert.ToInt32(dgvGarantes.Rows[1].Cells[8].Value), "id_ciudad", "nombreCiu", "Ciudades");
                    //ObjDoc.Bookmarks.Add(ciudadG2.ToString(), ciuG2);

                    //object deposLetras = "depositoLetras";
                    //Word.Range depL = ObjDoc.Bookmarks.get_Item(ref deposLetras).Range;
                    //depL.Text = enLetras(txtDeposito.Text);
                    //ObjDoc.Bookmarks.Add(deposLetras.ToString(), depL);

                    //object deposito = "DepositoNro";
                    //Word.Range depo = ObjDoc.Bookmarks.get_Item(ref deposito).Range;
                    //depo.Text = txtDeposito.Text;
                    //ObjDoc.Bookmarks.Add(deposito.ToString(), depo);

                    //object mailLoc = "mailLocataria";
                    //Word.Range mailL = ObjDoc.Bookmarks.get_Item(ref mailLoc).Range;
                    //mailL.Text = txtMail.Text;
                    //ObjDoc.Bookmarks.Add(mailLoc.ToString(), mailL);

                    //object diaCont = "diaContrato";
                    //Word.Range diaC = ObjDoc.Bookmarks.get_Item(ref diaCont).Range;
                    //diaC.Text = dtpFechaInicio.Value.Day.ToString();
                    //ObjDoc.Bookmarks.Add(diaCont.ToString(), diaC);

                    //object mesCont = "mesContrato";
                    //Word.Range mesC = ObjDoc.Bookmarks.get_Item(ref mesCont).Range;
                    //mesC.Text = dtpFechaInicio.Value.Month.ToString();
                    //ObjDoc.Bookmarks.Add(mesCont.ToString(), mesC);

                    //object anCont = "añoContrato";
                    //Word.Range anC = ObjDoc.Bookmarks.get_Item(ref anCont).Range;
                    //anC.Text = dtpFechaInicio.Value.Year.ToString();
                    //ObjDoc.Bookmarks.Add(anCont.ToString(), anC);

                    //object loca = "Locador";
                    //Word.Range loc = ObjDoc.Bookmarks.get_Item(ref loca).Range;
                    //loc.Text = ape.Text + ", " + nom.Text;
                    //ObjDoc.Bookmarks.Add(loca.ToString(), loc);

                    //object locat = "Locatario";
                    //Word.Range loct = ObjDoc.Bookmarks.get_Item(ref locat).Range;
                    //loct.Text = apeI.Text + ", " + nomI.Text;
                    //ObjDoc.Bookmarks.Add(locat.ToString(), loct);

                    //object dniloca = "DniLocador";
                    //Word.Range dnil = ObjDoc.Bookmarks.get_Item(ref dniloca).Range;
                    //dnil.Text = tipo.Text + " Nº" + doc.Text;
                    //ObjDoc.Bookmarks.Add(dniloca.ToString(), dnil);

                    //object dnilocat = "DniLocatario";
                    //Word.Range dnilt = ObjDoc.Bookmarks.get_Item(ref dnilocat).Range;
                    //dnilt.Text = tipoI.Text + " Nº" + docI.Text;
                    //ObjDoc.Bookmarks.Add(dnilocat.ToString(), dnilt);

                    //object Garan1 = "Garante1";
                    //Word.Range Gar1 = ObjDoc.Bookmarks.get_Item(ref Garan1).Range;
                    //Gar1.Text = apeG1.Text + ", " + nomG1.Text;
                    //ObjDoc.Bookmarks.Add(Garan1.ToString(), Gar1);

                    //object Garan2 = "Garante2";
                    //Word.Range Gar2 = ObjDoc.Bookmarks.get_Item(ref Garan2).Range;
                    //Gar2.Text = apeG2.Text + ", " + nomG2.Text;
                    //ObjDoc.Bookmarks.Add(Garan2.ToString(), Gar2);

                    //object dniGa1 = "DniGarante1";
                    //Word.Range dniG1 = ObjDoc.Bookmarks.get_Item(ref dniGa1).Range;
                    //dniG1.Text = tipG1.Text + " Nº" + docG1.Text;
                    //ObjDoc.Bookmarks.Add(dniGa1.ToString(), dniG1);

                    //object dniGa2 = "DniGarante2";
                    //Word.Range dniG2 = ObjDoc.Bookmarks.get_Item(ref dniGa2).Range;
                    //dniG2.Text = tipG2.Text + " Nº" + docG2.Text;
                    //ObjDoc.Bookmarks.Add(dniGa2.ToString(), dniG2);

                    //ObjWord.Visible = true; LimpiarCamposContrato();


                    //registroGuardado();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar todos los campos");
            }

        }


        //CONFIGURACIÓN ENVÍO Y RECEPCIÓN DE DATOS A OTRAS VENTANAS
                //Cargar campos desde Clientes / Propiedad 

        public void cargarCamposLocador(Persona p)
        {
            limpiarCamposLocador();
            locador = null;
            locador = p;
            txtDNILocador.Text = Convert.ToString(p.pDNI);
            cboTipo.SelectedValue = p.pTipoDNI;
            lblApellidoLocador.Text = p.pApellido;
            lblNombreLocador.Text = p.pNombre;
            lblDirLocador.Text = p.pDireccion + " n°" + p.pAltura;
            tc.traerCombo(cboBarrioLocador, "Barrios", "id_barrio", "nombreBarr", "id_barrio", p.pBarrio);
        }

        public void cargarPropiedad(Persona per)
        {
            listaProp = null;
            listaProp = p.CargarListaPropiedades(per.pDNI, per.pTipoDNI);
            foreach (var item in listaProp)
            {
                dgvPropiedades.Rows.Add(item.pId_propiedad, item.pCalle, item.pNumeroCalle);
            }
        }

        public void cargarCamposLocatario(Persona p)
        {
            limpiarCamposLocatario();
            locatario = null;
            locatario = p;
            txtDNILocatario.Text = Convert.ToString(locatario.pDNI);
            cboTipoLocatario.SelectedValue = locatario.pTipoDNI;
            lblApeLocatario.Text = locatario.pApellido;
            lblNomLocatario.Text = locatario.pNombre;

            if (locatario.pTelefono.Count > 0)
            {
                foreach (var item in locatario.pTelefono)
                {
                    lblCodArLocatario.Text = Convert.ToString(item.pcodigoArea);
                    lblTelLocatario.Text = Convert.ToString(item.pnumero);
                    break;
                }
            }

            lblDirLocatario.Text = Convert.ToString(locatario.pDireccion);
            lblNumLocatario.Text = Convert.ToString(locatario.pAltura);
            lblPisoLocatario.Text = Convert.ToString(locatario.pPiso);
            lblDepartLocatario.Text = locatario.pDepto;
            lblMailLocatario.Text = locatario.pMail;

            ubicacion = tc.buscarUbicacion(locatario.pBarrio);

            for (int i = 0; i < ubicacion.Length; i++)
            {
                if (i == 0)
                    cboProvinciaLocatario.SelectedValue = ubicacion[3];
                else if (i == 1)
                    cboDeptoLocatario.SelectedValue = ubicacion[2];
                else if (i == 2)
                    cboCiudadLocatario.SelectedValue = ubicacion[1];
                else if (i == 3)
                    cboBarrioLocatario.SelectedValue = ubicacion[0];
            }
        }

        public void cargarCamposGarante(Persona p)
        {
            limpiarCamposGarante();
            garante = null;
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

                //Abrir otras ventanas
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


        //CONFIGURACIONES
                //Carga Inicial
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

                //Dgv Propiedades
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
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Add("idPropiedad", "idPropiedad");
            dgv.Columns[0].Visible = false;
            dgv.Columns.Add("Dirección", "Dirección:");
            dgv.Columns.Add("Altura", "Altura:");

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

                //Dgv Garantes
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

            dgv.AutoGenerateColumns = false;
            dgv.Columns.Add("apellido", "Apellido:");
            dgv.Columns.Add("nombre", "Nombre:");

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

        #region VALIDACIONES Y LIMPIEZAS

        private bool ValidarPestanaContrato()
        {
            throw new NotImplementedException();
        }

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

        private void txtDNILocador_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDNILocatario_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDNIGarante_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPrecioAlquiler_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtIntereses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ',' && !txtIntereses.Text.Contains(","))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtDiaVencimiento_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDuracion_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDeposito_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt1erAumento_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt2doAumento_KeyPress(object sender, KeyPressEventArgs e)
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

        #endregion
    }
}
