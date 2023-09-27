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

    $('#select-agencia').change(async function () {
        const valueAgencia = $(this).val();

        const result = await fetch(urlGetArea, {
            method: 'POST',
            body: JSON.stringify({ AgenciaId: valueAgencia }),
            headers: {
                'Content-Type': 'application/json'
            }
        });

        const json = await result.json();

        const options =
            json.map(agencia => `<option value=${agencia.value}>${agencia.text}</option>`);

        //Obtener la primera opcion
        const selectOption = $("#select-area option:first");

        //Elimina las opciones despues de la primera opcion
        $("#select-area option").remove(':gt(0)');

        //Agregar las nuevas opciones despues de la primera opcion
        selectOption.after(options.join(''));
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

$('#btn-agregar-banco').click(function () {
    const selectBanco = $('#select-banco');

    const celdaAccionesBank = $('<td>');
    const botonEliminarBank = $('<button>', {
        class: 'btn btn-outline-danger btn-sm bi bi-trash',
        id: 'btn-eliminar-fila'
    });

    const celdaBank = $('<td>', {
        text: selectBanco.find(':selected').text()
    });
    const inputBancoId = $('<input>', {
        type: 'hidden',
        name: 'BancoId',
        value: selectBanco.val()
    });

    const celdaInputNoCuenta = $('<td>');
    const inputNoCuenta = $('<input>', {
        type: 'text',
        class: 'form-control form-control-sm',
        name: 'EmpleadoBanco.EmpleadoBancoNoCuenta'
    });
    const celdaInputBancoActiva = $('<td>');
    const divFormCheck = $('<div>', {
        class: 'form-check'
    });
    const inputBancoActiva = $('<input>', {
        type: 'radio',
        class: 'form-check-input',
        name: 'EmpleadoBanco.EmpleadoBancoActiva',
        value: ''
    });

    celdaAccionesBank.append(botonEliminarBank);
    celdaBank.append(inputBancoId);
    celdaInputNoCuenta.append(inputNoCuenta);
    celdaInputBancoActiva.append(divFormCheck.append(inputBancoActiva));

    const nuevaFilaBank = $('<tr>').append(celdaAccionesBank, celdaBank, celdaInputNoCuenta, celdaInputBancoActiva);

    $('#data-table-body-bank').append(nuevaFilaBank);
});

$('#btn-agregar-colegiacion').click(function () {
    const selectColegio = $('#select-colegio');

    const celdaAccionesColegio = $('<td>');
    const botonEliminasColegio = $('<button>', {
        class: 'btn btn-outline-danger btn-sm bi bi-trash',
        id: 'btn-eliminar-fila'
    });

    const celdaColegio = $('<td>', {
        text: selectColegio.find(':selected').text()
    });
    const inputColegioId = $('<input>', {
        type: 'hidden',
        name: 'BancoId',
        value: selectColegio.val()
    });
    const celdaInputColAnio = $('<td>');
    const inputColAnio = $('<input>', {
        type: 'text',
        class: 'form-control form-control-sm',
        name: ''
    });
    const celdaInputColCuota = $('<td>');
    const inputColCuota = $('<input>', {
        type: 'text',
        class: 'form-control form-control-sm',
        name: ''
    });
    const celdaInputColActivo = $('<td>');
    const divFormCheck = $('<div>', {
        class: 'form-check'
    });
    const inputColActivo = $('<input>', {
        type: 'radio',
        class: 'form-check-input',
        name: 'EmpleadoColegiacion.EmpleadoColegiacionActivo',
        value: ''
    });

    celdaAccionesColegio.append(botonEliminasColegio);
    celdaColegio.append(inputColegioId);
    celdaInputColAnio.append(inputColAnio);
    celdaInputColCuota.append(inputColCuota);
    celdaInputColActivo.append(divFormCheck.append(inputColActivo));

    const nuevaFilaColegio = $('<tr>').append(celdaAccionesColegio, celdaColegio, celdaInputColAnio, celdaInputColCuota, celdaInputColActivo);

    $('#data-table-body-colegio').append(nuevaFilaColegio);
});

$('#btn-agregar-area').click(function () {
    const selectAgencia = $('#select-agencia');
    const selectArea = $('#select-area');

    const celdaAccionesArea = $('<td>');
    const buttonEliminarArea = $('<button>', {
        class: 'btn btn-outline-danger btn-sm bi bi-trash',
        id: 'btn-eliminar-fila'
    });

    const celdaAgencia = $('<td>', {
        text: selectAgencia.find(':selected').text()
    });
    const inputAgencia = $('<input>', {
        type: 'hidden',
        name: 'EmpleadoArea.AgenciaId',
        value: selectAgencia.val()
    })

    const celdaArea = $('<td>', {
        text: selectArea.find(':selected').text()
    });
    const inputArea = $('<input>', {
        type: 'hidden',
        name: 'EmpleadoArea.UnidadId',
        value: selectArea.val()
    })

    const celdaInputAreaActiva = $('<td>');
    const divFormCheck = $('<div>', {
        class: 'form-check'
    });
    const inputAreaActiva = $('<input>', {
        id: 'radio-area-activo',
        type: 'radio',
        class: 'form-check-input',
        name: 'EmpleadoArea.EmpleadoAreaActivo',
        value: ''
    });

    celdaAccionesArea.append(buttonEliminarArea);
    celdaAgencia.append(inputAgencia);
    celdaArea.append(inputArea);
    celdaInputAreaActiva.append(divFormCheck.append(inputAreaActiva));

    const nuevaFilaArea = $('<tr>').append(celdaAccionesArea, celdaAgencia, celdaArea, celdaInputAreaActiva);

    $('#data-table-body-area').append(nuevaFilaArea);
})

$('#btn-agregar-cargo').click(function () {
    const selectCargo = $('#select-cargo');
    const selectModalidad = $('#select-modalidad')

    const celdaAccionesCargo = $('<td>');
    const buttonEliminarCargo = $('<button>', {
        type: 'button',
        class: 'btn btn-outline-danger btn-sm bi bi-trash',
        id: 'btn-eliminar-fila'
    });
    const celdaCargo = $('<td>', {
        text: selectCargo.find(':selected').text()
    });
    const inputCargoId = $('<input>', {
        type: 'hidden',
        name: 'EmpleadoCargo.CargoId',
        value: selectCargo.val()
    });
    const celdaModalidad = $('<td>', {
        text: selectModalidad.find(':selected').text()
    });
    const inputModalidadId = $('<input>', {
        type: 'hidden',
        name: 'EmpleadoCargo.ModalidadId',
        value: selectModalidad.val()
    });
    const celdaFechaInicio = $('<td>');
    const inputFechaInicio = $('<input>', {
        type: 'date',
        class: 'form-control form-control-sm',
        name: 'EmpleadoCargo.EmpleadoCargoFechaInicio'
    });
    const celdaFechaFinal = $('<td>');
    const inputFechaFinal = $('<input>', {
        type: 'date',
        class: 'form-control form-control-sm',
        name: 'EmpleadoCargo.EmpleadoCargoFechaFinal'
    });
    const celdaSalario = $('<td>');
    const inputSalario = $('<input>', {
        type: 'number',
        class: 'form-control form-control-sm',
        name: 'EmpleadoCargo.EmpleadoCargoFechaFinal'
    });
    const celdaObservacion = $('<td>');
    const inputObservacion = $('<input>', {
        type: 'text',
        class: 'form-control form-control-sm',
        name: 'EmpleadoCargo.EmpleadoCargoObs'
    });
    const celdaInputCargoActivo = $('<td>');
    const divFormCheck = $('<div>', {
        class: 'form-check'
    });
    const inputCargoActivo = $('<input>', {
        type: 'radio',
        class: 'form-check-input',
        name: 'EmpleadoCargo.EmpleadoCargoActivo',
        value: ''
    });

    celdaAccionesCargo.append(buttonEliminarCargo);
    celdaCargo.append(inputCargoId);
    celdaModalidad.append(inputModalidadId);
    celdaFechaInicio.append(inputFechaInicio);
    celdaFechaFinal.append(inputFechaFinal);
    celdaSalario.append(inputSalario);
    celdaObservacion.append(inputObservacion);
    celdaInputCargoActivo.append(divFormCheck.append(inputCargoActivo));

    const nuevaFilaCargo = $('<tr>').append(celdaAccionesCargo, celdaCargo, celdaModalidad, celdaFechaInicio, celdaFechaFinal, celdaSalario, celdaObservacion, celdaInputCargoActivo);

    $('#data-table-body-cargo').append(nuevaFilaCargo);
});

$(document).on("change", "input[type=\"radio\"]", function () {
    $('input[type="radio"]:checked').val('true');
    // Establece el valor del botón de radio seleccionado en "true"
    $('input[type="radio"]:not(:checked)').val('false');
});

$(document).on("click", "#btn-eliminar-fila", function () {
    $(this).closest("tr").remove();
});

