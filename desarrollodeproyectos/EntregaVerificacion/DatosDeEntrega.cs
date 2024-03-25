using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace desarrollodeproyectos.EntregasVerificacion
{
    public class DatosDeEntrega
    {
       
        private readonly string _connectionString;

        public DatosDeEntrega()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
        }

        // datos del usuario 
        public (string Email, string Nombre, string Apellido) ObtenerDatosUsuario(int usuarioId)
        {
            try
            {
                string email = string.Empty;
                string nombre = string.Empty;
                string apellido = string.Empty;

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_OBTENER_DATOS_USER", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UsuarioId", usuarioId);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            email = reader.GetString(reader.GetOrdinal("Correo"));
                            nombre = reader.GetString(reader.GetOrdinal("Nombre"));
                            apellido = reader.GetString(reader.GetOrdinal("Apellido"));
                        }

                        reader.Close();
                    }
                }

                return (email, nombre, apellido);
            }
            catch (SqlException ex)
            {

                Console.WriteLine($"Error al obtener datos del usuario: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw;
            }
        }

        // datos del carrito 
        public (string Data, decimal Total) ObtenerDatosCarrito(int carritoId)
        {
            try
            {
                string data = string.Empty;
                decimal total = 0;

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_OBTENER_DATOS_CARR", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CarritoId", carritoId);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            int productoId = reader.GetInt32(reader.GetOrdinal("CAR_DET_ProductoId"));
                            decimal precio = reader.GetDecimal(reader.GetOrdinal("CAR_DET_Precio"));
                            int cantidad = reader.GetInt32(reader.GetOrdinal("CAR_DET_Cantidad"));
                            decimal importe = reader.GetDecimal(reader.GetOrdinal("CAR_DET_Importe"));

                            data += $"{productoId}:{precio}:{cantidad}:{importe};";
                            total += importe;
                        }

                        reader.Close();
                    }
                }

                return (data, total);
            }
            catch (SqlException ex)
            {

                Console.WriteLine($"Error al obtener datos del carrito: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw;
            }
        }
    }
}
