using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoSegundoParcial.Models;
using ProyectoSegundoParcial.Services;

namespace Proyecto_Segundo_Parcial.Pages.Consultas
{
    public class EditModel : PageModel
    {
        private readonly IConsultaService _consultaService;
        private readonly IEmpleadoService _empleadoService;

        public List<Empleado> Empleados { get; set; } = new();

        [BindProperty]
        public Consulta Consulta { get; set; }

        public EditModel(IConsultaService consultaService, IEmpleadoService empleadoService)
        {
            _consultaService = consultaService;
            _empleadoService = empleadoService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Consulta = await _consultaService.ObtenerPorIdAsync(id.Value);
            if (Consulta == null)
                return NotFound();

            Empleados = await _empleadoService.ObtenerTodosAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Empleados = await _empleadoService.ObtenerTodosAsync();
                return Page();
            }

            await _consultaService.ActualizarAsync(Consulta);
            return RedirectToPage("Index");
        }
    }
}
