using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Models.Agencias
{
    public class AgenciaCrearViewModel : Agencia
    {
        public IEnumerable<SelectListItem> Unidades { get; set; }
        public int[] UnidadId { get; set; }
    }
}
