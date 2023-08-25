using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Departamentos;
using RRHHCapucasCoffe.Models.Municipios;
using RRHHCapucasCoffe.Models.Paises;
using RRHHCapucasCoffe.Services;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace RRHHCapucasCoffe.Controllers
{
    public class MunicipiosController : Controller
    {
        private readonly IRepositorioMunicipio repositorioMunicipio;
        private readonly IRepositorioDepartamento repositorioDepartamento;
        private readonly IRepositorioPais repositorioPais;
        private readonly IRepositorioDeptoMunicipio repositorioDeptoMunicipio;

        public MunicipiosController(IRepositorioMunicipio repositorioMunicipio, 
            IRepositorioDepartamento repositorioDepartamento, IRepositorioPais repositorioPais, 
            IRepositorioDeptoMunicipio repositorioDeptoMunicipio) 
        {
            this.repositorioMunicipio = repositorioMunicipio;
            this.repositorioDepartamento = repositorioDepartamento;
            this.repositorioPais = repositorioPais;
            this.repositorioDeptoMunicipio = repositorioDeptoMunicipio;
        }
        public IActionResult Municipio()
        {
            return View();
        }
        public async Task<IActionResult> CrearMunicipio()
        {
            var modelo = new MunicipioCrearViewModel();
            modelo.Paises = await ObtenerPaises();
            //modelo.Departamentos = await ObtenerDeptoPorPais(modelo.PaisId);

            return View(modelo);
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

            return new List<SelectListItem>(); // Retorna una colección vacía si 'departamentos' es nulo.
        }

        // Metodo Ajax para devolver departamentos
        [HttpPost]
        public async Task<IActionResult> ObtenerDepartamentos([FromBody] Pais pais)
        {
            var departamentos = await ObtenerDeptoPorPais(pais);

            return Ok(departamentos);
        }

        [HttpPost]
        public async Task<IActionResult> CrearMunicipio(MunicipioCrearViewModel municipio)
        {
            var existeMunicipio = await repositorioMunicipio.ExisteMunicipio(municipio.MunicipioNombre);

            if (municipio.PaisId == null && municipio.DepartamentoId == null )
            {
                ModelState.AddModelError("", $"Por favor, seleccione una opción en todos los campos antes de enviar los datos.");
                municipio.Paises = await ObtenerPaises();
                return View(municipio);
            }

            if (existeMunicipio)
            {
                ModelState.AddModelError("", $"El municipio {municipio.MunicipioNombre} ya existe.");
                municipio.Paises = await ObtenerPaises();
                return View(municipio);
            }

            await repositorioMunicipio.CrearMunicipio(municipio);
            await repositorioDeptoMunicipio.InsertarDeptoMunicipio(municipio);

            return RedirectToAction("Municipio");
        }

        //[HttpGet]
        //public async Task<IActionResult> EditarMunicipio(int municipioId)
        //{
        //    var municipio = await repositorioMunicipio.ObtenerMunicipioPorId(municipioId);
        //    var paisDepto = await 
        //}
    }
}
