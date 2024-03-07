using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaleriaFotografica
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'galeriaFotografica2DataSet.View_ProyectoCategoria' Puede moverla o quitarla según sea necesario.
            this.view_ProyectoCategoriaTableAdapter.Fill(this.galeriaFotografica2DataSet.View_ProyectoCategoria);

            this.reportViewer1.RefreshReport();
        }
    }
}
