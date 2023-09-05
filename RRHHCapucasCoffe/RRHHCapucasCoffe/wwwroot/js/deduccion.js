//Obtener el valor seleccionado
var selectElement = document.getElementById("DeduccionTipoCobro");
//Obtener div cobros
var headerCobro = document.getElementById("header-cobro");
var bodyCobro = document.getElementById("body-cobro");
//Obtener Inputs
var inputCobroDesde = document.getElementById("input-desde");
var inputCobroHasta = document.getElementById("input-hasta");
var inputCobroPorcentaje = document.getElementById("input-porcentaje");
var inputCobroMonto = document.getElementById("input-monto");
//obtener elementos accordion
var accordionButtonDeduccion = document.getElementById("accordion-button-deduccion");
var accordionBody = document.getElementById("flush-collapse-deduccion")
//obtener boton agregar cobros
botonAgregarCobro = document.getElementById("btn-agregar");

var i = 0;

function expandirAccordion() {
    accordionButtonDeduccion.classList.remove("collapsed");
    accordionButtonDeduccion.ariaExpanded = true;
    accordionBody.classList.add("show");
}

function deduccionFija() {
    eliminarElementosCobros();

    botonAgregarCobro.disabled = false;
    inputCobroHasta.disabled = false;
    inputCobroDesde.disabled = false;
    inputCobroPorcentaje.disabled = true;
    inputCobroMonto.disabled = false;

    expandirAccordion();

    i = 0;
}

function deduccionPorRango() {
    eliminarElementosCobros();

    botonAgregarCobro.disabled = false;
    inputCobroHasta.disabled = false;
    inputCobroDesde.disabled = false;
    inputCobroPorcentaje.disabled = false;
    inputCobroMonto.disabled = true;

    expandirAccordion();

    i = 0;
}

function deduccionVariable() {
    eliminarElementosCobros();

    botonAgregarCobro.disabled = false;
    inputCobroHasta.disabled = true;
    inputCobroDesde.disabled = true;
    inputCobroPorcentaje.disabled = true;
    inputCobroMonto.disabled = false;

    expandirAccordion();

    i = 0;
}

function eliminarElementosCobros() {
    botonAgregarCobro.disabled = true;
    inputCobroHasta.disabled = true;
    inputCobroDesde.disabled = true;
    inputCobroPorcentaje.disabled = true;
    inputCobroMonto.disabled = true;

    const dataTableBody = document.getElementById("data-table-body");
    // Elimina todas las filas dentro del tbody
    while (dataTableBody.firstChild) {
        dataTableBody.removeChild(dataTableBody.firstChild);
    }

    i = 0;
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

function addCobro() {
    //obtener el body de la tabla
    const dataTableBody = document.getElementById("data-table-body");
    //Crear elementos html
    const nuevaFila = document.createElement("tr");
    const celdaAcciones = document.createElement("td");
    const celdaCobroDesde = document.createElement("td");
    const celdaCobroHasta = document.createElement("td");
    const celdaCobroPorcentaje = document.createElement("td");
    const celdaCobroMonto = document.createElement("td");

    const inputDesdeValue = document.createElement("input");
    inputDesdeValue.type = "hidden";
    inputDesdeValue.setAttribute("name", `DeduccionesCobros[${i}].DeduccionCobroDesde`);
    inputDesdeValue.value = inputCobroDesde.value;

    const inputHastaValue = document.createElement("input");
    inputDesdeValue.type = "hidden";
    inputHastaValue.setAttribute("name", `DeduccionesCobros[${i}].DeduccionCobroHasta`);
    inputHastaValue.value = inputCobroHasta.value;

    const inputPorcentajeValue = document.createElement("input");
    inputDesdeValue.type = "hidden";
    inputPorcentajeValue.setAttribute("name", `DeduccionesCobros[${i}].DeduccionCobroPorcentaje`);
    inputPorcentajeValue.value = inputCobroPorcentaje.value;

    const inputMontoValue = document.createElement("input");
    inputDesdeValue.type = "hidden";
    inputMontoValue.setAttribute("name", `DeduccionesCobros[${i}].DeduccionCobroMonto`);
    inputMontoValue.value = inputCobroMonto.value;

    //Boton eliminar Cobros
    const botonEliminarCobro = document.createElement("button");
    botonEliminarCobro.classList.add("btn", "btn-outline-danger", "btn-sm", "bi", "bi-trash");
    botonEliminarCobro.addEventListener("click", function () {
        dataTableBody.removeChild(nuevaFila);
    });

    celdaAcciones.appendChild(botonEliminarCobro);
    celdaCobroDesde.textContent = inputCobroDesde.value;
    celdaCobroDesde.appendChild(inputDesdeValue);
    celdaCobroHasta.textContent = inputCobroHasta.value;
    celdaCobroHasta.appendChild(inputHastaValue);
    celdaCobroPorcentaje.textContent = inputCobroPorcentaje.value;
    celdaCobroPorcentaje.appendChild(inputPorcentajeValue);
    celdaCobroMonto.textContent = inputCobroMonto.value;
    celdaCobroMonto.appendChild(inputMontoValue);

    nuevaFila.appendChild(celdaAcciones);
    nuevaFila.appendChild(celdaCobroDesde);
    nuevaFila.appendChild(celdaCobroHasta);
    nuevaFila.appendChild(celdaCobroPorcentaje);
    nuevaFila.appendChild(celdaCobroMonto);

    dataTableBody.appendChild(nuevaFila);

    inputCobroDesde.value = "";
    inputCobroHasta.value = "";
    inputCobroMonto.value = "";
    inputCobroPorcentaje.value = "";

    i++;
}






