using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Departamentos;

namespace RRHHCapucasCoffe.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly IRepositorioPais repositorioPais;
        private readonly IRepositorioDepartamento repositorioDepartamento;
        private readonly IRepositorioPaisDepto repositorioPaisDepto;
        private readonly IMapper mapper;

        public DepartamentosController(IRepositorioPais repositorioPais,
            IRepositorioDepartamento repositorioDepartamento, IRepositorioPaisDepto repositorioPaisDepto, IMapper mapper)
        {
            this.repositorioPais = repositorioPais;
            this.repositorioDepartamento = repositorioDepartamento;
            this.repositorioPaisDepto = repositorioPaisDepto;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Departamento()
        {
            var departamento = await repositorioDepartamento.ObtenerDepartamento();
            return View(departamento);
        }

        [HttpGet]
        public async Task<IActionResult> CrearDepartamento()
        {
            var modelo = new DeptoCrearViewModel();
            modelo.Paises = await ObtenerPaises();
            return View(modelo);
        }

        //Metodo privado para obtener paises
        private async Task<IEnumerable<SelectListItem>> ObtenerPaises()
        {
            var paises = await repositorioPais.ObtenerPaisActivo();

            return paises.Select(x => new SelectListItem(x.PaisNombre, x.PaisId.ToString()));
        }

        [HttpPost]
        public async Task<IActionResult> CrearDepartamento(DeptoCrearViewModel departamento)
        {
            if (!ModelState.IsValid)
            {
                departamento.Paises = await ObtenerPaises();
                return View(departamento);
            }

            if (departamento.PaisId == null)
            {
                ModelState.AddModelError("", $"Por favor, seleccione una opción en todos los campos antes de enviar los datos.");
                departamento.Paises = await ObtenerPaises();
                return View(departamento);
            }

            var existeDepto = await repositorioDepartamento.ExisteDepartamento(departamento.DepartamentoNombre);

            if (existeDepto)
            {
                ModelState.AddModelError("", $"El departamento {departamento.DepartamentoNombre} ya existe.");
                departamento.Paises = await ObtenerPaises();
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
            var modelo = mapper.Map<DeptoEditarViewModel>(departamento);
            modelo.Pais = await repositorioPais.ObtenerPaisPorDepto(departamentoId);
            modelo.Paises = await ObtenerPaises();

            if (modelo is null)
            {
                return RedirectToAction("NoEcontrado", "Home");
            }

            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> EditarDepartamento(DeptoEditarViewModel deptoPaises)
        {
            var existeDepto = await repositorioDepartamento.ObtenerDepartamentoPorId(deptoPaises.DepartamentoId);

            var modelo = mapper.Map<DeptoEditarViewModel>(deptoPaises);
            modelo.Paises = deptoPaises.Paises;
            modelo.Pais = deptoPaises.Pais;
            modelo.PaisId = deptoPaises.PaisId;

            if (!ModelState.IsValid)
            {
                modelo.Pais = await repositorioPais.ObtenerPaisPorDepto(modelo.DepartamentoId);
                modelo.Paises = await ObtenerPaises();
                return View(modelo);
            }

            if (modelo.PaisId == null)
            {
                ModelState.AddModelError("", $"Por favor, seleccione una opción en todos los campos antes de enviar los datos.");
                modelo.Pais = await repositorioPais.ObtenerPaisPorDepto(modelo.DepartamentoId);
                modelo.Paises = await ObtenerPaises();
                return View(modelo);
            }

            if (existeDepto is null)
            {
                RedirectToAction("NoEncontrado", "Home");
            }

            await repositorioDepartamento.EditarDepartamento(modelo);
            await repositorioPaisDepto.EliminarPaisDeptoPorDepto(modelo);
            await repositorioPaisDepto.InsertarPaisDeptoPorDepto(modelo);

            return RedirectToAction("Departamento");
        }

        //[HttpGet]
        //public async Task<IActionResult> EliminarDepartamento(int departamentoId)
        //{
        //    var departamento = await repositorioDepartamento.ObtenerDepartamentoPorId(departamentoId);
        //    var paisesDepto = await repositorioPais.ObtenerPaisPorDepto(departamentoId);

        //    var modelo = new DeptoViewModel();

        //    modelo.DepartamentoId = departamento.DepartamentoId;
        //    modelo.DepartamentoNombre = departamento.DepartamentoNombre;
        //    modelo.DepartamentoActivo = departamento.DepartamentoActivo;

        //    modelo.Pais = paisesDepto;

        //    if (modelo is null)
        //    {
        //        return RedirectToAction("NoEcontrado", "Home");
        //    }

        //    return View(modelo);
        //}

        //[HttpPost]
        //public async Task<IActionResult> EliminarDepartamentoSelect(DeptoViewModel deptoPais)
        //{
        //    var existeDepto = await repositorioDepartamento.ObtenerDepartamentoPorId(deptoPais.DepartamentoId);

        //    if (existeDepto is null)
        //    {
        //        RedirectToAction("NoEncontrado", "Home");
        //    }
        //    await repositorioPaisDepto.EliminarPaisDepto(deptoPais);
        //    await repositorioDepartamento.EliminarDepartamento(deptoPais.DepartamentoId);

        //    return RedirectToAction("Departamento");
        //}
    }
}
