using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoSegundoParcial.Models;
using ProyectoSegundoParcial.Services;

namespace Proyecto_Segundo_Parcial.Pages.Departamentos
{
    public class IndexModel : PageModel
    {
        private readonly IDepartamentoService _departamentoService;

        public List<Departamento> Departamentos { get; set; } = new();

        public IndexModel(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        public async Task OnGetAsync()
        {
            Departamentos = await _departamentoService.ObtenerTodosAsync();
        }
    }
}
