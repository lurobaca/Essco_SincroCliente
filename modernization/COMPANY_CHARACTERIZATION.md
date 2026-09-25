# Caracterización funcional — Empresa

Estado del módulo: **PARCIAL**. Fuente de verdad: `Play/Manager_Empresa.vb`, `Play/Manager_Empresa.Designer.vb` y los métodos directamente invocados de `Play/Class/Class_funcionesSQL.vb`. Esta caracterización describe el código original; no sustituye una prueba manual. Ninguna acción de Empresa se marca `VALIDADA POR USUARIO`.

## Inventario de pestañas

### Empresa

- **Función:** mantenimiento del único registro de empresa.
- **Campos:** tipo y número de cédula, nombre, nombre de fantasía, teléfonos, correo, contraseña de correo, web, dirección, provincia, cantón, distrito, barrio, código y descripción de actividad económica.
- **Botones:** `Nuevo`, `Guardar`, `Modificar` y `Eliminar` están en el panel compartido. `Eliminar` no tiene evento conectado.
- **Eventos:** `Load` consulta empresa y catálogos; `Nuevo` llama a `Limpia`; `Guardar` inserta; `Modificar` actualiza; `KeyPress` y `TextChanged` restringen o advierten sobre entradas; los cuatro `SelectedIndexChanged` encadenan ubicaciones; `FormClosing` advierte si no existe empresa, pero no impide cerrar.
- **Tablas/consultas:** `dbo.Empresa` mediante `CONSULTA_Empresa`, `INSERTA_Empresa`, `Actualiza_Empresa` y `ExisteEmpresa`; `dbo.Ubicaciones_CostaRica` mediante `ObtieneProvincias`, `ObtieneCantones`, `ObtieneDistritos` y `ObtieneBarrios`. No se encontró stored procedure, reporte, impresión, grid, archivo, imagen ni llamada directa a SAP en este formulario.
- **Reglas:** `Guardar` exige múltiples campos, incluso contraseña de correo y configuración SQL; `Modificar` convierte teléfonos vacíos en `0`. La cédula limita entrada según tipo; la validación de longitud en `TextChanged` es una advertencia, no una comprobación de persistencia. `Limpia` deja varios campos sin limpiar. Los combos originales persisten índices de selección, no necesariamente IDs; el evento de barrio asigna el índice de distrito a `Id_Barrio`. No corregir estas divergencias silenciosamente.
- **Dependencias:** conexión SQL heredada, permisos de apertura desde `Principal`, catálogo geográfico. La contraseña de correo y demás secretos compartidos con Configuraciones requieren tratamiento separado.
- **Estado actual en Web:** **PARCIAL**. `/Companies/Profile` consulta y guarda un subconjunto de datos, con permiso `company.manage`, auditoría y ubicaciones encadenadas. No hay prueba manual de paridad ni esquema verificado.

### Configuraciones

