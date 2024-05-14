<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionCatProd.aspx.cs" Inherits="desarrollodeproyectos.forms.SeleccionCatProd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="../Scripts/css/bootstrap.css" rel="stylesheet" />
<link href="../Scripts/css/bootstrap.min.css" rel="stylesheet" />
<link href="../Scripts/css/bootstrap.rtl.css" rel="stylesheet" />
<link href="../Scripts/css/bootstrap.rtl.min.css" rel="stylesheet" />
<link href="../Scripts/css/BottonCustom.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5 card shadow" style="padding: 3%; margin-top: 3%;" >
            <div class="row justify-content-between">
                <div class="container" style="margin-bottom: 20px;">
                    <div class="row justify-content-center"> <!-- Columna para el logo, alineado a la izquierda -->
                        <h3 style="text-align: center; margin-bottom: 1%;">Panel de administración de productos</h3>
                        <img src="../Img/Iconos/LogoTienda.png" alt="Logo" class="img-fluid" style="max-width: 100%; width: 170px; height: 170px;" /> <!-- Ajusta la ruta del logo y el tamaño según lo necesites -->
                    </div>
                </div>
                <div class="container">
                    <div class="row justify-content-center">
                        <div class="col-md-5 text-right"> <!-- Alinea los botones a la derecha -->
                            <asp:Button ID="Button4" runat="server" Text="Agregar Tipos de Productos" CssClass="btn btn-primary btn-custom" OnClick="Button4_Click"/>
                        </div>
                    </div>
                    <div class="row justify-content-center">
                        <div class="col-md-5 text-right"> <!-- Alinea los botones a la derecha -->
                            <asp:Button ID="Button1" runat="server" Text="Agregar Productos" CssClass="btn btn-success btn-custom" OnClick="Button1_Click"/>
                        </div>
                    </div>
                    <div class="row justify-content-center">
                        <div class="col-md-5 text-right"> <!-- Alinea los botones a la derecha -->
                            <asp:Button ID="Button2" runat="server" Text="Modificar Productos" CssClass="btn btn-danger btn-custom" OnClick="Button2_Click"/>
                        </div>
                    </div>
                </div>
             </div>
        </div>
    </form>
</body>
</html>
