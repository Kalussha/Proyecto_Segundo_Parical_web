using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ProyectoSegundoParcial.Models
{
    public class Consulta
    {
        public int Id { get; set; }

        [Required]
        public int EmpleadoId { get; set; }

        [Required(ErrorMessage = "El asunto es requerido")]
        [StringLength(150)]
        public string Asunto { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(1000)]
        public string Descripcion { get; set; }

        [Required]
        public TipoConsulta Tipo { get; set; }

        [Required]
        public EstadoConsulta Estado { get; set; } = EstadoConsulta.Pendiente;

        [StringLength(500)]
        public string Respuesta { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;

        // Relación
        [ValidateNever]
        public virtual Empleado Empleado { get; set; }
    }

    public enum TipoConsulta
    {
        Alias,
        Consulta,
        Actualizacion,
        Otro
    }

    public enum EstadoConsulta
    {
        Pendiente,
        EnProceso,
        Resuelta,
        Cerrada
    }
}
