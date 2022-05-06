Public Class VariablesGlobales

    Public Shared IMPRIMIENDO As String
    'PARAMETROS SAP
    Public Shared XMLParamSAP_CompanyDB As String
    Public Shared XMLParamSAP_Password As String
    Public Shared XMLParamSAP_UserName As String
    Public Shared XMLParamSAP_Server As String
    Public Shared XMLParamSAP_DbUserName As String
    Public Shared XMLParamSAP_DbPassword As String
    Public Shared XMLParamSAP_LicenseServer As String
    Public Shared Obj_Clas_XML As New Class_XML_Conexion
    Public Shared Obj_Log As New Log_Manager
    'PARAMETROS FTP
    Public Shared XMLParamFTP_Server As String
    Public Shared XMLParamFTP_user As String
    Public Shared XMLParamFTP_Password As String
    Public Shared XMLParamFTP_dirLocal As String

    'PARAMETROS SQL
    Public Shared XMLParamSQL_user As String = "sa"
    Public Shared XMLParamSQL_clave As String = "Bourn3"
    Public Shared XMLParamSQL_server As String = "SAP"
    Public Shared XMLParamSAP_DB As String = "BD_Bourne"
    Public Shared XMLParamSQL_dababase As String

    Public Shared ReporteTE_Consecutivo As String = ""
    Public Shared ReporteFE_Consecutivo As String = ""
    Public Shared ReporteFES_Consecutivo As String = ""
    Public Shared ReporteNC_Consecutivo As String = ""
    Public Shared ReporteNCS_Consecutivo As String = ""
    Public Shared ReporteND_Consecutivo As String = ""
    Public Shared ReporteNDS_Consecutivo As String = ""

    Public Shared ReporteTE_Clave As String = ""
    Public Shared ReporteFE_Clave As String = ""
    Public Shared ReporteFES_Clave As String = ""
    Public Shared ReporteNC_Clave As String = ""
    Public Shared ReporteNCS_Clave As String = ""
    Public Shared ReporteND_Clave As String = ""
    Public Shared ReporteNDS_Clave As String = ""

    Public Shared Patch_FEC As String = "\\SAP2\XMLs\FE"
    Public Shared Patch_FE As String = "\\SAP2\XMLs\FE"
    Public Shared Patch_NC As String = "\\SAP2\XMLs\NC"
    Public Shared Patch_ND As String = "\\SAP2\XMLs\ND"
    Public Shared Patch_TE As String = "\\SAP2\XMLs\TE"
    Public Shared Patch_MR As String = "\\SAP2\XMLs\MR"
    Public Shared Patch_Certificado As String = "\\SAP2\XMLs\Certificado\310120057532.p12"
    Public Shared ATV_Usuario As String = "cpj-3-101-200575@stag.comprobanteselectronicos.go.cr"
    Public Shared ATV_Password As String = "($hAU#](jHBg}ZK!o$#:"
    Public Shared Certificado_PIN As String = "1234"

    Public Shared URL_RECEPCION As String = ""
    Public Shared IDP_CLIENT_ID As String = ""
    Public Shared IDP_URI As String = ""
    Public Shared TOKEN As String = ""
    Public Shared TOKEN_REFRESH As String = ""

    Public Shared PRINT_FE As String = ""
    Public Shared PRINT_NC As String = ""
    Public Shared PRINT_ND As String = ""

    Public Shared PRINT_FES As String = ""
    Public Shared PRINT_NCS As String = ""
    Public Shared PRINT_NDS As String = ""
    Public Shared Patch_PDFMR As String = ""

    Public Shared estado As String = ""
    Public Shared ComprobantesSubidos As Boolean = False

    'Public Shared Patch_FE As String = "C:\wamp\www\Proyectos_Wamp\Tributacion\Factura Electronica\XMLs\FE"
    'Public Shared Patch_NC As String = "C:\wamp\www\Proyectos_Wamp\Tributacion\Factura Electronica\XMLs\NC"
    'Public Shared Patch_ND As String = "C:\wamp\www\Proyectos_Wamp\Tributacion\Factura Electronica\XMLs\ND"
    'Public Shared Patch_TE As String = "C:\wamp\www\Proyectos_Wamp\Tributacion\Factura Electronica\XMLs\TE"
    'Public Shared Patch_MR As String = "C:\wamp\www\Proyectos_Wamp\Tributacion\Factura Electronica\XMLs\MR"

    Public Shared ReceptorEmail As String = ""

    Public Shared EmisorEmail As String = ""

    Public Shared EstadoComprobante As String = "" 'almacena el estado del comprobante
    Public Shared MensajeRespuestaH As String = "" 'almacena el mensaje de respuesta de hacienda
    Public Shared GPatch_XML As String = ""
    Public Shared GPatch_PDF As String = ""
    Public Shared GPatch_RH As String = ""
    Public Shared GNotificado As Boolean = False

    Public Shared Obj_SQL As New Class_funcionesSQL
    Public Shared Obj_Mail As New Class_MAIL
    Public Shared GCodMensaje As String
    Public Shared GDetalleMensaje As String




    'Public Shared oCompany As SAPbobsCOM.Company



End Class
