# Inventario de integraciones

Generado por `tools/Generate-IntegrationInventory.ps1`. Los conteos representan coincidencias estáticas, no operaciones funcionales confirmadas.

| Integración | Archivos afectados | Coincidencias | Destino arquitectónico |
|---|---:|---:|---|
| Archivos locales | 12 | 250 | Infrastructure mediante interfaz de Application |
| Correo SMTP | 9 | 58 | Infrastructure mediante interfaz de Application |
| Crystal Reports | 49 | 1103 | Sustituir por web/PDF o puente temporal |
| Firma electrónica/XAdES | 5 | 22 | Infrastructure mediante interfaz de Application |
| FTP | 10 | 25 | Infrastructure mediante interfaz de Application |
| Google | 1 | 8 | Infrastructure mediante interfaz de Application |
| Hacienda Costa Rica | 34 | 294 | Infrastructure mediante interfaz de Application |
| HTTP/REST | 3 | 14 | Infrastructure mediante interfaz de Application |
| Impresión | 6 | 67 | SapBridge.Worker o adaptador Windows |
| Microsoft Office/Excel | 8 | 46 | Infrastructure mediante interfaz de Application |
| QR/código de barras | 4 | 22 | Infrastructure mediante interfaz de Application |
| SAP Business One | 14 | 88 | SapBridge.Worker o adaptador Windows |
| XML | 13 | 38 | Infrastructure mediante interfaz de Application |

## Ubicaciones

