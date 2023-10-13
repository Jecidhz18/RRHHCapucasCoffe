using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.DireccionesEmpleados;
using RRHHCapucasCoffe.Models.Empleados;
using RRHHCapucasCoffe.Models.TablasUniones;
using RRHHCapucasCoffe.Services;
using System.Data;

namespace RRHHCapucasCoffe.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IRepositorioDepartamento repositorioDepartamento;
        private readonly IRepositorioPais repositorioPais;
        private readonly IRepositorioMunicipio repositorioMunicipio;
        private readonly IRepositorioAldea repositorioAldea;
        private readonly IRepositorioEstadoCivil repositorioEstadoCivil;
        private readonly IRepositorioProfesion repositorioProfesion;
        private readonly IRepositorioBanco repositorioBanco;
        private readonly IRepositorioColegioProfesional repositorioColegioProfesional;
        private readonly IRepositorioAgencia repositorioAgencia;
        private readonly IRepositorioUnidad repositorioUnidad;
        private readonly IRepositorioAgenciaUnidad repositorioAgenciaUnidad;
        private readonly IRepositorioCargo repositorioCargo;
        private readonly IRepositorioModalidad repositorioModalidad;
        private readonly IRepositorioEmpleado repositorioEmpleado;
        private readonly IMapper mapper;
        private readonly IRepositorioDireccionEmpleado repositorioDireccionEmpleado;
        private readonly IRepositorioFamiliar repositorioFamiliar;
        private readonly IRepositorioUsuario repositorioUsuario;
        private readonly IRepositorioEmpleadoBanco repositorioEmpleadoBanco;
        private readonly IRepositorioEmpleadoColegiacion repositorioEmpleadoColegiacion;
        private readonly IRepositorioEmpleadoArea repositorioEmpleadoArea;
        private readonly IRepositorioEmpleadoCargo repositorioEmpleadoCargo;

        public EmpleadosController(IRepositorioDepartamento repositorioDepartamento, IRepositorioPais repositorioPais,
            IRepositorioMunicipio repositorioMunicipio, IRepositorioAldea repositorioAldea, IRepositorioEstadoCivil repositorioEstadoCivil,
            IRepositorioProfesion repositorioProfesion, IRepositorioBanco repositorioBanco, IRepositorioColegioProfesional repositorioColegioProfesional,
            IRepositorioAgencia repositorioAgencia, IRepositorioUnidad repositorioUnidad, IRepositorioAgenciaUnidad repositorioAgenciaUnidad,
            IRepositorioCargo repositorioCargo, IRepositorioModalidad repositorioModalidad, IRepositorioEmpleado repositorioEmpleado, IMapper mapper,
            IRepositorioDireccionEmpleado repositorioDireccionEmpleado, IRepositorioFamiliar repositorioFamiliar, IRepositorioUsuario repositorioUsuario,
            IRepositorioEmpleadoBanco repositorioEmpleadoBanco, IRepositorioEmpleadoColegiacion repositorioEmpleadoColegiacion, IRepositorioEmpleadoArea repositorioEmpleadoArea, 
            IRepositorioEmpleadoCargo repositorioEmpleadoCargo)
        {
            this.repositorioDepartamento = repositorioDepartamento;
            this.repositorioPais = repositorioPais;
            this.repositorioMunicipio = repositorioMunicipio;
            this.repositorioAldea = repositorioAldea;
            this.repositorioEstadoCivil = repositorioEstadoCivil;
            this.repositorioProfesion = repositorioProfesion;
            this.repositorioBanco = repositorioBanco;
            this.repositorioColegioProfesional = repositorioColegioProfesional;
            this.repositorioAgencia = repositorioAgencia;
            this.repositorioUnidad = repositorioUnidad;
            this.repositorioAgenciaUnidad = repositorioAgenciaUnidad;
            this.repositorioCargo = repositorioCargo;
            this.repositorioModalidad = repositorioModalidad;
            this.repositorioEmpleado = repositorioEmpleado;
            this.mapper = mapper;
            this.repositorioDireccionEmpleado = repositorioDireccionEmpleado;
            this.repositorioFamiliar = repositorioFamiliar;
            this.repositorioUsuario = repositorioUsuario;
            this.repositorioEmpleadoBanco = repositorioEmpleadoBanco;
            this.repositorioEmpleadoColegiacion = repositorioEmpleadoColegiacion;
            this.repositorioEmpleadoArea = repositorioEmpleadoArea;
            this.repositorioEmpleadoCargo = repositorioEmpleadoCargo;
        }


        public ActionResult Empleado()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CrearEmpleado()
        {
            var modelo = new EmpleadoCrearViewModel();
            modelo.Paises = await ObtenerPaises();
            modelo.EstadosCiviles = await ObtenerEstadosCiviles();
            modelo.Profesiones = await ObtenerProfesiones();
            modelo.Bancos = await ObtenerBancos();
            modelo.ColegiosProfesionales = await ObtenerColegiosProfesionales();
            modelo.Agencias = await ObtenerAgencias();
            modelo.Cargos = await ObtenerCargos();
            modelo.Modalidades = await ObtenerModalidades();
            return View(modelo);
        }
        [HttpPost]
        public async Task<IActionResult> CrearEmpleado([FromBody] EmpleadoCrearViewModel modelo)
        {
            var existeEmpleado = await repositorioEmpleado.ExisteEmpleado(modelo.EmpleadoIdentificacion);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (existeEmpleado)
            {
                ModelState.AddModelError("", $"El empleado {modelo.EmpleadoNombre + " " + modelo.EmpleadoPrimerApellido + " " + modelo.EmpleadoSegundoApellido}");
                return BadRequest();
            }

            var direccionEmpleadoNacimiento = new DireccionEmpleadoNacimiento();
            mapper.Map(modelo, direccionEmpleadoNacimiento);

            var direccionEmpleadoResidencia = new DireccionEmpleadoResidencia();
            mapper.Map(modelo, direccionEmpleadoResidencia);

            // Comprobamos si existen ambas direcciones en una sola llamada.
            var existeDireccionNacimiento = await repositorioDireccionEmpleado.ExisteDireccionEmpleado(direccionEmpleadoNacimiento);
            var existeDireccionResidencia = await repositorioDireccionEmpleado.ExisteDireccionEmpleado(direccionEmpleadoResidencia);

            if (existeDireccionNacimiento == 0)
            {
                modelo.EmpleadoDirNacimientoId = await repositorioDireccionEmpleado.CrearDireccionEmpleado(direccionEmpleadoNacimiento);
            }
            else
            {
                modelo.EmpleadoDirNacimientoId = existeDireccionNacimiento;
            }

            if (existeDireccionResidencia == 0)
            {
                modelo.EmpleadoDireccionId = await repositorioDireccionEmpleado.CrearDireccionEmpleado(direccionEmpleadoResidencia);
            }
            else
            {
                modelo.EmpleadoDireccionId = existeDireccionResidencia;
            }

            var existeFamiliar = await repositorioFamiliar.ObtenerFamiliarPorIdentificacion(modelo.Familiar.FamiliarIdentificacion);

            if (existeFamiliar is null)
            {
                modelo.FamiliarId = await repositorioFamiliar.CrearFamiliar(modelo.Familiar);
            }
            else
            {
                modelo.FamiliarId = existeFamiliar.FamiliarId;
            }

            var empleado = new Empleado();
            mapper.Map(modelo, empleado);
            var usuario = await repositorioUsuario.ObtenerUsuario();
            empleado.EmpleadoFotografia = Convert.FromBase64String(modelo.EmpleadoFotografiaBase64);
            empleado.EmpleadoUsuarioGrabo = usuario.UsuarioId;
            empleado.EmpleadoFechaGrabo = DateTime.Now;

            var empleadoId = await repositorioEmpleado.CrearEmpleado(empleado);

            await repositorioEmpleadoBanco.CrearEmpleadoBanco(modelo.EmpleadoBancos, empleadoId);
            await repositorioEmpleadoColegiacion.CrearEmpleadoColegiacion(modelo.EmpleadoColegiaciones, empleadoId);
            await repositorioEmpleadoArea.CrearEmpleadoArea(modelo.EmpleadoAreas, empleadoId);
            await repositorioEmpleadoCargo.CrearEmpleadoCargo(modelo.EmpleadoCargos, empleadoId);

            return Ok();
        }
        [HttpGet]
        public IActionResult EditarEmpleado()
        {
            return View();  
        }

        //Metodo AJAX para obtener departamentos
        [HttpPost]
        public async Task<IActionResult> ObtenerDepartamentos([FromBody] Pais pais)
        {
            var departamentos = await ObtenerDeptosPorPais(pais);

            return Ok(departamentos);
        }
        //Metodo AJAX para obtener municipios
        [HttpPost]
        public async Task<IActionResult> ObtenerMunicipios([FromBody] PaisDepto paisDepto)
        {
            var municipios = await ObtenerMpiosPorDepto(paisDepto);

            return Ok(municipios);
        }
        //Metodo AJAX para obtener aldeas
        [HttpPost]
        public async Task<IActionResult> ObtenerAldeas([FromBody] PaisDeptoMpio paisDeptoMpio)
        {
            var aldeas = await ObtenerAldeasPorMpio(paisDeptoMpio);

            return Ok(aldeas);
        }
        //Metodo AJAX para obtener areas
        public async Task<IActionResult> ObtenerAreas([FromBody] Agencia agencia)
        {
            var areas = await ObtenerAreasPorAgencia(agencia.AgenciaId);

            return Ok(areas);
        }
        //Metodo privado para obtener paises
        private async Task<IEnumerable<SelectListItem>> ObtenerPaises()
        {
            var paises = await repositorioPais.ObtenerPaisActivo();

            return paises.Select(x => new SelectListItem(x.PaisNombre, x.PaisId.ToString()));
        }
        //Metodo privado para obtener departamentos por pais
        private async Task<IEnumerable<SelectListItem>> ObtenerDeptosPorPais(Pais pais)
        {
            var departamentos = await repositorioDepartamento.ObtenerDeptoActivoPorPais(pais);

            if (departamentos != null)
            {
                return departamentos.Select(x => new SelectListItem(x.DepartamentoNombre, x.DepartamentoId.ToString()));
            }

            return new List<SelectListItem>(); //retorna una lista vacia si "departamentos" es nulo
        }
        // Metodo privado para obtener mpios por depto
        private async Task<IEnumerable<SelectListItem>> ObtenerMpiosPorDepto(PaisDepto paisDepto)
        {
            var municipios = await repositorioMunicipio.ObtenerMunicipioActivoPorDepto(paisDepto);

            if (municipios != null)
            {
                return municipios.Select(x => new SelectListItem(x.MunicipioNombre, x.MunicipioId.ToString()));
            }

            return new List<SelectListItem>();//retorna una lista vacia si "municipios" es nulo
        }
        //Metodo privado para obtener aldeas por mpio
        private async Task<IEnumerable<SelectListItem>> ObtenerAldeasPorMpio(PaisDeptoMpio paisDeptoMpio)
        {
            var aldeas = await repositorioAldea.ObtenerAldeasActivoPorMpio(paisDeptoMpio);

            if (aldeas != null)
            {
                return aldeas.Select(x => new SelectListItem(x.AldeaNombre, x.AldeaId.ToString()));
            }

            return new List<SelectListItem>();//retorna una lista vacia si "municipios" es nulo
        }
        //Metodo privado para obtener estados civiles
        private async Task<IEnumerable<SelectListItem>> ObtenerEstadosCiviles()
        {
            var estadosCiviles = await repositorioEstadoCivil.ObtenerEstadoCivilActivo();

            return estadosCiviles.Select(x => new SelectListItem(x.EstadoCivilNombre, x.EstadoCivilId.ToString()));
        }
        //Metodo privado para obtener profesiones
        private async Task<IEnumerable<SelectListItem>> ObtenerProfesiones()
        {
            var profesiones = await repositorioProfesion.ObtenerProfesionesActivas();

            return profesiones.Select(x => new SelectListItem(x.ProfesionNombre, x.ProfesionId.ToString()));
        }
        //Metodo privado para obtener bancos
        private async Task<IEnumerable<SelectListItem>> ObtenerBancos()
        {
            var bancos = await repositorioBanco.ObtenerBancosActivos();

            return bancos.Select(x => new SelectListItem(x.BancoNombre, x.BancoId.ToString()));
        }
        //Metodo privado para obtener colegios profesionales
        private async Task<IEnumerable<SelectListItem>> ObtenerColegiosProfesionales()
        {
            var colegiosProfesionales = await repositorioColegioProfesional.ObtenerColegiosProfesionalesActivos();

            return colegiosProfesionales.Select(x => new SelectListItem(x.ColegioProfesionalNombre, x.ColegioProfesionalId.ToString()));
        }
        //Metodo privado para obtener colegios profesionales
        private async Task<IEnumerable<SelectListItem>> ObtenerAgencias()
        {
            var agencias = await repositorioAgencia.ObtenerAgenciasActivas();

            return agencias.Select(x => new SelectListItem(x.AgenciaNombre, x.AgenciaId.ToString()));
        }
        //Metodo privado para obtener areas o unidades
        private async Task<IEnumerable<SelectListItem>> ObtenerAreasPorAgencia(int agenciaId)
        {
            var areas = await repositorioAgenciaUnidad.ObtenerUnidadPorAgencia(agenciaId);

            return areas.Select(x => new SelectListItem(x.UnidadDescripcion, x.UnidadId.ToString()));
        }
        //Metodo privado para obtener cargos
        private async Task<IEnumerable<SelectListItem>> ObtenerCargos()
        {
            var cargos = await repositorioCargo.ObtenerCargosActivos();

            return cargos.Select(x => new SelectListItem(x.CargoNombre, x.CargoId.ToString()));
        }
        //Metodo privado para obtener modalidades
        private async Task<IEnumerable<SelectListItem>> ObtenerModalidades()
        {
            var modalidades = await repositorioModalidad.ObtenerModalidadesActivas();

            return modalidades.Select(x => new SelectListItem(x.ModalidadNombre, x.ModalidadId.ToString()));    
        }
        
    }
}
