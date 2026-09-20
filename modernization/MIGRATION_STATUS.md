# Estado maestro de migración

Actualizado: 2026-09-19.

Ningún módulo se marca `VALIDADO` sin confirmación manual del usuario.

## Criterio global

Todo el seguimiento se rige por [FUNCTIONAL_PARITY_STANDARD.md](FUNCTIONAL_PARITY_STANDARD.md). La unidad mínima no es la página ni el Form, sino la acción funcional con su evento, reglas, datos, efectos secundarios, equivalente Web y prueba.

Los estados generales históricos de otros módulos son provisionales hasta que cada módulo sea reauditado con esta granularidad durante su turno vertical. No deben interpretarse como paridad demostrada.

## Empleados

**Origen:** `Planilla_Empleados`, `Planilla_List_Empleados`, `PlanillaEmpleado_HistorialAbonosVales` y reportes relacionados.

**Web:** `/Employees`, `EmployeeService`, servicios de movimientos, compensación, adjuntos y antecedentes, y repositorios SQL correspondientes.

**Estado:** Fase A `PENDIENTE VALIDACIÓN USUARIO`; el módulo completo continúa `ANALIZADO` porque las fases B–L no están cerradas.

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
| Vacaciones | Parcial | No | EN DESARROLLO; Fase E |
| Incapacidades | Parcial | No | EN DESARROLLO; Fase F |
| Deducciones | Parcial | No | EN DESARROLLO; Fase G |
| Vales y préstamos | Parcial | No | EN DESARROLLO; Fase H |
| Adjuntos | Parcial | No | EN DESARROLLO; fase posterior |
| Aumentos / Adicionales | Parcial | No | EN DESARROLLO; Fase I |
| Días adicionales | No | No | NO INICIADO; Fase J |
| Facturas / Planillas / Liquidación | Parcial o no | No | NO INICIADO; Fases D/K |

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
