using RRHHCapucasCoffe.Models.Aldeas;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioMpioAldea
    {
        Task InsertarPaisDeptoMpioAldea(AldeaEditarViewModel modelo);
        Task EliminarPaisDeptoMpioPorAldea(AldeaEditarViewModel modelo);
        Task InsertarMpioAldea(AldeaCrearViewModel mpioAldea);
        Task<IEnumerable<PaisDeptoMpioViewModel>> ObtenerPaisDeptoMpioPorAldea(int aldeaId);
    }
}
