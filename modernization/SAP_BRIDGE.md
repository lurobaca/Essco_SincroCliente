# Puente SAP

El worker modela trabajos con estados explícitos, número de intentos, identificador externo y error sanitizado. La clave de idempotencia evita solicitudes duplicadas.

La migración `database/sqlserver/003_sap_job_queue.sql` crea `dbo.WebSapJobs`. Web y Windows Service utilizan esa tabla cuando SQL Server está habilitado. La adquisición usa bloqueos `UPDLOCK/READPAST`, recupera trabajos abandonados después de diez minutos y programa reintentos con espera exponencial limitada a cinco minutos. El modo en memoria queda únicamente como alternativa local cuando SQL está deshabilitado.

Antes de integrar DI API se debe confirmar:

- Versión y arquitectura x86/x64 de SAP Business One y DI API.
- Empresas y ambientes sandbox disponibles.
- Operaciones utilizadas por cada módulo original.
- Política de reintentos y tratamiento de transacciones inciertas.
- Validación de la política final de reintentos con el ambiente SAP.

## Adaptador DI API de Clientes

El Windows Service crea `SAPbobsCOM.Company` mediante COM en un hilo STA dedicado. Implementa alta, modificación y cierre de socios de negocio, incluidos UDF heredados, dirección y conversión histórica de provincia. Tras éxito en SAP marca `ClientesModificados.Aprobado`; ante error conserva la solicitud pendiente y clasifica errores transitorios para reintento.

La configuración `Essco:Sap` contiene servidor, base de compañía, usuario SAP, usuario SQL, license server y el valor numérico de `BoDataServerTypes`. Las contraseñas no deben guardarse en `appsettings.json`: se suministran mediante variables de entorno, secretos protegidos o el almacén de secretos del servidor. El host debe tener instalada y registrada una DI API compatible con la arquitectura publicada.

La cola SQL sobrevive reinicios y funciona como transporte compartido entre procesos. Antes del piloto debe aplicarse la migración `003` y configurarse la misma cadena de conexión en ambos ejecutables.

El proyecto apunta a `net10.0-windows` y registra el host con el nombre `Essco SAP Bridge`, por lo que puede publicarse e instalarse como servicio de Windows. La instalación definitiva se habilitará cuando exista transporte persistente y configuración SAP validada.
