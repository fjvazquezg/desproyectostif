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
                // Utiliza using para garantizar la liberación de recursos, incluida la conexión
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    // Utiliza un try-catch para manejar posibles excepciones
                    try
                    {
                        // Nombre del procedimiento almacenado
                        string storedProcedureName = "ObtenerInformacionProductos";

                        // Crea el comando con el tipo de comando como StoredProcedure
                        using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                        {
                            // Establece el tipo de comando como StoredProcedure
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Abre la conexión dentro del bloque using
                            conn.Open();

                            // Utiliza un DataReader para obtener los resultados del procedimiento almacenado
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                // Crear una tabla para almacenar los datos de productos específicos
                                DataTable dt = new DataTable();
                                dt.Load(reader);

                                // Crear una nueva tabla solo con las columnas deseadas
                                DataTable dtReduced = new DataTable();
                                dtReduced.Columns.Add("ID", typeof(int));
                                dtReduced.Columns.Add("Nombre", typeof(string));
                                dtReduced.Columns.Add("Precio", typeof(decimal));

                                // Copiar los datos de la tabla original a la nueva tabla
                                foreach (DataRow row in dt.Rows)
                                {
                                    dtReduced.Rows.Add(row["ID"], row["Nombre"], row["Precio"]);
                                }

                                // Asigna la nueva tabla al control Repeater
                                rptProductos.DataSource = dtReduced;
                                rptProductos.DataBind();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejar la excepción, ya sea imprimir mensajes o registrarla
                        Console.WriteLine("Error al ejecutar el procedimiento almacenado: " + ex.Message);
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

                // Redirigir a la página de detalles (InfoProducto.aspx)
                Response.Redirect($"InfoProducto.aspx?id={productId}");
            }
        }
    }
}
