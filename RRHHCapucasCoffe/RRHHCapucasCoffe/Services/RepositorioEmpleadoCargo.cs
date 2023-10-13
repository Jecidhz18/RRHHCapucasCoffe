using Dapper;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;

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
    }
}
