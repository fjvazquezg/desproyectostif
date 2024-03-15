using System;
using System.Configuration;
using System.Data;
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
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    try
                    {
                        string storedProcedureName = "SP_PRODUCTO";

                        using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlParameter paramOP = new SqlParameter("@OP", SqlDbType.TinyInt);
                            paramOP.Value = 3;
                            cmd.Parameters.Add(paramOP);

                            conn.Open();

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    DataTable dt = new DataTable();
                                    dt.Load(reader);

                                    rptProductos.DataSource = dt;
                                    rptProductos.DataBind();  // Llama a la función ConvertToUrl dentro del Repeater
                                }
                                else
                                {
                                    lblMensaje.Text = "No se encontraron datos de productos.";
                                    lblMensaje.Visible = true;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al ejecutar el procedimiento almacenado: " + ex.Message);
                        lblMensaje.Text = "Error al cargar la información de productos. Consulta el registro para obtener más detalles.";
                        lblMensaje.Visible = true;
                    }
                }
            }
        }

        // Llama a la función ConvertToUrl dentro del Repeater para obtener la URL de las imágenes
        protected void rptProductos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView rowView = (DataRowView)e.Item.DataItem;
                string imageUrl = (string)rowView["PROD_URLImga"]; // Se asume que "PROD_URLImga" es la columna que contiene la ruta de la imagen
                Image imgProducto = (Image)e.Item.FindControl("imgProducto");
                imgProducto.ImageUrl = ConvertToUrl(imageUrl);
            }
        }

        protected string ConvertToUrl(object imageData)
        {
            if (imageData != null && imageData != DBNull.Value && imageData is string)
            {
                // La imageData ya es una cadena de caracteres (string) que contiene la ruta de la imagen
                string imageUrl = (string)imageData;

                // Devuelve la URL de la imagen directamente
                return imageUrl;
            }

            // Si la imageData no es válida, proporciona una URL de imagen predeterminada
            return ResolveUrl("~/img/placeholder.jpg");
        }




        // Función para manejar el evento ItemCommand del Repeater
        protected void rptProductos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalles")
            {
                string productId = e.CommandArgument.ToString();
                Response.Redirect($"InfoProducto.aspx?id={productId}");
            }
        }
    }
}
