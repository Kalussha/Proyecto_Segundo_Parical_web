using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoSegundoParcial.Models;
using ProyectoSegundoParcial.Services;

namespace Proyecto_Segundo_Parcial.Pages.Departamentos
{
    public class CreateModel : PageModel
    {
        private readonly IDepartamentoService _departamentoService;

        [BindProperty]
        public Departamento Departamento { get; set; } = new();

        public CreateModel(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _departamentoService.CrearAsync(Departamento);
            return RedirectToPage("Index");
        }
    }
}
