# Migración de Clientes

## Alcance heredado identificado

- `Admin_Clientes`: edición de solicitudes en `dbo.ClientesModificados`.
- `Lista_ClientesModificados`: búsqueda, filtros y aprobación.
- `ClientesDocumentosExoneracion`: documentos y códigos CABYS exentos.
- `ClientesEstadoCuenta`: consulta financiera dependiente de SAP.
- `CambioInfoClientes` y `ClientesShow`: consulta y selección.

Los incrementos actuales incorporan dominio, validación tributaria y geográfica, búsqueda paginada, formulario web de alta/edición y aprobación de `ClientesModificados`. Todas las consultas nuevas son parametrizadas. El consecutivo se incrementa junto con la inserción dentro de una transacción serializable.

Los cuatro estados se conservan textualmente para compatibilidad: `Nuevo`, `Cerrar`, `Modificado` e `Interno`.

## Diferencias de seguridad deliberadas

La contraseña web heredada continúa representada temporalmente para no romper el intercambio existente, pero se considera dato sensible: no debe aparecer en listados, auditoría ni registros. Antes de habilitar producción se determinará si el consumidor móvil admite hash o cifrado reversible administrado mediante Data Protection.

## Pendiente de verificación

- Tipos y longitudes reales de columnas en una copia de SQL Server.
- Semántica de `Estado`, `TipoSocio`, `Tipo_Cedula` e índices geográficos.
- Estrategia transaccional para documentos de exoneración y CABYS.
- Aprobación y creación/actualización efectiva en SAP Business One mediante el Windows Service.
