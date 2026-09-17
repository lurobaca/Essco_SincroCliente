# Validación de solicitudes antes de SAP

El despacho rechaza identificadores inválidos y valida la solicitud antes de crear el trabajo. El Worker vuelve a validar los datos actuales, el identificador del payload y la coincidencia entre operación y estado. Una solicitud aprobada no oculta una operación incompatible.

Altas y modificaciones requieren datos válidos y una única coincidencia con nombre no vacío en cada catálogo geográfico. Ya no se sustituye un nombre ausente por su identificador numérico. Estos errores no son reintentables automáticamente: requieren corregir la solicitud o los catálogos.

El cierre solo necesita un código válido para el adaptador existente; no consulta geografía ni exige datos tributarios que esa operación no utiliza.

Las pruebas utilizan repositorios y adaptadores simulados. Cubren payloads inválidos, estado incompatible, datos inválidos, ubicación inexistente, cierre sin catálogos y rechazo antes de encolar. No se enviaron datos a SAP.

Los trabajos nuevos incluyen una huella SHA-256 de los datos de la solicitud (excluyendo el indicador de aprobación). La clave de idempotencia incluye esa huella: reenviar los mismos datos conserva la clave; cambiar datos genera otra versión. El Worker compara la huella antes de contactar SAP. No guarda una copia adicional de datos personales ni de la clave web en el payload.

Los trabajos antiguos sin huella se rechazan sin reintento automático y deben reenviarse desde Clientes. Actualizar juntos Web y Worker; no mantener un Worker antiguo procesando payloads nuevos, pues no aplicaría esta validación.

Pendientes: validación real en sociedad de pruebas, concurrencia durante la llamada externa (la comprobación previa no bloquea ediciones posteriores), y recuperación cuando SAP confirma un alta pero falla la confirmación SQL. La cola no representa una instantánea inmutable ni resuelve por sí sola la aprobación atómica de la versión procesada.
