using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Cargos;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioCargo : IRepositorioCargo
    {
        private readonly string connectionString;

        public RepositorioCargo(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CrearCargo(Cargo cargo)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"INSERT INTO Cargos (CargoNombre, CargoActivo, CargoUsuarioGrabo, CargoFechaGrabo)
                VALUES (@CargoNombre, @CargoActivo, @CargoUsuarioGrabo, @CargoFechaGrabo)", cargo);
        }

        public async Task<bool> ExisteCargo(string cargoNombre)
        {
            using var connection = new SqlConnection(connectionString);

            var existeCargo = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM Cargos
                WHERE CargoNombre = @CargoNombre", new {cargoNombre});

            return existeCargo == 1;
        }

        public async Task<IEnumerable<CargoViewModel>> ObtenerCargo()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<CargoViewModel>(
                @"SELECT c.CargoId, c.CargoNombre, c.CargoActivo,
	                     c.CargoUsuarioGrabo, ug.UsuarioCuenta AS CUsuarioGrabo, c.CargoFechaGrabo
                FROM Cargos c
                INNER JOIN Usuarios ug ON ug.UsuarioId = c.CargoUsuarioGrabo");
        } 

        public async Task<Cargo> ObtenerCargoPorId(int cargoId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<Cargo>(
                @"SELECT CargoId, CargoNombre, CargoActivo, CargoUsuarioGrabo, CargoFechaGrabo
                FROM Cargos
                WHERE CargoId = @CargoId", new {cargoId});
        }

        public async Task EditarCargo(Cargo cargo)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"UPDATE Cargos
                SET CargoNombre = @CargoNombre, CargoActivo = @CargoActivo
                WHERE CargoId = @CargoId", cargo);
        }

        public async Task EliminarCargo(int cargoId)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE Cargos
                WHERE CargoId = @CargoId", new {cargoId});
        }

        public async Task<IEnumerable<Cargo>> ObtenerCargosActivos()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Cargo>(
                @"SELECT * FROM Cargos
                WHERE CargoActivo = '1'");
        }
    }
}
