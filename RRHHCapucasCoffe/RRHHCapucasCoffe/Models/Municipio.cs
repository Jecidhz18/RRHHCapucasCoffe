using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models
{
    public class Municipio
    {
        public int DivisionPoliticaMunicipioId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre del Municipio")]
        public string DivisionPoliticaMunicipioNombre { get; set; }
        [Display(Name = "Activo")]
        public bool DivisionPoliticaMunicipioActivo { get; set; }
    }
}
