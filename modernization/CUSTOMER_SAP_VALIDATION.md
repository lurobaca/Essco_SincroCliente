# Validación de solicitudes antes de SAP

El despacho rechaza identificadores inválidos y valida la solicitud antes de crear el trabajo. El Worker vuelve a validar los datos actuales, el identificador del payload y la coincidencia entre operación y estado. Una solicitud aprobada no oculta una operación incompatible.

Altas y modificaciones requieren datos válidos y una única coincidencia con nombre no vacío en cada catálogo geográfico. Ya no se sustituye un nombre ausente por su identificador numérico. Estos errores no son reintentables automáticamente: requieren corregir la solicitud o los catálogos.

El cierre solo necesita un código válido para el adaptador existente; no consulta geografía ni exige datos tributarios que esa operación no utiliza.

Las pruebas utilizan repositorios y adaptadores simulados. Cubren payloads inválidos, estado incompatible, datos inválidos, ubicación inexistente, cierre sin catálogos y rechazo antes de encolar. No se enviaron datos a SAP.

Pendientes: validación real en sociedad de pruebas, concurrencia entre edición y procesamiento, y recuperación cuando SAP confirma un alta pero falla la confirmación SQL. La cola referencia la solicitud por id; no representa una instantánea inmutable de sus campos.
