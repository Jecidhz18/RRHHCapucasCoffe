using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models.Municipios
{
    public class Municipio
    {
        public int MunicipioId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre del Municipio")]
        public string MunicipioNombre { get; set; }
        [Display(Name = "Activo")]
        public bool MunicipioActivo { get; set; }
    }
}
