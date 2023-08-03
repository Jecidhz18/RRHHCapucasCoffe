using RRHHCapucasCoffe.Interfaces;


namespace RRHHCapucasCoffe.Services
{
    public class RepositorioMunicipio : IRepositorioMunicipio
    {
        private readonly string connectionString;

        public RepositorioMunicipio(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }


    }
}
