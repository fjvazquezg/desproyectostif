<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorreoEnviadoCorrectamente.aspx.cs" Inherits="desarrollodeproyectos.forms.CorreoEnviadoCorrectamente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<link href="../Scripts/css/bootstrap.css" rel="stylesheet" />
<link href="../Scripts/css/bootstrap.min.css" rel="stylesheet" />
<link href="../Scripts/css/bootstrap.rtl.css" rel="stylesheet" />
<link href="../Scripts/css/bootstrap.rtl.min.css" rel="stylesheet" />
<link rel="stylesheet" href="../forms/Correo.css">

<body>
    <form id="form1" runat="server">
        <div class="container">
        <span class="success-icon">&#10004;</span>
        <h1>¡Correo enviado exitosamente!</h1>
        <p class="message">Tu mensaje ha sido enviado correctamente. ¡Gracias por tu consulta!</p>
        <a href="index.aspx" class="btn-back">Volver al inicio</a>
    </div>
    </form>
</body>
</html>
