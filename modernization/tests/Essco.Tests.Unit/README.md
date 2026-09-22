# Essco.Tests.Unit

Contiene pruebas rápidas y aisladas de reglas y servicios.

- **Debe contener:** escenarios deterministas con repositorios falsos o datos en memoria.
- **No debe contener:** dependencia obligatoria de SQL Server, red o SAP real.
- **Dependencias:** xUnit y proyectos bajo prueba.
- **Ejemplo:** `EmployeeTests` verifica estados, duplicados, fotografía y validaciones SAP mediante un repositorio falso.

