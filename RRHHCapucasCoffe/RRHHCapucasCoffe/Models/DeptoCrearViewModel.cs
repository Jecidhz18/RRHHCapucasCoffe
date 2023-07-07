using Microsoft.AspNetCore.Mvc.Rendering;

namespace RRHHCapucasCoffe.Models
{
    public class DeptoCrearViewModel : Departamento
    {
        public IEnumerable<SelectListItem> Paises { get; set; }
    }
}
