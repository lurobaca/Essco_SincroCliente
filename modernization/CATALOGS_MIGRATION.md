# Migración de catálogos operativos

## Motivos de devolución

Fuente heredada: `Admin_MotivosDevolucion.vb` y tabla `dbo.MotivoDevolucion`.

La página `/Catalogs/ReturnReasons` conserva alta, modificación y eliminación física. Las bodegas se consultan desde `OWHS` en la base de compañía indicada por `Essco:Sap:CompanyDatabase`; si no está configurada, el código puede introducirse manualmente para mantener operable el catálogo.

Todas las operaciones nuevas usan parámetros SQL, permiso `catalogs.manage` y auditoría. La eliminación física se conserva porque es el comportamiento original; antes del piloto debe probarse con las llaves foráneas reales y decidirse si conviene convertirla a inactivación.

## Próximos catálogos

- Rutas.
- Bodegas y bodegueros.
- Agentes y choferes.
- Bancos.
- Razones de no visita.
