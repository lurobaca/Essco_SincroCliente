# Migración de recursos humanos

Fuentes heredadas: `Planilla_Empleados.vb`, `dbo.Empleado`, `Empleado_Vacaciones`, `Empleado_Incapacidades`, `Empleado_Deducciones` y `Empleado_ValesPrestamos`.

La sección `/Employees` incorpora búsqueda del personal y un expediente web consolidado con datos laborales, salario, vacaciones, incapacidades, deducciones y vales/préstamos. Las consultas están parametrizadas y el acceso exige el permiso de planillas.

El siguiente incremento habilitará mutaciones con validación, auditoría y manejo de adjuntos. Antes del piloto deben verificarse nulabilidad y significado histórico de `Estado`, porcentajes por quincena y saldos de vacaciones/préstamos.
