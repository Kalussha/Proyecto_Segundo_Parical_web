using ProyectoSegundoParcial.Data;
using ProyectoSegundoParcial.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoSegundoParcial.Services
{
    public interface IDepartamentoService
    {
        Task<List<Departamento>> ObtenerTodosAsync();
        Task<Departamento> ObtenerPorIdAsync(int id);
        Task<Departamento> CrearAsync(Departamento departamento);
        Task<Departamento> ActualizarAsync(Departamento departamento);
        Task EliminarAsync(int id);
    }

    public class DepartamentoService : IDepartamentoService
    {
        private readonly ApplicationDbContext _context;

        public DepartamentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> ObtenerTodosAsync()
        {
            return await _context.Departamentos
                .Include(d => d.Empleados)
                .OrderBy(d => d.Nombre)
                .ToListAsync();
        }

        public async Task<Departamento> ObtenerPorIdAsync(int id)
        {
            return await _context.Departamentos
                .Include(d => d.Empleados)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Departamento> CrearAsync(Departamento departamento)
        {
            departamento.FechaCreacion = DateTime.Now;
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();
            return departamento;
        }

        public async Task<Departamento> ActualizarAsync(Departamento departamento)
        {
            _context.Departamentos.Update(departamento);
            await _context.SaveChangesAsync();
            return departamento;
        }

        public async Task EliminarAsync(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento != null)
            {
                _context.Departamentos.Remove(departamento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