| Integración | Archivo | Coincidencias |
|---|---|---:|
| Archivos locales | Play/Class/Class_FTP.vb | 2 |
| Archivos locales | Play/Class/Comunicacion.vb | 18 |
| Archivos locales | Play/Class/CrearArchivo.vb | 175 |
| Archivos locales | Play/Class/ExportarAExcell.vb | 1 |
| Archivos locales | Play/Class/Planilla/ArchivoTXT.vb | 1 |
| Archivos locales | Play/Enviar_Info_Seller.vb | 6 |
| Archivos locales | Play/frmReporte.vb | 1 |
| Archivos locales | Play/frmReportes.vb | 7 |
| Archivos locales | Play/LogicaNegocio/PlanillaBL.vb | 1 |
| Archivos locales | Play/Planilla_Empleados.vb | 14 |
| Archivos locales | Play/ReporteDeDevoluciones.vb | 16 |
| Archivos locales | Play/ReportesDeCarga.vb | 8 |
| Correo SMTP | Play/Class/Class_MAIL.vb | 49 |
| Correo SMTP | Play/Class/Class_Sonar.vb | 1 |
| Correo SMTP | Play/Class/Class_VariablesGlobales.vb | 2 |
| Correo SMTP | Play/Class/Comunicacion.vb | 1 |
| Correo SMTP | Play/Class/VariablesGlobales.vb | 1 |
| Correo SMTP | Play/Class/XML_Generator.vb | 1 |
| Correo SMTP | Play/InfoMsjHacienda.vb | 1 |
| Correo SMTP | Play/Planilla.vb | 1 |
| Correo SMTP | Play/Variables.vb | 1 |
| Crystal Reports | Play/Class/ExportarAExcell.vb | 3 |
| Crystal Reports | Play/frmReporte.Designer.vb | 18 |
| Crystal Reports | Play/frmReporte.vb | 88 |
| Crystal Reports | Play/frmReportes.vb | 44 |
| Crystal Reports | Play/Liquidacion_Agentes.vb | 5 |
| Crystal Reports | Play/Pedido_Principal.vb | 4 |
| Crystal Reports | Play/Planilla.vb | 2 |
| Crystal Reports | Play/PlanillaReport.Designer.vb | 18 |
| Crystal Reports | Play/PlanillaReport.vb | 8 |
| Crystal Reports | Play/Report_Faltantes_Choferes.Designer.vb | 18 |
| Crystal Reports | Play/Report_Faltantes_Choferes.vb | 6 |
| Crystal Reports | Play/Report_Faltantes.Designer.vb | 18 |
| Crystal Reports | Play/Report_Faltantes.vb | 6 |
| Crystal Reports | Play/Reportes/ColillaDePagoResumenPlanilla..vb | 20 |
| Crystal Reports | Play/Reportes/CrystalReports.vb | 18 |
| Crystal Reports | Play/Reportes/EtiquetasUbicacionesVertica.vb | 19 |
| Crystal Reports | Play/Reportes/ExpedienteEmpleado.vb | 37 |
| Crystal Reports | Play/Reportes/HojaCarta_FE.vb | 24 |
| Crystal Reports | Play/Reportes/HojaCarta_FEC.vb | 22 |
| Crystal Reports | Play/Reportes/HojaCarta_FES.vb | 24 |
| Crystal Reports | Play/Reportes/HojaCarta_ND.vb | 24 |
| Crystal Reports | Play/Reportes/HojaCarta_NDS.vb | 24 |
| Crystal Reports | Play/Reportes/HojaCarta_TE.vb | 24 |
| Crystal Reports | Play/Reportes/NotasCredito_NC.vb | 22 |
| Crystal Reports | Play/Reportes/NotasCredito_NCS.vb | 24 |
| Crystal Reports | Play/Reportes/OrdenDeCompra.vb | 19 |
| Crystal Reports | Play/Reportes/PlanillaFinal.vb | 22 |
| Crystal Reports | Play/Reportes/SolicitudVacaciones.vb | 19 |
| Crystal Reports | Play/Reportes/ValesPrestamos.vb | 19 |
| Crystal Reports | Play/Resources/ConstanciaSalarial.vb | 20 |
| Crystal Reports | Play/Resources/ConstanciaSalarial2.vb | 20 |
| Crystal Reports | Play/Resources/Depositos2.vb | 21 |
| Crystal Reports | Play/Resources/Facturas_sin_bodega_1v2.vb | 24 |
| Crystal Reports | Play/Resources/Gastos2.vb | 23 |
| Crystal Reports | Play/Resources/LiquidacionAgentes.vb | 35 |
| Crystal Reports | Play/Resources/LiquidacionAgentes2.vb | 35 |
| Crystal Reports | Play/Resources/LiquidacionChoferes.vb | 41 |
| Crystal Reports | Play/Resources/LiquidacionChoferes02.vb | 43 |
| Crystal Reports | Play/Resources/NotasCredito_PContinuo.vb | 20 |
| Crystal Reports | Play/Resources/Recibos2.vb | 23 |
| Crystal Reports | Play/Resources/RepCargaSector1.vb | 21 |
| Crystal Reports | Play/Resources/Reporte de Carga Faltantes.vb | 19 |
| Crystal Reports | Play/Resources/Reporte_Carga_XSector.vb | 21 |
| Crystal Reports | Play/Resources/Reporte_ResumenLiqAgentes.vb | 25 |
| Crystal Reports | Play/Resources/Reporte_ResumenLiqChoferes.vb | 25 |
| Crystal Reports | Play/Resources/Reporte_ResumenLiqChoferes2.vb | 25 |
| Crystal Reports | Play/Resources/ResultadosLiquidaciones.vb | 21 |
| Crystal Reports | Play/Resources/ResumenLiqAgentes.vb | 21 |
| Crystal Reports | Play/Resources/ResumenLiqChoferes.vb | 21 |
| Firma electrónica/XAdES | Play/Class/ATV_Class.vb | 1 |
| Firma electrónica/XAdES | Play/Class/Firma.vb | 18 |
| Firma electrónica/XAdES | Play/Class/VariablesGlobales.vb | 1 |
| Firma electrónica/XAdES | Play/packages.config | 1 |
| Firma electrónica/XAdES | Play/Resources/ConexionINFO.xml | 1 |
| FTP | Play/Class/Class_FTP.vb | 10 |
| FTP | Play/Class/Class_VariablesGlobales.vb | 2 |
| FTP | Play/Class/Comunicacion.vb | 1 |
| FTP | Play/Class/CrearArchivo.vb | 3 |
| FTP | Play/Class/XML_Generator.vb | 1 |
| FTP | Play/EstadoSubida.vb | 1 |
| FTP | Play/ReporteDeDevoluciones.vb | 4 |
| FTP | Play/ReportesDeCarga.vb | 1 |
| FTP | Play/Resources/ConexionINFO.xml | 1 |
| FTP | Play/Variables.vb | 1 |
| Google | Play/Class/GoogleControl.vb | 8 |
| Hacienda Costa Rica | Play/Acepta_Rechaza_Lista_Comprobantes.Designer.vb | 1 |
| Hacienda Costa Rica | Play/Acepta_Rechaza_Lista_Comprobantes.vb | 4 |
| Hacienda Costa Rica | Play/Acepta_Rechaza.Designer.vb | 16 |
| Hacienda Costa Rica | Play/Acepta_Rechaza.vb | 11 |
| Hacienda Costa Rica | Play/Admin_Clientes.vb | 2 |
| Hacienda Costa Rica | Play/Admin_EstadoComprobantes.vb | 33 |
| Hacienda Costa Rica | Play/Class/ClasesJson.vb | 2 |
| Hacienda Costa Rica | Play/Class/Class_funcionesSQL.vb | 28 |
| Hacienda Costa Rica | Play/Class/Class_MAIL.vb | 4 |
| Hacienda Costa Rica | Play/Class/Class_VariablesGlobales.vb | 4 |
| Hacienda Costa Rica | Play/Class/Class_XML_Conexion.vb | 1 |
| Hacienda Costa Rica | Play/Class/Comunicacion.vb | 71 |
| Hacienda Costa Rica | Play/Class/Firma.vb | 1 |
| Hacienda Costa Rica | Play/Class/Hacienda.vb | 2 |
| Hacienda Costa Rica | Play/Class/QR_CODE.vb | 1 |
| Hacienda Costa Rica | Play/Class/TokenHacienda.vb | 11 |
| Hacienda Costa Rica | Play/Class/VariablesGlobales.vb | 1 |
| Hacienda Costa Rica | Play/Class/XML_Generator.vb | 6 |
| Hacienda Costa Rica | Play/ClientesDocumentosExoneracion.Designer.vb | 1 |
| Hacienda Costa Rica | Play/ClientesDocumentosExoneracion.vb | 2 |
| Hacienda Costa Rica | Play/Detalle_Gastos_Choferes.vb | 1 |
| Hacienda Costa Rica | Play/Detalle_Gastos.vb | 1 |
| Hacienda Costa Rica | Play/DetalleMensajeHacienda.Designer.vb | 2 |
| Hacienda Costa Rica | Play/DetalleMensajeHacienda.vb | 1 |
| Hacienda Costa Rica | Play/Devoluciones.vb | 2 |
| Hacienda Costa Rica | Play/Facturacion.Designer.vb | 23 |
| Hacienda Costa Rica | Play/Facturacion.vb | 5 |
| Hacienda Costa Rica | Play/InfoMsjHacienda.Designer.vb | 4 |
| Hacienda Costa Rica | Play/InfoMsjHacienda.vb | 3 |
| Hacienda Costa Rica | Play/Math_Hacienda.Designer.vb | 17 |
| Hacienda Costa Rica | Play/Math_Hacienda.vb | 15 |
| Hacienda Costa Rica | Play/Principal.Designer.vb | 10 |
| Hacienda Costa Rica | Play/Principal.vb | 6 |
| Hacienda Costa Rica | Play/Resources/ConexionINFO.xml | 2 |
| HTTP/REST | Play/Class/Comunicacion.vb | 8 |
| HTTP/REST | Play/Class/TipoCambio.vb | 2 |
| HTTP/REST | Play/Class/TokenHacienda.vb | 4 |
| Impresión | Play/frmReporte.vb | 32 |
| Impresión | Play/frmReportes.vb | 27 |
| Impresión | Play/Pedido_Principal.vb | 3 |
| Impresión | Play/PlanillaReport.vb | 3 |
| Impresión | Play/Report_Faltantes_Choferes.vb | 1 |
| Impresión | Play/Report_Faltantes.vb | 1 |
| Microsoft Office/Excel | Play/Admin_EstadoComprobantes.vb | 2 |
| Microsoft Office/Excel | Play/Class/Class_CorreoMicrosoft.vb | 2 |
| Microsoft Office/Excel | Play/Class/Class_MAIL.vb | 1 |
| Microsoft Office/Excel | Play/Class/ExportarAExcell.vb | 31 |
| Microsoft Office/Excel | Play/Inv_Control.vb | 2 |
| Microsoft Office/Excel | Play/Pedido_Principal.vb | 3 |
| Microsoft Office/Excel | Play/Planilla.vb | 3 |
| Microsoft Office/Excel | Play/PlanillaNueva.vb | 2 |
| QR/código de barras | Play/Class/QR_CODE.vb | 11 |
| QR/código de barras | Play/Class/SAP_BUSSINES_ONE.vb | 1 |
| QR/código de barras | Play/frmReportes.vb | 9 |
| QR/código de barras | Play/packages.config | 1 |
| SAP Business One | Play/AddRecibo.vb | 1 |
| SAP Business One | Play/Admin_Clientes.vb | 2 |
| SAP Business One | Play/Class/Class_VariablesGlobales.vb | 3 |
| SAP Business One | Play/Class/Comunicacion.vb | 1 |
| SAP Business One | Play/Class/SAP_BUSSINES_ONE.vb | 68 |
| SAP Business One | Play/Class/VariablesGlobales.vb | 1 |
| SAP Business One | Play/Devoluciones.vb | 2 |
| SAP Business One | Play/Liquidacion_Choferes.vb | 1 |
| SAP Business One | Play/Pedido_Principal.vb | 3 |
| SAP Business One | Play/Principal.vb | 1 |
| SAP Business One | Play/ReporteDeDevoluciones.vb | 1 |
| SAP Business One | Play/RevisaDepositos.vb | 2 |
| SAP Business One | Play/Stock_Manager.vb | 1 |
| SAP Business One | Play/Variables.vb | 1 |
| XML | Play/Acepta_Rechaza_Lista_Comprobantes.vb | 3 |
| XML | Play/Acepta_Rechaza.vb | 6 |
| XML | Play/Class/Class_VariablesGlobales.vb | 2 |
| XML | Play/Class/Class_XML_Conexion.vb | 5 |
| XML | Play/Class/Comunicacion.vb | 8 |
| XML | Play/Class/Funciones.vb | 2 |
| XML | Play/Class/Lector_XML.vb | 5 |
| XML | Play/Class/SAP_BUSSINES_ONE.vb | 1 |
| XML | Play/Class/TipoCambio.vb | 1 |
| XML | Play/Class/VariablesGlobales.vb | 1 |
| XML | Play/Class/XML_Generator.vb | 2 |
| XML | Play/Principal.vb | 1 |
| XML | Play/Variables.vb | 1 |
