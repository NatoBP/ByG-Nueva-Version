using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using AccesoDatos.Clases;
using Word = Microsoft.Office.Interop.Word;



namespace Interfaz
{
    public partial class NuevoContrato : Form
    {
        //ACCESO A DATOS
        TransaccionAD tc = new TransaccionAD();
        ClienteAD cl = new ClienteAD();
        PropiedadAD p = new PropiedadAD();
        AlquileresAD alq = new AlquileresAD();

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
                //listaGarantes.Add(garante);
                ct.agregarGarante(garante);
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
                var dgv = dgvGarantes;

                for (int i = 0; i < ct.listarGarantes.Count; i++)
                {
                    if(ct.listarGarantes[i].pApellido.Equals(dgv.CurrentRow.Cells[0].Value.ToString()) &&
                       ct.listarGarantes[i].pNombre.Equals(dgv.CurrentRow.Cells[1].Value.ToString()))
                    {
                        ct.listarGarantes.RemoveAt(i);
                        dgv.Rows.Remove(dgv.CurrentRow);
                        break;
                    }
                }
            }
        }

                //Registrar Contrato
        private void btnRegistrarContrato_Click(object sender, EventArgs e)
        {
            if (ValidarPestanaContrato())
            {
                try
                {
                    ct.IdPropiedad = Convert.ToInt32(dgvPropiedades.CurrentRow.Cells[0].Value);
                    ct.DniInquilino = locatario.pDNI;
                    ct.TipoDniInquilino = locatario.pTipoDNI;
                    ct.Duracion = Convert.ToInt32(txtDuracion.Text);
                    ct.PrecioAlquiler = Convert.ToDouble(txtPrecioAlquiler.Text);
                    ct.InteresDiario = Convert.ToDecimal(txtIntereses.Text);
                    ct.Deposito = Convert.ToDouble(txtDeposito.Text);
                    ct.UsoPropiedad = Convert.ToInt32(cboUsoPropiedad.SelectedValue);
                    ct.Vigencia = dtpFechaFin.Value;
                    ct.DiaDeVencimiento = Convert.ToInt32(txtDiaVencimiento.Text);//Agregar este campo en la tabla ContratosAlquiler de la BD
                    ct.FechaInicioContrato = dtpFechaInicio.Value; //Agregar este campo en la tabla ContratosAlquiler de la BD
                    ct.Fecha1raActualizacion = dtpActualizacion1.Value;
                    ct.Aumento1raActualizacion = Convert.ToDouble(txt1erAumento.Text);
                    ct.Fecha2daActualizacion = dtpActualizacion2.Value;
                    ct.Aumento2daActualizacion = Convert.ToDouble(txt2doAumento.Text);

                    //Insertar Contrato en BD
                    alq.insertarContrato(ct);
                    int idContrato = alq.buscarIdContrato(); //Busca el Id del último contrato creado

                    //Insertar Garantes
                    foreach (var item in ct.listarGarantes)
                    {
                        if (cl.VerificarPersona(item.pTipoDNI, item.pDNI) > 0)
                        {
                            alq.InsertarGarante(item, idContrato);
                        }
                    }

                    //Generar Contrato
                    GenerarContrato(ct.IdPropiedad, idContrato);

                    limpiarCamposLocador();
                    limpiarCamposLocatario();
                    limpiarCamposGarante();

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

        private string establecerTipoDNI(int i)
        {
            string tipo = "";
            if (i == 1)
                tipo = "L.E.";
            else if (i == 2)
                tipo = "D.U.";
            else if (i == 3)
                tipo = "Pasaporte";

            return tipo;
        }

        private string enLetras(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try
            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " CON " + decimales.ToString() + "/100";
            }

            res = aTexto(Convert.ToDouble(entero)) + dec;
            return res;
        }

        private string aTexto(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + aTexto(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + aTexto(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = aTexto(Math.Truncate(value / 10) * 10) + " Y " + aTexto(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + aTexto(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = aTexto(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = aTexto(Math.Truncate(value / 100) * 100) + " " + aTexto(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + aTexto(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = aTexto(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + aTexto(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLÓN";
            else if (value < 2000000) Num2Text = "UN MILLÓN " + aTexto(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = aTexto(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + aTexto(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLÓN";
            else if (value < 2000000000000) Num2Text = "UN BILLÓN " + aTexto(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = aTexto(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + aTexto(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;
        }

        private void GenerarContrato(int idPropiedad, int idContrato)
        {
            DTOPropiedad tempo = p.buscarDTOPropiedad(idPropiedad);
            String direccion = tempo.Calle + " N°" + tempo.NumeroCalle;

            //int indice = dgvPropiedades.CurrentRow.Index; //NO SE USA

            String ciudadLocador = tc.buscarCiudad(locador.pBarrio);
            String ciudadPropiedad = tempo.Ciudad;
            String pciaPropiedad = tempo.Provincia;

            object ObjMiss = System.Reflection.Missing.Value;
            Word.Application ObjWord = new Word.Application();

            //Ruta del contrato base
            string ruta = @"C:\Users\Nato\Documents\GitHub\Contratos\CONTRATO DE LOCACION.docx";

            string directorio = @"C:\Users\Nato\Documents\GitHub\Contratos\" + @"\" +
               locador.pApellido.ToUpper() + " " + locador.pNombre + " - " + direccion.ToUpper();

            //Se crea una carpeta para guardar el Contrato
            if (!Directory.Exists(directorio))
            {
                DirectoryInfo di = Directory.CreateDirectory(directorio);
            }

            //Ruta destino del archivo a crearse (datos locador, datos locatario)
            string destFile = directorio + @"\" + idContrato + " - " + locador.pApellido + " " + locador.pNombre + " - " + locatario.pApellido + " " + locatario.pNombre + ".docx";

            //Genera una copia del archivo con los datos del locador y locatario
            System.IO.File.Copy(ruta, destFile, true);

            //Marcadores en Contrato Base
            object parametro = destFile;
            object apelLoc = "ApellidoLocador";
            object nomLoc = "NombreLocador";
            object tipoLoc = "TipoDocLocador";
            object docLoc = "DocLocador";
            object ciuLoc = "CiudadLocador";
            object domLoc = "CalleLocador";

            object apelLocat = "ApellidoLocatario";
            object nomLocat = "NombreLocatario";
            object tipoLocat = "TipoDocLocatario";
            object docLocat = "DocLocatario";

            object domProp = "DomicilioPropiedad";
            object ciuProp = "CiudadPropiedad";
            object pciaProp = "ProvinciaPropiedad";
            object tipoProp = "TipoPropiedad";
            object supTerreno = "SuperficieTerreno";

            Word.Document ObjDoc = ObjWord.Documents.Open(parametro, ObjMiss);

            //Locador
            Word.Range ape = ObjDoc.Bookmarks.get_Item(ref apelLoc).Range;
            ape.Text = locador.pApellido.ToUpper(); //Apellido
            ObjDoc.Bookmarks.Add(apelLoc.ToString(), ape);

            Word.Range nom = ObjDoc.Bookmarks.get_Item(ref nomLoc).Range;
            nom.Text = locador.pNombre; //Nombre
            ObjDoc.Bookmarks.Add(nomLoc.ToString(), nom);

            Word.Range tipo = ObjDoc.Bookmarks.get_Item(ref tipoLoc).Range;
            tipo.Text = establecerTipoDNI(locador.pTipoDNI); //Tipo DNI
            ObjDoc.Bookmarks.Add(tipoLoc.ToString(), tipo);

            Word.Range doc = ObjDoc.Bookmarks.get_Item(ref docLoc).Range;
            doc.Text = Convert.ToString(locador.pDNI); //DNI
            ObjDoc.Bookmarks.Add(docLoc.ToString(), doc);

            Word.Range ciu = ObjDoc.Bookmarks.get_Item(ref ciuLoc).Range;
            ciu.Text = ciudadLocador.ToUpper(); //Ciudad
            ObjDoc.Bookmarks.Add(ciuLoc.ToString(), ciu);

            Word.Range calle = ObjDoc.Bookmarks.get_Item(ref domLoc).Range;
            calle.Text = locador.pDireccion + " " + Convert.ToString(locador.pAltura); //Dirección
            ObjDoc.Bookmarks.Add(domLoc.ToString(), calle);

            //Locatario
            Word.Range apeI = ObjDoc.Bookmarks.get_Item(ref apelLocat).Range;
            apeI.Text = locatario.pApellido.ToUpper(); //Apellido
            ObjDoc.Bookmarks.Add(apelLocat.ToString(), apeI);

            Word.Range nomI = ObjDoc.Bookmarks.get_Item(ref nomLocat).Range;
            nomI.Text = locatario.pNombre; //Nombre
            ObjDoc.Bookmarks.Add(nomLocat.ToString(), nomI);

            Word.Range tipoI = ObjDoc.Bookmarks.get_Item(ref tipoLocat).Range;
            tipoI.Text = establecerTipoDNI(locatario.pTipoDNI); //Tipo DNI
            ObjDoc.Bookmarks.Add(tipoLocat.ToString(), tipoI);

            Word.Range docI = ObjDoc.Bookmarks.get_Item(ref docLocat).Range;
            docI.Text = Convert.ToString(locatario.pDNI); //DNI
            ObjDoc.Bookmarks.Add(docLocat.ToString(), docI);

            Word.Range domP = ObjDoc.Bookmarks.get_Item(ref domProp).Range;
            domP.Text = direccion; //Dirección
            ObjDoc.Bookmarks.Add(domProp.ToString(), domP);

            Word.Range ciuP = ObjDoc.Bookmarks.get_Item(ref ciuProp).Range;
            ciuP.Text = ciudadPropiedad.ToUpper(); //Ciudad
            ObjDoc.Bookmarks.Add(ciuProp.ToString(), ciuP);

            Word.Range pciaP = ObjDoc.Bookmarks.get_Item(ref pciaProp).Range;
            pciaP.Text = pciaPropiedad; //Provincia
            ObjDoc.Bookmarks.Add(pciaProp.ToString(), pciaP);

            Word.Range tipoP = ObjDoc.Bookmarks.get_Item(ref tipoProp).Range;
            tipoP.Text = tempo.TipoPropiedad; //Tipo Propiedad
            ObjDoc.Bookmarks.Add(tipoProp.ToString(), tipoP);

            Word.Range supP = ObjDoc.Bookmarks.get_Item(ref supTerreno).Range;
            supP.Text = Convert.ToString(tempo.Superficie); //Superficie
            ObjDoc.Bookmarks.Add(supTerreno.ToString(), supP);

            object Observ = "Observaciones";
            Word.Range Obs = ObjDoc.Bookmarks.get_Item(ref Observ).Range;
            Obs.Text = Convert.ToString(tempo.Observaciones); //Observaciones
            ObjDoc.Bookmarks.Add(Observ.ToString(), Obs);

            object fechaInicio = "fechaInicioAlquiler";
            Word.Range fInicio = ObjDoc.Bookmarks.get_Item(ref fechaInicio).Range;
            fInicio.Text = dtpFechaInicio.Text;
            ObjDoc.Bookmarks.Add(fechaInicio.ToString(), fInicio);

            object fechaFin = "fechaFinAlquiler";
            Word.Range fFin = ObjDoc.Bookmarks.get_Item(ref fechaFin).Range;
            fFin.Text = dtpFechaFin.Text;
            ObjDoc.Bookmarks.Add(fechaFin.ToString(), fFin);

            object moraLetras = "moraLetra";
            Word.Range moraD = ObjDoc.Bookmarks.get_Item(ref moraLetras).Range;
            moraD.Text = enLetras(txtIntereses.Text);
            ObjDoc.Bookmarks.Add(moraLetras.ToString(), moraD);

            object multaDiaria = "MoraDiaria";
            Word.Range multaD = ObjDoc.Bookmarks.get_Item(ref multaDiaria).Range;
            multaD.Text = txtIntereses.Text;
            ObjDoc.Bookmarks.Add(multaDiaria.ToString(), multaD);

            object usoProp = "usoQueLeDaran";
            Word.Range usoP = ObjDoc.Bookmarks.get_Item(ref usoProp).Range;
            usoP.Text = cboUsoPropiedad.Text;
            ObjDoc.Bookmarks.Add(usoProp.ToString(), usoP);

            object precioAlquiler = "precioAlquilerLetras";
            Word.Range precioAlq = ObjDoc.Bookmarks.get_Item(ref precioAlquiler).Range;
            precioAlq.Text = enLetras(txtPrecioAlquiler.Text);
            ObjDoc.Bookmarks.Add(precioAlquiler.ToString(), precioAlq);

            object precioAlquilerN = "precioAlquilerNros";
            Word.Range precioAlqN = ObjDoc.Bookmarks.get_Item(ref precioAlquilerN).Range;
            precioAlqN.Text = txtPrecioAlquiler.Text;
            ObjDoc.Bookmarks.Add(precioAlquilerN.ToString(), precioAlqN);

            object diaDePago = "diaDePago";
            Word.Range diaPago = ObjDoc.Bookmarks.get_Item(ref diaDePago).Range;
            diaPago.Text = txtDiaVencimiento.Text;
            ObjDoc.Bookmarks.Add(diaDePago.ToString(), diaPago);

            object diaDePagoL = "diaDePagoLetras";
            Word.Range diaPagoL = ObjDoc.Bookmarks.get_Item(ref diaDePagoL).Range;
            diaPagoL.Text = enLetras(txtDiaVencimiento.Text);
            ObjDoc.Bookmarks.Add(diaDePagoL.ToString(), diaPagoL);

            object apelG1 = "ApellidoGarante";
            Word.Range apeG1 = ObjDoc.Bookmarks.get_Item(ref apelG1).Range;
            apeG1.Text = dgvGarantes.Rows[0].Cells[2].Value.ToString();
            ObjDoc.Bookmarks.Add(apelG1.ToString(), apeG1);

            object nombreG1 = "NombreGarante";
            Word.Range nomG1 = ObjDoc.Bookmarks.get_Item(ref nombreG1).Range;
            nomG1.Text = dgvGarantes.Rows[0].Cells[3].Value.ToString();
            ObjDoc.Bookmarks.Add(nombreG1.ToString(), nomG1);

            object tipoG1 = "TipoDocGarante";
            Word.Range tipG1 = ObjDoc.Bookmarks.get_Item(ref tipoG1).Range;
            tipG1.Text = ad.buscarValor(Convert.ToInt32(dgvGarantes.Rows[0].Cells[1].Value), "id_DNI", "tipoDNI", "TiposDNI");
            ObjDoc.Bookmarks.Add(tipoG1.ToString(), tipG1);

            object docuG1 = "DocumGarante";
            Word.Range docG1 = ObjDoc.Bookmarks.get_Item(ref docuG1).Range;
            docG1.Text = dgvGarantes.Rows[0].Cells[0].Value.ToString();
            ObjDoc.Bookmarks.Add(docuG1.ToString(), docG1);

            object calleG1 = "calleGarante";
            Word.Range calG1 = ObjDoc.Bookmarks.get_Item(ref calleG1).Range;
            calG1.Text = dgvGarantes.Rows[0].Cells[6].Value.ToString() + " Nº" + dgvGarantes.Rows[0].Cells[7].Value.ToString();
            ObjDoc.Bookmarks.Add(calleG1.ToString(), calG1);

            object telefG1 = "TelGarante";
            Word.Range telG1 = ObjDoc.Bookmarks.get_Item(ref telefG1).Range;
            telG1.Text = dgvGarantes.Rows[0].Cells[4].Value.ToString() + dgvGarantes.Rows[0].Cells[5].Value.ToString(); ;
            ObjDoc.Bookmarks.Add(telefG1.ToString(), telG1);


            object pciaG1 = "PciaGarante";
            Word.Range provG1 = ObjDoc.Bookmarks.get_Item(ref pciaG1).Range;
            provG1.Text = ad.buscarValor(Convert.ToInt32(dgvGarantes.Rows[0].Cells[9].Value), "id_provincia", "nombre", "Provincias");
            ObjDoc.Bookmarks.Add(pciaG1.ToString(), provG1);

            object ciudadG1 = "CiudadGarante";
            Word.Range ciuG1 = ObjDoc.Bookmarks.get_Item(ref ciudadG1).Range;
            ciuG1.Text = ad.buscarValor(Convert.ToInt32(dgvGarantes.Rows[0].Cells[8].Value), "id_ciudad", "nombreCiu", "Ciudades");
            ObjDoc.Bookmarks.Add(ciudadG1.ToString(), ciuG1);


            //if (dgvGarantes.RowCount.ToString().Equals("2"))
            //{

            object apelG2 = "ApellidoGarante2";
            Word.Range apeG2 = ObjDoc.Bookmarks.get_Item(ref apelG2).Range;
            apeG2.Text = dgvGarantes.Rows[1].Cells[2].Value.ToString();
            ObjDoc.Bookmarks.Add(apelG2.ToString(), apeG2);

            object nombreG2 = "NombreGarante2";
            Word.Range nomG2 = ObjDoc.Bookmarks.get_Item(ref nombreG2).Range;
            nomG2.Text = dgvGarantes.Rows[1].Cells[3].Value.ToString();
            ObjDoc.Bookmarks.Add(nombreG2.ToString(), nomG2);

            object tipoG2 = "TipoDocGarante2";
            Word.Range tipG2 = ObjDoc.Bookmarks.get_Item(ref tipoG2).Range;
            tipG2.Text = ad.buscarValor(Convert.ToInt32(dgvGarantes.Rows[1].Cells[1].Value), "id_DNI", "tipoDNI", "TiposDNI");
            ObjDoc.Bookmarks.Add(tipoG2.ToString(), tipG2);

            object docuG2 = "DocumGarante2";
            Word.Range docG2 = ObjDoc.Bookmarks.get_Item(ref docuG2).Range;
            docG2.Text = dgvGarantes.Rows[1].Cells[0].Value.ToString();
            ObjDoc.Bookmarks.Add(docuG2.ToString(), docG2);

            object calleG2 = "calleGarante2";
            Word.Range calG2 = ObjDoc.Bookmarks.get_Item(ref calleG2).Range;
            calG2.Text = dgvGarantes.Rows[1].Cells[6].Value.ToString() + " Nº" + dgvGarantes.Rows[1].Cells[7].Value.ToString();
            ObjDoc.Bookmarks.Add(calleG2.ToString(), calG2);

            object telefG2 = "TelGarante2";
            Word.Range telG2 = ObjDoc.Bookmarks.get_Item(ref telefG2).Range;
            telG2.Text = dgvGarantes.Rows[1].Cells[4].Value.ToString() + dgvGarantes.Rows[1].Cells[5].Value.ToString();
            ObjDoc.Bookmarks.Add(telefG2.ToString(), telG2);

            object pciaG2 = "PciaGarante2";
            Word.Range provG2 = ObjDoc.Bookmarks.get_Item(ref pciaG2).Range;
            provG2.Text = ad.buscarValor(Convert.ToInt32(dgvGarantes.Rows[1].Cells[9].Value), "id_provincia", "nombre", "Provincias");
            ObjDoc.Bookmarks.Add(pciaG2.ToString(), provG2);

            object ciudadG2 = "CiudadGarante2";
            Word.Range ciuG2 = ObjDoc.Bookmarks.get_Item(ref ciudadG2).Range;
            ciuG2.Text = ad.buscarValor(Convert.ToInt32(dgvGarantes.Rows[1].Cells[8].Value), "id_ciudad", "nombreCiu", "Ciudades");
            ObjDoc.Bookmarks.Add(ciudadG2.ToString(), ciuG2);

            object deposLetras = "depositoLetras";
            Word.Range depL = ObjDoc.Bookmarks.get_Item(ref deposLetras).Range;
            depL.Text = enLetras(txtDeposito.Text);
            ObjDoc.Bookmarks.Add(deposLetras.ToString(), depL);

            object deposito = "DepositoNro";
            Word.Range depo = ObjDoc.Bookmarks.get_Item(ref deposito).Range;
            depo.Text = txtDeposito.Text;
            ObjDoc.Bookmarks.Add(deposito.ToString(), depo);

            object mailLoc = "mailLocataria";
            Word.Range mailL = ObjDoc.Bookmarks.get_Item(ref mailLoc).Range;
            mailL.Text = txtMail.Text;
            ObjDoc.Bookmarks.Add(mailLoc.ToString(), mailL);

            object diaCont = "diaContrato";
            Word.Range diaC = ObjDoc.Bookmarks.get_Item(ref diaCont).Range;
            diaC.Text = dtpFechaInicio.Value.Day.ToString();
            ObjDoc.Bookmarks.Add(diaCont.ToString(), diaC);

            object mesCont = "mesContrato";
            Word.Range mesC = ObjDoc.Bookmarks.get_Item(ref mesCont).Range;
            mesC.Text = dtpFechaInicio.Value.Month.ToString();
            ObjDoc.Bookmarks.Add(mesCont.ToString(), mesC);

            object anCont = "añoContrato";
            Word.Range anC = ObjDoc.Bookmarks.get_Item(ref anCont).Range;
            anC.Text = dtpFechaInicio.Value.Year.ToString();
            ObjDoc.Bookmarks.Add(anCont.ToString(), anC);

            object loca = "Locador";
            Word.Range loc = ObjDoc.Bookmarks.get_Item(ref loca).Range;
            loc.Text = ape.Text + ", " + nom.Text;
            ObjDoc.Bookmarks.Add(loca.ToString(), loc);

            object locat = "Locatario";
            Word.Range loct = ObjDoc.Bookmarks.get_Item(ref locat).Range;
            loct.Text = apeI.Text + ", " + nomI.Text;
            ObjDoc.Bookmarks.Add(locat.ToString(), loct);

            object dniloca = "DniLocador";
            Word.Range dnil = ObjDoc.Bookmarks.get_Item(ref dniloca).Range;
            dnil.Text = tipo.Text + " Nº" + doc.Text;
            ObjDoc.Bookmarks.Add(dniloca.ToString(), dnil);

            object dnilocat = "DniLocatario";
            Word.Range dnilt = ObjDoc.Bookmarks.get_Item(ref dnilocat).Range;
            dnilt.Text = tipoI.Text + " Nº" + docI.Text;
            ObjDoc.Bookmarks.Add(dnilocat.ToString(), dnilt);

            object Garan1 = "Garante1";
            Word.Range Gar1 = ObjDoc.Bookmarks.get_Item(ref Garan1).Range;
            Gar1.Text = apeG1.Text + ", " + nomG1.Text;
            ObjDoc.Bookmarks.Add(Garan1.ToString(), Gar1);

            object Garan2 = "Garante2";
            Word.Range Gar2 = ObjDoc.Bookmarks.get_Item(ref Garan2).Range;
            Gar2.Text = apeG2.Text + ", " + nomG2.Text;
            ObjDoc.Bookmarks.Add(Garan2.ToString(), Gar2);

            object dniGa1 = "DniGarante1";
            Word.Range dniG1 = ObjDoc.Bookmarks.get_Item(ref dniGa1).Range;
            dniG1.Text = tipG1.Text + " Nº" + docG1.Text;
            ObjDoc.Bookmarks.Add(dniGa1.ToString(), dniG1);

            object dniGa2 = "DniGarante2";
            Word.Range dniG2 = ObjDoc.Bookmarks.get_Item(ref dniGa2).Range;
            dniG2.Text = tipG2.Text + " Nº" + docG2.Text;
            ObjDoc.Bookmarks.Add(dniGa2.ToString(), dniG2);

            ObjWord.Visible = true;
        }

        //ENVÍO Y RECEPCIÓN DE DATOS A OTRAS VENTANAS
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
                    lblTelGarante.Text = Convert.ToString(item.pnumero);
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
