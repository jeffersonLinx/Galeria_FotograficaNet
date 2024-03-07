using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaleriaFotografica
{
    public partial class Home : Form
    {
        //private string cadenaDeConexion;
        //cadenaDeConexion = ConfigurationManager.ConnectionStrings["GaleriaFotograficaWeb"].ConnectionString;
        SqlConnection conexion = new SqlConnection("server=DESKTOP-1UHVG6J; database=GaleriaFotografica2;Integrated Security=True");
        public Home()
        {
            // se ejecuta contructor primero
            // ESTO SOLO se ejcuta una vez
            InitializeComponent();

            CargarProyectos();

            CargarCategoriasMenu();

        }

        #region

        //
        private async Task CargarProyectosPorCategoria(string categoria)
        {
            flowLayoutPanel1.Controls.Clear();// limpiar panel de flujo

            try
            {
                conexion.Open();
                // comando SQL para filtar los proyectos por categoria
                SqlCommand comando = new SqlCommand("SELECT p.*, c.IdCategorias AS id_cat, c.Categoria FROM trnProyectos p INNER JOIN trnCategorias c ON c.IdCategorias = p.IdCategorias WHERE c.Categoria = @categoria", conexion);
                // agregar parametro para consulta
                comando.Parameters.AddWithValue("@categoria", categoria);
                //ejecutar la consulta de manera Asincrona y obtener un lector de datos
                SqlDataReader lector = await comando.ExecuteReaderAsync();
                // leer resultados de consulta
                while (lector.Read())
                {
                    //obtener valores de la columna de la fila actual
                    string nombre = lector["nombre"].ToString();
                    string descripcion = lector["descripcion"].ToString();
                    string fotografo = lector["fotografo"].ToString();
                    string imagenPath = lector["imagenPath"].ToString();
                    
                    //crear un panel para mostrar cada proyecto
                    //con una talla determinada
                    Panel panel = new Panel();
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Size = new Size(200, 300);// estableces tamaño

                    //crear un picture box para las imagenes
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Size = new Size(150, 150); // establecer el tamaño de la imagen
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom; //ajustar modo vizualisacion de la imagen
                    pictureBox.Location = new Point(25, 10); // establecer la pocision del picturebox dentro del panel
                    pictureBox.Image = Image.FromFile(imagenPath); // cargar imagen desde la ruta guarda

                    //crear etiqueta para mostrar el nombre del proyecto
                    Label labelNombre = new Label();
                    labelNombre.AutoSize = true;
                    labelNombre.Text = nombre; // establecer el texto con el nombre de la imagen
                    labelNombre.Location = new Point(10, 170);  // establercer la pocision de la etiqueta

                    // Establecer el estilo de la fuente en negrita
                    labelNombre.Font = new Font(labelNombre.Font, FontStyle.Bold);
                    // Centrar el texto horizontalmente dentro del panel
                    labelNombre.TextAlign = ContentAlignment.MiddleCenter;
                    // Establecer el anclaje de la etiqueta para que se ajuste al centro
                    labelNombre.Anchor = AnchorStyles.None;
                   


                    // etiqueta de descripcion del proyecto
                    Label labelDescripcion = new Label();
                    labelDescripcion.AutoSize = true;
                    labelDescripcion.Text = descripcion; // establercer el texto de descripcion del proyecto
                    labelDescripcion.Location = new Point(10, 200); //pocision de la etiqueta dentro del panel

                    //etiqueta nombre fotografo
                    Label labelFotografo = new Label();
                    labelFotografo.AutoSize = true;
                    labelFotografo.Text = "Fotógrafo: " + fotografo; // establecer el texto del nombre del fotografo
                    labelFotografo.Location = new Point(10, 230);

                    //agragar controles al panel
                    panel.Controls.Add(pictureBox);
                    panel.Controls.Add(labelNombre);
                    panel.Controls.Add(labelDescripcion);
                    panel.Controls.Add(labelFotografo);
                    
                    // agreagr el panel al panel de flujo
                    flowLayoutPanel1.Controls.Add(panel);
                }
                // serrar
                lector.Close();
            }
            catch (Exception ex)
            {
                // manejo de errores mensaje
                MessageBox.Show("Error al cargar los proyectos por categoría: " + ex.Message);
            }
            finally
            {
                // cerrar
                conexion.Close();
            }
        }



        private void CargarCategoriasMenu()
        {// funcion argar

            try
            {
                conexion.Open();
                //crea comando para seleccionar todas las categorias
                SqlCommand comando = new SqlCommand("SELECT * FROM trnCategorias", conexion);
                //ejecuta el comando y obtiene un lector de datos para leer los resultados
                SqlDataReader lector = comando.ExecuteReader();

                // lee cada fila de resultado
                while (lector.Read())
                {
                    // obtiene el nombre de la categoria de la fila actual
                    string categoria = lector["categoria"].ToString();
                    // crea un nuevo elemento de menu con el nombre de la categoria
                    ToolStripMenuItem menuItem = new ToolStripMenuItem(categoria);
                    // agrega un controlador de eventos al hacer clic en el elemento nuevo
                    // += es un controlador de eventos, 
                    // => operador de funcion lamba , define funciones anonimas relacioanada con el evento clic si nolleva argumentos adicionales
                    menuItem.Click += async (sender, e) =>
                    {
                        //obtener la categoria seleccionada cuando se hace clic en el elemento del menu
                        string categoriaSeleccionada = categoria;
                        // cargar los proyectos correspondientes a la categoria seleccionada
                        // await espera que se acaben de ejecutar los procedimientos asincronicos
                        await CargarProyectosPorCategoria(categoriaSeleccionada);
                    };
                    // agregar elemento de menu al menu principal(el muStrip)
                    menuStrip1.Items.Add(menuItem);
                }
                //serrar lector de datos
                lector.Close();
            }
            catch (Exception ex)
            {
                // mostrar error cuando algo sale mal
                MessageBox.Show("Error al cargar las categorías: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }


      

        private void CargarProyectos()
        {
            // los carga de forma general
            try
            {
                conexion.Open();
                // crea consulta SQL
                SqlCommand comando = new SqlCommand("SELECT p.*, c.IdCategorias AS id_cat, c.Categoria FROM trnProyectos p INNER JOIN trnCategorias c ON c.IdCategorias = p.IdCategorias", conexion);
               // lector de datos
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    string nombre = lector["nombre"].ToString();
                    string descripcion = lector["descripcion"].ToString();
                    string fotografo = lector["fotografo"].ToString();
                    string imagenPath = lector["imagenPath"].ToString();

                    // Crear un nuevo panel para mostrar el proyecto
                    Panel panel = new Panel();
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Size = new Size(200, 300);

                    // PictureBox para mostrar la imagen
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Size = new Size(150, 150);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Location = new Point(25, 10);
                    pictureBox.Image = Image.FromFile(imagenPath); // Asignar la imagen desde la ruta

                    // Etiqueta para el nombre
                    Label labelNombre = new Label();
                    labelNombre.AutoSize = true;
                    labelNombre.Text = nombre;
                    labelNombre.Location = new Point(10, 170);

                    // Establecer el estilo de la fuente en negrita
                    labelNombre.Font = new Font(labelNombre.Font, FontStyle.Bold);
                    // Centrar el texto horizontalmente dentro del panel
                    labelNombre.TextAlign = ContentAlignment.MiddleCenter;
                    // Establecer el anclaje de la etiqueta para que se ajuste al centro
                    labelNombre.Anchor = AnchorStyles.None;                

                    // Etiqueta para la descripción
                    Label labelDescripcion = new Label();
                    labelDescripcion.AutoSize = true;
                    labelDescripcion.Text = descripcion;
                    labelDescripcion.Location = new Point(10, 200);

                    // Etiqueta para el fotógrafo
                    Label labelFotografo = new Label();
                    labelFotografo.AutoSize = true;
                    labelFotografo.Text = "Fotógrafo: " + fotografo;
                    labelFotografo.Location = new Point(10, 230);

                    // Agregar los controles al panel
                    panel.Controls.Add(pictureBox);
                    panel.Controls.Add(labelNombre);
                    panel.Controls.Add(labelDescripcion);
                    panel.Controls.Add(labelFotografo);
                    // Agregar el panel al FlowLayoutPanel
                    flowLayoutPanel1.Controls.Add(panel);
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los proyectos: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }


        #endregion

        private void Home_Load(object sender, EventArgs e)
        {
            // cargar aqui para que se ejecute primero
            //CargarCategoriasMenu();


        }

        private void galeriaFotograficaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void todoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarProyectos();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //// Obtén el valor actual de la barra de desplazamiento
            //int scrollValue = vScrollBar1.Value;

            //// Calcula el desplazamiento vertical multiplicando el valor de la barra de desplazamiento por la altura de cada proyecto
            //int verticalOffset = scrollValue * 300; // 300 es la altura de cada proyecto en el ejemplo

            //// Establece la nueva posición vertical de los proyectos en el flowLayoutPanel1
            //flowLayoutPanel1.VerticalScroll.Value = verticalOffset;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
