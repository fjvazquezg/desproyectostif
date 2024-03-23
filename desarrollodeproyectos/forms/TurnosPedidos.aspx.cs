using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace desarrollodeproyectos.forms
{
    public partial class TurnosPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verificar si el usuario está autenticado y es vendedor
                if (Session["TipoUsuario"] != null && Session["TipoUsuario"].ToString() == "Vendedor")
                {
                    // Obtener datos de la base de datos y enlazarlos con la GridView
                    BindGridView();
                }
                else
                {
                    // Redirigir al usuario a una página de acceso denegado o mostrar un mensaje de error
                    Response.Redirect("AccesoDenegado.aspx");
                }
            }
        }

        private void BindGridView()
        {
            // Cadena de conexión a la base de datos
            string constr = ConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT CAR_Id, CAR_Fecha, CAR_LugarDeEntrega, CAR_TipoDeEntrega, CAR_Total, CAR_Status FROM CARRITO", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }
}
