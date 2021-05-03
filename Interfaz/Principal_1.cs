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

        private void btnAlquileres_Click_1(object sender, EventArgs e)
        {
            if(pnlSubAdmin.Visible == false)
            {
                pnlSubAdmin.Visible = true;
            }
            else
            {
                pnlSubAdmin.Visible = false;
            }
        }

        private void btnAdminAlq_Click(object sender, EventArgs e)
        {
            if (pnlSubAdmin.Visible == false)
                pnlSubAdmin.Visible = true;
            else
                pnlSubAdmin.Visible = false;
        }

        private void btnNuevoContrato_Click(object sender, EventArgs e)
        {
            abrirVentanaPanel(new NuevoContrato());
        }

        private void btnAlqVigentes_Click(object sender, EventArgs e)
        {
            abrirVentanaPanel(new AlquileresVigentes());
        }

        private void btnAlqNoVigentes_Click(object sender, EventArgs e)
        {
            abrirVentanaPanel(new AlquileresNoVigentes());
        }

        private void btnEstadoCuentas_Click(object sender, EventArgs e)
        {
            abrirVentanaPanel(new EstadoDeCuentas());
        }

        private void btnAdminProp_Click(object sender, EventArgs e)
        {
            if (pnlSubProp.Visible == false)
                pnlSubProp.Visible = true;
            else
                pnlSubProp.Visible = false;
        }

        private void btnLocadores_Click(object sender, EventArgs e)
        {

        }

        private void btnPropiedades_Click(object sender, EventArgs e)
        {
            abrirVentanaPanel(new Propiedades());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            abrirVentanaPanel(new Clientes());
        }

        //Diseño botones Menú
        private void setBotones()
        {
            foreach (Control c in pnlMenu.Controls)
            {
                if (c is Button)
                {
                    c.Font = new Font("Oxygen", 12);
                }
            }
            foreach(Control c in pnlSubAdmin.Controls)
            {
                if (c is Button)
                {
                    c.Font = new Font("Oxygen", 12);
                }
            }
            foreach(Control c in pnlSubProp.Controls)
            {
                if (c is Button)
                {
                    c.Font = new Font("Oxygen", 12);
                }
            }
            pnlSubAdmin.Visible = false;
            pnlSubProp.Visible = false;
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
