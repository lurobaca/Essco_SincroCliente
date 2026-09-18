# Migración de devoluciones

Fuentes heredadas: `Devoluciones.vb`, `Devoluciones_Pendientes.vb`, `SAP_BUSSINES_ONE.AddDevolucion`, `dbo.Devoluciones` y `dbo.DevolucionesDetalle`.

La página `/Returns` presenta la bandeja parametrizada de devoluciones, filtros por estado, agente/chofer y número, además del detalle de artículos. Las devoluciones pendientes permiten agregar, editar y eliminar líneas antes de enviarlas a SAP. La edición cubre cantidad, descuentos fijo y promocional, motivo y comentario. Cada guardado o eliminación recalcula detalle y totales del encabezado con las mismas reglas del WinForms y no despacha el documento.

El esquema encontrado en `Sic_Local_Web_Pruebas` no contiene la columna `MotivoDevolucion.Bodega`, y `DevolucionesDetalle` tampoco almacena la bodega. La lectura y el mantenimiento de motivos son compatibles tanto con bases antiguas sin esa columna como con bases actualizadas. Cuando la columna no existe, la pantalla deja la bodega vacía y bloquea el envío a SAP con un mensaje explícito; no se inventa una bodega. Antes del piloto debe agregarse/migrarse esa relación o definirse la regla de negocio que permita resolverla.

Procesar encola `Return.CreateCreditNote`. El servicio Windows carga nuevamente la devolución, crea mediante DI API el mismo tipo de nota de crédito usado por el sistema heredado (`oPurchaseCreditNotes`) y solo después actualiza encabezado y detalle como procesados, almacenando el `DocEntry` de SAP. Si SAP crea el documento pero SQL no puede confirmarlo, el trabajo queda en fallo permanente para impedir duplicados y exigir conciliación manual.

Antes del piloto debe confirmarse con negocio si `oPurchaseCreditNotes` es intencional o si corresponde `oCreditNotes`, así como validar bodegas, UDF de descuentos, moneda e impuestos con la versión real de SAP.
