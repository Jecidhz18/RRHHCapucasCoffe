using Microsoft.AspNetCore.Mvc.Rendering;

namespace RRHHCapucasCoffe.Models
{
    public class DeptoCrearViewModel : Departamento
    {
        public IEnumerable<SelectListItem> Paises { get; set; }
        public int PaisId { get; set; }
        public int[] Ids { get; set; }
        public string DepartamentoNombre { get; set; }

    }
}
