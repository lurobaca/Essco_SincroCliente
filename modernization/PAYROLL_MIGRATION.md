# Migración de planillas

Fuentes heredadas: `Planilla.vb`, `Planilla_Empleados.vb`, tablas `Planilla*` y procedimientos `SP_CreaPlanilla`, `SP_FinalizaPlanilla` y `SP_AnulaPlanilla`.

La sección `/Payroll` permite filtrar, crear, consultar, finalizar y anular planillas. El detalle reúne por empleado salario, días trabajados, CCSS, renta, otras deducciones, vales/préstamos, facturas, faltantes de liquidación y salario final.

La creación y los cambios de estado invocan los procedimientos existentes con parámetros tipados y respetan sus códigos de salida. Antes del piloto se deben ejecutar pruebas de caracterización con una copia SQL para aguinaldo, incapacidades, vacaciones, liquidaciones laborales, deducciones fijas, préstamos, asiento contable y archivo bancario.
