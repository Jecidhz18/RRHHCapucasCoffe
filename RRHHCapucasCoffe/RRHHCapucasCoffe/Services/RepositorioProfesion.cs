using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Profesiones;
using System.Security.Principal;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioProfesion : IRepositorioProfesion
    {
        private readonly string connectrionString;

        public RepositorioProfesion(IConfiguration configuration)
        {
            connectrionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CrearProfesion(Profesion profesion)
        {
            using var connection = new SqlConnection(connectrionString);

            var profesionaId = await connection.QuerySingleAsync<int>(
                @"INSERT INTO Profesiones (ProfesionNombre, ProfesionActivo, ProfesionUsuarioGrabo, ProfesionFechaGrabo)
                VALUES (@ProfesionNombre, @ProfesionActivo, @ProfesionUsuarioGrabo, @ProfesionFechaGrabo)
                SELECT SCOPE_IDENTITY();", profesion);

            profesion.ProfesionId = profesionaId;
        }

        public async Task<bool> ExisteProfesion(string profesionNombre)
        {
            using var connection = new SqlConnection(connectrionString);

            var existeProfesion = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM Profesiones
                WHERE ProfesionNombre = @ProfesionNombre;", new { profesionNombre });

            return existeProfesion == 1;
        }

        public async Task<IEnumerable<ProfesionViewModel>> ObtenerProfesion()
        {
            using var connection = new SqlConnection(connectrionString);

            return await connection.QueryAsync<ProfesionViewModel>(
                @"SELECT p.ProfesionId, p.ProfesionNombre, p.ProfesionActivo, 
                         ug.UsuarioCuenta AS PUsuarioGrabo, p.ProfesionFechaGrabo
                FROM Profesiones p
                INNER JOIN Usuarios ug ON ug.UsuarioId = p.ProfesionUsuarioGrabo");
        }

        public async Task<Profesion> ObtenerProfesionPorId(int profesionId)
        {
            using var connection = new SqlConnection(connectrionString);

            return await connection.QueryFirstOrDefaultAsync<Profesion>(
                @"SELECT ProfesionId, ProfesionNombre, ProfesionActivo
                FROM Profesiones
                WHERE ProfesionId = @ProfesionId", new {profesionId});
        }

        public async Task EditarProfesion(Profesion profesion)
        {
            using var connection = new SqlConnection(connectrionString);

            await connection.ExecuteAsync(
                @"Update Profesiones 
                SET ProfesionNombre = @ProfesionNombre, ProfesionActivo = @ProfesionActivo
                WHERE ProfesionId = @ProfesionId", profesion);
        }

        public async Task EliminarProfesion(int profesionId)
        {
            using var connection = new SqlConnection(connectrionString);

            await connection.ExecuteAsync(
                @"DELETE Profesiones
                WHERE ProfesionId = @ProfesionId", new {profesionId});
        }
    }
}
