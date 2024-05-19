<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarProductos.aspx.cs" Inherits="desarrollodeproyectos.forms.SeleccionarProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="../Scripts/css/bootstrap.css" rel="stylesheet" />
<link href="../Scripts/css/bootstrap.min.css" rel="stylesheet" />
<link href="../Scripts/css/bootstrap.rtl.css" rel="stylesheet" />
<link href="../Scripts/css/bootstrap.rtl.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1 class="mb-4">Lista de Productos</h1>
            <div class="row">
                <div class="col-12">
                    <asp:GridView ID="gvProductos" runat="server" CssClass="table table-striped table-bordered table-responsive" AutoGenerateColumns="false" AutoGenerateSelectButton="true" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="PROD_Id" HeaderText="ID" />
                            <asp:BoundField DataField="PROD_Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="PROD_Precio" HeaderText="Precio" />
                            <asp:BoundField DataField="PROD_StockMin" HeaderText="Stock minimo" />
                            <asp:BoundField DataField="PROD_StockMax" HeaderText="Stock maximo" />
                            <asp:BoundField DataField="PROD_TipoComida" HeaderText="Tipo de comida" />
                            <asp:BoundField DataField="PROD_Descripcion" HeaderText="Descripción" />
                            <asp:BoundField DataField="PROD_URLImga" HeaderText="URL Logo" Visible="false" />
                            <asp:BoundField DataField="PROD_URLImgb" HeaderText="URL Promoción 1" Visible="false" />
                            <asp:BoundField DataField="PROD_URLImgc" HeaderText="URL Promoción 2" Visible="false" />
                            <asp:BoundField DataField="PROD_Status" HeaderText="Estado del producto" />
                            <asp:BoundField DataField="PROD_IdUsuario" HeaderText="ID Usuario" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
