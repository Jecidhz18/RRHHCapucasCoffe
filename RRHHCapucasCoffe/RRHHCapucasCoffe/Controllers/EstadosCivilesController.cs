using Microsoft.AspNetCore.Mvc;

namespace RRHHCapucasCoffe.Controllers
{
    public class EstadosCivilesController : Controller
    {

        public IActionResult EstadoCivil()
        {
            return View();
        }

        public IActionResult CrearEstadoCivil()
        {
            return View();  
        }
    }
}
