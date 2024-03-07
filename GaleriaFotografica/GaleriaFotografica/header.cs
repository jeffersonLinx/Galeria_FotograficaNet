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
    public partial class header : Form
    {

        public header()
        {
            InitializeComponent();
        }

        private void regisrtoUsiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.ShowDialog();
            //this.Close();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // cerar el formulario actual
            // a otro formulario
            Categorias categorias = new Categorias();
            categorias.ShowDialog();
            //this.Close();
        }

        private void proyectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proyectos proyectos = new Proyectos();
            proyectos.ShowDialog();
            //this.Close();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.ShowDialog();
            //this.Close();
        }

        private void header_Load(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.ShowDialog();
            //this.Close();

        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportes frmReportes = new FrmReportes();
                frmReportes.ShowDialog();
        }
    }
}
