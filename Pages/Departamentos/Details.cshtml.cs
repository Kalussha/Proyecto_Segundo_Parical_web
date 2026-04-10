using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoSegundoParcial.Models;
using ProyectoSegundoParcial.Services;

namespace Proyecto_Segundo_Parcial.Pages.Departamentos
{
    public class DetailsModel : PageModel
    {
        private readonly IDepartamentoService _departamentoService;

        public Departamento Departamento { get; set; }

        public DetailsModel(IDepartamentoService departamentoService)
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
    }
}
