﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MetodoDeEntrega.aspx.cs" Inherits="desarrollodeproyectos.forms.MetodoDeEntrega" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <link href="../Scripts/css/bootstrap.css" rel="stylesheet" />
    <link href="../Scripts/css/bootstrap.min.css" rel="stylesheet" />

    <link href="../Scripts/css/style_metodo_de_entrega.css" rel="stylesheet" />

</head>
<body>

    
     <nav class="navbar navbar-expand-lg bg-primary" data-bs-theme="dark">
     <div class="d-flex justify-content-between align-items-center">
        
        <a href="#" >
           <svg xmlns="http://www.w3.org/2000/svg" class="icon icon-tabler icon-tabler-arrow-left" width="40" height="40" viewBox="0 0 24 24" stroke-width="1.5" stroke="#2c3e50" fill="none" stroke-linecap="round" stroke-linejoin="round">
               <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
               <path d="M5 12l14 0" />
               <path d="M5 12l6 6" />
               <path d="M5 12l6 -6" />
           </svg>
        </a>
   

        <h1 class="navbar-brand">Elige metodo de entrega</h1>   
         
    </div>
</nav>

    <form id="form1" runat="server">
          <div class="container py-5">
            <div class="row">

                <div class="col-md-6 col-lg-5 mb-4">
                    <div class="card shadow cuadro" id="CuadroDomicilio">     
                        <div class="card-body p-3">     
                            <input type="checkbox" class="form-check-input fs-5" onclick="habilitar('CuadroDomicilio')" />
                            <h3 class="card-title" >Enviar al domicilio</h3>
                                <p class="mb-0">Edificio:</p>
                                  <input type="text" id="dotxtEdificio" name="txtEdificio" class="form-control form-control-sm" runat="server" disabled />
                                <p class="mb-0">Salon:</p>
                                  <input type="text" id="dotxtSalon" name="txtSalon" class="form-control form-control-sm"  runat="server" disabled />
                                <p class="mb-0">Telefono:</p> 
                                  <input type="text" id="dotxtTelefono" name="txtTelefono" class="form-control form-control-sm"  runat="server" disabled />

                            <hr class="m-0 my-3" />

                            <asp:Button ID="btnDomicilio" runat="server" Text="Guardar" CssClass="btn btn-secondary form-control form-control-sm" OnClick="Unnamed1_Click"  Enabled="false"  DisabledCssClass="disabled"></asp:Button>

                        </div>            
                    </div>
                </div>

                <div class="col-md-6 col-lg-5 mb-4">
                    <div class="card shadow cuadro" id="CuadroPunto">
                        <div class="card-body p-3">        
                            <input type="checkbox" class="form-check-input fs-5" onclick="habilitar('CuadroPunto')" />
                            <h3 class="card-title" >Retirar de un punto de entrega</h3>
                                <p class="mb-0">Edificio:</p>
                                   <input type="text" id="putxtEdificio" name="txtEdificio" class="form-control form-control-sm" runat="server" disabled />
                                <p class="mb-0">Salon:</p>
                                    <input type="text" id="putxtSalon" name="txtSalon" class="form-control form-control-sm" runat="server" disabled />
                                <p class="mb-0">Telefono:</p>
                                    <input type="text" id="putxtTelefono" name="txtTelefono" class="form-control form-control-sm" runat="server" disabled />


                            <hr class="m-0 my-3" />

                            <asp:Button ID="btnpunto" runat="server" Text="Guardar" CssClass="btn btn-secondary  form-control form-control-sm" OnClick="Unnamed2_Click" Enabled="false"  DisabledCssClass="disabled"></asp:Button> 
                            
                        </div>            
                    </div>
                </div>
            </div>
        </div>
    </form>



    
 <script>
     function habilitar(id) {
         var cuadros = document.getElementsByClassName('cuadro');
         for (var i = 0; i < cuadros.length; i++) {
             var checkbox = cuadros[i].getElementsByTagName('input')[0];
             var inputText1 = cuadros[i].getElementsByTagName('input')[1];
             var inputText2 = cuadros[i].getElementsByTagName('input')[2];
             var inputText3 = cuadros[i].getElementsByTagName('input')[3];

             var boton1;

             if (cuadros[i].id == 'CuadroDomicilio') {
                 boton1 = cuadros[i].querySelector('#<%= btnDomicilio.ClientID %>');
            } else if (cuadros[i].id == 'CuadroPunto') {
                boton1 = cuadros[i].querySelector('#<%= btnpunto.ClientID %>');
             }

             if (cuadros[i].id == id) {
                 checkbox.checked = true;
                 inputText1.disabled = false;
                 inputText2.disabled = false;
                 inputText3.disabled = false;
                 boton1.disabled = false;
                 cuadros[i].style.opacity = 1;
             } else {
                 checkbox.checked = false;
                 inputText1.disabled = true;
                 inputText2.disabled = true;
                 inputText3.disabled = true;
                 boton1.disabled = true;
                 cuadros[i].style.opacity = 0.5;
             }
         }
     }
 </script>


</body>
</html>
