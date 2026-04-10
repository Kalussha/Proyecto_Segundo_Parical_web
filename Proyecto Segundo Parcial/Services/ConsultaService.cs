using ProyectoSegundoParcial.Data;
using ProyectoSegundoParcial.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoSegundoParcial.Services
{
    public interface IConsultaService
    {
        Task<List<Consulta>> ObtenerTodosAsync();
        Task<Consulta> ObtenerPorIdAsync(int id);
        Task<Consulta> CrearAsync(Consulta consulta);
        Task<Consulta> ActualizarAsync(Consulta consulta);
        Task EliminarAsync(int id);
        Task<List<Consulta>> ObtenerPorEmpleadoAsync(int empleadoId);
        Task<List<Consulta>> ObtenerPorEstadoAsync(EstadoConsulta estado);
    }

    public class ConsultaService : IConsultaService
    {
        private readonly ApplicationDbContext _context;

        public ConsultaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Consulta>> ObtenerTodosAsync()
        {
            return await _context.Consultas
                .Include(c => c.Empleado)
                .OrderByDescending(c => c.FechaCreacion)
                .ToListAsync();
        }

        public async Task<Consulta> ObtenerPorIdAsync(int id)
        {
            return await _context.Consultas
                .Include(c => c.Empleado)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Consulta> CrearAsync(Consulta consulta)
        {
            consulta.FechaCreacion = DateTime.Now;
            consulta.FechaActualizacion = DateTime.Now;
            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();
            return consulta;
        }

        public async Task<Consulta> ActualizarAsync(Consulta consulta)
        {
            consulta.FechaActualizacion = DateTime.Now;
            _context.Consultas.Update(consulta);
            await _context.SaveChangesAsync();
            return consulta;
        }

        public async Task EliminarAsync(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta != null)
            {
                _context.Consultas.Remove(consulta);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Consulta>> ObtenerPorEmpleadoAsync(int empleadoId)
        {
            return await _context.Consultas
                .Where(c => c.EmpleadoId == empleadoId)
                .Include(c => c.Empleado)
                .OrderByDescending(c => c.FechaCreacion)
                .ToListAsync();
        }

        public async Task<List<Consulta>> ObtenerPorEstadoAsync(EstadoConsulta estado)
        {
            return await _context.Consultas
                .Where(c => c.Estado == estado)
                .Include(c => c.Empleado)
                .OrderByDescending(c => c.FechaCreacion)
                .ToListAsync();
        }
    }
}
