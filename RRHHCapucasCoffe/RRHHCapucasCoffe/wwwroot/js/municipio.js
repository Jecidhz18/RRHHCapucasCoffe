var accordionButtonMpio = document.getElementById("accordion-button-mpio");
var accordionBody = document.getElementById("flush-collapseOne");

//Input MunicipioNombre
var municipioNombreInput = document.getElementsByName("MunicipioNombre")[0];

var municipioValidationRow = document.getElementById("validation-row");

// Función para agregar una fila a la tabla
function addPaisDepto() {
    const selectPais = document.getElementById("select-pais");
    const selectDepto = document.getElementById("select-depto");
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
    errorPais('');
    errorDepartamento('');
    errorDepartamentoTable('');
    errorPaisTable('');

    //Funcion para evitar que se ingresen valores duplicados a la tabla
    $('#data-table-body tr').each(function () {
        var paisIdValue = $(this).find('input[name="PaisId"]').val();
        var deptoIdValue = $(this).find('input[name="DepartamentoId"]').val();

        if (paisIdValue == selectPais.value && deptoIdValue == selectDepto.value) {
            errorDepartamento("Ya existe el departamento.");
            foundDuplicate = true;
            return false;
        }
    })

    if (foundDuplicate) {
        return;
    }
    errorSummary('');
    municipioValidationRow.classList.add("visually-hidden")

    const nuevaFila = document.createElement("tr");
    const celdaAcciones = document.createElement("td");
    const celdaPais = document.createElement("td");
    const celdaDepto = document.createElement("td");
    const botonEliminar = document.createElement("button");
    const selectPaisHidden = document.createElement("input");
    const selectDeptoHidden = document.createElement("input");

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

    celdaAcciones.appendChild(botonEliminar);
    celdaPais.textContent = selectPais.options[selectPais.selectedIndex].text;
    celdaDepto.textContent = selectDepto.options[selectDepto.selectedIndex].text;

    nuevaFila.appendChild(celdaAcciones);
    nuevaFila.appendChild(celdaPais);
    nuevaFila.appendChild(celdaDepto);
    nuevaFila.appendChild(selectPaisHidden);
    nuevaFila.appendChild(selectDeptoHidden);

    dataTableBody.appendChild(nuevaFila);
}

function eliminarFilaExistenteMpio(botonEliminar) {
    var fila = botonEliminar.closest('tr'); // Obtener la fila padre del botón
    // Eliminar la fila de la tabla
    fila.remove();
}

function validateFormMpio() {
    var paisIdImputsMpio = document.getElementsByName("PaisId");
    var deptoIdImputsMpio = document.getElementsByName("DepartamentoId");
    var errorMunicipio = true;

    errorPaisTable("");
    errorPais("");

    if (paisIdImputsMpio.length == 0) {
        errorPaisTable("El campo País es requerido.")
        accordionButtonMpio.classList.remove("collapsed");
        accordionButtonMpio.setAttribute("aria-expanded", "true");
        accordionBody.classList.add("show");
        municipioValidationRow.classList.remove("visually-hidden")
        errorMunicipio = false;
    }

    if (deptoIdImputsMpio.length == 0) {
        errorDepartamentoTable("El campo Departamento es requerido");
        accordionButtonMpio.classList.remove("collapsed");
        accordionButtonMpio.setAttribute("aria-expanded", "true");
        accordionBody.classList.add("show");
        municipioValidationRow.classList.remove("visually-hidden")
        errorMunicipio = false;
    }

    if (municipioNombreInput.value[0] !== municipioNombreInput.value[0].toUpperCase() && municipioNombreInput.value !== "") {
        errorMunicipioNombre("La primera letra debe ser mayuscula.");
        errorMunicipio = false;
    }

    if (municipioNombreInput.value == municipioNombreInput.value.toUpperCase() && municipioNombreInput.value !== "") {
        errorMunicipioNombre("No todas las letras pueden ser mayusculas");
        errorMunicipio = false;
    }

    if (!errorMunicipio) {
        return false;
    } else {
        return true;
    }
}

municipioNombreInput.addEventListener("input", function () {
    if (municipioNombreInput.value === "") {
        errorMunicipioNombre("");
    }
});