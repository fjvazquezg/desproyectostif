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
    public partial class MetodoDeEntrega : System.Web.UI.Page
    {

        private string LugarEntrega;
        private int carId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["car_id"] != null)
                {
                    carId = Convert.ToInt32(Request.QueryString["car_id"]);
                    // Utiliza el carId como necesites
                }
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            LugarEntrega = dotxtLugarEntrega.Text;

            if (dotxtLugarEntrega.Text == "")
            {
                Response.Write("Faltan datos que rellenar");
            }
            else
            {
                InsertarDatos("Domicilio");
                Vaciardatos();
            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            LugarEntrega = putxtLugarEntrega.Text;

            if (putxtLugarEntrega.Text == "")
            {
                Response.Write("Faltan datos que rellenar");
            }
            else
            {
                InsertarDatos("Retirar de un punto de entrega");
                Vaciardatos();
            }
        }

        private void Vaciardatos()
        {
            dotxtLugarEntrega.Text = "";
            putxtLugarEntrega.Text = "";
        }

        private void InsertarDatos(string MetoEntrega)
        {
            // en el codigo del erik poner  Almacena el CAR_ID en la sesión "Session["CAR_ID"] = carritoId;"
            // int car_id = Convert.ToInt32(Session["CAR_ID"]);

            // Obtiene la cadena de conexión llamada "SA" del archivo de configuración (Web.config)
            string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

            // Establece una conexión a la base de datos utilizando la cadena de conexión obtenida
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SP_CARRITO", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@OP", 3);
                command.Parameters.AddWithValue("@CAR_UsuarioId", carId);
                command.Parameters.AddWithValue("@CAR_TipoDeEntrega", MetoEntrega);
                command.Parameters.AddWithValue("@CAR_LugarDeEntrega", LugarEntrega);

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