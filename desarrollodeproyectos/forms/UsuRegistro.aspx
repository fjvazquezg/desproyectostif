<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuRegistro.aspx.cs" Inherits="desarrollodeproyectos.forms.UsuRegistro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Formulario de Registro de Usuario</title>
    <link rel="stylesheet" href="..//Scripts/css/bootstrap.min.css">
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container-lg">
      <h3 class="text-center">REGISTRO DE USUARIOS</h3>
      <div class="form-group">
        <label for="exampleInputEmail1" class="form-label mt-4">Nombre</label>
        <input
          type="Nombre"
          class="form-control"
          id="exampleInputEmail1"
          aria-describedby="emailHelp"
          placeholder="Nombre completo"
        />
      </div>
      <div class="form-group">
        <label for="exampleInputPassword1" class="form-label mt-4">Correo</label>
        <input
          type="Correo"
          class="form-control"
          id="exampleInputPassword1"
          placeholder="Correo"
          autocomplete="off"
        />
      </div>
      <div class="form-group">
        <label for="exampleInputPassword1" class="form-label mt-4">Numero de telefono</label>
        <input
          type="Telefono"
          class="form-control"
          id="exampleInputPassword1"
          placeholder="Numero de telefono"
          autocomplete="off"
          inputmode="numeric"
        />
      </div>
      <div class="form-group">
        <label for="exampleInputPassword1" class="form-label mt-4">Contraseña</label>
        <input
          type="password"
          class="form-control"
          id="exampleInputPassword1"
          placeholder="contraseña"
          autocomplete="off"
        />
      </div>
      <div class="form-group">
        <label for="exampleInputPassword1" class="form-label mt-4">Confirma contraseña</label>
        <input
          type="password"
          class="form-control"
          id="exampleInputPassword1"
          placeholder="Confirma contraseña "
          autocomplete="off"
        />
      </div>
      <!-- Button trigger modal -->
<br>
<input disabled type="checkbox" class="btn-check " id="btncheck1"  autocomplete="off" >
<label  class="btn btn-outline-primary btn-sm" for="btncheck1" id="myButton">✔</label>
<label for="btncheck1" data-bs-toggle="modal" data-bs-target="#exampleModal" ><a href="#">Acepto los <b>términos de uso</b> y <b>politicas de privacidad</b></a> </label>

<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalLabel"><b></b>Términos y Condiciones de Uso <b></b></h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <p>
          <h3><b>1. Aceptación de los Términos y Condiciones</b></h3>
        
          Al acceder o utilizar la aplicación Free Market Foods, ya sea como usuario registrado, vendedor o invitado, usted acepta estar sujeto a los presentes Términos y Condiciones de Uso y Privacidad. Si no acepta estos Términos, no debe utilizar la Aplicación.
          
          <br><br><h3><b>2. Descripción del Servicio</b></h3> 
          
          Free Market Foods es una aplicación móvil que permite a los usuarios ordenar comida de diferentes restaurantes y recibirla en una ubicación dentro de una universidad. La Aplicación actúa como un intermediario entre los usuarios, los restaurantes y los proveedores de entrega.
          
          <br><br><h3><b>3. Registro y Cuenta de Usuario</b></h3>
          
          Para utilizar la Aplicación, usted puede crear una cuenta de usuario proporcionando información personal como su nombre, dirección de correo electrónico, número de teléfono y contraseña. Usted es responsable de mantener la confidencialidad de su Cuenta y contraseña.
          
          <br><br><h3><b>4. Realización de Pedidos</b></h3>
          
          Para realizar un pedido, usted debe seleccionar un restaurante o proovedor, los platos que desea y la ubicación de entrega. El precio del pedido incluirá el precio de la comida, las tarifas de entrega y cualquier impuesto o tasa aplicable.
          
          <br><br><h3><b>5. Pago</b></h3>
          
          Los pagos se realizan a través de la Aplicación mediante tarjeta de crédito o débito. Free Market Foods no almacena información de tarjetas de crédito o débito.
          
          <br><br><h3><b>6. Entrega</b></h3>
          
          Los pedidos son entregados por proveedores de entrega independientes. El tiempo de entrega puede variar según la distancia entre el restaurante y la ubicación de entrega.
          
          <br><br><h3><b>7. Cancelaciones y Reembolsos</b></h3>
          
          Los pedidos pueden ser cancelados antes de ser confirmados por el restaurante. Si un pedido es cancelado después de ser confirmado, se aplicará una tarifa de cancelación. Los reembolsos se procesarán de acuerdo con la política de reembolso del restaurante o proovedor.
          
          <br><br><h3><b>8. Privacidad</b></h3>
          
          Free Market Foods recopila información personal de los usuarios, como su nombre, dirección de correo electrónico, número de teléfono y ubicación. Esta información se utiliza para proporcionar el servicio, mejorar la experiencia del usuario y realizar análisis. Free Market Foods no comparte información personal con terceros sin el consentimiento del usuario.
          
          <br><br><h3><b>9. Propiedad Intelectual</b></h3>
          
          El contenido de la Aplicación, incluyendo el texto, imágenes, logotipos y marcas comerciales, es propiedad de Free Market Foods o de sus licenciantes. Usted no puede copiar, distribuir o modificar el contenido de la Aplicación sin el consentimiento de Free Market Foods.
          
          <br><br><h3><b>10. Responsabilidad</b></h3>
          
          Free Market Foods no se hace responsable de los daños o perjuicios causados por el uso de la Aplicación. La Aplicación se proporciona "tal cual" y "según esté disponible". Free Market Foods no ofrece ninguna garantía, expresa o implícita, sobre la Aplicación.
          
          <br><br><h3><b>11. Modificaciones</b></h3>
          
          Free Market Foods se reserva el derecho de modificar estos Términos en cualquier momento. Las modificaciones entrarán en vigor en la fecha de su publicación en la Aplicación.
        </p>

      </div>
      <div class="modal-footer">
        <button onclick="btnClear()" type="button" class="btn btn-secondary" data-bs-dismiss="modal" id="btnCancelar">Rechazar</button>
        <button onclick="btnFill()" type="button" class="btn btn-primary" data-bs-dismiss="modal" id="btnAceptar">Aceptar</button>
      </div>
    </div>
  </div>
</div>
<br>

<script>
const checkbox = document.getElementById('btncheck1');
const btnConfirmar = document.getElementById('btnConfirmar');
const btnCancelar = document.getElementById('btnCancelar');
  btnAceptar.addEventListener('click', function() {
  checkbox.checked = true;
});

btnCancelar.addEventListener('click', function() {
  checkbox.checked = false;
  
});

</script>
      <br>
      <button type="button" class="btn btn-primary">Registrar Vendedor</button>
      <button type="button" class="btn btn-success">Registrar Comprador</button>
    </div>
        </div>
    </form>
</body>
</html>

