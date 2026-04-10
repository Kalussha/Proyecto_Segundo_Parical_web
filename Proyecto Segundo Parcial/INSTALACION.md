# ?? Guía de Instalación y Configuración

## Prerrequisitos

- ? .NET 8 SDK instalado
- ? SQL Server LocalDB o SQL Server Express
- ? Visual Studio 2022 / VS Code
- ? Git (opcional)

---

## ?? Pasos de Instalación

### 1?? Clonar o descargar el proyecto

```bash
cd "ruta\del\proyecto"
```

### 2?? Restaurar paquetes NuGet

```bash
dotnet restore
```

o en Visual Studio:
- Click derecho en la solución ? "Restaurar paquetes de NuGet"

### 3?? Configurar la cadena de conexión

**Archivo**: `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CapitalHumanoDb;Trusted_Connection=true;MultipleActiveResultSets=true;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### 4?? Crear y actualizar la base de datos

**Opción A - Con Visual Studio:**
```bash
Add-Migration InitialCreate
Update-Database
```

**Opción B - Con CLI:**
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5?? Ejecutar la aplicación

**Opción A - Visual Studio:**
- Presionar `F5` o click en "Iniciar"

**Opción B - CLI:**
```bash
dotnet run
```

### 6?? Acceder a la aplicación

Abrir navegador en:
```
https://localhost:5001
```

---

## ??? Base de Datos

### Tablas creadas automáticamente:

1. **Departamentos**
   - Id (PK)
   - Nombre
   - Descripcion
   - GerenteId (nullable)
   - PresupuestoAnual
   - FechaCreacion

2. **Empleados**
   - Id (PK)
   - Nombre
   - Apellido
   - Email (Unique)
   - Telefono
   - Cargo
   - DepartamentoId (FK)
   - FechaIngreso
   - Salario
   - Observaciones
   - Estado (enum)
   - FechaCreacion
   - FechaActualizacion

3. **Consultas**
   - Id (PK)
   - EmpleadoId (FK)
   - Asunto
   - Descripcion
   - Tipo (enum)
   - Estado (enum)
   - Respuesta (nullable)
   - FechaCreacion
   - FechaActualizacion

### Datos iniciales (Seed):

```
Departamentos:
- Recursos Humanos ($50,000)
- Tecnología ($100,000)
- Ventas ($75,000)
- Finanzas ($60,000)
```

---

## ?? Troubleshooting

### Problema: "No se puede conectar a la BD"
**Solución:**
```bash
dotnet ef database update
```

### Problema: Puerto 5001 en uso
**Solución:**
1. Cambiar puerto en `Properties/launchSettings.json`
2. O encontrar y liberar el puerto

### Problema: Librería no encontrada
**Solución:**
```bash
dotnet restore
dotnet clean
dotnet build
```

### Problema: Migración fallida
**Solución:**
```bash
dotnet ef migrations remove
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## ?? Información de Puertos

| Servicio | Puerto | Protocolo |
|----------|--------|----------|
| HTTP | 5000 | HTTP |
| HTTPS | 5001 | HTTPS |
| LocalDB | 1433 | MSSQL |

---

## ?? Variables de Entorno (Opcional)

Para producción, crear archivo `.env`:

```
ASPNETCORE_ENVIRONMENT=Production
ASPNETCORE_URLS=https://localhost:5001
ConnectionStrings__DefaultConnection=Tu_Cadena_Conexion
```

---

## ?? Testing

Para verificar que todo funciona:

1. Ir a Dashboard
2. Crear un Departamento
3. Crear un Empleado
4. Crear una Consulta
5. Verificar en la BD con SQL Server Management Studio

---

## ?? Recursos Útiles

- [Documentación .NET 8](https://learn.microsoft.com/es-es/dotnet/core/whats-new/dotnet-8)
- [Entity Framework Core](https://learn.microsoft.com/es-es/ef/core/)
- [Razor Pages](https://learn.microsoft.com/es-es/aspnet/core/razor-pages/)
- [Bootstrap 5](https://getbootstrap.com/)
- [Font Awesome](https://fontawesome.com/)

---

## ? Verificación Final

Ejecutar:
```bash
dotnet build
```

Si no hay errores ?, la instalación fue exitosa ?

---

**¡Listo! Tu aplicación está lista para usar.**
