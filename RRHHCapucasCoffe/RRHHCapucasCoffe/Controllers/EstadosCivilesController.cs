using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.EstadosCiviles;

namespace RRHHCapucasCoffe.Controllers
{
    public class EstadosCivilesController : Controller
    {
        private readonly IRepositorioEstadoCivil repositorioEstadoCivil;

        public EstadosCivilesController(IRepositorioEstadoCivil repositorioEstadoCivil)
        {
            this.repositorioEstadoCivil = repositorioEstadoCivil;
        }

        public async Task<IActionResult> EstadoCivil()
        {
            var estadoCivil = await repositorioEstadoCivil.ObtenerEstadoCivil();
            return View(estadoCivil);
        }

        public IActionResult CrearEstadoCivil()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> CrearEstadoCivil(EstadoCivil estadoCivil)
        {
            if (!ModelState.IsValid)
            {
                return View(estadoCivil);
            }

            var existeEstadoCivil = await repositorioEstadoCivil.ExisteEstadoCivil(estadoCivil.EstadoCivilNombre);

            if (existeEstadoCivil)
            {
                ModelState.AddModelError("",$"El estado civil {estadoCivil.EstadoCivilNombre} ya existe!");
                return View(estadoCivil);
            }
            await repositorioEstadoCivil.CrearEstadoCivil(estadoCivil);
            return RedirectToAction("EstadoCivil");
        }

        [HttpGet]
        public async Task<IActionResult> EditarEstadoCivil(int estadoCivilId)
        {
            var estadoCivil = await repositorioEstadoCivil.ObtenerEstadoCivilPorId(estadoCivilId);

            if (estadoCivil is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            return View(estadoCivil);
        }

        [HttpPost]
        public async Task<IActionResult> EditarEstadoCivil(EstadoCivil estadoCivil)
        {
            var existeEstadoCivil = await repositorioEstadoCivil.ObtenerEstadoCivilPorId(estadoCivil.EstadoCivilId);

            if (existeEstadoCivil is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            await repositorioEstadoCivil.EditarEstadoCivil(estadoCivil);
            return RedirectToAction("EstadoCivil");
        }

        [HttpGet]
        public async Task<IActionResult> EliminarEstadoCivil(int estadoCivilId)
        {
            var estadoCivil = await repositorioEstadoCivil.ObtenerEstadoCivilPorId(estadoCivilId);

            if (estadoCivil is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            return View(estadoCivil);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarEstadoCivilSelect(int estadoCivilId)
        {
            var estadoCivil = await repositorioEstadoCivil.ObtenerEstadoCivilPorId(estadoCivilId);

            if (estadoCivil is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            await repositorioEstadoCivil.EliminarEstadoCivil(estadoCivilId);

            return RedirectToAction("EstadoCivil");
        }
    }
}
