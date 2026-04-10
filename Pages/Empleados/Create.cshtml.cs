using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoSegundoParcial.Models;
using ProyectoSegundoParcial.Services;

namespace Proyecto_Segundo_Parcial.Pages.Empleados
{
    public class CreateModel : PageModel
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IDepartamentoService _departamentoService;

        public List<Departamento> Departamentos { get; set; } = new();

        [BindProperty]
        public Empleado Empleado { get; set; } = new();

        public CreateModel(IEmpleadoService empleadoService, IDepartamentoService departamentoService)
        {
            _empleadoService = empleadoService;
            _departamentoService = departamentoService;
        }

        public async Task OnGetAsync()
        {
            Departamentos = await _departamentoService.ObtenerTodosAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Departamentos = await _departamentoService.ObtenerTodosAsync();
                return Page();
            }

            try
            {
                await _empleadoService.CrearAsync(Empleado);
                return RedirectToPage("Index");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                Departamentos = await _departamentoService.ObtenerTodosAsync();
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al crear el empleado: " + ex.Message);
                Departamentos = await _departamentoService.ObtenerTodosAsync();
                return Page();
            }
        }
    }
}
