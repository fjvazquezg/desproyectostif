using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace desarrollodeproyectos.forms
{
    public partial class MetodoDeEntrega : System.Web.UI.Page
    {
        private string Edificio;
        private string Salon;
        private string Telefono;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Edificio = dotxtEdificio.Value;
            Salon = dotxtSalon.Value;
            Telefono = dotxtTelefono.Value;

            if ((dotxtEdificio.Value == "") || (dotxtSalon.Value == "") || (dotxtTelefono.Value == ""))
            {
                Response.Write("Faltan datos que rellenar");
            }
            else
            {
                InsertarDatos("Domicilio");
            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {

        }

        private void InsertarDatos(string MetoEntrega)
        {

            // Obtiene la cadena de conexión llamada "SA" del archivo de configuración (Web.config)
            string connectionString = ConfigurationManager.ConnectionStrings["SA"].ConnectionString;

            // Establece una conexión a la base de datos utilizando la cadena de conexión obtenida
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SP_PuntoEntrega", connection);
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.AddWithValue("@OP", 1);
                command.Parameters.AddWithValue("@idPunto", 0);
                command.Parameters.AddWithValue("@tipoEntrega", MetoEntrega);
                command.Parameters.AddWithValue("@edificio", Edificio);
                command.Parameters.AddWithValue("@salon", Salon);
                command.Parameters.AddWithValue("@telefono", Telefono);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje de error al usuario
                    Response.Write("Ha ocurrido un error al procesar la solicitud. Por favor, inténtalo de nuevo más tarde.");
                    // También podrías redirigir a una página de error personalizada.
                }
                finally
                {
                    connection.Close();
                }
            }
        }


    }
}