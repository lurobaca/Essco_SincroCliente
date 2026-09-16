# Migración de facturación electrónica

Fuentes heredadas: `Facturacion.vb`, `BuscaFactura.vb`, `Lista_Facturas.vb`, `dbo.CE_FE` y `dbo.CE_FE1`.

La sección `/Billing` incorpora búsqueda parametrizada por documento, clave, cliente, fechas y estado de Hacienda. El detalle conserva clave, consecutivo, identificación del receptor, moneda, totales, CABYS, código de tarifa y exoneraciones de cada línea.

Esta primera vertical es de consulta para evitar que la aplicación web emita comprobantes antes de completar la sustitución segura de consecutivos, XML, XAdES, OAuth y recepción de Hacienda. No se reutilizarán certificados ni credenciales del cliente WinForms dentro del proceso web; la transmisión será un trabajo aislado e idempotente y deberá validarse en sandbox oficial antes de habilitar emisión.
