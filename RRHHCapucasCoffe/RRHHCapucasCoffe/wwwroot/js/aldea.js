var accordionButtonAldea = document.getElementById("accordion-button-aldea");
var accordionBody = document.getElementById("flush-collapseOne");

//Input MunicipioNombre
var aldeaNombreInput = document.getElementsByName("AldeaNombre")[0];

var aldeaValidationRow = document.getElementById("validation-row");

function addPaisDeptoMpio() {
    const selectPais = document.getElementById("select-pais");
    const selectDepto = document.getElementById("select-depto");
    const selectMpio = document.getElementById("select-mpio")
    const dataTableBody = document.getElementById("data-table-body");
    var foundDuplicate = false;

    if (selectPais.selectedIndex == '') {
        errorPais('Seleccione una opción válida.');
        errorSummary('');
        return;
    }

    if (selectDepto.selectedIndex == '') {
        errorDepartamento('Seleccione una opción válida.');
        errorSummary('');
        errorPais('');
        return;
    }

    if (selectMpio.selectedIndex == '') {
        errorMunicipio('Seleccione una opción válida.');
        errorSummary('');
        errorPais('');
        errorDepartamento("");
        return;
    }

    errorPais('');
    errorDepartamento('');
    errorMunicipio("");
    errorDepartamentoTable('');
    errorPaisTable('');

    //Funcion para evitar que se ingresen valores duplicados a la tabla
    $('#data-table-body tr').each(function () {
        var paisIdValue = $(this).find('input[name="PaisId"]').val();
        var deptoIdValue = $(this).find('input[name="DepartamentoId"]').val();
        var mpioIdValue = $(this).find('input[name="MunicipioId"]').val();

        if (paisIdValue == selectPais.value && deptoIdValue == selectDepto.value && mpioIdValue == selectMpio.value) {
            errorMunicipio("Ya existe el Municipio.");
            foundDuplicate = true;
            return false;
        }
    })

    if (foundDuplicate) {
        return;
    }
    errorSummary('');
    aldeaValidationRow.classList.add("visually-hidden")

    const nuevaFila = document.createElement("tr");
    const celdaAcciones = document.createElement("td");
    const celdaPais = document.createElement("td");
    const celdaDepto = document.createElement("td");
    const celdaMpio = document.createElement("td");
    const botonEliminar = document.createElement("button");
    const selectPaisHidden = document.createElement("input");
    const selectDeptoHidden = document.createElement("input");
    const selectMpioHidden = document.createElement("input");

    botonEliminar.classList.add("btn", "btn-outline-danger", "btn-sm", "bi", "bi-trash");
    botonEliminar.addEventListener("click", function () {
        dataTableBody.removeChild(nuevaFila);
    });

    // input para almacenar el Id respectivos
    selectPaisHidden.type = "hidden";
    selectPaisHidden.name = "PaisId";
    selectPaisHidden.value = selectPais.value;

    selectDeptoHidden.type = "hidden";
    selectDeptoHidden.name = "DepartamentoId";
    selectDeptoHidden.value = selectDepto.value;

    selectMpioHidden.type = "hidden";
    selectMpioHidden.name = "MunicipioId";
    selectMpioHidden.value = selectMpio.value;

    celdaAcciones.appendChild(botonEliminar);
    celdaPais.textContent = selectPais.options[selectPais.selectedIndex].text;
    celdaDepto.textContent = selectDepto.options[selectDepto.selectedIndex].text;
    celdaMpio.textContent = selectMpio.options[selectMpio.selectedIndex].text;

    nuevaFila.appendChild(celdaAcciones);
    nuevaFila.appendChild(celdaPais);
    nuevaFila.appendChild(celdaDepto);
    nuevaFila.appendChild(celdaMpio);
    nuevaFila.appendChild(selectPaisHidden);
    nuevaFila.appendChild(selectDeptoHidden);
    nuevaFila.appendChild(selectMpioHidden);

    dataTableBody.appendChild(nuevaFila);
}

function validateFormAldea() {
    var paisIdInputsAldea = document.getElementsByName("PaisId");
    var deptoIdInputsAldea = document.getElementsByName("DepartamentoId");
    var mpioIdInputsAldea = document.getElementsByName("MunicipioId");
    var errorAldea = true;

    errorPaisTable("");
    errorDepartamentoTable("");
    errorMunicipioTable("");
    errorAldeaNombre("");

    if (paisIdInputsAldea.length == 0) {
        errorPaisTable("El campo País es requerido.")
        accordionButtonAldea.classList.remove("collapsed");
        accordionButtonAldea.setAttribute("aria-expanded", "true");
        accordionBody.classList.add("show");
        aldeaValidationRow.classList.remove("visually-hidden")
        errorAldea = false;
    }

    if (deptoIdInputsAldea.length == 0) {
        errorDepartamentoTable("El campo Departamento es requerido");
        accordionButtonAldea.classList.remove("collapsed");
        accordionButtonAldea.setAttribute("aria-expanded", "true");
        accordionBody.classList.add("show");
        aldeaValidationRow.classList.remove("visually-hidden")
        errorAldea = false;
    }

    if (mpioIdInputsAldea.length == 0) {
        errorMunicipioTable("El campo Municipio es requerido");
        accordionButtonAldea.classList.remove("collapsed");
        accordionButtonAldea.setAttribute("aria-expanded", "true");
        accordionBody.classList.add("show");
        aldeaValidationRow.classList.remove("visually-hidden")
        errorAldea = false;
    }

    if (aldeaNombreInput.value[0] !== aldeaNombreInput.value[0].toUpperCase() && aldeaNombreInput.value !== "") {
        errorAldeaNombre("La primera letra debe ser mayuscula.");
        errorAldea = false;
    }

    if (aldeaNombreInput.value == aldeaNombreInput.value.toUpperCase() && aldeaNombreInput.value !== "") {
        errorAldeaNombre("No todas las letras pueden ser mayusculas");
        errorAldea = false;
    }

    if (!errorAldea) {
        return false;
    } else {
        return true;
    }
}

function eliminarFilaExistenteAldea(botonEliminar) {
    var fila = botonEliminar.closest('tr'); // Obtener la fila padre del botón
    // Eliminar la fila de la tabla
    fila.remove();
}

aldeaNombreInput.addEventListener("input", function () {
    if (aldeaNombreInput.value === "") {
        errorAldeaNombre("");
    }
});

