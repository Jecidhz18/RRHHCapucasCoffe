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
        var croppedImageBase64WithoutPrefix = croppedImageBase64.slice(23);
        $('#imagen-recortada').val(croppedImageBase64WithoutPrefix);
        var previewImage = document.getElementById('imagen-previa');
        previewImage.src = canvas.toDataURL(); // Actualiza la imagen previa

        image.removeAttribute('src'); // Elimina el atributo 'src' de la imagen
        cropper.destroy();

        $('#img-input').val("");

        modal.hide(); // Cierra el modal
    });

    $('#crop-cancel').click(function () {
        image.removeAttribute('src'); // Elimina el atributo 'src' de la imagen
        cropper.destroy();
        $('#img-input').val("");
    });
});
$('#btn-delete-photo').click(function () {
    $('#imagen-previa').attr('src', '');
    // Establece la nueva imagen desde la carpeta 'img/'
    var nuevaImagenSrc = '/img/ImgUpload.png'; // Reemplaza 'tu-nueva-imagen.jpg' con el nombre de tu nueva imagen
    $('#imagen-previa').attr('src', nuevaImagenSrc);
    $('#imagen-recortada').val("");
});
$('[name="EmpleadoFechaNacimiento"]').change(function () {
    var empleadoFechaNac = new Date($('[name="EmpleadoFechaNacimiento"]').val());
    var fechaActual = new Date();
    var diferencia = fechaActual - empleadoFechaNac;
    var edad = Math.floor(diferencia / (1000 * 60 * 60 * 24 * 365.25));
    $('[name="EmpleadoEdad"]').val(edad);
});


function validarAgregarBanco(selectBanco, newEmpleadoBancoNoCuenta) {
    var errorAgregarBanco = true;
    if (selectBanco.val() == "") {
        errorBancoSelect("Seleccione una opción válida.");
        errorAgregarBanco = false;
    }
    if (newEmpleadoBancoNoCuenta.val() == "") {
        errorInputBancoNoCuenta("Campo requerido.");
        errorAgregarBanco = false;
        
    }
    $("#data-table-body-bank tr").each(function () {
        var bancoId = $(this).find("td input[name='BancoId']").val();
        var empleadoBancoNoCuenta = $(this).find("td input[name='EmpleadoBancoNoCuenta']").val();

        if (bancoId == selectBanco.val() && empleadoBancoNoCuenta == newEmpleadoBancoNoCuenta.val()) {
            errorInputBancoNoCuenta("Ya existe el número de cuenta.");

            errorAgregarBanco = false;
            return false;
        }
    });
    return errorAgregarBanco 
}

$('#btn-agregar-banco').click(function () {
    const selectBanco = $('#select-banco');
    const empleadoBancoNoCuenta = $("#empleado-banco-no-cuenta");

    errorBancoSelect("");
    errorInputBancoNoCuenta("");

    if (!validarAgregarBanco(selectBanco, empleadoBancoNoCuenta)) {
        return;
    }

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

    const celdaInputNoCuenta = $('<td>', {
        text: empleadoBancoNoCuenta.val()
    });
    const inputNoCuenta = $('<input>', {
        type: 'hidden',
        name: 'EmpleadoBancoNoCuenta',
        value: empleadoBancoNoCuenta.val()
    });
    const celdaInputBancoActiva = $('<td>');
    const divFormCheck = $('<div>', {
        class: 'form-check'
    });
    const inputBancoActiva = $('<input>', {
        type: 'radio',
        class: 'form-check-input',
        name: 'EmpleadoBancoActiva',
        value: ''
    });

    celdaAccionesBank.append(botonEliminarBank);
    celdaBank.append(inputBancoId);
    celdaInputNoCuenta.append(inputNoCuenta);
    celdaInputBancoActiva.append(divFormCheck.append(inputBancoActiva));

    const nuevaFilaBank = $('<tr>').append(celdaAccionesBank, celdaBank, celdaInputNoCuenta, celdaInputBancoActiva);

    $('#data-table-body-bank').append(nuevaFilaBank);

    selectBanco.val("");
    empleadoBancoNoCuenta.val("");
});

