using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Agencias;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioAgenciaUnidad : IRepositorioAgenciaUnidad
    {
        private readonly string connectionString;

        public RepositorioAgenciaUnidad(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task InsertarAgenciaUnidad(AgenciaCrearViewModel modelo)
        {
            using var connection = new SqlConnection(connectionString);

            for (int i = 0; i < modelo.UnidadId.Count(); i++)
            {
                await connection.ExecuteAsync(
                    @"INSERT INTO AgenciasUnidades (AgenciaId, UnidadId)
                    VALUES (@AgenciaId, @UnidadId)", new 
                    {
                        modelo.AgenciaId,
                        UnidadId = modelo.UnidadId[i]
                    });
            }
        }

        public async Task<IEnumerable<Unidad>> ObtenerUnidadPorAgencia(int agenciaId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Unidad>(
                @"SELECT au.UnidadId, u.UnidadDescripcion
                FROM AgenciasUnidades au
                INNER JOIN Unidades u ON au.UnidadId = u.UnidadId
                WHERE au.AgenciaId = @AgenciaId", new { agenciaId });
        }

        public async Task EliminarAgenciaUnidad(int agenciaId)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE FROM AgenciasUnidades
                WHERE AgenciaId = @AgenciaId", new { agenciaId });
        }

        public async Task InsertarAgenciaUnidadPorAgencia(AgenciaEditarViewModel modelo)
        {
            using var connection = new SqlConnection(connectionString);

            for (int i = 0; i < modelo.UnidadId.Count(); i++)
            {
                await connection.ExecuteAsync(
                    @"INSERT INTO AgenciasUnidades (AgenciaId, UnidadId)
                    VALUES (@AgenciaId, @UnidadId)", new
                    {
                        modelo.AgenciaId,
                        UnidadId = modelo.UnidadId[i]
                    });
            }
        }
    }
}
