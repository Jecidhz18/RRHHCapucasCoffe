namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioEmpleado
    {
        Task<bool> ExisteEmpleado(string empleadoIdentificacion);
    }
}
