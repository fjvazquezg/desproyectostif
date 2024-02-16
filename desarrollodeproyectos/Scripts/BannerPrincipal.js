function previewImage(event, querySelector){

	const input = event.target;
	
	$imgPreview = document.querySelector(querySelector);

	if(!input.files.length) return
	
	file = input.files[0];

	// Verificar el tipo de archivo
	let fileType = file.type;
	if(fileType !== 'image/jpeg' && fileType !== 'image/png' && fileType !== 'image/jpg') {
		alert('Archivo no aceptado! Solo se aceptan imágenes jpg, jpeg y png');
		return;
	}

	objectURL = URL.createObjectURL(file);
	
	let img = new Image();

	img.onload = function() {
		if(this.width == 910 && this.height == 373) {
			$imgPreview.src = objectURL;
		} else {
			alert('Imagen no aceptada! La imagen debe de ser de un tamaño de 910x373 pixeles');
		}
	}
	img.src = objectURL;
}
