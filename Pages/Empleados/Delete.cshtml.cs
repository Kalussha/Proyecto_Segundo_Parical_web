using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoSegundoParcial.Models;
using ProyectoSegundoParcial.Services;

namespace Proyecto_Segundo_Parcial.Pages.Empleados
{
    public class DeleteModel : PageModel
    {
        private readonly IEmpleadoService _empleadoService;

        public Empleado Empleado { get; set; }

        public DeleteModel(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Empleado = await _empleadoService.ObtenerPorIdAsync(id.Value);
            if (Empleado == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            await _empleadoService.EliminarAsync(id.Value);
            return RedirectToPage("Index");
        }
    }
}