function validarAgregarColegiacion(newSelectColegio, newEmpleadoColegioAnio, newEmpleadoColegioCuota) {
    var errorAgregarColegiacion = true;
    if (newSelectColegio.val() == "") {
        errorColegioSelect("Seleccione una opción válida.");
        errorAgregarColegiacion = false;
    }
    if (newEmpleadoColegioAnio.val() == "") {
        errorInputColegioAnio("Campo requerido.");
        errorAgregarColegiacion = false;
    }
    if (newEmpleadoColegioCuota.val() == "") {
        errorInputColegioCuota("Campo requerido.");
        errorAgregarColegiacion = false;
    }
    $("#data-table-body-colegio tr").each(function () {
        var colegioProfesionalId = $(this).find("td input[name='ColegioProfesionalId']").val();

        if (colegioProfesionalId == newSelectColegio.val()) {
            errorColegioSelect("Ya existe la colegiación.");

            errorAgregarColegiacion = false;
            return false;
        }
    });
    return errorAgregarColegiacion
}


$('#btn-agregar-colegiacion').click(function () {
    const selectColegio = $('#select-colegio')
    const empleadoColegioAnio = $('#colegiacion-anio');
    const empleadoColegioCuota = $('#colegiacion-cuota');

    errorColegioSelect("");
    errorInputColegioAnio("");
    errorInputColegioCuota("");

    if (!validarAgregarColegiacion(selectColegio, empleadoColegioAnio, empleadoColegioCuota)) {
        return;
    }

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
        name: 'ColegioProfesionalId',
        value: selectColegio.val()
    });
    const celdaInputColAnio = $('<td>', {
        text: empleadoColegioAnio.val()
    });
    const inputColAnio = $('<input>', {
        type: 'hidden',
        name: 'EmpleadoColegiacionAnio',
        value: empleadoColegioAnio.val()
    });
    const celdaInputColCuota = $('<td>', {
        text: empleadoColegioCuota.val()
    });
    const inputColCuota = $('<input>', {
        type: 'hidden',
        name: 'EmpleadoColegiacionCuota',
        value: empleadoColegioCuota.val()
    });
    const celdaInputColActivo = $('<td>');
    const divFormCheck = $('<div>', {
        class: 'form-check'
    });
    const inputColActivo = $('<input>', {
        type: 'radio',
        class: 'form-check-input',
        name: 'EmpleadoColegiacionActivo',
        value: ''
    });

    celdaAccionesColegio.append(botonEliminasColegio);
    celdaColegio.append(inputColegioId);
    celdaInputColAnio.append(inputColAnio);
    celdaInputColCuota.append(inputColCuota);
    celdaInputColActivo.append(divFormCheck.append(inputColActivo));

    const nuevaFilaColegio = $('<tr>').append(celdaAccionesColegio, celdaColegio, celdaInputColAnio, celdaInputColCuota, celdaInputColActivo);

    $('#data-table-body-colegio').append(nuevaFilaColegio);

    selectColegio.val("");
    empleadoColegioAnio.val("");
    empleadoColegioCuota.val("");
});

function validarAgregarArea(newSelectAgencia, newSelectArea) {
    var errorAgregarArea = true;
    if (newSelectAgencia.val() == "") {
        errorAgenciaSelect("Seleccione una opción válida.");
        errorAgregarArea = false;
    }
    if (newSelectArea.val() == "") {
        errorAreaSelect("Seleccione una opción válida.");
        errorAgregarArea = false;
    }
    $("#data-table-body-area tr").each(function () {
        var agenciaId = $(this).find("td input[name='AgenciaId']").val();
        var areaId = $(this).find("td input[name='UnidadId']").val();

        if (agenciaId == newSelectAgencia.val() && areaId == newSelectArea.val()) {
            errorAreaSelect("Ya existe el area.");

            errorAgregarArea = false;
            return false;
        }
    });
    return errorAgregarArea
}

$('#btn-agregar-area').click(function () {
    const selectAgencia = $('#select-agencia');
    const selectArea = $('#select-area');

    errorAgenciaSelect("");
    errorAreaSelect("");

    if (!validarAgregarArea(selectAgencia, selectArea)) {
        return;
    }


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
        name: 'AgenciaId',
        value: selectAgencia.val()
    })

    const celdaArea = $('<td>', {
        text: selectArea.find(':selected').text()
    });
    const inputArea = $('<input>', {
        type: 'hidden',
        name: 'UnidadId',
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
        name: 'EmpleadoAreaActivo',
        value: ''
    });

    celdaAccionesArea.append(buttonEliminarArea);
    celdaAgencia.append(inputAgencia);
    celdaArea.append(inputArea);
    celdaInputAreaActiva.append(divFormCheck.append(inputAreaActiva));

    const nuevaFilaArea = $('<tr>').append(celdaAccionesArea, celdaAgencia, celdaArea, celdaInputAreaActiva);

    $('#data-table-body-area').append(nuevaFilaArea);

    selectAgencia.val("");
    selectArea.val("");
})

