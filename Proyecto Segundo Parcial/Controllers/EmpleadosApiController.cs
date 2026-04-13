using Microsoft.AspNetCore.Mvc;
using ProyectoSegundoParcial.Models;
using ProyectoSegundoParcial.Services;

namespace ProyectoSegundoParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosApiController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadosApiController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        // GET: api/EmpleadosApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            var empleados = await _empleadoService.ObtenerTodosAsync();
            return Ok(empleados);
        }

        // GET: api/EmpleadosApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var empleado = await _empleadoService.ObtenerPorIdAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(empleado);
        }
    }
}
