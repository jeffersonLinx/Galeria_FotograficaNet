using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GaleriaFotografica.Entidades;
using System.Data.SqlClient;
using System.IO;


namespace MiSistema.Datos
{        // Clase que maneja el acceso a datos para la entidad Usuario
    public class clsUsuarioDA : clsUsuarioBE// Hereda de la clase clsUsuarioBE
    {

        private string cadenaDeConexion; // Cadena de conexión a la base de datos
       // Constructor de la clase clsUsuarioDA
        public clsUsuarioDA()
        {
             // Obtener la cadena de conexión de la configuración de la aplicación
            cadenaDeConexion = 
                ConfigurationManager.ConnectionStrings["GaleriaFotografica"].ConnectionString;
        }
        // Método para obtener un usuario por su nombre de usuario
        public clsUsuarioBE GetPorNombreUsuario(string nombreusuario)
        {
            clsUsuarioBE oclsUsuarioBE = new clsUsuarioBE(); // Crear un objeto de la clase clsUsuarioBE para almacenar los datos del usuario
            oclsUsuarioBE.IdUsuario = 0;//si el usuario no existe su id sera igual a cero

            // Establecer una conexión con la base de datos
            using (SqlConnection conn = new SqlConnection(cadenaDeConexion))
            {
                conn.Open();// Abrir la conexión

                // Crear y ejecutar una consulta SQL para obtener los datos del usuario por su nombre de usuario
                SqlCommand cmd = new SqlCommand("select * from trnUsuario where NombreUsuario='"
                    + nombreusuario + "';", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Asignar los valores obtenidos del usuario al objeto clsUsuarioBE
                        oclsUsuarioBE.IdUsuario = Convert.ToInt32(reader["IdUsuario"].ToString());
                        oclsUsuarioBE.NombreUsuario = reader["NombreUsuario"].ToString();
                        oclsUsuarioBE.Clave = reader["Clave"].ToString();
                        oclsUsuarioBE.Salt = reader["Salt"].ToString();
                        oclsUsuarioBE.IdRol = Convert.ToInt32(reader["IdRol"].ToString());
                    }
                }
            }
            return oclsUsuarioBE;
        }
    }
}

