using Microsoft.AspNetCore.Mvc;

namespace RRHHCapucasCoffe.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Departamento()
        {
            return View();   
        }

        public IActionResult CrearDepartamento() 
        {
            return View();       
        }
    }
}
