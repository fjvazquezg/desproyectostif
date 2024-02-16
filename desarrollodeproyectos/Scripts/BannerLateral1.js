let isImageAccepted = false; // Variable de estado para rastrear si la imagen es aceptada

function previewImage(event, querySelector){

	const input = event.target;
	
	$imgPreview = document.querySelector(querySelector);

	if(!input.files.length) return
	
	file = input.files[0];

	// Verificar el tipo de archivo
	let fileType = file.type;
	if(fileType !== 'image/jpeg' && fileType !== 'image/png' && fileType !== 'image/jpg') {
		alert('Archivo no aceptado! Solo se aceptan imágenes jpg, jpeg y png');
		isImageAccepted = false; // Imagen no aceptada
		return;
	}

	objectURL = URL.createObjectURL(file);
	
	let img = new Image();

	img.onload = function() {
		if(this.width == 185 && this.height == 753) {
			$imgPreview.src = objectURL;
			isImageAccepted = true; // Imagen aceptada
		} else {
			alert('Imagen no aceptada! La imagen debe de ser de un tamaño de 910x373 pixeles');
			isImageAccepted = false; // Imagen no aceptada
		}
	}
	img.src = objectURL;
}

// Función para verificar si la imagen es aceptada antes de subir
function uploadBanner() {
	if(isImageAccepted) {
		location.href='BannerLateral.html';
	} else {
		alert('Por favor, sube una imagen válida antes de continuar.');
	}
}
