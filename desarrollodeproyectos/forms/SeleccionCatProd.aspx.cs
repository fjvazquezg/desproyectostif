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
            Response.Redirect("CatalogoProductos.aspx?abcd=" + IdUsua + "&def=" + NombreUsua);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeleccionarProductos.aspx?abcd=" + IdUsua + "&def=" + NombreUsua);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("CatalagoTipoComida.aspx?abcd=" + IdUsua + "&def=" + NombreUsua);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Control_Inventario/Control.Inventario.html?abcd=" + IdUsua + "&def=" + NombreUsua);
        }
    }
}