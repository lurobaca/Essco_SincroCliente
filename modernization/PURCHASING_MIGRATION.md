# Migración de pedidos a proveedores

Fuentes heredadas: `Pedido_Principal.vb`, `Pedido_EditaLinea.vb`, `Pedido_ListaPedidosGuardados.vb`, `Class_funcionesSQL.vb`, `SAP_BUSSINES_ONE.vb` y `dbo.Pedidor`.

La sección `/Purchasing` implementa la bandeja con filtros parametrizados, detalle, edición segura de cantidades/totales antes del envío y anulación. El envío genera un trabajo idempotente `PurchaseOrder.Create`; el servicio Windows carga de nuevo el pedido, crea una orden de compra SAP (`oPurchaseOrders`, tipo DI API 22) y marca las líneas como creadas/cerradas únicamente después de recibir un `DocEntry` válido.

Si SAP confirma y SQL falla, el trabajo queda en fallo permanente para exigir conciliación y evitar duplicados. Antes del piloto se deben validar contra SAP real la unidad de medida, bodega, moneda, impuestos, fechas de entrega y UDF usados por la instalación. La generación analítica inicial del sugerido de compra (`InbGeneraPedido`) permanece como regla especializada pendiente de contraste con los procedimientos almacenados reales.
