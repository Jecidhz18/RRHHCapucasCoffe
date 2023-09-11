using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Models.Agencias
{
    public class AgenciaEditarViewModel : Agencia
    {
        public IEnumerable<SelectListItem> Unidades { get; set; }
        public IEnumerable<Unidad> Unidad { get; set; }
        public int[] UnidadId { get; set; }
    }
}
