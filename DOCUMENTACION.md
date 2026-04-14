# Documentación de Desarrollo del Proyecto

## 1. Introducción
Este proyecto es una aplicación web desarrollada con el patrón **Razor Pages** utilizando **ASP.NET Core** (.NET 8 y C# 12). La finalidad principal de la aplicación es gestionar un sistema de **Consultas** o incidencias vinculadas a empleados.

## 2. Tecnologías y Herramientas Utilizadas
- **Backend:** C# 12, .NET 8, ASP.NET Core.
- **Frontend:** Razor Pages (HTML, CSS integrado).
- **Diseño UI:** Bootstrap 5, FontAwesome (para iconos), CSS personalizado (con gradientes y sombras).
- **Control de Versiones:** Git y GitHub.

## 3. Arquitectura del Proyecto
El proyecto sigue la arquitectura por defecto de ASP.NET Core Razor Pages, separando la lógica de las vistas a través de archivos `PageModel` (`.cshtml.cs`) y la interfaz en archivos Razor (`.cshtml`).

### Estructura Principal
- **/Pages:** Contiene todas las páginas de la aplicación web.
  - **/Shared:** Archivos compartidos como el diseño principal (`_Layout.cshtml`), donde se define la barra de navegación y los scripts globales.
  - **/Consultas:** Módulo central de nuestra aplicación que contiene el CRUD de la entidad Consulta.
    - `Index.cshtml`: Listado de consultas.
    - `Create.cshtml`: Formulario para registrar una nueva consulta.
    - `Details.cshtml`: Vista detallada de una consulta con su información completa, estado y respuesta.
    - `Edit.cshtml`: Interfaz para actualizar los datos.
    - `Delete.cshtml`: Confirmación para eliminar el registro.

## 4. Modelos de Datos (Entidades)
La estructura reflejada en las vistas incluye las siguientes entidades principales:

### `Consulta`
Representa un ticket o requerimiento de soporte.
- **Asunto:** Título breve.
- **Descripción:** Detalle del problema o consulta.
- **Tipo de Consulta:** Clasificado mediante un Enum (`Alias`, `Consulta`, `Actualización`, `Otro`).
- **Estado:** Seguimiento del ciclo de vida (`Pendiente`, `En Proceso`, `Resuelta`, `Cerrada`).
- **Respuesta:** Retroalimentación dada al empleado.
- **Fechas:** `FechaCreacion` y `FechaActualizacion`.
- **Relaciones:** Vinculado a un usuario de tipo `Empleado`.

### `Empleado`
Representa al usuario del sistema (identificado por `Nombre` y `Apellido`).

## 5. Diseño y Experiencia de Usuario (UX/UI)
- **Responsive Design:** Gracias a las clases de grid de Bootstrap (`col-md-6`, `col-lg-8`, etc.), la aplicación se adapta a diferentes tamaños de pantalla (móvil, tablet, escritorio).
- **Indicadores visuales:** Se utilizan *badges* de Bootstrap para resaltar el tipo de consulta (`bg-light`) y su severidad o estado (`bg-danger` para pendiente, `bg-success` para resuelta).
- **Detalles Visuales:** Las vistas como `Details` implementan tarjetas (`card`) con sombras y cabeceras con gradientes de color (`bg-gradient`) para ofrecer un aspecto moderno y limpio.

## 6. Flujo de Desarrollo Actual
1. **Creación de Modelos y Contexto de Datos:** Establecimiento de la base de datos (Ej. `ApplicationDbContext`).
2. **Scaffolding de Razor Pages:** Generación automática de vistas estándar.
3. **Personalización del Frontend:** Mejora de los formularios y las vistas detalladas con HTML/CSS a medida, reemplazando la vista genérica por una interfaz amigable.
4. **Control de Código Fuente (Git):** Archivos excluidos innecesarios (`.vs`, `bin`, `obj`) gracias al archivo `.gitignore` y sincronizados con el repositorio remoto alojado en GitHub.
