using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioFamiliar : IRepositorioFamiliar
    {
        private readonly string connectionString;

        public RepositorioFamiliar(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Familiar> ObtenerFamiliarPorIdentificacion(string familiarIdentificacion)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<Familiar>(
                @"SELECT * FROM Familiares
                WHERE FamiliarIdentificacion = @FamiliarIdentificacion", new { familiarIdentificacion});
        }

        public async Task<int> CrearFamiliar(Familiar familiar)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QuerySingleAsync<int>(
                @"INSERT INTO Familiares 
                (FamiliarIdentificacion, FamiliarNombre, FamiliarPrimerApellido, FamiliarSegundoApellido, FamiliarParentesco, FamiliarTelefono, FamiliarCelular)
                VALUES (@FamiliarIdentificacion, @FamiliarNombre, @FamiliarPrimerApellido, @FamiliarSegundoApellido, @FamiliarParentesco, @FamiliarTelefono, @FamiliarCelular)
                SELECT SCOPE_IDENTITY()", familiar);
        }

        public async Task<Familiar> ObtenerFamiliarPorId(int familiarId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<Familiar>(
                @"SELECT * FROM Familiares
                WHERE FamiliarId = @FamiliarId", new { familiarId });
        }
    }
}