function validarAgregarCargo(newSelectCargo, newSelectModalidad, newEmpleadoCargoFechaInicio, newEmpleadoCargoFechaFinal, newEmpleadoCargoSalario) {
    var errorAgregarCargo = true;
    if (newSelectCargo.val() == "") {
        errorCargoSelect("Seleccione una opción válida.");
        errorAgregarCargo = false;
    }
    if (newSelectModalidad.val() == "") {
        errorModalidadSelect("Seleccione una opción válida.");
        errorAgregarCargo = false;
    }
    if (newEmpleadoCargoFechaInicio.val() == "") {
        errorCargoFechaInicio("Campo requerido.");
        errorAgregarCargo = false;
    }
    if (newEmpleadoCargoFechaFinal.val() == "") {
        errorCargoFechaFinal("Campo requerido.");
        errorAgregarCargo = false;
    }
    if (newEmpleadoCargoSalario.val() == "") {
        errorCargoSalario("Campo requerido.");
        errorAgregarCargo = false;
    }
    $("#data-table-body-cargo tr").each(function () {
        var cargoId = $(this).find("td input[name='CargoId']").val();

        if (cargoId == newSelectCargo.val()) {
            errorCargoSelect("Ya existe el cargo.");
            errorAgregarCargo = false;
            return false;
        }
    });
    return errorAgregarCargo
}

$('#btn-agregar-cargo').click(function () {
    const selectCargo = $('#select-cargo');
    const selectModalidad = $('#select-modalidad');
    const empleadoCargoFechaInicio = $('#cargo-fecha-inicio');
    const empleadoCargoFechaFinal = $('#cargo-fecha-final');
    const empleadoCargoSalario = $('#cargo-salario')

    errorCargoSelect("");
    errorModalidadSelect("");
    errorCargoFechaInicio("");
    errorCargoFechaFinal("");
    errorCargoSalario("");

    if (!validarAgregarCargo(selectCargo, selectModalidad, empleadoCargoFechaInicio, empleadoCargoFechaFinal, empleadoCargoSalario)) {
        return;
    }

    //Formateo de fecha
    const partesFechaInicio = empleadoCargoFechaInicio.val().split('-');
    const formatFechaInicio = `${partesFechaInicio[2]}/${partesFechaInicio[1]}/${partesFechaInicio[0]}`;

    const partesFechaFinal = empleadoCargoFechaFinal.val().split('-');
    const formatFechaFinal = `${partesFechaFinal[2]}/${partesFechaFinal[1]}/${partesFechaFinal[0]}`;


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
        name: 'CargoId',
        value: selectCargo.val()
    });
    const celdaModalidad = $('<td>', {
        text: selectModalidad.find(':selected').text()
    });
    const inputModalidadId = $('<input>', {
        type: 'hidden',
        name: 'ModalidadId',
        value: selectModalidad.val()
    });
    const celdaFechaInicio = $('<td>', {
        text: formatFechaInicio
    });
    const inputFechaInicio = $('<input>', {
        type: 'hidden',
        name: 'EmpleadoCargoFechaInicio',
        value: empleadoCargoFechaInicio.val()
    });
    const celdaFechaFinal = $('<td>', {
        text: formatFechaFinal
    });
    const inputFechaFinal = $('<input>', {
        type: 'hidden',
        name: 'EmpleadoCargoFechaFinal',
        value: empleadoCargoFechaFinal.val()
    });
    const celdaSalario = $('<td>', {
        text: empleadoCargoSalario.val()
    });
    const inputSalario = $('<input>', {
        type: 'hidden',
        name: 'EmpleadoCargoSalario',
        value: empleadoCargoSalario.val()
    });
    const celdaObservacion = $('<td>');
    const inputObservacion = $('<input>', {
        type: 'text',
        class: 'form-control form-control-sm',
        name: 'EmpleadoCargoObs'
    });
    const celdaInputCargoActivo = $('<td>');
    const divFormCheck = $('<div>', {
        class: 'form-check'
    });
    const inputCargoActivo = $('<input>', {
        type: 'radio',
        class: 'form-check-input',
        name: 'EmpleadoCargoActivo',
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

    selectCargo.val("");
    selectModalidad.val("");
    empleadoCargoFechaInicio.val("");
    empleadoCargoFechaFinal.val(""); 
    empleadoCargoSalario.val("");
});

