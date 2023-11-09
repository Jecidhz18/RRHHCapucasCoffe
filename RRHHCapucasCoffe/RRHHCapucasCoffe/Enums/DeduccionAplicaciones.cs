using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Enums
{
    public enum DeduccionAplicaciones
    {
        [Display(Name = "Obligatoria")]
        Obligatoria = 1,
        [Display(Name = "Opcional")]
        Opcional = 2
    }
}
