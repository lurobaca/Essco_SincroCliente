# Consecutivo de solicitudes de clientes

La columna heredada Empresa.Conse_Clientes es int. La asignación utiliza incremento directo, compatible con SQL Server 2014 y nivel de compatibilidad 100, dentro de la transacción serializable que guarda la solicitud. No depende de TRY_CONVERT ni reinicia valores inválidos en cero.

Debe existir exactamente una empresa y un consecutivo no nulo entre cero y 2147483646. Cero genera uno; el último valor asignable es 2147483647. Configuración ausente, negativa o agotada produce un error y no asigna un nuevo número. No se modificó la configuración de la empresa para corregirla automáticamente.

Test-CustomerSequenceSql.ps1 ejecuta el literal SQL del repositorio con tablas temporales y rollback. Ocho escenarios aprobados: cero, incremento normal, último número disponible, empresa ausente, empresas duplicadas, nulo, negativo y agotado. Recibe Server, Database y SqlCmd como parámetros; no contiene nombres de servidores ni credenciales.

Pendiente: guardar solicitudes de extremo a extremo con el formulario, probar dos altas concurrentes y verificar el envío a SAP. Las pruebas del consecutivo no certifican esas integraciones.
