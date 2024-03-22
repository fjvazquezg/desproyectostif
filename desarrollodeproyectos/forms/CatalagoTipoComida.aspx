<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatalagoTipoComida.aspx.cs" Inherits="desarrollodeproyectos.forms.CatalagoTipoComida" %>

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
    <%--<nav class="navbar navbar-expand-lg bg-primary" data-bs-theme="dark">
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
    </nav>--%>
    <form id="form1" runat="server">
        <div>
            <div class="container card shadow" style="padding: 3%; margin-top: 3%;" >
    <div class="row justify-content-center">
      <div class="col-md-40">
            <fieldset>
                <div class="form-group">
                    <div class="row gx-4">
                        <asp:Label ID="lblError" runat="server" Visible="false" Text="" ForeColor="Red"></asp:Label>
                        <div class="col" style="margin-right: 250px;" >
                        <label for="IdUsua" class="form-label mt-4 col">Id</label>
                        <%--<input type="text" readonly="" class="form-control" style="width: 140px;" id="IdUsua" placeholder="1" />--%>
                        <asp:TextBox ID="IdTipoComida" runat="server" CssClass="form-control" ReadOnly="true" Width="140px"></asp:TextBox>
                        </div>
                        <div class="col" style="margin-left: -88%;" >
                        <label for="NombreUsua" class="form-label mt-4 col">Nombre de un tipo de comida</label>
                        <%--<input type="text" readonly="" class="form-control" id="NombreUsua" placeholder="Juan Lopez Lopez" />--%>
                        <asp:TextBox ID="NombreTipoComida" runat="server" CssClass="form-control" Placeholder="Quesadillas"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <br/>
                <asp:button ID="BtnRegistrar" Text="Registrar" type="button" class="btn btn-success" runat="server" style="margin-right: 50px; width: 150px;" OnClick="BtnRegistrar_Click"></asp:button>
                <asp:button ID="BtnCancelar" Text="Cancelar" type="button" class="btn btn-danger" runat="server" style="width: 150px;" ></asp:button>
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
