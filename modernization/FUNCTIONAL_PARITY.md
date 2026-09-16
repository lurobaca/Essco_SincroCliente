# Matriz de paridad funcional

Estados: `Pendiente`, `Analizando`, `Implementado`, `Verificado` y `Bloqueado`.

| Área original | Ejemplos encontrados | Destino web | Estado | Validación pendiente |
|---|---|---|---|---|
| Acceso y seguridad | `LoginForm1`, usuarios, licencia | Login/logout, hashing, bloqueo y cambio obligatorio implementados | Implementado | Validar repositorio y credenciales en copia SQL; roles y licencia pendientes |
| Empresa | `Manager_Empresa`, `Empresa`, `Ubicaciones_CostaRica` | Perfil web, validaciones, ubicaciones encadenadas, autorización y auditoría | Implementado | Verificar columnas y valores reales en copia SQL |
| Catálogos operativos | Motivos, rutas, bodegas, bodegueros, agentes, choferes, bancos y razones de no visita | Mantenimientos principales implementados, incluidos Agentes y Choferes históricos | Implementado | Validar esquemas y relaciones contra copia SQL; pruebas end-to-end |
| Clientes | Administración, estado de cuenta, exoneraciones | Solicitudes, alta/edición, aprobación, exoneraciones/CABYS y estado de cuenta implementados | Analizando | Ejecución SAP pendiente; validar contra copia SQL |
| Artículos y precios | Artículos, listas y descuentos | Consulta de catálogo, listas de precios y descuentos automáticos implementados | Analizando | Validar esquema SQL, reglas de unidades y autoridad del maestro SAP |
| Pedidos y facturación | Pedidos, facturación y búsqueda | Pedidos a proveedores con SAP; consulta y detalle de facturas electrónicas implementados | Analizando | Emisión, consecutivos, XML, firma, transmisión Hacienda y validación SAP |
| Recibos y depósitos | Recibos, bancos y depósitos | Depósitos web y envío asíncrono a SAP; consulta de recibos y vinculación/desvinculación implementadas | Analizando | Conciliación posterior, asientos y validación SQL/DI API real |
| Gastos y devoluciones | Gastos, proveedores y devoluciones | Gastos web; bandeja de devoluciones y creación asíncrona de nota de crédito SAP implementadas | Analizando | Tipos, edición de devoluciones, FEC/Hacienda y validación SQL/DI API real |
| Inventario | Conteos, cruces y grupos | Consulta, captura de conteos, diferencias y cierre transaccional implementados | Analizando | Creación, grupos/proveedores, reconteo, cruce y ajustes SAP |
| Liquidaciones | Agentes y choferes | Cabeceras web: consulta, alta, edición y anulación con consecutivos transaccionales | Analizando | Integrar depósitos, recibos, gastos, facturas, devoluciones, cálculos, reportes y cierre |
| Planillas | Clases y pantallas de planilla | Listado, creación, desglose por empleado, finalización y anulación implementados | Analizando | Caracterizar cálculos, expedientes, aguinaldo, vacaciones, archivos bancarios y asiento SAP |
| Hacienda | XML, token, firma y mensajes | Facturación electrónica | Pendiente | Sandbox oficial y certificados |
| SAP Business One | `SAP_BUSSINES_ONE.vb` y llamadas relacionadas | SapBridge.Worker | Analizando | DI API, bitness y versión instalada |
| Reportes | 49 archivos `.rpt` inventariados; 48 con uso detectable | PDF/Excel/web o puente heredado | Analizando | Comparación reporte por reporte |

El análisis reproducible identificó 160 archivos `*.Designer.vb`, de los cuales 145 tienen código `*.vb` asociado. También existen aproximadamente 393 archivos VB y 49 reportes RPT. El detalle está en `docs/inventory/FORMS.md` y se regenerará conforme avance el inventario.
