namespace GaleriaFotografica
{
    partial class FrmReportes
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportes));
            this.viewProyectoCategoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.galeriaFotografica2DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.galeriaFotografica2DataSet = new GaleriaFotografica.GaleriaFotografica2DataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.view_ProyectoCategoriaTableAdapter = new GaleriaFotografica.GaleriaFotografica2DataSetTableAdapters.View_ProyectoCategoriaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.viewProyectoCategoriaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.galeriaFotografica2DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.galeriaFotografica2DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // viewProyectoCategoriaBindingSource
            // 
            this.viewProyectoCategoriaBindingSource.DataMember = "View_ProyectoCategoria";
            this.viewProyectoCategoriaBindingSource.DataSource = this.galeriaFotografica2DataSetBindingSource;
            // 
            // galeriaFotografica2DataSetBindingSource
            // 
            this.galeriaFotografica2DataSetBindingSource.DataSource = this.galeriaFotografica2DataSet;
            this.galeriaFotografica2DataSetBindingSource.Position = 0;
            // 
            // galeriaFotografica2DataSet
            // 
            this.galeriaFotografica2DataSet.DataSetName = "GaleriaFotografica2DataSet";
            this.galeriaFotografica2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.viewProyectoCategoriaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GaleriaFotografica.Reportes.ReporteProyectos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // view_ProyectoCategoriaTableAdapter
            // 
            this.view_ProyectoCategoriaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReportes";
            this.Text = "FrmReportes";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewProyectoCategoriaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.galeriaFotografica2DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.galeriaFotografica2DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private GaleriaFotografica2DataSet galeriaFotografica2DataSet;
        private System.Windows.Forms.BindingSource galeriaFotografica2DataSetBindingSource;
        private System.Windows.Forms.BindingSource viewProyectoCategoriaBindingSource;
        private GaleriaFotografica2DataSetTableAdapters.View_ProyectoCategoriaTableAdapter view_ProyectoCategoriaTableAdapter;
    }
}