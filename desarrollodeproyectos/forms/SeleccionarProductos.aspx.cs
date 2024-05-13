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
    public partial class SeleccionarProductos : System.Web.UI.Page
    {
        int idusua;
        string NombreUsua;

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                idusua = Convert.ToInt32(Request.QueryString["abcd"]);
                NombreUsua = Convert.ToString(Request.QueryString["def"]);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_PRODUCTO";
                cmd.Parameters.Add("@OP", SqlDbType.TinyInt).Value = 4;
                cmd.Parameters.Add("@PROD_IdUsuario", SqlDbType.Int).Value = idusua;
                cmd.Connection = conn;

                try
                {
                    conn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);

                    gvProductos.DataSource = ds;
                    gvProductos.DataBind();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtiene el índice de la fila seleccionada
            int index = gvProductos.SelectedIndex;

            // Obtiene los datos de la fila seleccionada
            int Id = Convert.ToInt32(gvProductos.SelectedRow.Cells[1].Text);
            //string Nombre = gvProductos.SelectedRow.Cells[2].Text;
            //decimal Precio = Convert.ToDecimal(gvProductos.SelectedRow.Cells[3].Text);
            //int StockMin = Convert.ToInt32(gvProductos.SelectedRow.Cells[4].Text);
            //int StockMax = Convert.ToInt32(gvProductos.SelectedRow.Cells[5].Text);
            //int TipoComida = Convert.ToInt32(gvProductos.SelectedRow.Cells[6].Text);
            //string Descripcion = gvProductos.SelectedRow.Cells[7].Text;
            //string urlimga = gvProductos.SelectedRow.Cells[8].Text;
            //string urlimgb = gvProductos.SelectedRow.Cells[9].Text;
            //string urlimgc = gvProductos.SelectedRow.Cells[10].Text;
            //bool estado = Convert.ToBoolean(gvProductos.SelectedRow.Cells[11].Text);
            ////int IdUsau = Convert.ToInt32(gvProductos.SelectedRow.Cells[8].Text);

            //string accion = Convert.ToString(Session["Accion"]);

            // Almacena los datos en variables de sesión
            //Session["PROD_Id"] = Id;
            //Session["PROD_Nombre"] = Nombre;
            //Session["PROD_Precio"] = Precio;
            //Session["PROD_StockMin"] = StockMin;
            //Session["PROD_StockMax"] = StockMax;
            //Session["PROD_TipoComida"] = TipoComida;
            //Session["PROD_Descripcion"] = Descripcion;
            //Session["PROD_URLImga"] = urlimga;
            //Session["PROD_URLImgb"] = urlimgb;
            //Session["PROD_URLImgc"] = urlimgc;
            //Session["PROD_Status"] = estado;
            ////Session["PROD_IdUsuario"] = IdUsau;
            //Session["Accion"] = accion;

            Response.Redirect("CatalogoProductos.aspx?abc=" + Id + "&abcd=" + idusua + "&def=" + NombreUsua);
        }
    }
}