<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TurnosPedidos.aspx.cs" Inherits="desarrollodeproyectos.forms.TurnosPedidos" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <link rel="stylesheet" href="/Scripts/css/bootstrap.min.css" />
  <title>Pedidos</title>
</head>
<body>
  <form id="form1" runat="server">
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
      <div class="container-fluid">
        <a class="navbar-brand" href="#">Nombre de la Empresa</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarColor02" aria-controls="navbarColor02" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarColor02">
        </div>
      </div>
    </nav>

    <div class="container mt-4">
      <h1 class="text-center">Pedidos</h1>

      <!-- Verificación de usuario vendedor -->
      <% if(Session["TipoUsuario"].ToString() == "Vendedor") { %>

      <!-- Barra de búsqueda -->
      <asp:Panel runat="server" CssClass="mt-4 mb-3">
        <div class="input-group">
          <asp:TextBox runat="server" CssClass="form-control" placeholder="Buscar por Número de pedido" aria-label="Buscar por Número de pedido"></asp:TextBox>
          <button class="btn btn-outline-secondary" type="button">Buscar</button>
        </div>
      </asp:Panel>

      <!-- Tabla de pedidos -->
      <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped">
        <Columns>
          <asp:BoundField DataField="CAR_Id" HeaderText="Número de pedido" />
          <asp:BoundField DataField="CAR_Fecha" HeaderText="Fecha" />
          <asp:BoundField DataField="CAR_LugarDeEntrega" HeaderText="Lugar de entrega" />
          <asp:BoundField DataField="CAR_TipoDeEntrega" HeaderText="Tipo de entrega" />
          <asp:BoundField DataField="CAR_Total" HeaderText="Total" />
          <asp:BoundField DataField="CAR_Status" HeaderText="Estado" />
        </Columns>
      </asp:GridView>

      <% } else { %>
      <!-- Mensaje de error para usuarios no vendedores -->
      <div class="alert alert-danger" role="alert">
        No tienes permisos para ver esta página.
      </div>
      <% } %>
    </div>

    <script src="/js/bootstrap.bundle.min.js"></script>
  </form>
  <footer class="mt-5">
    <p class="text-center">© 2023 Nombre del Website. Todos los derechos reservados.</p>
  </footer>
</body>
</html>
