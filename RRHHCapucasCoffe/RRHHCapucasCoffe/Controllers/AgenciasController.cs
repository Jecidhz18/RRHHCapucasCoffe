using Microsoft.AspNetCore.Mvc;

namespace RRHHCapucasCoffe.Controllers
{
    public class AgenciasController : Controller
    {
        public AgenciasController() 
        {
            
        }

        public IActionResult Agencia()
        {
            return View();
        }
    }
}
