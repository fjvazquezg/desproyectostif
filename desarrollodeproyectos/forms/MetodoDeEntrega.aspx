<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MetodoDeEntrega.aspx.cs" Inherits="desarrollodeproyectos.forms.MetodoDeEntrega" %>

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

                <div class="col-md-6 col-lg-4 mb-4">
                    <div class="card shadow">
                        <div class="card-body p-0">     
                             <a href="#" class="cuadro" >        
                                <h3 class="card-title" >Enviar al domicilio</h3>
                                <p class="mb-0">Edificio: A</p> 
                                <p class="mb-0">Salon: A5</p>
                                <p class="mb-0">Telefono: 687-465-6587</p>
                             </a>

                            <hr class="m-0" />

                            <a href="#" class="cuadro ">                      
                                <h6 class="text-info">Editar o elegir otro domicilio</h6>                 
                            </a>   
                        </div>            
                    </div>
                </div>

                <div class="col-md-6 col-lg-4 mb-4">
                    <div class="card shadow">
                        <div class="card-body p-0">     
                            <a href="#" class="cuadro" >        
                                <h3 class="card-title" >Retirar de un punto de entrega</h3>
                                <p class="mb-0">Edificio: A</p> 
                                <p class="mb-0">Salon: A5</p>
                                <p class="mb-0">Telefono: 687-465-6587</p>
                            </a>

                            <hr class="m-0" /> 
                   
                           <a href="#" class="cuadro ">                      
                                <h6 class="text-info">Ver punto en el mapa</h6>                 
                           </a>   
                        </div>            
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
</html>
