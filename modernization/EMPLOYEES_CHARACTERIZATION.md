# Caracterización funcional del módulo Empleados

Fecha de análisis: 2026-09-19.

Estado documental: `ANALIZADO`. Fase A: `PENDIENTE VALIDACIÓN USUARIO` después de una primera validación manual no superada y su corrección. Ninguna funcionalidad está marcada como `VALIDADO`.

Esta caracterización se rige por [FUNCTIONAL_PARITY_STANDARD.md](FUNCTIONAL_PARITY_STANDARD.md). Las filas actuales constituyen la primera descomposición funcional; antes de implementar cada fase se ampliarán con el control, evento, efectos secundarios y prueba concreta cuando todavía no estén expresados individualmente.

## Alcance y fuentes

La referencia funcional principal es `Play/Planilla_Empleados.vb` y su diseñador. También se revisaron `Class_funcionesSQL.vb`, `Planilla_List_Empleados`, `PlanillaEmpleado_HistorialAbonosVales`, los reportes de expediente, vacaciones, préstamos y planilla, y la implementación actual bajo `/Employees`.

El formulario tiene un bloque de datos generales y 12 pestañas, en este orden:

1. Experiencia.
2. Educación.
3. Vacaciones.
4. Facturas.
5. Vales y préstamos.
6. Deducciones.
7. Incapacidades.
8. Aumentos.
9. Planillas.
10. Días adicionales.
11. Liquidación laboral.
12. Adicionales.

## Seguridad y permisos

El WinForms habilita el acceso desde el menú principal y comparte el usuario en estado global. No se observó autorización granular por operación dentro del formulario. Web protege todas las páginas revisadas con `Permissions.Payroll`; esto es mejor que confiar en el menú, pero actualmente concede con una sola política lectura y modificación. En la implementación se deberá decidir si separar consulta, mantenimiento, compensación, movimientos y liquidación.

## Caracterización por área

### 0. Datos generales — bloque exterior

**Propósito.** Crear, localizar, actualizar, inactivar, cerrar y navegar empleados; servir de contexto a las 12 pestañas.

**Campos.** Id/consecutivo, cédula, código/cliente SAP, nombre, puesto, teléfonos, salario, fecha de ingreso, fecha de salida, estado activo, fotografía/ruta, años/meses/días laborados, ruta, correo, salario quincenal y diario, cuenta bancaria, id de colaborador bancario, cuenta contable, categoría y saldos de vacaciones.

**Obligatorios comprobados.** Cédula, nombre, salario, cuenta bancaria, id de colaborador y categoría. Salario mínimo: 1000. La cuenta contable, si se indica, debe existir en SAP y no exceder 15 caracteres. El código de cliente, si se indica, debe existir en SAP y no exceder 15 caracteres.

**Acciones y eventos.** Nuevo obtiene consecutivo; Guardar/Actualizar; Inactivar con confirmación; seleccionar y reemplazar fotografía; buscar mediante `Planilla_List_Empleados`; anterior/siguiente; imprimir expediente; cambio de puesto; cambio de salario recalcula salario quincenal/diario; fechas recalculan antigüedad y liquidación; cerrar empleado inicia liquidación y no se presenta como reversible.

**Reglas especiales.** El nombre elimina tildes, ñ y símbolos; la fotografía se guarda en archivo y como bytes, con imagen predeterminada si no existe; el estado usa `0=Activo`, `1=Inactivo`, `2=Cerrado`, `3=Liquidado`. El WinForms ejecutable solo implementa `Activo → Inactivo`; el bloque que reactivaba está comentado y los estados 1/2/3 deshabilitan edición. No existe eliminación explícita de fotografía. `IdColaborador` es obligatorio y se usa en el archivo bancario, pero WinForms no lo valida contra SAP ni otra tabla (por eso `0` no puede rechazarse sin crear una regla nueva).

**Dependencias.** `Empleado`, validación de cuenta contable y cliente en SAP, ruta local de fotografías, `Planilla_List_Empleados`, reporte `ExpedienteEmpleado`.

**Web actual (Fase A corregida).** Lista, filtro, alta, edición solo de activos e inactivación explícita; no ofrece reactivación; fotografía visible, previsualizable y reemplazable; validación de firma real; validaciones SAP que bloquean también cuando SAP no está configurado/disponible; obligatoriedad visible y errores por campo; permisos backend y auditoría. El identificador técnico lo genera SQL. Cierre/liquidación e impresión permanecen fuera de Fase A.

### 1. Experiencia

**Propósito.** Mantener experiencia laboral previa.

**Campos.** Cédula de empresa, empresa, puesto anterior, fecha de ingreso, fecha de salida, persona de referencia, teléfono y comentarios.

