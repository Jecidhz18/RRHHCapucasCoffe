using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Services;

namespace RRHHCapucasCoffe.Controllers
{
    public class ProfesionesController : Controller
    {
        private readonly IRepositorioProfesion repositorioProfesion;
        private readonly IRepositorioUsuario repositorioUsuario;

        public ProfesionesController(IRepositorioProfesion repositorioProfesion, IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioProfesion = repositorioProfesion;
            this.repositorioUsuario = repositorioUsuario;
        }
        public async Task<IActionResult> Profesion()
        {
            var profesion = await repositorioProfesion.ObtenerProfesion();
            return View(profesion);
        }

        public IActionResult CrearProfesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearProfesion(Profesion profesion)
        {
            if (!ModelState.IsValid)
            {
                return View(profesion);
            }

            var existeProfesion = repositorioProfesion.ExisteProfesion(profesion.ProfesionNombre);

            if (existeProfesion == null)
            {
                ModelState.AddModelError("", $"La profesion {profesion.ProfesionNombre} ya existe!");
                return View(profesion);
            }

            var usuario = await repositorioUsuario.ObtenerUsuario();

            profesion.ProfesionFechaGrabo = DateTime.Now;
            profesion.ProfesionUsuarioGrabo = usuario.UsuarioId;

            await repositorioProfesion.CrearProfesion(profesion);

            return RedirectToAction("Profesion");
        }

        [HttpGet]
        public async Task<IActionResult> EditarProfesion(int profesionId)
        {
            var profesion = await repositorioProfesion.ObtenerProfesionPorId(profesionId);

            if (profesion is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            return View(profesion);
        }

        [HttpPost]
        public async Task<IActionResult> EditarProfesion(Profesion profesion)
        {
            var existeProfesion = await repositorioProfesion.ObtenerProfesionPorId(profesion.ProfesionId);

            if (existeProfesion is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            await repositorioProfesion.EditarProfesion(profesion);
            return RedirectToAction("Profesion");
        }

        [HttpGet]
        public async Task<IActionResult> EliminarProfesion(int profesionId)
        {
            var profesion = await repositorioProfesion.ObtenerProfesionPorId(profesionId);

            if (profesion is null)
            {
                RedirectToAction("NoEncontrado", "Home");
            }

            return View(profesion);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarProfesionSelect(int profesionId)
        {
            var profesion = await repositorioProfesion.ObtenerProfesionPorId(profesionId);

            if(profesion is null)
            {
                RedirectToAction("NoEncontrado","Home");
            }

            await repositorioProfesion.EliminarProfesion(profesionId);
            return RedirectToAction("Profesion");
        }
    }
}
