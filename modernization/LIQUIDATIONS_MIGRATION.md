# Migración de liquidaciones

Fuentes heredadas: `Liquidacion_Agentes.vb`, `Liquidacion_Choferes.vb`, `Lista_LiquidacionesAgentes.vb`, `Lista_LiquidacionesChoferes.vb`, `dbo.Liquidaciones` y `dbo.Liquidaciones_Choferes`.

La página `/Liquidations` unifica consulta, creación, edición y anulación lógica. Conserva las dos tablas y sus campos específicos: rangos de recibos, lista de agentes y códigos de reportes para choferes. La creación reserva `ConseLiqAgentes` o `ConseLiqChoferes` e inserta dentro de una transacción serializable, evitando que dos usuarios reciban el mismo consecutivo.

El acceso usa `liquidation-differences.access` y todas las mutaciones se auditan. Los registros anulados no se pueden editar.

La página `/Liquidations/Expenses` migra el mantenimiento de `dbo.GastosLiquidaciones`: consulta parametrizada, creación con reserva transaccional de `ConseGastos`, edición, asociación a liquidación y anulación lógica. Conserva la marca de factura electrónica, proveedor, inclusión y estado de Hacienda.

El resumen web consolida facturas, depósitos, recibos SAP y gastos vinculados. Conserva la fórmula heredada de diferencia `(depósitos + gastos) - recibos` y permite recalcular el resultado persistido. Las facturas se muestran para conciliación, pero no participan en esa fórmula histórica.

Aún deben incorporarse al flujo transaccional las devoluciones, el cierre definitivo y la generación de reportes PDF.
