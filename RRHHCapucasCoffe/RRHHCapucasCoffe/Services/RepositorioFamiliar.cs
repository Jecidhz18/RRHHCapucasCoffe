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
                WHERE FamiliarIdentificacion = @FamiliarIdentificacion", new { familiarIdentificacion });
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

        public async Task EditarFamiliar(Familiar familiar)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"UPDATE Familiares
                SET FamiliarIdentificacion = @FamiliarIdentificacion, FamiliarNombre = @FamiliarNombre, FamiliarPrimerApellido = @FamiliarPrimerApellido,
                FamiliarSegundoApellido = @FamiliarSegundoApellido, FamiliarParentesco = @FamiliarParentesco, FamiliarTelefono = @FamiliarTelefono,
                FamiliarCelular = @FamiliarCelular
                WHERE FamiliarId = @FamiliarId", familiar);
        }

        public async Task EliminarFamiliar(int familiarId)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE FROM Familiares
                WHERE FamiliarId = @FamiliarId", new { familiarId });
        }

        public async Task<bool> VerificarReferenciaFamiliar(int familiarId)
        {
            using var connection = new SqlConnection(connectionString);

            var existeReferenciaFamiliar = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1
                FROM Familiares
                WHERE FamiliarId = @FamiliarId AND EXISTS (
	                SELECT 1 FROM Empleados 
	                WHERE FamiliarId = @FamiliarId)", new { familiarId });

            return existeReferenciaFamiliar == 1;
        }
    }
}
