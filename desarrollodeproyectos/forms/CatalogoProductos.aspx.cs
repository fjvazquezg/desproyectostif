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
        string defaultImageUrl = "../Img/No2.jpg";

        protected void Page_Load(object sender, EventArgs e)
        {
            int idusua = Convert.ToInt32(Session["PROD_IdUsuario"]);
            string nombreusua = Convert.ToString(Session["PROD_NomUsuario"]);
            string accion = Convert.ToString(Session["Accion"]);

            int prodid = Convert.ToInt32(Session["PROD_Id"]);
            string prodnombre = Convert.ToString(Session["PROD_Nombre"]);
            decimal prodprecio = Convert.ToDecimal(Session["PROD_Precio"]);
            int prodstockmin = Convert.ToInt32(Session["PROD_StockMin"]);
            int prodstockmax = Convert.ToInt32(Session["PROD_StockMax"]);
            int prodtipocomida = Convert.ToInt32(Session["PROD_TipoComida"]);
            string proddescripcion = Convert.ToString(Session["PROD_Descripcion"]);
            /*string urlIMGa = Convert.ToString(Session["PROD_URLImga"]);
            string urlIMGb = Convert.ToString(Session["PROD_URLImgb"]);
            string urlIMGc = Convert.ToString(Session["PROD_URLImgc"]);*/

            if (!IsPostBack)
            {
                if (accion == "1")
                {
                    IdUsuar.Text = idusua.ToString();
                    NombreUsua.Text = nombreusua;
                    lblError.Visible = false;
                    Preview.ImageUrl = defaultImageUrl;
                    Previewb.ImageUrl = defaultImageUrl;
                    Previewc.ImageUrl = defaultImageUrl;
                    CargarConsecutivo();
                    CargaTipoComida();
                }
                else if (accion == "2")
                {
                    IdUsuar.Text = idusua.ToString();
                    NombreUsua.Text = nombreusua;
                    IdProduc.Text = prodid.ToString();
                    NombreProduc.Text = prodnombre;
                    PrecioProdu.Text = prodprecio.ToString();
                    StockMin.Text = prodstockmin.ToString();
                    StockMax.Text = prodstockmax.ToString();
                    Seleccion.SelectedValue = prodtipocomida.ToString();
                    DescripcionProduc.Text = proddescripcion;
                    lblError.Visible = false;
                    Preview.ImageUrl = defaultImageUrl;
                    Previewb.ImageUrl = defaultImageUrl;
                    Previewc.ImageUrl = defaultImageUrl;
                }

                /*IdUsuar.Text = idusua.ToString();
                NombreUsua.Text = nombreusua;
                lblError.Visible = false;
                Preview.ImageUrl = defaultImageUrl;
                Previewb.ImageUrl = defaultImageUrl;
                Previewc.ImageUrl = defaultImageUrl;
                CargarConsecutivo();
                CargaTipoComida();*/
            }
        }

        public void CargaTipoComida()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_TIPOCOMIDA";
                cmd.Parameters.Add("@OP", SqlDbType.TinyInt).Value = 3;
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

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_PRODUCTO";
                cmd.Parameters.Add("@OP", SqlDbType.TinyInt).Value = 3;
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
                string fileNamea = "";
                string fileNameb = "";
                string fileNamec = "";

                string filePatha = "";
                string filePathb = "";
                string filePathc = "";

                string rutaImga = "";
                string rutaImgb = "";
                string rutaImgc = "";

                if (Logo != null || ImagenPromo1 != null || ImagenPromo2 != null)
                {
                    fileNamea = Path.GetFileName(Logo.FileName);
                    fileNameb = Path.GetFileName(ImagenPromo1.FileName);
                    fileNamec = Path.GetFileName(ImagenPromo2.FileName);

                    rutaImga = "../Img/ProdImg/" + fileNamea;
                    rutaImgb = "../Img/ProdImg/" + fileNameb;
                    rutaImgc = "../Img/ProdImg/" + fileNamec;

                    filePatha = Server.MapPath("../Img/ProdImg/") + fileNamea;
                    filePathb = Server.MapPath("../Img/ProdImg/") + fileNameb;
                    filePathc = Server.MapPath("../Img/ProdImg/") + fileNamec;

                    Logo.SaveAs(filePatha);
                    ImagenPromo1.SaveAs(filePathb);
                    ImagenPromo2.SaveAs(filePathc);
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
                cmd.Parameters.Add("@PROD_Descripcion", SqlDbType.VarChar).Value = DescripcionProduc.Text.Trim();
                cmd.Parameters.Add("@PROD_URLImga", SqlDbType.VarChar).Value = rutaImga;
                cmd.Parameters.Add("@PROD_URLImgb", SqlDbType.VarChar).Value = rutaImgb;
                cmd.Parameters.Add("@PROD_URLImgc", SqlDbType.VarChar).Value = rutaImgc;
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
            lblError.Visible = false;
        }


        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (NombreProduc.Text == "" || PrecioProdu.Text == "" || StockMin.Text == "" || StockMax.Text == "" || DescripcionProduc.Text == "" || Logo == null || ImagenPromo1 == null || ImagenPromo2 == null)
            {
                lblError.Visible = true;
                lblError.Text = "Faltan datos por llenar, porfavor de rellenarlos";
            }
            else
            {
                // Lista para almacenar los mensajes de error de cada imagen
                List<string> errores = new List<string>();

                // Verificar y evaluar las dimensiones de cada imagen
                foreach (FileUpload fileUpload in new FileUpload[] { Logo, ImagenPromo1, ImagenPromo2 })
                {
                    // Verificar si se ha seleccionado un archivo
                    if (fileUpload.HasFile)
                    {
                        // Leer la imagen desde el archivo cargado
                        using (var image = System.Drawing.Image.FromStream(fileUpload.PostedFile.InputStream))
                        {
                            // Verificar las dimensiones de la imagen
                            if (image.Width == 500 && image.Height == 500)
                            {
                                // Si las dimensiones son correctas, no hay errores
                                errores.Add(null);
                            }
                            else
                            {
                                // Si las dimensiones no son correctas, registrar un mensaje de error
                                errores.Add($"Las dimensiones de la imagen {fileUpload.ID} no son las adecuadas");
                            }
                        }
                    }
                    else
                    {
                        // Registrar un mensaje de error si no se ha seleccionado ningún archivo
                        errores.Add($"No se ha seleccionado ninguna imagen en {fileUpload.ID}");
                    }
                }

                // Verificar si hay algún error
                if (errores.Any(error => error != null))
                {
                    // Mostrar los errores
                    lblError.Visible = true;
                    lblError.Text = string.Join("<br>", errores.Where(error => error != null));
                }
                else
                {
                    // Si no hay errores, realizar las acciones necesarias
                    lblError.Visible = false;
                    RegistrarProducto();
                    ClearTodo();
                    CargarConsecutivo();
                }
            }
        }
    }
}