# Migración de liquidaciones

Fuentes heredadas: `Liquidacion_Agentes.vb`, `Liquidacion_Choferes.vb`, `Lista_LiquidacionesAgentes.vb`, `Lista_LiquidacionesChoferes.vb`, `dbo.Liquidaciones` y `dbo.Liquidaciones_Choferes`.

La página `/Liquidations` unifica consulta, creación, edición y anulación lógica. Conserva las dos tablas y sus campos específicos: rangos de recibos, lista de agentes y códigos de reportes para choferes. La creación reserva `ConseLiqAgentes` o `ConseLiqChoferes` e inserta dentro de una transacción serializable, evitando que dos usuarios reciban el mismo consecutivo.

El acceso usa `liquidation-differences.access` y todas las mutaciones se auditan. Los registros anulados no se pueden editar.

La página `/Liquidations/Expenses` migra el mantenimiento de `dbo.GastosLiquidaciones`: consulta parametrizada, creación con reserva transaccional de `ConseGastos`, edición, asociación a liquidación y anulación lógica. Conserva la marca de factura electrónica, proveedor, inclusión y estado de Hacienda.

El resumen web consolida facturas, depósitos, recibos SAP y gastos vinculados. Conserva la fórmula heredada de diferencia `(depósitos + gastos) - recibos` y permite recalcular el resultado persistido. Las facturas se muestran para conciliación, pero no participan en esa fórmula histórica.

Aún deben incorporarse al flujo transaccional las devoluciones, el cierre definitivo y la generación de reportes PDF.

## Validación y conciliación

Se rechazan tipos de responsable desconocidos, textos que exceden las longitudes SQL y modificaciones sin consecutivo válido. La creación exige una única fila de configuración de consecutivos, con valor positivo y sin desbordamiento; comprueba una sola inserción y una sola actualización del consecutivo antes de confirmar la transacción. Un retorno sin confirmar revierte al disponer la transacción.

La suma de depósitos incluye DP_TIPO_LIQ además de DPLIQUIDACION, evitando mezclar consecutivos de agentes y choferes. El recálculo bloquea la cabecera activa y consulta los importes y actualiza Resultado dentro de la misma transacción serializable. Requiere acceso de lectura a SAP en la misma instancia, como la consulta previa. Debe probarse contra copia SQL con números coincidentes entre tipos y operaciones concurrentes.

En los formularios revisados se comprobó bloqueo de edición por Anulada, pero no se identificó un estado independiente de cierre definitivo. No se añadió ninguna columna ni regla de cierre sin evidencia del esquema. La revisión de ese flujo sigue pendiente; no debe confundirse guardar o recalcular con cerrar.
