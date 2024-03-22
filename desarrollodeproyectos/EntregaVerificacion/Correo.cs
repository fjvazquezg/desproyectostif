using System;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace desarrollodeproyectos.EntregasVerificacion
{
    public class Correo
    {
        private readonly SmtpClient _smtpClient;

        public Correo()
        {
            _smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("uadeoisoft@gmail.com", "ixav znpf qvou eywm")
            };
        }

        // metodo para enviar el correo electrónico
        public bool EnviarCorreo(string fromAddress, string fromDisplayName,
            string toAddress, string subject, string body, string tempQrCodePath, string codigo)
        {
            try
            {
                using (var mailMessage = new MailMessage(fromAddress, toAddress, subject, body))
                {
                    mailMessage.IsBodyHtml = true;
                    mailMessage.From = new MailAddress(fromAddress, fromDisplayName);

                    // Adjuntar el código QR
                    mailMessage.Attachments.Add(new Attachment(tempQrCodePath));

                    _smtpClient.Send(mailMessage);
                    // Si el correo se envía con éxito, devuelve true
                    return true;
                }
            }
            catch (SmtpException ex)
            {
                // error al envío de correo electrónico
                Console.WriteLine($"Error al enviar el correo electrónico: {ex.Message}");
                // Si ocurre un error al enviar el correo, devuelve false
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                // Si ocurre un error inesperado, también devuelve false
                return false;
            }
        }
    }
}
