using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
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
                CargarTarjetasGuardadas();
                CargarTotalEfectivo();
            }
        }

        protected void guardarTarjetaButton_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = ObtenerIdUsuario();

                string cardType = ddlTipoTarjeta.SelectedValue;
                string cardNumber = numeroTarjetaDialog.Text;
                string cardName = nombreTarjetaDialog.Text;
                string expirationDate = fechaExpiracionDialog.Text;
                string securityCode = codigoSeguridad1.Text;

                int metId = SaveCard(userId, cardType, cardNumber, cardName, expirationDate, securityCode);

                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Tarjeta guardada correctamente. ID: {metId}');", true);

                LimpiarCampos();
                CargarTarjetasGuardadas();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Ocurrió un error al guardar la tarjeta: {ex.Message}');", true);
            }
        }


        private int ObtenerIdUsuario()
        {
            return 5; 
        }

        private void CargarTiposTarjeta()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                string query = "SELECT DISTINCT CARD_TYPE FROM USUCARD";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            string tipoTarjeta = reader["CARD_TYPE"].ToString();
                            ddlTipoTarjeta.Items.Add(new ListItem(tipoTarjeta, tipoTarjeta));
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
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
                    command.Parameters.AddWithValue("@USUCARD_ID", 0);
                    command.Parameters.AddWithValue("@USR_ID", userId);
                    command.Parameters.AddWithValue("@CARD_TYPE", cardType);
                    command.Parameters.AddWithValue("@NUMERO_TARJETA", cardNumber);
                    command.Parameters.AddWithValue("@NOMBRE_EN_TARJETA", cardName);
                    command.Parameters.AddWithValue("@FECHA_EXPIRACION", Convert.ToDateTime(expiryDate));
                    command.Parameters.AddWithValue("@CODIGO_SEGURIDAD", securityCode);

                    SqlParameter metIdParameter = new SqlParameter("@MET_ID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(metIdParameter);

                    connection.Open();
                    command.ExecuteNonQuery();
                    metodoPagoId = Convert.ToInt32(metIdParameter.Value);
                }
            }
            return metodoPagoId;
        }

        private void LimpiarCampos()
        {
            ddlTipoTarjeta.ClearSelection();
            numeroTarjetaDialog.Text = "";
            nombreTarjetaDialog.Text = "";
            fechaExpiracionDialog.Text = "";
            codigoSeguridad1.Text = "";
        }

        private void CargarTarjetasGuardadas()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
                string query = "SELECT CARD_TYPE, NUMERO_TARJETA, NOMBRE_EN_TARJETA FROM USUCARD";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        repeaterTarjetas.DataSource = reader;
                        repeaterTarjetas.DataBind();

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar las tarjetas guardadas: " + ex.Message);
            }
        }

        protected void btnEliminarTarjeta_Click(object sender, EventArgs e)
        {
            LinkButton btnEliminar = (LinkButton)sender;
            string numeroTarjeta = btnEliminar.CommandArgument;

            try
            {
                
                string query = "DELETE FROM USUCARD WHERE NUMERO_TARJETA = @NumeroTarjeta";

                string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                       
                        command.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                
                CargarTarjetasGuardadas();
            }
            catch (Exception ex)
            {
               
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al eliminar la tarjeta: {ex.Message}');", true);
            }
        }

        private decimal ObtenerTotalCarrito(int carritoId)
        {
            decimal total = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
            string query = "SELECT SUM(CAR_DET_Importe) FROM CARRITO_DETALLE WHERE CAR_DET_CarritoId = @CarritoId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarritoId", carritoId);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        total = Convert.ToDecimal(result);
                    }
                }
            }
            return total;
        }

        private void CargarTotalEfectivo()
        {
            try
            {
                int carritoId = ObtenerCarritoIdPorUsuario(); // Método que obtiene el ID del carrito actual del usuario
                decimal totalCarrito = ObtenerTotalCarrito(carritoId);
                precioCompra.Text = totalCarrito.ToString("F2"); // Formatear el total a 2 decimales
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar el total en efectivo: " + ex.Message);
            }
        }

        private int ObtenerCarritoIdPorUsuario()
        {
            int carritoId = 0;
            int userId = ObtenerIdUsuario(); // Método que obtiene el ID del usuario actual
            string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
            string query = "SELECT CAR_Id FROM CARRITO WHERE CAR_UsuarioId = @UserId AND CAR_Status = 'Active'"; // Assuming 'Active' status for the current cart

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        carritoId = Convert.ToInt32(result);
                    }
                }
            }
            return carritoId;
        }

    }
}