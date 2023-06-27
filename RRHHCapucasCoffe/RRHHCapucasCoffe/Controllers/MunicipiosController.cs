using Microsoft.AspNetCore.Mvc;

namespace RRHHCapucasCoffe.Controllers
{
    public class MunicipiosController : Controller
    {
        public IActionResult Municipio()
        {
            return View();
        }
        public IActionResult CrearMunicipio()
        {
            return View();  
        }

    }
}
