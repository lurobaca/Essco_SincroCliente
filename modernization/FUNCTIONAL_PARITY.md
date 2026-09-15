# Matriz de paridad funcional

Estados: `Pendiente`, `Analizando`, `Implementado`, `Verificado` y `Bloqueado`.

| Área original | Ejemplos encontrados | Destino web | Estado | Validación pendiente |
|---|---|---|---|---|
| Acceso y seguridad | `LoginForm1`, usuarios, licencia | Identidad, roles y políticas | Pendiente | Usuarios, permisos y licenciamiento |
| Clientes | Administración, estado de cuenta, exoneraciones | Módulo Clientes | Pendiente | Datos, filtros y permisos |
| Artículos y precios | Artículos, listas y descuentos | Catálogo comercial | Pendiente | Reglas de precio y unidades |
| Pedidos y facturación | Pedidos, facturación y búsqueda | Ventas | Pendiente | Totales, impuestos, inventario y SAP |
| Recibos y depósitos | Recibos, bancos y depósitos | Tesorería | Pendiente | Conciliación y asientos |
| Gastos y devoluciones | Gastos, proveedores y devoluciones | Operaciones | Pendiente | Estados y aprobaciones |
| Inventario | Conteos, cruces y grupos | Inventario | Pendiente | Concurrencia y ajustes SAP |
| Liquidaciones | Agentes y choferes | Liquidaciones | Pendiente | Cálculos y reportes |
| Planillas | Clases y pantallas de planilla | Planillas | Pendiente | Archivos bancarios y cálculos |
| Hacienda | XML, token, firma y mensajes | Facturación electrónica | Pendiente | Sandbox oficial y certificados |
| SAP Business One | `SAP_BUSSINES_ONE.vb` y llamadas relacionadas | SapBridge.Worker | Analizando | DI API, bitness y versión instalada |
| Reportes | 49 archivos `.rpt` inventariados; 48 con uso detectable | PDF/Excel/web o puente heredado | Analizando | Comparación reporte por reporte |

El análisis reproducible identificó 160 archivos `*.Designer.vb`, de los cuales 145 tienen código `*.vb` asociado. También existen aproximadamente 393 archivos VB y 49 reportes RPT. El detalle está en `docs/inventory/FORMS.md` y se regenerará conforme avance el inventario.
