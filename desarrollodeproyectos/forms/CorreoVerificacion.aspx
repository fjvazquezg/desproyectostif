<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorreoVerificacion.aspx.cs"
    Inherits="desarrollodeproyectos.forms.CorreoVerificacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Scripts/css/bootstrap.css" rel="stylesheet" />
    <link href="../Scripts/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Scripts/css/bootstrap.rtl.css" rel="stylesheet" />
    <link href="../Scripts/css/bootstrap.rtl.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../forms/CorreoVerificacion.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
    <title></title>
</head>

<body>
    <nav class="navbar navbar-expand-lg bg-primary" data-bs-theme="dark">
        <div class="d-flex justify-content-between align-items-center">
            <a href="#">
                <svg xmlns="http://www.w3.org/2000/svg" class="icon icon-tabler icon-tabler-arrow-left" width="40"
                    height="40" viewBox="0 0 24 24" stroke-width="1.5" stroke="#2c3e50" fill="none"
                    stroke-linecap="round" stroke-linejoin="round">
                    <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                    <path d="M5 12l14 0" />
                    <path d="M5 12l6 6" />
                    <path d="M5 12l6 -6" />
                </svg>
            </a>
            <h1 class="navbar-brand">ENTREGA DE PRODUCTO</h1>
        </div>
    </nav>

    <form runat="server">
        <div class="container">
           
            <h2>ENVIAR CODIGO DE VERIFICACION</h2>
            <p>Enviaremos un código al correo del usuario</p>
            <div class="qr-section">
                <Button Class="btn btn-primary" disabled runat="server" OnClick="btnGenerarCodigoQR_Click"/>
                <div id="qrCodeDisplay" runat="server" style="width: 200px; height: 200px;" class="mb-3 qr-code-box">
                    <!-- Aquí se mostrara el código QR -->
                </div>
            </div>
            <div class="sms-section">
                <Button Class="btn btn-secondary" disabled runat="server" OnClick="btnGenerarCodigos_Click"/>
                <div class="input-group mb-3">
                    <input type="text" class="form-control" maxlength="5" disabled runat="server" id="inputClave" />
                </div>
            </div>
            <asp:Button ID="btnEnviarCorreo" Class="btn btn-outline-primary" runat="server" Text="Enviar Correo"
                OnClick="btnEnviarCorreo_Click" />
            <asp:Label ID="lblMensaje" runat="server" Class="mt-3"></asp:Label>
        </div>
    </form>

    <!-- Modal -->
    <div class="modal fade" id="successModal" tabindex="-1" aria-labelledby="successModalLabel" aria-hidden="true">
     <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="successModalLabel">¡Éxito!</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <i class="fas fa-dove text-success"></i> Se ha enviado las claves al usuario.
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
          </div>
        </div>
     </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script>
        function showModal(success) {
            var modalTitle = success ? "¡Éxito!" : "Error";
            var modalBody = success ? "Se ha enviado las claves al usuario." : "Hubo un error al enviar el correo.";
            var modal = new bootstrap.Modal(document.getElementById('successModal'), {});
            document.getElementById('successModalLabel').innerText = modalTitle;
      
            document.querySelector('#successModal .modal-body').innerText = modalBody;
            modal.show();
        }
    </script>

</body>

</html>
