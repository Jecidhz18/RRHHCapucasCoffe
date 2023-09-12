using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Models.Empleados;

namespace RRHHCapucasCoffe.Controllers
{
    public class EmpleadosController : Controller
    {
        public EmpleadosController() 
        {

        }

        public ActionResult Empleado() 
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CrearEmpleado()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearEmpleado(EmpleadoCrearViewModel modelo)
        {
            return RedirectToAction("Empleado");
        }
    }
}
