namespace Interfaz
{
    partial class VisorDeFotos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisorDeFotos));
            this.pctFotos = new System.Windows.Forms.PictureBox();
            this.btnRetroceder = new System.Windows.Forms.Button();
            this.btnAdelantar = new System.Windows.Forms.Button();
            this.pctCerrar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctFotos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // pctFotos
            // 
            this.pctFotos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pctFotos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(214)))), ((int)(((byte)(199)))));
            this.pctFotos.Location = new System.Drawing.Point(25, 30);
            this.pctFotos.Name = "pctFotos";
            this.pctFotos.Size = new System.Drawing.Size(1000, 540);
            this.pctFotos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctFotos.TabIndex = 0;
            this.pctFotos.TabStop = false;
            // 
            // btnRetroceder
            // 
            this.btnRetroceder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetroceder.BackColor = System.Drawing.Color.Transparent;
            this.btnRetroceder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetroceder.FlatAppearance.BorderSize = 0;
            this.btnRetroceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetroceder.Image = ((System.Drawing.Image)(resources.GetObject("btnRetroceder.Image")));
            this.btnRetroceder.Location = new System.Drawing.Point(364, 580);
            this.btnRetroceder.Name = "btnRetroceder";
            this.btnRetroceder.Size = new System.Drawing.Size(60, 60);
            this.btnRetroceder.TabIndex = 4;
            this.btnRetroceder.UseVisualStyleBackColor = false;
            this.btnRetroceder.Click += new System.EventHandler(this.btnRetroceder_Click);
            // 
            // btnAdelantar
            // 
            this.btnAdelantar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdelantar.BackColor = System.Drawing.Color.Transparent;
            this.btnAdelantar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdelantar.FlatAppearance.BorderSize = 0;
            this.btnAdelantar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdelantar.Image = ((System.Drawing.Image)(resources.GetObject("btnAdelantar.Image")));
            this.btnAdelantar.Location = new System.Drawing.Point(611, 580);
            this.btnAdelantar.Name = "btnAdelantar";
            this.btnAdelantar.Size = new System.Drawing.Size(60, 60);
            this.btnAdelantar.TabIndex = 3;
            this.btnAdelantar.UseVisualStyleBackColor = false;
            this.btnAdelantar.Click += new System.EventHandler(this.btnAdelantar_Click);
            // 
            // pctCerrar
            // 
            this.pctCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pctCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctCerrar.Image = ((System.Drawing.Image)(resources.GetObject("pctCerrar.Image")));
            this.pctCerrar.Location = new System.Drawing.Point(1003, 3);
            this.pctCerrar.Name = "pctCerrar";
            this.pctCerrar.Size = new System.Drawing.Size(24, 24);
            this.pctCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctCerrar.TabIndex = 5;
            this.pctCerrar.TabStop = false;
            this.pctCerrar.Click += new System.EventHandler(this.pctCerrar_Click);
            // 
            // VisorDeFotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(109)))), ((int)(((byte)(131)))));
            this.ClientSize = new System.Drawing.Size(1050, 650);
            this.Controls.Add(this.pctCerrar);
            this.Controls.Add(this.btnRetroceder);
            this.Controls.Add(this.btnAdelantar);
            this.Controls.Add(this.pctFotos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VisorDeFotos";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VisorDeFotos";
            ((System.ComponentModel.ISupportInitialize)(this.pctFotos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pctFotos;
        private System.Windows.Forms.Button btnRetroceder;
        private System.Windows.Forms.Button btnAdelantar;
        private System.Windows.Forms.PictureBox pctCerrar;
    }
}