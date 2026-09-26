# Estado maestro de migración

Actualizado: 2026-09-19.

## Menú general

La navegación Web refleja el inventario completo de `Principal.MenuStrip1`: 80 acciones terminales funcionales y la acción global de cierre de sesión. Hay 45 accesos utilizables marcados como parciales, 32 no migrados y 3 sujetos a revisión; ninguno se considera validado por aparecer en el menú. Consultar [WINFORMS_MENU_INVENTORY.md](WINFORMS_MENU_INVENTORY.md). El catálogo mantenible está centralizado en `src/Essco.Application/Security/ErpNavigationCatalog.cs`.

Ningún módulo se marca `VALIDADO` sin confirmación manual del usuario.

## Estados de transmisiones

**Estado:** `PARCIAL`. La primera opción del menú web de Facturación consulta `Estado_Subida_SAP`, muestra parte del estado del proceso y permite limpieza delimitada, cambio de origen y marca de reintento con permiso de administración. Nada de esto ha sido validado por el usuario. “Solo subir”, “Recargar y subir” y “Recargar todos” siguen `NO MIGRADA` por depender del archivo de señal y del FTP de Syncro Server. Véase [TRANSMISSION_STATUS_CHARACTERIZATION.md](TRANSMISSION_STATUS_CHARACTERIZATION.md). La base local de pruebas tiene 0 filas en `Estado_Subida_SAP`; no se cambió el esquema ni se avanzó a la siguiente opción del menú.

## Empresa

**Estado:** `PARCIAL`; 18 acciones trazadas: 3 `IMPLEMENTADA PENDIENTE VALIDACIÓN`, 10 `PARCIAL`, 5 `NO MIGRADA` y ninguna `VALIDADA POR USUARIO`. El formulario original tiene dos pestañas, «Empresa» y «Configuraciones». La página web actual no equivale todavía al módulo completo. Consultar [COMPANY_CHARACTERIZATION.md](COMPANY_CHARACTERIZATION.md) para botones, eventos, SQL, divergencias y orden vertical.

**Siguiente bloque:** datos generales, con cotejo de esquema y registro de prueba antes de solicitar validación manual. La Web ya separa las dos pestañas y enlaza el catálogo de razones, pero esto no constituye paridad funcional. No se modificó el esquema SQL ni se confirmó integración SAP.

## Criterio global

Todo el seguimiento se rige por [FUNCTIONAL_PARITY_STANDARD.md](FUNCTIONAL_PARITY_STANDARD.md). La unidad mínima no es la página ni el Form, sino la acción funcional con su evento, reglas, datos, efectos secundarios, equivalente Web y prueba.

Los estados generales históricos de otros módulos son provisionales hasta que cada módulo sea reauditado con esta granularidad durante su turno vertical. No deben interpretarse como paridad demostrada.

## Empleados

**Origen:** `Planilla_Empleados`, `Planilla_List_Empleados`, `PlanillaEmpleado_HistorialAbonosVales` y reportes relacionados.

**Web:** `/Employees`, `EmployeeService`, servicios de movimientos, compensación, adjuntos y antecedentes, y repositorios SQL correspondientes.

**Estado:** Fase A `PENDIENTE VALIDACIÓN USUARIO`; el módulo completo continúa `PARCIAL` porque las fases B–L no están cerradas. El expediente muestra las doce pestañas originales, pero varias acciones todavía abren páginas separadas o están pendientes. En Fase B se implementó la edición de Experiencia y se corrigió la lectura de `EnCurso`; ambas requieren validación manual con SQL real.

**Caracterización:** consultar [EMPLOYEES_CHARACTERIZATION.md](EMPLOYEES_CHARACTERIZATION.md).

### Métrica funcional de caracterización

| Medida | Cantidad |
|---|---:|
| Acciones funcionales trazadas | 92 |
| Migradas y verificadas por Codex | 0 |
| Implementadas, aún sin validación manual | 29 |
| En desarrollo/parciales | 15 |
| Incorrectas o requieren revisión | 0 |
| Analizadas sin implementación cerrada | 2 |
| No migradas | 46 |
| Validadas por el usuario | 0 |

No se publica un porcentaje único: las 92 acciones no tienen la misma complejidad. Pruebas verdes y páginas visibles no se contabilizan como validación funcional.

**Implementado actualmente:**

- listado y búsqueda;
- alta y edición parcial;
- consulta de expediente;
- altas de vacaciones, incapacidades, deducciones y préstamos;
- anulación básica de movimientos;
- adjuntos básicos;
- aumentos y adicionales parciales;
- educación y experiencia parciales.

**Fase A corregida después de validación manual no superada y pendiente de nueva validación:** estado exacto `0/1/2/3`, duplicados con estado explícito, edición solo de activos, transición permitida únicamente `Activo → Inactivo`, campos requeridos accesibles, validación SAP con resultado válido/inválido/no disponible, fotografía visible y previsualizable, auditoría y permisos backend. La configuración local todavía debe indicar `Essco:Sap:CompanyDatabase` para probar valores reales. Compilación: 0 errores/advertencias. Pruebas: 222 unitarias y 10 de integración superadas.

### Realidad de pestañas posteriores

| Sección | Consulta visible | Ciclo funcional completo | Estado |
|---|---|---|---|
| Experiencia / Educación | Parcial | No | EN DESARROLLO; Fases B/C |
| Vacaciones | Parcial | No | PARCIAL; alta y anulación visibles en el expediente; cálculo de saldos pendiente |
| Incapacidades | Parcial | No | EN DESARROLLO; Fase F |
| Deducciones | Parcial | No | EN DESARROLLO; Fase G |
| Vales y préstamos | Parcial | No | EN DESARROLLO; Fase H |
| Adjuntos | Parcial | No | EN DESARROLLO; fase posterior |
| Aumentos / Adicionales | Parcial | No | EN DESARROLLO; Fase I |
| Días adicionales | No | No | NO INICIADO; Fase J |
| Facturas / Planillas / Liquidación | Parcial o no | No | PARCIAL; Facturas consulta y total pendiente de validación; Planillas y Liquidación sin ciclo completo |

Una pestaña o consulta visible no figura como migración cerrada.

**Pendiente de las fases posteriores:**

- edición completa de antecedentes y movimientos;
- historial contextual de planillas;
- cálculos completos de vacaciones;
- historial de abonos de préstamos;
- días adicionales;
- facturas del empleado;
- liquidación laboral;
- reportes e impresión;
- validación manual de Fase A con la base real y confirmación del usuario;

**Dependencias principales:** `Empleado`, tablas `Empleado_*`, historial de planillas, SAP para cuentas/clientes, almacenamiento documental y sustitución de Crystal Reports.

**Siguiente paso sujeto a aprobación después de validar Fase A:** Fase B — Experiencia laboral.
