<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PoliticasWebsite.aspx.cs" Inherits="desarrollodeproyectos.forms.PoliticasWebsite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Políticas del sitio - Comida en línea</title>
    <link href="https://stackpath.bootstrapcdn.com/bootswatch/4.5.2/journal/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Nombre de la Empresa</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor02"
                    aria-controls="navbarColor02" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarColor02">
                    <ul class="navbar-nav me-auto">
                        <li class="nav-item">
                            <a class="nav-link" href="#">Inicio</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <div class="container">
            <h1 class="text-center mt-5">Políticas del sitio</h1>
            <p class="lead text-center mb-5">Bienvenido a nuestro sitio de compra y venta de comida en línea</p>
            <div class="row">
                <div class="col-md-4">
                    <h3>Políticas de envío</h3>
                    <p id="shipping">
                        Ofrecemos envío gratuito para pedidos superiores a $50 dentro de un radio de 20 millas desde nuestro centro de distribución principal.
                        Los tiempos de entrega estándar son de 2 a 3 días hábiles, pero pueden variar según la ubicación y la disponibilidad del producto.
                        En caso de retrasos inesperados, nos comprometemos a comunicarnos con nuestros clientes y proporcionar actualizaciones oportunas sobre el estado de su pedido.
                        Información sobre tarifas de envío y posibles promociones de envío gratuito.
                    </p>
                </div>
                <div class="col-md-4">
                    <h3>Políticas de devolución</h3>
                    <p id="return">
                        Aceptamos devoluciones dentro de los 7 días posteriores a la entrega del pedido en caso de productos dañados, incorrectos o insatisfactorios.
                        Los clientes deben notificar cualquier problema con su pedido y proporcionar evidencia fotográfica, si es necesario, para iniciar el proceso de devolución.
                        Se emitirá un reembolso completo o se ofrecerá un crédito en la cuenta del cliente una vez que se complete el proceso de devolución.
                    </p>
                </div>
                <div class="col-md-4">
                    <h3>Políticas de pago</h3>
                    <p id="payment">
                        Aceptamos pagos con tarjeta de crédito, PayPal y transferencia bancaria para brindar opciones flexibles a nuestros clientes.
                        Todos los pagos se procesan de forma segura a través de nuestra pasarela de pago certificada y se encriptan para proteger la información del cliente.
                        Los clientes recibirán una confirmación de pedido por correo electrónico una vez que se haya completado con éxito su transacción.
                    </p>
                </div>
            </div>
            <div class="row mt-5">
                <div class="col-md-12">
                    <h2 class="text-center">Políticas adicionales</h2>
                    <ul>
                        <li><strong>Política de privacidad:</strong> Nos comprometemos a proteger la privacidad de nuestros usuarios. Toda la información personal recopilada se utiliza de acuerdo con nuestra política de privacidad.</li>
                        <li><strong>Política de seguridad:</strong> Implementamos medidas de seguridad para proteger la información de nuestros usuarios y garantizar transacciones seguras en nuestro sitio web.</li>
                        <li><strong>Política de calidad:</strong> Nos esforzamos por ofrecer productos de la más alta calidad y garantizar la satisfacción del cliente en cada pedido.</li>
                    </ul>
                </div>
            </div>
            <footer class="mt-5">
                <p class="text-center">© 2023 Comida en línea. Todos los derechos reservados.</p>
            </footer>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.bundle.min.js"></script>
</body>
</html>
