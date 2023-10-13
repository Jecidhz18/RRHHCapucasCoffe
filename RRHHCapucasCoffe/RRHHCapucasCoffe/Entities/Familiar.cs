using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace RRHHCapucasCoffe.Entities
{
    public class Familiar
    {
        public int FamiliarId { get; set; }
        public string FamiliarIdentificacion { get; set; }
        public string FamiliarNombre { get; set; }
        public string FamiliarPrimerApellido { get; set; }
        public string FamiliarSegundoApellido { get; set; }
        public int? FamiliarParentesco { get; set; }
        public string FamiliarTelefono { get; set; }
        public string FamiliarCelular { get; set; }
    }
}
