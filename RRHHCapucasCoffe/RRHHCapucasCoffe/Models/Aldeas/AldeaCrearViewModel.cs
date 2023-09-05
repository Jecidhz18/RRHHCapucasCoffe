using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Models.Aldeas
{
    public class AldeaCrearViewModel : Aldea
    {
        public IEnumerable<SelectListItem> Paises { get; set; }
        public IEnumerable<SelectListItem> Departamentos { get; set; }
        public IEnumerable<SelectListItem> Municipios { get; set; }
        public int[] PaisId { get; set; }
        public int[] DepartamentoId { get; set; }
        public int[] MunicipioId { get; set; }
    }
}
