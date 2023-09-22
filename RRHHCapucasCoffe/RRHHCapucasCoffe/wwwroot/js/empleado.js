function inicializarFormCrearEmpleado(urlGetDepto, urlGetMpio, urlGetAldea) {
    //Metodos AJAX para rellenar los select de direccion de nacimiento del empleado
    $("#select-pais-nac").change(async function () {
        const valueSelect = $(this).val();

        const result = await fetch(urlGetDepto, {
            method: 'POST',
            body: JSON.stringify({ PaisId: valueSelect }),
            headers: {
                'Content-Type': 'application/json'
            }
        });

        const json = await result.json();
        const options =
            json.map(depto => `<option value=${depto.value}>${depto.text}</option>`);

        // Obtener la opción "Seleccione una opción"
        const selectOption = $("#select-depto-nac option:first");

        // Eliminar las opciones después de la opción "Seleccione una opción"
        $("#select-depto-nac option").remove(':gt(0)');

        // Agregar las nuevas opciones después de la opción "Seleccione una opción"
        selectOption.after(options.join(''));
        //$("#DepartamentoId").html(options);
    });

    $("#select-depto-nac").change(async function () {
        const valueSelectPais = document.getElementById('select-pais-nac').value;
        const valueSelectDepto = $(this).val();

        const result = await fetch(urlGetMpio, {
            method: 'POST',
            body: JSON.stringify({ PaisId: valueSelectPais, DepartamentoId: valueSelectDepto }),
            headers: {
                'Content-Type': 'application/json'
            }
        });

        const json = await result.json();
        const options =
            json.map(mpio => `<option value=${mpio.value}>${mpio.text}</option>`);

        // Obtener la opción "Seleccione una opción"
        const selectOption = $("#select-mpio-nac option:first");
        // Eliminar las opciones después de la opción "Seleccione una opción"
        $("#select-mpio-nac option").remove(':gt(0)');
        // Agregar las nuevas opciones después de la opción "Seleccione una opción"
        selectOption.after(options.join(''));
        //$("#DepartamentoId").html(options);
    });
    $("#select-mpio-nac").change(async function () {
        const valueSelectPais = document.getElementById('select-pais-nac').value;
        const valueSelectDepto = document.getElementById('select-depto-nac').value;
        const valueSelectMpio = $(this).val();

        const result = await fetch(urlGetAldea, {
            method: 'POST',
            body: JSON.stringify(
                {
                    PaisId: valueSelectPais,
                    DepartamentoId: valueSelectDepto,
                    MunicipioId: valueSelectMpio
                }),
            headers: {
                'Content-Type': 'application/json'
            }
        });

        const json = await result.json();
        const options =
            json.map(aldea => `<option value=${aldea.value}>${aldea.text}</option>`);

        // Obtener la opción "Seleccione una opción"
        const selectOption = $("#select-aldea-nac option:first");
        // Eliminar las opciones después de la opción "Seleccione una opción"
        $("#select-aldea-nac option").remove(':gt(0)');
        // Agregar las nuevas opciones después de la opción "Seleccione una opción"
        selectOption.after(options.join(''));
        //$("#DepartamentoId").html(options);
    });
    //Metodos AJAX para rellenar los select de direccion de residencia del empleado
    $("#select-pais-dir").change(async function () {
        const valueSelect = $(this).val();

        const result = await fetch(urlGetDepto, {
            method: 'POST',
            body: JSON.stringify({ PaisId: valueSelect }),
            headers: {
                'Content-Type': 'application/json'
            }
        });

        const json = await result.json();
        const options =
            json.map(depto => `<option value=${depto.value}>${depto.text}</option>`);

        // Obtener la opción "Seleccione una opción"
        const selectOption = $("#select-depto-dir option:first");

        // Eliminar las opciones después de la opción "Seleccione una opción"
        $("#select-depto-dir option").remove(':gt(0)');

        // Agregar las nuevas opciones después de la opción "Seleccione una opción"
        selectOption.after(options.join(''));
        //$("#DepartamentoId").html(options);
    });

    $("#select-depto-dir").change(async function () {
        const valueSelectPais = document.getElementById('select-pais-dir').value;
        const valueSelectDepto = $(this).val();

        const result = await fetch(urlGetMpio, {
            method: 'POST',
            body: JSON.stringify({ PaisId: valueSelectPais, DepartamentoId: valueSelectDepto }),
            headers: {
                'Content-Type': 'application/json'
            }
        });

        const json = await result.json();
        const options =
            json.map(mpio => `<option value=${mpio.value}>${mpio.text}</option>`);

        // Obtener la opción "Seleccione una opción"
        const selectOption = $("#select-mpio-dir option:first");
        // Eliminar las opciones después de la opción "Seleccione una opción"
        $("#select-mpio-dir option").remove(':gt(0)');
        // Agregar las nuevas opciones después de la opción "Seleccione una opción"
        selectOption.after(options.join(''));
        //$("#DepartamentoId").html(options);
    });
    $("#select-mpio-dir").change(async function () {
        const valueSelectPais = document.getElementById('select-pais-dir').value;
        const valueSelectDepto = document.getElementById('select-depto-dir').value;
        const valueSelectMpio = $(this).val();

        const result = await fetch(urlGetAldea, {
            method: 'POST',
            body: JSON.stringify(
                {
                    PaisId: valueSelectPais,
                    DepartamentoId: valueSelectDepto,
                    MunicipioId: valueSelectMpio
                }),
            headers: {
                'Content-Type': 'application/json'
            }
        });

        const json = await result.json();
        const options =
            json.map(aldea => `<option value=${aldea.value}>${aldea.text}</option>`);

        // Obtener la opción "Seleccione una opción"
        const selectOption = $("#select-aldea-dir option:first");
        // Eliminar las opciones después de la opción "Seleccione una opción"
        $("#select-aldea-dir option").remove(':gt(0)');
        // Agregar las nuevas opciones después de la opción "Seleccione una opción"
        selectOption.after(options.join(''));
        //$("#DepartamentoId").html(options);
    });


}

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
        var croppedImageBase64 = canvas.toDataURL('image/jpeg');
        $('#imagen-recortada').val(croppedImageBase64);
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