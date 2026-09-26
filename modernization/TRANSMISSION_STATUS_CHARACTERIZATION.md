# Estados de transmisiones — caracterización funcional

Actualizado: 2026-09-26. Estado global: `PARCIAL`. No existe validación manual del usuario.

## Paridad visual y de controles

El `Designer` sitúa los controles en dos filas compactas (`y=10–78`) y el grid a partir de `y=86`, anclado a los cuatro bordes. La Web conserva una barra operativa de dos filas seguida inmediatamente por un grid que ocupa el espacio disponible. En tablet y móvil la barra envuelve los controles y el grid permite desplazamiento horizontal; no se usan coordenadas fijas.

| Control WinForms | Evento o propósito comprobado | Equivalente Web y ubicación | Estado |
|---|---|---|---|
| `Label1` / `CBox_Archivo` | Selecciona Todos, Pedidos, Devoluciones o Pagos para las consultas | Archivo y lista al inicio de la fila superior | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| `btn_Todos`, `btn_Errores`, `btn_Subido` | Consultan la bitácora con el estado correspondiente | Tres botones de consulta agrupados junto a Archivo | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| `btn_LimpError`, `btn_LimpSubidos` | Eliminan el estado seleccionado del agente escrito | Limpiar Errores / Limpiar Subidos en la fila superior; exige agente, confirmación y permiso | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| `Button1` (Nube) | Oculto en Designer; sin evento conectado | Indicador Nube sin acción, junto a FTP | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| `BTN_LocalFtp` | Alterna la bandera SQL y muestra FTP o LOCAL | Botón FTP/LOCAL junto a Nube; cambio global protegido | PARCIAL |
| `Button5` (HOY) | Oculto en Designer; el Timer refleja `FiltraHOY.HoySi` y además reescribe ese valor | Indicador HOY BLOQUEADO/DESBLOQUEADO de solo lectura; no reescribe SQL | PARCIAL |
| `Label4` / `txt_SoloAg` | Entrada #Agente para consultas y acciones | #Agente al comienzo de la segunda fila | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| `btn_RecargSubir`, `btn_subir`, `btn_RecargaTodos` | Limpieza, cola, archivo de señal y FTP según acción | Tres botones en la segunda fila, deshabilitados por dependencia externa | PARCIAL |
| `LbL_AgEjecucion` / `Lbl_Procesando` | Agente siguiente y proceso actual consultados por Timer | #Ag y proceso al final de la segunda fila | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| `Timer_AGEjecucion` | Consulta agente, proceso, señal FTP y bloqueo de hoy; intervalo no configurado explícitamente en Designer | Polling de señales de solo lectura cada 15 s mientras la pestaña está visible | PARCIAL |
| `DGV_EstadoSubida` | Dos columnas declaradas (`Fecha`, `Archivo`); el `DataSource` agrega Agente, Archivo, Consecutivo, Estado, Detalle, Fecha y Reintento en ejecución | Grid inmediatamente bajo la barra, con las siete columnas efectivas más una acción compacta de reintento | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| `CheckedListBox1` | Fuera del área visible (`x=-60`, `y=-83`), sin evento | No aplica en Web: no hay interacción visible que reproducir | NO MIGRADA |

`DataGridView.MouseClick` llama `CambiaEstadoReinsertar` para la fila seleccionada. La Web usa un botón explícito en filas ERROR para evitar cambios accidentales y limita la escritura a una fila inequívoca. Esta diferencia de interacción requiere validación del usuario. `Timer1_Tick` existe sin `Handles` y no se ejecuta; no se replica.

El Timer original también consume `InfoTransmision` y actualiza `FiltraHOY.HoySi`. La Web presenta alertas FTP sin consumir esa señal y lee el bloqueo sin escribirlo. Esas divergencias evitan que abrir o cerrar una pestaña del navegador cambie el estado global del servidor, pero impiden declarar paridad funcional completa. El Timer de WinForms no define `Interval` en Designer y por tanto utiliza el valor predeterminado del componente; el polling Web de 15 segundos es una adaptación de carga, no paridad temporal exacta.

### Dependencias pendientes de ejecución

`Solo Subir`, `Recargar y Subir` y `Recargar Todos` siguen en su lugar en la barra, pero no ejecutan limpieza, cola ni envío mientras no se pueda validar el archivo `.mbg`, FTP y Syncro Server en un entorno de prueba. Los botones están deshabilitados y explicados; no hay éxito simulado. La consulta, limpieza y cambio FTP/local conservan sus handlers existentes. Quedan pendientes pruebas manuales con registros reales y comparación visual en navegador de escritorio, tablet y móvil.

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
| Mostrar agente siguiente y proceso actual | `Timer_AGEjecucion_Tick` / tablas de control | Lectura inicial y actualización liviana cada 15 segundos mientras la pestaña está visible | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| Avisar que no hay archivo FTP | `Timer_AGEjecucion_Tick` / `Consulta_InfoNOARCHIVO_FTP` | Muestra las primeras diez alertas activas; no consume ni limpia la señal | PARCIAL |
| Limpiar errores | `btn_LimpError` / `LimpiaEstadoSubidoSAP` | Elimina solo registros ERROR de un agente indicado y confirmado | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| Limpiar subidos | `btn_LimpSubidos` / `LimpiaEstadoSubidoSAP` | Elimina solo registros SUBIDO de un agente indicado y confirmado | IMPLEMENTADA PENDIENTE VALIDACIÓN |
| Solo subir | `btn_subir` / cola y archivo `Revisame` en FTP | Sin equivalente | NO MIGRADA |
| Recargar y subir | `btn_RecargSubir` / limpieza, marca de recarga, cola y FTP | Sin equivalente | NO MIGRADA |
| Recargar todos | `btn_RecargaTodos` / iteración de agentes y FTP | Sin equivalente | NO MIGRADA |
| Seleccionar fila para reintentar | `DGV_EstadoSubida.MouseClick` / `CambiaEstadoReinsertar` | Botón explícito por fila ERROR; solo actualiza `Reintento`, no confirma procesamiento externo | PARCIAL |
| Alternar origen FTP/local | `BTN_LocalFtp.Click` / `Bloquea_Desbloquea_DescargardeFTP` | Lectura y actualización de `BajarDeFTP`, sin cambiar al cerrar la página | PARCIAL |
| Bloqueo de pedidos de hoy | carga, timer y cierre; botón oculto en diseñador | Indicador de solo lectura según `FiltraHOY.HoySi`; no reproduce las escrituras globales en apertura/cierre | PARCIAL |

## Riesgos y decisiones

El SQL WinForms concatena filtros y algunas rutas de limpieza pueden afectar todos los agentes si el campo está vacío. La Web restringe la limpieza a un agente explícito, usa parámetros, exige la palabra de confirmación y audita la acción: esta es una diferencia de seguridad deliberada respecto al origen. La marca de reintento se limita a una fila ERROR inequívoca; si hay duplicados no se modifica ninguna. El cambio de origen FTP/local es global y no se revierte automáticamente al cerrar la página, otra divergencia a validar con el usuario. El disparo de FTP/cola requiere caracterizar el proceso externo y probarlo en un entorno controlado. No se cambió el esquema de base de datos.

La fecha y el reintento se presentan como texto para conservar la representación de los valores heredados hasta contrastar sus tipos reales en la base de prueba. `Sic_Local_Web_Pruebas` contiene cero filas en la bitácora, por lo que las mutaciones aún no tienen prueba con registros reales. La pantalla no está declarada equivalente funcional completo.
