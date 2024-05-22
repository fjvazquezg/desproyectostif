using desarrollodeproyectos.EntregasVerificacion;
using System;
using System.EnterpriseServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

namespace desarrollodeproyectos.forms
{
    public partial class CorreoVerificacion : System.Web.UI.Page
    {
        private CodigoGenerador codigoGenerador;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            codigoGenerador = new CodigoGenerador();

            if (!IsPostBack)
            {
                Session["USU_ID"] = 1;
                Session["CARR_ID"] = 1;

                int usuarioId = ObtenerUsuario();
                int carritoId = ObtenerCarrito();

                try
                {
                    DatosDeEntrega datosEntrega = new DatosDeEntrega();
                    var (email, nombre, apellido) = datosEntrega.ObtenerDatosUsuario(usuarioId);
                    var (dataCarrito, totalCarrito) = datosEntrega.ObtenerDatosCarrito(carritoId);
                    var (qrCodeBitmap, codigo) = codigoGenerador.GenerateCodeAndQr(dataCarrito, totalCarrito);

                    // Convertir el Bitmap a una cadena Base64
                    string qrCodeBase64 = ProcesoDeEntrega.ProcesoEntrega.BitmapToBase64(qrCodeBitmap);

                    // Mostrar resultados en el frontend
                    qrCodeDisplay.InnerHtml = $"<img src='data:image/png;base64,{qrCodeBase64}' alt='Código QR' />";
                    inputClave.Value = codigo;

                    // Mostrar el botón de enviar correo electrónico
                    btnEnviarCorreo.Visible = true;
                }
                catch (Exception ex)
                {
                    ShowModal(false, $"Ocurrió un error durante el proceso de entrega: {ex.Message}");
                }
            }
        }


        /*protected void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            try
            {
                var datosEntrega = new DatosDeEntrega();
                int usuarioId = ObtenerUsuario();
                int carritoId = ObtenerCarrito();
                var (email, nombre, apellido) = datosEntrega.ObtenerDatosUsuario(usuarioId);

                if (!CorreoValido(email))
                {
                    ShowModal(false, "El correo proporcionado no es válido.");
                    return;
                }

                if (EnviarCorreoUsuario(email, nombre, apellido, carritoId))
                {
                    ShowModal(true, "Correo enviado exitosamente.");
                }
                else
                {
                    ShowModal(false, "No se pudo enviar el correo.");
                }
            }
            catch (Exception ex)
            {
                ShowModal(false, $"Correo no enviado: {ex.Message}");
            }
        }*/


        protected void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            try
            {
                var datosEntrega = new DatosDeEntrega();
                int usuarioId = ObtenerUsuario();
                int carritoId = ObtenerCarrito();
                var (email, nombre, apellido) = datosEntrega.ObtenerDatosUsuario(usuarioId);

                if (!CorreoValido(email))
                {
                    ShowModal(false, "El correo proporcionado no es válido.");
                    return;
                }

                if (EnviarCorreoUsuario(email, nombre, apellido, carritoId))
                {
                    ShowModal(true, "Correo enviado exitosamente.");
                    Response.Redirect("CorreoEnviadoCorrectamente");
                }
                else
                {
                    ShowModal(false, "No se pudo enviar el correo.");
                }
            }
            catch (Exception ex)
            {
                ShowModal(false, $"Correo no enviado: {ex.Message}");
            }
        }



        private bool EnviarCorreoUsuario(string email, string nombre, string apellido, int carritoId)
        {
            if (codigoGenerador == null)
            {
                throw new InvalidOperationException("El generador de códigos QR no está inicializado.");
            }
            if (inputClave == null || inputClave.Value == null)
            {
                throw new InvalidOperationException("La clave de entrada no está disponible.");
            }

            var datosEntrega = new DatosDeEntrega();
            var (dataCarrito, totalCarrito) = datosEntrega.ObtenerDatosCarrito(carritoId);
            string codigo = inputClave.Value;
            var qrCodeBitmap = codigoGenerador.GenerateQrCodeBitmap($"{dataCarrito}|{totalCarrito}|{codigo}");
            if (qrCodeBitmap == null)
            {
                throw new InvalidOperationException("No se pudo generar el bitmap del código QR.");
            }

            string qrCodeBase64 = ProcesoDeEntrega.ProcesoEntrega.BitmapToBase64(qrCodeBitmap);
            var correo = new Correo();
            if (correo == null)
            {
                throw new InvalidOperationException("El servicio de correo no está inicializado.");
            }

            string body = GenerarCuerpoCorreo(nombre, apellido, qrCodeBase64, codigo);

            return correo.EnviarCorreo(
                "losrandys81@gmail.com", "Desarrollo TICS",
                email, $"Entrega de Producto para {nombre} {apellido}",
                body,
                qrCodeBase64,
                codigo
            );
        }




        private string GenerarCuerpoCorreo(string nombre, string apellido, string qrCodeBase64, string codigo)
        {
            return $@"
    <html>
    <head>
        <style>
            body {{
                font-family: Arial, sans-serif;
                margin: 0;
                padding: 0;
                background-color: #f4f4f9;
            }}
            .container {{
                width: 80%;
                margin: auto;
                padding: 20px;
                background-color: #ffffff;
                border: 1px solid #dddddd;
                border-radius: 10px;
                box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            }}
            .header {{
                background-color: #4CAF50;
                color: white;
                padding: 10px;
                text-align: center;
                border-radius: 10px 10px 0 0;
            }}
            .content {{
                margin: 20px 0;
            }}
            .footer {{
                text-align: center;
                font-size: 0.9em;
                color: #777777;
                margin-top: 20px;
            }}
        </style>
    </head>
    <body>
        <div class='container'>
            <div class='header'>
                <h1>Entrega de Producto</h1>
            </div>
            <div class='content'>
                <p>Estimado/a {nombre} {apellido},</p>
                <p>Nos complace informarle que su pedido está listo para ser entregado. A continuación, encontrará los detalles de su entrega:</p>
                <p><strong>Código de Verificación:</strong> {codigo}</p>
                <p>Por favor, presente este código en el momento de la entrega.</p>
                <p>Además, hemos generado un código QR para su conveniencia:</p>
                <img src='data:image/png;base64,{qrCodeBase64}' alt='Código QR' style='display: block; margin: auto;'>
                <p>Si tiene alguna pregunta o necesita asistencia adicional, no dude en contactarnos.</p>
                <p>Atentamente,<br/>El equipo de Desarrollo TICS</p>
            </div>
            <div class='footer'>
                <p>&copy; {DateTime.Now.Year} Desarrollo TICS. Todos los derechos reservados.</p>
            </div>
        </div>
    </body>
    </html>";
        }




        private int ObtenerUsuario()
        {
            if (Session["USU_ID"] != null)
                return Convert.ToInt32(Session["USU_ID"]);
            else
            {
                ShowModal(false, "No se pudo obtener el id del usuario, por favor, inicie sesión");
                return -1;
            }
        }

        private int ObtenerCarrito()
        {
            if (Session["CARR_ID"] != null)
                return Convert.ToInt32(Session["CARR_ID"]);
            else
            {
                ShowModal(false, "No se pudo obtener el ID del carrito. Por favor, inicie sesión.");
                return -1;
            }
        }

        private bool CorreoValido(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }
        }


        private void ShowModal(bool success, string message)
        {
            /* var script = success ? "showModal(true);" : "showModal(false);";
             ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalScript", script, true);
             lblMensaje.Text = message;*/


            if (success)
            {
                var script = $"showModal(true, '{message}');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalScript", script, true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "AlertScript", $"alert('{message}');", true);
            }

        }
    }
}
