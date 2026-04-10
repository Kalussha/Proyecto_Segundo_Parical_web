# ?? Sistema de Gestión de Capital Humano

## Descripción
Sistema web profesional para la gestión integral de recursos humanos, desarrollado con **ASP.NET Core 8 con Razor Pages**, Entity Framework Core, y diseño moderno con animaciones.

---

## ?? Requisitos del Proyecto Implementados

? **1. Definición del Modelo**
- Clase correctamente definida con propiedades adecuadas (mínimo 6 campos)
- Modelos: `Empleado`, `Departamento`, `Consulta`
- Validaciones de datos integradas

? **2. Uso de Entity Framework**
- Creación, uso adecuado y funcional de `ApplicationDbContext`
- Configuración de relaciones (One-to-Many)
- Seed data inicial

? **3. Inyección de Dependencias**
- Servicios funcionales: `IEmpleadoService`, `IDepartamentoService`, `IConsultaService`
- Inyección configurada en `Program.cs`

? **4. Páginas Razz con Información Temática**
- 3 secciones principales:
  - **Empleados** (Alias, Consultas, Actualizaciones)
  - **Departamentos** 
  - **Consultas y Actualizaciones**
- Manejo de información referente a Capital Humano
- Dashboard con estadísticas

? **5. Diseño Profesional y Moderno**
- Animaciones suaves y transiciones
- Estilos inspirados en UIverse.io
- Layout responsivo con Bootstrap 5
- Paleta de colores profesional
- Iconos Font Awesome

? **6. Video de las Instituciones**
- Sistema completamente funcional
- Demostración visual en ejecución

? **7. Documentación del Código**
- Comentarios claros y estructurados
- Nombres de variables descriptivos
- Estructura modular y escalable

? **8. GitHub y Documentación**
- Readme completo (este archivo)
- Código fuente documentado
- Instrucciones de instalación

? **9. Género de la API**
- API Generadora: Integración completa con el Front End
- Consultas asincrónicas
- Manejo de relaciones

---

## ?? Inicio Rápido

### Instalación de Paquetes NuGet

```bash
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.0
dotnet add package AutoMapper --version 13.0.1
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
dotnet add package FluentValidation --version 11.9.0
```

### Configuración de la Base de Datos

1. **Actualizar la cadena de conexión** en `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CapitalHumanoDb;Trusted_Connection=true;MultipleActiveResultSets=true;"
}
```

2. **Crear las migraciones** (si es necesario):
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

3. **Ejecutar la aplicación**:
```bash
dotnet run
```

4. **Acceder a**: `https://localhost:5001`

---

## ?? Funcionalidades Principales

### 1. Dashboard
- **KPI Cards**: Métricas en tiempo real (Total Empleados, Departamentos, Consultas Pendientes)
- **Acciones Rápidas**: Botones directos para crear empleados, departamentos y consultas
- **Datos Recientes**: Tabla de empleados y consultas más recientes

### 2. Gestión de Empleados
- ? **Listar**: Visualizar todos los empleados con filtros
- ? **Crear**: Formulario completo con validaciones
- ?? **Editar**: Actualizar datos del empleado
- ??? **Detalles**: Vista completa con historial de consultas
- ??? **Eliminar**: Con confirmación

### 3. Gestión de Departamentos
- ?? Listado en tarjetas con estadísticas
- ?? Formularios de creación y edición
- ?? Vista de empleados por departamento
- ?? Presupuesto anual

### 4. Consultas y Actualizaciones
- ?? Sistema de consultas de empleados
- ??? Tipos de consulta (Alias, Consulta, Actualización, Otro)
- ?? Estados (Pendiente, En Proceso, Resuelta, Cerrada)
- ?? Sistema de respuestas

---

## ?? Características de Diseño

### Animaciones Incluidas
- **Float Animation**: Iconos flotantes
- **Fade In**: Transiciones suaves al cargar
- **Hover Effects**: Cambios en cards y botones
- **Slide In**: Alertas y notificaciones
- **Pulse Animation**: Badges pulsantes

### Paleta de Colores
- **Primario**: #0d6efd (Azul)
- **Éxito**: #198754 (Verde)
- **Advertencia**: #ffc107 (Amarillo)
- **Peligro**: #dc3545 (Rojo)
- **Información**: #0dcaf0 (Cyan)

