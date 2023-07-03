using Microsoft.AspNetCore.Mvc;

namespace RRHHCapucasCoffe.Controllers
{
    public class RemuneracionesController : Controller
    {
        public IActionResult Remuneracion()
        {
            return View();
        }

        public IActionResult CrearRemuneracion()
        {
            return View();  
        }
    }
}
