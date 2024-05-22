using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace desarrollodeproyectos.forms
{
    public partial class Resena : System.Web.UI.Page
    {
        private void GuardarReseña(int idVendedor, int cantidadEstrellas, string reseña)
        {
            try
            {
                // Obtener la cadena de conexión desde el archivo de configuración
                string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

                // Crear la conexión
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "OP";

                    // Obtener el siguiente RES_ID (suponiendo que se guarda manualmente)
                    int resId = ObtenerSiguienteResId(conn);

                    // Agregar los parámetros al comando
                    cmd.Parameters.AddWithValue("@OP", 1);
                    cmd.Parameters.AddWithValue("@RES_ID", resId);
                    cmd.Parameters.AddWithValue("@VEN_ID", 1);
                    cmd.Parameters.AddWithValue("@USU_ID", 1);
                    cmd.Parameters.AddWithValue("@Calificacion", cantidadEstrellas);
                    cmd.Parameters.AddWithValue("@Comentario", reseña);

                    // Abrir la conexión
                    conn.Open();

                    // Ejecutar el comando
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // lblMensaje.Text = "Error al guardar la reseña: " + ex.Message;

            }
        }

        private int ObtenerSiguienteResId(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(RES_ID), 0) + 1 FROM Reseña", conn);
            conn.Open();
            int nextId = (int)cmd.ExecuteScalar();
            conn.Close();
            return nextId;
        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            int idVendedor = 1; // ID del vendedor
            int cantidadEstrellas = ObtenerCantidadEstrellas(); // Obtener la cantidad de estrellas seleccionadas
            string reseña = comentario.Text; // Obtener el texto de la reseña

            // Guardar en la base de datos utilizando un procedimiento almacenado
            GuardarReseña(idVendedor, cantidadEstrellas, reseña);
        }

        protected int ObtenerCantidadEstrellas()
        {
            int cantidadEstrellas = 0;
            foreach (Control control in Panel1.Controls)
            {
                if (control is HiddenField hiddenField)
                {
                    if (hiddenField.ID.StartsWith("star_") && hiddenField.Value == "1")
                    {
                        cantidadEstrellas++;
                    }
                }
            }
            return cantidadEstrellas;
        }
    }
}

