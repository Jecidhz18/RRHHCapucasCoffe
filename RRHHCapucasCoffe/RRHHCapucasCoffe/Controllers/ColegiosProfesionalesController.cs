using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.ColegiosProfesionales;

namespace RRHHCapucasCoffe.Controllers
{
    public class ColegiosProfesionalesController : Controller
    {
        private readonly IRepositorioColegioProfesional repositorioColegioProfesional;

        public ColegiosProfesionalesController(IRepositorioColegioProfesional repositorioColegioProfesional) 
        {
            this.repositorioColegioProfesional = repositorioColegioProfesional;
        }
        public async Task<IActionResult> ColegioProfesional()
        {
            var colegioProfesional = await repositorioColegioProfesional.ObtenerColegioProfesional();
            return View(colegioProfesional);
        }
        public IActionResult CrearColegioProfesional() 
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> CrearColegioProfesional(ColegioProfesional colegioProfesional)
        {
            if (!ModelState.IsValid)
            {
                return View(colegioProfesional);
            }

            var exiteColegioProfesional = await repositorioColegioProfesional.ExisteColegioProfesional(colegioProfesional.ColegioProfesionalNombre);

            if (exiteColegioProfesional)
            {
                ModelState.AddModelError("", $"El colegio profesional {colegioProfesional.ColegioProfesionalNombre} ya existe!");
                return View(colegioProfesional);
            }

            await repositorioColegioProfesional.CrearColegioProfesional(colegioProfesional);

            return RedirectToAction("ColegioProfesional");
        }

        [HttpGet]
        public async Task<IActionResult> EditarColegioProfesional(int colegioProfesionalId)
        {
            var colegioProfesional = await repositorioColegioProfesional.ObtenerColegioProfesionalPorId(colegioProfesionalId);

            if (colegioProfesional is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            return View(colegioProfesional);
        }

        [HttpPost]
        public async Task<IActionResult> EditarColegioProfesional(ColegioProfesional colegioProfesional)
        {
            var exiteColegioProfesional = await repositorioColegioProfesional.ObtenerColegioProfesionalPorId(colegioProfesional.ColegioProfesionalId);

            if (exiteColegioProfesional is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            await repositorioColegioProfesional.EditarColegioProfesional(colegioProfesional);
            return RedirectToAction("ColegioProfesional");
        }

        [HttpGet]
        public async Task<IActionResult> EliminarColegioProfesional(int colegioProfesionalId)
        {
            var colegioProfesional = await repositorioColegioProfesional.ObtenerColegioProfesionalPorId(colegioProfesionalId);

            if (colegioProfesional is null)
            {
                return RedirectToAction("NoEcontrado", "Home");
            }

            return View(colegioProfesional);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarColegioProfesionalSelect(int colegioProfesionalId)
        {
            var colegioProfesional = await repositorioColegioProfesional.ObtenerColegioProfesionalPorId(colegioProfesionalId);

            if (colegioProfesional is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            await repositorioColegioProfesional.EliminarColegioProfesional(colegioProfesionalId);
            return RedirectToAction("ColegioProfesional");
        }
    }
}
