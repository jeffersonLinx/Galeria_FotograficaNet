using GaleriaFotografica.Conexion;
using GaleriaFotografica.Entidades;
using GaleriaFotografica.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GaleriaFotografica//.admin.includes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public void limpiar_Campos()
        {
            txtUsuario.Clear();
            txtClave.Clear();


        }

        private void btnAutenticar_Click(object sender, EventArgs e)
        {
            Usuario oclsUsuario = new Usuario(); // Crear una instancia del objeto de la clase Usuario
            clsUsuarioBE oclsUsuarioBE = oclsUsuario.Autenticar(txtUsuario.Text, txtClave.Text); // Autenticar el usuario con el nombre de usuario y la contraseña proporcionados

            if (oclsUsuarioBE.IdUsuario > 0) // Si el IdUsuario es mayor que cero, la autenticación fue exitosa
            {
              if(  oclsUsuarioBE.IdRol==1)
              {
                    Categorias categorias = new Categorias(); // Crear una instancia del formulario principal
                    categorias.ShowDialog(); // Mostrar el formulario principal
              }
              else
              {
                    categoria2 categorias2 = new categoria2();
                    categorias2.ShowDialog();
              }

            }


            // Si el IdUsuario es igual o menor que cero, la autenticación falló
            else
            {
                MessageBox.Show("Credenciales inválidas"); // Mostrar un mensaje de error
            }
            //probar
            limpiar_Campos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
