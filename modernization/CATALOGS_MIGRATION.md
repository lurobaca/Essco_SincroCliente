# Migración de catálogos operativos

## Motivos de devolución

Fuente heredada: `Admin_MotivosDevolucion.vb` y tabla `dbo.MotivoDevolucion`.

La página `/Catalogs/ReturnReasons` conserva alta, modificación y eliminación física. Las bodegas se consultan desde `OWHS` en la base de compañía indicada por `Essco:Sap:CompanyDatabase`; si no está configurada, el código puede introducirse manualmente para mantener operable el catálogo.

Todas las operaciones nuevas usan parámetros SQL, permiso `catalogs.manage` y auditoría. La eliminación física se conserva porque es el comportamiento original; antes del piloto debe probarse con las llaves foráneas reales y decidirse si conviene convertirla a inactivación.

## Próximos catálogos

- Bodegas y bodegueros.
- Agentes y choferes.
- Razones de no visita.

## Rutas

Fuente heredada: `Admin_Rutas.vb` y `dbo.Rutas`. El formulario original solo tenía funcional el botón Guardar y contenía un SQL de modificación mal formado. La versión web completa alta, consulta, modificación y eliminación con SQL parametrizado, concurrencia básica y auditoría.

## Bancos

Fuente heredada: `Admin_Bancos.vb` y `dbo.BancosEssco`. La página `/Catalogs/Banks` conserva el alta, consulta ordenada por registro descendente y eliminación por código. También presenta la cuenta asignada, que el listado original omitía aunque sí la almacenaba. No se agregó edición porque el WinForms original tampoco la ofrecía.
