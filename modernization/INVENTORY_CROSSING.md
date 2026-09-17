# Cruce de inventario

## Comprobación previa de grupos

La vista de proveedor consulta ahora los grupos originales (LEN(idGrupo)=1, como PuedeUnifica) del inventario explícitamente seleccionado. Cada grupo debe tener exactamente un control del conteo 3 y estar finalizado. Ausencia, duplicados o controles pendientes impiden confirmar la finalización. Esta consulta es informativa; la futura escritura debe repetir las comprobaciones en su propia transacción. No se ha probado esta consulta contra una copia SQL real.

Regla confirmada por el usuario: las diferencias se recuentan tantas veces como el usuario decida, sin límite funcional fijo (4, 5, 6, etc.). Se conserva el historial de conteos.

La página Recount permite seleccionar códigos de artículos, uno por línea, y crear el sucesor de un conteo finalizado desde el 3. La transacción comprueba inventario abierto, un único control finalizado, ausencia de sucesores y líneas válidas/resueltas sin duplicados. Copia todas las líneas al siguiente número: las seleccionadas quedan en cero y pendientes; las demás conservan su cantidad y estado resuelto. No sobrescribe conteos anteriores. El cierre de inventario rechaza controles todavía abiertos. La consulta utiliza OPENJSON (requiere SQL Server con compatibilidad 130 o superior); falta validación de esquema, concurrencia y ejecución contra copia SQL.

Este incremento no crea todavía el grupo unificado por proveedor ni acepta sus cantidades como resultado definitivo. La creación del conteo inicial de ese grupo y la aceptación final siguen pendientes; finalizar un conteo solo bloquea su captura.

SupplierSummary ofrece una vista previa de la unificación por proveedor: suma las líneas del conteo 3 del inventario seleccionado, calcula diferencia como Stock menos suma (convención de GuardaGrupo en Inv_Cruzar.vb) y aplica el umbral monetario inclusivo. Detecta artículos sin conteo o sin maestro, duplicados dentro del mismo grupo y reconteos pendientes. No certifica finalización de grupos, no crea el conteo 4 y no modifica datos. La escritura transaccional de unificación continúa pendiente.

La página Inventory/Compare compara dos conteos del grupo seleccionado. La diferencia se calcula como primer conteo menos segundo conteo y el importe multiplica por el costo del inventario seleccionado. El umbral incluye la igualdad; las diferencias cero no requieren reconteo.

El botón de cruce admite únicamente 1 contra 2 y genera el conteo 3. En una transacción serializable comprueba que el inventario esté abierto, ambos conteos finalizados, ningún cruce posterior exista y cada artículo tenga una sola fila por conteo y un costo/stock disponible. Un fallo revierte la operación.

Se conserva la convención heredada: Reconteo=1 indica línea resuelta; Reconteo=0 indica pendiente. Las líneas resueltas conservan la cantidad del primer conteo; las pendientes se inicializan en cero. Las columnas CF/DF/DFM siguen la fórmula de Inv_Cruzar.vb y se habilita el conteo 3 en Inv_ConActivo.

La página CompleteCount finaliza un conteo activo de un inventario abierto. Requiere filas con cantidades válidas y no negativas; desde el conteo 3 exige que todas las líneas estén resueltas. La actualización es transaccional y revierte si no afecta exactamente un control. Guardar un reconteo lo marca resuelto y el repositorio rechaza modificaciones de conteos finalizados. Los formularios rechazan errores de conversión antes de guardar.

Verificado: compilación de toda la solución (incluidos Web y Worker), 120 pruebas unitarias y 4 de integración. Estas pruebas no ejecutan las nuevas transacciones contra SQL Server. Pendiente: ejecución de las transacciones contra copia SQL, caracterización con inventario real, unificación por proveedor y ajustes SAP. Esta funcionalidad no declara completado todo el módulo.
