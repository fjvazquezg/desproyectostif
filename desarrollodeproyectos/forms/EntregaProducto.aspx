<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntregaProducto.aspx.cs"
    Inherits="desarrollodeproyectos.About" %>

    <!DOCTYPE html>
    <html lang="en">

    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Inicio sin contraseña</title>
        <link rel="stylesheet" href="bootstrap.min.css">
        <!-- Bootstrap CSS -->
        <link rel="stylesheet" href="/desarrollodeproyectos/Scripts/css/bootstrap.min.css" />
        <link rel="stylesheet" href="/desarrollodeproyectos/forms/EntregaDeProducto.css">
    </head>

    <body>

        <nav class="navbar navbar-expand-lg bg-primary" data-bs-theme="dark">
            <div class="d-flex justify-content-between align-items-center">

                <a href="#">
                    <svg xmlns="http://www.w3.org/2000/svg" class="icon icon-tabler icon-tabler-arrow-left" width="40"
                        height="40" viewBox="0 0 24 24" stroke-width="1.5" stroke="#2c3e50" fill="none"
                        stroke-linecap="round" stroke-linejoin="round">
                        <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                        <path d="M5 12l14 0" />
                        <path d="M5 12l6 6" />
                        <path d="M5 12l6 -6" />
                    </svg>
                </a>
                <h1 class="navbar-brand">ENTREGA DE PRODUCTO</h1>
            </div>
              
        </nav>
        <div class="container">
            <div class="left-section">
                <!-- Sección izquierda -->
                <h1>ENTREGA DE PRODUCTO</h1>
                <p class="lead" value="NOMBRE">Yamir Castro Quiroz</p>
                <p class="lead" value="CONTACTO">687-165-21-03</p>
            </div>
            <div class="right-section">
                <!-- Sección derecha -->
                <h2>ENVIAR CODIGO DE VERIFICACION</h2>
                <p>Enviaremos un código al correo del usuario</p>
                <div class="qr-section">
                    <button class="btn btn-primary">Código QR</button>
                    <div id="qr-code-display" class="mb-3 qr-code-box">
                        <!-- Aquí se mostrará el código QR -->
                    </div>
                </div>
                <div class="sms-section">
                    <button class="btn btn-secondary">CLAVE</button>
                    <div class="input-group mb-3">
                        <input type="text" class="form-control" maxlength="5">
                    </div>
                </div>
                <button class="btn btn-success">Enviar y Confirmar</button>
            </div>
        </div>
    </body>

    </html>