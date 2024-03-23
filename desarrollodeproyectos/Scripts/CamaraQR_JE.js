// Crea elemento
const video = document.createElement("video");

// Nuestro canvas
const canvasElement = document.getElementById("qr-canvas");
const canvas = canvasElement.getContext("2d");

// Div donde llegará nuestro canvas
const btnScanQR = document.getElementById("btn-scan-qr");

// Lectura desactivada
let scanning = false;

// Función para encender la cámara
const encenderCamara = () => {
    navigator.mediaDevices
        .getUserMedia({ video: { facingMode: "environment" } })
        .then(function (stream) {
            scanning = true;
            btnScanQR.hidden = true;
            canvasElement.hidden = false;
            video.setAttribute("playsinline", true); // required to tell iOS safari we don't want fullscreen
            video.srcObject = stream;
            video.play();
            tick();
            scan();
        });
};

// Funciones para levantar las funciones de encendido de la cámara
function tick() {
    canvasElement.height = video.videoHeight;
    canvasElement.width = video.videoWidth;
    canvas.drawImage(video, 0, 0, canvasElement.width, canvasElement.height);

    scanning && requestAnimationFrame(tick);
}

function scan() {
    try {
        qrcode.decode();
    } catch (e) {
        setTimeout(scan, 500);
    }
}

// Apagará la cámara
const cerrarCamara = () => {
    video.srcObject.getTracks().forEach((track) => {
        track.stop();
    });
    canvasElement.hidden = true;
    btnScanQR.hidden = false;
};

/*const activarSonido = () => {
    var audio = document.getElementById('audioScaner');
    audio.play();
}*/

// Callback cuando termina de leer el código QR
qrcode.callback = (respuesta) => {
    if (respuesta) {
        // Establecer el valor del cuadro de texto con los datos del código QR
        document.getElementById('verification_number').value = respuesta;
        // Mostrar el mensaje del código QR utilizando SweetAlert2 (opcional)
        Swal.fire(respuesta);

        // Camara encender y apagar
        // activarSonido();
        cerrarCamara();
    }
};

/////////////////////////////////////////////////////////////////////////////
//solicitud HTTP (AJAX)

document.getElementById("BtnVerificar").addEventListener("click", function (event) {
    // Obtener el valor del campo de texto
    var verificationNumber = document.getElementById('verification_number').value;

    // Verificar si el campo de texto está vacío
    if (verificationNumber === '') {
        // Mostrar un mensaje de error
        Swal.fire({
            title: "Error",
            text: "No hay número de verificación agregado",
            icon: "error"
        });
    } else {
        // Llamar a la función para enviar los datos
        enviarContenido();
        console.log("dentro del evento del botón");

        // Mostrar un mensaje de éxito después de enviar los datos
        Swal.fire({
            title: "Verificación de pedido realizada",
            icon: "success"
        }).then((result) => {
            // Limpiar contenido de la caja de texto después de que el usuario presione "OK"
            if (result.isConfirmed) {
                document.getElementById('verification_number').value = '';
            }
            // Llamar a la función para enviar los datos después de mostrar el mensaje
        });
    }
});
// Función para enviar el contenido de la caja de texto mediante AJAX
function enviarContenido() {
    // Obtener el valor del cuadro de texto
    var contenido = document.getElementById('verification_number').value;

    //solicitud
    $.ajax({
        url: "/ControllerQR/ActualizarEstado",
        type: "POST",
        data: { codigoVerificacion: contenido },
        success: function (response) {
            // Manejar la respuesta del controlador si es necesario
            console.log("Operación exitosa:" + contenido);

        },
        error: function (xhr, status, error) {
            // Manejar errores si es necesario
            console.error("Error en la solicitud AJAX");
            Swal.fire("Verificación de pedido no realizada");
        }
    });
}

////////////////////////////////////////////////////////////////////////////////

// Evento para mostrar la cámara sin el botón 
window.addEventListener('load', (e) => {
    encenderCamara();
});
