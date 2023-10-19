using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RRHHCapucasCoffe.Entities;
using RRHHCapucasCoffe.Interfaces;
using RRHHCapucasCoffe.Models.Empleados;

namespace RRHHCapucasCoffe.Services
{
    public class RepositorioEmpleado : IRepositorioEmpleado
    {
        private readonly string connectionString;

        public RepositorioEmpleado(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<int> CrearEmpleado(Empleado empleado)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QuerySingleAsync<int>(
                @"INSERT INTO Empleados (EmpleadoIdentificacion, EmpleadoFotografia, EmpleadoNombre, EmpleadoPrimerApellido,
	                EmpleadoSegundoApellido, EmpleadoSexo, EmpleadoDirNacimientoId, EmpleadoFechaNacimiento, EmpleadoEdad, EstadoCivilId,
	                EmpleadoTelefono, EmpleadoCelular, EmpleadoDireccion, EmpleadoDireccionId, EmpleadoEmail, FamiliarId, ProfesionId,
	                EmpleadoFechaIngreso, EmpleadoFechaContrato, EmpleadoActivo, EmpleadoUsuarioGrabo, EmpleadoFechaGrabo)
                VALUES (@EmpleadoIdentificacion, @EmpleadoFotografia, @EmpleadoNombre, @EmpleadoPrimerApellido,
	                @EmpleadoSegundoApellido, @EmpleadoSexo, @EmpleadoDirNacimientoId, @EmpleadoFechaNacimiento, @EmpleadoEdad, @EstadoCivilId,
	                @EmpleadoTelefono, @EmpleadoCelular, @EmpleadoDireccion, @EmpleadoDireccionId, @EmpleadoEmail, @FamiliarId, @ProfesionId,
	                @EmpleadoFechaIngreso, @EmpleadoFechaContrato, @EmpleadoActivo, @EmpleadoUsuarioGrabo, @EmpleadoFechaGrabo)
	            SELECT SCOPE_IDENTITY();", empleado);
        }
        public async Task<bool> ExisteEmpleado(string empleadoIdentificacion)
        {
            using var connection = new SqlConnection(connectionString);

            var existeEmpleado = await connection.QueryFirstOrDefaultAsync<int>(
                @"SELECT 1 FROM Empleados
                WHERE EmpleadoIdentificacion = @EmpleadoIdentificacion", new { empleadoIdentificacion });

            return existeEmpleado == 1;
        }

        public async Task<IEnumerable<EmpleadoViewModel>> ObtenerEmpleado()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<EmpleadoViewModel>(
                @"SELECT * FROM Empleados");
        }

    }
}
