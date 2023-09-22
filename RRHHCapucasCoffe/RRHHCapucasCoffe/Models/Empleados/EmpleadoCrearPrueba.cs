using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models.Empleados
{
    public class EmpleadoCrearPrueba
    {
        [Display(Name = "Esta es una foto de prueba")]
        public byte[] EmpleadoFotografia { get; set; }
    }
}
