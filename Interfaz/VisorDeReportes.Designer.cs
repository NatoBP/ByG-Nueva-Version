namespace Interfaz
{
    partial class VisorDeReportes
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ComprobanteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CaracteristicaPropiedadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PersonaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvComprobantes = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ComprobanteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaracteristicaPropiedadBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ComprobanteBindingSource
            // 
            this.ComprobanteBindingSource.DataSource = typeof(AccesoDatos.Clases.Comprobante);
            // 
            // CaracteristicaPropiedadBindingSource
            // 
            this.CaracteristicaPropiedadBindingSource.DataSource = typeof(AccesoDatos.Clases.CaracteristicaPropiedad);
            // 
            // PersonaBindingSource
            // 
            this.PersonaBindingSource.DataSource = typeof(AccesoDatos.Clases.Persona);
            // 
            // rpvComprobantes
            // 
            this.rpvComprobantes.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "DsComprobante";
            reportDataSource4.Value = this.ComprobanteBindingSource;
            reportDataSource5.Name = "DsItems";
            reportDataSource5.Value = this.CaracteristicaPropiedadBindingSource;
            reportDataSource6.Name = "DsPersona";
            reportDataSource6.Value = this.PersonaBindingSource;
            this.rpvComprobantes.LocalReport.DataSources.Add(reportDataSource4);
            this.rpvComprobantes.LocalReport.DataSources.Add(reportDataSource5);
            this.rpvComprobantes.LocalReport.DataSources.Add(reportDataSource6);
            this.rpvComprobantes.LocalReport.ReportEmbeddedResource = "Interfaz.Reportes.Reporte.rdlc";
            this.rpvComprobantes.Location = new System.Drawing.Point(0, 0);
            this.rpvComprobantes.Name = "rpvComprobantes";
            this.rpvComprobantes.ServerReport.BearerToken = null;
            this.rpvComprobantes.Size = new System.Drawing.Size(800, 450);
            this.rpvComprobantes.TabIndex = 0;
            this.rpvComprobantes.Load += new System.EventHandler(this.rpvComprobantes_Load);
            // 
            // VisorDeReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpvComprobantes);
            this.Name = "VisorDeReportes";
            this.Text = "VisorDeReportes";
            ((System.ComponentModel.ISupportInitialize)(this.ComprobanteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaracteristicaPropiedadBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PersonaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvComprobantes;
        private System.Windows.Forms.BindingSource ComprobanteBindingSource;
        private System.Windows.Forms.BindingSource CaracteristicaPropiedadBindingSource;
        private System.Windows.Forms.BindingSource PersonaBindingSource;
    }
}