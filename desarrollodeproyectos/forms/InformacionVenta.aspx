<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InformacionVenta.aspx.cs" Inherits="desarrollodeproyectos.forms.InformacionVenta" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <div class="container mt-4">
        <h1>Bienvenido a Tu Tienda en Línea</h1>
        <div class="row">
            <asp:Repeater ID="rptProductos" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <div class="card border-primary mb-3">
                            <img src='<%# Eval("Ruta Imagen") %>' class="card-img-top" alt='<%# Eval("Nombre") %>' />
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                                <p class="card-text">Precio: $<%# Eval("Precio") %></p>
                                <p class="card-text">Stock: <%# Eval("Stock") %></p>
                                <asp:HyperLink ID="hlDetalles" runat="server" NavigateUrl='<%# "detallesProducto.aspx?id=" + Eval("ID Producto") %>' Text="Ver detalles" CssClass="btn btn-outline-primary"></asp:HyperLink>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
