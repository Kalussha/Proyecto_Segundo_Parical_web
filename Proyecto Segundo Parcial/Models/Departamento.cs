using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ProyectoSegundoParcial.Models
{
    public class Departamento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del departamento es requerido")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        public int? GerenteId { get; set; }

        [DataType(DataType.Currency)]
        public decimal PresupuestoAnual { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Relación
        [ValidateNever]
        public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
    }
}
