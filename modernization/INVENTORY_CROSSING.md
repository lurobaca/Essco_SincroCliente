# Cruce de inventario

La página Inventory/Compare compara dos conteos del grupo seleccionado. La diferencia se calcula como primer conteo menos segundo conteo y el importe multiplica por el costo del inventario seleccionado. El umbral incluye la igualdad; las diferencias cero no requieren reconteo.

El botón de cruce admite únicamente 1 contra 2 y genera el conteo 3. En una transacción serializable comprueba que el inventario esté abierto, ambos conteos finalizados, ningún cruce posterior exista y cada artículo tenga una sola fila por conteo y un costo/stock disponible. Un fallo revierte la operación.

Se conserva la convención heredada: Reconteo=1 indica línea resuelta; Reconteo=0 indica pendiente. Las líneas resueltas conservan la cantidad del primer conteo; las pendientes se inicializan en cero. Las columnas CF/DF/DFM siguen la fórmula de Inv_Cruzar.vb y se habilita el conteo 3 en Inv_ConActivo.

Verificado: compilación de toda la solución y pruebas de cálculo, igualdad del umbral y datos ausentes. Pendiente: ejecución de la transacción contra copia SQL, caracterización con inventario real, flujo de finalización de conteos, unificación por proveedor y ajustes SAP. Esta funcionalidad no declara completado todo el módulo.
