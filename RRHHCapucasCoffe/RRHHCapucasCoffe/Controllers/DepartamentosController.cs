using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Departamentos;

namespace RRHHCapucasCoffe.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly IRepositorioPais repositorioPais;
        private readonly IRepositorioDepartamento repositorioDepartamento;

        public DepartamentosController(IRepositorioPais repositorioPais, IRepositorioDepartamento repositorioDepartamento)
        {
            this.repositorioPais = repositorioPais;
            this.repositorioDepartamento = repositorioDepartamento;
        }

        public IActionResult Departamento()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CrearDepartamento()
        {
            var paises = await repositorioPais.ObtenerPais();
            var modelo = new DeptoCrearViewModel();

            modelo.Paises = paises.Select(x => new SelectListItem(x.PaisNombre, x.PaisId.ToString()));
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> CrearDepartamento(Departamento departamento)
        {
            if (!ModelState.IsValid)
            {
                return View(departamento);
            }
            await repositorioDepartamento.CrearDepartamento(departamento);
            return RedirectToAction("departamento");
        }

        //public async Task<IActionResult> CrearReferencia([FromBody] int[] ids)
        //{
        //    var ultimoDepartamentoId = await repositorioDepartamento.ObtenerUltimoDepartamentoId();
        //    var paises = ids.Select(valor => new PaisDepto { PaisId = valor });

        //    int departamentoId = ultimoDepartamentoId + 1;

        //    await repositorioDepartamento.CrearReferencia(paises, departamentoId);

        //    return Ok();
        //}
    }
}
