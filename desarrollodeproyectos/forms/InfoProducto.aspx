<%@ Page Title="Detalle del Producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoProducto.aspx.cs" Inherits="desarrollodeproyectos.forms.InfoProducto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMensaje" runat="server" Visible="false" ForeColor="Red"></asp:Label>

    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <div class="container mt-4">
        <h1>Detalles del Producto</h1>
        <div class="row">
            <asp:Repeater ID="InfoProducto1" runat="server">
                <ItemTemplate>
                    <div class="col-md-6 mb-4">
                        <div class="card border-primary mb-3">
                            <div class="row g-0">
                                <div class="col-md-4">
                                    <asp:Image ID="imgProducto" runat="server" ImageUrl='<%# Eval("PROD_URLImga") %>' AlternateText="Producto" CssClass="img-fluid rounded-start" data-toggle="modal" data-target="#myModal" />
                                </div>
                                <div class="col-md-8">
                                    <div class="card-body">
                                        <h5 class="card-title"><%# Eval("PROD_Nombre") %> </h5>
                                        <p class="card-text">Precio: $<%# Eval("PROD_Precio") %></p>
                                        <div class="mb-3">
                                            <label for="cantidadAlimentos" class="form-label">Cantidad:</label>
                                            <input type="number" id="cantidadAlimentos" name="cantidadAlimentos" class="form-control" min="1" value="1" />
                                            <asp:Label ID="lbldescripcion" runat="server" Visible="false" CssClass="d-inline-block mr-2"></asp:Label>
                                        </div>
                                        <asp:HyperLink ID="lnkAgregarCarrito" runat="server" NavigateUrl="Carrito_compras.aspx" CssClass="btn btn-outline-primary" Text="Agregar al Carrito" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div> 
                </ItemTemplate>
            </asp:Repeater>
         
        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <img id="modalImage" class="img-fluid" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
