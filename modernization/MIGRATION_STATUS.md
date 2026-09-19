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
| Acciones funcionales trazadas | 82 |
| Migradas y verificadas por Codex | 15 |
| Implementadas, aún sin verificación completa | 14 |
| En desarrollo/parciales | 12 |
| Incorrectas o requieren revisión | 0 |
| Analizadas sin implementación cerrada | 1 |
| No migradas | 40 |
| Validadas por el usuario | 0 |

No se publica un porcentaje único: las 82 acciones no tienen la misma complejidad. Por ejemplo, consultar experiencia y calcular una liquidación laboral no representan un esfuerzo ni un riesgo equivalentes.

**Implementado actualmente:**

- listado y búsqueda;
- alta y edición parcial;
- consulta de expediente;
- altas de vacaciones, incapacidades, deducciones y préstamos;
- anulación básica de movimientos;
- adjuntos básicos;
- aumentos y adicionales parciales;
- educación y experiencia parciales.

**Fase A implementada y pendiente de validación manual:** listado/búsqueda, semántica real de estados (`0` activo), alta/edición, catálogos heredados, campos obligatorios, salario mínimo y derivados, antigüedad, fotografía, validaciones SAP parametrizadas, inactivación confirmada, auditoría y permisos separados de consulta/mantenimiento. Compilación: 0 errores/advertencias. Pruebas: 209 unitarias y 10 de integración superadas.

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
