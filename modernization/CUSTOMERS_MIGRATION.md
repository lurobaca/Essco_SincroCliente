# Migración de Clientes

## Alcance heredado identificado

- `Admin_Clientes`: edición de solicitudes en `dbo.ClientesModificados`.
- `Lista_ClientesModificados`: búsqueda, filtros y aprobación.
- `ClientesDocumentosExoneracion`: documentos y códigos CABYS exentos.
- `ClientesEstadoCuenta`: consulta financiera dependiente de SAP.
- `CambioInfoClientes` y `ClientesShow`: consulta y selección.

El primer incremento incorpora el dominio, validación, búsqueda paginada, alta/edición y aprobación de `ClientesModificados`. Todas las consultas nuevas son parametrizadas.

## Diferencias de seguridad deliberadas

La contraseña web heredada continúa representada temporalmente para no romper el intercambio existente, pero se considera dato sensible: no debe aparecer en listados, auditoría ni registros. Antes de habilitar producción se determinará si el consumidor móvil admite hash o cifrado reversible administrado mediante Data Protection.

## Pendiente de verificación

- Tipos y longitudes reales de columnas en una copia de SQL Server.
- Semántica de `Estado`, `TipoSocio`, `Tipo_Cedula` e índices geográficos.
- Estrategia transaccional para documentos de exoneración y CABYS.
- Aprobación y creación/actualización efectiva en SAP Business One mediante el Windows Service.
