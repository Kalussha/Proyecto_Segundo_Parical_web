using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoSegundoParcial.Models;
using ProyectoSegundoParcial.Services;

namespace Proyecto_Segundo_Parcial.Pages.Consultas
{
    public class IndexModel : PageModel
    {
        private readonly IConsultaService _consultaService;

        public List<Consulta> Consultas { get; set; } = new();

        public IndexModel(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        public async Task OnGetAsync()
        {
            Consultas = await _consultaService.ObtenerTodosAsync();
        }
    }
}
