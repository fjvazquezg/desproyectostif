document.getElementById('Logo').onchange = function (e) {
    let reader = new FileReader();
    reader.readAsDataURL(e.target.files[0]);
    reader.onload = function () {
        let previewb = document.getElementById('Preview');
        //let imagen = document.createElement('img');
        previewb.src = reader.result;
        previewb.style.maxWidth = "100%";
        previewb.style.maxHeight = "100%";
        imagen.style.height = "auto"; // Cambiado de 'hight' a 'height'
        previewb.innerHTML = ''; // Elimina cualquier imagen previa
        previewb.appendChild(imagen);
    }
}


document.getElementById('ImagenPromo1').onchange = function (e) {
    let reader = new FileReader();
    reader.readAsDataURL(e.target.files[0]);
    reader.onload = function () {
        let previewb = document.getElementById('Previewb');
        //let imagen = document.createElement('img');
        previewb.src = reader.result;
        previewb.style.maxWidth = "100%";
        previewb.style.maxHeight = "100%";
        imagen.style.height = "auto"; // Cambiado de 'hight' a 'height'
        previewb.innerHTML = ''; // Elimina cualquier imagen previa
        previewb.appendChild(imagen);
    }
}

document.getElementById('ImagenPromo2').onchange = function (e) {
    let reader = new FileReader();
    reader.readAsDataURL(e.target.files[0]);
    reader.onload = function () {
        let previewc = document.getElementById('Previewc');
        //let imagen = document.createElement('img');
        previewc.src = reader.result;
        previewc.style.maxWidth = "100%";
        previewc.style.maxHeight = "100%";
        imagen.style.height = "auto"; // Cambiado de 'hight' a 'height'
        previewc.innerHTML = ''; // Elimina cualquier imagen previa
        previewc.appendChild(imagen);
    }
}