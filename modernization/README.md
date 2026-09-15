# Essco Modern

Modernización incremental de `SincroCliente`, actualmente VB.NET/Windows Forms sobre .NET Framework 4.8, hacia una aplicación web en C# y ASP.NET Core.

## Estado

La solución base está creada. Todavía **no sustituye al sistema productivo**. La equivalencia funcional se validará módulo por módulo en `FUNCTIONAL_PARITY.md`.

## Componentes

- `Essco.Web`: aplicación web Razor Pages y endpoints internos.
- `Essco.Domain`: entidades y reglas de negocio independientes de infraestructura.
- `Essco.Application`: casos de uso y contratos de puertos.
- `Essco.Infrastructure`: adaptadores de datos y servicios externos.
- `Essco.SapBridge.Contracts`: mensajes compartidos sin dependencias COM.
- `Essco.SapBridge.Worker`: proceso en segundo plano destinado a ejecutarse como Windows Service.
- `Essco.Tests.*`: pruebas unitarias y de integración.

## Desarrollo

```powershell
dotnet restore Essco.Modern.sln
dotnet build Essco.Modern.sln --no-restore
dotnet test Essco.Modern.sln --no-build
dotnet run --project src/Essco.Web
```

Las cadenas de conexión, credenciales SAP, certificados y secretos se proporcionarán mediante variables de entorno o un almacén de secretos. Nunca deben agregarse al repositorio.

Consulte `CONFIGURATION.md` para la estructura tipada, variables de entorno y diagnóstico por correlación.
