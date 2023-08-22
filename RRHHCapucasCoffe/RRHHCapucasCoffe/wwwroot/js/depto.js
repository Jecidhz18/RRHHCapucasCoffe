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
            errorSummary("Ya existe el país");
            foundDuplicateDt = true;
            return false;
        }
    })

    if (foundDuplicateDt) {
        return;
    }
    errorSummary('');

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
//$("form").submit(async function (event) {
//    event.preventDefault(); // Prevenir el envío predeterminado

//    const url = '/Departamentos/CrearDepartamento';
///*    const formData = new FormData$(this); *//*// Obtener datos del formulario*/*/

//    const formData = {
//        DepartamentoNombre: $('#DepartamentoNombre').val(),
//        DepartamentoActivo: $('#DepartamentoActivo').val()
//    }

//    const respuesta = await fetch(url, {
//        method: 'POST',
//        body: formData,
//        headers: {
//            'Content-Type': 'application/json'
//        }
//    });

//    if (respuesta.ok) {
//        console.log("Exitoso");
//    } else {
//        console.log("fallido");
//    }
//});