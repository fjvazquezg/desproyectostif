using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace desarrollodeproyectos
{
    public partial class AgregarTarjeta : System.Web.UI.Page
    {
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

                    // Agregar parámetro de salida para @MET_ID
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
                }
            }
        }
    }
}
