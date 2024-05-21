using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace desarrollodeproyectos.forms
{
    public partial class InfoProducto : System.Web.UI.Page
    {
        Carrito Carrito = new Carrito();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["productoId"] != null)
                {
                    int productoId;
                    if (int.TryParse(Request.QueryString["productoId"], out productoId))
                    {
                        CargarProducto(productoId);
                        ViewState["productoId"] = productoId; // Guarda el productoId en el ViewState
                    }
                    else
                    {
                        lblMensaje.Text = "El ID del producto proporcionado en la URL no es válido.";
                        lblMensaje.Visible = true;
                    }
                }
                else
                {
                    lblMensaje.Text = "No se proporcionó ningún ID de producto en la URL.";
                    lblMensaje.Visible = true;
                }
            }
        }

        private void CargarProducto(int productoId)
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
                        paramOP.Value = 6; // Consultar solo un producto por ID
                        cmd.Parameters.Add(paramOP);

                        SqlParameter ProductoId = new SqlParameter("@PROD_Id", SqlDbType.Int);
                        ProductoId.Value = productoId;
                        cmd.Parameters.Add(ProductoId);

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string nombreProducto = reader["PROD_Nombre"].ToString();
                                    decimal precio = Convert.ToDecimal(reader["PROD_Precio"]);
                                    string descripcion = reader["PROD_Descripcion"].ToString();
                                    string imagenUrl = reader["PROD_URLImga"].ToString();

                                    lblNombreProducto.Text = nombreProducto;
                                    lblPrecio.Text = precio.ToString("C");
                                    lblDescripcion.Text = descripcion;
                                    imgProducto.ImageUrl = imagenUrl;
                                }

                                lblNombreProducto.Visible = true;
                                lblPrecio.Visible = true;
                                lblDescripcion.Visible = true;
                                imgProducto.Visible = true;
                            }
                            else
                            {
                                lblMensaje.Text = "No se encontró ningún producto con el ID proporcionado.";
                                lblMensaje.Visible = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al ejecutar el procedimiento almacenado: " + ex.Message);
                    lblMensaje.Text = "Error al cargar la información del producto. Consulta el registro para obtener más detalles.";
                    lblMensaje.Visible = true;
                }
            }
        }

        protected void add_Click(object sender, EventArgs e)
        {
            int productoId = (int)ViewState["productoId"];
            int cantidad = int.Parse(txtCantidad.Text);
            int usuario = 1; //Colocar la variable global del usuario


            Carrito.CrearCarrito(productoId, usuario, cantidad);
        }

    }
}