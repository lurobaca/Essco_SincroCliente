# Cruce de inventario

SupplierSummary ofrece una vista previa de la unificación por proveedor: suma las líneas del conteo 3 del inventario seleccionado, calcula diferencia como Stock menos suma (convención de GuardaGrupo en Inv_Cruzar.vb) y aplica el umbral monetario inclusivo. Detecta artículos sin conteo o sin maestro, duplicados dentro del mismo grupo y reconteos pendientes. No certifica finalización de grupos, no crea el conteo 4 y no modifica datos. La escritura transaccional de unificación continúa pendiente.

La página Inventory/Compare compara dos conteos del grupo seleccionado. La diferencia se calcula como primer conteo menos segundo conteo y el importe multiplica por el costo del inventario seleccionado. El umbral incluye la igualdad; las diferencias cero no requieren reconteo.

El botón de cruce admite únicamente 1 contra 2 y genera el conteo 3. En una transacción serializable comprueba que el inventario esté abierto, ambos conteos finalizados, ningún cruce posterior exista y cada artículo tenga una sola fila por conteo y un costo/stock disponible. Un fallo revierte la operación.

Se conserva la convención heredada: Reconteo=1 indica línea resuelta; Reconteo=0 indica pendiente. Las líneas resueltas conservan la cantidad del primer conteo; las pendientes se inicializan en cero. Las columnas CF/DF/DFM siguen la fórmula de Inv_Cruzar.vb y se habilita el conteo 3 en Inv_ConActivo.

La página CompleteCount finaliza un conteo activo de un inventario abierto. Requiere filas con cantidades válidas y no negativas; desde el conteo 3 exige que todas las líneas estén resueltas. La actualización es transaccional y revierte si no afecta exactamente un control. Guardar un reconteo lo marca resuelto y el repositorio rechaza modificaciones de conteos finalizados. Los formularios rechazan errores de conversión antes de guardar.

Verificado: compilación de toda la solución (incluidos Web y Worker), 120 pruebas unitarias y 4 de integración. Estas pruebas no ejecutan las nuevas transacciones contra SQL Server. Pendiente: ejecución de las transacciones contra copia SQL, caracterización con inventario real, unificación por proveedor y ajustes SAP. Esta funcionalidad no declara completado todo el módulo.
