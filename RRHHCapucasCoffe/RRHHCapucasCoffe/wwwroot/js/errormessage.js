function errorSummary(mensaje) {
    const mensajeError = document.getElementById('validation-summary');
    mensajeError.textContent = mensaje;
}
//Funciones para mostrar errores en los select para llenar la tablas de division politica
function errorPais(mensaje) {
    const mensajeError = document.getElementById('validation-pais');
    mensajeError.textContent = mensaje;
}

function errorDepartamento(mensaje) {
    const mensajeError = document.getElementById('validation-departamento');
    mensajeError.textContent = mensaje;
}

function errorMunicipio(mensaje) {
    const mensajeError = document.getElementById('validation-municipio');
    mensajeError.textContent = mensaje;
}

//Departamento
function errorDepartamentoInput(mensaje) {
    const mensajeError = document.getElementById('validation-input-departamento');
    mensajeError.textContent = mensaje;
}
//Municipio
function errorPaisTable(mensaje) {
    const mensajeError = document.getElementById('validation-pais-table');
    mensajeError.textContent = mensaje;
}
function errorDepartamentoTable(mensaje){
    const mensajeError = document.getElementById('validation-depto-table');
    mensajeError.textContent = mensaje;
}

function errorMunicipioNombre(mensaje) {
    const mensajeError = document.getElementById("validation-municipioNombre");
    mensajeError.textContent = mensaje;
}

//Aldea
function errorAldeaNombre(mensaje) {
    const mensajeError = document.getElementById("validation-aldeaNombre");
    mensajeError.textContent = mensaje;
}
function errorMunicipioTable(mensaje) {
    const mensajeError = document.getElementById("validation-mpio-table")
    mensajeError.textContent = mensaje;
}
//Agencia
function errorUnidadSelect(mensaje) {
    const mensajeError = document.getElementById("validation-unidad-select");
    mensajeError.textContent = mensaje;
}

function errorUnidadTable(mensaje) {
    const mensajeError = document.getElementById("validation-unidad-table");
    mensajeError.textContent = mensaje;
}

function errorAgenciaNombre(mensaje) {
    const mensajeError = document.getElementById("validation-agenciaNombre");
    mensajeError.textContent = mensaje;
}
//Empleado
function errorBancoSelect(mensaje) {
    const mensajeError = $('#validate-select-banco');
    mensajeError.text(mensaje);
}

function errorInputBancoNoCuenta(mensaje) {
    const mensajeError = $('#validate-input-banco-no-cuenta');
    mensajeError.text(mensaje);
}

function errorColegioSelect(mensaje) {
    const mensajeError = $('#validate-colegio-profesional');
    mensajeError.text(mensaje);
}

function errorInputColegioAnio(mensaje) {
    const mensajeError = $('#validate-colegiacion-anio');
    mensajeError.text(mensaje);
}

function errorInputColegioCuota(mensaje) {
    const mensajeError = $('#validate-colegiacion-cuota');
    mensajeError.text(mensaje);
}

function errorAgenciaSelect(mensaje) {
    const mensajeError = $('#validate-agencia');
    mensajeError.text(mensaje);
}

function errorAreaSelect(mensaje) {
    const mensajeError = $('#validate-unidad');
    mensajeError.text(mensaje);
}

function errorCargoSelect(mensaje) {
    const mensajeError = $('#validate-cargo');
    mensajeError.text(mensaje);
}

function errorModalidadSelect(mensaje) {
    const mensajeError = $('#validate-modalidad');
    mensajeError.text(mensaje);
}

function errorCargoFechaInicio(mensaje) {
    const mensajeError = $('#validate-fecha-inicio');
    mensajeError.text(mensaje);
}

function errorCargoFechaFinal(mensaje) {
    const mensajeError = $('#validate-fecha-final');
    mensajeError.text(mensaje);
}

function errorCargoSalario(mensaje) {
    const mensajeError = $('#validate-salario');
    mensajeError.text(mensaje);
}
