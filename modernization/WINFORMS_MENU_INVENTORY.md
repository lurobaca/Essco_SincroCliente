# Inventario del menú WinForms y proyección Web

Fuente inspeccionada: `Play/Principal.Designer.vb` (`MenuStrip1`) y manejadores de `Play/Principal.vb`.

Actualizado: 2026-09-21. Este documento inventaría navegación; el estado funcional detallado continúa en `MIGRATION_STATUS.md`. `PARCIAL` significa que existe una función Web utilizable, pero no demuestra paridad ni validación del usuario. Ninguna opción se declara completamente migrada o validada.

## Resumen

- 13 grupos superiores representados (12 operativos y Acerca de).
- 80 acciones terminales funcionales catalogadas.
- 1 acción global adicional: Cerrar sesión, implementada como `POST /Account/Logout` fuera del catálogo funcional.
- 45 opciones Web utilizables, identificadas como `PARCIAL`.
- 32 opciones `NO MIGRADAS`, visibles y deshabilitadas.
- 3 opciones `POR REVISAR` antes de declararlas obsoletas: WMS/Recepción, Ventas/Ofertas y Acerca de/Salir.
- 0 opciones declaradas `MIGRADAS` o `VALIDADAS`.

## Organización propuesta

El escritorio usaba una fila de menús MDI. La Web conserva nombres, orden y relación padre/hijo, pero los presenta en una barra lateral colapsable. En móvil se convierte en un panel `offcanvas`. Las opciones no migradas no tienen `href`, URL ni endpoint ficticio.

