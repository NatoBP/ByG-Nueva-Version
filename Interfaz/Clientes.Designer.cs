namespace Interfaz
{
    partial class Clientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clientes));
            this.pnlBase = new System.Windows.Forms.Panel();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.label75 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.dgvTelefonos = new System.Windows.Forms.DataGridView();
            this.cboTipoDNI = new System.Windows.Forms.ComboBox();
            this.txtCodArea = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboBarrio = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCargarBarrio = new System.Windows.Forms.Button();
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.cboCiudad = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnBorrarTelefono = new System.Windows.Forms.Button();
            this.btnCargarTelefono = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelefonos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBase.Controls.Add(this.txtDepto);
            this.pnlBase.Controls.Add(this.txtPiso);
            this.pnlBase.Controls.Add(this.label75);
            this.pnlBase.Controls.Add(this.label72);
            this.pnlBase.Controls.Add(this.pictureBox1);
            this.pnlBase.Controls.Add(this.btnCancelar);
            this.pnlBase.Controls.Add(this.txtApellido);
            this.pnlBase.Controls.Add(this.dgvTelefonos);
            this.pnlBase.Controls.Add(this.cboTipoDNI);
            this.pnlBase.Controls.Add(this.txtCodArea);
            this.pnlBase.Controls.Add(this.label10);
            this.pnlBase.Controls.Add(this.label5);
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Controls.Add(this.label7);
            this.pnlBase.Controls.Add(this.btnEditar);
            this.pnlBase.Controls.Add(this.txtAltura);
            this.pnlBase.Controls.Add(this.txtTelefono);
            this.pnlBase.Controls.Add(this.btnGuardar);
            this.pnlBase.Controls.Add(this.cboProvincia);
            this.pnlBase.Controls.Add(this.label3);
            this.pnlBase.Controls.Add(this.label12);
            this.pnlBase.Controls.Add(this.cboBarrio);
            this.pnlBase.Controls.Add(this.label8);
            this.pnlBase.Controls.Add(this.txtNombre);
            this.pnlBase.Controls.Add(this.label6);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Controls.Add(this.btnCargarBarrio);
            this.pnlBase.Controls.Add(this.cboDepartamento);
            this.pnlBase.Controls.Add(this.txtDireccion);
            this.pnlBase.Controls.Add(this.txtMail);
            this.pnlBase.Controls.Add(this.cboCiudad);
            this.pnlBase.Controls.Add(this.label13);
            this.pnlBase.Controls.Add(this.btnBorrarTelefono);
            this.pnlBase.Controls.Add(this.btnCargarTelefono);
            this.pnlBase.Controls.Add(this.label11);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.txtDNI);
            this.pnlBase.Location = new System.Drawing.Point(0, 0);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(1050, 650);
            this.pnlBase.TabIndex = 0;
            // 
            // txtDepto
            // 
            this.txtDepto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepto.Location = new System.Drawing.Point(657, 357);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(34, 20);
            this.txtDepto.TabIndex = 360;
            this.txtDepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepto_KeyPress);
            // 
            // txtPiso
            // 
            this.txtPiso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPiso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPiso.Location = new System.Drawing.Point(570, 357);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(34, 20);
            this.txtPiso.TabIndex = 359;
            this.txtPiso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPiso_KeyPress);
            // 
            // label75
            // 
            this.label75.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(609, 360);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(42, 13);
            this.label75.TabIndex = 389;
            this.label75.Text = "Depto.:";
            // 
            // label72
            // 
            this.label72.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(502, 360);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(30, 13);
            this.label72.TabIndex = 388;
            this.label72.Text = "Piso:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 248);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(410, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 387;
            this.pictureBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(869, 598);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(119, 23);
            this.btnCancelar.TabIndex = 373;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtApellido
            // 
            this.txtApellido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Location = new System.Drawing.Point(570, 178);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(121, 20);
            this.txtApellido.TabIndex = 355;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress_1);
            // 
            // dgvTelefonos
            // 
            this.dgvTelefonos.AllowUserToAddRows = false;
            this.dgvTelefonos.AllowUserToDeleteRows = false;
            this.dgvTelefonos.AllowUserToResizeRows = false;
            this.dgvTelefonos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvTelefonos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTelefonos.BackgroundColor = System.Drawing.Color.White;
            this.dgvTelefonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTelefonos.GridColor = System.Drawing.Color.White;
            this.dgvTelefonos.Location = new System.Drawing.Point(803, 163);
            this.dgvTelefonos.Name = "dgvTelefonos";
            this.dgvTelefonos.ReadOnly = true;
            this.dgvTelefonos.RowHeadersVisible = false;
            this.dgvTelefonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTelefonos.Size = new System.Drawing.Size(185, 81);
            this.dgvTelefonos.TabIndex = 386;
            // 
            // cboTipoDNI
            // 
            this.cboTipoDNI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboTipoDNI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.cboTipoDNI.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboTipoDNI.FormattingEnabled = true;
            this.cboTipoDNI.Location = new System.Drawing.Point(570, 135);
            this.cboTipoDNI.Name = "cboTipoDNI";
            this.cboTipoDNI.Size = new System.Drawing.Size(121, 21);
            this.cboTipoDNI.TabIndex = 354;
            this.cboTipoDNI.SelectedIndexChanged += new System.EventHandler(this.cboTipoDNI_SelectedIndexChanged);
            // 
            // txtCodArea
            // 
            this.txtCodArea.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCodArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodArea.Location = new System.Drawing.Point(803, 135);
            this.txtCodArea.Name = "txtCodArea";
            this.txtCodArea.Size = new System.Drawing.Size(49, 20);
            this.txtCodArea.TabIndex = 367;
            this.txtCodArea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodArea_KeyPress_1);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(509, 541);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 382;
            this.label10.Text = "Barrio";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(719, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 378;
            this.label5.Text = "Teléfonos:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(496, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 377;
            this.label4.Text = "Nombre:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(506, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 380;
            this.label7.Text = "Altura:";
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.btnEditar.Enabled = false;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Location = new System.Drawing.Point(869, 354);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(119, 23);
            this.btnEditar.TabIndex = 371;
            this.btnEditar.Text = "Editar Datos";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // txtAltura
            // 
            this.txtAltura.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAltura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAltura.Location = new System.Drawing.Point(570, 310);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(121, 20);
            this.txtAltura.TabIndex = 358;
            this.txtAltura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAltura_KeyPress_1);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Location = new System.Drawing.Point(858, 135);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(130, 20);
            this.txtTelefono.TabIndex = 368;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress_1);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(869, 536);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(119, 23);
            this.btnGuardar.TabIndex = 372;
            this.btnGuardar.Text = "Guardar Persona";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cboProvincia
            // 
            this.cboProvincia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboProvincia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.cboProvincia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(570, 409);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(121, 21);
            this.cboProvincia.TabIndex = 361;
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(this.cboProvincia_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(496, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 376;
            this.label3.Text = "Apellido:";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(503, 498);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 384;
            this.label12.Text = "Ciudad";
            // 
            // cboBarrio
            // 
            this.cboBarrio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboBarrio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.cboBarrio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboBarrio.FormattingEnabled = true;
            this.cboBarrio.Location = new System.Drawing.Point(570, 538);
            this.cboBarrio.Name = "cboBarrio";
            this.cboBarrio.Size = new System.Drawing.Size(121, 21);
            this.cboBarrio.TabIndex = 364;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(738, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 381;
            this.label8.Text = "e-Mail:";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Location = new System.Drawing.Point(570, 221);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 356;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress_1);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(488, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 379;
            this.label6.Text = "Dirección:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(506, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 374;
            this.label1.Text = "D.N.I.:";
            // 
            // btnCargarBarrio
            // 
            this.btnCargarBarrio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCargarBarrio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.btnCargarBarrio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarBarrio.Location = new System.Drawing.Point(697, 536);
            this.btnCargarBarrio.Name = "btnCargarBarrio";
            this.btnCargarBarrio.Size = new System.Drawing.Size(121, 23);
            this.btnCargarBarrio.TabIndex = 365;
            this.btnCargarBarrio.Text = "Ingresar Barrio";
            this.btnCargarBarrio.UseVisualStyleBackColor = false;
            this.btnCargarBarrio.Click += new System.EventHandler(this.btnCargarBarrio_Click);
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboDepartamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.cboDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(570, 452);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(121, 21);
            this.cboDepartamento.TabIndex = 362;
            this.cboDepartamento.SelectedIndexChanged += new System.EventHandler(this.cboDepartamento_SelectedIndexChanged);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Location = new System.Drawing.Point(570, 267);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(121, 20);
            this.txtDireccion.TabIndex = 357;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress_1);
            // 
            // txtMail
            // 
            this.txtMail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMail.Location = new System.Drawing.Point(803, 92);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(185, 20);
            this.txtMail.TabIndex = 366;
            this.txtMail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMail_KeyPress);
            // 
            // cboCiudad
            // 
            this.cboCiudad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboCiudad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.cboCiudad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboCiudad.FormattingEnabled = true;
            this.cboCiudad.Location = new System.Drawing.Point(570, 495);
            this.cboCiudad.Name = "cboCiudad";
            this.cboCiudad.Size = new System.Drawing.Size(121, 21);
            this.cboCiudad.TabIndex = 363;
            this.cboCiudad.SelectedIndexChanged += new System.EventHandler(this.cboCiudad_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(492, 412);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 385;
            this.label13.Text = "Provincia";
            // 
            // btnBorrarTelefono
            // 
            this.btnBorrarTelefono.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBorrarTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.btnBorrarTelefono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarTelefono.Location = new System.Drawing.Point(869, 308);
            this.btnBorrarTelefono.Name = "btnBorrarTelefono";
            this.btnBorrarTelefono.Size = new System.Drawing.Size(119, 23);
            this.btnBorrarTelefono.TabIndex = 370;
            this.btnBorrarTelefono.Text = "Borrar Teléfono";
            this.btnBorrarTelefono.UseVisualStyleBackColor = false;
            this.btnBorrarTelefono.Click += new System.EventHandler(this.btnBorrarTelefono_Click);
            // 
            // btnCargarTelefono
            // 
            this.btnCargarTelefono.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCargarTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.btnCargarTelefono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarTelefono.Location = new System.Drawing.Point(869, 260);
            this.btnCargarTelefono.Name = "btnCargarTelefono";
            this.btnCargarTelefono.Size = new System.Drawing.Size(119, 23);
            this.btnCargarTelefono.TabIndex = 369;
            this.btnCargarTelefono.Text = "Cargar Teléfono";
            this.btnCargarTelefono.UseVisualStyleBackColor = false;
            this.btnCargarTelefono.Click += new System.EventHandler(this.btnCargarTelefono_Click);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(469, 455);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 383;
            this.label11.Text = "Departamento";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(512, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 375;
            this.label2.Text = "Tipo:";
            // 
            // txtDNI
            // 
            this.txtDNI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDNI.Location = new System.Drawing.Point(570, 92);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(121, 20);
            this.txtDNI.TabIndex = 353;
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNI_KeyPress_1);
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(214)))), ((int)(((byte)(199)))));
            this.ClientSize = new System.Drawing.Size(1050, 650);
            this.Controls.Add(this.pnlBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Clientes";
            this.Text = "Clientes";
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelefonos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.TextBox txtApellido;
        public System.Windows.Forms.DataGridView dgvTelefonos;
        public System.Windows.Forms.ComboBox cboTipoDNI;
        public System.Windows.Forms.TextBox txtCodArea;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEditar;
        public System.Windows.Forms.TextBox txtAltura;
        public System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.ComboBox cboBarrio;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCargarBarrio;
        public System.Windows.Forms.ComboBox cboDepartamento;
        public System.Windows.Forms.TextBox txtDireccion;
        public System.Windows.Forms.TextBox txtMail;
        public System.Windows.Forms.ComboBox cboCiudad;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnBorrarTelefono;
        private System.Windows.Forms.Button btnCargarTelefono;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtDNI;
    }
}