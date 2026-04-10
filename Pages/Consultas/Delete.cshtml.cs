using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoSegundoParcial.Models;
using ProyectoSegundoParcial.Services;

namespace Proyecto_Segundo_Parcial.Pages.Consultas
{
    public class DeleteModel : PageModel
    {
        private readonly IConsultaService _consultaService;

        public Consulta Consulta { get; set; }

        public DeleteModel(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Consulta = await _consultaService.ObtenerPorIdAsync(id.Value);
            if (Consulta == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            await _consultaService.EliminarAsync(id.Value);
            return RedirectToPage("Index");
        }
    }
}
