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
    // Encuentra la fila que deseas clonar (en este caso, la primera fila de la tabla)
    const filaOriginal = document.querySelector('.tr-clone');

    // Verifica si hay una fila previa y si tiene una opción seleccionada
    const filasPrevias = document.querySelectorAll('#data-table-body tr');
    if (filasPrevias.length > 0) {
        const ultimaFilaPrevia = filasPrevias[filasPrevias.length - 1];
        const selectPrevia = ultimaFilaPrevia.querySelector('#listselect');
        if (selectPrevia.value === '') {
            mostrarMensajeError('Por favor, seleccione una opción en la fila anterior antes de agregar una nueva fila.');
            return;
        }
    }

    // Crea una nueva fila a partir de la fila original
    const nuevaFila = filaOriginal.cloneNode(true);

    // Borra cualquier valor seleccionado en el select de la nueva fila
    nuevaFila.querySelector('#listselect').value = '';

    // Agrega el botón para eliminar la fila
    const botonEliminar = document.createElement('button');
    botonEliminar.classList.add('btn', 'btn-outline-danger', 'bi', 'bi-trash');
    botonEliminar.onclick = function () {
        eliminarFila(this);
    };
    nuevaFila.querySelector('td:first-child').appendChild(botonEliminar);

    //Elimina una clase específica de los elementos select en la nueva fila
    const selectsEnNuevaFila = nuevaFila.querySelectorAll('select');
    selectsEnNuevaFila.forEach((select) => {
        select.classList.remove('no-valid');
    });

    // Agrega la nueva fila al final de la tabla
    document.querySelector('#data-table-body').appendChild(nuevaFila);
}

function eliminarFila(boton) {
    // Encuentra el elemento <tr> padre del botón que se hizo clic (la fila a eliminar)
    const filaAEliminar = boton.closest('tr');

    // Elimina la fila del DOM
    filaAEliminar.remove();
}