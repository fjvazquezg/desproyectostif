using System;
using System.Data.SqlClient;
using System.Configuration;

namespace desarrollodeproyectos.forms
{
    public partial class InfoProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Utiliza using para garantizar la liberación de recursos, incluida la conexión
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    // Utiliza un try-catch para manejar posibles excepciones
                    try
                    {
                        // Obtén el ID del producto desde la consulta de la URL
                        if (Request.QueryString["id"] != null)
                        {
                            string productId = Request.QueryString["id"];

                            // Crea la consulta SQL directamente
                            string query = $"SELECT P.ID AS 'ID Producto', P.Nombre AS 'Nombre', P.Precio AS 'Precio', " +
                                           $"P.Descripcion AS 'Descripcion', P.Stock AS 'Stock', I.Ruta AS 'Ruta Imagen' " +
                                           $"FROM Productos P LEFT JOIN Imagenes I ON P.ID = I.ProductoID " +
                                           $"WHERE P.ID = {productId}";

                            // Crea el comando con la consulta SQL y asigna la conexión al comando
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                // Abre la conexión dentro del bloque using
                                conn.Open();

                                // Utiliza un DataReader para obtener los resultados de la consulta
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    // Verifica si hay datos antes de intentar leer
                                    if (reader.Read())
                                    {
                                        // Asigna los datos a las etiquetas o controles de tu página InfoProducto.aspx
                                        lblNombre.InnerText = reader["Nombre"].ToString();
                                        lblDescripcion.InnerText = reader["Descripcion"].ToString();
                                        lblPrecio.InnerText = reader["Precio"].ToString();
                                        lblStock.InnerText = reader["Stock"].ToString();
                                        mainImage.Src = reader["Ruta Imagen"].ToString();
                                    }
                                    else
                                    {
                                        // Manejar el caso en que no se encuentren datos para el ID proporcionado
                                        // Puedes redirigir a una página de error o imprimir un mensaje adecuado
                                        Response.Write("Producto no encontrado.");
                                    }
                                }
                            }
                        }
                        else
                        {
                            // Manejar el caso en que no se proporciona un parámetro ID en la URL
                            Response.Write("Falta el parámetro de ID en la URL.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejar la excepción, ya sea imprimir mensajes o registrarla
                        Console.WriteLine("Error al ejecutar la consulta SQL: " + ex.Message);
                    }
                }
            }
        }
    }
}
