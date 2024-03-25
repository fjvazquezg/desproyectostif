// app.js

const express = require('express');
const sql = require('mssql');

const app = express();
const PORT = process.env.PORT || 3000;

// Configuración de la conexión a la base de datos
const config = {
  user: 'sa',
  password: '123qwe!@#',
  server: 'doli.servehttp.com\sql2017,1434', // Cambia esto si tu servidor SQL Server está en un lugar diferente
  database: 'DESPROYECTOS',
  options: {
    trustServerCertificate: true // Si estás usando certificados SSL
  }
};

// Middleware para analizar el cuerpo de las solicitudes como JSON
app.use(express.json());

// Ruta para agregar un nuevo producto
app.post('/api/productos', async (req, res) => {
  try {
    const { nombre, precio, stock, imagen } = req.body;

    // Conectar a la base de datos
    await sql.connect(config);

    // Insertar el nuevo producto en la base de datos
    await sql.query`INSERT INTO Productos (Nombre, Precio, Stock, Imagen) VALUES (${nombre}, ${precio}, ${stock}, ${imagen})`;

    // Desconectar de la base de datos
    await sql.close();

    res.status(201).json({ message: 'Producto agregado correctamente' });
  } catch (error) {
    console.error('Error al agregar producto:', error.message);
    res.status(500).json({ error: 'Error interno del servidor' });
  }
});

// Ruta para obtener todos los productos
app.get('/api/productos', async (req, res) => {
  try {
    // Conectar a la base de datos
    await sql.connect(config);

    // Obtener todos los productos de la base de datos
    const result = await sql.query`SELECT * FROM Productos`;

    // Desconectar de la base de datos
    await sql.close();

    res.json(result.recordset);
  } catch (error) {
    console.error('Error al obtener productos:', error.message);
    res.status(500).json({ error: 'Error interno del servidor' });
  }
});

// Iniciar el servidor
app.listen(PORT, () => {
  console.log(`Servidor escuchando en el puerto ${PORT}`);
});

// En tu archivo HTML, agrega un botón para registrar el producto
<button id="btnRegistrarProducto">Registrar Producto</button>

// En tu archivo JavaScript, agrega el siguiente código para manejar el evento de clic del botón
document.addEventListener('DOMContentLoaded', () => {
    const btnRegistrarProducto = document.getElementById('btnRegistrarProducto');
    
    btnRegistrarProducto.addEventListener('click', async () => {
        try {
            const nombre = document.getElementById('nombre').value;
            const precio = parseFloat(document.getElementById('precio').value);
            const stock = parseInt(document.getElementById('stock').value);
            const imagen = document.getElementById('imagen').value;

            const nuevoProducto = {
                nombre,
                precio,
                stock,
                imagen
            };

            // Llamar a la API para registrar el nuevo producto
            const response = await fetch('/api/productos', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(nuevoProducto)
            });

            if (response.ok) {
                // Producto agregado exitosamente
                alert('Producto agregado correctamente');
            } else {
                // Error al agregar el producto
                const errorMessage = await response.text();
                throw new Error(errorMessage);
            }
        } catch (error) {
            console.error('Error al agregar el producto:', error.message);
            alert('Error al agregar el producto. Consulta la consola para más detalles.');
        }
    });
});
