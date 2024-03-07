using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GaleriaFotografica.Entidades;
using System.Data.SqlClient;
using System.IO;


namespace GaleriaFotografica.Datos
{
    public  class clsProyectosDA
    {
        private string cadenaDeConexion; // Cadena de conexión a la base de datos
                                         // Constructor de la clase clsUsuarioDA
        public clsProyectosDA()
        {
            // Obtener la cadena de conexión de la configuración de la aplicación
            cadenaDeConexion =
                ConfigurationManager.ConnectionStrings["GaleriaFotografica"].ConnectionString;
        }
        //public clsProyectosDA GetPorNombreProyecto(int nOpcion,clsProyectosDA oAr) 
        //{
        //    string Rpta = "";
        //    string Sql_tarea = "";
        //    SqlConnection conn = new SqlConnection();
        //    try
        //    {
        //        conn.Open();

        //        //Sqlcon = Conexion.getInstancia().CrearConexion();
        //        if(nOpcion == 1)// nuevo registro
        //        {
        //            Sql_tarea = "";
        //        }
        //        else//actulizar registr
        //        {
        //            Sql_tarea = "";
        //        }
        //        SqlConnection Comando = new SqlConnection(Sql_tarea, conn);
        //        //conn.Open();
        //        Rpta = Comando.ExecuteNomQuery() >= 1 ? "Ok" : "No se pudo";
        //        return Rpta;

        //    }
        //    catch (Exception ex)
        //    {
        //       return Rpta = ex.Message;
        //    }
        //    finally
        //    {
        //        if (conn.State == System.Data.ConnectionState.Open) conn.Close();
        //    }

        //}
    }
}
