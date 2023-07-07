namespace RRHHCapucasCoffe.Models
{
    public class PaisesDeptos
    {
        public int PaisId { get; set; }
        public int DepartamentoId { get; set; }

        public virtual Pais Pais { get; set; }
        public virtual Departamento Departamento { get;}
    }
}