| Grupo | Subgrupo | Opción WinForms | Form/función original | Estado Web | Ruta Web | Permiso | Estado menú |
|---|---|---|---|---|---|---|---|
| Facturación | — | Estado de transmisiones | EstadoSubida | PARCIAL | `/Billing/Index` | billing.access | Habilitada |
| Facturación | — | Reportes de carga | ReportesDeCarga | NO MIGRADA | — | Por determinar | Deshabilitada |
| Facturación | — | Reporte de facturas | Reporte_Facturas | PARCIAL | `/Reports/Index` | reports.access | Habilitada |
| Facturación | — | Últimos consecutivos | UltimosConsecutivos | NO MIGRADA | — | Por determinar | Deshabilitada |
| Facturación | — | Descuentos fijos | DescFijos / DescuentosFijos | PARCIAL | `/Products/Discounts` | billing.access | Habilitada |
| Facturación | — | Información del cliente | ClientesShow | PARCIAL | `/Customers/Index` | customers.manage | Habilitada |
| Facturación | — | Devoluciones | Devoluciones | PARCIAL | `/Returns/Index` | billing.access | Habilitada |
| Facturación | — | Devoluciones pendientes | Devoluciones_Pendientes | PARCIAL | `/Returns/Index` | billing.access | Habilitada |
| Facturación | — | Estado de comprobantes | Admin_EstadoComprobantes | PARCIAL | `/Billing/Index` | billing.access | Habilitada |
| Facturación | — | Acepta/Rechaza facturas | Acepta_Rechaza | PARCIAL | `/Billing/Index` | billing.access | Habilitada |
| Administrar | — | Agente/Choferes | Admin_Agentes | PARCIAL | `/Catalogs/SalesAgents` | catalogs.manage | Habilitada |
| Administrar | — | Bodegueros | Admin_Bodeguero | PARCIAL | `/Catalogs/WarehouseOperators` | catalogs.manage | Habilitada |
| Administrar | — | Empresa | Manager_Empresa | PARCIAL | `/Companies/Profile` | company.manage | Habilitada |
| Administrar | — | Choferes y ayudantes | Admin_Choferes | PARCIAL | `/Catalogs/Drivers` | catalogs.manage | Habilitada |
| Administrar | — | Rutas | Admin_Rutas | PARCIAL | `/Catalogs/Routes` | catalogs.manage | Habilitada |
| Administrar | — | Universos | Universos | NO MIGRADA | — | Por determinar | Deshabilitada |
| Administrar | — | Cambio Info cliente | CambioInfoClientes | PARCIAL | `/Customers/Index` | customers.manage | Habilitada |
| Administrar | — | Usuarios | Usuarios | NO MIGRADA | — | users.manage | Deshabilitada |
| Administrar | — | Camiones | Admin_Mantenimiento_Camiones | NO MIGRADA | — | Por determinar | Deshabilitada |
| Administrar | — | Clientes | Admin_Clientes | PARCIAL | `/Customers/Index` | customers.manage | Habilitada |
| Administrar | — | Decisiones | Gerencia | NO MIGRADA | — | Por determinar | Deshabilitada |
| Administrar | — | Licencias | MantenimientoLicencias | NO MIGRADA | — | Por determinar | Deshabilitada |
| Administrar | — | Bancos | Admin_Bancos | PARCIAL | `/Catalogs/Banks` | catalogs.manage | Habilitada |
| Administrar | — | Motivos de devolución | Admin_MotivosDevolucion | PARCIAL | `/Catalogs/ReturnReasons` | catalogs.manage | Habilitada |
| Administrar | — | Lista de precios | ListaDePrecios | PARCIAL | `/Products/PriceLists` | billing.access | Habilitada |
| Bodega | — | Reporte de carga | ReportesDeCarga | NO MIGRADA | — | load-reports.access | Deshabilitada |
| Bodega | — | Reporte de devoluciones | ReporteDeDevoluciones | NO MIGRADA | — | Por determinar | Deshabilitada |
| Bodega | — | Crear pedido | Pedido_Principal | PARCIAL | `/Purchasing/Index` | billing.access | Habilitada |
| Bodega | — | Chequear reporte | Rutas_RepCarga | NO MIGRADA | — | warehouse.access | Deshabilitada |
| Bodega | WMS/Bodega | Diseñar | WMS_MantenimientoBodegas | NO MIGRADA | — | warehouse.access | Deshabilitada |
| Bodega | WMS/Bodega | Ver | WMS_VerBodegas | NO MIGRADA | — | warehouse.access | Deshabilitada |
| Bodega | WMS | Recepción | Sin manejador funcional | POR REVISAR | — | Por determinar | Deshabilitada |
| Bodega | WMS | Líneas nuevas | WMS_LineaNueva | NO MIGRADA | — | warehouse.access | Deshabilitada |
| Bodega | WMS | Chequeados | WMS_PedidosChequeados | NO MIGRADA | — | warehouse.access | Deshabilitada |
| Liquidaciones | Choferes | Nueva | Liquidacion_Choferes | PARCIAL | `/Liquidations/Index` | liquidation-differences.access | Habilitada |
| Liquidaciones | Choferes | Gastos | Detalle_Gastos_Choferes | PARCIAL | `/Liquidations/Expenses` | liquidation-differences.access | Habilitada |
| Liquidaciones | Choferes | Depósitos | Admin_Depositos_Choferes | PARCIAL | `/Treasury/Deposits` | cash.access | Habilitada |
| Liquidaciones | Choferes | Buscar factura | BuscaFactura | NO MIGRADA | — | Por determinar | Deshabilitada |
| Liquidaciones | Agentes | Nueva | Liquidacion_Agentes | PARCIAL | `/Liquidations/Index` | liquidation-differences.access | Habilitada |
| Liquidaciones | Agentes | Gastos | Detalle_Gastos | PARCIAL | `/Liquidations/Expenses` | liquidation-differences.access | Habilitada |
| Liquidaciones | Agentes | Depósitos | Admin_Depositos_Agentes | PARCIAL | `/Treasury/Deposits` | cash.access | Habilitada |
| Liquidaciones | — | Revisar depósitos | RevisaDepositos | PARCIAL | `/Treasury/Deposits` | cash.access | Habilitada |
| Exportar | — | Información a Seller | Enviar_Info_Seller | NO MIGRADA | — | export.access | Deshabilitada |
| Exportar | — | Información a Picking | Enviar_Info_Picking | NO MIGRADA | — | export.access | Deshabilitada |
| Exportar | — | Información a Deliver | Enviar_Info_Deliver | NO MIGRADA | — | export.access | Deshabilitada |
| Reportes | — | Faltantes en facturación | Report_Faltantes | PARCIAL | `/Reports/Index` | reports.access | Habilitada |
| Reportes | — | Faltante/Sobrante choferes | Report_Faltantes_Choferes | PARCIAL | `/Liquidations/Summary` | liquidation-differences.access | Habilitada |
| Reportes | — | Faltante/Sobrante agentes | Report_Faltantes | PARCIAL | `/Liquidations/Summary` | liquidation-differences.access | Habilitada |
| Reportes | — | Math Hacienda | Math_Hacienda | NO MIGRADA | — | Por determinar | Deshabilitada |
| Conteo físico | — | Nuevo | Inv_NuevoConteo | PARCIAL | `/Inventory/Index` | warehouse.access | Habilitada |
| Conteo físico | — | Grupos | GruposConteo | PARCIAL | `/Inventory/Index` | warehouse.access | Habilitada |
| Conteo físico | — | Control | Inv_Control | PARCIAL | `/Inventory/Index` | warehouse.access | Habilitada |
| Conteo físico | — | Conteo activo | Inv_SeguridadConteoGrupos | PARCIAL | `/Inventory/Index` | warehouse.access | Habilitada |
| Conteo físico | — | Cruzar | Inv_Cruzar | PARCIAL | `/Inventory/Compare` | warehouse.access | Habilitada |
| Conteo físico | — | Conteos realizados | Inv_ConteosRealizados | PARCIAL | `/Inventory/Index` | warehouse.access | Habilitada |
| Planilla | — | Nueva | Planilla | PARCIAL | `/Payroll/Index` | payroll.access | Habilitada |
| Planilla | — | Empleados | Planilla_Empleados | PARCIAL | `/Employees/Index` | employees.view | Habilitada |
| Planilla | — | Aumentos | Planilla_AplicarAumento | PARCIAL | `/Employees/Index` | payroll.access | Habilitada |
| Planilla | — | Deducciones fijas | DeduccionesAcreditaciones | PARCIAL | `/Employees/Index` | payroll.access | Habilitada |
| Planilla | — | Desglose de renta | PlanillaDesgloseDeRenta | NO MIGRADA | — | payroll.access | Deshabilitada |
| Planilla | — | Desglose de CCSS | Planilla_DesgloceCCSS | NO MIGRADA | — | payroll.access | Deshabilitada |
| Planilla | — | Asigna empleado a ruta | PlanillaAsignaEmpleadoARuta | PARCIAL | `/Employees/Index` | payroll.access | Habilitada |
| Ventas | — | Orden de compra/Proforma | Facturacion | NO MIGRADA | — | billing.access | Deshabilitada |
| Ventas | — | Facturación | Facturacion | NO MIGRADA | — | billing.access | Deshabilitada |
| Ventas | — | Notas de crédito | Facturacion | NO MIGRADA | — | billing.access | Deshabilitada |
| Ventas | — | Notas de débito | Facturacion | NO MIGRADA | — | billing.access | Deshabilitada |
| Ventas | — | Descuentos por periodo y cantidad | Función comentada | PARCIAL | `/Products/Discounts` | billing.access | Habilitada |
| Ventas | — | Ofertas | Función comentada sin implementación | POR REVISAR | — | Por determinar | Deshabilitada |
| Inventario | — | Manager de artículos | Stock_Manager | PARCIAL | `/Products/Index` | billing.access | Habilitada |
| Inventario | — | Entradas | Sin manejador | NO MIGRADA | — | warehouse.access | Deshabilitada |
| Inventario | — | Salidas | Sin manejador | NO MIGRADA | — | warehouse.access | Deshabilitada |
| Inventario | — | Traslados | Sin manejador | NO MIGRADA | — | warehouse.access | Deshabilitada |
| Inventario | — | Bodegas | Stock_Manager/pestaña bodegas | PARCIAL | `/Catalogs/Warehouses` | catalogs.manage | Habilitada |
| Compras | — | Orden de compra | Pedido_Principal | PARCIAL | `/Purchasing/Index` | billing.access | Habilitada |
| Compras | — | Facturación | Sin manejador | NO MIGRADA | — | billing.access | Deshabilitada |
| Compras | — | Notas de crédito | Sin manejador | NO MIGRADA | — | billing.access | Deshabilitada |
| Compras | — | Notas de débito | Sin manejador | NO MIGRADA | — | billing.access | Deshabilitada |
| Finanzas | — | Recibos de dinero | RecibosDeDinero | PARCIAL | `/Treasury/Receipts` | cash.access | Habilitada |
| Acerca de | — | Sistema | AboutBox1 | NO MIGRADA | — | Por determinar | Deshabilitada |
| Acerca de | — | Salir | Cierre del ejecutable | POR REVISAR/NO APLICA WEB | — | — | Deshabilitada |

