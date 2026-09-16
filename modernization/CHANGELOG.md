# Historial

## En desarrollo

- Creación de la solución web por capas sobre .NET 10.
- Creación del prototipo de trabajos idempotentes para el puente SAP.
- Incorporación de health check y endpoints iniciales.
- Documentación inicial de arquitectura, seguridad, pruebas y paridad.
- Inventario reproducible de 160 diseñadores WinForms, sus controles, eventos y dependencias detectables.
- Inventario reproducible de 49 clases/DTO con aproximadamente 30.412 líneas, métodos, dependencias, riesgos y estado global.
- Inventario de 34 archivos con acceso a datos, 188 referencias y 43 tablas/objetos SQL detectados.
- Inventario de 168 ubicaciones de integración y 97 referencias de ensamblados heredados.
- Catálogo individual de 49 Crystal Reports, con invocaciones, parámetros y estrategia inicial de sustitución.
- Configuración tipada validada al inicio, Problem Details y correlación de solicitudes web.
- Núcleo de autenticación con bloqueo, PBKDF2-SHA512 y actualización controlada de credenciales heredadas.
- Repositorio SQL Server parametrizado y migración reversible para estado de seguridad web.
- Login/logout web con cookie segura y cambio obligatorio de contraseña.
- Políticas de autorización para los ocho puestos heredados identificados en el menú principal.
- Auditoría SQL estructurada para accesos, cierres de sesión y cambios de contraseña.
- Dominio y repositorio parametrizado para el perfil empresarial, excluyendo secretos heredados.
- Página web protegida para administrar Empresa, catálogos geográficos encadenados y auditoría de cambios.
- Núcleo de solicitudes de cambio de Clientes con validación, filtros paginados, SQL parametrizado y aprobación.
- Formulario web auditado de alta/edición de clientes con ubicación encadenada y consecutivo transaccional.
- Persistencia parametrizada y transaccional de documentos de exoneración y códigos CABYS.
- Página web auditada para documentos de exoneración, vigencias y asociaciones CABYS.
- Consulta web del estado de cuenta de comprobantes con filtros, saldos y totales.
- Cola SAP persistente en SQL Server con idempotencia, adquisición atómica, recuperación y reintentos.
- Despacho idempotente de altas, modificaciones y cierres de clientes hacia el Windows Service SAP.
- Adaptador COM/DI API en hilo STA para crear, modificar y cerrar clientes, con confirmación SQL posterior al éxito SAP.
- Catálogo web auditado de motivos de devolución y selección de bodegas SAP.
- Catálogo web auditado de rutas con CRUD completo.
