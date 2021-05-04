namespace Interfaz
{
    partial class AlquileresNoVigentes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBase = new System.Windows.Forms.Panel();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnEstadoCuenta = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAlquilerNoV = new System.Windows.Forms.TextBox();
            this.rtbNotas = new System.Windows.Forms.RichTextBox();
            this.dtpUltimoPago = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFinContrato = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreNoV = new System.Windows.Forms.TextBox();
            this.txtApellidoNoV = new System.Windows.Forms.TextBox();
            this.dgvAlquileresNoV = new System.Windows.Forms.DataGridView();
            this.bntBuscarAlquiler = new System.Windows.Forms.Button();
            this.pnlBase.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlquileresNoV)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(214)))), ((int)(((byte)(199)))));
            this.pnlBase.Controls.Add(this.pnlDatos);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Controls.Add(this.txtNombreNoV);
            this.pnlBase.Controls.Add(this.txtApellidoNoV);
            this.pnlBase.Controls.Add(this.dgvAlquileresNoV);
            this.pnlBase.Controls.Add(this.bntBuscarAlquiler);
            this.pnlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBase.Location = new System.Drawing.Point(0, 0);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(1050, 650);
            this.pnlBase.TabIndex = 0;
            // 
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.pnlDatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlDatos.Controls.Add(this.txtApellido);
            this.pnlDatos.Controls.Add(this.txtNombre);
            this.pnlDatos.Controls.Add(this.btnEstadoCuenta);
            this.pnlDatos.Controls.Add(this.label10);
            this.pnlDatos.Controls.Add(this.txtAlquilerNoV);
            this.pnlDatos.Controls.Add(this.rtbNotas);
            this.pnlDatos.Controls.Add(this.dtpUltimoPago);
            this.pnlDatos.Controls.Add(this.label4);
            this.pnlDatos.Controls.Add(this.label9);
            this.pnlDatos.Controls.Add(this.label3);
            this.pnlDatos.Controls.Add(this.dtpFinContrato);
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Location = new System.Drawing.Point(710, 90);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(319, 541);
            this.pnlDatos.TabIndex = 65;
            // 
            // txtApellido
            // 
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(207, 11);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 24;
            this.txtApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(207, 55);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 23;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnEstadoCuenta
            // 
            this.btnEstadoCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(103)))), ((int)(((byte)(125)))));
            this.btnEstadoCuenta.FlatAppearance.BorderSize = 0;
            this.btnEstadoCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadoCuenta.Location = new System.Drawing.Point(107, 487);
            this.btnEstadoCuenta.Name = "btnEstadoCuenta";
            this.btnEstadoCuenta.Size = new System.Drawing.Size(200, 40);
            this.btnEstadoCuenta.TabIndex = 0;
            this.btnEstadoCuenta.Text = "Estado de Cuenta / Comprobantes";
            this.btnEstadoCuenta.UseVisualStyleBackColor = false;
            this.btnEstadoCuenta.Click += new System.EventHandler(this.btnEstadoCuenta_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(152, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Alquiler:";
            // 
            // txtAlquilerNoV
            // 
            this.txtAlquilerNoV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlquilerNoV.Location = new System.Drawing.Point(207, 99);
            this.txtAlquilerNoV.Name = "txtAlquilerNoV";
            this.txtAlquilerNoV.Size = new System.Drawing.Size(100, 20);
            this.txtAlquilerNoV.TabIndex = 20;
            this.txtAlquilerNoV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rtbNotas
            // 
            this.rtbNotas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbNotas.Enabled = false;
            this.rtbNotas.Location = new System.Drawing.Point(7, 231);
            this.rtbNotas.Name = "rtbNotas";
            this.rtbNotas.Size = new System.Drawing.Size(300, 132);
            this.rtbNotas.TabIndex = 14;
            this.rtbNotas.Text = "";
            // 
            // dtpUltimoPago
            // 
            this.dtpUltimoPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpUltimoPago.Location = new System.Drawing.Point(207, 143);
            this.dtpUltimoPago.Name = "dtpUltimoPago";
            this.dtpUltimoPago.Size = new System.Drawing.Size(100, 20);
            this.dtpUltimoPago.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Último pago:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Notas:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Datos Locatario:";
            // 
            // dtpFinContrato
            // 
            this.dtpFinContrato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinContrato.Location = new System.Drawing.Point(207, 187);
            this.dtpFinContrato.Name = "dtpFinContrato";
            this.dtpFinContrato.Size = new System.Drawing.Size(100, 20);
            this.dtpFinContrato.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(115, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Venc. Contrato:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Apellido:";
            // 
            // txtNombreNoV
            // 
            this.txtNombreNoV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreNoV.Location = new System.Drawing.Point(306, 57);
            this.txtNombreNoV.Name = "txtNombreNoV";
            this.txtNombreNoV.Size = new System.Drawing.Size(140, 20);
            this.txtNombreNoV.TabIndex = 1;
            this.txtNombreNoV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNombreNoV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreV_KeyPress);
            // 
            // txtApellidoNoV
            // 
            this.txtApellidoNoV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidoNoV.Location = new System.Drawing.Point(95, 57);
            this.txtApellidoNoV.Name = "txtApellidoNoV";
            this.txtApellidoNoV.Size = new System.Drawing.Size(140, 20);
            this.txtApellidoNoV.TabIndex = 0;
            this.txtApellidoNoV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtApellidoNoV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidoV_KeyPress);
            // 
            // dgvAlquileresNoV
            // 
            this.dgvAlquileresNoV.AllowUserToAddRows = false;
            this.dgvAlquileresNoV.AllowUserToDeleteRows = false;
            this.dgvAlquileresNoV.AllowUserToResizeRows = false;
            this.dgvAlquileresNoV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAlquileresNoV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlquileresNoV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlquileresNoV.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAlquileresNoV.Location = new System.Drawing.Point(36, 90);
            this.dgvAlquileresNoV.Name = "dgvAlquileresNoV";
            this.dgvAlquileresNoV.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlquileresNoV.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAlquileresNoV.RowHeadersVisible = false;
            this.dgvAlquileresNoV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlquileresNoV.Size = new System.Drawing.Size(668, 541);
            this.dgvAlquileresNoV.TabIndex = 60;
            this.dgvAlquileresNoV.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAlquileresNoV_CellMouseClick);
            this.dgvAlquileresNoV.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAlquileresNoV_CellMouseDoubleClick);
            this.dgvAlquileresNoV.SelectionChanged += new System.EventHandler(this.dgvAlquileresNoV_SelectionChanged);
            // 
            // bntBuscarAlquiler
            // 
            this.bntBuscarAlquiler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntBuscarAlquiler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.bntBuscarAlquiler.FlatAppearance.BorderSize = 0;
            this.bntBuscarAlquiler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntBuscarAlquiler.Location = new System.Drawing.Point(555, 55);
            this.bntBuscarAlquiler.Name = "bntBuscarAlquiler";
            this.bntBuscarAlquiler.Size = new System.Drawing.Size(149, 23);
            this.bntBuscarAlquiler.TabIndex = 2;
            this.bntBuscarAlquiler.Text = "Buscar Alquiler";
            this.bntBuscarAlquiler.UseVisualStyleBackColor = false;
            this.bntBuscarAlquiler.Click += new System.EventHandler(this.bntBuscarAlquiler_Click);
            // 
            // AlquileresNoVigentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 650);
            this.Controls.Add(this.pnlBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AlquileresNoVigentes";
            this.Text = "AlquileresNoVigentes";
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlquileresNoV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnEstadoCuenta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAlquilerNoV;
        private System.Windows.Forms.RichTextBox rtbNotas;
        private System.Windows.Forms.DateTimePicker dtpUltimoPago;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFinContrato;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreNoV;
        private System.Windows.Forms.TextBox txtApellidoNoV;
        private System.Windows.Forms.DataGridView dgvAlquileresNoV;
        private System.Windows.Forms.Button bntBuscarAlquiler;
    }
}