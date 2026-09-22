# Guía práctica de arquitectura

Esta guía explica dónde buscar y cómo seguir el código de Syncro Cliente Web. Describe la solución actual; no declara paridad funcional con WinForms. El estado de cada módulo se mantiene en [MIGRATION_STATUS.md](MIGRATION_STATUS.md).

## Vista general

```text
Navegador
   ↓
Essco.Web (Razor Pages, autenticación y composición)
   ↓
Essco.Application (casos de uso e interfaces)
   ↓                         ↓
Essco.Domain                 Essco.Infrastructure
(entidades y reglas)         (SQL Server y adaptadores)
                                 ↓
                              SQL Server

Essco.Web → cola SAP → Essco.SapBridge.Worker → SAP Business One DI API
```

La Web no referencia componentes COM de SAP. `Essco.SapBridge.Worker` mantiene esa dependencia aislada para ejecutarse en Windows.

## Proyectos de la solución

| Proyecto | Responsabilidad | Dependencias principales |
|---|---|---|
| `Essco.Domain` | Entidades, estados y reglas puras del negocio. | Ningún proyecto interno. |
| `Essco.Application` | Casos de uso, servicios, contratos de repositorios, permisos y configuración tipada. | Domain y SapBridge.Contracts. |
| `Essco.Infrastructure` | Implementaciones SQL Server, seguridad persistente y adaptadores externos. | Application, Domain y SqlClient. |
| `Essco.Web` | Aplicación Razor Pages de Syncro Cliente: interfaz, PageModels, autenticación y composición de dependencias. | Application e Infrastructure. |
| `Essco.Portal` | Portal público/cliente de ESSCO, separado del ERP Syncro Cliente. | ASP.NET Core y su modelo de portal. |
| `Essco.SapBridge.Contracts` | Mensajes compartidos para solicitar y consultar trabajos SAP, sin COM. | Ninguna dependencia COM. |
| `Essco.SapBridge.Worker` | Servicio Windows que consume trabajos y ejecuta operaciones mediante SAP DI API. | Contracts y componentes SAP disponibles en Windows. |
| `Essco.Tests.Unit` | Pruebas rápidas de reglas, servicios y validadores con dobles de repositorio. | Domain y Application. |
| `Essco.Tests.Integration` | Pruebas de límites técnicos, persistencia o integraciones que requieren mayor composición. | Proyectos bajo prueba. |

## Carpetas principales

### Interfaz y entrada Web

- `src/Essco.Web/Pages`: páginas Razor. Cada `.cshtml` contiene presentación y su `.cshtml.cs` contiene las acciones HTTP.
- `src/Essco.Web/Pages/Shared`: layouts, parciales y componentes reutilizados.
- `src/Essco.Web/wwwroot/js`: JavaScript propio.
- `src/Essco.Web/wwwroot/css`: estilos y tokens visuales.
- `src/Essco.Web/Program.cs`: registro de dependencias, autenticación, autorización y pipeline HTTP.
- `src/Essco.Web/Security`: requisitos y handlers de autorización Web.

### Casos de uso y dominio

- `src/Essco.Application/<Módulo>`: servicios de aplicación e interfaces que necesita cada módulo.
- `src/Essco.Application/Security`: permisos y catálogo central del menú.
- `src/Essco.Application/Configuration`: opciones de configuración validadas al iniciar.
- `src/Essco.Domain/<Módulo>`: entidades y reglas que no deberían conocer HTTP, Razor ni SQL Server.

### Datos e integraciones

- `src/Essco.Infrastructure/Data`: repositorios SQL Server y consultas SQL parametrizadas.
- `src/Essco.Infrastructure/Security`: persistencia de usuarios y contraseñas.
- `src/Essco.SapBridge.Worker`: gateways DI API y procesamiento en segundo plano.
- `src/Essco.SapBridge.Contracts`: contratos que conectan la Web con el worker sin compartir COM.
- `sql`: scripts versionados de esquema y compatibilidad. Verifique el documento del módulo antes de ejecutar uno.

### Pruebas

- `tests/Essco.Tests.Unit`: validación de reglas sin infraestructura real.
- `tests/Essco.Tests.Integration`: validación de límites técnicos e integraciones.

## Cómo seguir una operación real: guardar empleado

El flujo comienza en la pantalla y termina en SQL Server:

```text
Pages/Employees/Edit.cshtml
    botón "Guardar empleado"
        ↓ POST
Pages/Employees/Edit.cshtml.cs
    EditModel.OnPostAsync
        ↓ valida archivo, formulario y auditoría
Application/HumanResources/EmployeeService.cs
    EmployeeService.SaveAsync
        ↓ aplica reglas y validaciones SAP
Application/HumanResources/IEmployeeRepository.cs
    contrato de persistencia
        ↓ implementación configurada en Program.cs
Infrastructure/Data/SqlServerEmployeeRepository.cs
    CreateAsync o UpdateAsync
        ↓ comandos SQL parametrizados y transacción
SQL Server: dbo.Empleado y dbo.Web_EmployeePhoto
```

Para investigar un error:

