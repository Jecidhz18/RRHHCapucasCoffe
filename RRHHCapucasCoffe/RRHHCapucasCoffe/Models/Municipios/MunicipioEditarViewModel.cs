using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Models.Departamentos;
using RRHHCapucasCoffe.Models.Paises;

namespace RRHHCapucasCoffe.Models.Municipios
{
    public class MunicipioEditarViewModel : Municipio
    {
        //Coleccion para rellenar los select list
        public IEnumerable<SelectListItem> Paises { get; set; }
        public IEnumerable<SelectListItem> Departamentos { get; set; }
        //Lista de Paises y Departamentos relacionados con el municipio
        public IEnumerable<PaisDeptoViewModel> PaisDepto { get; set; }
        //Array de selecciones en el formulario
        public int[] PaisId { get; set; }
        public int[] DepartamentoId { get; set; }
    }
}
