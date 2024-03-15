<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InformacionVenta.aspx.cs" Inherits="desarrollodeproyectos.forms.InformacionVenta" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMensaje" runat="server" Visible="false" ForeColor="Red"></asp:Label>

    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <div class="container mt-4">
        <h1>Bienvenido a Tu Tienda en Línea</h1>
        <div class="row">
            <asp:Repeater ID="rptProductos" runat="server" OnItemDataBound="rptProductos_ItemDataBound">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <div class="card border-primary mb-3">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("PROD_Nombre") %></h5>
                                 <asp:Image ID="imgProducto" runat="server" ImageUrl='<%# Eval("PROD_URLImga") %>' AlternateText="Producto" CssClass="img-fluid" />
                                <p class="card-text">Precio: $<%# Eval("PROD_Precio") %></p>                             
                                <asp:HyperLink ID="hlDetalles" runat="server" NavigateUrl='<%# "InfoProducto.aspx?id=" + Eval("PROD_Id") + "&timestamp=" + DateTime.Now.Ticks.ToString() %>' 
                                    Text="Ver detalles" CssClass="btn btn-outline-primary"></asp:HyperLink>

                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
