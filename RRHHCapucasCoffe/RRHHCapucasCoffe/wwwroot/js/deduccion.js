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

function expandirAccordion() {
    accordionButtonDeduccion.classList.remove("collapsed");
    accordionButtonDeduccion.ariaExpanded = true;
    accordionBody.classList.add("show");
}

function deduccionFija() {
    eliminarElementosCobros();

    botonAgregarCobro.disabled = false;
    cobroHasta.prop('disabled', false);
    cobroDesde.prop('disabled', false);
    cobroPorcentaje.prop('disabled', true);
    cobroMonto.prop('disabled', false);

    expandirAccordion();
}

function deduccionPorRango() {
    eliminarElementosCobros();

    botonAgregarCobro.disabled = false;
    cobroHasta.prop('disabled', false);
    cobroDesde.prop('disabled', false);
    cobroPorcentaje.prop('disabled', false);
    cobroMonto.prop('disabled', true);

    expandirAccordion();
}

function deduccionVariable() {
    eliminarElementosCobros();

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

selectElement.addEventListener("change", function () {
    // Obtiene el valor seleccionado
    var selectedValue = selectElement.value;

    // Luego, puedes ejecutar una función en función del valor seleccionado
    switch (selectedValue) {
        case "1":
            deduccionFija();
            break;
        case "2":
            deduccionPorRango();
            break;
        case "3":
            deduccionVariable();
            break;
        default:
            eliminarElementosCobros();
            break;
    }
});

$('#btn-agregar-cobro').click(function () {
    const celdaAccionesCobro = $('<td>');
    const buttonEliminarCobro = $('<button>', {
        type: 'button',
        class: 'btn btn-outline-danger btn-sm bi bi-trash',
        id: 'btn-eliminar-fila'
    });

    const celdaCobroDesde = $('<td>', {
        text: "L " + cobroDesde.val()
    });
    const inputCobroDesde = $('<input>', {
        type: 'hidden',
        name: 'DeduccionCobroDesde',
        value: cobroDesde.val().replace(/,/g, "")
    });

    const celdaCobroHasta = $('<td>', {
        text: "L " + cobroHasta.val()
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
        text: "L " + cobroMonto.val()
    });
    const inputCobroMonto = $('<input>', {
        type: 'hidden',
        name: 'DeduccionCobroMonto',
        value: cobroMonto.val().replace(/,/, "")
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

async function obtenerDataDeduccion() {
    var deduccionCobros = []

    $('#data-table-body-cobro tr').each(function () {
        var fila = $(this);
        var cobro = {
            DeduccionCobroId: fila.find("td input[name='DeduccionCobroId']").val(),
            DeduccionCobroDesde: fila.find("td input[name='DeduccionCobroDesde']").val() || null,
            DeduccionCobroHasta: fila.find("td input[name='DeduccionCobroHasta']").val() || null,
            DeduccionCobroPorcentaje: fila.find("td input[name='DeduccionCobroPorcentaje']").val() || null,
            DeduccionCobroMonto: fila.find("td input[name='DeduccionCobroMonto']").val() || null
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

