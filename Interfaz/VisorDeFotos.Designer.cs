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
            ((System.ComponentModel.ISupportInitialize)(this.pctFotos)).BeginInit();
            this.SuspendLayout();
            // 
            // pctFotos
            // 
            this.pctFotos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(214)))), ((int)(((byte)(199)))));
            this.pctFotos.Location = new System.Drawing.Point(0, 0);
            this.pctFotos.Name = "pctFotos";
            this.pctFotos.Size = new System.Drawing.Size(750, 600);
            this.pctFotos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctFotos.TabIndex = 0;
            this.pctFotos.TabStop = false;
            // 
            // btnRetroceder
            // 
            this.btnRetroceder.BackColor = System.Drawing.Color.Transparent;
            this.btnRetroceder.FlatAppearance.BorderSize = 0;
            this.btnRetroceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetroceder.Image = ((System.Drawing.Image)(resources.GetObject("btnRetroceder.Image")));
            this.btnRetroceder.Location = new System.Drawing.Point(788, 313);
            this.btnRetroceder.Name = "btnRetroceder";
            this.btnRetroceder.Size = new System.Drawing.Size(71, 72);
            this.btnRetroceder.TabIndex = 4;
            this.btnRetroceder.UseVisualStyleBackColor = false;
            this.btnRetroceder.Click += new System.EventHandler(this.btnRetroceder_Click);
            // 
            // btnAdelantar
            // 
            this.btnAdelantar.BackColor = System.Drawing.Color.Transparent;
            this.btnAdelantar.FlatAppearance.BorderSize = 0;
            this.btnAdelantar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdelantar.Image = ((System.Drawing.Image)(resources.GetObject("btnAdelantar.Image")));
            this.btnAdelantar.Location = new System.Drawing.Point(788, 216);
            this.btnAdelantar.Name = "btnAdelantar";
            this.btnAdelantar.Size = new System.Drawing.Size(71, 72);
            this.btnAdelantar.TabIndex = 3;
            this.btnAdelantar.UseVisualStyleBackColor = false;
            this.btnAdelantar.Click += new System.EventHandler(this.btnAdelantar_Click);
            // 
            // VisorDeFotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(214)))), ((int)(((byte)(199)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.btnRetroceder);
            this.Controls.Add(this.btnAdelantar);
            this.Controls.Add(this.pctFotos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VisorDeFotos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VisorDeFotos";
            ((System.ComponentModel.ISupportInitialize)(this.pctFotos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pctFotos;
        private System.Windows.Forms.Button btnRetroceder;
        private System.Windows.Forms.Button btnAdelantar;
    }
}