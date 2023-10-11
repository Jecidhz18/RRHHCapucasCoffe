using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Empleados;
using RRHHCapucasCoffe.Models.TablasUniones;
using RRHHCapucasCoffe.Services;

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

        public EmpleadosController(IRepositorioDepartamento repositorioDepartamento, IRepositorioPais repositorioPais,
            IRepositorioMunicipio repositorioMunicipio, IRepositorioAldea repositorioAldea, IRepositorioEstadoCivil repositorioEstadoCivil,
            IRepositorioProfesion repositorioProfesion, IRepositorioBanco repositorioBanco, IRepositorioColegioProfesional repositorioColegioProfesional,
            IRepositorioAgencia repositorioAgencia, IRepositorioUnidad repositorioUnidad, IRepositorioAgenciaUnidad repositorioAgenciaUnidad,
            IRepositorioCargo repositorioCargo, IRepositorioModalidad repositorioModalidad, IRepositorioEmpleado repositorioEmpleado, IMapper mapper)
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

            var direccionEmpleado = new DireccionEmpleado();
            mapper.Map(modelo, direccionEmpleado);

            if (direccionEmpleado is null)
            {
                return BadRequest();
            }

            return Ok();
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
