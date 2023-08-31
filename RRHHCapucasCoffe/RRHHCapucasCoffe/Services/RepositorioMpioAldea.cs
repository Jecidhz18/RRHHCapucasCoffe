using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Aldeas;
using RRHHCapucasCoffe.Models.Departamentos;

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
            using var connection = new SqlConnection(connectionString);

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

        public async Task<IEnumerable<PaisDeptoMpioViewModel>> ObtenerPaisDeptoMpioPorAldea(int aldeaId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<PaisDeptoMpioViewModel>(
                @"SELECT ma.PaisId, p.PaisNombre, ma.DepartamentoId, d.DepartamentoNombre, ma.MunicipioId, m.MunicipioNombre
                FROM DpMpiosAldeas ma
                INNER JOIN DpPaises p ON ma.PaisId = p.PaisId
                INNER JOIN DpDepartamentos d ON ma.DepartamentoId = d.DepartamentoId
                INNER JOIN DpMunicipios m ON ma.MunicipioId = m.MunicipioId
                WHERE ma.AldeaId = @AldeaId", new { aldeaId });
        }

        public async Task EliminarPaisDeptoMpioPorAldea(AldeaEditarViewModel modelo)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE FROM DpMpiosAldeas
                WHERE AldeaId = @AldeaId", new {modelo.AldeaId});
        }

        public async Task InsertarPaisDeptoMpioAldea(AldeaEditarViewModel modelo)
        {
            using var connection = new SqlConnection(connectionString);

            for (int i = 0; i < modelo.PaisId.Count(); i++)
            {
                await connection.ExecuteAsync(
                    @"INSERT INTO DpMpiosAldeas (PaisId, DepartamentoId, MunicipioId, AldeaId)
                    VALUES (@PaisId, @DepartamentoId, @MunicipioId, @AldeaId)", 
                    new { PaisId = modelo.PaisId[i], DepartamentoId = modelo.DepartamentoId[i], MunicipioId = modelo.MunicipioId[i], modelo.AldeaId });
            }
        }
    }
}
