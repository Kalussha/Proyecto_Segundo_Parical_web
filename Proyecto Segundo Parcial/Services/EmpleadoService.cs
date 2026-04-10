using ProyectoSegundoParcial.Data;
using ProyectoSegundoParcial.Data;
using ProyectoSegundoParcial.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoSegundoParcial.Services
{
    public interface IEmpleadoService
    {
        Task<List<Empleado>> ObtenerTodosAsync();
        Task<Empleado> ObtenerPorIdAsync(int id);
        Task<Empleado> CrearAsync(Empleado empleado);
        Task<Empleado> ActualizarAsync(Empleado empleado);
        Task EliminarAsync(int id);
        Task<List<Empleado>> ObtenerPorDepartamentoAsync(int departamentoId);
    }

    public class EmpleadoService : IEmpleadoService
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Empleado>> ObtenerTodosAsync()
        {
            return await _context.Empleados
                .Include(e => e.Departamento)
                .OrderByDescending(e => e.FechaCreacion)
                .ToListAsync();
        }

        public async Task<Empleado> ObtenerPorIdAsync(int id)
        {
            return await _context.Empleados
                .Include(e => e.Departamento)
                .Include(e => e.Consultas)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Empleado> CrearAsync(Empleado empleado)
        {
            empleado.FechaCreacion = DateTime.Now;
            empleado.FechaActualizacion = DateTime.Now;
            _context.Empleados.Add(empleado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Error al crear el empleado. Verifique que el email no esté duplicado.", ex);
            }
            return empleado;
        }

        public async Task<Empleado> ActualizarAsync(Empleado empleado)
        {
            empleado.FechaActualizacion = DateTime.Now;
            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }

        public async Task EliminarAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Empleado>> ObtenerPorDepartamentoAsync(int departamentoId)
        {
            return await _context.Empleados
                .Where(e => e.DepartamentoId == departamentoId)
                .Include(e => e.Departamento)
                .ToListAsync();
        }
    }
}
