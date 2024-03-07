using GaleriaFotografica.Conexion;
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
    public partial class Categorias : GaleriaFotografica.header
    {
        //private string cadenaDeConexion;
        //cadenaDeConexion = ConfigurationManager.ConnectionStrings["GaleriaFotograficaWeb"].ConnectionString;
        SqlConnection conexion = new SqlConnection("server=DESKTOP-1UHVG6J; database=GaleriaFotografica2;Integrated Security=True");

        public Categorias()
        {
            InitializeComponent();
            //// Obtener la conexión al crear una instancia del formulario
            //conexion = GestorConexion.ObtenerConexion();
        }
        //crear funcion
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
            txtCategoria.Clear();

        }

        private void EliminarRegistro(int id)
        {
            try
            {
                conexion.Open();
                string consulta = "DELETE FROM trnCategorias WHERE IdCategorias = @IdCategorias";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@IdCategorias", id);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar eliminar el registro: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
        #endregion

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            // Verificar si el campo txtCategoria está vacío
            if (string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                MessageBox.Show("Por favor, llene todos los campos.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detener la ejecución del método si el campo está vacío
            }
            // si el campo no esta vacio proceder al siguiente metodo
            try
            {
                conexion.Open();
                //crear bariable consulta para insertar datos
                string consulta = "insert into trnCategorias values('" + txtCategoria.Text + "')";
                //crear objeto de clase sql comand se utiliza ejecutar consultas en sql
                SqlCommand comando = new SqlCommand(consulta, conexion);
                //eejcutar todo el codigo
                comando.ExecuteNonQuery();
                MessageBox.Show("Rguistro agregado");

                llenar_tabla();
                limpiar_Campos();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al agregar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
          
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
        //lo, ocupaba para elimar un registro por boton
        //    conexion.Open();
        //    //crer bariable delete donde where es mi "ID"
        //    string consulta = "delete from trnCategorias where IdCategorias=" +txtCategoria.Text + "";
        //    //
        //    SqlCommand comando = new SqlCommand(consulta, conexion);
        //    //
        //    comando.ExecuteNonQuery();
        //    MessageBox.Show("Rguistro Eliminado");

        //    llenar_tabla();
        //    limpiar_Campos();
        //    conexion.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //elimine el boton modificar en el FORM
            //conexion.Open();
            ////crear bariable modificar 
            //string consulta = "update trnCategorias set IdCategorias=" +txtIdentidicador.Text + ",Categoria='" + txtCategoria.Text + "' where IdCategorias=" + txtIdentidicador.Text + "";
            //SqlCommand comando = new SqlCommand(consulta, conexion);
            ////declaracion de variable de tipo entero Cantidad para hacer la comnparacion
            //int cant;
            //comando.ExecuteNonQuery();
            //cant = comando.ExecuteNonQuery();
            ////si hay un reguistro modificado mayor que 0
            //if (cant > 0)
            //{
            //    MessageBox.Show("modificado");
            //}

            //llenar_tabla();
            //limpiar_Campos();
            //conexion.Close();
        }

        private void Categorias_Load(object sender, EventArgs e)
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

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Eliminar";
            buttonColumn.Name = "Eliminar"; // Nombre de la columna
            buttonColumn.Text = "Eliminar";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);
            //conexion.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // vsita de las celdas para devolver a los txt para su modificacion
            txtCategoria.Text = dataGridView1.SelectedCells[1].Value.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //conexion.Open();
            // vsita de las celdas para devolver a los txt para su modificacion
            dataGridView1.SelectedCells[0].Value.ToString();
            dataGridView1.SelectedCells[1].Value.ToString();

            // Verificar si se hizo clic en el botón Eliminar
            if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del registro a eliminar
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IdCategorias"].Value);

                // Eliminar el registro de la base de datos
                EliminarRegistro(id);

                // Eliminar la fila del DataGridView
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
            //conexion.Close();
        }
    }
}
