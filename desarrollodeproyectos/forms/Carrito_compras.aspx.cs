using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace desarrollodeproyectos
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosAlDataGridView(1);
            }
        }

        protected void GridViewCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(GridViewCarrito.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_CARRITO_DETALLE", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OP", 2);
                    cmd.Parameters.AddWithValue("@CAR_DET_ID", index);

                    int idcarrito = ObtenerDatos(index, 5);

                    cmd.Parameters.AddWithValue("@CAR_DET_CarritoId", idcarrito);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
                CargarDatosAlDataGridView(1);
            }
        }

        public void CrearCarrito(int productoId, int usuarioId, int cantidad)
        {
            int carritoId = ObtenerDatos(usuarioId, 1);

            if (carritoId == 0)
            {
                carritoId = ObtenerDatos(usuarioId, 1) + 1;

                CrearNuevoCarrito(usuarioId, carritoId);
            }
            if (ObtenerDatos(usuarioId, 4) == 0) // TO-DO comprobar bien como sera el caso cuando una trasnaccion termine borrare la tabla detalle y si la dejo como manejare lo demas? 
            {
                AgregarProductoAlCarritoDetalle(carritoId, productoId, cantidad);

                CargarDatosAlDataGridView(usuarioId);
            }
        }


        private void CrearNuevoCarrito(int usuarioId, int carritoId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CARRITO", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OP", 1);
                cmd.Parameters.AddWithValue("@CAR_ID", carritoId);
                cmd.Parameters.AddWithValue("@CAR_UsuarioId", usuarioId);
                cmd.Parameters.AddWithValue("@CAR_Fecha", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("@CAR_LugarDeEntrega", "");
                cmd.Parameters.AddWithValue("@CAR_TipoDeEntrega", "");
                cmd.Parameters.AddWithValue("@CAR_Status", 0);

                connection.Open();

                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        private void AgregarProductoAlCarritoDetalle(int carritoId, int productoId, int cantidad)
        {
            int nuevoIdDetalle = ObtenerDatos(carritoId, 2) + 1;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CARRITO_DETALLE", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OP", 1);
                cmd.Parameters.AddWithValue("@CAR_DET_ID", nuevoIdDetalle);
                cmd.Parameters.AddWithValue("@CAR_DET_CarritoId", carritoId);
                cmd.Parameters.AddWithValue("@CAR_DET_ProductoId", productoId);
                cmd.Parameters.AddWithValue("@CAR_DET_Cantidad", cantidad);

                connection.Open();

                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        private void CargarDatosAlDataGridView(int usuarioId)
        {
            double total = ObtenerDatos(usuarioId, 3);
            lblTotalPagar.Text = "Total a pagar: $" + total.ToString();

            List<CarritoDetalle> detallesCarrito = ObtenerDetallesCarritoDesdeBaseDeDatos();
            GridViewCarrito.DataSource = detallesCarrito;
            GridViewCarrito.DataBind();
        }

        private List<CarritoDetalle> ObtenerDetallesCarritoDesdeBaseDeDatos()
        {
            List<CarritoDetalle> detallesCarrito = new List<CarritoDetalle>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT CD.CAR_DET_ID, CD.CAR_DET_ProductoId, P.PROD_Nombre, P.PROD_Precio, CD.CAR_DET_Cantidad, CD.CAR_DET_Importe, P.PROD_URLImga FROM CARRITODETALLE CD INNER JOIN PRODUCTO P ON CD.CAR_DET_ProductoId = P.PROD_Id", connection); SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    CarritoDetalle detalle = new CarritoDetalle();
                    detalle.URLImagen = row["PROD_URLImga"].ToString();
                    detalle.NombreProducto = row["PROD_Nombre"].ToString();
                    detalle.Precio = Convert.ToDecimal(row["PROD_Precio"]);
                    detalle.Cantidad = Convert.ToInt32(row["CAR_DET_Cantidad"]);
                    detalle.Importe = Convert.ToDecimal(row["CAR_DET_Importe"]);
                    detalle.CAR_DET_ID = Convert.ToInt32(row["CAR_DET_ID"]);
                    detallesCarrito.Add(detalle);
                }
            }
            return detallesCarrito;
        }

        private int ObtenerDatos(int id, int tarea)
        {
            int dato = 0;
            string consulta = "";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                connection.Open();
                switch (tarea)
                {
                    case 1:
                        consulta = "SELECT MAX(CAR_Id) FROM CARRITO WHERE CAR_UsuarioId = @ID";
                        break;
                    case 2:
                        consulta = "SELECT MAX(CAR_DET_Id) FROM CARRITODETALLE WHERE CAR_DET_CarritoId = @ID";
                        break;
                    case 3:
                        consulta = "SELECT CAR_Total FROM CARRITO WHERE CAR_UsuarioId = @ID";
                        break;
                    case 4:
                        consulta = "SELECT CAR_Status FROM CARRITO WHERE CAR_UsuarioId = @ID";
                        break;
                    case 5:
                        consulta = "SELECT CAR_DET_CarritoId FROM CARRITODETALLE WHERE CAR_DET_Id = @ID";
                        break;
                    default:
                        break;
                }
                if (!string.IsNullOrEmpty(consulta))
                {
                    SqlCommand cmd = new SqlCommand(consulta, connection);
                    cmd.Parameters.AddWithValue("@ID", id);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        dato = Convert.ToInt32(result);
                    }
                }
                return dato;
            }
        }
    }

    public class CarritoDetalle
    {
        public string URLImagen { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int CAR_DET_ID { get; set; }
        public decimal Importe { get; set; }
    }
}