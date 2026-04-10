using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoSegundoParcial.Models;
using ProyectoSegundoParcial.Services;

namespace Proyecto_Segundo_Parcial.Pages.Consultas
{
    public class DetailsModel : PageModel
    {
        private readonly IConsultaService _consultaService;

        public Consulta Consulta { get; set; }

        public DetailsModel(IConsultaService consultaService)
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
    }
}
