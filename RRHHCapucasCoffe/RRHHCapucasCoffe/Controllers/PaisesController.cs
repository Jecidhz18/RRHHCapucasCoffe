using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Models;
using RRHHCapucasCoffe.Services;

namespace RRHHCapucasCoffe.Controllers
{
    public class PaisesController : Controller
    {
        private IRepositorioPais repositorioPais;

        public PaisesController(IRepositorioPais repositorioPais)
        {
            this.repositorioPais = repositorioPais;
            
        }
        public IActionResult Pais()
        {
            return View();
        }

        public IActionResult CrearPais()
        {
            return View();  
        }



        [HttpPost]
        public async Task<IActionResult> CrearPais(Pais pais)
        {
            if (!ModelState.IsValid)
            {
                return View(pais);
            }

            var paisExiste = await repositorioPais.ExistePais(pais.PaisNombre);

            if (paisExiste)
            {
                ModelState.AddModelError("", $"El pais {pais.PaisNombre} ya existe!");

                return View(pais);
            }

            await repositorioPais.CrearPais(pais);

            return View();
        }
    }
}
