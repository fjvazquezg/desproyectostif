<!DOCTYPE html>

<html lang="es">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Formulario de Registro de Usuario</title>
    <link rel="stylesheet" href="/Scripts/css/bootstrap.min.css" />
  </head>
  <body>
      <div class="container-lg">
        <h3 class="text-center">REGISTRO DE VENDEDOR</h3>
        <div class="form-group">
          <label for="exampleInputEmail1" class="form-label mt-4"
            >Nombre</label
          >
          <input
            type="Nombre"
            class="form-control"
            id="exampleInputEmail1"
            aria-describedby="emailHelp"
             placeholder="Nombre complet"
          />

        </div>
        <div class="form-group">
          <label for="exampleInputPassword1" class="form-label mt-4"
            >Correo</label
          >
          <input
            type="Correo"
            class="form-control"
            id="exampleInputPassword1"
            placeholder="Correo"
            autocomplete="off"
          />

        </div>
        <div class="form-group">
          <label for="exampleInputPassword1" class="form-label mt-4"
            >Numero de telefono</label
          >
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
          <label for="exampleInputPassword1" class="form-label mt-4"
            >Contraseña</label
          >
          <input
            type="password"
            class="form-control"
            id="exampleInputPassword1"
            placeholder="contraseña"
            autocomplete="off"
          />
        </div>
        <div class="form-group">
          <label for="exampleInputPassword1" class="form-label mt-4"
            >Confirma contraseña</label
          >
          <input
            type="password"
            class="form-control"
            id="exampleInputPassword1"
            placeholder="Confirma contraseña "
            autocomplete="off"
          />
        </div>
        <br>
        <button type="button" class="btn btn-danger">Registrar</button>

      </div>
  </body>
</html>
