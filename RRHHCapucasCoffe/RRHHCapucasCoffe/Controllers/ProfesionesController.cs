using Microsoft.AspNetCore.Mvc;

namespace RRHHCapucasCoffe.Controllers
{
    public class ProfesionesController : Controller
    {
        public IActionResult Profesion()
        {
            return View();  
        }

        public IActionResult CrearProfesion()
        {
            return View();
        }
    }
}
