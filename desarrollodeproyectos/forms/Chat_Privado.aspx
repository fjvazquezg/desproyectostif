<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Chat Privado Vendedor-Consumidor</title>
    <link href="../Scripts/css/styles.css" rel="stylesheet" />
</head>
<body>
    <div class="chat-container">
        <h1>Chat Privado</h1>
        <div class="chat" id="chat-box"></div>
        <div class="input-container">
            <input type="text" id="message-input" placeholder="Escribe tu mensaje..." />
            <button onclick="sendMessage()">Enviar</button>
            <div id="typing-indicator"></div>
        </div>
    </div>
    <script src="../Scripts/script.js"></script>
</body>
</html>