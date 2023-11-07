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
	                EmpleadoSegundoApellido, EmpleadoSexo, EmpleadoDirNacimientoId, EmpleadoFechaNacimiento, EstadoCivilId,
	                EmpleadoTelefono, EmpleadoCelular, EmpleadoDireccion, EmpleadoDireccionId, EmpleadoEmail, FamiliarId, ProfesionId,
	                EmpleadoFechaIngreso, EmpleadoFechaContrato, EmpleadoActivo, EmpleadoUsuarioGrabo, EmpleadoFechaGrabo)
                VALUES (@EmpleadoIdentificacion, @EmpleadoFotografia, @EmpleadoNombre, @EmpleadoPrimerApellido,
	                @EmpleadoSegundoApellido, @EmpleadoSexo, @EmpleadoDirNacimientoId, @EmpleadoFechaNacimiento, @EstadoCivilId,
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

        public async Task<Empleado> ObtenerEmpleadoPorId(int empleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<Empleado>(
                @"SELECT * FROM Empleados
                WHERE EmpleadoId = @EmpleadoId", new { empleadoId });
        }

        public async Task EditarEmpleado(Empleado empleado)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"UPDATE Empleados
                SET EmpleadoIdentificacion = @EmpleadoIdentificacion, EmpleadoFotografia = @EmpleadoFotografia, EmpleadoNombre = @EmpleadoNombre,
	                EmpleadoPrimerApellido = @EmpleadoPrimerApellido, EmpleadoSegundoApellido = @EmpleadoSegundoApellido, EmpleadoSexo = @EmpleadoSexo,
	                EmpleadoFechaNacimiento = @EmpleadoFechaNacimiento, EstadoCivilId = @EstadoCivilId, EmpleadoTelefono = @EmpleadoTelefono, 
                    EmpleadoCelular = @EmpleadoCelular, EmpleadoDireccion = @EmpleadoDireccion, EmpleadoEmail = @EmpleadoEmail,ProfesionId = @ProfesionId,
                    EmpleadoFechaIngreso = @EmpleadoFechaIngreso, EmpleadoFechaContrato = @EmpleadoFechaContrato, EmpleadoActivo = @EmpleadoActivo,
                    EmpleadoUsuarioModifico = @EmpleadoUsuarioModifico, EmpleadoFechaModifico = @EmpleadoFechaModifico
                WHERE EmpleadoId = @EmpleadoId", empleado);
        }
        //Metodo para obtener el empleado, en vez de traer las llaves foraneas tambien traemos el registro completo.
        public async Task<EmpleadoViewModel> ObtenerEmpleadoPorIdCompleto(int empleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<EmpleadoViewModel>(
                @"SELECT  e.EmpleadoId, e.EmpleadoIdentificacion, e.EmpleadoFotografia, e.EmpleadoNombre, e.EmpleadoPrimerApellido,
		                e.EmpleadoSegundoApellido, e.EmpleadoSexo, e.EmpleadoDirNacimientoId, e.EmpleadoFechaNacimiento, e.EstadoCivilId,
		                ec.EstadoCivilNombre, e.EmpleadoTelefono, e.EmpleadoCelular, e.EmpleadoDireccion, e.EmpleadoDireccionId,
		                dp.PaisNombre AS PaisRes, dd.DepartamentoNombre AS DepartamentoRes, dm.MunicipioNombre AS MunicipioRes,
		                da.AldeaNombre AS AldeaRes, e.EmpleadoEmail, e.FamiliarId, e.ProfesionId, p.ProfesionNombre, e.EmpleadoFechaIngreso,
		                e.EmpleadoFechaContrato, e.EmpleadoActivo, e.EmpleadoUsuarioGrabo,e.EmpleadoFechaGrabo, e.EmpleadoUsuarioModifico,
		                e.EmpleadoFechaModifico
                FROM Empleados e
                INNER JOIN EstadosCiviles ec ON ec.EstadoCivilId = e.EstadoCivilId
                INNER JOIN DireccionesEmpleados de ON de.DireccionEmpleadoId = e.EmpleadoDireccionId
                INNER JOIN Profesiones p ON p.ProfesionId = e.ProfesionId 
                INNER JOIN DpPaises dp ON dp.PaisId = de.PaisId
                INNER JOIN DpDepartamentos dd ON dd.DepartamentoId = de.DepartamentoId
                INNER JOIN DpMunicipios dm ON dm.MunicipioId = de.MunicipioId
                LEFT JOIN DpAldeas da ON da.AldeaId = de.AldeaId
                WHERE e.EmpleadoId = @EmpleadoId", new { empleadoId });
        }

        public async Task EliminarEmpleado(int empleadoId)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(
                @"DELETE FROM Empleados
                WHERE EmpleadoId = @EmpleadoId", new { empleadoId });
        }
    }
}
