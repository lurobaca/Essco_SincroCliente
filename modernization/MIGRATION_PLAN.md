# Plan de migración

1. Inventario reproducible de formularios, clases, reportes, consultas y dependencias.
2. Base transversal: configuración, autenticación, roles, auditoría y manejo de errores.
3. Acceso a SQL Server/MySQL con pruebas contra entornos no productivos.
4. Puente SAP persistente, idempotente y recuperable.
5. Migración de catálogos: usuarios, clientes, artículos, agentes, rutas y proveedores.
6. Migración transaccional: pedidos, facturación, recibos, gastos y devoluciones.
7. Inventario, liquidaciones, planillas y procesos administrativos.
8. Hacienda, firma electrónica, correo, FTP, Excel y QR.
9. Sustitución o encapsulado de los 49 reportes Crystal Reports.
10. Comparación funcional, piloto, estabilización y retiro controlado del cliente WinForms.

## Hallazgo transversal: estado global

`Class_VariablesGlobales.vb` concentra contexto de usuario, empresa, pantallas, conexiones, credenciales leídas de XML y datos transaccionales. Es incompatible con concurrencia web y se descompondrá en opciones seguras, contexto de solicitud, servicios sin estado y persistencia. No se copiará como una clase estática a C#.

## Hallazgo transversal: persistencia

El análisis estático inicial encontró 34 archivos con acceso directo o sentencias SQL, 43 tablas/objetos únicos y numerosos indicios de construcción dinámica de consultas. No se detectaron límites transaccionales explícitos mediante las APIs buscadas. Durante la migración, cada operación crítica deberá definir atomicidad, parametrización, timeout y cancelación; no se trasladará SQL concatenado sin revisar sus entradas.

Ninguna fase autoriza conexiones o cambios en producción.
