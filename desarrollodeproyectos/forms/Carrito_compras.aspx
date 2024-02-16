<%@ Page Title="Carrito de Compras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito_Compras.aspx.cs" Inherits="desarrollodeproyectos.Carrito" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h1 class="mb-4">Carrito de Compras</h1>
        <!-- Bootstrap CSS -->
        <link rel="stylesheet" href="~/Scripts/css/bootstrap.min.css" />

        <div class="row">
            <div class="col-md-8">
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col" class="fw-bold">Producto</th>
                            <th scope="col" class="fw-bold">Precio</th>
                            <th scope="col" class="fw-bold">Cantidad</th>
                            <th scope="col" class="fw-bold">Total</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Producto 1</td>
                            <td>$10.00</td>
                            <td>2</td>
                            <td>$20.00</td>
                        </tr>
                        <tr>
                            <td>Producto 2</td>
                            <td>$15.00</td>
                            <td>1</td>
                            <td>$15.00</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="col-md-4">
                <div class="text-md-end">
                    <p class="fw-bold">Total a pagar: $35.00</p>
                    <asp:LinkButton ID="btnPagar" CssClass="btn btn-success" runat="server" Text="Pagar"></asp:LinkButton>
                </div>
            </div>
        </div>

        <div class="row mt-3">
            <div class="col-md-6">
                <asp:LinkButton ID="btnSeguirComprando" CssClass="btn btn-primary" runat="server" Text="Seguir Comprando"></asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
