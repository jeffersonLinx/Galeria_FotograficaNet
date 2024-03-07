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
    public partial class header2 : Form
    {
        public header2()
        {
            InitializeComponent();
        }

        private void Header2_Load(object sender, EventArgs e)
        {

        }

        private void proyectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            categoria2 categoria2 = new categoria2();
            categoria2.ShowDialog();
        }

        private void pryectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proyectos2 proyectos2 = new proyectos2();
            proyectos2.ShowDialog();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.ShowDialog();
        }
    }
}