$(document).on("change", "input[type=\"radio\"]", function () {
    $('input[type="radio"]:checked').val('true');
    // Establece el valor del botón de radio seleccionado en "true"
    $('input[type="radio"]:not(:checked)').val('false');
});

$(document).on("click", "#btn-eliminar-fila", function () {
    $(this).closest("tr").remove();
});

$("#crear-empleado").submit(async function (event) {
    event.preventDefault();

    const empleado = await obtenerDataEmpleado();

    await crearEmpleado(empleado);
});

$("#editar-empleado").submit(async function (event) {
    event.preventDefault();

    const empleado = await obtenerDataEmpleado();

    await editarEmpleado(empleado);
});
//Data
async function obtenerDataEmpleado() {
    var empleadoBancos = [];
    var empleadoColegiaciones = [];
    var empleadoAreas = [];
    var empleadoCargos = [];

    $("#data-table-body-bank tr").each(function () {
        var fila = $(this);
        var banco = {
            EmpleadoBancoId: fila.find("td input[name='EmpleadoBancoId']").val(),
            BancoId: fila.find("td input[name='BancoId']").val(),
            EmpleadoBancoNoCuenta: fila.find("td input[name='EmpleadoBancoNoCuenta']").val(),
            EmpleadoBancoActiva: fila.find("td input[name='EmpleadoBancoActiva']").is(":checked")
        };
        empleadoBancos.push(banco);
    });

    $("#data-table-body-colegio tr").each(function () {
        var fila = $(this);
        var colegiacion = {
            EmpleadoColegiacionId: fila.find("td input[name='EmpleadoColegiacionId']").val(),
            ColegioProfesionalId: fila.find("td input[name='ColegioProfesionalId']").val(),
            EmpleadoColegiacionAnio: fila.find("td input[name='EmpleadoColegiacionAnio']").val(),
            EmpleadoColegiacionCuota: fila.find("td input[name='EmpleadoColegiacionCuota']").val(),
            EmpleadoColegiacionActivo: fila.find("td input[name='EmpleadoColegiacionActivo']").is(":checked")
        };
        empleadoColegiaciones.push(colegiacion);
    });

    $("#data-table-body-area tr").each(function () {
        var fila = $(this);
        var area = {
            EmpleadoAreaId: fila.find("td input[name='EmpleadoAreaId']").val(),
            AgenciaId: fila.find("td input[name='AgenciaId']").val(),
            UnidadId: fila.find("td input[name='UnidadId']").val(),
            EmpleadoAreaActivo: fila.find("td input[name='EmpleadoAreaActivo']").is(":checked")
        };
        empleadoAreas.push(area);
    });

    $("#data-table-body-cargo tr").each(function () {
        var fila = $(this);
        var cargo = {
            EmpleadoCargoId: fila.find("td input[name='EmpleadoCargoId']").val(),
            CargoId: fila.find("td input[name='CargoId']").val(),
            ModalidadId: fila.find("td input[name='ModalidadId']").val(),
            EmpleadoCargoFechaInicio: fila.find("td input[name='EmpleadoCargoFechaInicio']").val(),
            EmpleadoCargoFechaFinal: fila.find("td input[name='EmpleadoCargoFechaFinal']").val(),
            EmpleadoCargoSalario: fila.find("td input[name='EmpleadoCargoSalario']").val(),
            EmpleadoCargoObs: fila.find("td input[name='EmpleadoCargoObs']").val(),
            EmpleadoCargoActivo: fila.find("td input[name='EmpleadoCargoActivo']").is(":checked")
        };
        empleadoCargos.push(cargo);
    });

    var EmpleadoData = {
        EmpleadoId: $("[name='EmpleadoId']").val(),
        EmpleadoIdentificacion: $("[name='EmpleadoIdentificacion']").val(),
        EmpleadoNombre: $("[name='EmpleadoNombre']").val(),
        EmpleadoPrimerApellido: $("[name='EmpleadoPrimerApellido']").val(),
        EmpleadoSegundoApellido: $("[name='EmpleadoSegundoApellido']").val(),
        EmpleadoFotografiaBase64: $("[name='EmpleadoFotografiaBase64']").val(),
        EmpleadoSexo: $("[name='EmpleadoSexo']").val() || null,
        EmpleadoFechaNacimiento: $("[name='EmpleadoFechaNacimiento']").val(),
        EmpleadoDirNacimientoId: $("[name='EmpleadoDirNacimientoId']").val(),
        EmpleadoNacPaisId: $("[name='EmpleadoNacPaisId']").val() || null,
        EmpleadoNacDeptoId: $("[name='EmpleadoNacDeptoId']").val() || null,
        EmpleadoNacMpioId: $("[name='EmpleadoNacMpioId']").val() || null,
        EmpleadoNacAldeaId: $("[name='EmpleadoNacAldeaId']").val() || null,
        EmpleadoEdad: $("[name='EmpleadoEdad']").val(),
        EstadoCivilId: $("[name='EstadoCivilId']").val() || null,
        EmpleadoTelefono: $("[name='EmpleadoTelefono']").val(),
        EmpleadoCelular: $("[name='EmpleadoCelular']").val(),
        EmpleadoDireccionId: $("[name='EmpleadoDireccionId']").val(),
        EmpleadoDirPaisId: $("[name='EmpleadoDirPaisId']").val() || null,
        EmpleadoDirDeptoId: $("[name='EmpleadoDirDeptoId']").val() || null,
        EmpleadoDirMpioId: $("[name='EmpleadoDirMpioId']").val() || null,
        EmpleadoDirAldeaId: $("[name='EmpleadoDirAldeaId']").val() || null,
        EmpleadoDireccion: $("[name='EmpleadoDireccion']").val(),
        EmpleadoEmail: $("[name='EmpleadoEmail']").val(),
        ProfesionId: $("[name='ProfesionId']").val() || null,
        EmpleadoFechaIngreso: $("[name='EmpleadoFechaIngreso']").val(),
        EmpleadoFechaContrato: $("[name='EmpleadoFechaContrato']").val(),
        EmpleadoActivo: $("[name='EmpleadoActivo']").is(":checked"),
        Familiar: {
            FamiliarIdentificacion: $("[name='Familiar.FamiliarIdentificacion']").val(),
            FamiliarNombre: $("[name='Familiar.FamiliarNombre']").val(),
            FamiliarPrimerApellido: $("[name='Familiar.FamiliarPrimerApellido']").val(),
            FamiliarSegundoApellido: $("[name='Familiar.FamiliarSegundoApellido']").val(),
            FamiliarParentesco: $("[name='Familiar.FamiliarParentesco']").val() || null,
            FamiliarTelefono: $("[name='Familiar.FamiliarTelefono']").val(),
            FamiliarCelular: $("[name='Familiar.FamiliarCelular']").val()
        },
        EmpleadoBancos: empleadoBancos,
        EmpleadoColegiaciones: empleadoColegiaciones,
        EmpleadoAreas: empleadoAreas,
        EmpleadoCargos: empleadoCargos
    } 
    return EmpleadoData;
}

async function crearEmpleado(empleado) {
    try {
        const result = await fetch(urlCrearEmpleado, {
            method: 'POST',
            body: JSON.stringify(empleado),
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (result.ok) {
            console.log("Empleado creado exitosamente");
            window.location.href = "/Empleados/Empleado";
        } else {
            console.error("Error en la respuesta del servidor:", result.status, result.statusText);
            const responseText = await result.text();
            console.error("Contenido de la respuesta:", responseText);
        }
    } catch (error) {
        console.error("Error en la solicitud:", error);
    }
}

async function editarEmpleado(empleado) {
    try {
        const result = await fetch(urlEditarEmpleado, {
            method: 'POST',
            body: JSON.stringify(empleado),
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (result.ok) {
            console.log("Empleado editado exitosamente");
            window.location.href = "/Empleados/Empleado";
        } else {
            if (result.status === 404) {
                console.log("Empleado no encontrado");
                window.location.href = "/Home/NoEncontrado";
            }
        }
    } catch (error) {
        
    }
}
