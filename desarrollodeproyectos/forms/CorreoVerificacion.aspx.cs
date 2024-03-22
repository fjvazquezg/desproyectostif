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
            if (!IsPostBack)
            {
                
                codigoGenerador = new CodigoGenerador();

                // simulación del inicio de sesión
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
                    lblMensaje.Text = $"Ocurrió un error durante el proceso de entrega: {ex.Message}";
                }
            }
        }

        protected void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            try
            {
                // Asegurarse de que codigoGenerador esté instanciado
                if (codigoGenerador == null)
                {
                    codigoGenerador = new CodigoGenerador();
                }

                // Obtener datos del usuario y del carrito
                DatosDeEntrega datosEntrega = new DatosDeEntrega();
                int usuarioId = ObtenerUsuario();
                int carritoId = ObtenerCarrito();

                var (email, nombre, apellido) = datosEntrega.ObtenerDatosUsuario(usuarioId);
                var (dataCarrito, totalCarrito) = datosEntrega.ObtenerDatosCarrito(carritoId);

                if (!CorreoValido(email))
                {
                    // mostrar el modal de error cuando el correo no es válido
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorModal", "showModal(false);", true);
                    return; // validamos el correo 
                }

                string codigo = inputClave.Value;

                // generar el código QR como Bitmap
                Bitmap qrCodeBitmap = codigoGenerador.GenerateQrCodeBitmap($"{dataCarrito}|{totalCarrito}|{codigo}");

                // convertir el Bitmap a una cadena Base64
                string qrCodeBase64 = ProcesoDeEntrega.ProcesoEntrega.BitmapToBase64(qrCodeBitmap);

                // enviar correo electrónico
                var correo = new Correo();
                bool correoEnviado = correo.EnviarCorreo(
                    "uadeoisoftt@gmail.com", "Desarrollo TICS",
                    email, $"Entrega de Producto para {nombre} {apellido}",
                    $"Aquí están los detalles de tu entrega:<br/><img src='data:image/png;base64,{qrCodeBase64}'><br/>Y tu clave de verificación: {codigo}",
                    qrCodeBase64, codigo
                );

                if (correoEnviado)
                {
                    // mostrar el modal de éxito cuando el correo se envía con éxito
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessModal", "showModal(true);", true);
                }
                else
                {
                    lblMensaje.Text = "Ocurrió un error durante el proceso de envío del correo electrónico.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Correo no enviado: {ex.Message}";
            }
        }

        private int ObtenerUsuario()
        {
            // verificar si el ID del usuario está almacenado en la sesion
            if (Session["USU_ID"] != null)
            {
                return Convert.ToInt32(Session["USU_ID"]);
            }
            else
            {
                // manejar el caso en que el ID del usuario no esté en la sesion
                lblMensaje.Text = "No se pudo obtener el id del usuario, por favor, inicie sesion";
                return -1; // retorna un valor inválido para indicar que no se pudo obtener el Id
            }
        }

        private int ObtenerCarrito()
        {
            if (Session["CARR_ID"] != null)
            {
                return Convert.ToInt32(Session["CARR_ID"]);
            }
            else
            {
                lblMensaje.Text = "No se pudo obtener el ID del carrito. Por favor, inicie sesión.";
                return -1;
            }
        }

        private bool CorreoValido(string correo) // validacion de correo
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
    }
}
