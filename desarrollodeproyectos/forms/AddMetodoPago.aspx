<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMetodoPago.aspx.cs" Inherits="desarrollodeproyectos.forms.AddMetodoPago" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Agregar Metodo de Pago</title>
    <link rel="stylesheet" href="/css/bootstrap.css" />
</head>
<body>
    <form id="formAddMetodoPago" runat="server">
        <div class="container-lg">
            <h3 class="text-center">Agregar Metodo de Pago</h3>
            <hr />
            <div class="mb-3">
                <label for="txtMetodoPagoName" class="form-label">Nombre</label>
                <input type="text" class="form-control" id="txtMetodoPagoName" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNuevoNombre" class="form-label">Nuevo Nombre</label>
                <asp:TextBox ID="txtNuevoNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="d-flex justify-content-center">
                <asp:Button ID="btnGuardarMetodoPago" runat="server" Text="Guardar Metodo"
                    OnClick="GuardarMetodoPago_Click" CssClass="btn btn-primary" />
            </div>
            <br />
            <div class="container-lg">
                <asp:GridView ID="gridMetodosPago" runat="server" CssClass="table table-striped table-hover"
                    AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="MET_ID" HeaderText="ID" />
                        <asp:BoundField DataField="MET_NAME" HeaderText="Nombre" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Eliminar" CommandName="EliminarMetodoPago"
                                    CommandArgument='<%# Eval("MET_ID") %>' OnClick="EliminarMetodoPago_Click" />
                                <asp:Button runat="server" Text="Actualizar" CommandName="ActualizarMetodoPago"
                                    CommandArgument='<%# Eval("MET_ID") %>' OnClick="ActualizarMetodoPago_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
