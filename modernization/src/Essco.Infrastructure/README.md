# Essco.Infrastructure

Implementa persistencia e integraciones técnicas solicitadas por Application.

- **Debe contener:** repositorios SQL Server, comandos parametrizados y adaptadores externos.
- **No debe contener:** decisiones visuales ni reglas empresariales nuevas.
- **Dependencias:** Essco.Application, Essco.Domain, Essco.SapBridge.Contracts y Microsoft.Data.SqlClient.
- **Ejemplo:** `SqlServerEmployeeRepository` persiste las decisiones tomadas por `EmployeeService` en `dbo.Empleado`.

