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

        public EmpleadosController(IRepositorioDepartamento repositorioDepartamento, IRepositorioPais repositorioPais,
            IRepositorioMunicipio repositorioMunicipio, IRepositorioAldea repositorioAldea, IRepositorioEstadoCivil repositorioEstadoCivil,
            IRepositorioProfesion repositorioProfesion)
        {
            this.repositorioDepartamento = repositorioDepartamento;
            this.repositorioPais = repositorioPais;
            this.repositorioMunicipio = repositorioMunicipio;
            this.repositorioAldea = repositorioAldea;
            this.repositorioEstadoCivil = repositorioEstadoCivil;
            this.repositorioProfesion = repositorioProfesion;
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
            return View(modelo);
        }

        [HttpPost]
        public IActionResult CrearEmpleado(EmpleadoCrearViewModel modelo)
        {
            return RedirectToAction("Empleado");
        }

        [HttpGet]
        public IActionResult PruebaEmpleados() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult InsertarFoto(string imagenRecortada)
        {
            return RedirectToAction("Empleado");
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
        public async Task<IEnumerable<SelectListItem>> ObtenerProfesiones()
        {
            var profesiones = await repositorioProfesion.ObtenerProfesionesActivas();

            return profesiones.Select(x => new SelectListItem(x.ProfesionNombre, x.ProfesionId.ToString()));
        }
    }
}
