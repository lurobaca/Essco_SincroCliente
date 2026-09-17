# Cruce de inventario

## Cierre general

El cierre exige inventario abierto, todos los controles finalizados y todos los artículos unificados. Comprueba que cada artículo tenga exactamente una cantidad aceptada en el último conteo de un grupo unificado y que coincida con CF. Rechaza artículos duplicados, datos ausentes y cantidades negativas. Calcula los importes de cierre a partir de esas cantidades dentro de una transacción serializable: ENTRADAS positivas y SALIDAS negativas según (CF-Stock)*Costo, como Inv_Control.vb. Ignora los importes enviados por el formulario. No crea ajustes SAP.

Pruebas pendientes en una copia SQL aislada: dos solicitudes simultáneas de unificación (solo una debe crear el grupo); dos solicitudes del mismo reconteo (solo una debe crear el sucesor); fallo a mitad de una operación (sin cambios parciales); conteos 9/10 (orden numérico); cierre con reconteo pendiente (rechazado); finalización del reconteo 10 y cierre (cantidades coincidentes); modificación concurrente durante el cierre. No ejecutar estas pruebas en producción.

## Comprobación previa de grupos

La vista de proveedor consulta los grupos originales (LEN(idGrupo)=1, como PuedeUnifica) del inventario explícitamente seleccionado. Cada grupo debe tener exactamente un control del último conteo (desde el 3) y estar finalizado. Ausencia, duplicados o controles pendientes impiden confirmar la finalización. Esta consulta es informativa; la escritura repite las comprobaciones en su propia transacción. No se ha probado esta consulta contra una copia SQL real.

Regla confirmada por el usuario: las diferencias se recuentan tantas veces como el usuario decida, sin límite funcional fijo (4, 5, 6, etc.). Se conserva el historial de conteos.

La página Recount permite seleccionar códigos de artículos, uno por línea, y crear el sucesor de un conteo finalizado desde el 3. La transacción comprueba inventario abierto, un único control finalizado, ausencia de sucesores y líneas válidas/resueltas sin duplicados. Copia todas las líneas al siguiente número: las seleccionadas quedan en cero y pendientes; las demás conservan su cantidad y estado resuelto. No sobrescribe conteos anteriores. El cierre de inventario rechaza controles todavía abiertos. La selección se carga mediante SqlBulkCopy en una tabla temporal de la misma conexión/transacción, sin OPENJSON ni límite de 2100 parámetros. No se cambia el nivel de compatibilidad de la base.

Consolidate crea el grupo unificado (código de 2 a 50 caracteres para distinguirlo de los grupos originales), su conteo 4 y el control activo en una transacción serializable. Suma el último conteo finalizado de cada grupo original; rechaza proveedores ya unificados, grupos existentes, datos incompletos y artículos duplicados. Actualiza Unificado/CF/DF/DFM. Las diferencias que alcanzan el umbral conservan la suma como referencia, pero quedan pendientes de captura. Al finalizar el último conteo de un grupo unificado se actualizan CF/DF/DFM con las cantidades aceptadas en esa misma transacción. Es posible recontar nuevamente antes del cierre general. No se permiten nuevos reconteos en grupos originales cuyos artículos ya se unificaron; deben hacerse en el grupo unificado.

SupplierSummary ofrece una vista previa de la unificación por proveedor: suma el último conteo desde el 3 de cada grupo original, excluye grupos unificados para no duplicar cantidades, calcula diferencia como Stock menos suma (convención de GuardaGrupo en Inv_Cruzar.vb) y aplica el umbral monetario inclusivo. Detecta artículos sin conteo o sin maestro, duplicados dentro del mismo grupo y reconteos pendientes. No modifica datos.

La página Inventory/Compare compara dos conteos del grupo seleccionado. La diferencia se calcula como primer conteo menos segundo conteo y el importe multiplica por el costo del inventario seleccionado. El umbral incluye la igualdad; las diferencias cero no requieren reconteo.

El botón de cruce admite únicamente 1 contra 2 y genera el conteo 3. En una transacción serializable comprueba que el inventario esté abierto, ambos conteos finalizados, ningún cruce posterior exista y cada artículo tenga una sola fila por conteo y un costo/stock disponible. Un fallo revierte la operación.

Se conserva la convención heredada: Reconteo=1 indica línea resuelta; Reconteo=0 indica pendiente. Las líneas resueltas conservan la cantidad del primer conteo; las pendientes se inicializan en cero. Las columnas CF/DF/DFM siguen la fórmula de Inv_Cruzar.vb y se habilita el conteo 3 en Inv_ConActivo.

La página CompleteCount finaliza un conteo activo de un inventario abierto. Requiere filas con cantidades válidas y no negativas; desde el conteo 3 exige que todas las líneas estén resueltas. La actualización es transaccional y revierte si no afecta exactamente un control. Guardar un reconteo lo marca resuelto y el repositorio rechaza modificaciones de conteos finalizados. Los formularios rechazan errores de conversión antes de guardar.

La suite incluye pruebas de validación de solicitudes y selección del último reconteo por grupo. Además, scripts/Test-InventorySqlCompatibility.ps1 ejecuta los literales SQL de los repositorios contra tablas temporales con datos ficticios. Pasaron nueve escenarios en SQL Server 2014 con compatibilidad 100: reconteos sucesivos 4–6, seis rechazos de estados/selecciones inválidos, recorrido cruce-finalización-unificación-cierre y copia del universo numérico con sector textual.

Estas pruebas sustituyen únicamente nombres de tablas por tablas temporales; no modifican inventarios reales. No ejercitan SqlBulkCopy, las transacciones C# completas, concurrencia, permisos reales ni vistas SAP. Esas verificaciones, la caracterización con inventario real y los ajustes SAP siguen pendientes. Esta funcionalidad no declara completado todo el módulo.
