using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models;

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
        public async Task<IActionResult> EditarPais(int paisId)
        {
            var pais = await repositorioPais.ObtenerPaisPorId(paisId);

            if (pais is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            return View(pais);
        }

        [HttpPost]
        public async Task<IActionResult> EditarPais(Pais pais)
        {
            var paisExiste = await repositorioPais.ObtenerPaisPorId(pais.PaisId);

            if (paisExiste is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            await repositorioPais.ActualizarPais(pais);
            return RedirectToAction("Pais");
        }

        public async Task<IActionResult> EliminarPais(int paisId)
        {
            var pais = await repositorioPais.ObtenerPaisPorId(paisId);

            if (pais is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            return View(pais);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarPaisSelect(int paisId)
        {
            var pais = await repositorioPais.ObtenerPaisPorId(paisId);

            if (pais is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            await repositorioPais.EliminarPais(paisId);
            return RedirectToAction("Pais");
        }
    }
}
