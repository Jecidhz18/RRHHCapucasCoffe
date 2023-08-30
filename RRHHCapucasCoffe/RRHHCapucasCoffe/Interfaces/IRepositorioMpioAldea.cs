using RRHHCapucasCoffe.Models.Aldeas;

namespace RRHHCapucasCoffe.Interfaces
{
    public interface IRepositorioMpioAldea
    {
        Task InsertarMpioAldea(AldeaCrearViewModel mpioAldea);
    }
}
