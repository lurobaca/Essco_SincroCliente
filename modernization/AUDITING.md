# Auditoría

La aplicación registra eventos empresariales estructurados en `dbo.Web_AuditLog`. La tabla se crea con `database/sqlserver/002_web_audit_log.sql` y dispone de reversión separada.

Cada evento contiene:

- Identificador único.
- Fecha UTC.
- Usuario e identificador cuando están disponibles.
- Empresa.
- Operación.
- Tipo e identificador de entidad.
- Resultado.
- Identificador de correlación.
- Dirección IP remota.

No se admiten contraseñas, hashes, tokens, certificados, cadenas de conexión ni cargas completas dentro de la auditoría. Actualmente se registran login, logout y cambio de contraseña. Cada comando transaccional nuevo deberá escribir un evento con resultado confirmado dentro de su diseño.

Cuando SQL Server está deshabilitado, la aplicación no permite autenticar usuarios y el sink de auditoría queda inactivo para permitir health checks y diagnóstico inicial. Cuando SQL está habilitado, un fallo al persistir auditoría impide finalizar la operación de seguridad correspondiente.
