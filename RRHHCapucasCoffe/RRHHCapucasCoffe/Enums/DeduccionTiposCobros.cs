using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Enums
{
    public enum DeduccionTiposCobros
    {
        Fijo = 1,
        [Display(Name = "Por Rango")]
        PorRango = 2,
        Variable = 3
    }
}
