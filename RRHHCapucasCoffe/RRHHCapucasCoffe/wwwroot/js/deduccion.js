//Obtener el valor seleccionado
var selectElement = document.getElementById("DeduccionTipoCobro");
//Obtener div cobros
var headerCobro = document.getElementById("header-cobro");
var bodyCobro = document.getElementById("body-cobro");
//Obtener Inputs
const cobroDesde = $("#input-desde");
const cobroHasta = $("#input-hasta");
const cobroPorcentaje = $("#input-porcentaje");
const cobroMonto = $("#input-monto");
//obtener elementos accordion
var accordionButtonDeduccion = document.getElementById("accordion-button-deduccion");
var accordionBody = document.getElementById("flush-collapse-deduccion")
//obtener boton agregar cobros
botonAgregarCobro = document.getElementById("btn-agregar-cobro");

if (selectElement != null) {
    // Solo ejecuta la función si selectElement no es nulo
    switchTipoCobroEditar();
}

function expandirAccordion() {
    accordionButtonDeduccion.classList.remove("collapsed");
    accordionButtonDeduccion.ariaExpanded = true;
    accordionBody.classList.add("show");
}

function deduccionFija() {
    botonAgregarCobro.disabled = false;
    cobroHasta.prop('disabled', false);
    cobroDesde.prop('disabled', false);
    cobroPorcentaje.prop('disabled', true);
    cobroMonto.prop('disabled', false);

    expandirAccordion();
}

function deduccionPorRango() {
    botonAgregarCobro.disabled = false;
    cobroHasta.prop('disabled', false);
    cobroDesde.prop('disabled', false);
    cobroPorcentaje.prop('disabled', false);
    cobroMonto.prop('disabled', true);

    expandirAccordion();
}

function deduccionVariable() {
    botonAgregarCobro.disabled = false;
    cobroHasta.prop('disabled', true);
    cobroDesde.prop('disabled', true);
    cobroPorcentaje.prop('disabled', true);
    cobroMonto.prop('disabled', false);

    expandirAccordion();
}

function eliminarElementosCobros() {
    botonAgregarCobro.disabled = true;
    cobroHasta.prop('disabled', true);
    cobroDesde.prop('disabled', true);
    cobroPorcentaje.prop('disabled', true);
    cobroMonto.prop('disabled', true);

    cobroHasta.val("");
    cobroDesde.val("");
    cobroPorcentaje.val("");
    cobroMonto.val("");

    const dataTableBody = document.getElementById("data-table-body-cobro");
    // Elimina todas las filas dentro del tbody
    while (dataTableBody.firstChild) {
        dataTableBody.removeChild(dataTableBody.firstChild);
    }
}

if (selectElement) {
    selectElement.addEventListener("change", function () {
        // Obtiene el valor seleccionado
        var selectedValue = selectElement.value;

        // Luego, puedes ejecutar una función en función del valor seleccionado
        switch (selectedValue) {
            case "1":
                eliminarElementosCobros();
                deduccionFija();
                break;
            case "2":
                eliminarElementosCobros();
                deduccionPorRango();
                break;
            case "3":
                eliminarElementosCobros();
                deduccionVariable();
                break;
            default:
                eliminarElementosCobros();
                break;
        }
    });
}

function switchTipoCobroEditar() {
    var selectedValue = selectElement.value;

    // Luego, puedes ejecutar una función en función del valor seleccionado
    switch (selectedValue) {
        case "1":
            deduccionFija();
            $('[name="DeduccionCobroPorcentaje"]').attr('hidden', true);
            break;
        case "2":
            deduccionPorRango();
            $('[name="DeduccionCobroMonto"]').attr('hidden', true);
            break;
        case "3":
            deduccionVariable();
            $('[name="DeduccionCobroDesde"]').attr('hidden', true);
            $('[name="DeduccionCobroHasta"]').attr('hidden', true);
            $('[name="DeduccionCobroPorcentaje"]').attr('hidden', true);
            break;
        default:
            eliminarElementosCobros();
            break;
    }
}

$('#btn-agregar-cobro').click(function () {
    const celdaAccionesCobro = $('<td>');
    const buttonEliminarCobro = $('<button>', {
        type: 'button',
        class: 'btn btn-outline-danger btn-sm bi bi-trash',
        id: 'btn-eliminar-fila'
    });

    const celdaCobroDesde = $('<td>', {
        text: cobroDesde.val()
    });
    const inputCobroDesde = $('<input>', {
        type: 'hidden',
        name: 'DeduccionCobroDesde',
        value: cobroDesde.val().replace(/,/g, "")
    });

    const celdaCobroHasta = $('<td>', {
        text: cobroHasta.val()
    });
    const inputCobroHasta = $('<input>', {
        type: 'hidden',
        name: 'DeduccionCobroHasta',
        value: cobroHasta.val().replace(/,/g, "")
    });

    const celdaCobroPorcentaje = $('<td>', {
        text: cobroPorcentaje.val()
    });
    const inputCobroPorcentaje = $('<input>', {
        type: 'hidden',
        name: 'DeduccionCobroPorcentaje',
        value: cobroPorcentaje.val().trim().replace(/\s+/g, '').replace(/%/g, "")
    });

    const celdaCobroMonto = $('<td>', {
        text: cobroMonto.val()
    });
    const inputCobroMonto = $('<input>', {
        type: 'hidden',
        name: 'DeduccionCobroMonto',
        value: cobroMonto.val().replace(/,/g, "")
    });

    celdaAccionesCobro.append(buttonEliminarCobro);
    celdaCobroDesde.append(inputCobroDesde);
    celdaCobroHasta.append(inputCobroHasta);
    celdaCobroPorcentaje.append(inputCobroPorcentaje);
    celdaCobroMonto.append(inputCobroMonto);

    const nuevaFilaCobro = $('<tr>').append(celdaAccionesCobro, celdaCobroDesde, celdaCobroHasta, celdaCobroPorcentaje, celdaCobroMonto);

    $("#data-table-body-cobro").append(nuevaFilaCobro);

    cobroDesde.val("");
    cobroHasta.val("");
    cobroPorcentaje.val("");
    cobroMonto.val("");
});

