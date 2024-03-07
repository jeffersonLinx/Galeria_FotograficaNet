using GaleriaFotografica.Negocios;
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
    public partial class Usuarios : GaleriaFotografica.header 
    {
        //private string cadenaDeConexion;
        //cadenaDeConexion = ConfigurationManager.ConnectionStrings["GaleriaFotograficaWeb"].ConnectionString;
        SqlConnection conexion = new SqlConnection("server=DESKTOP-1UHVG6J; database=GaleriaFotografica2;Integrated Security=True");

        public Usuarios()
        {
            InitializeComponent();
        }
        private void EliminarRegistro(int id)
        {
            try
            {
                conexion.Open();
                string consulta = "DELETE FROM trnUsuario WHERE IdUsuario = @IdUsuario";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@IdUsuario", id);
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
        private void usuarios_Load(object sender, EventArgs e)
        {
            //para mostar los datos de la base de datos en un datagridview
            //estableser una cadena de consultas
            string consulta = "select * from trnUsuario";
            //parametros cosulta, conexion, objeto adatador
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            //pasar la consulta a la tabla memoria datable
            DataTable dt = new DataTable();
            //lo que se tenga en el adaptador se llenara en datatable
            adaptador.Fill(dt);
            //vista vista tomara los datos de dt
            dataGridView1.DataSource = dt;

            // Agregar columna de botón Eliminar al DataGridView
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Eliminar";
            buttonColumn.Name = "Eliminar"; // Nombre de la columna
            buttonColumn.Text = "Eliminar";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //conexion.Open();
            // vsita de las celdas para devolver a los txt para su modificacion
             dataGridView1.SelectedCells[0].Value.ToString();
             dataGridView1.SelectedCells[1].Value.ToString();
             dataGridView1.SelectedCells[2].Value.ToString();
             dataGridView1.SelectedCells[3].Value.ToString();
             dataGridView1.SelectedCells[4].Value.ToString();
             dataGridView1.SelectedCells[5].Value.ToString();
             dataGridView1.SelectedCells[6].Value.ToString();
             dataGridView1.SelectedCells[7].Value.ToString();

            // Verificar si se hizo clic en el botón Eliminar
            if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del registro a eliminar
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IdUsuario"].Value);

                // Eliminar el registro de la base de datos
                EliminarRegistro(id);

                // Eliminar la fila del DataGridView
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
            //conexion.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
