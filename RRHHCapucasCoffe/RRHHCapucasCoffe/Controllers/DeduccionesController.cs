using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Deducciones;

namespace RRHHCapucasCoffe.Controllers
{
    public class DeduccionesController : Controller
    {
        private readonly IRepositorioDeduccion repositorioDeduccion;

        public DeduccionesController(IRepositorioDeduccion repositorioDeduccion)
        {
            this.repositorioDeduccion = repositorioDeduccion;
        }

        public ActionResult Deduccion()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CrearDeduccion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearDeduccion(DeduccionCrearViewModel deduccion) 
        {
            return RedirectToAction("Deduccion");
        }

    }
}