**Obligatorios comprobados.** Empresa, puesto, fechas, persona de referencia y teléfono son validados por `ValidaCamposExperiencia`; la cédula de empleado debe existir.

**Acciones.** Nuevo, Guardar, Actualizar al seleccionar una fila y Eliminar. La consulta se carga por cédula.

**Reglas.** Guardar y actualizar comparten `GuardaExperiencia`; eliminación identifica por empleado y nombre de empresa, lo que puede ser ambiguo.

**Datos.** `Empleado_Experiencia`. No se observaron vistas ni stored procedures.

**Web actual.** Alta, consulta, edición explícita y eliminación en `/Employees/Background`. La edición se identifica por `CedulaEmpresa` exacta y solo afecta una fila; si esa clave está duplicada, no ofrece una selección ambigua ni actualiza varias filas. Esta decisión defensiva difiere del `LIKE` parcial del WinForms. La eliminación web usa `CompanyId`, criterio distinto del original; su equivalencia y seguridad siguen pendientes de validación.

### 2. Educación

**Propósito.** Mantener estudios del empleado.

**Campos.** Institución, título, grado, fecha de ingreso, fecha de salida y En curso.

**Acciones.** Nuevo, Guardar, Actualizar por fila y Eliminar. `En curso` deshabilita la fecha de salida.

**Reglas.** Requiere empleado existente. Deben verificarse institución, título, grado y fechas; el comportamiento exacto de fecha final cuando está en curso debe preservarse.

**Datos.** `Empleado_Educacion`. No se observaron vistas ni stored procedures.

**Web actual.** Alta, consulta y eliminación en la pestaña Educación de la página de antecedentes. La lectura de `EnCurso` reconoce los valores heredados `0`/`1` y `False`/`True`, que antes causaban error 500. Falta edición explícita y confirmar equivalencia de las validaciones con SQL real.

### 3. Vacaciones

**Propósito.** Calcular el derecho, registrar consumo, mantener adjuntos e imprimir la solicitud.

**Campos.** Consecutivo, fecha inicial/final, días a consumir, comentario, días ganados/consumidos/pendientes, montos ganados/consumidos/pendientes, adjunto y estado.

**Acciones.** Nuevo, Guardar/Actualizar, Anular, seleccionar fila, adjuntar, ver, descargar e imprimir solicitud.

**Reglas y cálculos.** La fecha inicial no puede ser anterior al ingreso; el rango debe ser válido; cuenta días laborales de lunes a sábado; valida que el saldo no quede negativo; calcula vacaciones ganadas según tiempo laborado y salario promedio; pendientes = ganadas - consumidas; monto = días por salario diario; el estado anulado bloquea edición; la modificación mantiene consecutivo.

**Archivos/reportes.** Adjunto binario PDF o imagen; apertura mediante archivo temporal; descarga; reporte `SolicitudVacaciones`.

**Datos.** `Empleado_Vacaciones` y actualización de saldos en `Empleado`. No se observaron stored procedures.

**Web actual.** Alta y anulación parcial desde la pestaña Vacaciones del expediente, además de consulta y adjunto. Se valida que el empleado esté activo y que el periodo no comience antes del ingreso. Faltan edición, cálculo laboral equivalente, actualización atómica de saldos, impresión, montos y estados detallados. No se ha validado manualmente el flujo con datos reales.

### 4. Facturas

**Propósito.** Mostrar facturas asociadas al código de cliente SAP vinculado al empleado y calcular el total.

**Campos/filtros.** Código de cliente y selector de estado/tipo visible en la pestaña; grilla de documentos y total.

**Acciones.** Carga al abrir la pestaña y formatea importes. No se observó alta desde este formulario.

**Reglas.** Solo consulta cuando el empleado tiene código de cliente; el total se calcula sobre la grilla.

**Dependencias.** Consulta `ObtineFacturas`, código de cliente SAP y objetos de facturación.

**Web actual.** Consulta de solo lectura de `FacturaPendiente` por el código de cliente SAP del empleado, con las columnas devueltas por SQL y total de `Saldo`. Se carga al abrir la pestaña Facturas. Falta validación manual con una base que tenga facturas y confirmar el formato de todas las columnas; el módulo `/Billing` no reemplaza esta relación contextual.

### 5. Vales y préstamos

**Propósito.** Registrar, actualizar, anular y consultar obligaciones del empleado y sus abonos.

**Campos.** Consecutivo, fecha, monto, saldo, tipo, detalle, cuota quincenal, adjunto, estado y total de saldos activos.

**Obligatorios comprobados.** Empleado, tipo, monto mayor que cero, fecha no anterior al ingreso y cuenta contable del empleado. La cuota debe ser válida.

**Acciones.** Nuevo, Guardar/Actualizar, Anular, imprimir solicitud, adjuntar/ver/descargar y abrir historial de abonos.

