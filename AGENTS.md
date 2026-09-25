# Instrucciones permanentes — ESSCO / Syncro Cliente

Este archivo rige el trabajo de agentes en todo este repositorio. Aplicar estas reglas a cada módulo y tarea futura junto con la solicitud vigente. No refactorizar archivos ajenos al alcance solo para imponer el estilo.

## Prioridades y fuente funcional

- Priorizar correctitud funcional, legibilidad, simplicidad, mantenibilidad, seguridad y consistencia. La abstracción solo se justifica cuando resuelve un problema real.
- El Syncro Cliente WinForms original es la fuente de verdad del comportamiento durante la migración. Investigar el formulario, sus eventos y dependencias directas antes de cambiar reglas. Migrar comportamiento, no SQL inseguro ni deuda técnica.
- No inferir paridad de la presencia de una pantalla. Trazar botones, eventos, validaciones, consultas, cálculos, archivos, reportes, integraciones y efectos en base de datos.
- No cambiar silenciosamente una regla heredada extraña. Documentar la diferencia y consultar al usuario cuando altere el comportamiento esperado.
- Utilizar únicamente `NO MIGRADA`, `PARCIAL`, `IMPLEMENTADA PENDIENTE VALIDACIÓN` y `VALIDADA POR USUARIO` para el estado funcional. Solo el usuario puede confirmar la última categoría.

## Código legible

- Escribir para quien deba comprender y modificar el código dentro de seis meses. Usar nombres descriptivos que representen el significado comprobado; evitar abreviaturas ambiguas como `c`, `cmd`, `r` o `t` cuando `connection`, `command`, `reader` o `cancellationToken` sean más claros.
- En C#, usar llaves Allman, una instrucción por línea, firmas y llamadas largas divididas, SQL formateado y métodos de propósito reconocible. No compactar `if`, bucles, `using`, validaciones o métodos enteros en una línea. Preferir `async`/`await` y sufijo `Async` cuando corresponda.
- Aplicar Clean Code con criterio: no introducir capas, interfaces, factories, helpers, repositorios genéricos, CQRS, MediatR, AutoMapper, buses, frameworks o paquetes nuevos sin necesidad funcional concreta.
- Al tocar una zona excesivamente compacta, normalizar esa zona si puede hacerse sin cambiar comportamiento; no ejecutar transformaciones globales por esta regla.
- Mantener el flujo UI → PageModel/Controller → Application/Service → Infrastructure/Repository → SQL/SAP explícito. Gestionar `null`, excepciones y errores con decisiones visibles; no ocultar fallos de integraciones ni inventar resultados positivos.
- Validar identidad, permisos, parámetros, identificadores y archivos en backend; ocultar botones no equivale a autorización.

## Comentarios y presentación

- Escribir **en español** toda documentación y comentario propio: XML `<summary>` de clases, interfaces y métodos; bloques lógicos internos; JSDoc; Razor/HTML; CSS; SQL y documentación técnica. Mantener identificadores existentes en su convención técnica.
- Comentar la intención de reglas empresariales, seguridad, cálculos, SQL, SAP y decisiones no evidentes; no repetir sintaxis obvia. Documentar los métodos propios relevantes, incluidos privados y métodos de interfaces.
- Mantener Razor/HTML expandido e indentado, con secciones identificables. Dejar la lógica empresarial fuera de las vistas. Escribir JavaScript fuente legible, con JSDoc en español para funciones nuevas.
- Organizar CSS propio por secciones, una propiedad por línea, usando estilos y tokens existentes antes de duplicarlos.

## Verificación, alcance y Git

- Compilar después de cada bloque coherente y ejecutar pruebas que protejan reglas, estados, cálculos, permisos, errores o integraciones relevantes. No equiparar pruebas verdes con validación manual.
- Respetar la rama indicada. Crear commits pequeños y coherentes sin incorporar cambios locales ajenos al trabajo; no hacer push sin autorización del flujo vigente.
- Revisar primero la documentación de `modernization` y las fuentes directamente relacionadas con la tarea. No reanalizar todo WinForms ni normalizar todo el repositorio en cada turno.
- Mantener `modernization/ARCHITECTURE_GUIDE.md` solo cuando haya cambios arquitectónicos reales.
- Cuando una regla o dato no se pueda establecer con evidencia, buscar en código, documentación, WinForms, pruebas e historial relevante; si persiste la ambigüedad, reportarla sin adivinar.
