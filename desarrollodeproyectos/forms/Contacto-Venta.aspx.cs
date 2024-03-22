using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace desarrollodeproyectos.forms
{
    public partial class Contacto_Venta : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnChat_Click(object sender, EventArgs e)
        {
            // Redirigir al chat privado
            Response.Redirect("Chat_Privado.html");
        }

        protected void btnWhatsApp_Click(object sender, EventArgs e)
        {
            // Redirigir al contacto de WhatsApp
            Response.Redirect("https://api.whatsapp.com/send?phone=526871001414");
        }
    }
}