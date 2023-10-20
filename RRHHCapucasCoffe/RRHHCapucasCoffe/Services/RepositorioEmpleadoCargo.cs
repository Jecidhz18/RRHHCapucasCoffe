using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Empleados;
using RRHHCapucasCoffe.Models.EmpleadosCargos;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioEmpleadoCargo : IRepositorioEmpleadoCargo
    {
        private readonly string connectionString;

        public RepositorioEmpleadoCargo(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CrearEmpleadoCargo(List<EmpleadoCargo> empleadoCargos, int empleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            foreach (var empleadoCargo in empleadoCargos)
            {
                await connection.ExecuteAsync(
                    @"INSERT INTO EmpleadosCargos (EmpleadoId, CargoId, ModalidadId, EmpleadoCargoFechaInicio, EmpleadoCargoFechaFinal,
                        EmpleadoCargoSalario, EmpleadoCargoObs, EmpleadoCargoActivo)
                    VALUES (@EmpleadoId, @CargoId, @ModalidadId, @EmpleadoCargoFechaInicio, @EmpleadoCargoFechaFinal, @EmpleadoCargoSalario,
                        @EmpleadoCargoObs, @EmpleadoCargoActivo)", new
                    {
                        empleadoId, 
                        empleadoCargo.CargoId, 
                        empleadoCargo.ModalidadId,
                        empleadoCargo.EmpleadoCargoFechaInicio,
                        empleadoCargo.EmpleadoCargoFechaFinal,
                        empleadoCargo.EmpleadoCargoSalario,
                        empleadoCargo.EmpleadoCargoObs,
                        empleadoCargo.EmpleadoCargoActivo
                    });
            }
        }

        public async Task<IEnumerable<EmpleadoCargoViewModel>> ObtenerEmpleadoCargoPorEmpleadoId(int empleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<EmpleadoCargoViewModel>(
                @"SELECT ec.CargoId, c.CargoNombre, ec.ModalidadId, m.ModalidadNombre, ec.EmpleadoCargoFechaInicio, ec.EmpleadoCargoFechaFinal,
                    ec.EmpleadoCargoSalario, ec.EmpleadoCargoObs, ec.EmpleadoCargoActivo
                FROM EmpleadosCargos ec
                INNER JOIN Cargos c ON c.CargoId = ec.CargoId
                INNER JOIN Modalidades m ON m.ModalidadId = ec.ModalidadId
                WHERE ec.EmpleadoId = @EmpleadoId", new { empleadoId });
        }
    }
}
