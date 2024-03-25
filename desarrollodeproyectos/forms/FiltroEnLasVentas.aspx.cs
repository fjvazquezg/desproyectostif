using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace desarrollodeproyectos.forms
{
    public partial class FiltroEnLasVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    // Obtener los valores de los parámetros
                    double precioMin = double.Parse(Request.QueryString["PrecioMin"]);
                    double precioMax = double.Parse(Request.QueryString["PrecioMax"]);

                    // Establecer los valores iniciales en los controles de entrada
                    txtPrecioMin.Text = precioMin.ToString();
                    txtPrecioMax.Text = precioMax.ToString();

                    FiltrarProductos(precioMin, precioMax);
                }
            }
            catch
            {
                // Manejar errores
            }
        }

        public void FiltrarProductos(double precioMin, double precioMax)
        {
            List<Producto> productosFiltrados = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                conn.Open();

                string nombreProcedimiento = "SP_PRODUCTO";

                SqlCommand comando = new SqlCommand(nombreProcedimiento, conn);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@OP", 7);
                comando.Parameters.AddWithValue("@PrecioMin", precioMin);
                comando.Parameters.AddWithValue("@PrecioMax", precioMax);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = int.Parse(reader["PROD_Id"].ToString());
                    producto.Nombre = reader["PROD_Nombre"].ToString();
                    producto.Precio = double.Parse(reader["PROD_Precio"].ToString());

                    productosFiltrados.Add(producto);
                }
                reader.Close();
            }

            // filtrar según el rango de precios
            productosFiltrados = productosFiltrados.Where(p => p.Precio >= precioMin && p.Precio <= precioMax).ToList();

            RepeaterProductos.DataSource = productosFiltrados;
            RepeaterProductos.DataBind();
        }


        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            // Obtener valores de los cuadros de texto de precios
            double precioMin = double.Parse(txtPrecioMin.Text);
            double precioMax = double.Parse(txtPrecioMax.Text);

            FiltrarProductos(precioMin, precioMax);
        }

        internal class Producto
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public double Precio { get; set;}
        }
    }
}