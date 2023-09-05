using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Entities;

namespace RRHHCapucasCoffe.Models.Departamentos
{
    public class DeptoCrearViewModel : Departamento
    {
        public IEnumerable<SelectListItem> Paises { get; set; }
        public int[] PaisId { get; set; }
    }
}
