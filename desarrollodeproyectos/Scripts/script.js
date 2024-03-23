// script.js
var vendedorMessageMostrado = false;
var segundoMensajeMostrado = false;

function handleKey(event) {
    if (event.key === 'Enter') {
        sendMessage();
    }
}

function sendMessage() {
    var messageInput = document.getElementById('message-input');
    var chatBox = document.getElementById('chat-box');

    var message = messageInput.value.trim();

    if (message !== '') {
        var senderLabel = 'Consumidor';
        var messageClass = 'consumer-message';
        chatBox.innerHTML += `<div class="${messageClass}"><strong>${senderLabel}:</strong> ${message}</div>`;

        messageInput.value = '';
        chatBox.scrollTop = chatBox.scrollHeight;

        if (!vendedorMessageMostrado) {
            sendDefaultVendorMessage();
            vendedorMessageMostrado = true;
        } else if (!segundoMensajeMostrado) {
            setTimeout(sendVendorResponse, 1000);
            segundoMensajeMostrado = true;
        } else {
            setTimeout(sendSecondVendorMessage, 1000);
        }
    }
}

function sendDefaultVendorMessage() {
    var chatBox = document.getElementById('chat-box');
    chatBox.innerHTML += `<div class="vendor-message"><strong>Vendedor:</strong> ¡Hola! ¿En qué puedo ayudarte?</div>`;
}

function sendSecondVendorMessage() {
    var chatBox = document.getElementById('chat-box');
    chatBox.innerHTML += `<div class="vendor-message"><strong>Vendedor:</strong> Recuerda que estoy aquí para ayudarte.</div>`;
}

function sendVendorResponse() {
    var chatBox = document.getElementById('chat-box');
    chatBox.innerHTML += `<div class="vendor-message"><strong>Vendedor:</strong> Claro, estaré encantado de ayudarte.</div>`;
}
