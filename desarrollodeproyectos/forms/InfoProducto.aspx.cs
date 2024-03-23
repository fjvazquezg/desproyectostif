using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic; // Para List<>



namespace desarrollodeproyectos.forms
{

    public partial class InfoProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["productoId"] != null)
                {
                    int productId;
                    if (int.TryParse(Request.QueryString["productoId"], out productId))
                    {
                        CargarProducto(productId);
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

        private void CargarProducto(int productId)
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

                        SqlParameter paramProductId = new SqlParameter("@PROD_Id", SqlDbType.Int);
                        paramProductId.Value = productId;
                        cmd.Parameters.Add(paramProductId);

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                DataTable dt = new DataTable();
                                dt.Load(reader);

                                InfoProducto1.DataSource = dt;
                                InfoProducto1.DataBind();

                                // Mostrar el stock mínimo si está disponible
                                if (dt.Rows.Count > 0)
                                {
                                    DataRow row = dt.Rows[0];
                                     //Label lblStockMin = (Label)InfoProducto1.Items[0].FindControl("lblStockMin");
                                    //lblStockMin.Text = "Stock Mínimo: " + row["PROD_StockMin"].ToString();
                                    //lblStockMin.Visible = true;

                                    Label lbldescripcion = (Label)InfoProducto1.Items[0].FindControl("lbldescripcion");
                                    lbldescripcion.Text = "Descripcion: " + row["PROD_Descripcion"].ToString();
                                    lbldescripcion.Visible = true;
                                }
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
    }

}
