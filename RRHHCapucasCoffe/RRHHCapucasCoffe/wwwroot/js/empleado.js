$(document).ready(function () {
    var image = $('#img-cropper')[0];
    var cropper;
    var modal = new bootstrap.Modal(document.getElementById('modal-cropper-empleado'));
    $('#img-input').change(function () {
        var imgFile = this.files[0];
        var reader = new FileReader();

        if (cropper) {
            image.removeAttribute('src'); // Elimina el atributo 'src' de la imagen
            cropper.destroy();
        }

        reader.onload = function (e) {
            image.src = e.target.result;
            initializeCropper();
        };
        reader.readAsDataURL(imgFile);
    });
    function initializeCropper() {
        cropper = new Cropper(image, {
            aspectRatio: 1, // Cambia esto según tus necesidades
            viewMode: 1, // Opciones de visualización para ajustar la imagen
        });
    }
    $('#crop-button').click(function () {
        var canvas = cropper.getCroppedCanvas();
        var previewImage = document.getElementById('imagen-previa');
        previewImage.src = canvas.toDataURL(); // Actualiza la imagen previa
        modal.hide(); // Cierra el modal
    });
});

$('#btn-delete-photo').click(function () {
    $('#imagen-previa').attr('src', '');

    // Establece la nueva imagen desde la carpeta 'img/'
    var nuevaImagenSrc = '/img/ImgUpload.png'; // Reemplaza 'tu-nueva-imagen.jpg' con el nombre de tu nueva imagen
    $('#imagen-previa').attr('src', nuevaImagenSrc);
});