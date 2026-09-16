# Plan de migración

## Directiva de ejecución continua

No detener la ejecución ni presentar un módulo, prueba, commit o `push` incremental como terminación de la migración. Después de cada bloque verificado se debe crear y publicar su commit y continuar inmediatamente con el siguiente bloque pendiente. La migración solo puede declararse completa cuando toda la matriz `FUNCTIONAL_PARITY.md` esté cerrada, las pruebas automatizadas estén aprobadas, las integraciones externas tengan adaptador y procedimiento de validación, la documentación operativa esté completa y la rama remota contenga todos los cambios. Una dependencia externa inaccesible debe quedar aislada, simulada y documentada, pero no autoriza a abandonar los demás módulos que puedan seguir migrándose.

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

## Hallazgo transversal: integraciones

SAP Business One aparece en 14 archivos, Hacienda en 34 y Crystal Reports en 49. También existen dependencias de firma XAdES, SMTP, FTP, Office Interop, QR, impresión y archivos locales. Las 97 referencias de ensamblado incluyen componentes COM/GAC y rutas locales: ninguna se considerará compatible con el servidor web hasta sustituirla o aislarla y probarla.

Ninguna fase autoriza conexiones o cambios en producción.
