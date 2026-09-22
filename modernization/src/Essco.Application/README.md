# Essco.Application

Contiene casos de uso, servicios de aplicación, permisos, configuración tipada y contratos que Infrastructure debe implementar.

- **Debe contener:** coordinación de reglas, interfaces de repositorio y resultados de operaciones.
- **No debe contener:** HTML, detalles de `SqlConnection` ni SAP COM.
- **Dependencias:** Essco.Domain y Essco.SapBridge.Contracts.
- **Ejemplo:** `EmployeeService.SaveAsync` valida el empleado y decide si llama `IEmployeeRepository.CreateAsync` o `UpdateAsync`.

