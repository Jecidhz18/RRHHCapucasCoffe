using RRHHCapucasCoffe.Interfaces;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioDeduccionAplicada : IRepositorioDeduccionAplicada
    {
        private readonly string connectionString;

        public RepositorioDeduccionAplicada(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
    }
}
