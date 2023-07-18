using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Cargos;

namespace RRHHCapucasCoffe.Controllers
{
    public class CargosController : Controller
    {
        private readonly IRepositorioCargo repositorioCargo;
        private readonly IRepositorioUsuario repositorioUsuario;

        public CargosController(IRepositorioCargo repositorioCargo, IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioCargo = repositorioCargo;
            this.repositorioUsuario = repositorioUsuario;
        }

        public async Task<IActionResult> Cargo()
        {
            var cargo = await repositorioCargo.ObtenerCargo();
            return View(cargo);  
        }
        public IActionResult CrearCargo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearCargo(Cargo cargo)
        {
            if (!ModelState.IsValid)
            {
                return View(cargo);
            }

            var existeCargo = await repositorioCargo.ExisteCargo(cargo.CargoNombre);

            if (existeCargo) 
            {
                ModelState.AddModelError("",$"El cargo {cargo.CargoNombre} ya existe!");
                return View(cargo);
            }

            cargo.CargoUsuarioGrabo = await repositorioUsuario.ObtenerUsuario();
            cargo.CargoFechaGrabo = DateTime.Now;

            await repositorioCargo.CrearCargo(cargo);

            return RedirectToAction("Cargo");
        }

        [HttpGet]
        public async Task<IActionResult> EditarCargo(int cargoId)
        {
            var cargo = await repositorioCargo.ObtenerCargoPorId(cargoId);

            if (cargo is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            return View(cargo);
        }

        [HttpPost]
        public async Task<IActionResult> EditarCargo(Cargo cargo)
        {
            var existeCargo = await repositorioCargo.ObtenerCargoPorId(cargo.CargoId);

            if (existeCargo is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            await repositorioCargo.EditarCargo(cargo);
            return RedirectToAction("Cargo");
        }

        [HttpGet]
        public async Task<IActionResult> EliminarCargo(int cargoId)
        {
            var cargo = await repositorioCargo.ObtenerCargoPorId(cargoId);

            if (cargo is null)
            {
                return RedirectToAction("NoEncotrado", "Home");
            }

            return View(cargo);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarCargoSelect(int cargoId)
        {
            var cargo = await repositorioCargo.ObtenerCargoPorId(cargoId);

            if (cargo is null)
            {
                return RedirectToAction("NoEcontrado", "Home");
            }

            await repositorioCargo.EliminarCargo(cargoId);
            return RedirectToAction("Cargo");
        }
    }
}
