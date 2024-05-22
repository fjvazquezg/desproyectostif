document.addEventListener('DOMContentLoaded', () => {
        let repartidores = []; // Array para almacenar los repartidores
    
        const form = document.getElementById('repartidorForm');
        const repartidoresList = document.getElementById('repartidoresList');
    
        form.addEventListener('submit', (e) => {
            e.preventDefault();
    
            const nombre = form.querySelector('#nombre').value;
            const matricula = form.querySelector('#matricula').value;
            const zona = form.querySelector('#zona').value;
    
            // Crear un nuevo repartidor
            const nuevoRepartidor = { nombre, matricula, zona };
    
            // Agregar el repartidor al array
            repartidores.push(nuevoRepartidor);
    
            // Crear un nuevo elemento de repartidor y añadirlo a la lista
            const repartidorItem = document.createElement('div');
            repartidorItem.innerHTML = `
                <strong>${nombre}</strong> - Matrícula: ${matricula} - Zona: ${zona}
            `;
            repartidoresList.appendChild(repartidorItem);
    
            // Limpiar el formulario
            form.reset();
        });
    });
    