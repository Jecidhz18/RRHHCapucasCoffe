using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Abstractions;
using Microsoft.VisualBasic;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Agencias;

namespace RRHHCapucasCoffe.Controllers
{
    public class AgenciasController : Controller
    {
        private readonly IRepositorioUnidad repositorioUnidad;
        private readonly IRepositorioAgencia repositorioAgencia;
        private readonly IRepositorioAgenciaUnidad repositorioAgenciaUnidad;
        private readonly IRepositorioUsuario repositorioUsuario;
        private readonly IMapper mapper;

        public AgenciasController(IRepositorioUnidad repositorioUnidad, IRepositorioAgencia repositorioAgencia, 
            IRepositorioAgenciaUnidad repositorioAgenciaUnidad, IRepositorioUsuario repositorioUsuario, IMapper mapper) 
        {
            this.repositorioUnidad = repositorioUnidad;
            this.repositorioAgencia = repositorioAgencia;
            this.repositorioAgenciaUnidad = repositorioAgenciaUnidad;
            this.repositorioUsuario = repositorioUsuario;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Agencia()
        {
            var modelo = await repositorioAgencia.ObtenerAgencia();
            return View(modelo);
        }
        [HttpGet]
        public async Task<IActionResult> CrearAgencia()
        {
            var modelo = new AgenciaCrearViewModel();
            modelo.Unidades = await ObtenerUnidades();

            return View(modelo);
        }
        [HttpPost]
        public async Task<IActionResult> CrearAgencia(AgenciaCrearViewModel modelo)
        {
            var existeAgencia = await repositorioAgencia.ExisteAgencia(modelo.AgenciaNombre);

            if (!ModelState.IsValid)
            {
                modelo.Unidades = await ObtenerUnidades();
                return View(modelo);
            }

            if (modelo.UnidadId == null)
            {
                modelo.Unidades = await ObtenerUnidades();
                ModelState.AddModelError("", $"Seleccione una opción en todos los campo");
                return View(modelo);
            }

            if (existeAgencia)
            {
                ModelState.AddModelError("", $"La agencia {modelo.AgenciaNombre} ya existe");
                modelo.Unidades = await ObtenerUnidades();
                return View(modelo);
            }

            var usuario = await repositorioUsuario.ObtenerUsuario();

            modelo.AgenciaUsuarioGrabo = usuario.UsuarioId;
            modelo.AgenciaFechaGrabo = DateTime.Now;

            await repositorioAgencia.CrearAgencia(modelo);
            await repositorioAgenciaUnidad.InsertarAgenciaUnidad(modelo);

            return RedirectToAction("Agencia");
        }

        [HttpGet]
        public async Task<IActionResult> EditarAgencia(int agenciaId)
        {
            var existeAgencia = await repositorioAgencia.ObtenerAgenciaPorId(agenciaId);

            if (existeAgencia is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            var unidad = await repositorioAgenciaUnidad.ObtenerUnidadPorAgencia(agenciaId);

            var modelo = new AgenciaEditarViewModel();
            mapper.Map(existeAgencia, modelo);
            modelo.Unidad = mapper.Map<IEnumerable<Unidad>>(unidad);

            modelo.Unidades = await ObtenerUnidades();

            return View(modelo);
        }
        [HttpPost]
        public async Task<IActionResult> EditarAgencia(AgenciaEditarViewModel modelo)
        {
            var existeAgencia = await repositorioAgencia.ObtenerAgenciaPorId(modelo.AgenciaId);

            if (!ModelState.IsValid)
            {
                var unidad = await repositorioAgenciaUnidad.ObtenerUnidadPorAgencia(modelo.AgenciaId);
                modelo.Unidad = mapper.Map<IEnumerable<Unidad>>(unidad);
                modelo.Unidades = await ObtenerUnidades();
                return View(modelo);
            }

            if (existeAgencia is null)
            {
                return RedirectToAction("NoEncontrado", "Home");
            }

            if (modelo.UnidadId == null)
            {
                modelo.Unidades = await ObtenerUnidades();
                var unidad = await repositorioAgenciaUnidad.ObtenerUnidadPorAgencia(modelo.AgenciaId);
                modelo.Unidad = mapper.Map<IEnumerable<Unidad>>(unidad);
                modelo.Unidades = await ObtenerUnidades();
                return View(modelo);
            }

            await repositorioAgencia.EditarAgencia(modelo);
            await repositorioAgenciaUnidad.EliminarAgenciaUnidad(modelo.AgenciaId);
            await repositorioAgenciaUnidad.InsertarAgenciaUnidadPorAgencia(modelo);

            return RedirectToAction("Agencia");
        }

        //Metodo Privado para obtener unidades
        private async Task<IEnumerable<SelectListItem>> ObtenerUnidades()
        {
            var unidades = await repositorioUnidad.ObtenerUnidadActiva();

            return unidades.Select(x => new SelectListItem(x.UnidadDescripcion, x.UnidadId.ToString()));
        }
    }
}
