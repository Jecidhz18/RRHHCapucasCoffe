using Azure;
using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.Empleados;
using static System.Net.Mime.MediaTypeNames;

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
        public IActionResult CrearEmpleado()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearEmpleado(EmpleadoCrearViewModel modelo)
        {
            return RedirectToAction("Empleado");
        }

        [HttpGet]
        public IActionResult PruebaEmpleados() 
        {
            return View();
        }


    }
}
