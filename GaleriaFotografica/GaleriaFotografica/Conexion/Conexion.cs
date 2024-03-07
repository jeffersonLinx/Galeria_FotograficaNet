using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleriaFotografica.Conexion
{
    internal static class GestorConexion
    {
        public static SqlConnection ObtenerConexion()
        {
            string cadenaDeConexion = "server=DESKTOP-1UHVG6J; database=GaleriaFotografica2;Integrated Security=True";
            return new SqlConnection(cadenaDeConexion);
        }
    }
}
