# Estados de transmisiones — caracterización funcional

Actualizado: 2026-09-26. Estado global: `PARCIAL`. No existe validación manual del usuario.

## Trazabilidad

- Menú web: Facturación → Estado de transmisiones, permiso `Permissions.Billing`.
- WinForms: `Principal.EstadoDeTransmisionesToolStripMenuItem_Click` abre `EstadoSubida`.
- Datos: `[dbo].[Estado_Subida_SAP]`, con columnas Agente, Archivo, Consecutivo, Estado, Detalle, Fecha y Reintento. El formulario también consulta colas, estado de proceso y configuración FTP.
- Web anterior: el menú llevaba a `/Billing/Index`, que consulta `CE_FE` y no representa las transmisiones.
- Web actual: `/Billing/TransmissionStatus`, consulta limitada a 500 filas, con filtros parametrizados y sin escrituras.

## Matriz por acción

| Acción original | Evento o dependencia | Equivalente web | Estado |
|---|---|---|---|
| Abrir y mostrar errores iniciales | `EstadoSubida_Load` / `Consulta_EstadoError_SubidaSAP` | Consulta de `ERROR` al abrir | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| Filtrar por agente | `txt_SoloAg` / `Consulta_Estado_SubidaSAP` | Campo numérico de agente | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| Filtrar por tipo de archivo | `CBox_Archivo`: Todos, Pedidos, Devoluciones, Pagos | Lista de archivo | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| Ver todos, errores o subidos | `btn_Todos`, `btn_Errores`, `btn_Subido` | Lista de estado y consulta | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| Mostrar agente siguiente y proceso actual | `Timer_AGEjecucion_Tick` / tablas de control | Sin equivalente | NO MIGRADA |
| Avisar que no hay archivo FTP | `Timer_AGEjecucion_Tick` / `Consulta_InfoNOARCHIVO_FTP` | Sin equivalente | NO MIGRADA |
| Limpiar errores | `btn_LimpError` / `LimpiaEstadoSubidoSAP` | Sin equivalente; elimina registros | NO MIGRADA |
| Limpiar subidos | `btn_LimpSubidos` / `LimpiaEstadoSubidoSAP` | Sin equivalente; elimina registros | NO MIGRADA |
| Solo subir | `btn_subir` / cola y archivo `Revisame` en FTP | Sin equivalente | NO MIGRADA |
| Recargar y subir | `btn_RecargSubir` / limpieza, marca de recarga, cola y FTP | Sin equivalente | NO MIGRADA |
| Recargar todos | `btn_RecargaTodos` / iteración de agentes y FTP | Sin equivalente | NO MIGRADA |
| Seleccionar fila para reintentar | `DGV_EstadoSubida.MouseClick` / `CambiaEstadoReinsertar` | Sin equivalente | NO MIGRADA |
| Alternar origen FTP/local | `BTN_LocalFtp.Click` / `Bloquea_Desbloquea_DescargardeFTP` | Sin equivalente | NO MIGRADA |
| Bloqueo de pedidos de hoy | carga, timer y cierre; botón oculto en diseñador | Sin equivalente | NO MIGRADA |

## Riesgos y decisiones

El SQL WinForms concatena filtros y algunas rutas de limpieza pueden afectar todos los agentes si el campo está vacío. No se trasladan esas consultas ni se exponen operaciones destructivas sin delimitar autorización, confirmación, auditoría y alcance de filas. El disparo de FTP/cola requiere caracterizar el proceso externo y probarlo en un entorno controlado. No se cambió el esquema de base de datos. La consulta web solo usa parámetros y el permiso de facturación existente.

La fecha y el reintento se presentan como texto para conservar la representación de los valores heredados hasta contrastar sus tipos reales en la base de prueba. La pantalla no está declarada equivalente funcional completo.
