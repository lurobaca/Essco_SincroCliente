# Seguridad

- No guardar secretos, certificados ni conexiones reales en Git.
- Usar variables de entorno o almacén de secretos administrado.
- Autenticar usuarios y autorizar por módulo, operación y empresa.
- Parametrizar consultas y validar toda entrada en servidor.
- Añadir auditoría para operaciones financieras, inventario y SAP.
- Mantener el puente SAP en una red interna; nunca exponerlo directamente a Internet.
- Sanitizar errores antes de almacenarlos o mostrarlos.
- Persistir las llaves de Data Protection fuera del artefacto desplegado y proteger su directorio con permisos del sistema operativo.

Antes del primer push se ejecutará una revisión de secretos sobre todos los archivos nuevos.
