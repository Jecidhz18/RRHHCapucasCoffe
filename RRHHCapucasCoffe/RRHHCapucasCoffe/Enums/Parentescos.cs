using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Enums
{
    public enum Parentescos
    {
        Padre = 1,
        Madre = 2,
        [Display(Name = "Hijo(a)")]
        Hijoa = 3,
        [Display(Name = "Hermano(a)")]
        Hermanoa = 4,
        [Display(Name = "Tío(a)")]
        Tioa = 5
    }
}
