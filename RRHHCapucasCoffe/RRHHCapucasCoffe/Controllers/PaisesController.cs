using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Models;
using RRHHCapucasCoffe.Services;

namespace RRHHCapucasCoffe.Controllers
{
    public class PaisesController : Controller
    {
        private readonly IRepositorioPais repositorioPais;

        public PaisesController(IRepositorioPais repositorioPais)
        {
            this.repositorioPais = repositorioPais;
            
        }

        public async Task<IActionResult> Pais()
        {
            var pais = await repositorioPais.ObtenerPais();
            return View(pais);
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

            return RedirectToAction("Pais");
        }

        [HttpGet]
        public async Task<ActionResult> EditarPais(int paisId)
            {
            var pais = await repositorioPais.ObtenerPaisPorId(paisId);

            if (pais is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            return View(pais);
        }

        [HttpPost]
        public async Task<ActionResult> EditarPais(Pais pais)
        {
            var paisExiste = await repositorioPais.ExistePais(pais.PaisNombre);

            if (paisExiste)
            {
                ModelState.AddModelError("", $"El pais {pais.PaisNombre} ya existe!");

                return View(pais);
            }

            await repositorioPais.ActualizarPais(pais);
            return RedirectToAction("Pais");
        }
    }
}