**Reglas.** El saldo inicia en el monto; si ya hay abonos, el monto original se bloquea; estados 1 y 2 representan anulado y cancelado; ambos bloquean cambios; el total excluye anulados; se usa consecutivo global.

**Archivos/reportes.** Adjunto PDF/imagen; reporte `ValesPrestamos`; Form `PlanillaEmpleado_HistorialAbonosVales`.

**Datos.** `Empleado_ValesPrestamos` y `Empleado_ValesPrestamosAbonos`.

**Web actual.** Alta, consulta, anulación genérica y adjunto. Faltan edición, historial de abonos, estados cancelado/anulado, impresión, total, validación de cuenta contable y protección del monto con abonos.

### 6. Deducciones

**Propósito.** Mantener deducciones fijas o variables que alimentan planilla.

**Campos.** Consecutivo, categoría, monto, detalle, fecha, estado, porcentaje primera quincena, porcentaje segunda quincena, segmentación y total activo.

**Acciones.** Nuevo, Guardar/Actualizar, seleccionar y Anular.

**Reglas.** Los porcentajes deben sumar 100; fecha no anterior al ingreso; monto válido; impide duplicar una deducción fija de la misma categoría para un empleado; total excluye anuladas; el estado anulado bloquea edición.

**Datos.** `Empleado_Deducciones`; consumo posterior desde planillas.

**Web actual.** Alta, consulta y anulación. La suma 100 está implementada. Faltan edición, control de duplicado fijo, catálogo/segmentación equivalente, total y validación de fecha de ingreso.

### 7. Incapacidades

**Propósito.** Registrar periodos de incapacidad que afectan planilla.

**Campos.** Consecutivo, inicio, fin, días, número de boleta, detalle, tipo, adjunto, fecha de creación y estado.

**Acciones.** Nuevo, Guardar/Actualizar, Anular, seleccionar, adjuntar, ver y descargar.

**Reglas.** Empleado existente; rango válido; fecha no anterior al ingreso; días calculados/validados; registro anulado bloquea cambios. La anulación también actualiza `Empleado_IncapacidadesDetalle`.

**Archivos.** PDF o imagen persistido como binario.

**Datos.** `Empleado_Incapacidades` y `Empleado_IncapacidadesDetalle`.

**Web actual.** Alta, consulta, anulación genérica y adjunto. Faltan edición, actualización del detalle relacionado, catálogo de tipos, cálculo equivalente de días y validación contra ingreso.

### 8. Aumentos

**Propósito.** Registrar historial de aumentos y actualizar el salario vigente.

**Campos.** Fecha, porcentaje, salario anterior, salario posterior, monto del aumento, motivo y usuario creador.

**Acciones.** Nuevo, Guardar y consultar historial. Una fila histórica es de solo lectura.

**Reglas/cálculos.** Fecha no anterior al ingreso; porcentaje numérico; salario posterior y monto se calculan desde salario actual; al guardar actualiza `Empleado.Salario`; usuario creador queda registrado; recalcula aguinaldo.

**Datos.** `Empleado_Aumentos` y `Empleado`.

**Web actual.** Alta e historial; actualiza salario. Debe verificarse atomicidad, fecha de ingreso, fórmula/redondeo, usuario y efecto sobre cálculos relacionados.

### 9. Planillas

**Propósito.** Consultar las planillas históricas del empleado y promedios usados por vacaciones/liquidación.

**Campos.** Grilla de planillas, salario promedio y días laborados de los últimos seis meses.

**Acciones.** Consulta al abrir la pestaña; no se modifica planilla desde aquí.

**Reglas/cálculos.** Obtiene días trabajados por mes y salario bruto promedio sin deducciones. Estos valores alimentan vacaciones, preaviso, cesantía y liquidación.

**Dependencias.** Tablas de planilla y funciones `ObtienePlanillasXEmpleado`, `ObtieneDiasTrabajadosxMesXEmpleado` y `ObtieneSalarioBrutoSinDeduccionesPromedioXMesXEmpleado`.

**Web actual.** No existe en `/Employees`; `/Payroll` no ofrece esta vista contextual ni los promedios.

### 10. Días adicionales

**Propósito.** Registrar porcentajes/días adicionales aplicables a fechas concretas.

**Campos.** Fecha, motivo, porcentaje y estado.

**Acciones.** Nuevo, Guardar/Modificar, seleccionar y Anular.

**Reglas.** Porcentaje mayor que 0 y menor o igual que 1, con máximo dos decimales; empleado existente; la fecha identifica la actualización/anulación.

**Datos.** `Empleado_DiasAdicionales`.

**Web actual.** No iniciado.

### 11. Liquidación laboral

**Propósito.** Proyectar, calcular, guardar e imprimir la liquidación; cerrar definitivamente al empleado.

