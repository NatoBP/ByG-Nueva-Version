namespace Interfaz
{
    partial class Principal_1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal_1));
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnClientes = new System.Windows.Forms.Button();
            this.pnlSubProp = new System.Windows.Forms.Panel();
            this.btnPropiedades = new System.Windows.Forms.Button();
            this.btnLocadores = new System.Windows.Forms.Button();
            this.btnAdminProp = new System.Windows.Forms.Button();
            this.pnlSubAdmin = new System.Windows.Forms.Panel();
            this.btnEstadoCuentas = new System.Windows.Forms.Button();
            this.btnAlqNoVigentes = new System.Windows.Forms.Button();
            this.btnAlqVigentes = new System.Windows.Forms.Button();
            this.btnNuevoContrato = new System.Windows.Forms.Button();
            this.btnAlquileres = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.pnlPrincipal.SuspendLayout();
            this.pnlContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.pnlSubProp.SuspendLayout();
            this.pnlSubAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.pnlContenedor);
            this.pnlPrincipal.Controls.Add(this.pnlCabecera);
            this.pnlPrincipal.Controls.Add(this.pnlMenu);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1300, 730);
            this.pnlPrincipal.TabIndex = 0;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(214)))), ((int)(((byte)(199)))));
            this.pnlContenedor.Controls.Add(this.pictureBox1);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(250, 80);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1050, 650);
            this.pnlContenedor.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(320, 248);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(410, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 388;
            this.pictureBox1.TabStop = false;
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.pnlCabecera.Controls.Add(this.btnCerrar);
            this.pnlCabecera.Controls.Add(this.btnMinimizar);
            this.pnlCabecera.Controls.Add(this.btnRestaurar);
            this.pnlCabecera.Controls.Add(this.btnMaximizar);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(250, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(1050, 80);
            this.pnlCabecera.TabIndex = 1;
            this.pnlCabecera.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlCabecera_MouseDown);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1003, 28);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 25);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(941, 28);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(25, 25);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMinimizar.TabIndex = 10;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("btnRestaurar.Image")));
            this.btnRestaurar.Location = new System.Drawing.Point(972, 28);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(25, 25);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRestaurar.TabIndex = 9;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Visible = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(972, 28);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(25, 25);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMaximizar.TabIndex = 12;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(103)))), ((int)(((byte)(125)))));
            this.pnlMenu.Controls.Add(this.btnClientes);
            this.pnlMenu.Controls.Add(this.pnlSubProp);
            this.pnlMenu.Controls.Add(this.btnAdminProp);
            this.pnlMenu.Controls.Add(this.pnlSubAdmin);
            this.pnlMenu.Controls.Add(this.btnAlquileres);
            this.pnlMenu.Controls.Add(this.btnVentas);
            this.pnlMenu.Controls.Add(this.Logo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(250, 730);
            this.pnlMenu.TabIndex = 1;
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(204)))), ((int)(((byte)(211)))));
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(0, 485);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(250, 45);
            this.btnClientes.TabIndex = 39;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // pnlSubProp
            // 
            this.pnlSubProp.Controls.Add(this.btnPropiedades);
            this.pnlSubProp.Controls.Add(this.btnLocadores);
            this.pnlSubProp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubProp.Location = new System.Drawing.Point(0, 395);
            this.pnlSubProp.Name = "pnlSubProp";
            this.pnlSubProp.Size = new System.Drawing.Size(250, 90);
            this.pnlSubProp.TabIndex = 38;
            // 
            // btnPropiedades
            // 
            this.btnPropiedades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.btnPropiedades.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPropiedades.FlatAppearance.BorderSize = 0;
            this.btnPropiedades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPropiedades.Location = new System.Drawing.Point(0, 45);
            this.btnPropiedades.Name = "btnPropiedades";
            this.btnPropiedades.Size = new System.Drawing.Size(250, 45);
            this.btnPropiedades.TabIndex = 1;
            this.btnPropiedades.Text = "Propiedades";
            this.btnPropiedades.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPropiedades.UseVisualStyleBackColor = false;
            this.btnPropiedades.Click += new System.EventHandler(this.btnPropiedades_Click);
            // 
            // btnLocadores
            // 
            this.btnLocadores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.btnLocadores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLocadores.Enabled = false;
            this.btnLocadores.FlatAppearance.BorderSize = 0;
            this.btnLocadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocadores.Location = new System.Drawing.Point(0, 0);
            this.btnLocadores.Name = "btnLocadores";
            this.btnLocadores.Size = new System.Drawing.Size(250, 45);
            this.btnLocadores.TabIndex = 0;
            this.btnLocadores.Text = "Locadores";
            this.btnLocadores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLocadores.UseVisualStyleBackColor = false;
            this.btnLocadores.Click += new System.EventHandler(this.btnLocadores_Click);
            // 
            // btnAdminProp
            // 
            this.btnAdminProp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(204)))), ((int)(((byte)(211)))));
            this.btnAdminProp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdminProp.FlatAppearance.BorderSize = 0;
            this.btnAdminProp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminProp.Image = ((System.Drawing.Image)(resources.GetObject("btnAdminProp.Image")));
            this.btnAdminProp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdminProp.Location = new System.Drawing.Point(0, 350);
            this.btnAdminProp.Name = "btnAdminProp";
            this.btnAdminProp.Size = new System.Drawing.Size(250, 45);
            this.btnAdminProp.TabIndex = 37;
            this.btnAdminProp.Text = "Admin. de Propiedades";
            this.btnAdminProp.UseVisualStyleBackColor = false;
            this.btnAdminProp.Click += new System.EventHandler(this.btnAdminProp_Click);
            // 
            // pnlSubAdmin
            // 
            this.pnlSubAdmin.Controls.Add(this.btnEstadoCuentas);
            this.pnlSubAdmin.Controls.Add(this.btnAlqNoVigentes);
            this.pnlSubAdmin.Controls.Add(this.btnAlqVigentes);
            this.pnlSubAdmin.Controls.Add(this.btnNuevoContrato);
            this.pnlSubAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubAdmin.Location = new System.Drawing.Point(0, 170);
            this.pnlSubAdmin.Name = "pnlSubAdmin";
            this.pnlSubAdmin.Size = new System.Drawing.Size(250, 180);
            this.pnlSubAdmin.TabIndex = 35;
            // 
            // btnEstadoCuentas
            // 
            this.btnEstadoCuentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.btnEstadoCuentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEstadoCuentas.FlatAppearance.BorderSize = 0;
            this.btnEstadoCuentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadoCuentas.Location = new System.Drawing.Point(0, 135);
            this.btnEstadoCuentas.Name = "btnEstadoCuentas";
            this.btnEstadoCuentas.Size = new System.Drawing.Size(250, 45);
            this.btnEstadoCuentas.TabIndex = 3;
            this.btnEstadoCuentas.Text = "Est. de Cuentas / Comprobantes";
            this.btnEstadoCuentas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEstadoCuentas.UseVisualStyleBackColor = false;
            this.btnEstadoCuentas.Click += new System.EventHandler(this.btnEstadoCuentas_Click);
            // 
            // btnAlqNoVigentes
            // 
            this.btnAlqNoVigentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.btnAlqNoVigentes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAlqNoVigentes.FlatAppearance.BorderSize = 0;
            this.btnAlqNoVigentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlqNoVigentes.Location = new System.Drawing.Point(0, 90);
            this.btnAlqNoVigentes.Name = "btnAlqNoVigentes";
            this.btnAlqNoVigentes.Size = new System.Drawing.Size(250, 45);
            this.btnAlqNoVigentes.TabIndex = 2;
            this.btnAlqNoVigentes.Text = "Alquileres No Vigentes";
            this.btnAlqNoVigentes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlqNoVigentes.UseVisualStyleBackColor = false;
            this.btnAlqNoVigentes.Click += new System.EventHandler(this.btnAlqNoVigentes_Click);
            // 
            // btnAlqVigentes
            // 
            this.btnAlqVigentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.btnAlqVigentes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAlqVigentes.FlatAppearance.BorderSize = 0;
            this.btnAlqVigentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlqVigentes.Location = new System.Drawing.Point(0, 45);
            this.btnAlqVigentes.Name = "btnAlqVigentes";
            this.btnAlqVigentes.Size = new System.Drawing.Size(250, 45);
            this.btnAlqVigentes.TabIndex = 1;
            this.btnAlqVigentes.Text = "Alquileres Vigentes";
            this.btnAlqVigentes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlqVigentes.UseVisualStyleBackColor = false;
            this.btnAlqVigentes.Click += new System.EventHandler(this.btnAlqVigentes_Click);
            // 
            // btnNuevoContrato
            // 
            this.btnNuevoContrato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.btnNuevoContrato.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNuevoContrato.FlatAppearance.BorderSize = 0;
            this.btnNuevoContrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoContrato.Location = new System.Drawing.Point(0, 0);
            this.btnNuevoContrato.Name = "btnNuevoContrato";
            this.btnNuevoContrato.Size = new System.Drawing.Size(250, 45);
            this.btnNuevoContrato.TabIndex = 0;
            this.btnNuevoContrato.Text = "Nuevo Contrato";
            this.btnNuevoContrato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevoContrato.UseVisualStyleBackColor = false;
            this.btnNuevoContrato.Click += new System.EventHandler(this.btnNuevoContrato_Click);
            // 
            // btnAlquileres
            // 
            this.btnAlquileres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(204)))), ((int)(((byte)(211)))));
            this.btnAlquileres.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAlquileres.FlatAppearance.BorderSize = 0;
            this.btnAlquileres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlquileres.Image = ((System.Drawing.Image)(resources.GetObject("btnAlquileres.Image")));
            this.btnAlquileres.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlquileres.Location = new System.Drawing.Point(0, 125);
            this.btnAlquileres.Name = "btnAlquileres";
            this.btnAlquileres.Size = new System.Drawing.Size(250, 45);
            this.btnAlquileres.TabIndex = 33;
            this.btnAlquileres.Text = "Alquileres";
            this.btnAlquileres.UseVisualStyleBackColor = false;
            this.btnAlquileres.Click += new System.EventHandler(this.btnAlquileres_Click_1);
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(204)))), ((int)(((byte)(211)))));
            this.btnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnVentas.Image")));
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.Location = new System.Drawing.Point(0, 80);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(250, 45);
            this.btnVentas.TabIndex = 32;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = false;
            // 
            // Logo
            // 
            this.Logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(0, 0);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(250, 80);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 31;
            this.Logo.TabStop = false;
            // 
            // Principal_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 730);
            this.Controls.Add(this.pnlPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Principal_1";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal_1";
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlSubProp.ResumeLayout(false);
            this.pnlSubAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Panel pnlSubProp;
        private System.Windows.Forms.Button btnPropiedades;
        private System.Windows.Forms.Button btnLocadores;
        private System.Windows.Forms.Button btnAdminProp;
        private System.Windows.Forms.Panel pnlSubAdmin;
        private System.Windows.Forms.Button btnEstadoCuentas;
        private System.Windows.Forms.Button btnAlqNoVigentes;
        private System.Windows.Forms.Button btnAlqVigentes;
        private System.Windows.Forms.Button btnNuevoContrato;
        private System.Windows.Forms.Button btnAlquileres;
        private System.Windows.Forms.Button btnVentas;
    }
}