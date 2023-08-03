using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Models.Paises;

namespace RRHHCapucasCoffe.Models.Municipios
{
    public class MunicipioViewModel : Municipio
    {
        public IEnumerable<SelectListItem> Paises { get; set; }
        public IEnumerable<SelectListItem> Departamentos { get; set; }
    }
}
