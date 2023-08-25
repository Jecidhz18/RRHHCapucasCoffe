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

function errorDepartamentoInput(mensaje) {
    const mensajeError = document.getElementById('validation-input-departamento');
    mensajeError.textContent = mensaje;
}

function errorPaisTable(mensaje) {
    const mensajeError = document.getElementById('validation-pais-table');
    mensajeError.textContent = mensaje;
}
