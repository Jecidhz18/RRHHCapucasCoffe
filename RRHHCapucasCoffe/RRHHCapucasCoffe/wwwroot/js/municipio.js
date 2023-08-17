function errorSummary(mensaje) {
    const mensajeError = document.getElementById('validation-summary');
    mensajeError.textContent = mensaje;
}
function errorPais(mensaje) {
    const mensajeError = document.getElementById('validation-pais');
    mensajeError.textContent = mensaje;
}

function errorDepartamento(mensaje) {
    const mensajeError = document.getElementById('validation-departamento');
    mensajeError.textContent = mensaje;
}

const selectPais = document.getElementById("select-pais");
const selectDepto = document.getElementById("select-depto");
const dataTableBody = document.getElementById("data-table-body");

// Función para agregar una fila a la tabla
function addPaisDepto() {
    const selects = $('#data-table-body td');
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

    //Funcion para evitar que se ingresen valores duplicados a la tabla
    $('#data-table-body tr').each(function () {
        var paisIdValue = $(this).find('input[name="PaisId"]').val();
        var deptoIdValue = $(this).find('input[name="DepartamentoId"]').val();

        if (paisIdValue == selectPais.value && deptoIdValue == selectDepto.value) {
            errorSummary("Ya existe el país y el departamento.");
            foundDuplicate = true;
            return false;
        }
    })

    if (foundDuplicate) {
        return;
    }
    errorSummary('');

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