**Campos.** Motivo de salida, fecha proyectada/real, preaviso sí/no, días y monto de preaviso, salario promedio, cesantía, aguinaldo, días y monto de vacaciones, salario pendiente, total y adjunto firmado.

**Acciones.** Calcular automáticamente, guardar, imprimir, adjuntar/ver/descargar y cerrar empleado.

**Reglas/cálculos.** Fecha posterior al ingreso y validación especial del día de salida; confirmación irreversible; preaviso depende de antigüedad; cesantía depende del motivo; aguinaldo se obtiene de planillas no canceladas; vacaciones dependen de saldo y salario diario; salario pendiente usa días laborales restantes; total suma componentes aplicables. Guardar puede exigir documento firmado y cambia el empleado a estado liquidado/cerrado.

**Archivos/reportes.** Adjunto binario firmado; reporte de liquidación/expediente.

**Datos.** `Empleado_Liquidacion`, `Empleado`, planillas, vacaciones y cálculos históricos.

**Web actual.** No iniciado. Es el submódulo de mayor riesgo y no debe implementarse copiando fórmulas sin pruebas de caracterización.

### 12. Adicionales

**Propósito.** Mantener montos adicionales recurrentes utilizados por planilla.

**Campos.** Tipo, monto, fecha, estado y total.

**Acciones.** Nuevo, Guardar/Actualizar, seleccionar y Anular.

**Reglas.** Empleado existente; tipo permitido; monto positivo; estado controla inclusión en total. Se observaron tipos Viáticos y Combustibles.

**Datos.** `Empleado_Adicionales`.

**Web actual.** Alta, consulta y anulación masiva de adicionales activos. Falta edición/anulación individual, total, estados, fecha e igualdad exacta con el catálogo original.

## Matriz granular WinForms → Web

