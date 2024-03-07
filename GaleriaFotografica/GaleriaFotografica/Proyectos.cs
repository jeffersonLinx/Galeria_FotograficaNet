using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GaleriaFotografica
{
    public partial class Proyectos : GaleriaFotografica.header
    {
        //private string cadenaDeConexion;
        //cadenaDeConexion = ConfigurationManager.ConnectionStrings["GaleriaFotograficaWeb"].ConnectionString;
        SqlConnection conexion = new SqlConnection("server=DESKTOP-1UHVG6J; database=GaleriaFotografica2;Integrated Security=True");

        public Proyectos()
        {
            InitializeComponent();

        }
        //definir variables a utilizar
        #region"Mis variables"
        #endregion
        
        #region "Mis metodos"
        private void Estado_texto(bool lEstado)
        {
            //bloquear o desbloquear los textos
            // ojo con esto parece que no lo ocupare
            txtNombre.ReadOnly = !lEstado;
            txtDescripcion.ReadOnly = !lEstado;
            txtFotografo.ReadOnly = !lEstado;
        }
        private void Limpia_texto()
        {

            txtNombre.Clear();
            txtFotografo.Clear();
            txtDescripcion.Clear();
            txtDescripcion.Clear();           
           
        }
        private void EstadoBotonesProceso(bool lEstado)
        {
            //metodo para mostrar los objetos que esten con visibilidad valsa
            //visibilidad de los botones
            //btnLupaCat.Visible = lEstado;
            groupBox1.Visible = lEstado;
        }
        private void estadoBotonesPrincipare(bool lEstado)
        {
            // metodo para bloquear otros botones cunado se usa una accion en un formulario
            btnNuevo.Enabled = lEstado;
            btnEliminar.Enabled = lEstado;
            btnModificar.Enabled = lEstado;
            dataGridView1.Enabled = lEstado;
        }
        //
        private void EliminarRegistro(int id) 
        {
            try
            {
                conexion.Open();
                //deinir la consuolta SQL para eliminar el registro de la tabla trnProyectos
                string consulta = "DELETE FROM trnProyectos WHERE IdProyectos = @IdProyectos";
                //Crear un nuevo comando SQL con la consulta   y la conexion especificada
                SqlCommand comando = new SqlCommand(consulta, conexion);
                //Agrega un parametro al comando para especificar el valor de ID DEL proyecto a eliminar
                comando.Parameters.AddWithValue("@IdProyectos", id);
                //ejecuta el comando SQL para eliminar el registro
                comando.ExecuteNonQuery();

                MessageBox.Show("Registro eliminado correctamente.");
            }
            catch (Exception ex)
            {
                // por si ocurre algo
                MessageBox.Show("Error al intentar eliminar el registro: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
        private void Formato_ar(bool lEstado)
        {
            ////para ocultar y dar formato al data grid view
            //dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns["IdCategorias"].Visible = false;
            dataGridView1.Columns["imagenPath"].Visible = false;
            dataGridView1.Columns["EstadoRegistro"].Visible = false;
            dataGridView1.Columns["id_cat"].Visible = false;

            //USAR this.formato_ar();

        }
        private void CargarCategoriaEnConboBox()
        {
            //cargar en un conboBox todas las categorias registradas en la tabla trnCategoria
            //Consulta SQL para seleccionar las categorias y sus identificadores
            string consulta = "SELECT IdCategorias AS Value, Categoria AS Display FROM trnCategorias";
            //Crear un adaptador de datos para ejecutar la consulta y llenar una DataTable con los Resultados
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            // Asugnar el dataTable como rigen de datos para el comboBox
            comboBox1.DataSource = dt;
            //especificar que columna de datos mostraremos atraves del comboBox
            comboBox1.DisplayMember = "Display"; // Columna que se mostrará en el ComboBox
           // Especificar que columna del DataTable se utilizara como valor seleccionado en el ComboBox
            comboBox1.ValueMember = "Value"; // Valor asociado a cada elemento del ComboBox
        }
        private string SeleccionarImagen()
        {
            // este metodo ayuda a seleccionar una imagen atraves de un openFileDialog y retornar la ruta de la imagen
            //crear un cuadro de dialogo para seleccionar el archivo de imagen
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif";

            //mostar el cuadro de dialogo y esperar la seleccion del user
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //una ves la seleccion devolver la ruta de imagen seleccionada
                return openFileDialog.FileName;

            }
            else
            {
                //devolver
                return null;
            }
        }
        private string GuardarImagenEnCarpeta(string rutaImagenSeleccionada)
        {
            //metodo o funcion que guarda una imagen seleccionadad en una carpeta especifica de la aplicacion
            //recibe la ruta de la imagen seleccionada como paramerto  y devuelbe la ruta de la imagen donde se guardo la imagen
            //obtener el nombre del archivo de la ruta de la imagen seleccionada 
            string nombreArchivo = Path.GetFileName(rutaImagenSeleccionada);
            //combinar la ruta de la carpeta assets en el directorio de la aplicacion con el nombre de archivo
            string carpetaAssets = Path.Combine(Application.StartupPath, "assets");
            // combinar la carpeta assets con el nombre de archivo para obtener la nueva ruta de la imagen
            string nuevaRuta = Path.Combine(carpetaAssets, nombreArchivo);

            // Imprimir la ruta de la imagen para verificar que sea correcta
            Console.WriteLine("Ruta de la imagen: " + nuevaRuta);

            try
            {
                //verificar si la carpeta assets existe , si no existe , crearla
                if (!Directory.Exists(carpetaAssets))
                {
                    Directory.CreateDirectory(carpetaAssets);
                }
                //copiar el archivo de la ruta original a la nueva ruta en la carpeta assets
                File.Copy(rutaImagenSeleccionada, nuevaRuta, true);
                //Devolver nueva ruta 
                return nuevaRuta;
            }
            catch (Exception ex)
            {
                //
                MessageBox.Show("Error al copiar la imagen: " + ex.Message);
                //
                return null;
            }
        }
        public void llenar_tabla()
        {
            //Consulta SQL para para hacer combinacion de datos
            string consulta = "SELECT p.*, c.IdCategorias AS id_cat, c.Categoria FROM trnProyectos p INNER JOIN trnCategorias c ON c.IdCategorias = p.IdCategorias ORDER BY p.IdProyectos DESC;";
            //Crear un adaptador de datos para ejecutar la consulta y llenar una DataTable con los Resultados
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            // Agregar una nueva columna para las imágenes al DataTable
            DataColumn columnaImagen = new DataColumn("Imagen", typeof(Image));
            dt.Columns.Add(columnaImagen);

            // Iterar sobre cada fila en el DataTable y cargar las imágenes desde la ruta
            foreach (DataRow fila in dt.Rows)
            {
                // Obtener la ruta de la imagen de la fila
                string rutaImagen = fila["imagenPath"].ToString();

                // Si la ruta de la imagen no está vacía
                if (!string.IsNullOrEmpty(rutaImagen))
                {
                    // Cargar la imagen desde la ruta
                    Image imagen = Image.FromFile(rutaImagen);

                    // Asignar la imagen a la nueva columna en la fila
                    fila["Imagen"] = imagen;
                }
            }

            // Asignar el DataTable al origen de datos del DataGridView
            dataGridView1.DataSource = dt;

            // Cerrar la conexión (opcional)


            conexion.Close();
        }


        private string rutaImagenSeleccionada;// ruta global para obtener la direccion de la imagen

        #endregion


        private void Proyectos_Load(object sender, EventArgs e)
        {
            CargarCategoriaEnConboBox();//funcion o metodo para el combobox

            //para mostar los datos de la base de datos en un datagridview
            //estableser una cadena de consultas
            string consulta = "SELECT p.*, c.IdCategorias AS id_cat, c.Categoria FROM trnProyectos p INNER JOIN trnCategorias c ON c.IdCategorias = p.IdCategorias ORDER BY p.IdProyectos DESC; ";
            //parametros cosulta, conexion, objeto adatador
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            //pasar la consulta a la tabla memoria datable
            DataTable dt = new DataTable();
            //lo que se tenga en el adaptador se llenara en datatable
            adaptador.Fill(dt);
            //vista vista tomara los datos de dt
            dataGridView1.DataSource = dt;
            //EVENTO 2
            // Agregar columna de botón Eliminar al DataGridView
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Eliminar";
            buttonColumn.Name = "Eliminar"; // Nombre de la columna
            buttonColumn.Text = "Eliminar";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);

            llenar_tabla();
            this.Formato_ar(true);
            //EVENTO 3

            // ENVENTO 4
            // Iterar sobre todas las filas del DataGridView
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                // Establecer la altura deseada para cada fila (en píxeles)
                fila.Height = 100; // Por ejemplo, establecer una altura de 100 píxeles
            }
            //CargarDatosEnDataGridView();

            //dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            this.EstadoBotonesProceso(true);
            this.Limpia_texto();
            this.estadoBotonesPrincipare(false);
            this.Estado_texto(true);
            txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.EstadoBotonesProceso(false);
            this.Limpia_texto();
            this.estadoBotonesPrincipare(true);
            this.Estado_texto(false);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // vsita de las celdas para devolver a los txt para su modificacion
            //dataGridView1.SelectedCells[0].Value.ToString();
            //dataGridView1.SelectedCells[1].Value.ToString();
            //dataGridView1.SelectedCells[2].Value.ToString();
            //dataGridView1.SelectedCells[3].Value.ToString();
            //dataGridView1.SelectedCells[4].Value.ToString();
            //dataGridView1.SelectedCells[5].Value.ToString();
            //dataGridView1.SelectedCells[6].Value.ToString();
            ////dataGridView1.SelectedCells[7].Value.ToString();
            ////dataGridView1.Columns.Add(imagenColumn);

            // Verificar si se hizo clic en el botón Eliminar
            if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del registro a eliminar
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IdProyectos"].Value);

                // Eliminar el registro de la base de datos
                EliminarRegistro(id);

                // Eliminar la fila del DataGridView
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }

            //this.Formato_ar(true);
            //// Verificar si hay filas seleccionadas antes de acceder a las celdas
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    // Acceder a los valores de las celdas seleccionadas y hacer lo que necesites
            //    // Por ejemplo:
            //    string valorCelda0 = dataGridView1.SelectedCells[0].Value?.ToString();
            //    string valorCelda1 = dataGridView1.SelectedCells[1].Value?.ToString();
            //    // y así sucesivamente...
            //}
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            // Verificar si todos los campos obligatorios están llenos
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtFotografo.Text))
            {
                MessageBox.Show("Por favor, llene todos los campos obligatorios.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detener la ejecución del método si algún campo obligatorio está vacío
            }

            // verificar si se selcciono una imagen
            if (rutaImagenSeleccionada != null)
            {
                // Guardar la imagen en la carpeta "assets"
                string nuevaRuta = GuardarImagenEnCarpeta(rutaImagenSeleccionada);
                //verifica si la imagne se guardo correptamente     
                if (nuevaRuta != null)
                {
                    try
                    {
                        conexion.Open();
                        // definir la consulta SQL para insertar un nuevo registro a la tabla
                        string consulta = "INSERT INTO trnProyectos (IdCategorias, descripcion, imagenPath, nombre, fotografo, EstadoRegistro) " +
                                          "VALUES (@IdCategorias, @descripcion, @imagenPath, @nombre, @fotografo, @EstadoRegistro)";
                        //crear comando SQL con la consulta y conexion 
                        SqlCommand comando = new SqlCommand(consulta, conexion);
                        //asignar valores a los parametros de consulta 
                        comando.Parameters.AddWithValue("@IdCategorias", comboBox1.SelectedValue);//
                        comando.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                        comando.Parameters.AddWithValue("@imagenPath", nuevaRuta); // Utiliza la nueva ruta de la imagen
                        comando.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        comando.Parameters.AddWithValue("@fotografo", txtFotografo.Text);
                        comando.Parameters.AddWithValue("@EstadoRegistro", 1); // valor de EstadoRegistro
                       //Ejecuta el comando SQL para insertar el nuevo rgistro
                        comando.ExecuteNonQuery();
                        //
                        MessageBox.Show("Registro insertado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        //
                        MessageBox.Show("Error al intentar insertar el registro: " + ex.Message);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
            else
            {
                //
                MessageBox.Show("Por favor, selecciona una imagen antes de guardar.");
            }

            llenar_tabla();
            Limpia_texto();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                rutaImagenSeleccionada = openFileDialog1.FileName;
                txtFotografia.Text = openFileDialog1.FileName;
                //capas y lo vuelbo invisible esto XD
                pictureBox1.Image = Image.FromFile(rutaImagenSeleccionada);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtFotografia_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFotografo_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificar si la columna actual es la columna de imagen
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Imagen")
            {
                // Obtener la fila actual
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                // Obtener la imagen de la celda actual
                Image imagen = (Image)fila.Cells[e.ColumnIndex].Value;

                // Si hay una imagen válida
                if (imagen != null)
                {
                    // Establecer el tamaño deseado para la imagen
                    int nuevoAncho = 80; // Establecer el ancho deseado en píxeles
                    int nuevoAlto = 100; // Establecer el alto deseado en píxeles

                    // Redimensionar la imagen al tamaño deseado
                    Image nuevaImagen = new Bitmap(imagen, nuevoAncho, nuevoAlto);

                    // Asignar la imagen redimensionada de nuevo a la celda
                    e.Value = nuevaImagen;
                }
            }
           

        }
    }
}
