# Estrategia de pruebas

- Unitarias: reglas, cálculos, transiciones de estado y validaciones.
- Integración: SQL Server, MySQL, cola persistente, SAP sandbox, Hacienda y archivos.
- Funcionales: flujos completos comparados con el cliente WinForms.
- Regresión de reportes: datos, totales, agrupaciones, orden y salida PDF/Excel.
- Seguridad: autenticación, autorización, aislamiento por empresa y entradas maliciosas.

La compilación exitosa no equivale a paridad funcional.

Las pruebas del repositorio SQL Server requieren una copia no productiva con la estructura real de `dbo.Users`. La migración `001_web_user_security.sql` no debe ejecutarse en producción hasta validar tipos, índices, respaldo y reversión.
