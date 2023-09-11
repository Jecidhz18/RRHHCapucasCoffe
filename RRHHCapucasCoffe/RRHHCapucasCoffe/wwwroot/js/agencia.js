var unidadValidationTable = document.getElementById("validation-row");

var accordionButtonUnidad = document.getElementById("accordion-button-unidad");
var accordionBody = document.getElementById("flush-collapse-unidad");
//input AgenciaNombre
var agenciaNombreInput = document.getElementsByName("AgenciaNombre")[0];
function addUnidad() {
    const selectUnidad = document.getElementById("select-unidad");
    const dataTableBody = document.getElementById("data-table-body");
    var errorUnidad = false;

    if (selectUnidad.selectedIndex == '') {
        errorUnidadSelect('Seleccione una opción válida.');
        return;
    }

    errorUnidadSelect('');

    $('#data-table-body tr').each(function () {
        var unidadIdValue = $(this).find('input[name="UnidadId"]').val();

        if (unidadIdValue == selectUnidad.value) {
            errorUnidadSelect("Ya existe la unidad.");
            errorUnidad = true;
            return false;
        }
    });

    if (errorUnidad) {
        return;
    }

    unidadValidationTable.classList.add("visually-hidden");
    //Creacion de elementos
    const nuevaFila = document.createElement("tr");
    const celdaAcciones = document.createElement("td");
    const celdaUnidad = document.createElement("td");
    const botonEliminar = document.createElement("button");
    const unidadInput = document.createElement("input");

    botonEliminar.classList.add("btn", "btn-outline-danger", "btn-sm", "bi", "bi-trash");
    botonEliminar.addEventListener("click", function () {
        dataTableBody.removeChild(nuevaFila);
    });

    //input para almacenar la UnidadId
    unidadInput.type = "hidden";
    unidadInput.name = "UnidadId";
    unidadInput.value = selectUnidad.value;

    celdaAcciones.appendChild(botonEliminar);

    celdaUnidad.textContent = selectUnidad.options[selectUnidad.selectedIndex].text;
    celdaUnidad.appendChild(unidadInput);
    
    nuevaFila.appendChild(celdaAcciones);
    nuevaFila.appendChild(celdaUnidad);

    dataTableBody.appendChild(nuevaFila);
}

function validateFormAgencia() {
    var unidadIdInputs = document.getElementsByName("UnidadId");
    var errorAgencia = true;

    errorUnidadTable("");
    errorAgenciaNombre("");

    if (unidadIdInputs.length == 0) {
        errorUnidadTable("El campo Unidad es requerido")
        accordionButtonUnidad.classList.remove("collapsed");
        accordionButtonUnidad.setAttribute("aria-expanded", "true");
        accordionBody.classList.add("show");
        unidadValidationTable.classList.remove("visually-hidden")
        errorAgencia = false;
    }

    if (agenciaNombreInput.value[0] !== agenciaNombreInput.value[0].toUpperCase() && agenciaNombreInput.value !== "") {
        errorAgenciaNombre("La primera letra debe ser mayuscula");
        errorAgencia = false;
    }

    if (agenciaNombreInput.value == agenciaNombreInput.value.toUpperCase() && agenciaNombreInput.value !== "") {
        errorAgenciaNombre("No todas las letras pueden ser mayusculas");
        errorAgencia = false;
    }

    if (!errorAgencia) {
        return false;
    } else {
        return true;
    }
}

function eliminarFilaExistenteUnidad(botonEliminar) {
    var fila = botonEliminar.closest('tr');
    fila.remove();
}

agenciaNombreInput.addEventListener("input", function () {
    if (agenciaNombreInput.value === "") {
        errorAgenciaNombre("");
    }
})