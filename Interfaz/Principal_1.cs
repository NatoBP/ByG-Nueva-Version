using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Interfaz
{
    public partial class Principal_1 : Form
    {
        public Principal_1()
        {
            InitializeComponent();
            setBotones();
            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
        }

        #region //Botones del Menú

        //Botón Alquileres
        private void btnAlquileres_Click(object sender, EventArgs e)
        {
            if (rbtAdminAlq.Visible == false && rbtLocadores.Visible == false)
            {
                rbtAdminAlq.Visible = true;
                rbtAlqDisponibles.Visible = true;
                rbtAdminAlq.Location = new Point(0, 190);
                rbtAlqDisponibles.Location = new Point(0, 235);
                rbtAdminProp.Location = new Point(0, 280);
                rbtClientes.Location = new Point(0, 325);
            }

            else if (rbtAdminAlq.Visible == false && rbtLocadores.Visible == true)
            {
                rbtAdminAlq.Visible = true;
                rbtAlqDisponibles.Visible = true;
                rbtAlqDisponibles.Location = new Point(0, 235);
                rbtAdminProp.Location = new Point(0, 280);
                rbtLocadores.Location = new Point(0, 325);
                rbtVerProp.Location = new Point(0, 370);
                rbtNuevaProp.Location = new Point(0, 415);

                rbtClientes.Location = new Point(0, 460);

            }

            else if (rbtAdminAlq.Visible == true && rbtNuevoContrato.Visible == true && rbtLocadores.Visible == true)
            {
                rbtAdminProp.Location = new Point(0, 190);
                rbtLocadores.Location = new Point(0, 235);
                rbtVerProp.Location = new Point(0, 280);
                rbtNuevaProp.Location = new Point(0, 325);
                rbtClientes.Location = new Point(0, 370);
                rbtAdminAlq.Visible = false;
                rbtAlqDisponibles.Visible = false;
                rbtNuevoContrato.Visible = false;
                rbtAlqVigentes.Visible = false;
                rbtAlqNoVigentes.Visible = false;
                rbtRegistrarPagos.Visible = false;
                rbtEstadoCuentas.Visible = false;
                rbtAlqDisponibles.Visible = false;

            }

            else if (rbtAdminAlq.Visible == true && rbtNuevoContrato.Visible == true && rbtLocadores.Visible == false)
            {
                rbtAdminProp.Location = new Point(0, 190);
                rbtClientes.Location = new Point(0, 235);
                rbtNuevoContrato.Visible = false;
                rbtAlqVigentes.Visible = false;
                rbtAlqNoVigentes.Visible = false;
                rbtRegistrarPagos.Visible = false;
                rbtEstadoCuentas.Visible = false;
                rbtAdminAlq.Visible = false;
                rbtAlqDisponibles.Visible = false;
            }
            else if (rbtAdminAlq.Visible == true && rbtNuevoContrato.Visible == false && rbtLocadores.Visible == true)
            {
                rbtAdminAlq.Visible = false;
                rbtAlqDisponibles.Visible = false;
                rbtAdminProp.Location = new Point(0, 190);
                rbtLocadores.Location = new Point(0, 235);
                rbtVerProp.Location = new Point(0, 280);
                rbtNuevaProp.Location = new Point(0, 325);
                rbtClientes.Location = new Point(0, 370);
            }

            else if (rbtAdminAlq.Visible == true && rbtNuevoContrato.Visible == false && rbtLocadores.Visible == false)
            {
                rbtAdminProp.Location = new Point(0, 190);
                rbtClientes.Location = new Point(0, 235);
                rbtAdminAlq.Visible = false;
                rbtAlqDisponibles.Visible = false;
            }
        }

        //Botón Administración de Alquileres
        private void rbtAdminAlq_Click(object sender, EventArgs e)
        {
            if (rbtNuevoContrato.Visible == false && rbtLocadores.Visible == false)
            {
                rbtAlqDisponibles.Location = new Point(0, 460);
                rbtAdminProp.Location = new Point(0, 505);
                rbtClientes.Location = new Point(0, 550);
                rbtNuevoContrato.Location = new Point(0, 235);
                rbtNuevoContrato.Visible = true;
                rbtAlqVigentes.Visible = true;
                rbtAlqNoVigentes.Visible = true;
                rbtRegistrarPagos.Visible = true;
                rbtEstadoCuentas.Visible = true;
            }
            else if (rbtNuevoContrato.Visible == true && rbtLocadores.Visible == false)
            {
                rbtAdminProp.Location = new Point(0, 280);
                rbtClientes.Location = new Point(0, 325);
                rbtAlqDisponibles.Location = new Point(0, 235);
                rbtNuevoContrato.Visible = false;
                rbtAlqVigentes.Visible = false;
                rbtAlqNoVigentes.Visible = false;
                rbtRegistrarPagos.Visible = false;
                rbtEstadoCuentas.Visible = false;
            }
            else if (rbtNuevoContrato.Visible == false && rbtLocadores.Visible == true)
            {
                rbtNuevoContrato.Visible = true;
                rbtAlqVigentes.Visible = true;
                rbtAlqNoVigentes.Visible = true;
                rbtRegistrarPagos.Visible = true;
                rbtEstadoCuentas.Visible = true;
                rbtAlqDisponibles.Location = new Point(0, 460);
                rbtAdminProp.Location = new Point(0, 505);
                rbtLocadores.Location = new Point(0, 550);
                rbtVerProp.Location = new Point(0, 595);
                rbtNuevaProp.Location = new Point(0, 640);
                rbtClientes.Location = new Point(0, 685);

            }
            else if (rbtNuevoContrato.Visible == true && rbtLocadores.Visible == true)
            {
                rbtNuevoContrato.Visible = false;
                rbtAlqVigentes.Visible = false;
                rbtAlqNoVigentes.Visible = false;
                rbtRegistrarPagos.Visible = false;
                rbtEstadoCuentas.Visible = false;
                rbtAlqDisponibles.Location = new Point(0, 235);
                rbtAdminProp.Location = new Point(0, 280);
                rbtLocadores.Location = new Point(0, 325);
                rbtVerProp.Location = new Point(0, 370);
                rbtNuevaProp.Location = new Point(0, 415);
                rbtClientes.Location = new Point(0, 460);
            }
        }

        //Botón Administración de Propiedades
        private void rbtAdminProp_Click(object sender, EventArgs e)
        {
            if (rbtLocadores.Visible == false && rbtAdminAlq.Visible == false)
            {
                rbtLocadores.Visible = true;
                rbtVerProp.Visible = true;
                rbtNuevaProp.Visible = true;
                rbtLocadores.Location = new Point(0, 235);
                rbtVerProp.Location = new Point(0, 280);
                rbtNuevaProp.Location = new Point(0, 325);
                rbtClientes.Location = new Point(0, 370);
            }
            else if (rbtLocadores.Visible == true && rbtAdminAlq.Visible == true && rbtNuevoContrato.Visible == true)
            {
                rbtLocadores.Visible = false;
                rbtVerProp.Visible = false;
                rbtNuevaProp.Visible = false;
                rbtClientes.Location = new Point(0, 550);
            }

            else if (rbtAdminAlq.Visible == true && rbtNuevoContrato.Visible == false && rbtLocadores.Visible == true)
            {
                rbtLocadores.Visible = false;
                rbtVerProp.Visible = false;
                rbtNuevaProp.Visible = false;
                rbtClientes.Location = new Point(0, 325);
            }
            else if (rbtAdminAlq.Visible == false && rbtLocadores.Visible == true)
            {
                rbtLocadores.Visible = false;
                rbtVerProp.Visible = false;
                rbtNuevaProp.Visible = false;
                rbtClientes.Location = new Point(0, 235);

            }

            else if (rbtAdminAlq.Visible == true && rbtNuevoContrato.Visible == true && rbtLocadores.Visible == false)
            {
                rbtLocadores.Visible = true;
                rbtVerProp.Visible = true;
                rbtNuevaProp.Visible = true;
                rbtLocadores.Location = new Point(0, 550);
                rbtVerProp.Location = new Point(0, 595);
                rbtNuevaProp.Location = new Point(0, 640);
                rbtClientes.Location = new Point(0, 685);
            }
            else if (rbtAdminAlq.Visible == true && rbtNuevoContrato.Visible == false && rbtLocadores.Visible == false)
            {
                rbtLocadores.Visible = true;
                rbtVerProp.Visible = true;
                rbtNuevaProp.Visible = true;
                rbtLocadores.Location = new Point(0, 325);
                rbtVerProp.Location = new Point(0, 370);
                rbtNuevaProp.Location = new Point(0, 415);
                rbtClientes.Location = new Point(0, 460);
            }
        }

        //Botón Nuevo Contrato
        private void rbtNuevoContrato_Click(object sender, EventArgs e)
        {
            //abrirVentanaPanel(new IngresarPropietario());
        }

        //Botón Alquileres Vigentes
        private void rbtAlqVigentes_Click(object sender, EventArgs e)
        {
            //abrirVentanaPanel(new AlquileresVigentes());
        }

        //Botón Alquileres No Vigentes
        private void rbtAlqNoVigentes_Click(object sender, EventArgs e)
        {
            //abrirVentanaPanel(new AlquileresNoVigentes());
        }

        //Botón Registrar Pagos
        private void rbtRegistrarPagos_Click(object sender, EventArgs e)
        {
            //abrirVentanaPanel(new Comprobantes());

        }

        //Botón Estado de Cuentas
        private void rbtEstadoCuentas_Click(object sender, EventArgs e)
        {
            //abrirVentanaPanel(new CARGAR_ITEMS_A_PAGAR());
        }

        //Botón Ver Propiedades
        private void rbtVerProp_Click(object sender, EventArgs e)
        {
            //abrirVentanaPanel(new PropiedadesABM());
        }

        //Botón Nueva Propiedad
        private void rbtNuevaProp_Click(object sender, EventArgs e)
        {
            //abrirVentanaPanel(new PropiedadesAlta());
        }

        //Diseño botones Menú
        private void setBotones()
        {
            foreach (Control c in pnlMenu.Controls)
            {
                if (c is RadioButton)
                {
                    c.Font = new Font("Oxygen", 12);
                }
            }
        }

        #endregion

        #region //ControlDeInterfaz

        //BOTONES
        int Lx, Ly;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            Lx = this.Location.X;
            Ly = this.Location.Y;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size; //El tamaño debe ser igual al de la pantalla principal
            this.Location = Screen.PrimaryScreen.WorkingArea.Location; //La posición es igual al de la pantalla principal
            btnRestaurar.Visible = true;
            btnMaximizar.Visible = false;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1300, 772); //Se restaura al tamaño orignal del form Principal
            this.Location = new Point(Lx, Ly);
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show("¿Está segura que desea cerrar la aplicación?", "¿Cerrar aplicación?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
                Application.Exit();
        }

        private void rbtClientes_CheckedChanged(object sender, EventArgs e)
        {
            abrirVentanaPanel(new Clientes());
        }

        private void rbtNuevoContrato_CheckedChanged(object sender, EventArgs e)
        {
            abrirVentanaPanel(new NuevoContrato());
        }

        //METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO  TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.pnlPrincipal.Region = region;
            this.Invalidate();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //ABRIR VENTANAS EN PANEL
        public void abrirVentanaPanel(object formhijo)
        {
            if (this.pnlContenedor.Controls.Count > 0)
            {
                this.pnlContenedor.Controls.RemoveAt(0);
            }
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnlContenedor.Controls.Add(fh);
            this.pnlContenedor.Tag = fh;
            fh.Show();
        }

        //BARRA TÍTULO
        private void pnlCabecera_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void rbtNuevaProp_CheckedChanged(object sender, EventArgs e)
        {
            abrirVentanaPanel(new Propiedades());
        }

        private void rbtAlqVigentes_CheckedChanged(object sender, EventArgs e)
        {
            abrirVentanaPanel(new AlquileresVigentes());
        }

        private void rbtAlqNoVigentes_CheckedChanged(object sender, EventArgs e)
        {
            abrirVentanaPanel(new AlquileresNoVigentes());
        }

        private void rbtEstadoCuentas_CheckedChanged(object sender, EventArgs e)
        {
            abrirVentanaPanel(new EstadoDeCuentas());
        }


        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(99, 103, 125));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        #endregion
    }
}
