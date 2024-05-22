using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace desarrollodeproyectos.forms
{
    public partial class UsuRegistro : System.Web.UI.Page
    {

        private string idusuario;
        private string nombre;
        private string apellido;
        private string correo;
        private string telefono;
        private string contraseña;
        private string cfscontraseña;
        private string fecharegistro;

        protected void Page_Load(object sender, EventArgs e)
        {
            //coment
        }

        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]); // Corrección en el formato
            }
            return sb.ToString();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            nombre = txtNombre.Text;
            correo = txtCorreo.Text;
            telefono = txtTelefono.Text;
            contraseña = GetSHA256(txtContrasena.Text);
            cfscontraseña = GetSHA256(txtContrasena2.Text);
            apellido = txtApellido.Text;

            if (contraseña == cfscontraseña)
            {
                InsertarUsuario();
            }
            else
            {
                Response.Write("La contraseña no concuerdan.");
            }
        }

        private void InsertarUsuario()
        {
            // Obtener la fecha y hora actual
            DateTime fecha = DateTime.Now;

            // Obtiene la cadena de conexión llamada "connDB" del archivo de configuración (Web.config)
            string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

            // Establece una conexión a la base de datos utilizando la cadena de conexión obtenida
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SP_USUARIO", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Obtenemos el próximo ID consecutivo
                int nextUserId = GetNextUserId(connection);

                command.Parameters.AddWithValue("@OP", 1);
                command.Parameters.AddWithValue("@USU_ID", nextUserId);
                command.Parameters.AddWithValue("@USU_NOMBRE", nombre);
                command.Parameters.AddWithValue("@USU_APELLIDO", apellido);
                command.Parameters.AddWithValue("@USU_EMAIL", correo);
                command.Parameters.AddWithValue("@USU_TELELEFONO", telefono);
                command.Parameters.AddWithValue("@USU_CONTRASEÑA", contraseña);
                command.Parameters.AddWithValue("@USU_FECHAREGISTRO", fecha);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    Response.Write("Usuario registrado correctamente.");

                }
                catch (Exception ex)
                {

                    Response.Write("Ha ocurrido un error al registrar el usuario. Por favor, inténtalo de nuevo más tarde.");

                }
                finally
                {
                    connection.Close();
                }
            }

        }


        // Método para obtener el próximo ID consecutivo
        private int GetNextUserId(SqlConnection connection)
        {
            int nextUserId = 0;

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT ISNULL(MAX(USU_ID), 0) + 1 as consec FROM USUARIO";

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

                Response.Write($"Error al obtener el próximo ID consecutivo: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return nextUserId;
        }
        protected void btnRegistrarVendedor_Click(object sender, EventArgs e)
        {
            // Guardar los datos en variables de sesión para usarlos en la siguiente página
            Session["Nombre"] = txtNombre.Text;
            Session["Apellido"] = txtApellido.Text;
            Session["Correo"] = txtCorreo.Text;
            Session["Telefono"] = txtTelefono.Text;
            Session["Contrasena"] = GetSHA256(txtContrasena.Text); // Guardar la contraseña cifrada



            // Redirigir al formulario de verificación de documentos
            Response.Redirect("MetodosDeComprobacion.aspx");
        }


    }
}