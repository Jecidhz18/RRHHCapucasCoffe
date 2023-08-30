using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Aldeas;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioMpioAldea : IRepositorioMpioAldea
    {
        private readonly string connectionString;

        public RepositorioMpioAldea(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task InsertarMpioAldea(AldeaCrearViewModel mpioAldea)
        {
            var connection = new SqlConnection(connectionString);

            for (int i = 0; i < mpioAldea.PaisId.Count(); i++)
            {
                await connection.ExecuteAsync(
                    @"INSERT INTO DpMpiosAldeas (PaisId, DepartamentoId, MunicipioId, AldeaId)
                    VALUES (@PaisId, @DepartamentoId, @MunicipioId, @AldeaId)",
                    new 
                    { 
                        PaisId = mpioAldea.PaisId[i], 
                        DepartamentoId = mpioAldea.DepartamentoId[i], 
                        MunicipioId = mpioAldea.MunicipioId[i],
                        mpioAldea.AldeaId
                    });
            }
        }
    }
}