| Área | Funcionalidad WinForms | Web | Estado | Implementación actual / diferencia | Acción necesaria | Riesgo |
|---|---|---|---|---|---|---|
| General | Listar empleados | Sí | IMPLEMENTADO | `/Employees`; usa `Estado=0` como activo | Validación manual con base real | Medio |
| General | Buscar por cédula/código/nombre | Sí | IMPLEMENTADO | Filtro parametrizado | Validación manual | Bajo |
| General | Incluir inactivos | Sí | IMPLEMENTADO | Incluye todos los códigos al solicitarlo | Validación manual | Medio |
| General | Obtener consecutivo | Sí | IMPLEMENTADO | El id técnico lo genera SQL; no se pide al usuario | Validación manual de alta | Bajo |
| General | Alta | Sí | IMPLEMENTADO | Persiste campos generales, foto y antigüedad | Validación manual | Alto |
| General | Edición | Sí | IMPLEMENTADO | Actualiza por identificación original | Validación manual | Alto |
| General | Inactivar con confirmación | Sí | IMPLEMENTADO | Operación explícita, confirmada y auditada | Validación manual | Alto |
| General | Reactivar empleado | No aplica | ANALIZADO | Código WinForms comentado; estados no activos bloquean edición | No inventar transición | Alto |
| General | Bloquear edición de inactivo/cerrado/liquidado | Sí | IMPLEMENTADO | Backend y UI rechazan modificación directa | Validación manual | Alto |
| General | Duplicado activo con estado explícito | Sí | IMPLEMENTADO | Mensaje identifica ACTIVO | Validación manual | Medio |
| General | Duplicado inactivo/cerrado/liquidado con estado explícito | Sí | IMPLEMENTADO | Mensaje indica estado y evita recreación | Validación manual | Alto |
| General | Cerrar/liquidar empleado | No | NO INICIADO | Sin equivalente | Implementar con liquidación | Crítico |
| General | Fotografía | Sí | IMPLEMENTADO | Carga segura JPG/PNG/WEBP hasta 5 MB y lectura desde `Foto` | Validación manual | Medio |
| General | Previsualizar fotografía seleccionada | Sí | IMPLEMENTADO | Vista previa local antes de guardar | Validación manual | Bajo |
| General | Recuperar/mostrar fotografía o estado vacío | Sí | IMPLEMENTADO | Visible en edición y expediente | Validación manual | Medio |
| General | Reemplazar fotografía | Sí | IMPLEMENTADO | Nueva imagen reemplaza `Foto`; ausencia conserva existente | Validación manual | Medio |
| General | Validar contenido real de fotografía | Sí | IMPLEMENTADO | Firma binaria JPG/PNG/WEBP, no solo MIME/extensión | Validación manual | Alto |
| General | Validar salario mínimo 1000 | Sí | IMPLEMENTADO | Regla cliente/servidor y prueba unitaria | Validación manual | Alto |
| General | Validar cuenta contable SAP | Sí | IMPLEMENTADO | Consulta parametrizada a `OACT` | Validación con SAP real | Alto |
| General | Validar código cliente SAP | Sí | IMPLEMENTADO | Consulta parametrizada a `OCRD` | Validación con SAP real | Alto |
| General | Cuenta bancaria/id/categoría obligatorios | Sí | IMPLEMENTADO | Reglas cliente/servidor | Validación manual | Alto |
| General | Identificación visual y accesible de obligatorios | Sí | IMPLEMENTADO | Asterisco, `required`, `aria-required`, resumen y error por campo | Validación manual | Medio |
| General | SAP no configurado/no disponible | Sí | IMPLEMENTADO | Bloquea guardado y explica indisponibilidad | Configurar DB SAP y validar | Alto |
| General | Puesto y categoría como listas | Sí | IMPLEMENTADO | Opciones idénticas al Designer WinForms | Validación manual | Medio |
| General | Calcular antigüedad | Sí | IMPLEMENTADO | Años/meses/días recalculados al guardar y probados | Validación manual | Alto |
| General | Salario diario/quincenal | Sí | IMPLEMENTADO | Cálculo visible mensual/2 y mensual/30 | Validación manual | Medio |
| General | Navegar anterior/siguiente | Sí | IMPLEMENTADO | Sustituido por lista/búsqueda y retorno al expediente | Validación UX | Bajo |
| General | Imprimir expediente | No | NO INICIADO | Sin PDF | Sustituir Crystal y comparar | Medio |
| Experiencia | Consultar | Sí | IMPLEMENTADO | Background | Validar columnas | Bajo |
| Experiencia | Alta | Sí | EN DESARROLLO | AddExperience | Completar validaciones | Medio |
| Experiencia | Editar | No | NO INICIADO | Alta solamente | Crear edición con clave estable | Medio |
| Experiencia | Eliminar | Sí | EN DESARROLLO | Por CompanyId, distinto al original | Definir identidad correcta | Alto |
| Educación | Consultar | Sí | IMPLEMENTADO | Background | Validar columnas | Bajo |
| Educación | Alta | Sí | EN DESARROLLO | AddEducation | Completar validaciones | Medio |
| Educación | Editar | No | NO INICIADO | Alta solamente | Implementar edición | Medio |
| Educación | Eliminar | Sí | EN DESARROLLO | Por institución | Evitar ambigüedad | Medio |
| Educación | En curso deshabilita fin | Parcial | EN DESARROLLO | Backend conserva bandera | Completar UX y regla backend | Bajo |
| Vacaciones | Consultar historial | Sí | IMPLEMENTADO | Detail | Verificar estados y fechas | Medio |
| Vacaciones | Alta | Sí | EN DESARROLLO | Movements | Aplicar reglas originales | Alto |
| Vacaciones | Editar | No | NO INICIADO | Sin operación | Implementar actualización | Alto |
| Vacaciones | Anular | Sí | EN DESARROLLO | Handler genérico | Actualizar saldos atómicamente | Crítico |
| Vacaciones | Calcular días lunes-sábado | No | NO INICIADO | Días ingresados manualmente | Caracterizar festivos y fórmula | Alto |
| Vacaciones | Validar saldo | No | NO INICIADO | Solo días positivos | Evitar saldo negativo | Crítico |
| Vacaciones | Calcular ganado/pendiente/montos | No | NO INICIADO | Saldos editables manualmente | Mover cálculo a dominio | Crítico |
| Vacaciones | Adjuntar/ver/descargar | Sí | EN DESARROLLO | Attachment | Validar tamaño, MIME y autorización | Alto |
| Vacaciones | Imprimir solicitud | No | NO INICIADO | Sin PDF | Sustituir reporte | Medio |
| Facturas | Consultar por empleado/código cliente | Sí | IMPLEMENTADA PENDIENTE VALIDACIÓN | Detail / FacturaPendiente | Probar contra datos reales | Medio |
| Facturas | Filtrar/totalizar | Parcial | PARCIAL | Total de Saldo; selector heredado no visible | Validar total y selector | Medio |
| Préstamos | Consultar | Sí | IMPLEMENTADO | Detail | Validar estados | Medio |
| Préstamos | Alta | Sí | EN DESARROLLO | Movements | Completar reglas | Alto |
| Préstamos | Editar | No | NO INICIADO | Sin operación | Implementar controlando abonos | Crítico |
| Préstamos | Anular | Sí | EN DESARROLLO | Handler genérico | Distinguir anulado/cancelado | Alto |
| Préstamos | Historial de abonos | No | NO INICIADO | Sin tabla/servicio | Implementar consulta | Alto |
| Préstamos | Bloquear monto con abonos | No | NO INICIADO | Sin edición | Regla backend | Crítico |
| Préstamos | Adjuntar/ver/descargar | Sí | EN DESARROLLO | Attachment | Validar seguridad | Alto |
| Préstamos | Imprimir solicitud | No | NO INICIADO | Sin PDF | Sustituir reporte | Medio |
| Deducciones | Consultar | Sí | IMPLEMENTADO | Detail | Validar categorías | Medio |
| Deducciones | Alta | Sí | EN DESARROLLO | Movements | Completar reglas | Alto |
| Deducciones | Editar | No | NO INICIADO | Sin operación | Implementar actualización | Alto |
| Deducciones | Anular | Sí | EN DESARROLLO | Handler genérico | Validar identidad/concurrencia | Alto |
| Deducciones | Distribución suma 100 | Sí | IMPLEMENTADO | Service | Agregar pruebas de bordes | Medio |
| Deducciones | Evitar fija duplicada | No | NO INICIADO | Sin verificación | Añadir regla/repositorio | Alto |
| Deducciones | Total de activas | No | NO INICIADO | Sin resumen | Calcular en consulta | Bajo |
| Incapacidades | Consultar | Sí | IMPLEMENTADO | Detail | Validar esquema | Medio |
| Incapacidades | Alta | Sí | EN DESARROLLO | Movements | Completar reglas | Alto |
| Incapacidades | Editar | No | NO INICIADO | Sin operación | Implementar | Alto |
| Incapacidades | Anular cabecera y detalle | Parcial | INCORRECTO / REQUIERE REVISIÓN | Web solo actualiza cabecera | Hacer operación atómica | Crítico |
| Incapacidades | Calcular días | No | NO INICIADO | Manual | Caracterizar fórmula | Alto |
| Incapacidades | Adjuntar/ver/descargar | Sí | EN DESARROLLO | Attachment | Validar seguridad | Alto |
| Aumentos | Consultar historial | Sí | IMPLEMENTADO | Compensation | Validar columnas | Medio |
| Aumentos | Alta y actualización salario | Sí | EN DESARROLLO | Repositorio transaccional por verificar | Probar atomicidad/fórmula | Crítico |
| Aumentos | Fecha posterior al ingreso | No | NO INICIADO | No validado | Añadir regla | Alto |
| Aumentos | Recalcular aguinaldo | No | NO INICIADO | Sin efecto visible | Integrar con cálculo validado | Crítico |
| Planillas | Historial por empleado | No | NO INICIADO | Payroll separado | Añadir consulta contextual | Alto |
| Planillas | Promedio salarial | No | NO INICIADO | Sin equivalente | Caracterizar consulta/fórmula | Crítico |
| Planillas | Días trabajados seis meses | No | NO INICIADO | Sin equivalente | Caracterizar consulta/fórmula | Crítico |
| Días adicionales | Consultar | No | NO INICIADO | Sin contratos | Implementar verticalmente | Alto |
| Días adicionales | Alta/edición/anulación | No | NO INICIADO | Sin equivalente | CRUD con regla 0 < x <= 1 | Alto |
| Liquidación | Calcular preaviso | No | NO INICIADO | Sin equivalente | Servicio de dominio con casos límite | Crítico |
| Liquidación | Calcular cesantía | No | NO INICIADO | Sin equivalente | Caracterizar legislación/regla vigente | Crítico |
| Liquidación | Calcular aguinaldo | No | NO INICIADO | Sin equivalente | Comparar planillas históricas | Crítico |
| Liquidación | Calcular vacaciones | No | NO INICIADO | Sin equivalente | Depende de vacaciones validadas | Crítico |
| Liquidación | Calcular salario pendiente | No | NO INICIADO | Sin equivalente | Validar días laborales | Crítico |
| Liquidación | Guardar y marcar liquidado | No | NO INICIADO | Sin equivalente | Transacción y auditoría | Crítico |
| Liquidación | Cerrar irreversiblemente | No | NO INICIADO | Sin equivalente | Permiso fuerte y confirmación | Crítico |
| Liquidación | Adjunto firmado | No | NO INICIADO | Attachment no soporta liquidación | Almacenamiento seguro | Alto |
| Liquidación | Imprimir | No | NO INICIADO | Sin PDF | Sustituir reporte | Alto |
| Adicionales | Consultar | Sí | IMPLEMENTADO | Compensation | Validar estados | Medio |
| Adicionales | Alta | Sí | EN DESARROLLO | Dos tipos codificados | Confirmar catálogo | Medio |
| Adicionales | Editar | No | NO INICIADO | Sin operación | Implementar si se conserva | Medio |
| Adicionales | Anular individual | No | INCORRECTO / REQUIERE REVISIÓN | Web anula todos los activos | Cambiar a identidad individual | Alto |
| Adicionales | Total activos | No | NO INICIADO | Sin resumen | Agregar cálculo | Bajo |

