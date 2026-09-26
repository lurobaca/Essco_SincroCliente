# Estados de transmisiones — caracterización funcional

Actualizado: 2026-09-26. Estado global: `PARCIAL`. No existe validación manual del usuario.

## Trazabilidad

- Menú web: Facturación → Estado de transmisiones, permiso `Permissions.Billing`.
- WinForms: `Principal.EstadoDeTransmisionesToolStripMenuItem_Click` abre `EstadoSubida`.
- Datos: `[dbo].[Estado_Subida_SAP]`, con columnas Agente, Archivo, Consecutivo, Estado, Detalle, Fecha y Reintento. El formulario también consulta colas, estado de proceso y configuración FTP.
- Web anterior: el menú llevaba a `/Billing/Index`, que consulta `CE_FE` y no representa las transmisiones.
- Web actual: `/Billing/TransmissionStatus`, PageModel → `ITransmissionStatusRepository` → repositorio SQL. Consulta limitada a 500 filas, con filtros parametrizados. Las escrituras requieren permiso de administración, auditoría y antifalsificación de formularios.

## Matriz por acción

| Acción original | Evento o dependencia | Equivalente web | Estado |
|---|---|---|---|
| Abrir y mostrar errores iniciales | `EstadoSubida_Load` / `Consulta_EstadoError_SubidaSAP` | Consulta de `ERROR` al abrir | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| Filtrar por agente | `txt_SoloAg` / `Consulta_Estado_SubidaSAP` | Campo numérico de agente | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| Filtrar por tipo de archivo | `CBox_Archivo`: Todos, Pedidos, Devoluciones, Pagos | Lista de archivo | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| Ver todos, errores o subidos | `btn_Todos`, `btn_Errores`, `btn_Subido` | Lista de estado y consulta | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| Mostrar agente siguiente y proceso actual | `Timer_AGEjecucion_Tick` / tablas de control | Consulta de tablas de control al abrir la página; sin actualización automática | PARCIAL |
| Avisar que no hay archivo FTP | `Timer_AGEjecucion_Tick` / `Consulta_InfoNOARCHIVO_FTP` | Muestra las primeras diez alertas activas; no consume ni limpia la señal | PARCIAL |
| Limpiar errores | `btn_LimpError` / `LimpiaEstadoSubidoSAP` | Elimina solo registros ERROR de un agente indicado y confirmado | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| Limpiar subidos | `btn_LimpSubidos` / `LimpiaEstadoSubidoSAP` | Elimina solo registros SUBIDO de un agente indicado y confirmado | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| Solo subir | `btn_subir` / cola y archivo `Revisame` en FTP | Sin equivalente | NO MIGRADA |
| Recargar y subir | `btn_RecargSubir` / limpieza, marca de recarga, cola y FTP | Sin equivalente | NO MIGRADA |
| Recargar todos | `btn_RecargaTodos` / iteración de agentes y FTP | Sin equivalente | NO MIGRADA |
| Seleccionar fila para reintentar | `DGV_EstadoSubida.MouseClick` / `CambiaEstadoReinsertar` | Botón explícito por fila ERROR; solo actualiza `Reintento`, no confirma procesamiento externo | PARCIAL |
| Alternar origen FTP/local | `BTN_LocalFtp.Click` / `Bloquea_Desbloquea_DescargardeFTP` | Lectura y actualización de `BajarDeFTP`, sin cambiar al cerrar la página | PARCIAL |
| Bloqueo de pedidos de hoy | carga, timer y cierre; botón oculto en diseñador | Sin equivalente | NO MIGRADA |

## Riesgos y decisiones

El SQL WinForms concatena filtros y algunas rutas de limpieza pueden afectar todos los agentes si el campo está vacío. La Web restringe la limpieza a un agente explícito, usa parámetros, exige la palabra de confirmación y audita la acción: esta es una diferencia de seguridad deliberada respecto al origen. La marca de reintento se limita a una fila ERROR inequívoca; si hay duplicados no se modifica ninguna. El cambio de origen FTP/local es global y no se revierte automáticamente al cerrar la página, otra divergencia a validar con el usuario. El disparo de FTP/cola requiere caracterizar el proceso externo y probarlo en un entorno controlado. No se cambió el esquema de base de datos.

La fecha y el reintento se presentan como texto para conservar la representación de los valores heredados hasta contrastar sus tipos reales en la base de prueba. `Sic_Local_Web_Pruebas` contiene cero filas en la bitácora, por lo que las mutaciones aún no tienen prueba con registros reales. La pantalla no está declarada equivalente funcional completo.
