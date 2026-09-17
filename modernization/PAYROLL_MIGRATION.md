# Migración de planillas

Fuentes heredadas: `Planilla.vb`, `Planilla_Empleados.vb`, tablas `Planilla*` y procedimientos `SP_CreaPlanilla`, `SP_FinalizaPlanilla` y `SP_AnulaPlanilla`.

La sección `/Payroll` permite filtrar, crear, consultar, finalizar y anular planillas. El detalle reúne por empleado salario, días trabajados, CCSS, renta, otras deducciones, vales/préstamos, facturas, faltantes de liquidación y salario final.

La creación y los cambios de estado invocan los procedimientos existentes con parámetros tipados y respetan sus códigos de salida. La planilla de aguinaldo fuerza el período del 1 de diciembre al 30 de noviembre. El detalle permite descargar un TXT bancario con registros HD/DA y encolar el asiento producido por SP_CrearAsientoPlanilla para que el servicio Windows lo registre mediante SAP DI API. La compatibilidad bancaria completa NO está validada. Antes del piloto se deben ejecutar pruebas de caracterización con una copia SQL para incapacidades, vacaciones, liquidaciones laborales, deducciones fijas y préstamos; el asiento SAP requiere además validación con una sociedad de pruebas.

## Revisión del TXT bancario

Se corrigió la referencia del movimiento de crédito según ArchivoTXT.vb: CedulaEmpleado + ".1." + CedulaEmpresa + "1" + IdColaborador. La versión migrada anterior usaba incorrectamente CedulaEmpresa + ".1." + IdColaborador. Se exige identificación del empleado para generar el archivo.

Pendientes identificados: Crear_PlanillaTxt2 usa Now.Date.ToString() (dependiente de la configuración regional) y recorta cinco caracteres de CuentaDeducirPlanilla antes de exportar. La versión web usa yyyyMMdd y la cuenta persistida sin ese recorte. Es necesario contrastar el formato con un archivo aceptado y la forma real del campo de cuenta antes de modificar esos campos o declarar compatibilidad. No se ha enviado ningún archivo al banco.
