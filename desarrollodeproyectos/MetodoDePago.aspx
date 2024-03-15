<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MetodoDePago.aspx.cs" Inherits="desarrollodeproyectos.MetodoDePago" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Formulario de Método de Pago</title>
    <link rel="stylesheet" href="/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-lg">
            <h2 class="text-center">Selecciona tu Método de Pago</h2>
            <hr />
        </div>
        <div class="container mt-5">
            <div class="form-group">
                <div class="custom-control custom-radio">
                    <input type="radio" id="tarjeta" name="metodoPago" class="custom-control-input" data-bs-toggle="collapse" data-bs-target="#tarjetasGuardadas" />
                    <label class="custom-control-label" for="tarjeta">Tarjeta</label>
                </div>
                <!-- Añadido aquí el bloque de tarjetas guardadas -->
                <div class="collapse" id="tarjetasGuardadas">
                    <h3>Tarjetas Guardadas:</h3>
                    <ul id="listaTarjetas">
                        <!-- Aquí se mostrarán las tarjetas guardadas -->
                    </ul>
                    <button type="button" id="agregarTarjeta" class="btn btn-link" data-bs-target="#dialogTarjeta" data-bs-toggle="modal">Agregar Tarjeta</button>
                </div>
                <!-- Fin del bloque de tarjetas guardadas -->
                <div class="custom-control custom-radio">
                    <input type="radio" id="efectivo" name="metodoPago" class="custom-control-input" data-bs-toggle="modal" data-bs-target="#dialogEfectivo" />
                    <label class="custom-control-label" for="efectivo">Efectivo</label>
                </div>
            </div>
            <br />
            <button type="button" id="continuarButton" class="btn btn-primary">Continuar</button>
        </div>
    </form>

    <!-- Diálogos -->
    <div class="modal fade" id="dialogTarjeta" tabindex="-1" aria-labelledby="dialogTarjetaLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="dialogTarjetaLabel">Agregue la tarjeta</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="ddlTipoTarjeta" class="form-label">Tipo de Tarjeta</label>
                        <select class="form-select" id="ddlTipoTarjeta">
                            <option value="credito">Crédito</option>
                            <option value="debito">Débito</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="numeroTarjetaDialog">Número de Tarjeta</label>
                        <input type="text" id="numeroTarjetaDialog" class="form-control" inputmode="numeric" />
                    </div>
                    <div class="form-group">
                        <label for="nombreTarjetaDialog">Nombre en la Tarjeta</label>
                        <input type="text" id="nombreTarjetaDialog" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="fechaExpiracionDialog">Fecha de Expiración</label>
                        <input type="text" id="fechaExpiracionDialog" class="form-control" inputmode="numeric" />
                    </div>
                    <div class="input-group">
                        <span class="input-group-text">Código de Seguridad</span>
                        <input type="text" id="codigoSeguridad1" class="form-control" inputmode="numeric" />
                        <input type="text" id="codigoSeguridad2" class="form-control" inputmode="numeric" />
                    </div>
                </div>
                <div class="modal-footer justify-content-start">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                    <button type="button" id="guardarTarjetaButton" class="btn btn-primary">Guardar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="dialogEfectivo" tabindex="-1" aria-labelledby="dialogEfectivoLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="dialogEfectivoLabel">Ingrese la cantidad de efectivo</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="cantidadEfectivo">Cantidad de Efectivo</label>
                        <input type="text" id="cantidadEfectivo" class="form-control" />
                    </div>
                </div>
                <div class="modal-footer justify-content-start">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                    <button type="button" id="procederPagoEfectivoButton" class="btn btn-primary">Proceder al Pago</button>
                </div>
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha384-KyZXEAg3QhqLMpG8r+Knujsl5+EHQv5StI3b4M1j17BmK/SQKb8v+fo4v/d0PB0b" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
    <script>
        $(document).ready(function () {
            $('#guardarTarjetaButton').click(function () {
                var cardType = $('#ddlTipoTarjeta').val();
                var cardNumber = $('#numeroTarjetaDialog').val();
                var cardName = $('#nombreTarjetaDialog').val();
                var expirationDate = $('#fechaExpiracionDialog').val();
                var securityCode = $('#codigoSeguridad1').val() + $('#codigoSeguridad2').val();

                // Llamada al método de C# para guardar la tarjeta
                PageMethods.SaveCard(cardType, cardNumber, cardName, expirationDate, securityCode, onSuccess, onError);
            });
        });

        // Función de éxito
        function onSuccess() {
            alert('Tarjeta guardada exitosamente.');
            $('#dialogTarjeta').modal('hide');
        }

        // Función de error
        function onError() {
            alert('Error al guardar la tarjeta. Inténtelo de nuevo.');
        }
    </script>
</body>
</html>
