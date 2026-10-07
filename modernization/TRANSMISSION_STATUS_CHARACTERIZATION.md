# Estados de transmisiones — caracterización funcional

Actualizado: 2026-10-06. Estado global: `PARCIAL`. No existe validación manual del usuario.

## Auditoría ampliada del envío (2026-10-06)

La trazabilidad de los tres botones de envío está en `Play/EstadoSubida.vb`:

| Acción | Secuencia WinForms comprobada | Web antes de esta revisión | Estado inicial |
|---|---|---|---|
| Recargar y Subir | Limpia ERROR y SUBIDO del agente, marca `Agentes.Recargar = 1`, genera la señal `.mbg`, la sube al FTP y reemplaza `AgenteAEjecutar` | Botón deshabilitado | NO MIGRADA |
| Solo Subir | Limpia ERROR y SUBIDO del agente, reemplaza `AgenteAEjecutar`, genera la señal `.mbg` y la sube al FTP | Botón deshabilitado | NO MIGRADA |
| Recargar Todos | Recorre agentes con puesto AGENTE excepto el código 1 y repite la secuencia de recarga y envío | Botón deshabilitado | NO MIGRADA |

`CrearArchivo.Crear_Revisame` crea un archivo con una línea vacía. `Class_FTP.Subir` elimina el destino antes de cargarlo con FTP, pero captura errores y devuelve éxito aparente incluso si falló. Syncro Server no es invocado directamente por este formulario: consume la señal `Revisame/<agente>.mbg` en el FTP y la fila de `AgenteAEjecutar`. El XML leído por WinForms aporta servidor, usuario, contraseña y directorio local; no hay endpoint HTTP ni socket en el formulario. La ruta local configurada en los XML disponibles no existe en esta máquina; el servidor Web puede generar el contenido de la señal sin depender de esa carpeta de la PC.

Hay una falla heredada peligrosa: `RecargaTodos_Click` itera el agente correcto para `ModificaRecargar` y FTP, pero llama `LimpiaEstadoSubidoSAP(txt_SoloAg.Text, ...)` en vez del agente iterado. Si el campo está vacío, puede limpiar resultados de todos los agentes. La migración no debe repetir ese borrado global. La Web ya exige agente explícito y confirmación para los botones de limpieza independientes.

El SQL de prueba conectado por la Web es `Sic_Local_Web_Pruebas`: se verificaron solo metadatos y conteos, sin mutaciones; `Estado_Subida_SAP` tiene cero filas. El XML sandbox apunta a esa base, pero comparte servidor y usuario FTP con el XML de producción. Por ello las pruebas reales de envío no son seguras hasta identificar un FTP y un consumidor Syncro Server aislados. Tampoco se pueden ejecutar pruebas de limpieza, filtros con datos ni reintento con esa tabla vacía.

### Implementación Web preparada

`TransmissionDispatchService` conserva los órdenes distintos: Solo Subir prioriza al agente antes de publicar la señal; Recargar y Subir y Recargar Todos publican antes de sustituir la prioridad. `SqlServerTransmissionStatusRepository` valida el agente en `Agentes`, elimina solamente sus filas ERROR y SUBIDO en una transacción, marca `Recargar` solo cuando corresponde y sustituye la fila de `AgenteAEjecutar` en otra transacción. Recargar Todos usa siempre el agente iterado; no reproduce el borrado global accidental de WinForms. Se rechazan solicitudes simultáneas dentro de una instancia Web.

`LegacyFtpTransmissionSignalSender` lee las secciones FTP y SQL del XML heredado, exige que la base coincida con la conexión de la Web y publica una línea vacía en `Revisame/<agente>.mbg`. Genera la señal en memoria porque el archivo local de WinForms no contiene datos y su directorio configurado no existe en esta máquina. No borra previamente el archivo remoto: la carga FTP lo reemplaza para evitar un intervalo sin señal. Los errores de SQL o FTP no se ocultan; la Web advierte de posibles cambios parciales si falla el envío. Syncro Server sigue siendo un consumidor externo: el éxito de la carga FTP **no** confirma que haya procesado el agente.

