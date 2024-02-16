<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contacto-Venta.aspx.cs" Inherits="desarrollodeproyectos.forms.Contacto_Venta" %>

<!DOCTYPE html>

<html lang="es" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Contacto para Venta</title>
    <link href="../Scripts/css/bootstrap.css" rel="stylesheet" />
    <link href="../Scripts/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid h-100 d-flex justify-content-center">
            <div class="container">
                <h1 class="display-4 mb-4 fw-bold text-center" style="margin: 0 auto;">Elige cómo quieres contactarnos</h1>
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Button ID="btnChat" runat="server" Text="Chat privado" CssClass="btn btn-dark w-100" OnClick="btnChat_Click" />
                    </div>
                    <div class="col-md-6">
                        <asp:Button ID="btnWhatsApp" runat="server" Text="WhatsApp" CssClass="btn btn-success w-100" OnClick="btnWhatsApp_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>