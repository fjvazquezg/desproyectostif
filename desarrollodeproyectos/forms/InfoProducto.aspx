<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoProducto.aspx.cs" Inherits="desarrollodeproyectos.forms.InfoProducto" %>

<!DOCTYPE html>

<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="../Scripts/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .product-container {
            display: flex;
            max-width: 800px;
            margin: auto;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 5px;
            margin-top: 20px;
        }

        .product-images {
            flex: 1;
            display: flex;
            flex-direction: column;
            align-items: flex-start;
        }

        .product-images img {
            max-width: 80px;
            height: auto;
            border-radius: 5px;
            margin-bottom: 10px;
            cursor: pointer;
        }

        .product-info {
            flex: 1;
            padding-left: 20px;
        }

        .product-info h1 {
            font-size: 1.5rem;
        }

        .product-info p {
            margin: 10px 0;
        }

        .btn-container {
            display: flex;
            justify-content: flex-end;
        }

        .btn-comprar {
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="product-container">
            <div class="product-images" id="image-container">
                <img id="mainImage" runat="server" alt="Imagen principal" />
            </div>

            <div class="product-info">
                <h1 runat="server" id="lblNombre"></h1>
                <p runat="server" id="lblDescripcion" class="description"></p>
                <p runat="server" id="lblPrecio" class="price"></p>
                <p runat="server" id="lblStock" class="stock"></p>

                <div class="btn-container">
                    <button class="btn btn-outline-primary btn-comprar" onclick="agregarAlCarrito()">Agregar al Carrito</button>
                    <button class="btn btn-outline-primary btn-comprar">Comprar</button>
                </div>
            </div>
        </div>
    </form>

    <script src="../Scripts/js/bootstrap.bundle.min.js"></script>
    <script>
        function agregarAlCarrito() {
            alert('¡Producto agregado al carrito!');
            // Puedes agregar la lógica para gestionar el carrito de compras aquí
        }
    </script>
</body>
</html>
