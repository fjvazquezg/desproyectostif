document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('repartidorForm');
    const repartidoresList = document.getElementById('repartidoresList');

    form.addEventListener('submit', (e) => {
        e.preventDefault();

        const nombre = form.querySelector('#nombre').value;
        const matricula = form.querySelector('#Matricula').value;
        const zona = form.querySelector('#zona').value;

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
