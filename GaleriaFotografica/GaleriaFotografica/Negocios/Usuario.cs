using GaleriaFotografica.Datos;
using GaleriaFotografica.Entidades;
using MiSistema.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
//


namespace GaleriaFotografica.Negocios
{
    public class Usuario
    {
        // Método para crear un hash de contraseña
        public static string CreatePasswordHash(string password, string salt)
        {
            // Concatenar la contraseña y el salt (sal)
            string combinedString = string.Concat(password, salt);

            // Crear un hash SHA1
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(combinedString));
                StringBuilder sb = new StringBuilder();

                // Convertir el hash a formato hexadecimal
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Convertir a hexadecimal
                }

                return sb.ToString(); // Devolver el hash como una cadena hexadecimal
            }
        }

        // Método para autenticar un usuario
        public clsUsuarioBE Autenticar(string nombreusuario, string clave)
        {
            string cPasswordhash = string.Empty;
            clsUsuarioDA oclsUsuarioDA = new clsUsuarioDA(); // Instanciar un objeto de acceso a datos de usuario
            clsUsuarioBE oclsUsuarioBE = new clsUsuarioBE(); // Instanciar un objeto de entidad de usuario
            oclsUsuarioBE = oclsUsuarioDA.GetPorNombreUsuario(nombreusuario); // Obtener los datos del usuario por su nombre de usuario desde la capa de datos

            if (oclsUsuarioBE.IdUsuario == 0) // Si el ID es igual a cero, el nombre de usuario no existe
            {
                return oclsUsuarioBE; // Devolver objeto de entidad de usuario vacío
            }
            else
            {
                cPasswordhash = CreatePasswordHash(clave, oclsUsuarioBE.Salt.Trim()); // Crear hash de la contraseña proporcionada
                if (cPasswordhash == oclsUsuarioBE.Clave) // Verificar si el hash de la contraseña coincide con el almacenado en la base de datos
                {
                    return oclsUsuarioBE; // Devolver el objeto de entidad de usuario si la autenticación es exitosa
                }
                else
                {
                    // Si la contraseña no coincide, establecer IdUsuario a -1 para indicar una autenticación fallida
                    oclsUsuarioBE.IdUsuario = -1;
                }
            }
            return oclsUsuarioBE; // Devolver el objeto de entidad de usuario
        }

    }
}
