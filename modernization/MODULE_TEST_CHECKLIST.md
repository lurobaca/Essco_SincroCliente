# Lista de módulos para pruebas de migración

Actualizada: 2026-09-18. `Listo para probar` significa que existe un flujo web utilizable con SQL parametrizado; no significa que SAP, Hacienda, bancos u otros servicios externos ya estén certificados para producción.

## Módulos que ya puede probar

| Módulo | Ruta | Funciones disponibles | Estado de prueba |
|---|---|---|---|
| Acceso y seguridad | `/Account/Login` | Login, bloqueo, cambio de contraseña y permisos | Listo con copia SQL |
| Empresa | `/Companies/Profile` | Consulta y edición del perfil y ubicaciones | Listo |
| Catálogos | `/Catalogs` | Motivos, rutas, bancos, bodegas, bodegueros, agentes y choferes | Listo; validar relaciones |
| Clientes | `/Customers` | Solicitudes, alta, edición, aprobación, exoneraciones, CABYS y estado de cuenta | Listo en SQL; SAP pendiente |
| Productos | `/Products` | Consulta, listas de precios y descuentos | Listo; maestro permanece en SAP |
| Pedidos a proveedores | `/Purchasing` | Bandeja, detalle, edición, anulación y cola SAP | Listo sin certificar SAP |
| Facturas electrónicas | `/Billing` | Búsqueda y detalle existentes | Solo consulta |
| Devoluciones | `/Returns` | Bandeja, líneas y cola SAP | Parcial; validar bodega/SAP |
| Depósitos | `/Treasury/Deposits` | Alta, edición, anulación, asociación y cola SAP | Listo en SQL; SAP pendiente |
| Recibos | `/Treasury/Receipts` | Consulta, vinculación y desvinculación | Listo; UDF SAP pendientes |
| Inventario | `/Inventory` | Apertura, grupos, conteos variables, cruces, reconteos, consolidación, cierre y XLSX SAP | Listo; ajuste SAP pendiente |
| Liquidaciones | `/Liquidations` | Agentes/choferes, gastos, conciliación, diferencias y resumen | Parcial |
| Planillas | `/Payroll` | Crear, consultar, finalizar, anular, detalle, TXT bancario y asiento SAP | Parcial; requiere caracterización |
| Empleados | `/Employees` | Alta, edición, expediente, movimientos, adjuntos, educación y experiencia | Listo para este alcance |
| Reportes | `/Reports` | CSV iniciales de facturación, inventario y planillas | Parcial |
| Portal público/clientes | `https://localhost:7252` | Sitio público, organizaciones, aplicaciones y acceso a Syncro Cliente | Parcial |

## Pendientes de completar o crear

| Prioridad | Área | Trabajo pendiente |
|---|---|---|
| Alta | Facturación electrónica | Emisión, consecutivos, XML 4.4, XAdES, token y respuesta de Hacienda |
| Alta | SAP Business One | Certificar DI API, arquitectura, UDF, impuestos, bodegas y recuperación del servicio Windows |
| Alta | Empleados | Aumentos, adicionales, días adicionales, liquidación laboral, fotografía y reglas de vacaciones |
| Alta | Planillas | Validar cálculos, incapacidades, renta/CCSS, aguinaldo, liquidaciones y formato bancario |
| Alta | Portal de clientes | Registro persistente, invitaciones, usuarios/permisos, facturas, pagos y soporte |
| Media | Liquidaciones | Devoluciones, cierre definitivo y PDF final |
| Media | Inventario | Ajustes SAP y pruebas de concurrencia |
| Media | Productos | Definir mantenimiento del maestro frente a SAP |
| Media | Compras/devoluciones | Certificar documentos reales en SAP |
| Media | Reportes | Comparar y sustituir los 49 Crystal Reports |
| Media | Integraciones auxiliares | Correo, FTP, impresión, QR, Excel y secretos |
| Baja | Licencia/retiro WinForms | Sustituir licencia, piloto, estabilización y retiro controlado |

## Orden sugerido de prueba

1. Acceso, Empresa y Catálogos.
2. Empleados y expediente.
3. Clientes, Productos y Pedidos.
4. Inventario con tantos conteos como requiera el usuario.
5. Depósitos, Recibos y Liquidaciones.
6. Planillas comparadas contra WinForms.
7. SAP y Hacienda únicamente en ambientes de prueba.

Registre cada diferencia con módulo, operación, datos usados, resultado esperado, resultado obtenido y captura. No use datos productivos.
