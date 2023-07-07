using RRHHCapucasCoffe.Validators;
using System.ComponentModel.DataAnnotations;

namespace RRHHCapucasCoffe.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre del Departamento")]
        [PrimeraLetraMayusAtribute]
        [TodoMayusculaAtribute]
        [RegularExpression(@"^[A-Z+a-z ]*$", ErrorMessage = "Caracteres no validos")]
        public string DepartamentoNombre { get; set; }
        [Display(Name = "Activo")]
        public bool DepartamentoActivo { get; set; }

        //public virtual ICollection<PaisesDeptos> PaisesDeptos { get; set; }

        //public Departamento(ICollection<PaisesDeptos> paisesDeptos)
        //{
        //    PaisesDeptos = paisesDeptos;
        //}
    }
}

