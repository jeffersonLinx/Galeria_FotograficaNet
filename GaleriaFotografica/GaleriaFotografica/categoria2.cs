using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GaleriaFotografica
{
    public partial class categoria2 : GaleriaFotografica.header2
    {
        //private string cadenaDeConexion;
        //cadenaDeConexion = ConfigurationManager.ConnectionStrings["GaleriaFotograficaWeb"].ConnectionString;
        SqlConnection conexion = new SqlConnection("server=DESKTOP-1UHVG6J; database=GaleriaFotografica2;Integrated Security=True");

        public categoria2()
        {
            InitializeComponent();
        }
        #region
        public void llenar_tabla()
        {
            string consulta = "select * from trnCategorias";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
            conexion.Close();
        }
        public void limpiar_Campos()
        {
            txtCategoria2.Clear();

        }

        #endregion

        private void categoria2_Load(object sender, EventArgs e)
        {
            //conexion.Open();
            //para mostar los datos de la base de datos en un datagridview
            //estableser una cadena de consultas
            string consulta = "select * from trnCategorias";
            //parametros cosulta, conexion, objeto adatador
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            //pasar la consulta a la tabla memoria datable
            DataTable dt = new DataTable();
            //lo que se tenga en el adaptador se llenara en datatable
            adaptador.Fill(dt);
            //vista vista tomara los datos de dt
            dataGridView1.DataSource = dt;

        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            // verificar si el campo esta vasio
            if(string.IsNullOrWhiteSpace(txtCategoria2.Text))
            {
                MessageBox.Show("Por favor llenar campo.", "Campo vacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //detener la ejecucion del metodo si elcampo esta vacio
            }

            // si el campo no esta vacio
            try
            {
                conexion.Open();
                //crear bariable consulta para insertar datos
                string consulta = "insert into trnCategorias values('" + txtCategoria2.Text + "')";
                //crear objeto de clase sql comand se utiliza ejecutar consultas en sql
                SqlCommand comando = new SqlCommand(consulta, conexion);
                //eejcutar todo el codigo
                comando.ExecuteNonQuery();
                MessageBox.Show("Rguistro agregado");

                llenar_tabla();
                limpiar_Campos();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }


        }
    }
}
