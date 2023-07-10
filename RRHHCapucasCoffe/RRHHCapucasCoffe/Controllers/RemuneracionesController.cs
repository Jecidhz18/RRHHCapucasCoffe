using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models;
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

        public IActionResult Remuneracion()
        {
            return View();
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

            await repositorioRemuneracion.CrearRemuneracion(remuneracion);
            return RedirectToAction("Remuneracion");
        }

    }
}
