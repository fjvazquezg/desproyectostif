﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatalogoProductos.aspx.cs" Inherits="desarrollodeproyectos.forms.CatalogoProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="../Scripts/css/bootstrap.css" rel="stylesheet" />
<link href="../Scripts/css/bootstrap.min.css" rel="stylesheet" />
<link href="../Scripts/css/bootstrap.rtl.css" rel="stylesheet" />
<link href="../Scripts/css/bootstrap.rtl.min.css" rel="stylesheet" />
    <title></title>
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
   

            <h1 class="navbar-brand">Registro de productos</h1>
             
        </div>
    </nav>
    <form id="form1" runat="server">
        <div>
            <div class="container">
    <div class="row justify-content-center">
      <div class="col-md-40">
            <fieldset>
                <div class="form-group">
                <div class="row gx-4">
                    <div class="col" style="margin-right: 250px;" >
                    <label for="IdUsua" class="form-label mt-4 col">Id Usuario</label>
                    <input type="text" readonly="" class="form-control" style="width: 140px;" id="IdUsua" placeholder="1" />
                    </div>
                    <div class="col" style="margin-left: -88%;" >
                    <label for="NombreUsua" class="form-label mt-4 col">Nombre del usuario</label>
                    <input type="text" readonly="" class="form-control" id="NombreUsua" placeholder="Juan Lopez Lopez" />
                    </div>
                </div>
                </div>
                <div class="form-group">
                <div class="row gx-4">
                    <div class="col" style="margin-right: 250px;">
                    <label for="IdProduc" class="form-label mt-4 col">Id Producto</label>
                    <input type="text" readonly="" class="form-control" style="width: 140px;" id="IdProduc" placeholder="1" />
                    </div>
                    <div class="col" style="margin-left: -88%;">
                    <label for="NombreProduc" class="form-label mt-4 col">Nombre del producto</label>
                    <input type="text" class="form-control" id="NombreProduc" placeholder="Burritos de frijoles" />
                    </div>
                </div>
                </div>
                <div class="form-group">
                <label class="form-label mt-4">Precio del producto</label>
                <div class="form-group">
                    <div class="input-group mb-3">
                    <span class="input-group-text">$</span>
                    <input type="text" class="form-control" aria-label="Amount (to the nearest dollar)" />
                    </div>
                </div>
                </div>
                <div class="form-group">
                <label class="form-label mt-4">Stock minimo</label>
                <div class="form-group">
                    <div class="input-group mb-3">
                    <input type="text" class="form-control" />
                    </div>
                </div>
                </div>
                <div class="form-group">
                <label class="form-label mt-4">Stock maximo</label>
                <div class="form-group">
                    <div class="input-group mb-3">
                    <input type="text" class="form-control" />
                    </div>
                </div>
                </div>
                <div class="form-group">
                  <label for="SeleccionProduc" class="form-label mt-4">Tipo de comida</label>
                  <select class="form-select" id="SeleccionProduc">
                    <option>Torta(s)</option>
                    <option>Burrito(s)</option>
                    <option>Quesadilla(s)</option>
                    <option>Sandwich</option>
                    <option>Té</option>
                    <option>Refresco</option>
                    <option>Snack</option>
                    <option>Otro</option>
                  </select>
                </div>
                <div class="form-group">
                  <label for="DescripcionProduc" class="form-label mt-4">Descripción</label>
                  <textarea class="form-control" id="DescripcionProduc" rows="3"></textarea>
                </div>
                <div class="form-group" style="margin-right: 4%;">
                  <label for="ImgFile" class="form-label mt-4">Imagen del producto</label>
                  <input class="form-control" style="margin-bottom: 20px;" type="file" id="ImgFile" />
                  <div id="preview" class="styleImage" ></div>
                </div>
                <script src="../Js/main.js"></script>
                <br/>
                <button type="button" class="btn btn-success" style="margin-right: 50px; width: 150px;" >Registrar</button>
                <button type="button" class="btn btn-danger" style="width: 150px;" >Cancelar</button>
         </fieldset>
      </div>
    </div>
  </div>

  <footer class="border-top footer text-muted" style="margin: 2%;">
    <div class="container" style="margin: 1%;">
        &copy; 2024 - Proyecto de la comida - <a asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
    </div>
  </footer>
        </div>
    </form>
</body>
</html>