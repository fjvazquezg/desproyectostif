using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.IO;

namespace desarrollodeproyectos.forms
{
    public partial class CatalogoProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IdUsuar.Text = "1";
                NombreUsua.Text = "Juan Lopez Lopez";
                CargarConsecutivo();
                CargaTipoComida();
            }
        }

        public void CargaTipoComida()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TC_Nombre, TC_Id FROM TIPOCOMIDA";
                cmd.Connection = conn;

                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ListItem item = new ListItem(dr["TC_Nombre"].ToString(), dr["TC_Id"].ToString());
                        Seleccion.Items.Add(item);
                    }

                    dr.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void CargarConsecutivo()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT ISNULL(MAX(PROD_Id),0) + 1 as Consec FROM PRODUCTO";
                cmd.Connection = conn;

                try
                {
                    conn.Open();
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        IdProduc.Text = dr.GetInt32(0).ToString();
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void RegistrarProducto()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                //string sRuta = "C:/Users/cotan/Documents/VS Code/desproyectostif/desarrollodeproyectos/Img/";
                string fileName = "";
                string filePath = "";
                if (ImgFile != null)
                {
                    //sRuta = ImgFile.FileName;
                    //ImgFile.SaveAs(Server.MapPath(sRuta));

                    fileName = Path.GetFileName(ImgFile.FileName);
                    filePath = Server.MapPath("~/Img/") + fileName;
                    ImgFile.SaveAs(filePath);
                }
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_PRODUCTO";
                cmd.Parameters.Add("@OP", SqlDbType.TinyInt).Value = 1;
                cmd.Parameters.Add("@PROD_Id", SqlDbType.Int).Value = IdProduc.Text.Trim();
                cmd.Parameters.Add("@PROD_Nombre", SqlDbType.VarChar).Value = NombreProduc.Text.Trim();
                cmd.Parameters.Add("@PROD_Precio", SqlDbType.Decimal).Value = PrecioProdu.Text.Trim();
                cmd.Parameters.Add("@PROD_StockMin", SqlDbType.Int).Value = StockMin.Text.Trim();
                cmd.Parameters.Add("@PROD_StockMax", SqlDbType.Int).Value = StockMax.Text.Trim();
                cmd.Parameters.Add("@PROD_TipoComida", SqlDbType.Int).Value = Seleccion.SelectedValue;
                cmd.Parameters.Add("@PROD_URLImga", SqlDbType.VarChar).Value = filePath.ToString();
                cmd.Parameters.Add("@PROD_IdUsuario", SqlDbType.Int).Value = IdUsuar.Text.Trim();
                cmd.Connection = conn;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void ClearTodo()
        {
            IdProduc.Text = "";
            NombreProduc.Text = "";
            PrecioProdu.Text = "";
            StockMin.Text = "";
            StockMax.Text = "";
            DescripcionProduc.Text = "";
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarProducto();
            ClearTodo();
            CargarConsecutivo();
        }


        /*using (SqlConnection conn = new SqlConnection (ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "";
                    cmd.Connection = conn;
                    conn.Open();
                }*/
    }
}