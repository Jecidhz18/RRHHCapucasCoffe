using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Municipios;
using RRHHCapucasCoffe.Services;

namespace RRHHCapucasCoffe.Controllers
{
    public class MunicipiosController : Controller
    {
        private readonly IRepositorioMunicipio repositorioMunicipio;
        private readonly IRepositorioDepartamento repositorioDepartamento;
        private readonly IRepositorioPais repositorioPais;

        public MunicipiosController(IRepositorioMunicipio repositorioMunicipio, 
            IRepositorioDepartamento repositorioDepartamento, IRepositorioPais repositorioPais) 
        {
            this.repositorioMunicipio = repositorioMunicipio;
            this.repositorioDepartamento = repositorioDepartamento;
            this.repositorioPais = repositorioPais;
        }
        public IActionResult Municipio()
        {
            return View();
        }
        public async Task<IActionResult> CrearMunicipio()
        {
            var paises = await repositorioPais.ObtenerPaisActivo();
            var departamentos = await repositorioDepartamento.ObtenerDeptoActivo();
            var modelo = new MunicipioViewModel();

            modelo.Paises = paises.Select(p => new SelectListItem(p.PaisNombre, p.PaisId.ToString()));
            modelo.Departamentos = departamentos.Select(d => new SelectListItem(d.DepartamentoNombre, d.DepartamentoId.ToString()));

            return View(modelo);
        }

        [HttpPost]
        public IActionResult CrearMunicipio(MunicipioViewModel municipio)
        {
            if (!ModelState.IsValid)
            {
                return View(municipio);
            }

            return View(municipio); 
        }

    }
}
