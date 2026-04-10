using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoSegundoParcial.Models;
using ProyectoSegundoParcial.Services;

namespace Proyecto_Segundo_Parcial.Pages.Departamentos
{
    public class EditModel : PageModel
    {
        private readonly IDepartamentoService _departamentoService;

        [BindProperty]
        public Departamento Departamento { get; set; }

        public EditModel(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Departamento = await _departamentoService.ObtenerPorIdAsync(id.Value);
            if (Departamento == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _departamentoService.ActualizarAsync(Departamento);
            return RedirectToPage("Index");
        }
    }
}
