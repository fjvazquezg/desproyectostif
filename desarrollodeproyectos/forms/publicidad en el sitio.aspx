<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="publicidad en el sitio.aspx.cs" Inherits="desarrollodeproyectos.forms.publicidad_en_el_sitio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <title>Carrusel de Imágenes</title>
    <style>

        .banner-container {
            display: flex;
            justify-content: center; /* Centra horizontalmente */
            align-items: center; /* Centra verticalmente */
            height: 100vh; /* O ajusta a la altura deseada */
        }

        .banner {
            /* Estilos del banner */
            width: 468px; /* Ancho del banner */
            height: 60px; /* Alto del banner */
            /* Añade más estilos según sea necesario */
        }

        /* Estilos CSS para el carrusel */
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        .carousel {
            width: 94%; /* Ajusta el ancho del carrusel según tus necesidades */
            overflow: hidden;
            position: relative;
            display: flex;
            top: 0px;
            left: 0px;
        }

        .carousel-inner {
            display: flex;
            transition: transform 0.5s ease;
            align-items: flex-start; /* Alinea las imágenes hacia arriba */
            flex-grow: 1; /* Para que el carrusel ocupe todo el espacio disponible */
        }

        .carousel-item {
            flex: 0 0 100%;
            max-width: 100%;
            display: flex;
            justify-content: center; /* Centra horizontalmente las imágenes */
            align-items: flex-start; /* Alinea las imágenes hacia arriba */
        }

        .carousel-item img {
            max-width: 100%; /* Ajusta el ancho máximo de la imagen al 100% */
            height: 199px; /* Mantiene la proporción de aspecto original */
            width: 469px;
            margin-right: 212px;
        }

        /* Estilos para los controles del carrusel */
        .carousel-controls {
            position: absolute;
            bottom: 1358px;
            left: 60%;
            transform: translateX(-50%);
        }

        .carousel-controls button {
            font-size: 24px;
            background: none;
            border: none;
            cursor: pointer;
        }

        /* Estilos para imágenes verticales */
        .vertical-images {
            display: flex;
            flex-direction: column;
            justify-content: space-between; /* Espacio entre las imágenes */
            padding: 0 10px; /* Espaciado izquierda y derecha */
            transition: transform 0.5s ease; /* Agregamos transición para el efecto de carrusel */
            margin-top: 100px; /* Margen superior para centrar verticalmente */
        }

        .vertical-images img {
            height: 343px; /* Altura máxima de las imágenes verticales */
            width: 184px;
            margin-bottom: 10px;

        }
    </style>
</head>

<body>



    <div class="carousel">
        <div class="vertical-images sushi-images">
            <img src="../Img/ProdImg/hamburguesa.jpg" alt="Hamburguesa" />
            <img src="../Img/ProdImg/pollo.jpg" alt="Pollo" />
        </div>
        <div class="carousel-inner">
            <div class="carousel-item">
                <img src="../Img/ProdImg/baguette.jpg" alt="Baguette" />
            </div>
            <div class="carousel-item">
                <img src="../Img/ProdImg/burritos.jpg" alt="Burritos" />
            </div>
            <div class="carousel-item">
                <img src="../Img/ProdImg/sandwich.jpg" alt="Sandwich" />
            </div>
            <!-- Agrega más elementos div.carousel-item para más imágenes -->
        </div>
        <div class="vertical-images sushi-images">
            <img src="../Img/ProdImg/sushi..jpg" alt="Sushi" />
            <img src="../Img/ProdImg/torta.jpg" /alt="Torta" />
        </div>
        <div class="carousel-controls">
            <button onclick="prevSlide()">❮</button>
            <button onclick="nextSlide()">❯</button>
        </div>
    </div>

    <script>
        const carouselInner = document.querySelector('.carousel-inner');
        const totalItems = document.querySelectorAll('.carousel-item').length;
        let currentIndex = 0;
        let timerHorizontal;

        function showSlide(index) {
            if (index < 0) {
                index = totalItems - 1;
            } else if (index >= totalItems) {
                index = 0;
            }
            const offset = -index * 100;
            carouselInner.style.transform = `translateX(${offset}%)`;
            currentIndex = index;
        }

        function nextSlide() {
            showSlide(currentIndex + 1);
        }

        function prevSlide() {
            showSlide(currentIndex - 1);
        }

        function startCarousel() {
            timerHorizontal = setInterval(nextSlide, 3000); // Cambia 3000 por el tiempo en milisegundos que desees para cambiar de imagen automáticamente
        }

        function stopCarousel() {
            clearInterval(timerHorizontal);
        }

        // Event listeners para controles de navegación
        document.addEventListener('DOMContentLoaded', function () {
            startCarousel(); // Inicia el carrusel automáticamente al cargar la página
            document.querySelector('.carousel').addEventListener('mouseenter', stopCarousel);
            document.querySelector('.carousel').addEventListener('mouseleave', startCarousel);
        });
    </script>

</body>

</html>
