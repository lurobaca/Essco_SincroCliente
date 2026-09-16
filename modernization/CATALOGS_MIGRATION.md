# Migración de catálogos operativos

## Motivos de devolución

Fuente heredada: `Admin_MotivosDevolucion.vb` y tabla `dbo.MotivoDevolucion`.

La página `/Catalogs/ReturnReasons` conserva alta, modificación y eliminación física. Las bodegas se consultan desde `OWHS` en la base de compañía indicada por `Essco:Sap:CompanyDatabase`; si no está configurada, el código puede introducirse manualmente para mantener operable el catálogo.

Todas las operaciones nuevas usan parámetros SQL, permiso `catalogs.manage` y auditoría. La eliminación física se conserva porque es el comportamiento original; antes del piloto debe probarse con las llaves foráneas reales y decidirse si conviene convertirla a inactivación.

## Próximos catálogos

- Agentes y choferes.

## Rutas

Fuente heredada: `Admin_Rutas.vb` y `dbo.Rutas`. El formulario original solo tenía funcional el botón Guardar y contenía un SQL de modificación mal formado. La versión web completa alta, consulta, modificación y eliminación con SQL parametrizado, concurrencia básica y auditoría.

## Bancos

Fuente heredada: `Admin_Bancos.vb` y `dbo.BancosEssco`. La página `/Catalogs/Banks` conserva el alta, consulta ordenada por registro descendente y eliminación por código. También presenta la cuenta asignada, que el listado original omitía aunque sí la almacenaba. No se agregó edición porque el WinForms original tampoco la ofrecía.

## Razones de no visita

Fuente heredada: la sección correspondiente de `Manager_Empresa.vb` y `dbo.Razones_NoVisita`. La página `/Catalogs/NoVisitReasons` conserva alta, modificación y eliminación. La actualización usa el valor real de `Codigo`; corrige así el defecto original que enviaba el índice visual del `ComboBox` como identificador SQL.

## Bodegas WMS

Fuente heredada: `WMS_MantenimientoBodegas.vb`, `WMS_CroquisBodega.vb`, `dbo.Picking_Bodega` y `dbo.Picking_Ubicaciones`. La página `/Catalogs/Warehouses` conserva creación, modificación, eliminación y selección de bodega predeterminada. La selección predeterminada ahora es transaccional. Antes de reducir racks/columnas o eliminar una bodega, se comprueban los nombres de ubicación heredados `B{columna}-{rack}{bodega}` y se rechaza la operación si perdería ubicaciones configuradas.

## Bodegueros

Fuente heredada: `Admin_Bodeguero.vb`, `dbo.Bodegueros` y `dbo.Sectores_autorizados`. La página `/Catalogs/WarehouseOperators` conserva los datos personales y operativos, consecutivos, ruta FTP, usuario móvil y los 20 sectores. La clave heredada nunca se consulta ni se devuelve al navegador: en edición solo cambia cuando se introduce una nueva. Por compatibilidad con el cliente móvil existente aún se persiste en el formato heredado; su reemplazo por hash depende de migrar ese consumidor. La fila principal y los sectores se actualizan/eliminan en una sola transacción.
