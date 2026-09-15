# Roles y permisos

La matriz inicial proviene de las condiciones sobre `Class_VariablesGlobales.Puesto` en `Play/Principal.vb` (aproximadamente líneas 89–280). Ocultar menús no era una autorización real; en web cada operación deberá declarar una política en servidor.

| Rol heredado | Permisos iniciales observados |
|---|---|
| SuperUsuario | Todos los permisos conocidos |
| Manager | Facturación, contado, administración, exportación, reportes, empresa y diferencias de liquidación |
| Facturacion | Facturación, administración limitada, exportación y reportes de carga/facturas |
| Administracion | Contado, administración, planilla, exportación, reportes y usuarios |
| CuentasXCobrar | Facturación, administración, exportación, reportes y diferencias de liquidación |
| Bodega | Administración limitada, bodega y reportes de carga/facturas |
| Contabilidad | Exportación, reportes y diferencias de liquidación |
| Recepcion | Facturación, administración limitada, exportación y reportes |

## Incertidumbres que requieren validación

- `Contabilidad` activa y luego desactiva `PlanillaToolStripMenuItem`; se conservó el resultado final visible (sin planilla).
- `Manager` no activa explícitamente planilla, usuarios ni bodega dentro de su bloque; esos permisos se niegan hasta confirmar el estado inicial de los menús.
- Algunos menús se inicializan fuera del bloque inspeccionado y varios roles solamente ocultan submenús. Los permisos se refinarán al migrar cada caso de uso.
- `AGENTE`, `CHOFER` y `TODOS` aparecen en filtros operativos, pero no como roles principales de `Principal.vb`; no se conceden permisos web hasta confirmar su significado.
- La política web niega por defecto roles desconocidos.

Cada página, endpoint y comando crítico deberá usar una constante de `Permissions`; la visibilidad del menú será únicamente una consecuencia de la misma política del servidor.
