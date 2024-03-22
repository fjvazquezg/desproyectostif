using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace desarrollodeproyectos.forms
{
    public partial class SeleccionCatProd : System.Web.UI.Page
    {
        int IdUsua = 1;
        string NombreUsua = "Juan Lopez Lopez";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Accion"] = "1";
            Session["PROD_IdUsuario"] = IdUsua;
            Session["PROD_NomUsuario"] = NombreUsua;
            Response.Redirect("CatalogoProductos.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["Accion"] = "2";
            Session["PROD_IdUsuario"] = IdUsua;
            Session["PROD_NomUsuario"] = NombreUsua;
            Response.Redirect("SeleccionarProductos.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session["PROD_IdUsuario"] = IdUsua;
            Session["PROD_NomUsuario"] = NombreUsua;
            Response.Redirect("CatalagoTipoComida.aspx");
        }
    }
}