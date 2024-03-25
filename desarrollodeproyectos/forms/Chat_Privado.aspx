<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat_Privado.aspx.cs" Inherits="desarrollodeproyectos.forms.Chat_Privado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Chat Privado Vendedor-Consumidor</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="../Scripts/css/styles.css" rel="stylesheet" />
   
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="chat-container">
        <h1>Chat Privado</h1>
        <div class="chat" id="chat-box"></div>
        <div class="input-container">
            <input type="text" id="message-input" placeholder="Escribe tu mensaje..." oninput="handleTyping()" onkeydown="handleKey(event)">
            <button onclick="sendMessage()">Enviar</button>
            <div id="typing-indicator"></div>
        </div>
    </div>
    <script src="../Scripts/script.js"></script>

        </div>
    </form>
</body>
</html>
