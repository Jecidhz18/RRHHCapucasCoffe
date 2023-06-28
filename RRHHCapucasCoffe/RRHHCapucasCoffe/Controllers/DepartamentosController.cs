using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Models;

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

        [HttpPost]
        public IActionResult CrearDepartamento(Departamento departamento)
        {
            if (!ModelState.IsValid)
            {
                return View(departamento);
            }

            return View(departamento);  
        }
    }
}