- **Función:** parámetros de facturación y descuentos, razones de no visita, configuración FTP y conexión SQL/SAP Business One.
- **Campos:** máximo de líneas de factura, descuento máximo, días de extensión, consecutivos de reportes de carga y devoluciones; razón seleccionada y razón editable; ruta padre, servidor, usuario y clave FTP; servidor SQL, IP, usuario y clave SQL; radio de agrupación de descuentos (`2` socio específico / `10` grupo de clientes). `CBox_UtilozoSAP` y el grupo de descuentos están ocultos en el diseñador; los cuatro controles FTP están deshabilitados allí.
- **Botones:** panel compartido `Guardar`/`Modificar` persiste los parámetros junto con la empresa. `btn_Razon` y `btn_EliminaRazon` tienen controles visibles/ocultos, pero sus métodos no tienen `Handles` ni se encontró `AddHandler`. `Eliminar` compartido tampoco tiene evento conectado.
- **Eventos:** `Load` consulta empresa y lista razones; existen métodos para nuevo/guardar/modificar/eliminar razón y selección de razón, pero están desconectados del UI según el código inspeccionado.
- **Tablas/consultas:** `dbo.Empresa` para parámetros y credenciales; `dbo.Razones_NoVisita` con `CONSULTA_RazonesNoVisita`, `Inserta_Razones_NoVisita`, `Actualizar_Razones_NoVisita` y `Elimina_Razon`. No se encontró stored procedure ni transacción explícita en esos métodos; el SQL heredado concatena valores. El formulario no invoca SAP directamente: el grupo «SAP Bussines one» almacena configuración SQL.
- **Reglas:** el guardado de empresa exige varios secretos aun cuando algunos controles FTP están deshabilitados; el método de modificar razón usa índice del combo como `Codigo`, diferencia potencial frente a la clave real. No reproducir SQL concatenado ni exponer secretos en HTML.
- **Dependencias:** configuración de correo, FTP y SQL empleada fuera de este formulario; catálogo de razones de no visita. Su migración segura necesita acordar almacenamiento de secretos y cotejar datos reales.
- **Estado actual en Web:** **PARCIAL**. Los parámetros no secretos están en `/Companies/Profile`; razones tienen mantenimiento independiente en Catálogos, pero no están integradas como bloque de Empresa. Credenciales y servidores están excluidos deliberadamente del perfil web; no equivalen todavía a una administración segura de Configuraciones.

## Trazabilidad por acción

| Nº | Pestaña | Acción WinForms y ruta | Equivalente Web actual | Estado | Pendiente concreto |
|---:|---|---|---|---|---|
| 1 | Empresa | `Load` → `CONSULTA_Empresa` → `dbo.Empresa` | GET `/Companies/Profile` | IMPLEMENTADA PENDIENTE VALIDACIÓN | Cotejar fila y esquema reales. |
| 2 | Empresa | `Load` y cambios en provincia/cantón/distrito → `Ubicaciones_CostaRica` | Endpoints geográficos encadenados | IMPLEMENTADA PENDIENTE VALIDACIÓN | Cotejar índices heredados frente a IDs reales. |
| 3 | Empresa | `Nuevo` → `Limpia` (limpieza incompleta) | Formulario permite alta al no existir fila | PARCIAL | Definir UX explícita de alta y criterio de campos; no replicar borrado incompleto sin decisión. |
| 4 | Empresa | `Guardar` → validación → `INSERTA_Empresa` | POST con upsert transaccional | PARCIAL | La inserción original exige secretos hoy excluidos; validar escenario de primera alta. |
| 5 | Empresa | `Modificar` → `Actualiza_Empresa` | POST con upsert transaccional y auditoría | PARCIAL | Verificar todos los campos, reglas y error de guardado con SQL real. |
| 6 | Empresa | Cédula/teléfono/nombre: `KeyPress` y `TextChanged` | Validación de dominio/servidor | PARCIAL | Comparar longitudes por tipo; revisar error en control de nombre de fantasía. |
| 7 | Empresa | `FormClosing` → `ExisteEmpresa` → advertencia | Sin equivalente directo | NO MIGRADA | Definir aviso no bloqueante en navegación web si aporta valor. |
| 8 | Empresa | `Eliminar`: control sin `Click` conectado | Ninguno | NO MIGRADA | Confirmar con usuario si se requiere eliminación; no crear borrado de registro único sin autorización. |
| 9 | Configuraciones | `Load` → parámetros de `Empresa` | GET del perfil muestra parámetros no secretos | IMPLEMENTADA PENDIENTE VALIDACIÓN | Cotejar valores reales. |
| 10 | Configuraciones | `Guardar`/`Modificar` → parámetros y agrupación en `Empresa` | POST del perfil guarda parámetros no secretos | PARCIAL | Verificar consecutivos, límites y agrupación oculta. |
| 11 | Configuraciones | `Load` → `CONSULTA_RazonesNoVisita` | Catálogo web independiente | PARCIAL | Integrar acceso desde Empresa y comparar listado. |
| 12 | Configuraciones | Crear razón: método existente sin evento conectado → `INSERT` | Catálogo web independiente | PARCIAL | Verificar capacidad web y decidir relación con pestaña. |
| 13 | Configuraciones | Editar razón: método sin evento conectado → `UPDATE Codigo` | Catálogo web independiente | PARCIAL | Confirmar clave y corregir uso heredado del índice solo con evidencia. |
| 14 | Configuraciones | Eliminar razón: método sin evento conectado → `DELETE Razon` | Catálogo web independiente | PARCIAL | Revisar referencias y autorización antes de paridad. |
| 15 | Configuraciones | Consultar/editar clave de correo | Excluido del perfil | NO MIGRADA | Diseñar manejo de secreto sin devolverlo al navegador. |
| 16 | Configuraciones | Consultar/editar ruta y credenciales FTP | Excluido del perfil | NO MIGRADA | Acordar configuración segura; controles heredados deshabilitados. |
| 17 | Configuraciones | Consultar/editar servidor y credenciales SQL/SAP | Excluido del perfil | NO MIGRADA | Acordar almacén de secretos y alcance operativo. |
| 18 | Configuraciones | Opciones `UtilizoSAP`/descuentos ocultas | Agrupación persistida; casilla no expuesta | PARCIAL | Confirmar uso efectivo antes de exponer controles ocultos. |