## Mapa de dependencias

```text
Planilla_Empleados
├── Contexto global
│   ├── Class_VariablesGlobales
│   ├── conexión SQL compartida
│   ├── usuario actual
│   └── rutas locales de archivos/fotografías
├── Datos generales
│   ├── Empleado
│   ├── Planilla_List_Empleados
│   ├── validación de cuenta contable SAP
│   ├── validación de cliente SAP
│   └── reporte ExpedienteEmpleado
├── Experiencia → Empleado_Experiencia
├── Educación → Empleado_Educacion
├── Vacaciones
│   ├── Empleado_Vacaciones
│   ├── Empleado (saldos)
│   ├── historial de planillas/promedio salarial
│   ├── adjunto binario
│   └── reporte SolicitudVacaciones
├── Facturas
│   ├── código de cliente del empleado
│   └── objetos locales/SAP de facturación
├── Vales y préstamos
│   ├── Empleado_ValesPrestamos
│   ├── Empleado_ValesPrestamosAbonos
│   ├── cuenta contable
│   ├── PlanillaEmpleado_HistorialAbonosVales
│   └── reporte ValesPrestamos
├── Deducciones
│   ├── Empleado_Deducciones
│   └── cálculo de planillas
├── Incapacidades
│   ├── Empleado_Incapacidades
│   ├── Empleado_IncapacidadesDetalle
│   └── cálculo de planillas
├── Aumentos
│   ├── Empleado_Aumentos
│   ├── Empleado.Salario
│   └── cálculo de aguinaldo
├── Planillas
│   ├── historial de planillas
│   ├── días trabajados
│   └── salario bruto promedio
├── Días adicionales → Empleado_DiasAdicionales
├── Liquidación laboral
│   ├── Empleado_Liquidacion
│   ├── Empleado.Estado/FechaSalida
│   ├── historial de planillas
│   ├── vacaciones
│   ├── preaviso
│   ├── cesantía
│   ├── aguinaldo
│   ├── adjunto firmado
│   └── impresión
└── Adicionales
    ├── Empleado_Adicionales
    └── cálculo de planillas
```

