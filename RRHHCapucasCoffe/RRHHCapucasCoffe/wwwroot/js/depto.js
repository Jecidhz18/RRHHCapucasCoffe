//accordion
var accordionButton = document.getElementById("accordion-button");
var accordionBody = document.getElementById("flush-collapseOne");

//Input DepartamentoNombre
var departamentoNombreInput = document.getElementsByName("DepartamentoNombre")[0];

var deptoValidationRow = document.getElementById("validation-row");

function addPaisDt() {
    const selectPaisDt = document.getElementById("select-pais-dt");
    const dataTableBodyDt = document.getElementById("data-table-body-dt");
    //Variables necesarias para validar no duplicados
    var foundDuplicateDt = false;

    if (selectPaisDt.selectedIndex == '') {
        errorPais('Seleccione una opción válida.');
        errorSummary('');
        return;
    }
    errorPais('');

    //Funcion para evitar que se ingresen valores duplicados a la tabla
    $('#data-table-body-dt tr').each(function () {
        var paisIdValueDt = $(this).find('input[name="PaisId"]').val();

        if (paisIdValueDt == selectPaisDt.value) {
            errorPais("Ya existe el país");
            foundDuplicateDt = true;
            return false;
        }
    })

    if (foundDuplicateDt) {
        return;
    }
    errorSummary('');
    errorPaisTable("");
    deptoValidationRow.classList.add("visually-hidden")

    const nuevaFilaDt = document.createElement("tr");
    const celdaAccionesDt = document.createElement("td");
    const celdaPaisDt = document.createElement("td");
    const botonEliminarDt = document.createElement("button");
    const selectPaisHiddenDt = document.createElement("input");

    botonEliminarDt.classList.add("btn", "btn-outline-danger", "btn-sm", "bi", "bi-trash");

    botonEliminarDt.addEventListener("click", function () {
        dataTableBodyDt.removeChild(nuevaFilaDt);
    });

    // input para almacenar el Id respectivos
    selectPaisHiddenDt.type = "hidden";
    selectPaisHiddenDt.name = "PaisId";
    selectPaisHiddenDt.value = selectPaisDt.value;

    celdaAccionesDt.appendChild(botonEliminarDt);
    celdaPaisDt.textContent = selectPaisDt.options[selectPaisDt.selectedIndex].text;

    nuevaFilaDt.appendChild(celdaAccionesDt);
    nuevaFilaDt.appendChild(celdaPaisDt);
    nuevaFilaDt.appendChild(selectPaisHiddenDt);

    dataTableBodyDt.appendChild(nuevaFilaDt);
}

function eliminarFilaExistentesDt(botonEliminar) {
    var fila = botonEliminar.closest('tr'); // Obtener la fila padre del botón
    // Eliminar la fila de la tabla
    fila.remove();
}

function validarFormularioDt() {
    var paisIdInputs = document.getElementsByName("PaisId");
    var errorsDepto = true;

    errorPaisTable("");
    errorDepartamentoInput("");
    errorPais("");

    if (paisIdInputs.length == 0) {
        errorPaisTable("El campo País es requerido.");
        accordionButton.classList.remove("collapsed")
        accordionButton.setAttribute("aria-expanded", "true");
        accordionBody.classList.add("show");
        deptoValidationRow.classList.remove("visually-hidden")
        errorsDepto = false;
    }

    if (departamentoNombreInput.value == departamentoNombreInput.value.toUpperCase() && departamentoNombreInput.value !== "") {
        errorDepartamentoInput("No todas las letras pueden ser mayusculas.");
        errorsDepto = false;
    }

    if (departamentoNombreInput.value[0] !== departamentoNombreInput.value[0].toUpperCase() && departamentoNombreInput.value !== "") {
        errorDepartamentoInput("La primera letra debe ser mayuscula.")
        errorsDepto = false;
    }

    if (!errorsDepto) {
        return false;
    } else {
        return true;
    }
}

departamentoNombreInput.addEventListener("input", function () {
    if (departamentoNombreInput.value === "") {
        errorDepartamentoInput("");
    }
});