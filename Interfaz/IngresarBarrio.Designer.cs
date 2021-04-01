namespace Interfaz
{
    partial class IngresarBarrio
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtBarrio = new System.Windows.Forms.TextBox();
            this.btnCargarBarrio = new System.Windows.Forms.Button();
            this.cboPvcia = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboCiudad = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboDepto = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(190)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Location = new System.Drawing.Point(122, 262);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(121, 23);
            this.btnSalir.TabIndex = 73;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtBarrio
            // 
            this.txtBarrio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarrio.Location = new System.Drawing.Point(122, 173);
            this.txtBarrio.Name = "txtBarrio";
            this.txtBarrio.Size = new System.Drawing.Size(121, 20);
            this.txtBarrio.TabIndex = 71;
            // 
            // btnCargarBarrio
            // 
            this.btnCargarBarrio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(134)))), ((int)(((byte)(89)))));
            this.btnCargarBarrio.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCargarBarrio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarBarrio.Location = new System.Drawing.Point(122, 216);
            this.btnCargarBarrio.Name = "btnCargarBarrio";
            this.btnCargarBarrio.Size = new System.Drawing.Size(121, 23);
            this.btnCargarBarrio.TabIndex = 70;
            this.btnCargarBarrio.Text = "Cargar Barrio";
            this.btnCargarBarrio.UseVisualStyleBackColor = false;
            this.btnCargarBarrio.Click += new System.EventHandler(this.btnCargarBarrio_Click);
            // 
            // cboPvcia
            // 
            this.cboPvcia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPvcia.FormattingEnabled = true;
            this.cboPvcia.Location = new System.Drawing.Point(122, 41);
            this.cboPvcia.Name = "cboPvcia";
            this.cboPvcia.Size = new System.Drawing.Size(121, 21);
            this.cboPvcia.TabIndex = 62;
            this.cboPvcia.SelectedIndexChanged += new System.EventHandler(this.cboPvcia_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(52, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 69;
            this.label13.Text = "Provincia:";
            // 
            // cboCiudad
            // 
            this.cboCiudad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCiudad.FormattingEnabled = true;
            this.cboCiudad.Location = new System.Drawing.Point(122, 129);
            this.cboCiudad.Name = "cboCiudad";
            this.cboCiudad.Size = new System.Drawing.Size(121, 21);
            this.cboCiudad.TabIndex = 64;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(63, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 68;
            this.label12.Text = "Ciudad:";
            // 
            // cboDepto
            // 
            this.cboDepto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDepto.FormattingEnabled = true;
            this.cboDepto.Location = new System.Drawing.Point(122, 85);
            this.cboDepto.Name = "cboDepto";
            this.cboDepto.Size = new System.Drawing.Size(121, 21);
            this.cboDepto.TabIndex = 63;
            this.cboDepto.SelectedIndexChanged += new System.EventHandler(this.cboDepto_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 67;
            this.label11.Text = "Departamento:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(69, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 66;
            this.label10.Text = "Barrio:";
            // 
            // IngresarBarrio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(214)))), ((int)(((byte)(199)))));
            this.ClientSize = new System.Drawing.Size(364, 326);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtBarrio);
            this.Controls.Add(this.btnCargarBarrio);
            this.Controls.Add(this.cboPvcia);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cboCiudad);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cboDepto);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IngresarBarrio";
            this.Text = "IngresarBarrio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        public System.Windows.Forms.TextBox txtBarrio;
        private System.Windows.Forms.Button btnCargarBarrio;
        public System.Windows.Forms.ComboBox cboPvcia;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.ComboBox cboCiudad;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.ComboBox cboDepto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}