using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Bancos;

namespace RRHHCapucasCoffe.Controllers
{
    public class BancosController : Controller
    {
        private readonly IRepositorioBanco repositorioBanco;
        private readonly IRepositorioUsuario repositorioUsuario;

        public BancosController(IRepositorioBanco repositorioBanco, IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioBanco = repositorioBanco;
            this.repositorioUsuario = repositorioUsuario;
        }

        public async Task<IActionResult> Banco()
        {
            var banco = await repositorioBanco.ObtenerBanco();
            return View(banco);
        }

        public IActionResult CrearBanco()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CrearBanco(Banco banco)
        {
            if (!ModelState.IsValid)
            {
                return View(banco);
            }

            var existeBanco = await repositorioBanco.ExisteBanco(banco.BancoNombre);
            
            if ( existeBanco )
            {
                ModelState.AddModelError("", $"El banco {banco.BancoNombre} ya existe!");
                return View(banco); 
            }

            banco.BancoUsuarioGrabo = await repositorioUsuario.ObtenerUsuario();
            banco.BancoFechaGrabo = DateTime.Now;
            banco.BancoUsuarioModifico = await repositorioUsuario.ObtenerUsuario();
            banco.BancoFechaModifico = DateTime.Now;

            await repositorioBanco.CrearBanco(banco);
            return RedirectToAction("Banco");
        }

        [HttpGet]
        public async Task<IActionResult> EditarBanco(int bancoId)
        {
            var unidad = await repositorioBanco.ObtenerBancoPorId(bancoId);

            if (unidad is null)
            {
                return RedirectToAction("NoEncontrado","Home");
            }
            return View(unidad);
        }
        [HttpPost]
        public async Task<IActionResult> EditarBanco(Banco banco)
        {
            var existeBanco = await repositorioBanco.ObtenerBancoPorId(banco.BancoId);

            if (existeBanco is null)
            {
                return NotFound();
            }

            banco.BancoUsuarioModifico = await repositorioUsuario.ObtenerUsuario();
            banco.BancoFechaModifico = DateTime.Now;

            await repositorioBanco.EditarBanco(banco);
            TempData.Remove("BancoId");

            return RedirectToAction("Banco");
        }

        [HttpGet]

        public async Task<IActionResult> EliminarBanco(int bancoId)
        {
            var banco = await repositorioBanco.ObtenerBancoPorId(bancoId);

            if (banco is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            return View(banco);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarBancoSelect(int bancoId)
        {
            var banco = await repositorioBanco.ObtenerBancoPorId(bancoId);

            if (banco is null)
            {
                return RedirectToAction("NoEncontrado","Home");
            }

            await repositorioBanco.EliminarBanco(bancoId);

            return RedirectToAction("Banco");
        }
    }
}
