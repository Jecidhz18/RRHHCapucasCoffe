// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(function () {
    "use strict";

    /**
   * Easy selector helper function
   */
    const select = (el, all = false) => {
        el = el.trim()
        if (all) {
            return [...document.querySelectorAll(el)]
        } else {
            return document.querySelector(el)
        }
    }

    /**
     * Easy event listener function
     */
    const on = (type, el, listener, all = false) => {
        if (all) {
            select(el, all).forEach(e => e.addEventListener(type, listener))
        } else {
            select(el, all).addEventListener(type, listener)
        }
    }

    /**
     * Easy on scroll event listener 
     */
    const onscroll = (el, listener) => {
        el.addEventListener('scroll', listener)
    }

    /**
   * Sidebar toggle
   */
    if (select('.toggle-sidebar-btn')) {
        on('click', '.toggle-sidebar-btn', function (e) {
            select('body').classList.toggle('toggle-sidebar')
        })
    }

    /**
    * Initiate Datatables
    */
    const datatables = select('.datatable', true)
    datatables.forEach(datatable => {
        new simpleDatatables.DataTable(datatable);
    })

})();



function agregarFila() {
    var tablaBody = document.getElementById("data-table-body");
    var nuevaFila = document.createElement("tr");

    var columnaAcciones = document.createElement("td");
    var botonEliminar = document.createElement("button");
    botonEliminar.classList.add("bi", "bi-trash", "btn", "btn-outline-danger");
    botonEliminar.addEventListener("click", function () {
        eliminarFila(this);
    });
    columnaAcciones.appendChild(botonEliminar);
    nuevaFila.appendChild(columnaAcciones);

    var columnaPais = document.createElement("td");
    var select = document.createElement("select");
    select.name = "Paises";
    select.classList.add("form-select");
    select.setAttribute("aria-label", "Default select example");

    var opciones = document.getElementById("listselect").options;
    for (var i = 0; i < opciones.length; i++) {
        var opcion = opciones[i];
        var nuevaOpcion = document.createElement("option");
        nuevaOpcion.value = opcion.value;
        nuevaOpcion.textContent = opcion.textContent;
        select.appendChild(nuevaOpcion);
    }

    columnaPais.appendChild(select);
    nuevaFila.appendChild(columnaPais);

    tablaBody.appendChild(nuevaFila);

    validarSelectsUnicos();
}

function eliminarFila(botonEliminar) {
    var fila = botonEliminar.parentNode.parentNode;
    fila.remove();

    validarSelectsUnicos();
}


//function validarSelectsUnicos() {
//    var selects = document.getElementsByTagName("select");
//    var opcionesSeleccionadas = [];
//    var errorList = document.getElementById("errorList");
//    errorList.innerHTML = ""; // Limpiar la lista de errores

//    for (var i = 0; i < selects.length; i++) {
//        var select = selects[i];
//        var opcionSeleccionada = select.value;

//        if (opcionesSeleccionadas.includes(opcionSeleccionada)) {
//            var mensajeError = document.createElement("li");
//            mensajeError.textContent = "No se pueden seleccionar opciones repetidas.";
//            errorList.appendChild(mensajeError);
//            return false; // Devolver false para detener el envío del formulario
//        }

//        opcionesSeleccionadas.push(opcionSeleccionada);
//    }

//    return true; // Devolver true para permitir el envío del formulario
//}