## Duplicados y accesos convergentes

- `Report_Faltantes` se abre desde Faltantes en facturación y Faltante/Sobrante de agentes.
- `ReportesDeCarga` aparece en Facturación y Bodega.
- `Facturacion` sirve Proforma, Factura, Nota de crédito y Nota de débito según una variable global.
- Depósitos de agentes/choferes convergen en Tesorería Web, pero conservan accesos separados en el menú.
- Varias acciones de conteo físico convergen en `/Inventory/Index`; se mantienen separadas para conservar el mapa funcional original.

## Cómo habilitar una opción después de migrarla

Editar una sola entrada en `ErpNavigationCatalog.cs`: cambiar `N(...)` por `P(etiqueta, controlOriginal, formOriginal, rutaRazorReal, permisoReal)`. Antes de hacerlo deben existir funcionalidad utilizable, protección backend, pruebas y el estado acordado durante la migración. No basta con crear una URL.

## Diferencias justificadas

- `Cerrar sesión` se movió fuera de la jerarquía funcional y se ejecuta por POST desde el encabezado; evita confundir una acción de cuenta con un módulo.
- La fila horizontal MDI se reemplazó por sidebar colapsable para soportar profundidad, crecimiento y pantallas pequeñas.
- Los elementos históricamente ocultos no se eliminaron; permanecen inventariados y visibles como pendientes.
- Las opciones sin permiso no se muestran cuando son navegables. Las pendientes continúan visibles y deshabilitadas porque su finalidad adicional es reflejar el mapa de migración.
