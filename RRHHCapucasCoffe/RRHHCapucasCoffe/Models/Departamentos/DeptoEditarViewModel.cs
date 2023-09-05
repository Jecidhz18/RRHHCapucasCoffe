using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Models.Departamentos
{
    public class DeptoEditarViewModel : Departamento
    {
        public IEnumerable<SelectListItem> Paises { get; set; }
        public int[] PaisId { get; set; }
        public IEnumerable<Pais> Pais { get; set; }
    }
}
