using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoSegundoParcial.Models;
using ProyectoSegundoParcial.Services;

namespace Proyecto_Segundo_Parcial.Pages.Empleados
{
    public class EditModel : PageModel
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IDepartamentoService _departamentoService;

        public List<Departamento> Departamentos { get; set; } = new();

        [BindProperty]
        public Empleado Empleado { get; set; }

        public EditModel(IEmpleadoService empleadoService, IDepartamentoService departamentoService)
        {
            _empleadoService = empleadoService;
            _departamentoService = departamentoService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Empleado = await _empleadoService.ObtenerPorIdAsync(id.Value);
            if (Empleado == null)
                return NotFound();

            Departamentos = await _departamentoService.ObtenerTodosAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Departamentos = await _departamentoService.ObtenerTodosAsync();
                return Page();
            }

            await _empleadoService.ActualizarAsync(Empleado);
            return RedirectToPage("Index");
        }
    }
}