**Conteo:** 18 acciones trazadas; 3 `IMPLEMENTADA PENDIENTE VALIDACIÓN`, 10 `PARCIAL`, 5 `NO MIGRADA`, 0 `VALIDADA POR USUARIO`. La matriz separa métodos de razones existentes de eventos efectivamente conectados; no presume que los tres botones funcionaran en WinForms.

## SQL, permisos y decisiones

`INSERTA_Empresa` inserta sin transacción explícita y `Actualiza_Empresa` actualiza sin `WHERE`; la Web conserva el concepto de registro único, pero rechaza más de una fila y usa transacción serializable. Esto es una divergencia defensiva documentada, no paridad manual comprobada. Las operaciones de razones heredadas construyen SQL por concatenación; la Web debe conservar el efecto funcional, no esa vulnerabilidad. No se propone cambio de esquema en este bloque.

El menú original abre `Manager_Empresa` desde `Principal`; la Web exige `company.manage` en backend y audita guardados. Falta probar correspondencia de permisos con usuarios reales. Ninguna operación del formulario consulta tablas SAP ni emplea DI API; almacenar parámetros de conexión no equivale a validar SAP.

## Orden vertical y punto de control

1. **Empresa — datos generales:** consulta, alta/edición y ubicaciones, validación de entradas y pruebas con una copia SQL. Resolver divergencias de identificación/índices con evidencia. Detenerse para prueba manual.
2. **Configuraciones — parámetros no secretos:** límites, consecutivos, días y agrupación. Separar su guardado del perfil general si es necesario y probar consumos directos. Detenerse para prueba manual.
3. **Configuraciones — razones de no visita:** verificar catálogo web, enlazarlo de forma clara desde la pestaña y validar CRUD y permisos. No atribuir al WinForms un evento que está desconectado. Detenerse para prueba manual.
4. **Configuraciones — secretos e integraciones:** acordar gestión segura de correo, FTP y SQL/SAP, probar sus consumidores y fallos; no exponer valores ni asumir conexión SAP. Detenerse para prueba manual.
5. Decidir con el usuario si los controles ocultos y `Eliminar` deben permanecer fuera de alcance o convertirse en operaciones nuevas. No implementar borrado del único registro por inferencia.

**Primer punto de control:** la caracterización está terminada; el bloque de datos generales no se considera completo hasta cotejar esquema y registro de prueba. No se ha efectuado validación manual ni conexión a SAP.
