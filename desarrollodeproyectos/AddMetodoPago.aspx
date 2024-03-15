<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMetodoPago.aspx.cs" Inherits="desarrollodeproyectos.AgregarTarjeta" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Agregar Metodo de Pago</title>
    <link rel="stylesheet" href="/css/bootstrap.css" />
</head>
<body>
    <form id="formAddMetodoPago" runat="server">
        <div class="container-lg">
            <h3 class="text-center">Agregar Metodo de Pago</h3>
            <hr />
            <div class="mb-3">
                <label for="txtMetodoPagoName" class="form-label">Nombre</label>
                <input type="text" class="form-control" id="txtMetodoPagoName" runat="server" />
            </div>
            <div class="d-flex justify-content-center">
                <asp:Button ID="btnGuardarMetodoPago" runat="server" Text="Guardar Metodo" OnClick="GuardarMetodoPago_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </form>
</body>
</html>
