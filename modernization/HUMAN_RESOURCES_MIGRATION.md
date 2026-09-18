# Migración de recursos humanos

Fuentes heredadas: `Planilla_Empleados.vb`, `dbo.Empleado`, `Empleado_Vacaciones`, `Empleado_Incapacidades`, `Empleado_Deducciones` y `Empleado_ValesPrestamos`.

La sección `/Employees` incorpora búsqueda, alta y edición del personal y un expediente web consolidado con datos laborales, salario, vacaciones, incapacidades, deducciones y vales/préstamos. Puesto y categoría reproducen las listas cerradas del diseñador WinForms y también se validan en servidor. Desde el expediente se pueden registrar y anular esos cuatro tipos de movimiento, además de administrar educación, experiencia laboral y adjuntos. Las consultas y mutaciones están parametrizadas y el acceso exige el permiso de planillas.

El expediente incorpora aumentos salariales transaccionales: registra el historial y actualiza el salario vigente como una sola operación. También administra los adicionales heredados `Viaticos` y `Combustibles`, incluido su historial y anulación.

Quedan para incrementos posteriores la fotografía, días adicionales, liquidación laboral y la conciliación final de reglas históricas. El aguinaldo se administra desde Planillas. Antes del piloto deben verificarse nulabilidad y significado histórico de `Estado`, porcentajes por quincena y saldos de vacaciones/préstamos.
