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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblSaldoCuenta = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rtbNotas = new System.Windows.Forms.RichTextBox();
            this.lblSumatoria = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvAsientoDelDia = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGrabarRegistro = new System.Windows.Forms.Button();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtImporteItem = new System.Windows.Forms.TextBox();
            this.btnQuitarItem = new System.Windows.Forms.Button();
            this.btnAgregarItem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboItemsRecibo = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTipoDNI = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvEstadoDeuda = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientoDelDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadoDeuda)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSaldoCuenta
            // 
            this.lblSaldoCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaldoCuenta.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSaldoCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSaldoCuenta.Location = new System.Drawing.Point(836, 569);
            this.lblSaldoCuenta.Name = "lblSaldoCuenta";
            this.lblSaldoCuenta.Size = new System.Drawing.Size(96, 20);
            this.lblSaldoCuenta.TabIndex = 143;
            this.lblSaldoCuenta.Text = "                             ";
            this.lblSaldoCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(736, 573);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 142;
            this.label4.Text = "Saldo Cuenta $";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(103, 411);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 141;
            this.label9.Text = "Notas:";
            // 
            // rtbNotas
            // 
            this.rtbNotas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbNotas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbNotas.Location = new System.Drawing.Point(106, 427);
            this.rtbNotas.Name = "rtbNotas";
            this.rtbNotas.Size = new System.Drawing.Size(263, 126);
            this.rtbNotas.TabIndex = 127;
            this.rtbNotas.Text = "";
            // 
            // lblSumatoria
            // 
            this.lblSumatoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumatoria.BackColor = System.Drawing.Color.White;
            this.lblSumatoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSumatoria.Location = new System.Drawing.Point(249, 279);
            this.lblSumatoria.Name = "lblSumatoria";
            this.lblSumatoria.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSumatoria.Size = new System.Drawing.Size(120, 20);
            this.lblSumatoria.TabIndex = 140;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(157, 280);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 139;
            this.label12.Text = "Total a pagar: $";
            // 
            // dgvAsientoDelDia
            // 
            this.dgvAsientoDelDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAsientoDelDia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsientoDelDia.BackgroundColor = System.Drawing.Color.White;
            this.dgvAsientoDelDia.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvAsientoDelDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsientoDelDia.Location = new System.Drawing.Point(443, 116);
            this.dgvAsientoDelDia.Name = "dgvAsientoDelDia";
            this.dgvAsientoDelDia.RowHeadersVisible = false;
            this.dgvAsientoDelDia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsientoDelDia.Size = new System.Drawing.Size(489, 182);
            this.dgvAsientoDelDia.TabIndex = 138;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(820, 314);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 23);
            this.btnCancelar.TabIndex = 126;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabarRegistro
            // 
            this.btnGrabarRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabarRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.btnGrabarRegistro.FlatAppearance.BorderSize = 0;
            this.btnGrabarRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabarRegistro.Location = new System.Drawing.Point(703, 314);
            this.btnGrabarRegistro.Name = "btnGrabarRegistro";
            this.btnGrabarRegistro.Size = new System.Drawing.Size(112, 23);
            this.btnGrabarRegistro.TabIndex = 125;
            this.btnGrabarRegistro.Text = "Grabar Registro";
            this.btnGrabarRegistro.UseVisualStyleBackColor = false;
            this.btnGrabarRegistro.Click += new System.EventHandler(this.btnGrabarRegistro_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(173, 199);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 137;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Location = new System.Drawing.Point(249, 197);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(120, 20);
            this.txtDescripcion.TabIndex = 120;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(194, 240);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 136;
            this.label10.Text = "Importe:";
            // 
            // txtImporteItem
            // 
            this.txtImporteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImporteItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImporteItem.Location = new System.Drawing.Point(249, 238);
            this.txtImporteItem.Name = "txtImporteItem";
            this.txtImporteItem.Size = new System.Drawing.Size(120, 20);
            this.txtImporteItem.TabIndex = 121;
            this.txtImporteItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteItem_KeyPress);
            // 
            // btnQuitarItem
            // 
            this.btnQuitarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitarItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.btnQuitarItem.FlatAppearance.BorderSize = 0;
            this.btnQuitarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarItem.Location = new System.Drawing.Point(394, 275);
            this.btnQuitarItem.Name = "btnQuitarItem";
            this.btnQuitarItem.Size = new System.Drawing.Size(43, 23);
            this.btnQuitarItem.TabIndex = 124;
            this.btnQuitarItem.Text = "<<";
            this.btnQuitarItem.UseVisualStyleBackColor = false;
            this.btnQuitarItem.Click += new System.EventHandler(this.btnQuitarItem_Click);
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.btnAgregarItem.FlatAppearance.BorderSize = 0;
            this.btnAgregarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarItem.Location = new System.Drawing.Point(394, 238);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Size = new System.Drawing.Size(43, 23);
            this.btnAgregarItem.TabIndex = 122;
            this.btnAgregarItem.Text = ">>";
            this.btnAgregarItem.UseVisualStyleBackColor = false;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnAgregarItem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 135;
            this.label2.Text = "Item a pagar:";
            // 
            // cboItemsRecibo
            // 
            this.cboItemsRecibo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboItemsRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboItemsRecibo.FormattingEnabled = true;
            this.cboItemsRecibo.Location = new System.Drawing.Point(249, 155);
            this.cboItemsRecibo.Name = "cboItemsRecibo";
            this.cboItemsRecibo.Size = new System.Drawing.Size(120, 21);
            this.cboItemsRecibo.TabIndex = 119;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Location = new System.Drawing.Point(812, 72);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(120, 20);
            this.txtNombre.TabIndex = 132;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtApellido
            // 
            this.txtApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Location = new System.Drawing.Point(622, 72);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(120, 20);
            this.txtApellido.TabIndex = 131;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(569, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 134;
            this.label8.Text = "Apellido:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(759, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 133;
            this.label7.Text = "Nombre:";
            // 
            // cboTipoDNI
            // 
            this.cboTipoDNI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoDNI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoDNI.FormattingEnabled = true;
            this.cboTipoDNI.Location = new System.Drawing.Point(249, 113);
            this.cboTipoDNI.Name = "cboTipoDNI";
            this.cboTipoDNI.Size = new System.Drawing.Size(120, 21);
            this.cboTipoDNI.TabIndex = 118;
            this.cboTipoDNI.SelectedIndexChanged += new System.EventHandler(this.cboTipoDNI_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 130;
            this.label1.Text = "Tipo D.N.I.:";
            // 
            // txtDni
            // 
            this.txtDni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDni.Location = new System.Drawing.Point(249, 72);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(120, 20);
            this.txtDni.TabIndex = 117;
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_KeyPress);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(201, 76);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 129;
            this.label16.Text = "D.N.I.:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(812, 25);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(120, 20);
            this.dtpFecha.TabIndex = 123;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(766, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 128;
            this.label3.Text = "Fecha:";
            // 
            // dgvEstadoDeuda
            // 
            this.dgvEstadoDeuda.AllowUserToAddRows = false;
            this.dgvEstadoDeuda.AllowUserToDeleteRows = false;
            this.dgvEstadoDeuda.AllowUserToResizeColumns = false;
            this.dgvEstadoDeuda.AllowUserToResizeRows = false;
            this.dgvEstadoDeuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEstadoDeuda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstadoDeuda.BackgroundColor = System.Drawing.Color.White;
            this.dgvEstadoDeuda.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEstadoDeuda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvEstadoDeuda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstadoDeuda.Location = new System.Drawing.Point(443, 427);
            this.dgvEstadoDeuda.MultiSelect = false;
            this.dgvEstadoDeuda.Name = "dgvEstadoDeuda";
            this.dgvEstadoDeuda.RowHeadersVisible = false;
            this.dgvEstadoDeuda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstadoDeuda.Size = new System.Drawing.Size(489, 126);
            this.dgvEstadoDeuda.TabIndex = 116;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(440, 411);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 144;
            this.label5.Text = "Estado de cuenta:";
            // 
            // EstadoDeCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(214)))), ((int)(((byte)(199)))));
            this.ClientSize = new System.Drawing.Size(1034, 612);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSaldoCuenta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rtbNotas);
            this.Controls.Add(this.lblSumatoria);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dgvAsientoDelDia);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabarRegistro);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtImporteItem);
            this.Controls.Add(this.btnQuitarItem);
            this.Controls.Add(this.btnAgregarItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboItemsRecibo);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboTipoDNI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvEstadoDeuda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EstadoDeCuentas";
            this.Text = "EstadoDeCuentas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsientoDelDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadoDeuda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSaldoCuenta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox rtbNotas;
        private System.Windows.Forms.Label lblSumatoria;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvAsientoDelDia;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGrabarRegistro;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtImporteItem;
        private System.Windows.Forms.Button btnQuitarItem;
        private System.Windows.Forms.Button btnAgregarItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboItemsRecibo;
        public System.Windows.Forms.TextBox txtNombre;
        public System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox cboTipoDNI;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvEstadoDeuda;
        private System.Windows.Forms.Label label5;
    }
}