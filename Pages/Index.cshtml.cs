using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoSegundoParcial.Services;
using ProyectoSegundoParcial.Models;

namespace Proyecto_Segundo_Parcial.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IDepartamentoService _departamentoService;
        private readonly IConsultaService _consultaService;
        private readonly ILogger<IndexModel> _logger;

        public List<Empleado> Empleados { get; set; } = new();
        public List<Departamento> Departamentos { get; set; } = new();
        public List<Consulta> ConsultasRecientes { get; set; } = new();
        public int TotalEmpleados { get; set; }
        public int TotalDepartamentos { get; set; }
        public int ConsultasPendientes { get; set; }

        public IndexModel(IEmpleadoService empleadoService, 
            IDepartamentoService departamentoService,
            IConsultaService consultaService,
            ILogger<IndexModel> logger)
        {
            _empleadoService = empleadoService;
            _departamentoService = departamentoService;
            _consultaService = consultaService;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            try
            {
                Empleados = await _empleadoService.ObtenerTodosAsync();
                Departamentos = await _departamentoService.ObtenerTodosAsync();
                ConsultasRecientes = (await _consultaService.ObtenerTodosAsync()).Take(5).ToList();
                
                TotalEmpleados = Empleados.Count;
                TotalDepartamentos = Departamentos.Count;
                ConsultasPendientes = (await _consultaService.ObtenerPorEstadoAsync(EstadoConsulta.Pendiente)).Count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar datos del dashboard");
            }
        }
    }
}
