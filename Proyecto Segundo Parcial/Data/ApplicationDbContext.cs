using Microsoft.EntityFrameworkCore;
using ProyectoSegundoParcial.Models;

namespace ProyectoSegundoParcial.Data
{
    // Contexto de la base de datos de la aplicación.
    // Administra las conexiones a la base de datos SQL Server y mapea los modelos a tablas mediante Entity Framework.
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        // Configura el modelo y las relaciones usando Fluent API.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Departamento
            modelBuilder.Entity<Departamento>()
                .HasMany(d => d.Empleados)
                .WithOne(e => e.Departamento)
                .HasForeignKey(e => e.DepartamentoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar precisión para Departamento.PresupuestoAnual
            modelBuilder.Entity<Departamento>()
                .Property(d => d.PresupuestoAnual)
                .HasColumnType("decimal(18,2)");

            // Configuración de Empleado
            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Consultas)
                .WithOne(c => c.Empleado)
                .HasForeignKey(c => c.EmpleadoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar precisión para Empleado.Salario
            modelBuilder.Entity<Empleado>()
                .Property(e => e.Salario)
                .HasColumnType("decimal(18,2)");

            // Índices
            modelBuilder.Entity<Empleado>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<Departamento>()
                .HasIndex(d => d.Nombre)
                .IsUnique();

            // Datos iniciales
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Departamentos iniciales
            modelBuilder.Entity<Departamento>().HasData(
                new Departamento 
                { 
                    Id = 1, 
                    Nombre = "Recursos Humanos", 
                    Descripcion = "Departamento de gestión de recursos humanos",
                    PresupuestoAnual = 50000
                },
                new Departamento 
                { 
                    Id = 2, 
                    Nombre = "Tecnología", 
                    Descripcion = "Departamento de desarrollo y soporte tecnológico",
                    PresupuestoAnual = 100000
                },
                new Departamento 
                { 
                    Id = 3, 
                    Nombre = "Ventas", 
                    Descripcion = "Departamento comercial",
                    PresupuestoAnual = 75000
                },
                new Departamento 
                { 
                    Id = 4, 
                    Nombre = "Finanzas", 
                    Descripcion = "Departamento de gestión financiera",
                    PresupuestoAnual = 60000
                }
            );
        }
    }
}
