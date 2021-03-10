﻿namespace Interfaz
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.pnlBase = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnSlide = new System.Windows.Forms.PictureBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.rbtLocadores = new System.Windows.Forms.RadioButton();
            this.rbtVentas = new System.Windows.Forms.RadioButton();
            this.rbtAlqNoVigentes = new System.Windows.Forms.RadioButton();
            this.rbtRegistrarPagos = new System.Windows.Forms.RadioButton();
            this.rbtEstadoCuentas = new System.Windows.Forms.RadioButton();
            this.rbtNuevaProp = new System.Windows.Forms.RadioButton();
            this.rbtVerProp = new System.Windows.Forms.RadioButton();
            this.rbtAdminProp = new System.Windows.Forms.RadioButton();
            this.rbtAdminAlq = new System.Windows.Forms.RadioButton();
            this.rbtAlqVigentes = new System.Windows.Forms.RadioButton();
            this.rbtAlquileres = new System.Windows.Forms.RadioButton();
            this.rbtTasaciones = new System.Windows.Forms.RadioButton();
            this.rbtAlqDisponibles = new System.Windows.Forms.RadioButton();
            this.rbtNuevoContrato = new System.Windows.Forms.RadioButton();
            this.pnlBase.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSlide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.pnlContenedor);
            this.pnlBase.Controls.Add(this.pnlCabecera);
            this.pnlBase.Controls.Add(this.pnlMenu);
            this.pnlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBase.Location = new System.Drawing.Point(0, 0);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(1300, 730);
            this.pnlBase.TabIndex = 0;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(103)))), ((int)(((byte)(125)))));
            this.pnlMenu.Controls.Add(this.rbtLocadores);
            this.pnlMenu.Controls.Add(this.rbtVentas);
            this.pnlMenu.Controls.Add(this.rbtAlqNoVigentes);
            this.pnlMenu.Controls.Add(this.rbtRegistrarPagos);
            this.pnlMenu.Controls.Add(this.rbtEstadoCuentas);
            this.pnlMenu.Controls.Add(this.rbtNuevaProp);
            this.pnlMenu.Controls.Add(this.rbtVerProp);
            this.pnlMenu.Controls.Add(this.rbtAlqVigentes);
            this.pnlMenu.Controls.Add(this.rbtAlquileres);
            this.pnlMenu.Controls.Add(this.Logo);
            this.pnlMenu.Controls.Add(this.rbtNuevoContrato);
            this.pnlMenu.Controls.Add(this.rbtTasaciones);
            this.pnlMenu.Controls.Add(this.rbtAdminProp);
            this.pnlMenu.Controls.Add(this.rbtAdminAlq);
            this.pnlMenu.Controls.Add(this.rbtAlqDisponibles);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(250, 730);
            this.pnlMenu.TabIndex = 1;
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.pnlCabecera.Controls.Add(this.btnMinimizar);
            this.pnlCabecera.Controls.Add(this.btnSlide);
            this.pnlCabecera.Controls.Add(this.btnCerrar);
            this.pnlCabecera.Controls.Add(this.btnMaximizar);
            this.pnlCabecera.Controls.Add(this.btnRestaurar);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(250, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(1050, 80);
            this.pnlCabecera.TabIndex = 2;
            this.pnlCabecera.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlCabecera_MouseDown);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(951, 28);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(25, 25);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 6;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(982, 28);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(25, 25);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximizar.TabIndex = 8;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("btnRestaurar.Image")));
            this.btnRestaurar.Location = new System.Drawing.Point(982, 28);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(25, 25);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRestaurar.TabIndex = 3;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Visible = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1013, 28);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 25);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnSlide
            // 
            this.btnSlide.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSlide.Image = ((System.Drawing.Image)(resources.GetObject("btnSlide.Image")));
            this.btnSlide.Location = new System.Drawing.Point(17, 23);
            this.btnSlide.Name = "btnSlide";
            this.btnSlide.Size = new System.Drawing.Size(35, 35);
            this.btnSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSlide.TabIndex = 4;
            this.btnSlide.TabStop = false;
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(1, 1);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(250, 80);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 5;
            this.Logo.TabStop = false;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(250, 80);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1050, 650);
            this.pnlContenedor.TabIndex = 3;
            // 
            // rbtLocadores
            // 
            this.rbtLocadores.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtLocadores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.rbtLocadores.Enabled = false;
            this.rbtLocadores.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.rbtLocadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtLocadores.Location = new System.Drawing.Point(0, 460);
            this.rbtLocadores.Name = "rbtLocadores";
            this.rbtLocadores.Size = new System.Drawing.Size(250, 45);
            this.rbtLocadores.TabIndex = 18;
            this.rbtLocadores.Text = "Locadores";
            this.rbtLocadores.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtLocadores.UseVisualStyleBackColor = false;
            this.rbtLocadores.Visible = false;
            // 
            // rbtVentas
            // 
            this.rbtVentas.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(204)))), ((int)(((byte)(211)))));
            this.rbtVentas.Enabled = false;
            this.rbtVentas.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.rbtVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtVentas.Image = ((System.Drawing.Image)(resources.GetObject("rbtVentas.Image")));
            this.rbtVentas.Location = new System.Drawing.Point(0, 100);
            this.rbtVentas.Name = "rbtVentas";
            this.rbtVentas.Size = new System.Drawing.Size(250, 45);
            this.rbtVentas.TabIndex = 17;
            this.rbtVentas.Text = "Ventas";
            this.rbtVentas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtVentas.UseVisualStyleBackColor = false;
            // 
            // rbtAlqNoVigentes
            // 
            this.rbtAlqNoVigentes.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtAlqNoVigentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.rbtAlqNoVigentes.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.rbtAlqNoVigentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtAlqNoVigentes.Location = new System.Drawing.Point(0, 325);
            this.rbtAlqNoVigentes.Name = "rbtAlqNoVigentes";
            this.rbtAlqNoVigentes.Size = new System.Drawing.Size(250, 45);
            this.rbtAlqNoVigentes.TabIndex = 23;
            this.rbtAlqNoVigentes.Text = "Alquileres No Vigentes";
            this.rbtAlqNoVigentes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtAlqNoVigentes.UseVisualStyleBackColor = false;
            this.rbtAlqNoVigentes.Visible = false;
            this.rbtAlqNoVigentes.Click += new System.EventHandler(this.rbtAlqNoVigentes_Click);
            // 
            // rbtRegistrarPagos
            // 
            this.rbtRegistrarPagos.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtRegistrarPagos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.rbtRegistrarPagos.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.rbtRegistrarPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtRegistrarPagos.Location = new System.Drawing.Point(0, 370);
            this.rbtRegistrarPagos.Name = "rbtRegistrarPagos";
            this.rbtRegistrarPagos.Size = new System.Drawing.Size(250, 45);
            this.rbtRegistrarPagos.TabIndex = 22;
            this.rbtRegistrarPagos.Text = "Registrar Pagos";
            this.rbtRegistrarPagos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtRegistrarPagos.UseVisualStyleBackColor = false;
            this.rbtRegistrarPagos.Visible = false;
            this.rbtRegistrarPagos.Click += new System.EventHandler(this.rbtRegistrarPagos_Click);
            // 
            // rbtEstadoCuentas
            // 
            this.rbtEstadoCuentas.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtEstadoCuentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.rbtEstadoCuentas.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.rbtEstadoCuentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtEstadoCuentas.Location = new System.Drawing.Point(0, 415);
            this.rbtEstadoCuentas.Name = "rbtEstadoCuentas";
            this.rbtEstadoCuentas.Size = new System.Drawing.Size(250, 45);
            this.rbtEstadoCuentas.TabIndex = 21;
            this.rbtEstadoCuentas.Text = "Estado de Cuentas";
            this.rbtEstadoCuentas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtEstadoCuentas.UseVisualStyleBackColor = false;
            this.rbtEstadoCuentas.Visible = false;
            this.rbtEstadoCuentas.Click += new System.EventHandler(this.rbtEstadoCuentas_Click);
            // 
            // rbtNuevaProp
            // 
            this.rbtNuevaProp.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtNuevaProp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.rbtNuevaProp.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.rbtNuevaProp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtNuevaProp.Location = new System.Drawing.Point(0, 550);
            this.rbtNuevaProp.Name = "rbtNuevaProp";
            this.rbtNuevaProp.Size = new System.Drawing.Size(250, 45);
            this.rbtNuevaProp.TabIndex = 20;
            this.rbtNuevaProp.Text = "Nueva Propiedad";
            this.rbtNuevaProp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtNuevaProp.UseVisualStyleBackColor = false;
            this.rbtNuevaProp.Visible = false;
            this.rbtNuevaProp.Click += new System.EventHandler(this.rbtNuevaProp_Click);
            // 
            // rbtVerProp
            // 
            this.rbtVerProp.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtVerProp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.rbtVerProp.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.rbtVerProp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtVerProp.Location = new System.Drawing.Point(0, 505);
            this.rbtVerProp.Name = "rbtVerProp";
            this.rbtVerProp.Size = new System.Drawing.Size(250, 45);
            this.rbtVerProp.TabIndex = 19;
            this.rbtVerProp.Text = "Ver Propiedades";
            this.rbtVerProp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtVerProp.UseVisualStyleBackColor = false;
            this.rbtVerProp.Visible = false;
            this.rbtVerProp.Click += new System.EventHandler(this.rbtVerProp_Click);
            // 
            // rbtAdminProp
            // 
            this.rbtAdminProp.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtAdminProp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(204)))), ((int)(((byte)(211)))));
            this.rbtAdminProp.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.rbtAdminProp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtAdminProp.Image = ((System.Drawing.Image)(resources.GetObject("rbtAdminProp.Image")));
            this.rbtAdminProp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtAdminProp.Location = new System.Drawing.Point(0, 190);
            this.rbtAdminProp.Name = "rbtAdminProp";
            this.rbtAdminProp.Size = new System.Drawing.Size(250, 45);
            this.rbtAdminProp.TabIndex = 29;
            this.rbtAdminProp.Text = "Admin. de Propiedades";
            this.rbtAdminProp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtAdminProp.UseVisualStyleBackColor = false;
            this.rbtAdminProp.Click += new System.EventHandler(this.rbtAdminProp_Click);
            // 
            // rbtAdminAlq
            // 
            this.rbtAdminAlq.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtAdminAlq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.rbtAdminAlq.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.rbtAdminAlq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtAdminAlq.Image = ((System.Drawing.Image)(resources.GetObject("rbtAdminAlq.Image")));
            this.rbtAdminAlq.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtAdminAlq.Location = new System.Drawing.Point(0, 190);
            this.rbtAdminAlq.Name = "rbtAdminAlq";
            this.rbtAdminAlq.Size = new System.Drawing.Size(250, 45);
            this.rbtAdminAlq.TabIndex = 27;
            this.rbtAdminAlq.Text = "Admin. de Alquileres";
            this.rbtAdminAlq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtAdminAlq.UseVisualStyleBackColor = false;
            this.rbtAdminAlq.Visible = false;
            this.rbtAdminAlq.Click += new System.EventHandler(this.rbtAdminAlq_Click);
            // 
            // rbtAlqVigentes
            // 
            this.rbtAlqVigentes.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtAlqVigentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.rbtAlqVigentes.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.rbtAlqVigentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtAlqVigentes.Location = new System.Drawing.Point(0, 280);
            this.rbtAlqVigentes.Name = "rbtAlqVigentes";
            this.rbtAlqVigentes.Size = new System.Drawing.Size(250, 45);
            this.rbtAlqVigentes.TabIndex = 24;
            this.rbtAlqVigentes.Text = "Alquileres Vigentes";
            this.rbtAlqVigentes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtAlqVigentes.UseVisualStyleBackColor = false;
            this.rbtAlqVigentes.Visible = false;
            this.rbtAlqVigentes.Click += new System.EventHandler(this.rbtAlqVigentes_Click);
            // 
            // rbtAlquileres
            // 
            this.rbtAlquileres.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtAlquileres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(204)))), ((int)(((byte)(211)))));
            this.rbtAlquileres.Checked = true;
            this.rbtAlquileres.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.rbtAlquileres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtAlquileres.Image = ((System.Drawing.Image)(resources.GetObject("rbtAlquileres.Image")));
            this.rbtAlquileres.Location = new System.Drawing.Point(0, 145);
            this.rbtAlquileres.Name = "rbtAlquileres";
            this.rbtAlquileres.Size = new System.Drawing.Size(250, 45);
            this.rbtAlquileres.TabIndex = 30;
            this.rbtAlquileres.TabStop = true;
            this.rbtAlquileres.Text = "Alquileres";
            this.rbtAlquileres.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtAlquileres.UseVisualStyleBackColor = false;
            this.rbtAlquileres.Click += new System.EventHandler(this.btnAlquileres_Click);
            // 
            // rbtTasaciones
            // 
            this.rbtTasaciones.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtTasaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(204)))), ((int)(((byte)(211)))));
            this.rbtTasaciones.Enabled = false;
            this.rbtTasaciones.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.rbtTasaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtTasaciones.Image = ((System.Drawing.Image)(resources.GetObject("rbtTasaciones.Image")));
            this.rbtTasaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtTasaciones.Location = new System.Drawing.Point(0, 235);
            this.rbtTasaciones.Name = "rbtTasaciones";
            this.rbtTasaciones.Size = new System.Drawing.Size(250, 45);
            this.rbtTasaciones.TabIndex = 28;
            this.rbtTasaciones.Text = "Tasaciones";
            this.rbtTasaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtTasaciones.UseVisualStyleBackColor = false;
            // 
            // rbtAlqDisponibles
            // 
            this.rbtAlqDisponibles.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtAlqDisponibles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.rbtAlqDisponibles.Enabled = false;
            this.rbtAlqDisponibles.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.rbtAlqDisponibles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtAlqDisponibles.Image = ((System.Drawing.Image)(resources.GetObject("rbtAlqDisponibles.Image")));
            this.rbtAlqDisponibles.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtAlqDisponibles.Location = new System.Drawing.Point(0, 235);
            this.rbtAlqDisponibles.Name = "rbtAlqDisponibles";
            this.rbtAlqDisponibles.Size = new System.Drawing.Size(250, 45);
            this.rbtAlqDisponibles.TabIndex = 26;
            this.rbtAlqDisponibles.Text = "Alquileres Disponibles";
            this.rbtAlqDisponibles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtAlqDisponibles.UseVisualStyleBackColor = false;
            this.rbtAlqDisponibles.Visible = false;
            // 
            // rbtNuevoContrato
            // 
            this.rbtNuevoContrato.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtNuevoContrato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.rbtNuevoContrato.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.rbtNuevoContrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtNuevoContrato.Location = new System.Drawing.Point(0, 235);
            this.rbtNuevoContrato.Name = "rbtNuevoContrato";
            this.rbtNuevoContrato.Size = new System.Drawing.Size(250, 45);
            this.rbtNuevoContrato.TabIndex = 25;
            this.rbtNuevoContrato.Text = "Nuevo Contrato";
            this.rbtNuevoContrato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtNuevoContrato.UseVisualStyleBackColor = false;
            this.rbtNuevoContrato.Visible = false;
            this.rbtNuevoContrato.Click += new System.EventHandler(this.rbtNuevoContrato_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 730);
            this.Controls.Add(this.pnlBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(680, 480);
            this.Name = "Principal";
            this.Text = "Principal";
            this.pnlBase.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSlide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnSlide;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.RadioButton rbtLocadores;
        private System.Windows.Forms.RadioButton rbtVentas;
        private System.Windows.Forms.RadioButton rbtAlqNoVigentes;
        private System.Windows.Forms.RadioButton rbtRegistrarPagos;
        private System.Windows.Forms.RadioButton rbtEstadoCuentas;
        private System.Windows.Forms.RadioButton rbtNuevaProp;
        private System.Windows.Forms.RadioButton rbtVerProp;
        private System.Windows.Forms.RadioButton rbtAdminProp;
        private System.Windows.Forms.RadioButton rbtAdminAlq;
        private System.Windows.Forms.RadioButton rbtAlqVigentes;
        private System.Windows.Forms.RadioButton rbtAlquileres;
        private System.Windows.Forms.RadioButton rbtTasaciones;
        private System.Windows.Forms.RadioButton rbtAlqDisponibles;
        private System.Windows.Forms.RadioButton rbtNuevoContrato;
        private System.Windows.Forms.PictureBox Logo;
    }
}