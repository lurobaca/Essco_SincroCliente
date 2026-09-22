# Essco.Domain

Contiene entidades, estados y reglas puras del negocio. El código de este proyecto no debe conocer Razor, HTTP, SQL Server ni SAP DI API.

- **Debe contener:** modelos y comportamiento que pueden probarse sin infraestructura.
- **No debe contener:** consultas SQL, PageModels, cookies o componentes visuales.
- **Dependencias:** ninguna capa interna.
- **Ejemplo:** `HumanResources/Employee.cs` representa al empleado y sus estados laborales; `EmployeeService` en Application utiliza ese modelo.

