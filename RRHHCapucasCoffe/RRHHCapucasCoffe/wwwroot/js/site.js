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
 * Navbar links active state on scroll
 */
    let navbarlinks = select('#navbar .scrollto', true)
    const navbarlinksActive = () => {
        let position = window.scrollY + 200
        navbarlinks.forEach(navbarlink => {
            if (!navbarlink.hash) return
            let section = select(navbarlink.hash)
            if (!section) return
            if (position >= section.offsetTop && position <= (section.offsetTop + section.offsetHeight)) {
                navbarlink.classList.add('active')
            } else {
                navbarlink.classList.remove('active')
            }
        })
    }
    window.addEventListener('load', navbarlinksActive)
    onscroll(document, navbarlinksActive)

    function keepMenuExpanded() {
        const activeLink = document.querySelector('.nav-content a.active');
        if (activeLink) {
            const parentCollapse = activeLink.closest('.collapse');
            if (parentCollapse) {
                const collapseId = parentCollapse.getAttribute('id');
                const collapseInstance = new bootstrap.Collapse(document.getElementById(collapseId));
                collapseInstance.show();
            }
        }
    }

    // Ejecutar la función cuando el DOM esté completamente cargado
    document.addEventListener('DOMContentLoaded', keepMenuExpanded);
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
    select.name = "PaisId";
    select.classList.add("form-select");
    select.setAttribute("asp-items", "@Model.Paises");

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
}

function eliminarFila(botonEliminar) {
    var fila = botonEliminar.parentNode.parentNode;
    fila.remove();
}