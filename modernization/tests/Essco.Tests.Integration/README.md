# Essco.Tests.Integration

Contiene pruebas de límites técnicos que necesitan más composición que una prueba unitaria.

- **Debe contener:** contratos de persistencia, seguridad e integración reproducibles.
- **No debe contener:** pruebas manuales de interfaz ni dependencias productivas irreversibles.
- **Dependencias:** xUnit y proyectos bajo prueba.
- **Ejemplo:** `SapEmployeeValidationTests` comprueba el comportamiento de la validación SAP en escenarios configurados para pruebas.

