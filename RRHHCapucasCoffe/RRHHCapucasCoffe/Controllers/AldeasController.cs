using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Models;

namespace RRHHCapucasCoffe.Controllers
{
    public class AldeasController : Controller
    {
        public IActionResult Aldea()
        {
            return View();
        }
        public IActionResult CrearAldea()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearAldea(Aldea aldea)
        {
            return View();
        }
    }
}
