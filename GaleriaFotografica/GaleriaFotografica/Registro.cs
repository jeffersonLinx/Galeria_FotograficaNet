using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using System.Security.Cryptography;
using System.Data.SqlTypes;

namespace GaleriaFotografica
{
    public partial class Registro : GaleriaFotografica.header
    {
        //private string cadenaDeConexion;
        //cadenaDeConexion = ConfigurationManager.ConnectionStrings["GaleriaFotograficaWeb"].ConnectionString;
        SqlConnection conexion = new SqlConnection("server=DESKTOP-1UHVG6J; database=GaleriaFotografica2;Integrated Security=True");

        public Registro()
        {
            InitializeComponent();

        }
        #region
        public void limpiar_Campos()
        {
            txtCedula.Clear();
            txtClave.Clear();
            txtEstado.Clear();
            txtTelefono.Clear();
            txtUsuario.Clear();

        }

        private string GenerarSalt(int size)
        {
            // Función para generar un salt aleatorio
            // Crear un array de bytes para almacenar el salt
            byte[] saltBytes = new byte[size];

            // Utilizar RNGCryptoServiceProvider para generar bytes aleatorios
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                // Llenar el array con bytes aleatorios
                rng.GetBytes(saltBytes);
            }

            // Convertir el array de bytes a una cadena base64
            string salt = Convert.ToBase64String(saltBytes);

            return salt;
        }

        private string GenerarHash(string password, string salt)
        {
            // Función para generar un hash seguro de la contraseña
            // Concatenar la contraseña y el salt
            string combinedString = password + salt;

            // Crear un objeto SHA1 para calcular el hash
            using (SHA1 sha1 = SHA1.Create())
            {
                // Calcular el hash de la contraseña concatenada con el salt
                byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(combinedString));

                // Convertir el hash en una cadena hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Formato hexadecimal
                }

                // Devolver el hash como una cadena
                return sb.ToString();
            }
        }

        #endregion

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // verificar todos los campos
            if(string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtClave.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Por favor llenar todos los campos", "Capmpos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;// determer la ejecusion del metodo si el campo esta vacio

            }

            conexion.Open();

            try
            {
                // Generar un salt aleatorio
                string salt = GenerarSalt(16); // Puedes definir la longitud del salt según tus necesidades

                // Generar el hash de la contraseña utilizando el salt
                string hashedPassword = GenerarHash(txtClave.Text, salt);

                // Consulta SQL para insertar el usuario en la base de datos
                string consulta = "INSERT INTO trnUsuario (NombreUsuario, Clave, Salt, Telefono, Cedula, FechaRegistro, EstadoRegistro,IdRol) " +
                                  "VALUES (@NombreUsuario, @Clave, @Salt, @Telefono, @Cedula, @FechaRegistro, @EstadoRegistro,@IdRol)";

                // Crear el comando SQL con los parámetros necesarios
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@NombreUsuario", txtUsuario.Text);
                    comando.Parameters.AddWithValue("@Clave", hashedPassword);
                    comando.Parameters.AddWithValue("@Salt", salt);
                    comando.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    comando.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                    comando.Parameters.AddWithValue("@FechaRegistro", dateTimePicker1.Value);
                    comando.Parameters.AddWithValue("@EstadoRegistro", txtEstado.Text);
                    comando.Parameters.AddWithValue("@IdRol", txtRol.Text);

                    // Ejecutar el comando sql
                    comando.ExecuteNonQuery();

                    MessageBox.Show("Registro agregado correctamente.");
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error
                MessageBox.Show("Error al registrar usuario: " + ex.Message);
            }
            finally
            {
                conexion.Close();
               limpiar_Campos();
            }
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
