using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Models.Paises;

namespace RRHHCapucasCoffe.Models.Departamentos
{
    public class DeptoViewModel : Departamento
    {
        public IEnumerable<SelectListItem> Paises { get; set; }
        public int[] PaisId { get; set; }
        public IEnumerable<Pais> Pais { get; set; }
    }
}
