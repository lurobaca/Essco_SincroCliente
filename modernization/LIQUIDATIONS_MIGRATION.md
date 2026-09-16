# Migración de liquidaciones

Fuentes heredadas: `Liquidacion_Agentes.vb`, `Liquidacion_Choferes.vb`, `Lista_LiquidacionesAgentes.vb`, `Lista_LiquidacionesChoferes.vb`, `dbo.Liquidaciones` y `dbo.Liquidaciones_Choferes`.

La página `/Liquidations` unifica consulta, creación, edición y anulación lógica. Conserva las dos tablas y sus campos específicos: rangos de recibos, lista de agentes y códigos de reportes para choferes. La creación reserva `ConseLiqAgentes` o `ConseLiqChoferes` e inserta dentro de una transacción serializable, evitando que dos usuarios reciban el mismo consecutivo.

El acceso usa `liquidation-differences.access` y todas las mutaciones se auditan. Los registros anulados no se pueden editar.

Este incremento cubre la cabecera. Aún deben incorporarse al flujo transaccional los depósitos, recibos, gastos, facturas, devoluciones, diferencias calculadas y generación de reportes; hasta entonces no existe paridad completa con las pantallas heredadas.
