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
                Credentials = new NetworkCredential("losrandys81@gmail.com", "ovhbdylfdlugpifv")
            };
        }

        // Método para enviar el correo electrónico

        public bool EnviarCorreo(string fromAddress, string fromDisplayName, string toAddress, string subject, string body, string qrCodeBase64, string codigo)
        {
            try
            {
                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(fromAddress, fromDisplayName);
                    mailMessage.To.Add(toAddress);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;

                    if (!string.IsNullOrEmpty(qrCodeBase64))
                    {
                        var qrCodeBytes = Convert.FromBase64String(qrCodeBase64);
                        var qrCodeStream = new MemoryStream(qrCodeBytes);
                        mailMessage.Attachments.Add(new Attachment(qrCodeStream, "qrcode.png"));
                    }

                    _smtpClient.Send(mailMessage);
                    return true;
                }
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"Error al enviar el correo electrónico: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return false;
            }
        }

    }
}
