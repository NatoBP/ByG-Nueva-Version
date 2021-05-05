namespace Interfaz
{
    partial class EstadoDeCuentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtImporteItem = new System.Windows.Forms.TextBox();
            this.btnQuitarItem = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAgregarItem = new System.Windows.Forms.Button();
            this.lblSumatoria = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbNotas = new System.Windows.Forms.RichTextBox();
            this.cboItemsRecibo = new System.Windows.Forms.ComboBox();
            this.btnGrabarRegistro = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvAsientoDelDia = new System.Windows.Forms.DataGridView();
            this.grpAsiento = new System.Windows.Forms.GroupBox();
            this.dgvEstadoDeuda = new System.Windows.Forms.DataGridView();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cboTipoDNI = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSaldoCuenta = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.grpEstado = new System.Windows.Forms.GroupBox();
            this.cboOperacion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientoDelDia)).BeginInit();
            this.grpAsiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadoDeuda)).BeginInit();
            this.grpEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(893, 612);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 23);
            this.btnCancelar.TabIndex = 126;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(199, 118);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 137;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Location = new System.Drawing.Point(275, 116);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(90, 20);
            this.txtDescripcion.TabIndex = 120;
            this.txtDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(220, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 136;
            this.label10.Text = "Importe:";
            // 
            // txtImporteItem
            // 
            this.txtImporteItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImporteItem.ForeColor = System.Drawing.Color.Red;
            this.txtImporteItem.Location = new System.Drawing.Point(275, 157);
            this.txtImporteItem.Name = "txtImporteItem";
            this.txtImporteItem.Size = new System.Drawing.Size(90, 20);
            this.txtImporteItem.TabIndex = 121;
            this.txtImporteItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporteItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteItem_KeyPress);
            // 
            // btnQuitarItem
            // 
            this.btnQuitarItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.btnQuitarItem.FlatAppearance.BorderSize = 0;
            this.btnQuitarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarItem.Location = new System.Drawing.Point(455, 74);
            this.btnQuitarItem.Name = "btnQuitarItem";
            this.btnQuitarItem.Size = new System.Drawing.Size(40, 23);
            this.btnQuitarItem.TabIndex = 124;
            this.btnQuitarItem.Text = "<<";
            this.btnQuitarItem.UseVisualStyleBackColor = false;
            this.btnQuitarItem.Click += new System.EventHandler(this.btnQuitarItem_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(807, 246);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 139;
            this.label12.Text = "Total a pagar: $";
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.btnAgregarItem.FlatAppearance.BorderSize = 0;
            this.btnAgregarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarItem.Location = new System.Drawing.Point(455, 32);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Size = new System.Drawing.Size(40, 23);
            this.btnAgregarItem.TabIndex = 122;
            this.btnAgregarItem.Text = ">>";
            this.btnAgregarItem.UseVisualStyleBackColor = false;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnAgregarItem_Click);
            // 
            // lblSumatoria
            // 
            this.lblSumatoria.BackColor = System.Drawing.Color.LightGray;
            this.lblSumatoria.Enabled = false;
            this.lblSumatoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSumatoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumatoria.Location = new System.Drawing.Point(911, 242);
            this.lblSumatoria.Name = "lblSumatoria";
            this.lblSumatoria.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSumatoria.Size = new System.Drawing.Size(80, 20);
            this.lblSumatoria.TabIndex = 140;
            this.lblSumatoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 135;
            this.label2.Text = "Item a cargar:";
            // 
            // rtbNotas
            // 
            this.rtbNotas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbNotas.Location = new System.Drawing.Point(105, 208);
            this.rtbNotas.Name = "rtbNotas";
            this.rtbNotas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtbNotas.Size = new System.Drawing.Size(260, 105);
            this.rtbNotas.TabIndex = 127;
            this.rtbNotas.Text = "";
            // 
            // cboItemsRecibo
            // 
            this.cboItemsRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboItemsRecibo.FormattingEnabled = true;
            this.cboItemsRecibo.Location = new System.Drawing.Point(275, 74);
            this.cboItemsRecibo.Name = "cboItemsRecibo";
            this.cboItemsRecibo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboItemsRecibo.Size = new System.Drawing.Size(90, 21);
            this.cboItemsRecibo.TabIndex = 119;
            this.cboItemsRecibo.SelectedIndexChanged += new System.EventHandler(this.cboItemsRecibo_SelectedIndexChanged);
            // 
            // btnGrabarRegistro
            // 
            this.btnGrabarRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.btnGrabarRegistro.FlatAppearance.BorderSize = 0;
            this.btnGrabarRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabarRegistro.Location = new System.Drawing.Point(873, 290);
            this.btnGrabarRegistro.Name = "btnGrabarRegistro";
            this.btnGrabarRegistro.Size = new System.Drawing.Size(120, 23);
            this.btnGrabarRegistro.TabIndex = 125;
            this.btnGrabarRegistro.Text = "Guardar / Imprimir";
            this.btnGrabarRegistro.UseVisualStyleBackColor = false;
            this.btnGrabarRegistro.Click += new System.EventHandler(this.btnGrabarRegistro_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(58, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 141;
            this.label9.Text = "Notas:";
            // 
            // dgvAsientoDelDia
            // 
            this.dgvAsientoDelDia.AllowUserToAddRows = false;
            this.dgvAsientoDelDia.AllowUserToDeleteRows = false;
            this.dgvAsientoDelDia.AllowUserToResizeColumns = false;
            this.dgvAsientoDelDia.AllowUserToResizeRows = false;
            this.dgvAsientoDelDia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsientoDelDia.BackgroundColor = System.Drawing.Color.White;
            this.dgvAsientoDelDia.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsientoDelDia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAsientoDelDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsientoDelDia.Location = new System.Drawing.Point(501, 32);
            this.dgvAsientoDelDia.MultiSelect = false;
            this.dgvAsientoDelDia.Name = "dgvAsientoDelDia";
            this.dgvAsientoDelDia.ReadOnly = true;
            this.dgvAsientoDelDia.RowHeadersVisible = false;
            this.dgvAsientoDelDia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsientoDelDia.Size = new System.Drawing.Size(490, 204);
            this.dgvAsientoDelDia.TabIndex = 138;
            // 
            // grpAsiento
            // 
            this.grpAsiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAsiento.Controls.Add(this.label6);
            this.grpAsiento.Controls.Add(this.cboOperacion);
            this.grpAsiento.Controls.Add(this.dgvAsientoDelDia);
            this.grpAsiento.Controls.Add(this.label9);
            this.grpAsiento.Controls.Add(this.btnGrabarRegistro);
            this.grpAsiento.Controls.Add(this.cboItemsRecibo);
            this.grpAsiento.Controls.Add(this.rtbNotas);
            this.grpAsiento.Controls.Add(this.label2);
            this.grpAsiento.Controls.Add(this.lblSumatoria);
            this.grpAsiento.Controls.Add(this.btnAgregarItem);
            this.grpAsiento.Controls.Add(this.label12);
            this.grpAsiento.Controls.Add(this.btnQuitarItem);
            this.grpAsiento.Controls.Add(this.txtImporteItem);
            this.grpAsiento.Controls.Add(this.label10);
            this.grpAsiento.Controls.Add(this.txtDescripcion);
            this.grpAsiento.Controls.Add(this.lblDescripcion);
            this.grpAsiento.Location = new System.Drawing.Point(20, 265);
            this.grpAsiento.Name = "grpAsiento";
            this.grpAsiento.Size = new System.Drawing.Size(1010, 330);
            this.grpAsiento.TabIndex = 146;
            this.grpAsiento.TabStop = false;
            this.grpAsiento.Text = "Asiento del día:";
            // 
            // dgvEstadoDeuda
            // 
            this.dgvEstadoDeuda.AllowUserToAddRows = false;
            this.dgvEstadoDeuda.AllowUserToDeleteRows = false;
            this.dgvEstadoDeuda.AllowUserToResizeColumns = false;
            this.dgvEstadoDeuda.AllowUserToResizeRows = false;
            this.dgvEstadoDeuda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstadoDeuda.BackgroundColor = System.Drawing.Color.White;
            this.dgvEstadoDeuda.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEstadoDeuda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEstadoDeuda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstadoDeuda.Location = new System.Drawing.Point(503, 50);
            this.dgvEstadoDeuda.MultiSelect = false;
            this.dgvEstadoDeuda.Name = "dgvEstadoDeuda";
            this.dgvEstadoDeuda.ReadOnly = true;
            this.dgvEstadoDeuda.RowHeadersVisible = false;
            this.dgvEstadoDeuda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstadoDeuda.Size = new System.Drawing.Size(490, 150);
            this.dgvEstadoDeuda.TabIndex = 116;
            this.dgvEstadoDeuda.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEstadoDeuda_CellMouseClick);
            this.dgvEstadoDeuda.SelectionChanged += new System.EventHandler(this.dgvEstadoDeuda_SelectionChanged);
            // 
            // txtApellido
            // 
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Location = new System.Drawing.Point(275, 137);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(90, 20);
            this.txtApellido.TabIndex = 131;
            this.txtApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(222, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 134;
            this.label8.Text = "Apellido:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(222, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 133;
            this.label7.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Location = new System.Drawing.Point(275, 180);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(90, 20);
            this.txtNombre.TabIndex = 132;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // cboTipoDNI
            // 
            this.cboTipoDNI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoDNI.FormattingEnabled = true;
            this.cboTipoDNI.Location = new System.Drawing.Point(275, 93);
            this.cboTipoDNI.Name = "cboTipoDNI";
            this.cboTipoDNI.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboTipoDNI.Size = new System.Drawing.Size(90, 21);
            this.cboTipoDNI.TabIndex = 118;
            this.cboTipoDNI.SelectedIndexChanged += new System.EventHandler(this.cboTipoDNI_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(810, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 142;
            this.label4.Text = "Saldo cuenta: $";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 130;
            this.label1.Text = "Tipo D.N.I.:";
            // 
            // lblSaldoCuenta
            // 
            this.lblSaldoCuenta.BackColor = System.Drawing.Color.LightGray;
            this.lblSaldoCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoCuenta.Location = new System.Drawing.Point(913, 207);
            this.lblSaldoCuenta.Name = "lblSaldoCuenta";
            this.lblSaldoCuenta.Size = new System.Drawing.Size(80, 20);
            this.lblSaldoCuenta.TabIndex = 143;
            this.lblSaldoCuenta.Text = "                             ";
            this.lblSaldoCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(177, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 13);
            this.label16.TabIndex = 129;
            this.label16.Text = "Buscar por D.N.I.:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(501, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 144;
            this.label5.Text = "Estado de cuenta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(847, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 128;
            this.label3.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(893, 21);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(100, 20);
            this.dtpFecha.TabIndex = 123;
            // 
            // txtDni
            // 
            this.txtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDni.Location = new System.Drawing.Point(275, 50);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(90, 20);
            this.txtDni.TabIndex = 117;
            this.txtDni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_KeyPress);
            // 
            // grpEstado
            // 
            this.grpEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEstado.Controls.Add(this.txtDni);
            this.grpEstado.Controls.Add(this.dtpFecha);
            this.grpEstado.Controls.Add(this.label3);
            this.grpEstado.Controls.Add(this.label5);
            this.grpEstado.Controls.Add(this.label16);
            this.grpEstado.Controls.Add(this.lblSaldoCuenta);
            this.grpEstado.Controls.Add(this.label1);
            this.grpEstado.Controls.Add(this.label4);
            this.grpEstado.Controls.Add(this.cboTipoDNI);
            this.grpEstado.Controls.Add(this.txtNombre);
            this.grpEstado.Controls.Add(this.label7);
            this.grpEstado.Controls.Add(this.label8);
            this.grpEstado.Controls.Add(this.txtApellido);
            this.grpEstado.Controls.Add(this.dgvEstadoDeuda);
            this.grpEstado.Location = new System.Drawing.Point(20, 20);
            this.grpEstado.Name = "grpEstado";
            this.grpEstado.Size = new System.Drawing.Size(1010, 235);
            this.grpEstado.TabIndex = 145;
            this.grpEstado.TabStop = false;
            this.grpEstado.Text = "Estado de Cuenta:";
            // 
            // cboOperacion
            // 
            this.cboOperacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboOperacion.FormattingEnabled = true;
            this.cboOperacion.Items.AddRange(new object[] {
            "Comprobante",
            "Cargar Deuda"});
            this.cboOperacion.Location = new System.Drawing.Point(275, 32);
            this.cboOperacion.Name = "cboOperacion";
            this.cboOperacion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboOperacion.Size = new System.Drawing.Size(90, 21);
            this.cboOperacion.TabIndex = 142;
            this.cboOperacion.SelectedIndexChanged += new System.EventHandler(this.cboOperacion_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(206, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 143;
            this.label6.Text = "Operación:";
            // 
            // EstadoDeCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(214)))), ((int)(((byte)(199)))));
            this.ClientSize = new System.Drawing.Size(1050, 650);
            this.Controls.Add(this.grpEstado);
            this.Controls.Add(this.grpAsiento);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EstadoDeCuentas";
            this.Text = "EstadoDeCuentas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientoDelDia)).EndInit();
            this.grpAsiento.ResumeLayout(false);
            this.grpAsiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadoDeuda)).EndInit();
            this.grpEstado.ResumeLayout(false);
            this.grpEstado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtImporteItem;
        private System.Windows.Forms.Button btnQuitarItem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAgregarItem;
        private System.Windows.Forms.Label lblSumatoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbNotas;
        private System.Windows.Forms.ComboBox cboItemsRecibo;
        private System.Windows.Forms.Button btnGrabarRegistro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvAsientoDelDia;
        private System.Windows.Forms.GroupBox grpAsiento;
        private System.Windows.Forms.DataGridView dgvEstadoDeuda;
        public System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtNombre;
        public System.Windows.Forms.ComboBox cboTipoDNI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSaldoCuenta;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker dtpFecha;
        public System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.GroupBox grpEstado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboOperacion;
    }
}