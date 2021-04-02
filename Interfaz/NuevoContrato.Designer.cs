namespace Interfaz
{
    partial class NuevoContrato
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
            this.pnlBase = new System.Windows.Forms.Panel();
            this.pnlLocador = new System.Windows.Forms.Panel();
            this.pnlLocatario = new System.Windows.Forms.Panel();
            this.pnlGarantes = new System.Windows.Forms.Panel();
            this.pnlContrato = new System.Windows.Forms.Panel();
            this.pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.pnlContrato);
            this.pnlBase.Controls.Add(this.pnlGarantes);
            this.pnlBase.Controls.Add(this.pnlLocatario);
            this.pnlBase.Controls.Add(this.pnlLocador);
            this.pnlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBase.Location = new System.Drawing.Point(0, 0);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(1050, 650);
            this.pnlBase.TabIndex = 0;
            // 
            // pnlLocador
            // 
            this.pnlLocador.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLocador.Location = new System.Drawing.Point(0, 0);
            this.pnlLocador.Name = "pnlLocador";
            this.pnlLocador.Size = new System.Drawing.Size(1050, 138);
            this.pnlLocador.TabIndex = 0;
            // 
            // pnlLocatario
            // 
            this.pnlLocatario.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLocatario.Location = new System.Drawing.Point(0, 138);
            this.pnlLocatario.Name = "pnlLocatario";
            this.pnlLocatario.Size = new System.Drawing.Size(1050, 138);
            this.pnlLocatario.TabIndex = 1;
            // 
            // pnlGarantes
            // 
            this.pnlGarantes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGarantes.Location = new System.Drawing.Point(0, 276);
            this.pnlGarantes.Name = "pnlGarantes";
            this.pnlGarantes.Size = new System.Drawing.Size(1050, 138);
            this.pnlGarantes.TabIndex = 2;
            // 
            // pnlContrato
            // 
            this.pnlContrato.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContrato.Location = new System.Drawing.Point(0, 414);
            this.pnlContrato.Name = "pnlContrato";
            this.pnlContrato.Size = new System.Drawing.Size(1050, 138);
            this.pnlContrato.TabIndex = 3;
            // 
            // NuevoContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 650);
            this.Controls.Add(this.pnlBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NuevoContrato";
            this.Text = "NuevoContrato";
            this.pnlBase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.Panel pnlContrato;
        private System.Windows.Forms.Panel pnlGarantes;
        private System.Windows.Forms.Panel pnlLocatario;
        private System.Windows.Forms.Panel pnlLocador;
    }
}