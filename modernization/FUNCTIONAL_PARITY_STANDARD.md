# Estándar global de paridad funcional

Vigente desde: 2026-09-19.

Este estándar aplica retroactivamente a todos los módulos de la migración de Sincro Cliente.

## Unidad mínima de trazabilidad

```text
Módulo
→ Form
→ pestaña o sección
→ control o acción
→ evento WinForms
→ comportamiento
→ reglas y validaciones
→ datos e integraciones afectadas
→ efectos secundarios
→ resultado esperado
→ equivalente Web
→ prueba
→ estado
→ validación del usuario
```

Una página, servicio, repositorio, endpoint o compilación exitosa no constituye por sí solo una funcionalidad migrada.

## Condición funcional

- `MIGRADA`: equivalente Web ejecutable, probado y trazable.
- `PARCIAL`: existe implementación Web, pero falta comportamiento, prueba, efecto secundario o integración.
- `NO MIGRADA`: no existe equivalente funcional ejecutable.
- `NO APLICA / OBSOLETA`: requiere justificación documentada y aprobación explícita del usuario.

## Estados de seguimiento

- `NO INICIADO`
- `ANALIZADO`
- `EN DESARROLLO`
- `IMPLEMENTADO`
- `VERIFICADO POR CODEX`
- `PENDIENTE VALIDACIÓN USUARIO`
- `VALIDADO`
- `INCORRECTO / REQUIERE REVISIÓN`

`IMPLEMENTADO` no significa necesariamente `MIGRADA`: todavía puede faltar verificación funcional, integración o comparación con WinForms. `VALIDADO` solamente puede asignarse después de la confirmación manual del usuario.

## Matriz obligatoria por módulo

Cada módulo debe documentar, como mínimo:

| Campo | Contenido requerido |
|---|---|
| Módulo | Área funcional |
| Form | Formulario de origen |
| Pestaña/sección | Contexto funcional |
| Control/acción | Interacción concreta |
| Evento WinForms | Evento real que dispara la operación |
| Comportamiento | Resultado observable |
| Reglas | Reglas de negocio y cálculos |
| Validaciones | Entradas y estados permitidos |
| Datos afectados | Tablas, vistas, SP y archivos |
| Integraciones | SAP, Hacienda, correo, FTP, reportes u otras |
| Efectos secundarios | Cambios adicionales provocados por la operación |
| Equivalente Web | Forma en que el usuario ejecuta la operación |
| Implementación Web | Página, handler, servicio y repositorio |
| Prueba | Caso automatizado o manual que demuestra equivalencia |
| Condición | Migrada, parcial, no migrada o no aplica aprobada |
| Estado | Estado de seguimiento |
| Observaciones | Diferencias y trabajo pendiente |

No se deben agrupar acciones distintas cuando la agrupación pueda ocultar faltantes. Consultar, crear, editar, anular, eliminar, imprimir, adjuntar, descargar, aprobar, rechazar y procesar se trazan por separado.

## Revisión obligatoria de comportamiento

Para cada evento se seguirá la ejecución hasta identificar:

1. Métodos y clases invocados.
2. Consultas y persistencia.
3. Archivos e integraciones.
4. estados y transiciones.
5. permisos.
6. cálculos y validaciones.
7. efectos secundarios.
8. mensajes y errores relevantes.
9. Forms o procesos dependientes.

También se trazan comportamientos implícitos: carga, selección de filas, doble clic, cambios de combos/checkboxes, validaciones Leave, cálculos automáticos, bloqueo de campos, cierre, importación, exportación, sincronización e impresión.

## Criterio para `VERIFICADO POR CODEX`

Todas las acciones requeridas deben tener equivalente Web o excepción aprobada; consultas y mutaciones deben funcionar; reglas, estados, permisos, adjuntos, reportes, integraciones y efectos secundarios deben estar reproducidos; la persistencia debe comprobarse; y deben existir pruebas y comparación contra WinForms.

Si falta una sola funcionalidad relevante, el módulo permanece parcial.

## Métrica

El avance se reporta por casos de uso trazados:

- acciones identificadas;
- migradas y verificadas;
- parciales;
- no migradas;
- excepciones aprobadas;
- validadas por el usuario.

No se calcula avance a partir de archivos, páginas, clases, endpoints o líneas de código. Si las acciones tienen complejidades muy diferentes, no se presenta un porcentaje único sin explicar esa limitación.

## Estrategia

La aplicación de este estándar es progresiva y vertical: se audita, completa y prueba un módulo a la vez. No autoriza refactorizaciones masivas ni trabajo simultáneo sobre todos los módulos.
