# Migración de recursos humanos

Fuentes heredadas: `Planilla_Empleados.vb`, `dbo.Empleado`, `Empleado_Vacaciones`, `Empleado_Incapacidades`, `Empleado_Deducciones` y `Empleado_ValesPrestamos`.

La sección `/Employees` incorpora búsqueda del personal y un expediente web consolidado con datos laborales, salario, vacaciones, incapacidades, deducciones y vales/préstamos. Desde el expediente se pueden registrar y anular esos cuatro tipos de movimiento, además de administrar educación y experiencia laboral. Las consultas y mutaciones están parametrizadas y el acceso exige el permiso de planillas.

Quedan para incrementos posteriores los adjuntos, aguinaldo y la conciliación final de reglas históricas. Antes del piloto deben verificarse nulabilidad y significado histórico de `Estado`, porcentajes por quincena y saldos de vacaciones/préstamos.
