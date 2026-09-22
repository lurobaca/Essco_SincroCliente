# Essco.Web

Es la aplicación ASP.NET Core Razor Pages de Syncro Cliente.

- **Debe contener:** páginas, PageModels, autenticación, autorización, composición y recursos frontend.
- **No debe contener:** SQL directo en vistas ni reglas empresariales que correspondan a Application.
- **Dependencias:** Essco.Application y Essco.Infrastructure.
- **Ejemplo:** `Pages/Employees/Edit.cshtml.cs` recibe Guardar empleado y delega la operación a `EmployeeService`.

