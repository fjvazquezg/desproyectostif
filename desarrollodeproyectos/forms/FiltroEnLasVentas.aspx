<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FiltroEnLasVentas.aspx.cs" Inherits="desarrollodeproyectos.forms.FiltroEnLasVentas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Filtros en las ventas</title>
    <link href="../Scripts/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>

</head>
<body>
    <form id="form1" runat="server">
        </div>
    </form>

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5">Filtros</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <asp:Repeater ID="RepeaterProductos" runat="server">
                    <ItemTemplate>
                        <div>
                            <span><%# Eval("Nombre") %></span>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="modal-body">
                    <p>
                        <!-- Botones de Rango de precio -->
                        <h4>Rango de precio</h4>
                        <div class="input-group mb-3">
                            <asp:TextBox ID="txtPrecioMin" runat="server"></asp:TextBox>
                            <span class="input-group-text">$</span>
                            <input type="number" class="form-control" id="txtPreMini" placeholder="Precio mínimo" aria-label="Precio mínimo">

                            <asp:TextBox ID="txtPrecioMax" runat="server"></asp:TextBox>
                            <span class="input-group-text">$</span>
                            <input type="number" class="form-control" id="txtPreMax" placeholder="Precio máximo" aria-label="Precio máximo">
                        </div>

                        <!-- Botones de Productos -->
                        <h4>Categorías</h4>
                        <div class="btn-group" role="group" aria-label="Basic checkbox toggle button group">
                            <input type="checkbox" class="btn-check" id="check1" autocomplete="off">
                            <label class="btn btn-outline-primary" for="check1">Categoría</label>
                            <input type="checkbox" class="btn-check" id="check2" autocomplete="off">
                            <label class="btn btn-outline-primary" for="check2">Categoría</label>
                            <input type="checkbox" class="btn-check" id="check3" autocomplete="off">
                            <label class="btn btn-outline-primary" for="check3">Categoría</label>
                        </div>
                        <br>
                        <br>


                        <!-- Botón otros -->
                        <h4>Otros</h4>
                        <div class="btn-container">
                            <div class="d-grid gap-2">
                                <button class="btn btn-lg btn btn-outline-danger" id="btnFav" type="button">☆ Favoritos</button>
                                <br>
                            </div>
                        </div>
                    </p>
                </div>
                <!-- Botones de cerrar y confirmar -->
                <div class="modal-footer justify-content-between">
                    <button type="button" class="btn btn-secondary btn-lg" id="btnRestablecer">Restablecer</button>

                    <div>
                        <button type="button" class="btn btn-danger btn-lg" data-bs-dismiss="modal" id="btnCerrar">Cerrar</button>
                        <button type="button" class="btn btn-success btn-lg" id="btnAceptar">Confirmar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
<script>
    const btnRestablecer = document.getElementById('btnRestablecer');
    const btnCerrar = document.getElementById('btnCerrar');
    const Check1 = document.getElementById('check1');
    const Check2 = document.getElementById('check2');
    const Check3 = document.getElementById('check3');
    const textBox1 = document.getElementById('txtPreMini');
    const textBox2 = document.getElementById('txtPreMax');
    const btnFav = document.getElementById('btnFav');
    const btnAceptar = document.getElementById('btnAceptar');

    var checked = false;
    btnRestablecer.addEventListener('click', function () {
        Check1.checked = false;
        Check2.checked = false;
        Check3.checked = false;
        textBox1.value = null;
        textBox2.value = "";
        btnFav.className = "btn btn-lg btn btn-outline-danger";
    });

    btnFav.addEventListener('click', function () {
        if (checked) {
            btnFav.className = "btn btn-lg btn btn-outline-danger";
            checked = false;
        }
        else {
            btnFav.className = "btn btn-lg btn btn-danger";
            checked = true;

        }
    });

    btnAceptar.addEventListener('click', function (event) {
        event.preventDefault();

        __doPostBack('btnAceptar', '');
    });
</script>
</html>
