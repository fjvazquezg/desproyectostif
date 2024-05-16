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
    public partial class MetodoDePago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTiposTarjeta();
            }
        }

        protected void guardarTarjetaButton_Click(object sender, EventArgs e)
        {
            // Obtener el ID del usuario
            int userId = ObtenerIdUsuario(); // Esto debería obtener el ID del usuario actualmente autenticado o establecerlo según tu lógica de negocio

            // Obtener los valores de los controles
            string cardType = ddlTipoTarjeta.SelectedValue;
            string cardNumber = numeroTarjetaDialog.Text;
            string cardName = nombreTarjetaDialog.Text;
            string expirationDate = fechaExpiracionDialog.Text;
            string securityCode = codigoSeguridad1.Text + codigoSeguridad2.Text;

            try
            {
                // Procesar los datos y guardar la tarjeta en la base de datos
                int metId = SaveCard(userId, cardType, cardNumber, cardName, expirationDate, securityCode);

                // Mostrar un mensaje de éxito
                string mensajeExito = $"Tarjeta guardada correctamente. ID: {metId}";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{mensajeExito}');", true);

                // Limpiar los campos de entrada
                ddlTipoTarjeta.ClearSelection(); // Limpiar la selección del DropDownList
                numeroTarjetaDialog.Text = "";
                nombreTarjetaDialog.Text = "";
                fechaExpiracionDialog.Text = "";
                codigoSeguridad1.Text = "";
                codigoSeguridad2.Text = "";

                // Redireccionar a otra página (opcional)
                // Response.Redirect("OtraPagina.aspx");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ocurrió un error al guardar la tarjeta. Por favor, inténtalo de nuevo más tarde.');", true);
            }
        }

        protected void efectivo_CheckedChanged(object sender, EventArgs e)
        {
            // Manejar el evento efectivo_CheckedChanged aquí
        }


        private int ObtenerIdUsuario()
        {
            // Define una variable para almacenar el ID del usuario
            int userId = 0;

            // Conecta con la base de datos y consulta el ID del usuario
            string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Define la consulta SQL para obtener el ID del usuario
                string query = "SELECT TOP 1 USU_ID FROM USUARIO";

                // Crea el comando SQL
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    // Abre la conexión con la base de datos
                    connection.Open();

                    // Ejecuta la consulta y obtiene el resultado
                    userId = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    // Maneja la excepción (por ejemplo, registra un mensaje de error)
                    Console.WriteLine("Error al obtener el ID del usuario: " + ex.Message);
                    // En una aplicación web, podrías mostrar un mensaje de error al usuario
                }
            }

            // Devuelve el ID del usuario
            return userId;
        }

        private void CargarTiposTarjeta()
        {
            try
            {
                // Obtener la cadena de conexión desde Web.config
                string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

                // Query SQL para obtener los tipos de tarjeta desde la base de datos
                string query = "SELECT MET_NAME FROM METODO_PAGO";

                // Crear una conexión y un comando SQL
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Abrir la conexión
                        connection.Open();

                        // Ejecutar la consulta y obtener los resultados
                        SqlDataReader reader = command.ExecuteReader();

                        // Recorrer los resultados y agregar cada tipo de tarjeta como una opción al select
                        while (reader.Read())
                        {
                            string tipoTarjeta = reader["MET_NAME"].ToString();
                            // ddlTipoTarjeta.Items.Add(new ListItem(tipoTarjeta, tipoTarjeta));
                        }

                        // Cerrar el reader y la conexión
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción (por ejemplo, mostrar un mensaje de error)
                Console.WriteLine("Error al cargar los tipos de tarjeta: " + ex.Message);
            }
        }

        private int SaveCard(int userId, string cardType, string cardNumber, string cardName, string expiryDate, string securityCode)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
            int metodoPagoId = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_USUCARD", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OP", 1);
                    command.Parameters.AddWithValue("@USUCARD_ID", 0); // Esto debería ser 0 si estás insertando un nuevo registro
                    command.Parameters.AddWithValue("@USR_ID", userId); // Aquí pasas el ID del usuario
                    command.Parameters.AddWithValue("@CARD_TYPE", cardType);
                    command.Parameters.AddWithValue("@NUMERO_TARJETA", cardNumber);
                    command.Parameters.AddWithValue("@NOMBRE_EN_TARJETA", cardName);
                    command.Parameters.AddWithValue("@FECHA_EXPIRACION", Convert.ToDateTime(expiryDate));
                    command.Parameters.AddWithValue("@CODIGO_SEGURIDAD", securityCode);
                    command.Parameters.AddWithValue("@MET_ID", 0); // Asegúrate de obtener este valor si es necesario

                    // Configurar @MET_ID como un parámetro de salida
                    SqlParameter metIdParameter = command.Parameters.Add("@MET_ID", SqlDbType.Int);
                    metIdParameter.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    // Obtener el valor de @MET_ID después de ejecutar el procedimiento almacenado
                    metodoPagoId = Convert.ToInt32(metIdParameter.Value);
                }
            }

            // Devolver el ID del método de pago
            return metodoPagoId;
        }
    }
}