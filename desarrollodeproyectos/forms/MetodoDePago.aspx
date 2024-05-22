<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MetodoDePago.aspx.cs"
Inherits="desarrollodeproyectos.forms.MetodoDePago" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Formulario de Método de Pago</title>
    <link rel="stylesheet" href="/Scripts/css/bootstrap.min.css" />
  </head>

  <body>
    <form id="form1" runat="server" method="post">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <div class="container-lg">
        <h2 class="text-center">Selecciona tu Método de Pago</h2>
        <hr />
      </div>
      <div class="container mt-5">
        <div class="form-group">
          <div class="custom-control custom-radio">
            <asp:RadioButton
              ID="tarjeta"
              runat="server"
              CssClass="custom-control-input"
              GroupName="metodoPago"
              data-bs-toggle="collapse"
              data-bs-target="#tarjetasGuardadas"
            />
            <label class="custom-control-label" for="tarjeta">Tarjeta</label>
          </div>
          <div class="collapse" id="tarjetasGuardadas">
            <h3>Tarjetas Guardadas:</h3>
            <asp:Repeater ID="repeaterTarjetas" runat="server">
              <ItemTemplate>
                <div
                  class="container border rounded p-2 mb-3 position-relative"
                >
                  <!-- Botón de eliminación -->
                  <asp:LinkButton
                    ID="btnEliminarTarjeta"
                    runat="server"
                    CssClass="position-absolute top-0 end-0 p-2"
                    CommandArgument='<%# Eval("NUMERO_TARJETA") %>'
                    OnClick="btnEliminarTarjeta_Click"
                  >
                    <span aria-hidden="true">&times;</span>
                  </asp:LinkButton>
                  <!-- RadioButton para seleccionar la tarjeta -->
                  <asp:RadioButton
                    ID="radioTarjeta"
                    runat="server"
                    GroupName="grupoTarjetas"
                    Text='<%# Eval("NOMBRE_EN_TARJETA") %>'
                    Value='<%# Eval("NUMERO_TARJETA") %>'
                  />
                  <p class="fw-bold">
                    Tipo de Tarjeta: <%# Eval("CARD_TYPE") %>
                  </p>
                  <p>Número de Tarjeta: <%# Eval("NUMERO_TARJETA") %></p>
                  <p>Nombre en la Tarjeta: <%# Eval("NOMBRE_EN_TARJETA") %></p>
                </div>
              </ItemTemplate>
            </asp:Repeater>

            <button
              type="button"
              id="agregarTarjeta"
              class="btn btn-link"
              data-bs-target="#dialogTarjeta"
              F
              data-bs-toggle="modal"
            >
              Agregar Tarjeta
            </button>
          </div>
          <div class="custom-control custom-radio">
            <asp:RadioButton
              ID="efectivo"
              runat="server"
              CssClass="custom-control-input"
              GroupName="metodoPago"
              data-bs-toggle="modal"
              data-bs-target="#dialogEfectivo"
            />
            <label class="custom-control-label" for="efectivo">Efectivo</label>
          </div>
        </div>
        <br />

        <br />
        <asp:Button runat="server" Text="Aceptar" CssClass="btn btn-primary" />
      </div>

      <!-- Diálogo para agregar tarjeta -->
      <div
        class="modal fade"
        id="dialogTarjeta"
        tabindex="-1"
        aria-labelledby="dialogTarjetaLabel"
        aria-hidden="true"
      >
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="dialogTarjetaLabel">
                Agregue la tarjeta
              </h5>
              <button
                type="button"
                class="btn-close"
                data-bs-dismiss="modal"
                aria-label="Close"
              ></button>
            </div>
            <div class="modal-body">
              <div class="form-group">
                <label for="ddlTipoTarjetaDialog" class="form-label"
                  >Tipo de Tarjeta</label
                >
                <asp:DropDownList
                  ID="ddlTipoTarjeta"
                  runat="server"
                  CssClass="form-select"
                  ClientIDMode="Static"
                >
                  <asp:ListItem Text="Crédito" Value="Credit" />
                  <asp:ListItem Text="Débito" Value="Debit" />
                </asp:DropDownList>
              </div>
              <div class="form-group">
                <label for="numeroTarjetaDialog">Número de Tarjeta</label>
                <asp:TextBox
                  ID="numeroTarjetaDialog"
                  runat="server"
                  CssClass="form-control"
                  ClientIDMode="Static"
                >
                </asp:TextBox>
              </div>
              <div class="form-group">
                <label for="nombreTarjetaDialog">Nombre en la Tarjeta</label>
                <asp:TextBox
                  ID="nombreTarjetaDialog"
                  runat="server"
                  CssClass="form-control"
                  ClientIDMode="Static"
                >
                </asp:TextBox>
              </div>
              <div class="form-group">
                <label for="fechaExpiracionDialog">Fecha de Expiración</label>
                <asp:TextBox
                  ID="fechaExpiracionDialog"
                  runat="server"
                  CssClass="form-control"
                  ClientIDMode="Static"
                >
                </asp:TextBox>
              </div>
              <br />
              <div class="input-group">
                <span class="input-group-text">Código de Seguridad</span>
                <asp:TextBox
                  ID="codigoSeguridad1"
                  runat="server"
                  CssClass="form-control"
                  ClientIDMode="Static"
                >
                </asp:TextBox>
                >
              </div>
            </div>
            <div class="modal-footer justify-content-start">
              <button
                type="button"
                class="btn btn-secondary"
                data-bs-dismiss="modal"
              >
                Cerrar
              </button>
              <asp:Button
                ID="guardarTarjetaDialogButton"
                runat="server"
                Text="Guardar"
                CssClass="btn btn-primary"
                ClientIDMode="Static"
                OnClick="guardarTarjetaButton_Click"
              />
            </div>
          </div>
        </div>
      </div>

      <!-- Diálogo para pago en efectivo -->
      <div
        class="modal fade"
        id="dialogEfectivo"
        tabindex="-1"
        aria-labelledby="dialogEfectivoLabel"
        aria-hidden="true"
      >
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="dialogEfectivoLabel">
                Pago en Efectivo
              </h5>
              <button
                type="button"
                class="btn-close"
                data-bs-dismiss="modal"
                aria-label="Close"
              ></button>
            </div>
            <div class="modal-body">
              <asp:TextBox
                ID="precioCompra"
                runat="server"
                CssClass="form-control"
                InputMode="Numeric"
                ClientIDMode="Static"
              ></asp:TextBox>
            </div>
            <div class="modal-footer">
              <button
                type="button"
                class="btn btn-secondary"
                data-bs-dismiss="modal"
              >
                Cerrar
              </button>
            </div>
          </div>
        </div>
      </div>
    </form>

    <script
      src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
      integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
      crossorigin="anonymous"
    ></script>
  </body>
</html>
