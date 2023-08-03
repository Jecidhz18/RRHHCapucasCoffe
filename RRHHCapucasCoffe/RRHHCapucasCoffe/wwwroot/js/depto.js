function mostrarMensajeError(mensaje) {
    const mensajeError = document.getElementById('error-message');
    mensajeError.textContent = mensaje;
    mensajeError.style.display = 'block';

}

const form = document.getElementById('formData');
const selects = form.querySelectorAll('select');

form.addEventListener('submit', (event) => {
    event.preventDefault();
    // Obtiene todos los selects en las filas de la tabla
    const selects = $('#data-table-body select');

    // Verifica si hay opciones sin seleccionar en los selects
    for (const select of selects) {
        if (select.value === '') {
            mostrarMensajeError('Por favor, seleccione una opción en todos los campos antes de enviar los datos.');
            return;
        }
    }

    // Verifica si hay opciones duplicadas en los selects
    const selectValues = selects.toArray().map(select => select.value);
    const uniqueValues = new Set(selectValues);
    if (selectValues.length !== uniqueValues.size) {
        mostrarMensajeError('Hay opciones duplicadas en los campos. Por favor, seleccione opciones diferentes.');
        return;
    }

    // El formulario está bien, así que podemos enviarlo.
    form.submit();
});