1. Confirme en `Edit.cshtml` qué campo y handler se envían.
2. Revise `EditModel.OnPostAsync` para validación HTTP, carga de fotografía y mensajes al usuario.
3. Siga `EmployeeService.SaveAsync` para reglas de estado, duplicados y validación SAP.
4. Abra `IEmployeeRepository` para conocer el contrato esperado.
5. Revise `SqlServerEmployeeRepository.CreateAsync` o `UpdateAsync` para parámetros, SQL y transacción.
6. Busque la prueba equivalente en `EmployeeTests.cs` y las pruebas de integración relacionadas.

El formulario WinForms de referencia es `Play/Planilla_Empleados.vb`. Úselo para comprender intención y reglas heredadas, no para copiar su arquitectura de interfaz.

## Cómo localizar una funcionalidad proveniente de WinForms

1. Busque la opción en [WINFORMS_MENU_INVENTORY.md](WINFORMS_MENU_INVENTORY.md).
2. Identifique el control, handler y formulario original indicados en la matriz.
3. Consulte [MIGRATION_STATUS.md](MIGRATION_STATUS.md) y el documento específico del módulo.
4. Busque la ruta Web en `src/Essco.Web/Pages`.
5. Desde el PageModel siga el servicio de `Essco.Application` y luego la interfaz hasta `Essco.Infrastructure`.
6. Compare reglas puntuales con el archivo WinForms solamente cuando la documentación no sea suficiente.

## Dónde diagnosticar cada tipo de problema

| Síntoma | Primer lugar para revisar |
|---|---|
| Campo, botón o estructura visual incorrectos | `.cshtml` y CSS del componente. |
| Interacción del navegador | `wwwroot/js` y atributos HTML. |
| Validación o regla empresarial incorrecta | PageModel y servicio de `Essco.Application`. |
| Datos vacíos, duplicados o error SQL | Repositorio en `Essco.Infrastructure/Data`. |
| Acceso denegado | atributo `[Authorize]`, `Permissions` y handlers de seguridad. |
| SAP no disponible o rechaza una operación | configuración SAP, cola, worker y gateway correspondiente. |
| El formulario no abre o falla al arrancar | `Program.cs`, opciones tipadas y logs con correlation ID. |

## Cómo compilar y entender la solución paso a paso

Ejecute los comandos desde `modernization`.

### 1. Restaurar dependencias

```powershell
dotnet restore Essco.Modern.sln
```

### 2. Compilar una capa aislada

El orden conceptual es Domain → Contracts → Application → Infrastructure → Web/Worker.

```powershell
dotnet build src/Essco.Domain/Essco.Domain.csproj --no-restore
dotnet build src/Essco.Application/Essco.Application.csproj --no-restore
dotnet build src/Essco.Infrastructure/Essco.Infrastructure.csproj --no-restore
dotnet build src/Essco.Web/Essco.Web.csproj --no-restore
```

`dotnet build` compila automáticamente las dependencias anteriores. Compilar el proyecto más cercano al cambio produce una verificación más rápida; antes de un commit debe compilarse la solución completa.

### 3. Ejecutar pruebas relacionadas

```powershell
dotnet test tests/Essco.Tests.Unit/Essco.Tests.Unit.csproj --no-restore --filter "FullyQualifiedName~HumanResources"
dotnet test tests/Essco.Tests.Integration/Essco.Tests.Integration.csproj --no-restore --filter "FullyQualifiedName~Employee"
```

Quite `--filter` para ejecutar todo el proyecto de pruebas. Antes de cerrar un lote:

```powershell
dotnet test Essco.Modern.sln --no-restore
```

### 4. Ejecutar Syncro Cliente Web

```powershell
dotnet run --project src/Essco.Web
```

Consulte [VISUAL_STUDIO_SETUP.md](VISUAL_STUDIO_SETUP.md) para Visual Studio y [CONFIGURATION.md](CONFIGURATION.md) para conexiones y secretos.

## Reglas para colocar código nuevo

- Una regla que pueda probarse sin base de datos pertenece a Domain o Application.
- Un caso de uso que coordina repositorios pertenece a Application.
- SQL y detalles de `SqlConnection` pertenecen a Infrastructure.
- HTTP, formularios, cookies y navegación pertenecen a Web.
- COM de SAP pertenece exclusivamente al Worker.
- No agregue reglas empresariales en `.cshtml`, JavaScript ni repositorios.
- No guarde secretos en `appsettings*.json` versionados.

## Documentos relacionados

- [FUNCTIONAL_PARITY_STANDARD.md](FUNCTIONAL_PARITY_STANDARD.md): criterio obligatorio de paridad.
- [MIGRATION_STATUS.md](MIGRATION_STATUS.md): estado real por módulo.
- [EMPLOYEES_CHARACTERIZATION.md](EMPLOYEES_CHARACTERIZATION.md): trazabilidad detallada de Empleados.
- [CONFIGURATION.md](CONFIGURATION.md): configuración local y segura.
- [TESTING.md](TESTING.md): comandos y alcance de pruebas.
- [SAP_BRIDGE.md](SAP_BRIDGE.md): integración desacoplada con SAP.

