document.getElementById('ImgFile').onchange = function (e) {
    let reader = new FileReader();
    reader.readAsDataURL(e.target.files[0]);
    reader.onload = function () {
        let preview = document.getElementById('preview');
        let imagen = document.createElement('img');
        imagen.src = reader.result;
        imagen.style.width = "100%";
        imagen.style.height = "auto"; // Cambiado de 'hight' a 'height'
        preview.innerHTML = ''; // Elimina cualquier imagen previa
        preview.appendChild(imagen);
    }
}