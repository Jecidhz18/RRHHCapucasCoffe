using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Models;

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

        [HttpPost]
        public IActionResult CrearMunicipio(Municipio municipio)
        {
            if (!ModelState.IsValid)
            {
                return View(municipio);
            }
            return View(municipio); 
        }

    }
}
