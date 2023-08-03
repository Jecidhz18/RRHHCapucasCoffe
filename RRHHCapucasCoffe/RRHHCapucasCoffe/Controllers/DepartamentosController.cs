using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Departamentos;
using RRHHCapucasCoffe.Models.Paises;
using RRHHCapucasCoffe.Validators;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace RRHHCapucasCoffe.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly IRepositorioPais repositorioPais;
        private readonly IRepositorioDepartamento repositorioDepartamento;
        private readonly IRepositorioPaisDepto repositorioPaisDepto;

        public DepartamentosController(IRepositorioPais repositorioPais,
            IRepositorioDepartamento repositorioDepartamento, IRepositorioPaisDepto repositorioPaisDepto)
        {
            this.repositorioPais = repositorioPais;
            this.repositorioDepartamento = repositorioDepartamento;
            this.repositorioPaisDepto = repositorioPaisDepto;
        }

        public async Task<IActionResult> Departamento()
        {
            var departamento = await repositorioDepartamento.ObtenerDepartamento();
            return View(departamento);
        }

        [HttpGet]
        public async Task<IActionResult> CrearDepartamento()
        {
            var paises = await repositorioPais.ObtenerPaisActivo();
            var modelo = new DeptoViewModel();

            modelo.Paises = paises.Select(x => new SelectListItem(x.PaisNombre, x.PaisId.ToString()));
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> CrearDepartamento(DeptoViewModel departamento)
        {
            if (!ModelState.IsValid)
            {
                return View(departamento);
            }

            var existeDepto = await repositorioDepartamento.ExisteDepartamento(departamento.DepartamentoNombre);

            if (existeDepto)
            {
                ModelState.AddModelError("", $"El departamento {departamento.DepartamentoNombre} ya existe.");
                var paises = await repositorioPais.ObtenerPaisActivo();
                var modelo = new DeptoViewModel();

                departamento.Paises = paises.Select(x => new SelectListItem(x.PaisNombre, x.PaisId.ToString()));
                return View(departamento);
            }

            await repositorioDepartamento.CrearDepartamento(departamento);

            await repositorioPaisDepto.InsertarPaisDepto(departamento);

            return RedirectToAction("Departamento");
        }

        [HttpGet]
        public async Task<IActionResult> EditarDepartamento(int departamentoId)
        {
            var departamento = await repositorioDepartamento.ObtenerDepartamentoPorId(departamentoId);
            var paisesDepto = await repositorioPais.ObtenerPaisPorDepto(departamentoId);
            var paises = await repositorioPais.ObtenerPaisActivo();

            var modelo = new DeptoViewModel();

            modelo.DepartamentoId = departamento.DepartamentoId;
            modelo.DepartamentoNombre = departamento.DepartamentoNombre;
            modelo.DepartamentoActivo = departamento.DepartamentoActivo;

            modelo.Paises = paises.Select(x => new SelectListItem(x.PaisNombre, x.PaisId.ToString()));
            modelo.Pais = paisesDepto;

            if (modelo is null)
            {
                return RedirectToAction("NoEcontrado", "Home");
            }

            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> EditarDepartamento(DeptoViewModel deptoPais)
        {
            var existeDepto = await repositorioDepartamento.ObtenerDepartamentoPorId(deptoPais.DepartamentoId);

            if (existeDepto is null)
            {
                //if (deptoPais.PaisId is )
                //{

                //}
                RedirectToAction("NoEncontrado", "Home");
            }

            await repositorioDepartamento.EditarDepartamento(deptoPais);
            await repositorioPaisDepto.EliminarPaisDeptoPorDepto(deptoPais);
            await repositorioPaisDepto.InsertarPaisDeptoPorDepto(deptoPais);

            return RedirectToAction("Departamento");
        }

        [HttpGet]
        public async Task<IActionResult> EliminarDepartamento(int departamentoId)
        {
            var departamento = await repositorioDepartamento.ObtenerDepartamentoPorId(departamentoId);
            var paisesDepto = await repositorioPais.ObtenerPaisPorDepto(departamentoId);

            var modelo = new DeptoViewModel();

            modelo.DepartamentoId = departamento.DepartamentoId;
            modelo.DepartamentoNombre = departamento.DepartamentoNombre;
            modelo.DepartamentoActivo = departamento.DepartamentoActivo;

            modelo.Pais = paisesDepto;

            if (modelo is null)
            {
                return RedirectToAction("NoEcontrado", "Home");
            }

            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarDepartamentoSelect(DeptoViewModel deptoPais)
        {
            var existeDepto = await repositorioDepartamento.ObtenerDepartamentoPorId(deptoPais.DepartamentoId);

            if (existeDepto is null)
            {
                RedirectToAction("NoEncontrado", "Home");
            }
            await repositorioPaisDepto.EliminarPaisDepto(deptoPais);
            await repositorioDepartamento.EliminarDepartamento(deptoPais.DepartamentoId);

            return RedirectToAction("Departamento");
        }
    }
}
