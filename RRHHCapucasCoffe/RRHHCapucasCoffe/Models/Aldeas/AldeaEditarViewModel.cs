using Microsoft.AspNetCore.Mvc.Rendering;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Models.Municipios;

namespace RRHHCapucasCoffe.Models.Aldeas
{
    public class AldeaEditarViewModel : Aldea
    {
        //Coleccion para rellenar los select list
        public IEnumerable<SelectListItem> Paises { get; set; }
        public IEnumerable<SelectListItem> Departamentos { get; set; }
        public IEnumerable<SelectListItem> Municipios { get; set; }
        //Lista de Paises y Departamentos relacionados con el municipio
        public IEnumerable<PaisDeptoMpioViewModel> PaisDeptoMpio { get; set; }
        //Array de selecciones en el formulario
        public int[] PaisId { get; set; }
        public int[] DepartamentoId { get; set; }
        public int[] MunicipioId { get; set; }
    }
}
