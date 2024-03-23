using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace desarrollodeproyectos.Controllers
{
    public class ControllerQRController : Controller
    {
        [HttpPost]
        public ActionResult ActualizarEstado(string codigoVerificacion)
        {
            try
            {
                // Cadena de conexión a tu base de datos
                string connectionString = "Data Source=doli.servehttp.com\\sql2017,1434;Initial Catalog=DESPROYECTOS;User ID=sa;Password=123qwe!@#";

                // Crear la conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Definir el comando para ejecutar el procedimiento almacenado
                    SqlCommand command = new SqlCommand("ActualizarEstadoCarrito", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Pasar el parámetro al procedimiento almacenado
                    command.Parameters.AddWithValue("@CarritoId", codigoVerificacion);

                    // Ejecutar el procedimiento almacenado
                    command.ExecuteNonQuery();

                    // Devolver un mensaje de éxito
                    return Content("Estado actualizado correctamente para el código de verificación: " + codigoVerificacion);
                }
            }
            catch (Exception ex)
            {
                // Manejar errores si es necesario
                return Content("Error al actualizar el estado: " + ex.Message);
            }
        }
    }
}
