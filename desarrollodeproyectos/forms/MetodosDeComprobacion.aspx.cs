using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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
            if (Session["Nombre"] != null && Session["Apellido"] != null)
            {
                nombreCompleto.Text = Session["Nombre"].ToString() + " " + Session["Apellido"].ToString();
                nombreCompleto.ReadOnly = true;
            }
            else
            {
                Response.Write("Nombre o apellido no encontrados en la sesión.");
            }
        }




        protected void btnEnviar_Click(object sender, EventArgs e)
        {


            if (fuINE.HasFile)
            {
                try
                {
                    // Guardar el archivo en el servidor
                    string fileName = Path.GetFileName(fuINE.PostedFile.FileName);
                    string filePath = Server.MapPath("~/Img/ImgComprobacion/") + fileName;
                    fuINE.SaveAs(filePath);

                    // Ruta relativa para almacenar en la base de datos
                    string rutaImagen = "~/Img/ImgComprobacion/" + fileName;

                    DateTime fecha = DateTime.Now;

                    string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("SP_USUARIO", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        // Obtenemos el próximo ID consecutivo
                        int nextUserId = GetNextUserId(connection);

                        // Obtener los valores de sesión
                        string nombre = Session["Nombre"]?.ToString();
                        string apellido = Session["Apellido"]?.ToString();
                        string correo = Session["Correo"]?.ToString();
                        string telefono = Session["Telefono"]?.ToString();
                        string contrasena = Session["Contrasena"]?.ToString();


                        if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(correo) ||
                            string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(contrasena))
                        {
                            lblMensaje.Text = "Faltan datos en la sesión.";
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        command.Parameters.AddWithValue("@OP", 1);
                        command.Parameters.AddWithValue("@USU_ID", nextUserId);
                        command.Parameters.AddWithValue("@USU_NOMBRE", nombre);
                        command.Parameters.AddWithValue("@USU_APELLIDO", apellido);
                        command.Parameters.AddWithValue("@USU_EMAIL", correo);
                        command.Parameters.AddWithValue("@USU_TELELEFONO", telefono);
                        command.Parameters.AddWithValue("@USU_CONTRASEÑA", contrasena);
                        command.Parameters.AddWithValue("@USU_FECHAREGISTRO", fecha);
                        command.Parameters.AddWithValue("@USU_IMG", rutaImagen);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            lblMensaje.Text = "Usuario registrado correctamente.";
                            lblMensaje.ForeColor = System.Drawing.Color.Green;
                        }
                        catch (Exception ex)
                        {
                            lblMensaje.Text = "Ha ocurrido un error al registrar el usuario: " + ex.Message;
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Ocurrió un error al guardar la imagen: " + ex.Message;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMensaje.Text = "Por favor, sube una imagen de tu INE.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

        }

        private int GetNextUserId(SqlConnection connection)
        {
            int nextUserId = 0;

            SqlCommand command = new SqlCommand("SELECT ISNULL(MAX(USU_ID), 0) + 1 as consec FROM USUARIO", connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {
                    nextUserId = Convert.ToInt32(reader["consec"]);
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al obtener el próximo ID consecutivo: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                connection.Close();
            }

            return nextUserId;
        }


    }
}
