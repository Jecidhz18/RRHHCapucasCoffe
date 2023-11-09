using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Enums;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Deducciones;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace RRHHCapucasCoffe.Controllers
{
    public class DeduccionesController : Controller
    {
        private readonly IRepositorioDeduccion repositorioDeduccion;
        private readonly IMapper mapper;
        private readonly IRepositorioDeduccionCobro repositorioDeduccionCobro;
        private readonly IRepositorioUsuario repositorioUsuario;

        public DeduccionesController(IRepositorioDeduccion repositorioDeduccion, IMapper mapper, IRepositorioDeduccionCobro repositorioDeduccionCobro,
            IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioDeduccion = repositorioDeduccion;
            this.mapper = mapper;
            this.repositorioDeduccionCobro = repositorioDeduccionCobro;
            this.repositorioUsuario = repositorioUsuario;
        }

        public async Task<ActionResult> Deduccion()
        {
            var modelo = await repositorioDeduccion.ObtenerDeduccion();
            foreach (var item in modelo.ToList())
            {
                DeduccionTiposCobros tipoCobro = (DeduccionTiposCobros)item.DeduccionTipoCobro;
                DeduccionAplicaciones aplicacion = (DeduccionAplicaciones)item.DeduccionAplicacion;

                item.DTipoCobro = await GetDisplayNameEnum(tipoCobro);
                item.DAplicacion = await GetDisplayNameEnum(aplicacion);
            }
            return View(modelo);
        }
        [HttpGet]
        public IActionResult CrearDeduccion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearDeduccion([FromBody] DeduccionCrearViewModel modelo) 
        {
            var usuario = await repositorioUsuario.ObtenerUsuario();
            modelo.DeduccionUsuarioGrabo = usuario.UsuarioId;
            modelo.DeduccionFechaGrabo = DateTime.Now;

            var deduccion = new Deduccion();
            mapper.Map(modelo, deduccion);

            var deduccionId = await repositorioDeduccion.CrearDeduccion(deduccion);
            await repositorioDeduccionCobro.CrearDeduccionCobro(modelo.DeduccionCobros, deduccionId);

            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> EditarDeduccion(int deduccionId)
        {
            var modelo = new DeduccionEditarViewModel();

            var deduccion = await repositorioDeduccion.ObtenerDeduccionPorId(deduccionId);
            mapper.Map(deduccion, modelo);

            modelo.DeduccionesCobros = await repositorioDeduccionCobro.ObtenerDeduccionCobrosPorDeduccionId(deduccionId);

            return View(modelo);
        }
        [HttpPost]
        public async Task<IActionResult> EditarDeduccion([FromBody] DeduccionEditarViewModel modelo)
        {
            var deduccion = new Deduccion();
            mapper.Map(modelo, deduccion);
            var usuario = await repositorioUsuario.ObtenerUsuario();
            deduccion.DeduccionUsuarioModifico = usuario.UsuarioId;
            deduccion.DeduccionFechaModifico = DateTime.Now;

            await repositorioDeduccion.EditarDeduccion(deduccion);

            int[] deduccionCobroIds = modelo.DeduccionCobros.Select(x => x.DeduccionCobroId).ToArray();
            var deduccionCobroEditar = modelo.DeduccionCobros.Where(x => x.DeduccionCobroId != 0).ToList();
            var deduccionCobroCrear = modelo.DeduccionesCobros.Where(x => x.DeduccionCobroId == 0).ToList();

            await repositorioDeduccionCobro.EliminarDeduccionCobro(deduccionCobroIds, modelo.DeduccionId);
            await repositorioDeduccionCobro.CrearDeduccionCobro(deduccionCobroCrear, modelo.DeduccionId);
            await repositorioDeduccionCobro.EditarDeduccionCobro(deduccionCobroEditar, modelo.DeduccionId);

            return Ok();
        }

        private async Task<string> GetDisplayNameEnum(Enum value)
        {
            return await Task.Run(() =>
            {
                var fieldInfo = value.GetType().GetField(value.ToString());

                if (fieldInfo == null) return null;

                var displayAttribute = (DisplayAttribute)fieldInfo.GetCustomAttributes(
                    typeof(DisplayAttribute), false
                ).FirstOrDefault();

                return displayAttribute?.Name ?? value.ToString();
            });
        }

    }
}
