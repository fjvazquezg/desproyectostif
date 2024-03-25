using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace desarrollodeproyectos.forms
{
    public partial class AddMetodoPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Llama a un método para cargar los datos en el GridView al cargar la página por primera vez.
                CargarDatosMetodosPago();
            }
        }

        protected void GuardarMetodoPago_Click(object sender, EventArgs e)
        {
            string metodoPagoName = txtMetodoPagoName.Value; // Obtener el valor del input

            // Obtener la cadena de conexión desde Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_METODO_PAGO", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OP", 1);
                    command.Parameters.AddWithValue("@MET_NAME", metodoPagoName);

                    // Configurar @MET_ID como un parámetro de salida
                    SqlParameter metIdParameter = command.Parameters.Add("@MET_ID", SqlDbType.Int);
                    metIdParameter.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    // Obtener el valor de @MET_ID después de ejecutar el procedimiento almacenado
                    int metodoPagoId = Convert.ToInt32(metIdParameter.Value);

                    // Utilizar el valor de @MET_ID en tu aplicación si es necesario
                    // Por ejemplo, puedes mostrarlo en un mensaje de éxito
                    string mensajeExito = $"Método guardado correctamente. ID: {metodoPagoId}";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{mensajeExito}');", true);

                    // Llama a este método para recargar los datos en el GridView después de insertar un nuevo método de pago.
                    CargarDatosMetodosPago();
                }
            }

        }

        protected void CargarDatosMetodosPago()
        {
            try
            {
                // Obtener la cadena de conexión desde Web.config
                string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SELECT MET_ID, MET_NAME FROM METODO_PAGO", connection))
                    {
                        connection.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Enlaza los datos al GridView
                        gridMetodosPago.DataSource = dt;
                        gridMetodosPago.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al cargar los datos de métodos de pago: " + ex.Message);
                // Agregar un mensaje de error a la página
                lblError.Text = "Error al cargar los datos de métodos de pago: " + ex.Message;
            }

        }

        protected void ActualizarMetodoPago_Click(object sender, EventArgs e)
        {
            // Obtener el ID del método de pago a actualizar
            Button btn = (Button)sender;
            int metodoPagoId = Convert.ToInt32(btn.CommandArgument);

            // Obtener el nuevo nombre del método de pago desde algún control, como un TextBox
            // Suponiendo que tengas un TextBox con ID "txtNuevoNombre"
            string nuevoNombre = txtNuevoNombre.Text;
            

            // Llamar al método de actualización
            ActualizarMetodoPago(metodoPagoId, nuevoNombre);
        }

        protected void ActualizarMetodoPago(int metodoPagoId, string nuevoNombre)
        {
            // Obtener la cadena de conexión desde Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_METODO_PAGO", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OP", 3); // Operación de actualización
                    command.Parameters.AddWithValue("@MET_ID", metodoPagoId); // ID del método de pago a actualizar
                    command.Parameters.AddWithValue("@MET_NAME", nuevoNombre); // Nuevo nombre del método de pago

                    connection.Open();
                    command.ExecuteNonQuery();

                    // Mensaje de éxito
                    string mensajeExito = $"Método actualizado correctamente. ID: {metodoPagoId}";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{mensajeExito}');", true);

                    // Recargar los datos en el GridView después de la actualización
                    CargarDatosMetodosPago();
                }
            }
        }

        protected void EliminarMetodoPago_Click(object sender, EventArgs e)
        {
            // Obtener el ID del método de pago a eliminar
            Button btn = (Button)sender;
            int metodoPagoId = Convert.ToInt32(btn.CommandArgument);

            // Llamar al método de eliminación
            EliminarMetodoPago(metodoPagoId);
        }

        protected void EliminarMetodoPago(int metodoPagoId)
        {
            // Obtener la cadena de conexión desde Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_METODO_PAGO", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OP", 2); // Operación de eliminación
                    command.Parameters.AddWithValue("@MET_ID", metodoPagoId); // ID del método de pago a eliminar

                    connection.Open();
                    command.ExecuteNonQuery();

                    // Mensaje de éxito
                    string mensajeExito = $"Método eliminado correctamente. ID: {metodoPagoId}";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{mensajeExito}');", true);

                    // Recargar los datos en el GridView después de la eliminación
                    CargarDatosMetodosPago();
                }
            }
        }

    }
}