$('#crear-deduccion').submit(async function (e) {
    e.preventDefault();

    const deduccion = await obtenerDataDeduccion();

    await crearDeduccion(deduccion);
});

$('#editar-deduccion').submit(async function (e) {
    e.preventDefault();

    const deduccion = await obtenerDataDeduccion();

    await editarDeduccion(deduccion);
});

$('[name="btn-modal-eliminar-deduccion"]').on('click', async function () {
    var deduccionId = $(this).data('deduccionid');
    await obtenerDeduccionPorId(deduccionId);
    //$('#modal-eliminar-deduccion').modal('show');
});

$('#btn-eliminar-deduccion').on('click', async function () {
    const deduccionId = $('[name="delDeduccionId"]').val();

    const result = await Swal.fire({
        title: '¿Estas seguro de eliminar este registro?',
        text: "¡No podrás revertir esto!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#dc3545',
        cancelButtonColor: '#5e656c',
        confirmButtonText: 'Si, Eliminar registro!',
        cancelButtonText: 'Cancelar'
    });

    if (result.isConfirmed) {
        await eliminarDeduccion(deduccionId);
    }
});

async function obtenerDataDeduccion() {
    var deduccionCobros = []

    $('#data-table-body-cobro tr').each(function () {
        var fila = $(this);
        var cobro = {
            DeduccionCobroId: fila.find("td input[name='DeduccionCobroId']").val(),
            DeduccionCobroDesde: fila.find("td input[name='DeduccionCobroDesde']").val().replace(/,/g, "") || null,
            DeduccionCobroHasta: fila.find("td input[name='DeduccionCobroHasta']").val().replace(/,/g, "") || null,
            DeduccionCobroPorcentaje: fila.find("td input[name='DeduccionCobroPorcentaje']").val().trim().replace(/\s+/g, '').replace(/%/g, "") || null,
            DeduccionCobroMonto: fila.find("td input[name='DeduccionCobroMonto']").val().replace(/,/g, "") || null
        }

        deduccionCobros.push(cobro);
    });

    var DeduccionData = {
        DeduccionId: $("[name='DeduccionId']").val(),
        DeduccionDescripcion: $("[name='DeduccionDescripcion']").val(),
        DeduccionActiva: $("[name='DeduccionActiva']").is(":checked"),
        DeduccionAplicacion: $("[name='DeduccionAplicacion']").val() || null,
        DeduccionTipoCobro: $("[name='DeduccionTipoCobro']").val() || null,
        DeduccionCobros: deduccionCobros
    }

    return DeduccionData;
}

async function obtenerDeduccionPorId(deduccionId) {
    const result = await fetch(urlGetDeduccionPorId, {
        method: 'POST',
        body: JSON.stringify(deduccionId),
        headers: {
            'Content-Type': 'application/json'
        }
    });

    if (result.ok) {
        const json = await result.json();
        $('[name="delDeduccionId"]').val(json.deduccionId);
        $('[name="delDeduccionDescripcion"]').text(json.deduccionDescripcion);
        $('[name="delDeduccionAplicacion"]').text(json.dAplicacion);
        $('[name="delDeduccionTipoCobro"]').text(json.dTipoCobro);

        $('#modal-eliminar-deduccion').modal('show');
    } else {
        console.error("Error al editar la deduccion");
        const reponseText = await result.text();
        console.error(reponseText);
    }
}


async function crearDeduccion(deduccion) {
    const result = await fetch(urlCrearDeduccion, {
        method: 'POST',
        body: JSON.stringify(deduccion),
        headers: {
            'Content-Type': 'application/json'
        }
    });

    if (result.ok) {
        window.location.href = "/Deducciones/Deduccion";
    } else {
        console.error("Error al crear la deduccion")
    }
}

async function editarDeduccion(deduccion) {
    const result = await fetch(urlEditarDeduccion, {
        method: 'POST',
        body: JSON.stringify(deduccion),
        headers: {
            'Content-Type': 'application/json'
        }
    });

    if (result.ok) {
        window.location.href = "/Deducciones/Deduccion";
    } else {
        console.error("Error al editar la deduccion");
        const reponseText = await result.text();
        console.error(reponseText);
    }
}

async function eliminarDeduccion(deduccionId) {
    const result = await fetch(urlDeleteDeduccion, {
        method: 'POST',
        body: deduccionId,
        headers: {
            'Content-Type': 'application/json'
        }
    });

    if (result.ok) {
        $('#modal-eliminar-deduccion').modal('hide');
        Swal.fire({
            text: 'Registro eliminado con exito!',
            icon: 'success',
        }).then((result) => {
            if (result.isConfirmed) {
                setTimeout(() => {
                    location.reload();
                }, 320);
            } else {
                setTimeout(() => {
                    location.reload();
                }, 320);
            }
        })
    }
}






