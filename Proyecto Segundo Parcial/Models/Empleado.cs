using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ProyectoSegundoParcial.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, MinimumLength = 3, 
            ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "El apellido debe tener entre 3 y 100 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido")]
        [RegularExpression(@"^[0-9\s\-\+\(\)]{7,20}$", ErrorMessage = "El formato del teléfono no es válido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El cargo es requerido")]
        [StringLength(50)]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "El departamento es requerido")]
        public int DepartamentoId { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salario { get; set; }

        [StringLength(500)]
        public string Observaciones { get; set; }

        [Required]
        public EstadoEmpleado Estado { get; set; } = EstadoEmpleado.Activo;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;

        // Relación
        [ValidateNever]
        public virtual Departamento Departamento { get; set; }
        [ValidateNever]
        public virtual ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
    }

    public enum EstadoEmpleado
    {
        Activo,
        Inactivo,
        LicenciaSinPago,
        Despedido
    }
}
