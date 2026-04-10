using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoSegundoParcial.Models;
using ProyectoSegundoParcial.Services;

namespace Proyecto_Segundo_Parcial.Pages.Empleados
{
    public class IndexModel : PageModel
    {
        private readonly IEmpleadoService _empleadoService;

        public List<Empleado> Empleados { get; set; } = new();

        public IndexModel(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        public async Task OnGetAsync()
        {
            Empleados = await _empleadoService.ObtenerTodosAsync();
        }
    }
}
