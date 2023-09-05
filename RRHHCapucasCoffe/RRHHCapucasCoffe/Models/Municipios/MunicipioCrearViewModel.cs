using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Models.Municipios
{
    public class MunicipioCrearViewModel : Municipio
    {
        public IEnumerable<SelectListItem> Paises { get; set; }
        public IEnumerable<SelectListItem> Departamentos { get; set; }
        public int[] PaisId { get; set; }
        public int[] DepartamentoId { get; set; }
    }
}
