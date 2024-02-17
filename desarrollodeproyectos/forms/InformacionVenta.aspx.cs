using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace desarrollodeproyectos.forms
{
    public partial class InformacionVenta : System.Web.UI.Page
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
                        // Crea la consulta SQL directamente
                        string query = "SELECT P.ID AS 'ID Producto', P.Nombre AS 'Nombre', P.Precio AS 'Precio', " +
                                       "P.Descripcion AS 'Descripcion', P.Stock AS 'Stock', I.Ruta AS 'Ruta Imagen' " +
                                       "FROM Productos P LEFT JOIN Imagenes I ON P.ID = I.ProductoID";

                        // Crea el comando con la consulta SQL y asigna la conexión al comando
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // Abre la conexión dentro del bloque using
                            conn.Open();

                            // Utiliza un DataReader para obtener los resultados de la consulta
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                // Asigna el DataReader al control Repeater
                                rptProductos.DataSource = reader;
                                rptProductos.DataBind();
                            }
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

        protected void rptProductos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalles")
            {
                // Obtener el ID del producto de la propiedad CommandArgument
                string productId = e.CommandArgument.ToString();

                // Redirigir a la página de detalles
                Response.Redirect($"InfoProducto.aspx?id={productId}");
            }
        }
    }
}
