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
        public async Task<IActionResult> EditarDeduccion(int deduccionId)
        {

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
