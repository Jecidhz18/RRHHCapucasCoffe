using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Enums
{
    public enum DeduccionTiposCobros
    {
        [Display(Name = "Fijo")]
        Fijo = 1,
        [Display(Name = "Por Rango")]
        PorRango = 2,
        [Display(Name = "Variable")]
        Variable = 3
    }
}
