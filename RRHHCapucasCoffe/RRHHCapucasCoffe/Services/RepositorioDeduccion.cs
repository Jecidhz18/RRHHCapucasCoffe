using RRHHCapucasCoffe.Interfaces;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioDeduccion : IRepositorioDeduccion
    {
        private readonly string connectionString;

        public RepositorioDeduccion(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
    }
}
