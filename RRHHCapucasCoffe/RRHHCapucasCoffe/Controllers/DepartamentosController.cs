using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Models;
using RRHHCapucasCoffe.Services;

namespace RRHHCapucasCoffe.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly IRepositorioPais repositorioPais;

        public DepartamentosController(IRepositorioPais repositorioPais)
        {
            this.repositorioPais = repositorioPais;
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

        //[HttpPost]
        //public IActionResult CrearDepartamento(Departamento departamento)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(departamento);
        //    }

        //    return View(departamento);  
        //}
    }
}