La función queda deshabilitada por defecto mediante `Essco:TransmissionFtp:Enabled=false`. Para habilitarla se debe indicar `Essco:TransmissionFtp:LegacyConfigurationPath` mediante configuración local o secretos, con el XML del **mismo** entorno SQL y un FTP aislado. No se copiaron contraseñas al proyecto Web. El límite FTP es `Essco:TransmissionFtp:TimeoutSeconds` (15 segundos por señal por defecto). La configuración no se habilitó porque ambos XML disponibles comparten FTP. Estas acciones permanecen `PARCIAL` hasta contar con pruebas reales y validación del usuario.

El protocolo heredado es FTP sin TLS. La Web no empeora ese transporte ni inventa un endpoint de Syncro Server, pero tampoco puede confirmar que el consumidor externo esté disponible después de recibir la señal. SQL y FTP no comparten transacción: si FTP falla después de preparar SQL, pueden permanecer cambios parciales; el mensaje Web lo advierte y la operación requiere revisión antes de repetirse. El bloqueo de simultaneidad actual es por instancia Web, no distribuido entre múltiples servidores. `Recargar Todos` puede superar los límites de tiempo de un proxy si el catálogo crece; no se agregó infraestructura de jobs sin un entorno donde caracterizar su duración real.

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

`Solo Subir`, `Recargar y Subir` y `Recargar Todos` están implementados y aparecen habilitados únicamente cuando `Essco:TransmissionFtp` está configurado explícitamente. En el entorno actual continúan deshabilitados: no hay FTP sandbox aislado. La consulta, limpieza y cambio FTP/local conservan sus handlers existentes. Quedan pendientes pruebas manuales con registros reales y comparación visual en navegador de escritorio, tablet y móvil.

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
| Solo subir | `btn_subir` / cola y archivo `Revisame` en FTP | Flujo implementado, deshabilitado sin FTP aislado | PARCIAL |
| Recargar y subir | `btn_RecargSubir` / limpieza, marca de recarga, cola y FTP | Flujo implementado, deshabilitado sin FTP aislado | PARCIAL |
| Recargar todos | `btn_RecargaTodos` / iteración de agentes y FTP | Flujo implementado por agente, deshabilitado sin FTP aislado | PARCIAL |
| Seleccionar fila para reintentar | `DGV_EstadoSubida.MouseClick` / `CambiaEstadoReinsertar` | Botón explícito por fila ERROR; solo actualiza `Reintento`, no confirma procesamiento externo | PARCIAL |
| Alternar origen FTP/local | `BTN_LocalFtp.Click` / `Bloquea_Desbloquea_DescargardeFTP` | Lectura y actualización de `BajarDeFTP`, sin cambiar al cerrar la página | PARCIAL |
| Bloqueo de pedidos de hoy | carga, timer y cierre; botón oculto en diseñador | Indicador de solo lectura según `FiltraHOY.HoySi`; no reproduce las escrituras globales en apertura/cierre | PARCIAL |

## Riesgos y decisiones

El SQL WinForms concatena filtros y algunas rutas de limpieza pueden afectar todos los agentes si el campo está vacío. La Web restringe la limpieza a un agente explícito, usa parámetros, exige la palabra de confirmación y audita la acción: esta es una diferencia de seguridad deliberada respecto al origen. La marca de reintento se limita a una fila ERROR inequívoca; si hay duplicados no se modifica ninguna. El cambio de origen FTP/local es global y no se revierte automáticamente al cerrar la página, otra divergencia a validar con el usuario. El disparo de FTP/cola requiere caracterizar el proceso externo y probarlo en un entorno controlado. No se cambió el esquema de base de datos.

La fecha y el reintento se presentan como texto para conservar la representación de los valores heredados hasta contrastar sus tipos reales en la base de prueba. `Sic_Local_Web_Pruebas` contiene cero filas en la bitácora, por lo que las mutaciones aún no tienen prueba con registros reales. La pantalla no está declarada equivalente funcional completo.