No se identificaron stored procedures llamados directamente por `Planilla_Empleados`; la lógica observada usa SQL construido en `Class_funcionesSQL`. Tampoco se confirmó una vista específica para este formulario. Las consultas de planilla y facturación pueden depender de objetos adicionales y deberán documentarse al implementar esas fases.

## Revisión del código web actual

### Reutilizable/correcto

- Separación Domain/Application/Infrastructure/Web.
- Consultas SQL parametrizadas y cancelables.
- Política backend `Permissions.Payroll`.
- Servicios separados para empleado, movimientos, compensación, adjuntos y antecedentes.
- Validaciones básicas de rango, montos y distribución quincenal.
- Uso de identificador original al editar.
- Descarga de adjuntos a través de una página autorizada, no exponiendo una ruta local.

### Incompleto o incorrecto

- Una sola política permite todas las operaciones del módulo.
- `EmployeeService` permite saldos de vacaciones editables manualmente, aunque el original los calcula.
- No se verifica salario mínimo, cuenta contable SAP ni código cliente SAP.
- La anulación de incapacidad no demuestra actualización del detalle relacionado.
- La anulación de adicionales afecta todos los activos del empleado, mientras el WinForms trabaja con el registro seleccionado.
- Background no ofrece edición y usa claves de eliminación que pueden no equivaler al original.
- Movements no ofrece edición de movimientos existentes.
- No existen Facturas, Planillas, Días adicionales ni Liquidación dentro de Employees.
- No se implementó impresión.
- Las páginas no muestran estados de concurrencia ni usan una versión de fila.
- Los archivos permiten varias clases y métodos en una sola línea; compilan, pero son difíciles de mantener y revisar.
- `UnavailableEmployee*Repository` permite arrancar sin datos, pero la interfaz debe comunicar con claridad indisponibilidad; no debe confundirse con lista vacía.
- No se hallaron TODO críticos en producción dentro de Employees, pero sí ausencia funcional explícita.

### Seguridad y rendimiento

- Deben fijarse límite de tamaño, tipos MIME permitidos, firma de contenido y disposición segura para adjuntos.
- Toda edición/anulación necesita protección CSRF, autorización y auditoría; Razor aporta antiforgery por defecto, pero falta auditar todas las operaciones.
- Las consultas del expediente ejecutan varias consultas secuenciales; es aceptable inicialmente, pero debe medirse con datos reales.
- Las listas tienen límites parciales, pero los historiales del expediente requieren paginación si crecen.

## Plan vertical propuesto

### Fase A — Datos generales y seguridad

**Resultado: `PENDIENTE VALIDACIÓN USUARIO`.** La primera validación manual no fue superada; se corrigieron sus causas raíz y se reauditaron las transiciones, SAP, campos y fotografía. Queda repetir el guion manual con SQL/SAP reales. El trabajo posterior en Experiencia no equivale a la aprobación de Fase A.

