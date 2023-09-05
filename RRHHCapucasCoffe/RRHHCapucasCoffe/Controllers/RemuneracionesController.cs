using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Services;

namespace RRHHCapucasCoffe.Controllers
{
    public class RemuneracionesController : Controller
    {
        private readonly IRepositorioRemuneracion repositorioRemuneracion;

        public RemuneracionesController(IRepositorioRemuneracion repositorioRemuneracion)
        {
            this.repositorioRemuneracion = repositorioRemuneracion;
        }

        public async Task<IActionResult> Remuneracion()
        {
            var remuneracion = await repositorioRemuneracion.ObtenerRemuneracion();
            return View(remuneracion);
        }

        public IActionResult CrearRemuneracion()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> CrearRemuneracion(Remuneracion remuneracion)
        {
            if (!ModelState.IsValid)
            {
                return View(remuneracion);
            }

            var existeRemuneracion = await repositorioRemuneracion.ExisteRemuneracion(remuneracion.RemuneracionDescripcion);

            if (existeRemuneracion)
            {
                ModelState.AddModelError("", $"La remuneración {remuneracion.RemuneracionDescripcion} ya existe!");
                return View(remuneracion);
            }

            await repositorioRemuneracion.CrearRemuneracion(remuneracion);
            return RedirectToAction("Remuneracion");
        }
        [HttpGet]
        public async Task<IActionResult> EditarRemuneracion(int remuneracionId)
        {
            var remuneracion = await repositorioRemuneracion.ObtenerRemuneracionPorId(remuneracionId);

            if (remuneracion is null)
            {
                RedirectToAction("NoEncontrado", "Home");
            }

            return View(remuneracion);
        }

        [HttpPost]
        public async Task<IActionResult> EditarRemuneracion(Remuneracion remuneracion)
        {
            var existeRemuneracion = await repositorioRemuneracion.ObtenerRemuneracionPorId(remuneracion.RemuneracionId);

            if (existeRemuneracion is null)
            {
                RedirectToAction("NoEncontrado","Home");
            }

            await repositorioRemuneracion.EditarRemuneracion(remuneracion);
            return RedirectToAction("Remuneracion");
        }

        [HttpGet]
        public async Task<IActionResult> EliminarRemuneracion(int remuneracionId)
        {
            var remuneracion = await repositorioRemuneracion.ObtenerRemuneracionPorId(remuneracionId);

            if (remuneracion is null)
            {
                RedirectToAction("NoEncontrado", "Home");
            }

            return View(remuneracion);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarRemuneracionSelect(int remuneracionId)
        {
            var remuneracion = await repositorioRemuneracion.ObtenerRemuneracionPorId(remuneracionId);

            if (remuneracion is null)
            {
                RedirectToAction("NoEncontrado","Home");
            }

            await repositorioRemuneracion.EliminarRemuneracion(remuneracionId);
            return RedirectToAction("Remuneracion");
        }
    }
}
