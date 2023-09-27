using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Services;

namespace RRHHCapucasCoffe.Controllers
{
    public class ModalidadesController : Controller
    {
        private readonly IRepositorioModalidad repositorioModalidad;

        public ModalidadesController(IRepositorioModalidad repositorioModalidad)
        {
            this.repositorioModalidad = repositorioModalidad;
        }

        public async Task<IActionResult> Modalidad()
        {
            var modalidades = await repositorioModalidad.ObtenerModalidades();
            return View(modalidades);
        }
        [HttpGet]
        public IActionResult CrearModalidad()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CrearModalidad(Modalidad modalidad)
        {
            if (!ModelState.IsValid)
            {
                return View(modalidad);
            }

            var existeModalidad = await repositorioModalidad.ExisteModalidad(modalidad.ModalidadNombre);

            if (existeModalidad)
            {
                ModelState.AddModelError("", $"La modalidad {modalidad.ModalidadNombre} ya existe.");
                return View(modalidad);
            }

            await repositorioModalidad.CrearModalidad(modalidad);

            return RedirectToAction("Modalidad");
        }
        [HttpGet]
        public async Task<IActionResult> EditarModalidad(int modalidadId)
        {
            var modalidad = await repositorioModalidad.ObtenerModalidaPorId(modalidadId);

            if (modalidad is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            return View(modalidad);
        }
        [HttpPost]
        public async Task<IActionResult> EditarModalidad(Modalidad modalidad)
        {
            if (!ModelState.IsValid)
            {
                return View(modalidad);
            }

            var existeModalidad = await repositorioModalidad.ObtenerModalidaPorId(modalidad.ModalidadId);

            if (existeModalidad is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            await repositorioModalidad.EditarModalidad(modalidad);
            return RedirectToAction("Modalidad");
        }
    }
}
