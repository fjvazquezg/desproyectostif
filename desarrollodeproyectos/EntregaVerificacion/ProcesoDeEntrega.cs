using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;

namespace desarrollodeproyectos.EntregasVerificacion
{
    public class ProcesoDeEntrega
    {
        public class ProcesoEntrega
        {
            public void IniciarProcesoEntrega(int usuarioId, int carritoId)
            {
                try
                {
                    // obtener datos del usuario y del carrito
                    var datosDeEntrega = new DatosDeEntrega();
                    var (email, nombre, apellido) = datosDeEntrega.ObtenerDatosUsuario(usuarioId);
                    var (dataCarrito, totalCarrito) = datosDeEntrega.ObtenerDatosCarrito(carritoId);

                    var codigoGenerador = new CodigoGenerador();
                    var (qrCodeBitmap, codigo) = codigoGenerador.GenerateCodeAndQr(dataCarrito, totalCarrito);

                    // convertir el Bitmap a una cadena Base64
                    string qrCodeBase64 = BitmapToBase64(qrCodeBitmap);

                    // enviar correo electrónico
                    var correo = new Correo();
                    correo.EnviarCorreo(
                        "uadeoisoft@gmail.com", "Ingenieria de software",
                        email, $"Entrega de Producto para {nombre} {apellido}",
                        $"Aquí están los detalles de tu entrega:<br/><img src='data:image/png;base64,{qrCodeBase64}'><br/>Y tu clave de verificación: {codigo}",
                        qrCodeBase64, codigo
                    );

                    Console.WriteLine("El proceso de entrega se completó con éxito.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocurrió un error durante el proceso de entrega: {ex.Message}");
                }
            }

            // metodo para convertir un Bitmap a una cadena Base64
            public static string BitmapToBase64(Bitmap bitmap)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = memory.ToArray();
                    return Convert.ToBase64String(byteImage);
                }
            }
        }
    }
}
