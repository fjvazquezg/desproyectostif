using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace desarrollodeproyectos.forms
{
    public partial class MetodosDeComprobacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosUsuario();
            }
        }

        protected void CargarDatosUsuario()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_USUARIO";

                    cmd.Parameters.AddWithValue("@OP", 1);
                    cmd.Parameters.AddWithValue("@USU_ID", 0);
                    cmd.Parameters.AddWithValue("@USU_NOMBRE", "NombreNuevo");
                    cmd.Parameters.AddWithValue("@USU_IMG", "ruta_de_la_imagen");
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar los datos del usuario: " + ex.Message;
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                int idUsuario;
                if (int.TryParse(nombreCompleto.Text, out idUsuario))
                {
                    // string rutaImagen = ObtenerRutaDeLaImagen();

                    using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_USUARIO";

                        cmd.Parameters.AddWithValue("@OP", 2);
                        cmd.Parameters.AddWithValue("@USU_ID", idUsuario);
                        //cmd.Parameters.AddWithValue("@USU_IMG", rutaImagen); 

                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    lblMensaje.Text = "Por favor, ingresa un ID de usuario válido.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al guardar los datos: " + ex.Message;
            }
        }

        // Método para obtener la ruta de la imagen 
        /*private string ObtenerRutaDeLaImagen()
        {
            if (fileUploadControl.HasFile)
            {
                string fileName = fileUploadControl.FileName;
                string filePath = "~/images/" + fileName; // Ruta donde se guardará la imagen
                fileUploadControl.SaveAs(Server.MapPath(filePath));
                return filePath;
            }
            else
            {
                return "ruta_por_defecto"; // Ruta por defecto si no se selecciona ninguna imagen
            }
        }*/
    }
}
