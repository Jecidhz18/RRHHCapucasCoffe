using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Aldeas;
using RRHHCapucasCoffe.Models.Paises;
using RRHHCapucasCoffe.Models.TablasUniones;

namespace RRHHCapucasCoffe.Controllers
{
    public class AldeasController : Controller
    {
        private readonly IRepositorioPais repositorioPais;
        private readonly IRepositorioDepartamento repositorioDepartamento;
        private readonly IRepositorioMunicipio repositorioMunicipio;
        private readonly IRepositorioAldea repositorioAldea;
        private readonly IRepositorioMpioAldea repositorioMpioAldea;

        public AldeasController(IRepositorioPais repositorioPais, IRepositorioDepartamento repositorioDepartamento, IRepositorioMunicipio repositorioMunicipio,
            IRepositorioAldea repositorioAldea, IRepositorioMpioAldea repositorioMpioAldea) 
        {
            this.repositorioPais = repositorioPais;
            this.repositorioDepartamento = repositorioDepartamento;
            this.repositorioMunicipio = repositorioMunicipio;
            this.repositorioAldea = repositorioAldea;
            this.repositorioMpioAldea = repositorioMpioAldea;
        }

        public async Task<IActionResult> Aldea()
        {
            var modelo = await repositorioAldea.ObtenerAldeas();
            return View(modelo);
        }
        public async Task<IActionResult> CrearAldea()
        {
            var modelo = new AldeaCrearViewModel();
            modelo.Paises = await ObtenerPaises();
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> CrearAldea(AldeaCrearViewModel modelo)
        {
            var existeAldea = await repositorioAldea.ExisteAldea(modelo.AldeaNombre);

            if (!ModelState.IsValid)
            {
                modelo.Paises = await ObtenerPaises();
                return View(modelo); 
            }

            if (modelo.PaisId == null || modelo.DepartamentoId == null || modelo.MunicipioId == null)
            {
                modelo.Paises = await ObtenerPaises();
                ModelState.AddModelError("", $"Por favor, seleccione una opción en todos los campos antes de enviar los datos.");
                return View(modelo);
            }

            if (existeAldea)
            {
                ModelState.AddModelError("", $"La aldea {modelo.AldeaNombre} ya existe.");
                modelo.Paises = await ObtenerPaises();
                return View(modelo);
            }

            await repositorioAldea.CrearAldea(modelo);
            await repositorioMpioAldea.InsertarMpioAldea(modelo);

            return RedirectToAction("Aldea");
        }
        //Metodo AJAX para obtener departamentos
        [HttpPost]
        public async Task<IActionResult> ObtenerDepartamentos([FromBody] Pais pais)
        {
            var departamentos = await ObtenerDeptoPorPais(pais);

            return Ok(departamentos);
        }
        //Metodo AJAX para obtener municipios
        [HttpPost]
        public async Task<IActionResult> ObtenerMunicipios([FromBody] PaisDepto paisDepto)
        {
            var municipios = await ObtenerMpioPorDepto(paisDepto);

            return Ok(municipios);
        }
        //Metodo privado para obtener paises
        private async Task<IEnumerable<SelectListItem>> ObtenerPaises()
        {
            var paises = await repositorioPais.ObtenerPaisActivo();

            return paises.Select(x => new SelectListItem(x.PaisNombre, x.PaisId.ToString()));
        }
        //Metodo privado para obtener departamentos por pais
        private async Task<IEnumerable<SelectListItem>> ObtenerDeptoPorPais(Pais pais)
        {
            var departamentos = await repositorioDepartamento.ObtenerDeptoActivoPorPais(pais);

            if (departamentos != null)
            {
                return departamentos.Select(x => new SelectListItem(x.DepartamentoNombre, x.DepartamentoId.ToString()));
            }

            return new List<SelectListItem>(); //retorna una lista vacia si "departamentos" es nulo
        }
        //Metodo privado para obtener municipios por departamento
        private async Task<IEnumerable<SelectListItem>> ObtenerMpioPorDepto(PaisDepto paisDepto)
        {
            var municipios = await repositorioMunicipio.ObtenerMunicipioActivoPorDepto(paisDepto);

            if (municipios != null)
            {
                return municipios.Select(x => new SelectListItem(x.MunicipioNombre, x.MunicipioId.ToString()));
            }

            return new List<SelectListItem>();//retorna una lista vacia si "municipios" es nulo
        }

    }
}
