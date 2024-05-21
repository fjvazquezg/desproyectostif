<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoProducto.aspx.cs" Inherits="desarrollodeproyectos.forms.InfoProducto" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Detalle del Producto</title>
    <link href="../Scripts/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Scripts/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        .product-card {
            border: 1px solid #ddd;
            border-radius: 5px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            margin-bottom: 20px;
        }
        .product-image {
            max-width: 100%; /* Ajusta el tamaño según sea necesario */
            height: auto;
        }
        .product-info {
            padding: 15px;
        }
        .product-title {
            font-size: 1.5rem;
            font-weight: bold;
            margin-bottom: 10px;
        }
        .product-price {
            font-size: 1.25rem;
            color: #0a0a0a;
            margin-bottom: 10px;
        }
        .product-description {
            font-size: 1rem;
            margin-bottom: 10px;
        }
        .product-quantity {
            width: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblMensaje" runat="server" Visible="false" ForeColor="Red"></asp:Label>
            <div class="container mt-4">
                <h1>Detalles del Producto</h1>
                <div class="row">
                    <div class="col-md-6 mb-4">
                        <div class="card product-card">
                            <div class="row g-0">
                                <div class="col-md-4">
                                    <asp:Image ID="imgProducto" runat="server" ImageUrl="" AlternateText="Producto" CssClass="img-fluid rounded-start product-image" Visible="false" />
                                </div>
                                <div class="col-md-8">
                                    <div class="product-info">
                                        <h5 class="product-title">
                                            <asp:Label ID="lblNombreProducto" runat="server"></asp:Label>
                                        </h5>
                                        <p class="product-price">Precio: 
                                            <asp:Label ID="lblPrecio" runat="server"></asp:Label>
                                        </p>
                                        <p class="product-description">
                                            <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                                        </p>
                                        <div class="mb-3">
                                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control product-quantity" placeholder="Cantidad"></asp:TextBox>
                                            <asp:LinkButton ID="add" runat="server" Text="Agregar al Carrito" OnClick="add_Click" CssClass="btn btn-primary mt-2"></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </form>
</body>
</html>

