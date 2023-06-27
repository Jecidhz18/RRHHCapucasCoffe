using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Models;

namespace RRHHCapucasCoffe.Controllers
{
    public class PaisesController : Controller
    {
        public IActionResult Pais()
        {
            return View();
        }

        public IActionResult CrearPais()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearPais(Pais pais)
        {
            return View();
        }
    }
}
