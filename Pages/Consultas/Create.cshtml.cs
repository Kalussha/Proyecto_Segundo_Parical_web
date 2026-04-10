using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoSegundoParcial.Models;
using ProyectoSegundoParcial.Services;

namespace Proyecto_Segundo_Parcial.Pages.Consultas
{
    public class CreateModel : PageModel
    {
        private readonly IConsultaService _consultaService;
        private readonly IEmpleadoService _empleadoService;

        public List<Empleado> Empleados { get; set; } = new();

        [BindProperty]
        public Consulta Consulta { get; set; } = new();

        public CreateModel(IConsultaService consultaService, IEmpleadoService empleadoService)
        {
            _consultaService = consultaService;
            _empleadoService = empleadoService;
        }

        public async Task OnGetAsync()
        {
            Empleados = await _empleadoService.ObtenerTodosAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Empleados = await _empleadoService.ObtenerTodosAsync();
                return Page();
            }

            await _consultaService.CrearAsync(Consulta);
            return RedirectToPage("Index");
        }
    }
}
