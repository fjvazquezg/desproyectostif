using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Services;

namespace desarrollodeproyectos
{
    public partial class MetodoDePago : System.Web.UI.Page
    {

        [WebMethod]
        public static void SaveCard(string cardType, string cardNumber, string cardName, string expiryDate, string securityCode)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_USUCARD", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OP", 1);
                    command.Parameters.AddWithValue("@USUCARD_ID", 0);
                    command.Parameters.AddWithValue("@USR_ID", 0);
                    command.Parameters.AddWithValue("@CARD_TYPE", cardType);
                    command.Parameters.AddWithValue("@NUMERO_TARJETA", cardNumber);
                    command.Parameters.AddWithValue("@NOMBRE_EN_TARJETA", cardName);
                    command.Parameters.AddWithValue("@FECHA_EXPIRACION", Convert.ToDateTime(expiryDate));
                    command.Parameters.AddWithValue("@CODIGO_SEGURIDAD", securityCode);
                    command.Parameters.AddWithValue("@MET_ID", 0);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}