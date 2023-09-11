using RRHHCapucasCoffe.Interfaces;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioAgencia : IRepositorioAgencia
    {
        private readonly string connectionString;

        public RepositorioAgencia(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }


    }
}
