using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Models.Departamentos;
using RRHHCapucasCoffe.Models.Paises;
using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models.Municipios
{
    public class MunicipioCrearViewModel : Municipio
    {
        [Range(1, maximum: int.MaxValue, ErrorMessage = "holaaaaaaaaaaaaaaaaaaaaa")]
        public IEnumerable<SelectListItem> Paises { get; set; }
        public IEnumerable<SelectListItem> Departamentos { get; set; }
        public int[] PaisId { get; set; }
        public int[] DepartamentoId { get; set; }
    }
}