### Tipografía
- Font: Segoe UI, Tahoma, Geneva, Verdana, sans-serif
- Peso: 400 (normal), 600 (semibold), 700 (bold)
- Tamaño: Responsivo según dispositivo

---

## ?? Estructura del Proyecto

```
Proyecto Segundo Parcial/
??? Data/
?   ??? ApplicationDbContext.cs
??? Models/
?   ??? Empleado.cs
?   ??? Departamento.cs
?   ??? Consulta.cs
??? Services/
?   ??? EmpleadoService.cs
?   ??? DepartamentoService.cs
?   ??? ConsultaService.cs
??? Pages/
?   ??? Index.cshtml (Dashboard)
?   ??? Shared/
?   ?   ??? _Layout.cshtml
?   ??? Empleados/
?   ?   ??? Index.cshtml
?   ?   ??? Create.cshtml
?   ?   ??? Edit.cshtml
?   ?   ??? Details.cshtml
?   ?   ??? Delete.cshtml
?   ??? Departamentos/
?   ?   ??? Index.cshtml
?   ?   ??? Create.cshtml
?   ?   ??? Edit.cshtml
?   ?   ??? Details.cshtml
?   ?   ??? Delete.cshtml
?   ??? Consultas/
?       ??? Index.cshtml
?       ??? Create.cshtml
?       ??? Edit.cshtml
?       ??? Details.cshtml
?       ??? Delete.cshtml
??? wwwroot/
?   ??? css/
?       ??? site.css
??? Program.cs
??? appsettings.json
```

---

## ?? Seguridad y Validaciones

- ? Validaciones en el servidor
- ? Validaciones en el cliente (HTML5)
- ? Mensajes de error personalizados
- ? Confirmación de eliminación
- ? Protección contra inyección SQL (EF Core)

---

## ?? Navegación

### Menú Principal
1. **Dashboard** - Resumen general
2. **Empleados** - Gestión de personal
3. **Departamentos** - Gestión de áreas
4. **Consultas** - Sistema de tickets/consultas

---

## ?? Ejemplos de Uso

### Crear un Empleado
1. Click en "Empleados" en el menú
2. Click en "Nuevo Empleado"
3. Completar formulario
4. Click en "Crear Empleado"

### Crear Departamento
1. Click en "Departamentos"
2. Click en "Nuevo Departamento"
3. Ingresar nombre, descripción y presupuesto
4. Click en "Crear Departamento"

### Registrar Consulta
1. Click en "Consultas"
2. Click en "Nueva Consulta"
3. Seleccionar empleado, tipo y estado
4. Ingresar asunto y descripción
5. Click en "Registrar Consulta"

---

## ?? Tecnologías Utilizadas

- **Framework**: ASP.NET Core 8
- **ORM**: Entity Framework Core 8
- **Frontend**: Razor Pages + Bootstrap 5
- **Database**: SQL Server (LocalDB)
- **Icons**: Font Awesome 6.4
- **Styling**: CSS3 con animaciones

---

## ?? Dependencias Principales

```
Microsoft.EntityFrameworkCore (8.0.0)
Microsoft.EntityFrameworkCore.SqlServer (8.0.0)
Microsoft.EntityFrameworkCore.Tools (8.0.0)
AutoMapper (13.0.1)
AutoMapper.Extensions.Microsoft.DependencyInjection (12.0.1)
FluentValidation (11.9.0)
Bootstrap (5.x)
Font Awesome (6.4.0)
```

---

## ?? Mejoras Futuras

- ?? Sistema de autenticación y autorización
- ?? Reportes avanzados y exportación a PDF/Excel
- ?? Notificaciones por correo
- ?? Aplicación móvil
- ?? Búsqueda y filtros avanzados
- ?? Análisis y gráficos estadísticos
- ?? Internacionalización (i18n)
- ?? Sistema de notificaciones en tiempo real

---

## ?? Soporte

Para soporte y consultas, contactar al equipo de desarrollo.

---

## ?? Licencia

Proyecto desarrollado como parte de evaluación académica.

---

**Desarrollado por**: Senior Developer  
**Versión**: 1.0  
**Fecha**: 2024  
**Framework**: .NET 8  
**Estado**: ? Completo y Funcional
