<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MetodosDeComprobacion.aspx.cs" Inherits="desarrollodeproyectos.forms.MetodosDeComprobacion" %>

<!DOCTYPE html>

      <!-- Comentario-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Verificación de documentos</title>
    <link href="../Scripts/css/bootstrap.min.css" rel="stylesheet" />
      <style>
        .form-group {
            margin-bottom: 20px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <h2 class="mb-4 text-center">VERIFICACIÓN DE DOCUMENTOS</h2>
                   
                    <div class="form-group">
                        <label for="nombreCompleto">Nombre Completo:</label>
                        <asp:TextBox ID="nombreCompleto" runat="server" CssClass="form-control" required ></asp:TextBox>
                    </div>
                
                            <div class="form-group">
                        <label for="fuINE">Seleccionar imagen de tu identificación oficial (INE):</label>
                        <asp:FileUpload ID="fuINE" runat="server" CssClass="form-control" />
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="btnEnviar_Click" />
                        </div>
                     <div class="text-center mt-3">
                    <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>