### Fase B — Experiencia y educación

Completar edición, claves estables, validaciones y estados En curso. Probar alta/edición/eliminación y registros duplicados. Termina con CRUD completo y comparación SQL.

**Avance del primer bloque:** se añadió selección y actualización de Experiencia, con validación de los campos obligatorios del WinForms, clave exacta y actualización limitada a una fila. La página de antecedentes ahora separa Experiencia y Educación en pestañas. La lectura de `EnCurso` acepta los valores heredados conocidos y rechaza los desconocidos. **Estado: `IMPLEMENTADA PENDIENTE VALIDACIÓN` para la acción de edición y la corrección de lectura**, no para ambas pestañas completas. Educación, borrado con claves duplicadas y cotejo SQL real continúan pendientes.

**Navegación del expediente:** la Web presenta las doce pestañas originales en su orden, además del resumen y los adjuntos existentes. Por ahora algunas pestañas enlazan acciones que siguen en páginas de mantenimiento separadas y otras indican `NO MIGRADA` o `PARCIAL`; esto no representa todavía una equivalencia completa de la ventana WinForms. La integración de los formularios dentro del mismo expediente queda pendiente.

### Fase C — Historial de planillas de solo lectura

Crear la consulta contextual, salario promedio y días trabajados. Es dependencia de vacaciones y liquidación. Probar resultados contra empleados reales y periodos conocidos.

### Fase D — Vacaciones

Implementar cálculo, edición, anulación transaccional, saldo, adjuntos e impresión. Depende de C. Probar rangos, sábados, ingreso, saldo insuficiente, anulaciones y redondeo.

### Fase E — Incapacidades

Completar edición, tipos, días, adjuntos y anulación de cabecera/detalle. Probar impacto posterior en planilla.

### Fase F — Deducciones

Completar edición, catálogo, deducción fija duplicada, segmentación, total y anulación. Probar porcentajes y consumo desde planilla.

### Fase G — Vales y préstamos

Completar edición, estados, abonos, bloqueo del monto, adjuntos e impresión. Probar saldos y relación con planilla.

### Fase H — Aumentos y adicionales

Cerrar atomicidad del aumento, fecha, redondeo y usuario; completar edición/anulación individual de adicionales. Probar salario y cálculos derivados.

### Fase I — Días adicionales

Crear consulta y CRUD completo con la regla porcentual. Probar inclusión posterior en planilla.

### Fase J — Facturas del empleado

Agregar consulta contextual y total. Confirmar si sigue siendo requisito operativo o puede enlazarse al módulo Billing sin perder comportamiento.

### Fase K — Liquidación laboral

Última fase por riesgo y dependencias. Caracterizar fórmulas con casos reales, implementar cálculos de dominio, transacción, adjunto, PDF, estado irreversible y permiso específico. Requiere pruebas doradas comparando WinForms y Web.

### Fase L — Expediente e impresión integral

Consolidar pestañas, navegación, estados, PDF de expediente y regresión completa. El módulo pasa como máximo a `PENDIENTE VALIDACIÓN USUARIO`.

## Criterios generales de prueba

1. Usar una copia de base con empleados activos, inactivos, cerrados y liquidados.
2. Comparar cada consulta contra WinForms con la misma cédula.
3. Probar alta, modificación y anulación de cada movimiento.
4. Verificar que una anulación actualice saldos y tablas dependientes atómicamente.
5. Comparar cálculos monetarios con casos dorados y reglas de redondeo.
6. Probar permisos de lectura y modificación por separado cuando se definan.
7. Probar adjuntos PDF, imagen, archivo inválido, archivo grande y descarga no autorizada.
8. Probar concurrencia: dos sesiones modificando el mismo registro.
9. Probar errores SQL/SAP sin pérdida parcial de datos.
10. Verificar auditoría con usuario, operación, empleado y resultado.
11. Ejecutar pruebas automatizadas y recorrido manual en Visual Studio.
12. No marcar `VALIDADO` hasta la confirmación manual del usuario.

## Riesgos específicos

- **Crítico:** fórmulas de vacaciones y liquidación sin especificación independiente del código legado.
- **Crítico:** cambios de salario, saldos o estado repartidos en múltiples sentencias sin transacción.
- **Crítico:** incapacidad anulada sin sincronizar su detalle de planilla.
- **Alto:** eliminación por nombre de empresa/institución puede afectar registros ambiguos.
- **Alto:** adjuntos binarios sin límites y validación completa.
- **Alto:** estados numéricos con significado implícito.
- **Alto:** diferencias de redondeo entre `Double` legado y `decimal` web.
- **Medio:** consultas históricas sin paginación.
- **Medio:** una única política de permisos para todo el módulo.
