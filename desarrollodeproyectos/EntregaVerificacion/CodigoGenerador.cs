using QRCoder;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Drawing;

namespace desarrollodeproyectos.EntregasVerificacion
{
    public class CodigoGenerador
    {
        private const int CodeLength = 6;

        // metodo para generar un código aleatorio
        private string GenerateRandomCode(int length)
        {
            const string chars = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // metodo para generar un código QR como Bitmap
        public Bitmap GenerateQrCodeBitmap(string data)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);

            return qrCodeImage;
        }

        // metodo generar el código y el QR
        public (Bitmap QrCodeBitmap, string Code) GenerateCodeAndQr(string data, decimal total)
        {
            string code = GenerateRandomCode(CodeLength);
            string qrData = $"{data}|{total}|{code}";
            Bitmap qrCodeBitmap = GenerateQrCodeBitmap(qrData);

            return (qrCodeBitmap, code);
        }
    }
}
