using Microsoft.EntityFrameworkCore;
using ProyectoSegundoParcial.Data;
using ProyectoSegundoParcial.Services;

// Punto de entrada principal de la aplicación.
// Configura los servicios, la base de datos, la inyección de dependencias y el middleware.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

// Agregar DbContext
// Configuración de Entity Framework Core utilizando SQL Server.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions => {
            sqlOptions.EnableRetryOnFailure();
        }));

// Agregar servicios
// Registro de interfaces y clases concretas para la Inyección de Dependencias (DI).
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IConsultaService, ConsultaService>();

var app = builder.Build();

// Crear base de datos y aplicar tareas asíncronas de entity framework
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
