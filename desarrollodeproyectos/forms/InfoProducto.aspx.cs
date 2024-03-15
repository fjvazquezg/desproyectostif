using System;
using System.Data;
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
                // Obtener el ID del producto de la URL
                string productId = Request.QueryString["id"];

                // Verificar si se proporcionó un ID válido
                if (!string.IsNullOrEmpty(productId))
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_PRODUCTO", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@OP", 3); // Obtener todos los datos de productos
                            cmd.Parameters.AddWithValue("@PROD_Id", productId); // ID del producto deseado
                            

                            conn.Open();

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Asignar los datos del producto a las etiquetas o controles de la página
                                    lblNombre.InnerText = reader["PROD_Nombre"].ToString();
                                    lblPrecio.InnerText = reader["PROD_Precio"].ToString();
                                    lblStock.InnerText = reader["PROD_StockMin"].ToString();
                                    mainImage.Src = reader["PROD_URLImga"].ToString();
                                }
                                else
                                {
                                    // Manejar el caso en que el producto no sea encontrado
                                    Response.Write("Producto no encontrado.");
                                }
                            }
                        }
                    }
                }
                else
                {
                    // Manejar el caso en que no se proporcionó un ID de producto válido en la URL
                    Response.Write("Falta el parámetro de ID en la URL.");
                }
            }
        }
    }
}
