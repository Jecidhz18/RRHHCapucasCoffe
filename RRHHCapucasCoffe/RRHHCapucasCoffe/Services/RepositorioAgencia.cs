using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Agencias;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioAgencia : IRepositorioAgencia
    {
        private readonly string connectionString;

        public RepositorioAgencia(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public  async Task CrearAgencia(AgenciaCrearViewModel modelo)
        {
            using var connection = new SqlConnection(connectionString);

            var agenciaId = await connection.QuerySingleAsync<int>(
                @"INSERT INTO Agencias (AgenciaNombre, AgenciaActiva, AgenciaUsuarioGrabo, AgenciaFechaGrabo)
                VALUES (@AgenciaNombre, @AgenciaActiva, @AgenciaUsuarioGrabo, @AgenciaFechaGrabo)
                SELECT SCOPE_IDENTITY()", modelo);

            modelo.AgenciaId = agenciaId;
        }

        public async Task<bool> ExisteAgencia(string agenciaNombre)
        {
            using var connection = new SqlConnection(connectionString);

            var existeAgencia = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM Agencias
                WHERE AgenciaNombre = @AgenciaNombre", new { agenciaNombre });

            return existeAgencia == 1;
        }

        public async Task<IEnumerable<AgenciaViewModel>> ObtenerAgencia()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<AgenciaViewModel>(
                @"SELECT a.AgenciaId, a.AgenciaNombre, a.AgenciaActiva, a.AgenciaUsuarioGrabo, 
                         ug.UsuarioCuenta AS AUsuarioGrabo, a.AgenciaFechaGrabo
                FROM Agencias a
                INNER JOIN Usuarios ug ON ug.UsuarioId = a.AgenciaUsuarioGrabo");
        }

        public async Task<Agencia> ObtenerAgenciaPorId(int agenciaId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<Agencia>(
                @"SELECT AgenciaId, AgenciaNombre, AgenciaActiva
                FROM Agencias
                WHERE AgenciaId = @AgenciaId", new { agenciaId });
        }

        public async Task EditarAgencia(AgenciaEditarViewModel agencia)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"UPDATE Agencias
                SET AgenciaNombre = @AgenciaNombre, AgenciaActiva = @AgenciaActiva
                WHERE AgenciaId = @AgenciaId", agencia);
        }
    }
}
