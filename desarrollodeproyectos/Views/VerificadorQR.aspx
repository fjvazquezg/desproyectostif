<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerificadorQR.aspx.cs" Inherits="desarrollodeproyectos.Views.VerificadorQR" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8"> <!-- Codificación de caracteres UTF-8 -->

  <script src="../packages/plugins/qrCode.min.js"></script> <!-- Enlace al archivo JavaScript del plugin QR Code -->
  <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script> <!-- Enlace al archivo JavaScript de la biblioteca SweetAlert2 -->
  <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>


  <meta name="viewport" content="width=device-width, initial-scale=1.0"> <!-- Configuración de la vista adaptable -->
  <title>Verificador de Pedido</title> <!-- Título de la página -->
  <link rel="stylesheet" href="../Scripts/css/bootstrap.min.css"> <!-- Enlace al archivo CSS de Bootstrap -->

</head>
<body>  
    <div class=".container-fluid"> <!-- Contenedor fluido -->
        <nav class="navbar navbar-expand-lg bg-primary" data-bs-theme="dark"> <!-- Barra de navegación con estilo Bootstrap -->
            <div class="d-flex justify-content-between align-items-center"> <!-- Contenedor con alineación y distribución flexibles -->
                <a href="#"> <!-- Enlace de retorno -->
                    <svg xmlns="http://www.w3.org/2000/svg" class="icon icon-tabler icon-tabler-arrow-left" width="40" height="40" viewBox="0 0 24 24" stroke-width="1.5" stroke="#2c3e50" fill="none" stroke-linecap="round" stroke-linejoin="round"> <!-- Icono de flecha izquierda -->
                        <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
                        <path d="M5 12l14 0" />
                        <path d="M5 12l6 6" />
                        <path d="M5 12l6 -6" />
                    </svg>
                </a>
            <h1 class="navbar-brand">Verificación de Pedido</h1> <!-- Título de la barra de navegación -->
        </div>
    </nav>
    <div class="row justify-content-center mt-5"> <!-- Contenedor de fila centrada -->
      <div class="col-sm-4 shadow p-3"> <!-- Columna con sombra y relleno -->
        <h5 class="text-center">Escanear codigo QR</h5> <!-- Título centrado -->
        <div class="row text-center"> <!-- Contenedor de fila centrada -->
          <a id="btn-scan-qr" href="#"> <!-- Enlace para escanear el código QR -->
            <img src="https://dab1nmslvvntp.cloudfront.net/wp-content/uploads/2017/07/1499401426qr_icon.svg" class="img-fluid text-center" width="175"> <!-- Imagen del icono del código QR -->
          <a/>
          <canvas hidden="" id="qr-canvas" class="img-fluid"></canvas> <!-- Canvas oculto para el código QR -->
        </div>

  <div class="row mx-5 my-3"> <!-- Contenedor de fila con márgenes -->
  </div>

  <br> <!-- Salto de línea -->

      <div style="text-align: center;"> <!-- Estilo de alineación centrado -->
      <button class="btn btn-danger btn-sm rounded-3" onclick="encenderCamara()">Escanear QR</button>
      <h1></h1>
      <button class="btn btn-danger btn-sm rounded-3" onclick="cerrarCamara()">Detener deteccion por Qr</button> <!-- Botón para detener la cámara -->

  </div>
<hr>
  <div style="text-align: center;"> <!-- Estilo de alineación centrado -->
    <h3 for="verification_number">Número de Verificación:</h3> <!-- Etiqueta de título del campo de verificación -->
</div>
<div style="text-align: center;"> <!-- Estilo de alineación centrado -->
    <input type="text" id="verification_number" name="verification_number" placeholder="Ingrese el número de verificación"> <!-- Campo de entrada para el número de verificación -->
</div>
<br> <!-- Salto de línea -->
<div style="text-align: center;"> <!-- Estilo de alineación centrado -->
    <button id="BtnVerificar" type="submit" class="btn btn-success">Verificar Pedido</button> <!-- Botón para enviar el formulario de verificación -->
</div>
  


</div>


      </div>
    </div>

    <script src="../Scripts/CamaraQR_JE.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

  <!-- <audio id="audioScaner" src="../packages/plugins/sonido.mp3"></audio> <!-- Elemento de audio para el sonido de escaneo -->
     <!-- Enlace al archivo JavaScript de la función de la cámara QR -->
</body>
</html>


