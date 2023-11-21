using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Interfaces;

namespace RRHHCapucasCoffe.Controllers
{
    public class DeduccionesAplicadasController : Controller
    {
        private readonly IRepositorioDeduccionAplicada repositorioDeduccionAplicada;

        public DeduccionesAplicadasController(IRepositorioDeduccionAplicada repositorioDeduccionAplicada)
        {
            this.repositorioDeduccionAplicada = repositorioDeduccionAplicada;
        }

        [HttpGet]
        public IActionResult DeduccionAplicada()
        {
            return View();
        }
    }
}
