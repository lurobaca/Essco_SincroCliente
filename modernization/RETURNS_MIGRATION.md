# Migración de devoluciones

Fuentes heredadas: `Devoluciones.vb`, `Devoluciones_Pendientes.vb`, `SAP_BUSSINES_ONE.AddDevolucion`, `dbo.Devoluciones` y `dbo.DevolucionesDetalle`.

La página `/Returns` presenta la bandeja parametrizada de devoluciones, filtros por estado, agente/chofer y número, además del detalle de artículos. La bodega de cada línea se resuelve desde `MotivoDevolucion`, ya que no forma parte de `DevolucionesDetalle`.

Procesar encola `Return.CreateCreditNote`. El servicio Windows carga nuevamente la devolución, crea mediante DI API el mismo tipo de nota de crédito usado por el sistema heredado (`oPurchaseCreditNotes`) y solo después actualiza encabezado y detalle como procesados, almacenando el `DocEntry` de SAP. Si SAP crea el documento pero SQL no puede confirmarlo, el trabajo queda en fallo permanente para impedir duplicados y exigir conciliación manual.

Antes del piloto debe confirmarse con negocio si `oPurchaseCreditNotes` es intencional o si corresponde `oCreditNotes`, así como validar bodegas, UDF de descuentos, moneda e impuestos con la versión real de SAP.
