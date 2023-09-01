using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Unidades;
using RRHHCapucasCoffe.Models.Usuarios;

namespace RRHHCapucasCoffe.Controllers
{
    public class UnidadesController : Controller
    {
        private readonly IRepositorioUnidad repositorioUnidad;
        private readonly IRepositorioUsuario repositorioUsuario;

        public UnidadesController(IRepositorioUnidad repositorioUnidad, IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUnidad = repositorioUnidad;
            this.repositorioUsuario = repositorioUsuario;
        }

        public async Task<IActionResult> Unidad()
        {
            var unidad = await repositorioUnidad.ObtenerUnidad();
            return View(unidad);  
        }

        public IActionResult CrearUnidad()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CrearUnidad(Unidad unidad)
        {
            if (!ModelState.IsValid)
            {
                return View(unidad);
            }

            var existeUnidad = await repositorioUnidad.ExisteUnidad(unidad.UnidadDescripcion);

            if (existeUnidad)
            {
                ModelState.AddModelError("", $"La unidad {unidad.UnidadDescripcion} ya existe!");
                return View(unidad);
            }

            var usuario = await repositorioUsuario.ObtenerUsuario();

            unidad.UnidadFechaGrabo = DateTime.Now;
            unidad.UnidadUsuarioGrabo = usuario.UsuarioId;
            await repositorioUnidad.CrearUnidad(unidad);

            return RedirectToAction("Unidad");
        }
        [HttpGet]
        public async Task<IActionResult> EditarUnidad(int unidadId)
        {
            var unidad = await repositorioUnidad.ObtenerUnidadPorId(unidadId);

            if (unidad is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            return View(unidad);
        }

        [HttpPost]
        public async Task<IActionResult> EditarUnidad(Unidad unidad)
        {
            var existeUnidad = await repositorioUnidad.ObtenerUnidadPorId(unidad.UnidadId);

            if (existeUnidad is null)
            {
                return RedirectToAction("NoEncontro", "Home");
            }

            var usuario = await repositorioUsuario.ObtenerUsuario();

            unidad.UnidadUsuarioModifico = usuario.UsuarioId;
            unidad.UnidadFechaModifico = DateTime.Now;

            await repositorioUnidad.EditarUnidad(unidad);
            return RedirectToAction("Unidad");
        }

        [HttpGet]
        public async Task<IActionResult> EliminarUnidad(int unidadId)
        {
            var unidad = await repositorioUnidad.ObtenerUnidadPorId(unidadId);

            if (unidad is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            return View(unidad);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarUnidadSelect(int unidadId)
        {
            var unidad = await repositorioUnidad.ObtenerUnidadPorId(unidadId);

            if(unidad is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            await repositorioUnidad.EliminarUnidad(unidadId);
            return RedirectToAction("Unidad");
        }
    }
}
